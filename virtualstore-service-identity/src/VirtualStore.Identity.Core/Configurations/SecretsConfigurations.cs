using System.Net;
using YamlDotNet.Serialization;

namespace VirtualStore.Identity.Core.Configurations;

public static class SecretsConfigurations
{
    public static Secrets Get()
    {
        try
        {
            IDeserializer deserializer = new DeserializerBuilder().Build();
            using StreamReader reader = new StreamReader(@"./secrets.yaml");
            return deserializer.Deserialize<Secrets>(reader);
        }
        catch (Exception ex)
        {
            throw new FileLoadException($"Unable to get system secrets :{ex}");
        }
    }
}