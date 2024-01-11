using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using VirtualStore.Cart.Core.Arguments;
using VirtualStore.Cart.Core.Configurations.Mappers;
using VirtualStore.Cart.Core.Exceptions;
using VirtualStore.Cart.Core.Models;
using VirtualStore.Cart.Core.Repositories.Interfaces;

namespace VirtualStore.Cart.Core.Repositories;

public class CartRepository : BaseRepository, ICartRepository
{
    private readonly ILogger<CartRepository> _logger;

    public CartRepository(
        IConfiguration configuration, 
        ILogger<CartRepository> logger) : base(configuration)
    {
        _logger = logger;
    }

    public async Task<CartModel> GetCart(string username)
    {
        using IDbConnection connection = GetConnection();

        try
        {
            string query = @"
                            SELECT
                                c.CartId,
                                c.CreatedDate,
                                c.LastModifiedDate,
                                c.IsActive,
    
                                ch.CartHeaderId,
                                ch.TotalAmount,
                                ch.CreatedDate,
                                ch.LastModifiedDate,
                                ch.IsActive,

                                ch.UserId,
                                ch.Username,
                                ch.CreatedDate,
                                ch.LastModifiedDate,
                                ch.IsActive,

                                ch.CouponId,
                                ch.CouponCode,
                                ch.CreatedDate,
                                ch.LastModifiedDate,
                                ch.IsActive,
    
                                p.ProductId,
                                p.Name,
                                p.Description,
                                p.Brand,
                                p.Price,
                                p.Stock,

                                p.CategoryId,
                                p.CategoryName AS Name,

                                ci.CartItemId,
                                ci.Quantity,
                                ci.CreatedDate,
                                ci.LastModifiedDate,
                                ci.IsActive

                            FROM Cart c
                            JOIN CartHeader ch ON c.CartId = ch.CartId
                            JOIN CartItem ci ON ch.CartHeaderId = ci.CartHeaderId
                            JOIN Product p ON ci.ProductId = p.ProductId

                            WHERE ch.Usename = @Username AND c.IsActive = true;";

            Dictionary<int, CartModel> dataCartDict = new Dictionary<int, CartModel>();

            return (await connection.QueryAsync<CartModel>(
                sql: query,
                param: new { Username = username },
                transaction: null,
                buffered: true,
                splitOn: "CartHeaderId,UserId,CouponId,ProductId,CategoryId,CartItemId",
                types: new[]
                {
                    typeof(CartModel),
                    typeof(CartHeaderModel),
                    typeof(UserModel),
                    typeof(CouponModel),
                    typeof(ProductModel),
                    typeof(CategoryModel),
                    typeof(CartItemModel)
                },
                map: obj =>
                {
                    CartModel cartTemp;
                    CartModel cart = obj[0] as CartModel;
                    CartHeaderModel header = obj[1] as CartHeaderModel;
                    UserModel user = obj[2] as UserModel;
                    CouponModel coupon = obj[3] as CouponModel;
                    ProductModel product = obj[4] as ProductModel;
                    CategoryModel category = obj[5] as CategoryModel;
                    CartItemModel item = obj[6] as CartItemModel;

                    if (!dataCartDict.TryGetValue(cart.CartId, out cartTemp))
                    {
                        cartTemp = cart;

                        cartTemp.Itens ??= new List<CartItemModel>();

                        dataCartDict.Add(cart.CartId, cartTemp);
                    }

                    if (header != null)
                        cart.Header = header;

                    if (user != null)
                        cart.Header.User = user;

                    if (coupon != null)
                        cart.Header.Coupon = coupon;


                    if (item != null && !cartTemp.Itens.Any(x => x.CartItemId == item.CartItemId))
                    {
                        if (product != null && !cartTemp.Itens.Any(x => x.Product.ProductId == product.ProductId))
                            item.Product = product;

                        if (category != null && !cartTemp.Itens.Any(x => x.Product.Category.CategoryId == category.CategoryId))
                            item.Product.Category = category;

                        cartTemp.Itens.Add(item);
                    }

                    return cartTemp;
                }
                )).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError("Unable to retrieve shopping cart data. {0}", ex.Message);
            throw new CartException("Unable to retrieve shopping cart data.", ex);
        }
    }

    public Task<CartModel> CreateCart(CartArgument argument)
    {
        using IDbConnection connection = GetConnection();

        try
        {
            throw new Exception("");
        }
        catch (Exception ex)
        {
            _logger.LogError("Unable to update shopping cart. {0}", ex.Message);
            throw new CartException("Unable to update shopping cart.", ex);
        }
    }

    public Task<CartModel> UpdateCart(CartArgument argument)
    {
        using IDbConnection connection = GetConnection();

        try
        {
            throw new Exception("");
        }
        catch (Exception ex)
        {
            _logger.LogError("Unable to remove item '{0}' from shopping cart {1}", string.Join(", ", argument.Items.Select(id => id.CartItemId)) , ex.Message);
            throw new CartException(string.Format("Unable to remove item {0} from shopping cart", string.Join(", ", argument.Items.Select(id => id.CartItemId))), ex);
        }
    }

    public Task<bool> DeleteCart(string username)
    {
        using IDbConnection connection = GetConnection();

        try
        {
            throw new Exception("");
        }
        catch (Exception ex)
        {
            _logger.LogError("Unable to clear shopping cart. {0}", ex.Message);
            throw new CartException("Unable to clear shopping cart.", ex);
        }
    }
}