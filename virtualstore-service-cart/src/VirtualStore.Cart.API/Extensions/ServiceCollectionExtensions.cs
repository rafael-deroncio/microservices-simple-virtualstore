﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using VirtualStore.Cart.API.Settings;
using VirtualStore.Cart.Core.Repositories;
using VirtualStore.Cart.Core.Repositories.Interfaces;
using VirtualStore.Cart.Core.Services;
using VirtualStore.Cart.Core.Services.Interfaces;
using Refit;
using VirtualStore.Cart.Core.Services.Clients;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Caching.Memory;
using VirtualStore.Cart.Core.Handlers;

namespace VirtualStore.Cart.API.Extensions;

/// <summary>
/// Extends IServiceCollection with custom service configuration methods.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures routing to automatically convert incoming URLs to lowercase.
    /// </summary>
    /// <param name="services">The service collection to add the lowercase routing configuration to.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddLowerCaseRouting(this IServiceCollection services)
    {
        services.Configure<RouteOptions>(options =>
        {
            options.LowercaseUrls = true;
        });

        return services;
    }

    /// <summary>
    /// Configures JWT authentication based on provided configuration settings.
    /// </summary>
    /// <param name="services">The service collection to add the authentication configuration to.</param>
    /// <param name="configuration">The configuration containing JWT settings.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var key = Encoding.UTF8.GetBytes(configuration["JwtSymmetricSecurityKey"]);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });

        return services;
    }

    /// <summary>
    /// Configures Swagger documentation generation using settings from appsettings.json.
    /// </summary>
    /// <param name="services">The service collection to add the Swagger configuration to.</param>
    /// <param name="configuration">The configuration containing SwaggerGenDoc settings.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddSwaggerCustomSettings(this IServiceCollection services, IConfiguration configuration)
    {
        // Load SwaggerGenDocSettings from appsettings.json
        SwaggerSettings swaggerSettings = configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>()
            ?? throw new NullReferenceException("No settings for swagger documentation were found.");

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc(swaggerSettings.Name, new OpenApiInfo
            {
                Title = swaggerSettings.Title,
                Version = swaggerSettings.Version,
                Description = swaggerSettings.Description,
                Contact = new OpenApiContact
                {
                    Name = swaggerSettings.Contact.Name,
                    Email = swaggerSettings.Contact.Email,
                    Url = new Uri(swaggerSettings.Contact.Url)
                }
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        return services;
    }

    /// <summary>
    /// Configures custom settings for API versioning and API version explorer.
    /// </summary>
    /// <param name="services">The service collection to add the API versioning configuration to.</param>
    /// <param name="configuration">The configuration containing API versioning settings.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddAPIVersioningCustomSettings(this IServiceCollection services, IConfiguration configuration)
    {
        APIVersioningSettings versioningSettings = configuration.GetSection("APIVersioningSettings").Get<APIVersioningSettings>()
            ?? throw new NullReferenceException("No settings for API versioning were found.");

        services.AddApiVersioning(options =>
        {
            // Set the default API version and assume it when not specified
            options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(
                versioningSettings.ApiVersion.High,
                versioningSettings.ApiVersion.Medium);

            options.AssumeDefaultVersionWhenUnspecified = true;

            // Report API versions in response headers
            options.ReportApiVersions = true;

            // Choose the API version based on the current implementation
            options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);

            // Read API versions from URL segments, headers, and media types
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader(versioningSettings.Reader),
                new MediaTypeApiVersionReader(versioningSettings.Reader)
            );
        });

        services.AddVersionedApiExplorer(setup =>
        {
            // Format the group name using the API version in the 'vVVV' format
            setup.GroupNameFormat = versioningSettings.Explorer.Format;

            // Substitute the API version in URLs
            setup.SubstituteApiVersionInUrl = true;
        });

        services.AddEndpointsApiExplorer();

        return services;
    }

    /// <summary>
    /// Configures custom CORS settings based on the provided configuration.
    /// </summary>
    /// <param name="services">The service collection to add the CORS configuration to.</param>
    /// <param name="configuration">The configuration containing CORS settings.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddCorsCustomSettings(this IServiceCollection services, IConfiguration configuration)
    {
        // Load CORS settings from the provided configuration
        CorsCustomPolicy policy = configuration.GetSection("CorsSettings").Get<CorsSettings>().CorsPolicy
            ?? throw new NullReferenceException("No settings for cors were found.");

        services.AddCors(options =>
        {
            options.AddPolicy(policy.Name, builder =>
            {
                builder.WithHeaders(policy.AllowedHeaders);
                builder.WithMethods(policy.AllowedMethods);

                if (policy.AllowedOrigins.Contains("*")) builder.AllowAnyOrigin();
                else builder.WithOrigins(policy.AllowedOrigins);
            });
        });

        return services;
    }

    /// <summary>
    /// Configures Swagger to include JWT Bearer token authentication settings.
    /// </summary>
    /// <param name="services">The service collection to add the JWT Bearer authentication configuration to.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddAuthenticationSwaggerJwtBearer(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Header de autenticação JWT - Schema Bearer.\r\n\r\nInforme 'Bearer <token>'.\r\n\r\n"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }

    /// <summary>
    /// Adds service dependencies to the provided IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add service dependencies to.</param>
    /// <returns>The modified IServiceCollection.</returns>
    public static IServiceCollection AddServicesDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<ICartService, CartService>();

        // Service URI
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IUriService, UriService>(
            context =>
            {
                IHttpContextAccessor accessor = context.GetRequiredService<IHttpContextAccessor>();
                return new UriService(accessor);
            });

        return services;
    }

    /// <summary>
    /// Adds repository dependencies to the provided IServiceCollection.
    /// </summary>
    /// <param name="services">The IServiceCollection to add repository dependencies to.</param>
    /// <returns>The modified IServiceCollection.</returns>
    public static IServiceCollection AddRepositoriesDependencyInjection(this IServiceCollection services)
    {
        services.AddSingleton<ICartRepository, CartRepository>();
        
        return services;
    }

    /// <summary>
    /// Adds configuration for RestClients using Refit with specified base addresses.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> containing the client base addresses.</param>
    /// <returns>The <see cref="IServiceCollection"/> with added Refit client configurations.</returns>
    public static IServiceCollection AddRestClientConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<AuthenticatedHttpClientHandler>();

        // Configure RefitSettings with NewtonsoftJsonContentSerializer
        RefitSettings config = new()
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
        };

        // Add and configure ITokenClientService Refit client
        services.AddRefitClient<IAccountClientService>(config)
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(configuration.GetValue<string>("ClientBaseAddresses:User")))
            .AddHttpMessageHandler(provider =>
            {
                return services.GetHttpClientHandler(provider);
            });

        // Add and configure IDiscountClientService Refit client
        services.AddRefitClient<IDiscountClientService>(config)
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(configuration["ClientBaseAddresses:Discount"]))
            .AddHttpMessageHandler(provider =>
            {
                return services.GetHttpClientHandler(provider);
            }); ;

        // Add and configure ICatalogClientService Refit client
        services.AddRefitClient<ICatalogClientService>(config)
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(configuration.GetValue<string>("ClientBaseAddresses:Catalog")));

        return services;
    }

    public static AuthenticatedHttpClientHandler GetHttpClientHandler(this IServiceCollection services, IServiceProvider provider)
    {
        return new AuthenticatedHttpClientHandler(
            provider.GetRequiredService<IMemoryCache>(),
            provider.GetRequiredService<IConfiguration>()
            );
    }
}