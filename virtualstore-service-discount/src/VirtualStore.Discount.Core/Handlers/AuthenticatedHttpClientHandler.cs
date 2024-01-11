using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Refit;
using System.Text;
using VirtualStore.Discount.Core.Services.Clients;
using VirtualStore.Discount.Core.Responses;
using VirtualStore.Discount.Core.Requests;

namespace VirtualStore.DIscount.Core.Handlers;

public class AuthenticatedHttpClientHandler : DelegatingHandler
{
    private readonly IMemoryCache _cache;
    private readonly IConfiguration _configuration;
    private const string CacheKey = "VirtualStoreMicroserviceAccessToken"; 

    public AuthenticatedHttpClientHandler(IMemoryCache cache, IConfiguration configuration)
    {
        _cache = cache;
        _configuration = configuration;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", await GetTokenAsync());

        return await base.SendAsync(request, cancellationToken);
    }

    private async Task<string> GetTokenAsync()
    {
        byte[] array = _cache.Get<byte[]>(CacheKey);

        string text;
        if (array == null)
        {
            RefitSettings config = new()
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    })
            };

            TokenResponse response = await RestService.For<ITokenClientService>(
                _configuration.GetValue<string>("ClientBaseAddresses:Token"), config)
                .GetTokensAuthentication(MountTokenRequest());

            text = response.AccessToken.Token.ToString();

            _cache.Set(CacheKey, Encoding.UTF8.GetBytes(text), new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = response.AccessToken.Expires - DateTime.Now
            });


            return response.AccessToken.Token;
        }

        return Encoding.UTF8.GetString(array);
    }

    private TokenRequest MountTokenRequest()
    {
        return new()
        {
            Username = "Manager",
            Role = "Manager",
            Claims = new[]
            {
                    "CreateProduct",
                    "ReadProduct",
                    "UpdateProduct",
                    "DeleteProduct",

                    "CreateCatalog",
                    "ReadCatalog",
                    "UpdateCatalog",
                    "DeleteCatalog",

                    "CreateUser",
                    "ReadUser",
                    "UpdateUser",
                    "DeleteUser",
            }
        };
    }
}