using System.ComponentModel;

namespace VirtualStore.Identity.Core.Configurations.Enums;

public enum TokenType
{
    [Description("Access Token")]
    AccessToken,

    [Description("Refresh Token")]
    RefreshToken,
}

public static class TokenTypeExtensions
{
    public static string GetDescription(this TokenType value)
    {
        System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

        return attribute == null ? value.ToString() : attribute.Description;
    }
}