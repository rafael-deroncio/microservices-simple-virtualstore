using Microsoft.Extensions.Logging;
using Refit;
using VirtualStore.Discount.Core.Arguments;
using VirtualStore.Discount.Core.Configurations.Mappers;
using VirtualStore.Discount.Core.Exceptions;
using VirtualStore.Discount.Core.Models;
using VirtualStore.Discount.Core.Repositories.Interfaces;
using VirtualStore.Discount.Core.Services.Interfaces;
using VirtualStore.Discount.Domain.Requests;
using VirtualStore.Discount.Domain.Responses;

namespace VirtualStore.Discount.Core.Services;

public class DiscountService : IDiscountService
{
    private readonly IObjectConverter _objectConverter;
    private readonly IDiscountRepository _discountRepository;
    private readonly ILogger<DiscountService> _logger;
    private readonly ICatalogClientService _catalogClientService;

    public DiscountService(
        IObjectConverter objectConverter,
        IDiscountRepository discountRepository,
        ILogger<DiscountService> logger,
        ICatalogClientService catalogClientService)
    {
        _objectConverter = objectConverter;
        _discountRepository = discountRepository;
        _logger = logger;
        _catalogClientService = catalogClientService;
    }

    public async Task<CouponResponse> GetCoupon(string couponCode)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to '{2}'", nameof(DiscountService), nameof(GetCoupon), couponCode);

        try
        {
            return _objectConverter.Map<CouponResponse>(
                await _discountRepository.GetCoupon(couponCode));
        }
        catch (CouponException) { throw; }
        catch (Exception ex) 
        {
            _logger.LogError("Unable to get the {0} coupon. {1}", couponCode, ex.Message);
            throw new CouponException("The request could not be processed at this time.", ex);
        }
    }

    public async Task<CouponDetailsResponse> GetCouponDetails(string couponCode)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to '{2}'", nameof(DiscountService), nameof(GetCouponDetails), couponCode);

        try
        {
            var couponDetails = await _discountRepository.GetCoupon(couponCode, true, true);
            return _objectConverter.Map<CouponDetailsResponse>(couponDetails);
        }
        catch (CouponException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError("Unable to get the {0} coupon details. {1}", couponCode, ex.Message);
            throw new CouponException("The request could not be processed at this time.", ex);
        }
    }

    public async Task<CouponResponse> CreateCoupon(CouponRequest request)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to '{2}'", nameof(DiscountService), nameof(CreateCoupon), request.Code);

        try
        {
            CouponModel coupon = await _discountRepository.GetCoupon(request.Code);
            if(coupon != null)
                throw new CouponException(
                    message: $"The {request.Code} coupon already exists.",
                    responseType: Configurations.Enums.ExceptionType.Information,
                    statusCode: System.Net.HttpStatusCode.NotFound);

            IEnumerable<CategoryCouponArgument> categories = await Task.WhenAll(request.Categories.Select(async category =>
            {
                return await GetCategory(category);
            }));

            CouponArgument argument = new()
            {
                Code = request.Code,
                DiscountPercent = request.DiscountPercent,
                ExpiresDate = request.ExpiresDate,
                Categories = _objectConverter.Map<List<CategoryCouponArgument>>(categories)
            };

            CouponResponse response =  _objectConverter.Map<CouponResponse>(
                await _discountRepository.SaveCoupon(argument));

            return response;
        }
        catch (ApiException ex)
        {
            if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                throw new CouponException(
                    message: $"Error when trying to get categories {request.Categories.Select(c => c.Name)}",
                    responseType: Configurations.Enums.ExceptionType.Information,
                    statusCode: System.Net.HttpStatusCode.NotFound);


            throw new CouponException(
                    message: $"Catalog service did not work correctly",
                    responseType: Configurations.Enums.ExceptionType.Error,
                    statusCode: System.Net.HttpStatusCode.UnprocessableEntity);
        }
        catch (CouponException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError("Unable to create the {0} coupon. {1}", request.Code, ex.Message);
            throw new CouponException("The request could not be processed at this time.", ex);
        }
    }

    public async Task<CouponResponse> UpdateCoupon(string couponCode, CouponRequest request)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to '{2}'", nameof(DiscountService), nameof(UpdateCoupon), couponCode);

        try
        {
            if (couponCode != request.Code)
                throw new CouponException(
                    message: "coupon informed in the route is different from the coupon informed in the request",
                    responseType: Configurations.Enums.ExceptionType.Information,
                    statusCode: System.Net.HttpStatusCode.NotFound);

            CouponModel coupon = await _discountRepository.GetCoupon(couponCode, false, true) ??
                throw new CouponException(
                    message: $"The {request.Code} coupon already exists.",
                    responseType: Configurations.Enums.ExceptionType.Information,
                    statusCode: System.Net.HttpStatusCode.NotFound);

            IEnumerable<CategoryCouponArgument> categories = await Task.WhenAll(
                request.Categories.Where(x => !coupon.Categories.Any(y => y.CategoryId == x.CategoryId)).Select(async category =>
                {
                    return await GetCategory(category, coupon.CouponId);
                }
            ).ToList());

            CouponArgument argument = new()
            {
                Code = coupon.Code,
                DiscountPercent = request.DiscountPercent,
                ExpiresDate = request.ExpiresDate,
                Categories = categories.ToList()
            };

            return _objectConverter.Map<CouponResponse>(
                await _discountRepository.UpdateCoupon(argument));
        }
        catch (CouponException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError("Unable to update the {0} coupon. {1}", couponCode, ex.Message);
            throw new CouponException("The request could not be processed at this time.", ex);
        }
    }

    public async Task<bool> DisableCoupon(string couponCode)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to '{2}'", nameof(DiscountService), nameof(DisableCoupon), couponCode);

        try
        {
            couponCode = couponCode.Trim().ToUpper();

            CouponModel coupon = await _discountRepository.GetCoupon(couponCode);
            if (coupon == null)
                throw new CouponException(
                    message: $"The {couponCode} coupon already exists.",
                    responseType: Configurations.Enums.ExceptionType.Information,
                    statusCode: System.Net.HttpStatusCode.NotFound);

            return await _discountRepository.DisableCoupon(couponCode);
        }
        catch (CouponException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError("Unable to disable the {0} coupon. {1}", couponCode, ex.Message);
            throw new CouponException("The request could not be processed at this time.", ex);
        }
    }

    public async Task<bool> ApplyCoupon(ApplyCouponRequest request)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to '{2}'", nameof(DiscountService), nameof(ApplyCoupon), request.Code);

        try
        {
            CouponModel coupon = await _discountRepository.GetCoupon(request.Code, false, true) ??
                throw new CouponException(
                    message: $"The {request.Code} coupon already exists.",
                    responseType: Configurations.Enums.ExceptionType.Information,
                    statusCode: System.Net.HttpStatusCode.NotFound);


            CouponUsageArgument argument = new()
            {
                CouponId = coupon.CouponId,
                CartId = int.MaxValue,
                OrderId = int.MaxValue,
                UserId = int.MaxValue,
                Username = request.Username,
                DiscountAmount = request.TotalValueOfProducts.Value == default ? 0 : (coupon.DiscountPercent * request.TotalValueOfProducts.Value) / 100,
                TotalValueOfProducts = request.TotalValueOfProducts.Value
            };

            return await _discountRepository.AddUsageCoupon(argument);
        }
        catch (CouponException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError("Unable to apply the {0} coupon. {1}", request.Code, ex.Message);
            throw new CouponException("The request could not be processed at this time.", ex);
        }
    }

    public async Task<bool> RemoveCoupon(RemoveCouponRequest request)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to '{2}'", nameof(DiscountService), nameof(ApplyCoupon), request.Code);

        try
        {
            CouponModel coupon = await _discountRepository.GetCoupon(request.Code, false, true) ??
                throw new CouponException(
                    message: $"The {request.Code} coupon already exists.",
                    responseType: Configurations.Enums.ExceptionType.Information,
                    statusCode: System.Net.HttpStatusCode.NotFound);

            CouponUsageArgument argument = new()
            {
                CouponId = coupon.CouponId,
                CartId = request.CartId,
                OrderId = int.MaxValue, //await _orderClientService.GetOrderDetails(request.OrderNumber),
                UserId = int.MaxValue,
                Username = request.Username
            };

            return await _discountRepository.RemoveUsageCoupon(argument);
        }
        catch (CouponException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError("Unable to remove the {0} coupon. {1}", request.Code, ex.Message);
            throw new CouponException("The request could not be processed at this time.", ex);
        }
    }

    #region Privates
    private async Task<CategoryCouponArgument> GetCategory(CategoryRequest category, int couponId = default)
    {
        try
        {
            return new CategoryCouponArgument()
            {
                CouponID = couponId,
                CategoryId = category.CategoryId,
                CategoryName = (await _catalogClientService.GetCategory(category.CategoryId)).Name
            };
        }
        catch (ApiException ex)
        {
            if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                _logger.LogError("Category '{0}: {1}' dos not exists.", category.CategoryId, category.Name);

            else
                _logger.LogError("Error when consulting the category catalog. {0}", ex.Message);

            throw new CouponException("Error when consulting the category catalog.", ex);
        }
    }
    #endregion
}