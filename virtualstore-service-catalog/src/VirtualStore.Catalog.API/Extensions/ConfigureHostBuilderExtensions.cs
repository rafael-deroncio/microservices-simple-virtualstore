using Serilog;
using Serilog.Exceptions;
using VirtualStore.Catalog.Core.Configurations.Logging;

namespace VirtualStore.Catalog.API.Extensions;

/// <summary>
/// Extension for configuring Serilog usage in the host.
/// </summary>
public static class ConfigureHostBuilderExtensions
{
    /// <summary>
    /// Configures the usage of Serilog in the host.
    /// </summary>
    /// <param name="hostBuilder">The host builder.</param>
    /// <returns>The configured host builder.</returns>
    public static IHostBuilder UseSerilog(this IHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog((context, config) =>
            config.MinimumLevel.Information()
                  .MinimumLevel.ControlledBy(LoggingLevelSwitcher._instance)
                  .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Error)
                  .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Error)
                  .Enrich.With(new CustomEnricher(context.Configuration["AppDetails:Name"]))
                  .Enrich.WithProperty("Application", context.Configuration["ApplicationName"])
                  .Enrich.WithProperty("Envioroment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"))
                  .Enrich.FromLogContext()
                  .Enrich.WithExceptionDetails()
                  .WriteTo.Console()
                  .WriteTo.PostgreSQL(
                          connectionString: context.Configuration["LogDBConnectionString"],
                          tableName: "Logs",
                          needAutoCreateTable: false
                          ));
        return hostBuilder;
    }
}