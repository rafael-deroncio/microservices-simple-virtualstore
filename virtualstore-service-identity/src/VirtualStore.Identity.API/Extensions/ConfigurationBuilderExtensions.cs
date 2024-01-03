using VirtualStore.Identity.Core.Configurations;

namespace VirtualStore.Identity.API.Extensions;

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
            {"IdentityConnectionString", secrets.IdentityConnectionString},
            {"LogDBConnectionString", secrets.LogDBConnectionString },
            {"JwtSymmetricSecurityKey", secrets.JwtSymmetricSecurityKey},
            {"SecretHashRefreshToken", secrets.SecretHashRefreshToken}
        });

        return configuration;
    }
}