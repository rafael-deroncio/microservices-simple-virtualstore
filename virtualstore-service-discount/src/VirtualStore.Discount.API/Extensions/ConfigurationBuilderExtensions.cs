using VirtualStore.Discount.Core.Configurations;

namespace VirtualStore.Discount.API.Extensions;

public static class ConfigurationExtensions
{
    /// <summary>
    /// Adds credentials to the configuration from a Secrets object.
    /// </summary>
    /// <param name="configuration">The configuration builder to add the credentials to.</param>
    /// <returns>The modified configuration builder.</returns>
    public static IConfigurationBuilder AddSecrets(this IConfigurationBuilder configuration)
    {
        Secrets secrets = SecretsConfigurations.Get();

        configuration.AddInMemoryCollection(new Dictionary<string, string>
        {
            {"DiscountConnectionString", secrets.DiscountConnectionString},
            {"JwtSymmetricSecurityKey", secrets.JwtSymmetricSecurityKey},
            {"LogDBConnectionString", secrets.LogDBConnectionString}
        });

        return configuration;
    }
}