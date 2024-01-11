using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Text;
using System.Transactions;
using VirtualStore.Discount.Core.Arguments;
using VirtualStore.Discount.Core.Exceptions;
using VirtualStore.Discount.Core.Models;
using VirtualStore.Discount.Core.Repositories.Interfaces;

namespace VirtualStore.Discount.Core.Repositories;

public class DiscountRepository : BaseRepository, IDiscountRepository
{
    private readonly ILogger<DiscountRepository> _logger;

    public DiscountRepository(
        IConfiguration configuration, 
        ILogger<DiscountRepository> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<CouponModel> GetCoupon(string couponCode, bool getUsers = false, bool getCategories = false)
    {
        using IDbConnection connection = GetConnection();

        string query = @"
                        SELECT
                            c.CouponID,
                            c.Code,
                            c.DiscountPercent,
                            c.CreatedDate,
                            c.ExpiresDate,
                            c.LastModifiedDate,
                            c.IsActive,
    
                            cc.CategoryId,
                            cc.CategoryName AS Name,
    
                            cuh.CouponUsageHistoryID,
                            cuh.CouponID,
                            cuh.CartID,
                            cuh.OrderId,
                            cuh.ValueOfProducts,
                            cuh.DiscountAmount,
                            cuh.CreatedDate,
                            cuh.LastModifiedDate,
                            cuh.IsActive,
    
                            cuh.UserID,
                            cuh.Username
                        FROM Coupon c
                        LEFT JOIN CouponCategory cc ON c.CouponID = cc.CouponID AND cc.IsActive = true
                        LEFT JOIN CouponUsageHistory cuh ON c.CouponID = cuh.CouponID AND cuh.IsActive = true
                        WHERE c.Code = @CouponCode AND c.IsActive = true;";

        try
        {
            Dictionary<int, CouponModel> couponDataDict = new();
            return (await connection.QueryAsync<CouponModel>(
                sql: query,
                param: new { CouponCode = couponCode },
                transaction: null,
                buffered: true,
                splitOn: "CategoryId, CouponUsageHistoryID, UserId",
                types: new[]
                {
                    typeof(CouponModel),
                    typeof(CategoryModel),
                    typeof(CouponUsageHistoryModel),
                    typeof(UserModel)
                },
                map: obj =>
                {
                    CouponModel couponTemp;
                    CouponModel coupon = obj[0] as CouponModel;
                    CategoryModel category = obj[1] as CategoryModel;
                    CouponUsageHistoryModel couponUsageHistory = obj[2] as CouponUsageHistoryModel;
                    UserModel user  = obj[3] as UserModel;

                    if(!couponDataDict.TryGetValue(coupon.CouponId, out couponTemp))
                    {
                        couponTemp = coupon;
                        couponDataDict.Add(coupon.CouponId, couponTemp);
                    }

                    if (getCategories)
                    {
                        couponTemp.Categories ??= new List<CategoryModel>();

                        if (category != null && !couponTemp.Categories.Any(c => c.CategoryId == category.CategoryId))
                            couponTemp.Categories.Add(category);
                    }

                    if (getUsers)
                    {
                        couponTemp.Usagehistory ??= new CouponUsageHistoryModel();

                        if (couponUsageHistory != null)
                            couponTemp.Usagehistory = couponUsageHistory;


                        couponTemp.Usagehistory.Users ??= new List<UserModel>();

                        if (user != null && !couponTemp.Usagehistory.Users.Any(u => u.UserId == user.UserId))
                            couponTemp.Usagehistory.Users.Add(user);
                    }

                    return couponTemp;
                })).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError("Unable to obtain {0} coupon. {1}", couponCode, ex.Message);
            throw new CouponException(string.Format("Unable to obtain {0} coupon.", couponCode));
        }
    }

    public async Task<CouponModel> SaveCoupon(CouponArgument argument)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            CouponModel coupon = await SaveCoupon(argument, connection, transaction);
            argument.Categories.ForEach(category => category.CouponID = coupon.CouponId);
            IEnumerable<CouponCategoryModel> couponCategory = await SaveCouponCategory(argument, connection, transaction);

            coupon.Categories = couponCategory.Select(category =>
            {
                return new CategoryModel()
                {
                    Name = category.CategoryName,
                    CategoryId = category.CategoryId
                };
            }).ToList();

            transaction.Commit();

            return coupon;
        }
        catch (CouponException) { transaction.Rollback(); throw; }
        catch(Exception ex)
        {
            transaction.Rollback();
            _logger.LogError("Unable to save the {0} coupon. {1}", argument.Code, ex.Message);
            throw new CouponException("The request could not be processed at this time.", ex);
        }
    }

    public async Task<CouponModel> UpdateCoupon(CouponArgument argument)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            CouponModel coupon = await UpdateCoupon(argument, connection, transaction);
            IEnumerable<CouponCategoryModel> couponCategory = await UpdateCouponCategory(argument, connection, transaction);

            coupon.Categories = couponCategory.Select(category =>
            {
                return new CategoryModel()
                {
                    Name = category.CategoryName,
                    CategoryId = category.CategoryId
                };
            }).ToList();

            transaction.Commit();

            return coupon;
        }
        catch (CouponException) { transaction.Rollback(); throw; }
        catch (Exception ex)
        {
            transaction.Rollback();
            _logger.LogError("Unable to update the {0} coupon. {1}", argument.Code, ex.Message);
            throw new CouponException("The request could not be processed at this time.", ex);
        }
    }

    public async Task<bool> DisableCoupon(string couponCode)
    {
        using IDbConnection connection = GetConnection();
        using IDbTransaction transaction = connection.BeginTransaction();

        try
        {
            bool result1 = await DisableCoupon(couponCode, connection, transaction);
            bool result2 = await DisableCouponCategory(couponCode, connection, transaction);
            transaction.Commit();
            return result1 && result2;
        }
        catch (CouponException) { transaction.Rollback(); throw; }
        catch (Exception ex)
        {
            transaction.Rollback();
            _logger.LogError("Unable to disable the {0} coupon. {1}", couponCode, ex.Message);
            throw new CouponException("The request could not be processed at this time.", ex);
        }
    }

    public async Task<bool> AddUsageCoupon(CouponUsageArgument argument)
    {
        using IDbConnection connection = GetConnection();

        try
        {
            string query = @"
                            INSERT INTO CouponUsageHistory (CouponId, CartId, OrderId, ValueOfProducts, DiscountAmount, UserId, Username)
                            VALUES (@CouponId, @CartId, @OrderId, @TotalValueOfProducts, @DiscountAmount, @UserId, @Username);";

            return await connection.ExecuteAsync(query, argument) >0;
        }
        catch (Exception ex)
        {
            _logger.LogError("Unable to save the coupon with ID {0}. {1}", argument.CouponId, ex.Message);
            throw new CouponException($"Unable to use the coupon in this moment.", ex);
        }
    }

    public async Task<bool> RemoveUsageCoupon(CouponUsageArgument argument)
    {
        using IDbConnection connection = GetConnection();

        try
        {
            string query = @"
                            UPDATE CCouponUsageHistory
                            SET IsActive = false, LastModifiedDate = CURRENT_TIMESTAMP
                            WHERE CouponID = @CouponID AND Username = @Username";

            return await connection.ExecuteAsync(query, argument) > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError("Unable to save the coupon with ID {0}. {1}", argument.CouponId, ex.Message);
            throw new CouponException($"Unable to remove the coupon in this moment.", ex);
        }
    }

    #region Privates
    private async Task<CouponModel> SaveCoupon(CouponArgument argument, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                        INSERT INTO Coupon (Code, DiscountPercent, ExpiresDate) 
                        VALUES (@Code, @DiscountPercent, @ExpiresDate)
                        RETURNING CouponID, Code, DiscountPercent, CreatedDate, ExpiresDate, LastModifiedDate, IsActive";

            return await connection.QueryFirstAsync<CouponModel>(query, argument, transaction);
        }
        catch (Exception ex) 
        {
            _logger.LogError("Unable to save the {0} coupon. {1}", argument.Code, ex.Message);
            throw new CouponException($"Unable to save the {argument.Code} coupon.", ex);
        }
    }

    private async Task<IEnumerable<CouponCategoryModel>> SaveCouponCategory(CouponArgument argument, IDbConnection connection, IDbTransaction transaction)
    {
        string categoryName = string.Empty;

        try
        {
            string query = @"
                        INSERT INTO CouponCategory (CouponID, CategoryId, CategoryName) 
                        VALUES (@CouponID, @CategoryId, @CategoryName)
                        RETURNING CouponCategoryID, CouponID, CategoryId, CategoryName, CreatedDate, LastModifiedDate, IsActive";

            return await Task.WhenAll(argument.Categories.Select(async category =>
            {
                categoryName = category.CategoryName;
                return await connection.QueryFirstOrDefaultAsync<CouponCategoryModel>(query, category, transaction); ;
            }));
        }
        catch (Exception ex)
        {
            _logger.LogError("Unable to save the {0} coupon category '{1}'. {2}", argument.Code, categoryName, ex.Message);
            throw new CouponException($"Unable to save the '{argument.Code}' coupon category '{categoryName}'.", ex);
        }
    }

    private async Task<CouponModel> UpdateCoupon(CouponArgument argument, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                        UPDATE Coupon
                        SET 
                            Code = @Code, 
                            DiscountPercent = @DiscountPercent, 
                            ExpiresDate = @ExpiresDate, 
                            LastModifiedDate = CURRENT_TIMESTAMP
                        WHERE Code = @Code AND IsActive = true;

                        SELECT CouponID, Code, DiscountPercent, CreatedDate, ExpiresDate, LastModifiedDate, IsActive 
                        FROM Coupon WHERE Code = @Code AND IsActive = true;";

            return await connection.QueryFirstAsync<CouponModel>(query, argument, transaction);
        }
        catch (Exception ex)
        {
            _logger.LogError("Unable to save the {0} coupon. {1}", argument.Code, ex.Message);
            throw new CouponException($"Unable to save the {argument.Code} coupon.", ex);
        }
    }

    private async Task<IEnumerable<CouponCategoryModel>> UpdateCouponCategory(CouponArgument argument, IDbConnection connection, IDbTransaction transaction)
    {
        string categoryName = string.Empty;

        try
        {
            if (argument.Categories.Any())
                return await SaveCouponCategory(argument, connection, transaction);

            await DisableCouponCategory(argument.Code, connection, transaction);

            return new List<CouponCategoryModel>();
        }
        catch (CouponException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError("Unable to update the {0} coupon category '{1}'. {2}", argument.Code, categoryName, ex.Message);
            throw new CouponException($"Unable to save the '{argument.Code}' coupon category '{categoryName}'.", ex);
        }
    }

    private async Task<bool> DisableCoupon(string couponCode, IDbConnection connection, IDbTransaction transaction)
    {
        try
        {
            string query = @"
                        UPDATE Coupon
                        SET     IsActive = false, 
                                LastModifiedDate = CURRENT_TIMESTAMP
                        WHERE   Code = @Code;";

            return await connection.ExecuteAsync(query, new { Code = couponCode }, transaction) > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError("Unable to disable the {0} coupon. {1}", couponCode, ex.Message);
            throw new CouponException($"Unable to disable the {couponCode} coupon.", ex);
        }
    }

    private async Task<bool> DisableCouponCategory(string couponCode, IDbConnection connection, IDbTransaction transaction)
    {
        string categoryName = string.Empty;

        try
        {
            string query = @"
                        UPDATE  CouponCategory 
                        SET     IsActive = false, 
                                LastModifiedDate = CURRENT_TIMESTAMP
                        WHERE   CouponID = (SELECT CouponID FROM Coupon WHERE Code = @Code);";

            return await connection.ExecuteAsync(query, new { Code = couponCode }, transaction) > 0;
        }
        catch (Exception ex)
        {
            _logger.LogError("Unable to disable the {0} coupon. {1}", couponCode, ex.Message);
            throw new CouponException($"Unable to disable the '{couponCode}' coupon.'.", ex);
        }
    }
    #endregion
}