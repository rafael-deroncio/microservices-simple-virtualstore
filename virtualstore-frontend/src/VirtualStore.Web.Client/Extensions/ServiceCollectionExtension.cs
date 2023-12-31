﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using VirtualStore.Web.Core.Configurations;
using VirtualStore.Web.Core.Repositories;
using VirtualStore.Web.Core.Repositories.Interfaces;
using VirtualStore.Web.Core.Services;
using VirtualStore.Web.Core.Services.Interfaces;

namespace VirtualStore.Web.Client.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddHttpClientCustom(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ApiClientConfiguration>(configuration.GetSection("ApiClient"));

        services.AddHttpClient();

        // user
        services.AddHttpClient("IdentityApi", client =>
        {
            UriBuilder builder = new()
            {
                Scheme = configuration["ApiClient:IdentityApi:Scheme"],
                Host = configuration["ApiClient:IdentityApi:Host"],
            };

            client.BaseAddress = builder.Uri;
        });

        services.AddHttpClient("LoginApi", client =>
        {
            UriBuilder builder = new(
                schemeName: configuration["ApiClient:LoginApi:Scheme"],
                hostName: configuration["ApiClient:LoginApi:Host"]);

            client.BaseAddress = builder.Uri;
        });

        // catalog
        services.AddHttpClient("ProductApi", client =>
        {
            UriBuilder builder = new()
            {
                Scheme = configuration["ApiClient:ProductApi:Scheme"],
                Port = Int32.Parse(configuration["ApiClient:ProductApi:Port"]),
                Host = configuration["ApiClient:ProductApi:Host"],
            };

            client.BaseAddress = builder.Uri;
        });

        services.AddHttpClient("CategoryApi", client =>
        {
            UriBuilder builder = new()
            {
                Scheme = configuration["ApiClient:CategoryApi:Scheme"],
                Port = Int32.Parse(configuration["ApiClient:CategoryApi:Port"]),
                Host = configuration["ApiClient:CategoryApi:Host"],
            };


            client.BaseAddress = builder.Uri;
        });

        // cart
        services.AddHttpClient("CartApi", client =>
        {
            UriBuilder builder = new()
            {
                Scheme = configuration["ApiClient:CartApi:Scheme"],
                Host = configuration["ApiClient:CartApi:Host"],
            };

            client.BaseAddress = builder.Uri;
        });


        // discount
        services.AddHttpClient("DiscountApi", client =>
        {
            UriBuilder builder = new()
            {
                Scheme = configuration["ApiClient:DiscountApi:Scheme"],
                Host = configuration["ApiClient:DiscountApi:Host"],
            };

            client.BaseAddress = builder.Uri;
        });


        return services;
    }

    public static IServiceCollection AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IIdentityManagementService, IdentityManagementService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
    public static IServiceCollection AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddSingleton<IUserClientRepository, UserClientRepository>();
        services.AddSingleton<IProductRepository, ProductClientRepository>();
        services.AddSingleton<ICategoryRepository, CategoryClientRepository>();
        return services;
    }

    public static IServiceCollection AddCookieSchemeAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Account/Login";
                        options.Cookie.Name = "virtualstore-auth-cookie";
                    });

        return services;
    }
}
