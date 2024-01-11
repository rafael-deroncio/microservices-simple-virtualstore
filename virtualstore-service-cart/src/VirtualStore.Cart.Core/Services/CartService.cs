using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Refit;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Text.Json;
using VirtualStore.Cart.Core.Arguments;
using VirtualStore.Cart.Core.Configurations.Enums;
using VirtualStore.Cart.Core.Configurations.Mappers;
using VirtualStore.Cart.Core.Exceptions;
using VirtualStore.Cart.Core.Models;
using VirtualStore.Cart.Core.Repositories.Interfaces;
using VirtualStore.Cart.Core.Responses;
using VirtualStore.Cart.Core.Services.Clients;
using VirtualStore.Cart.Core.Services.Interfaces;
using VirtualStore.Cart.Domain.Requests;
using VirtualStore.Cart.Domain.Responses;

namespace VirtualStore.Cart.Core.Services;

public class CartService : ICartService
{
    private readonly IObjectConverter _objectConverter;
    private readonly ICartRepository _cartRepository;
    private readonly ILogger<CartService> _logger;
    private readonly IDiscountClientService _discountClientService;
    private readonly IAccountClientService _accountClientService;
    private readonly ICatalogClientService _catalogClientService;

    public CartService(
        IObjectConverter objectConverter,
        ICartRepository cartRepository,
        ILogger<CartService> logger,
        IDiscountClientService discountClientService,
        IAccountClientService accountClientService,
        ICatalogClientService catalogClientService)
    {
        _objectConverter = objectConverter;
        _cartRepository = cartRepository;
        _logger = logger;
        _discountClientService = discountClientService;
        _accountClientService = accountClientService;
        _catalogClientService = catalogClientService;
    }

    public async Task<CartResponse> GetCart(string username)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to user {2}", nameof(CartService), nameof(GetCart), username);

        try
        {
            await CkeckIfUserExists(username);

            Models.CartModel cart = await _cartRepository.GetCart(username);
            cart.Header.TotalAmount = cart.Itens.Sum(x => x.Product.Price * x.Quantity);
            return _objectConverter.Map<CartResponse>(cart);
        }
        // catch (UserException) { throw; }
        catch (CartException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<CartResponse> AddCart(string username, CartRequest request)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} with user {2}", nameof(CartService), nameof(AddCart), username);

        try
        {
            username = request.Header.Username;
            await CkeckIfUserExists(username);
            await CleanCart(username);

            // Recovering the products
            IEnumerable<ProductArgument> products = await Task.WhenAll(request.Items.Select(async item => 
                _objectConverter.Map<ProductArgument>(await _catalogClientService.GetProduct(item.Product.ProductId))
            ));

            IEnumerable<CartItemArgument> cartItems = request.Items.Join(products,
                productResquest => productResquest.Product.ProductId,
                productArgument => productArgument.ProductId,
                (productResquest, productArgument) =>
                    {
                        return new CartItemArgument()
                        {
                            Quantity = productResquest.Quantity,
                            Product = productArgument,
                        };
                    }
                );

            //CouponResponse coupon = await _couponClientRepository.GetCouponDetails(
            //    request.Header.CouponCode.ToUpper());

            //if (!string.IsNullOrEmpty(request.Header.CouponCode))

            CartHeaderArgument cartHeader = new()
            {
                //CouponCode = CouponResponse.Code,
                //TotalAmount = (coupon.Discount / 100) * products.Sum(item => item.Product.price)
            };

            CartArgument cart = new()
            {
                Header = cartHeader,
                Items = cartItems,
            };

            CartModel response = await _cartRepository.CreateCart(cart);

            return _objectConverter.Map<CartResponse>(response);
        }
        // catch (UserException) { throw; }
        catch (CartException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<bool> CleanCart(string username)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} with user {2}", nameof(CartService), nameof(AddCart), username);

        try
        {
            await CkeckIfUserExists(username);
            return false;
        }
        // catch (UserException) { throw; }
        catch (CartException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<CartResponse> AddItemCart(string username, ItemRequest request)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} with user {2}", nameof(CartService), nameof(AddItemCart), username);

        try
        {
            await CkeckIfUserExists(username);
            return null;
        }
        // catch (UserException) { throw; }
        catch (CartException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<bool> RemoveItemCart(string username, ItemRequest request)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} with user {2}", nameof(CartService), nameof(RemoveItemCart), username);

        try
        {
            await CkeckIfUserExists(username);
            return false;
        }
        // catch (UserException) { throw; }
        catch (CartException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<bool> ApplyCouponCart(string username, CouponRequest request)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to user {2}", nameof(CartService), nameof(ApplyCouponCart), username);

        try
        {
            await CkeckIfUserExists(username);
            await CheckIfCouponExists(request.CouponCode);

            return false;
        }
        // catch (UserException) { throw; }
        // catch (CouponException)  { throw; }
        catch (CartException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    public async Task<bool> RemoveCouponCart(string username, CouponRequest request)
    {
        _logger.LogInformation("Starting treatment of the request in {0} of {1} to user {2}", nameof(CartService), nameof(RemoveCouponCart), username);

        try
        {
            await CkeckIfUserExists(username);
            await CheckIfCouponExists(request.CouponCode);
            return false;
        }
        // catch (UserException) { throw; }
        // catch (CouponException)  { return true; }
        catch (CartException) { throw; }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return default;
        }
    }

    #region privates
    private async Task CkeckIfUserExists(string username)
    {
        try
        {
            await _accountClientService.GetUser(username);
        }
        catch (UserException) { throw; }
        catch (ApiException ex)
        {
            if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                _logger.LogError("User {0} does not exist.", username);
                throw new UserException(
                    $"User {username} does not exist.",
                    ExceptionType.Error,
                    System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                _logger.LogError(ex, "Error calling GetUser API");
                throw new UserException(
                    $"Error calling GetUser API: {ex.Message}",
                    ExceptionType.Error,
                    ex.StatusCode);
            }
        }
    }

    private async Task CheckIfCouponExists(string couponCode)
    {
        try
        {
            await _discountClientService.GetCoupon(couponCode);
        }
        catch (CouponException) { throw; }
        catch (ApiException ex)
        {
            if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                _logger.LogError("Coupon {0} does not exist.", couponCode);
                throw new UserException(
                    $"Coupon {couponCode} does not exist.",
                    ExceptionType.Error,
                    System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                _logger.LogError(ex, "Error calling GetCoupon API");
                throw new UserException(
                    $"Error calling GetCoupon API: {ex.Message}",
                    ExceptionType.Error,
                    ex.StatusCode);
            }
        }
    }
    #endregion
}