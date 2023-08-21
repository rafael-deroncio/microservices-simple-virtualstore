using VirtualStore.Identity.API.Settings;
using VirtualStore.Identity.Core.Middlewares;

namespace VirtualStore.Identity.API.Extensions;

/// <summary>
/// Extension methods for configuring and enhancing the application pipeline.
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Configures Swagger UI with custom settings for documentation.
    /// </summary>
    /// <param name="builder">The application builder.</param>
    /// <returns>The updated application builder.</returns>
    public static IApplicationBuilder UseSwaggerCustomSettings(this IApplicationBuilder builder)
    {
        // Retrieve the IConfiguration service from the application services
        IConfiguration configuration = builder.ApplicationServices.GetRequiredService<IConfiguration>();

        // Load Swagger settings from appsettings.json
        SwaggerSettings swaggerSettings = configuration.GetSection("SwaggerSettings").Get<SwaggerSettings>()
            ?? throw new NullReferenceException("No settings for swagger documentation were found.");

        // Configure Swagger UI with custom settings
        builder.UseSwaggerUI(options =>
        {
            // Set the default models expand depth
            options.DefaultModelsExpandDepth(-1);

            // Configure the Swagger endpoint using the title from settings
            options.SwaggerEndpoint($"/swagger/{swaggerSettings.Name}/swagger.json", swaggerSettings.Title);
        });

        builder.UseSwagger();

        return builder;
    }

    /// <summary>
    /// Adds middleware for handling exceptions in the request pipeline.
    /// </summary>
    /// <param name="builder">The application builder.</param>
    /// <returns>The updated application builder.</returns>
    public static IApplicationBuilder UseHandleException(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ExceptionHandlerMiddleware>();

        return builder;
    }
}