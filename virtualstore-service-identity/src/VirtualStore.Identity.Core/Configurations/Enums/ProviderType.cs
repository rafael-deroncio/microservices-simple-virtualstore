using System.ComponentModel;

namespace VirtualStore.Identity.Core.Configurations.Enums;

public enum ProviderType
{
    [Description("xkey-virtual-store-identity-provider")]
    VirtualStoreIdentityProvider,
}

public static class ProviderTypeExtensions
{
    public static string GetDescription(this ProviderType value)
    {
        System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

        return attribute == null ? value.ToString() : attribute.Description;
    }
}