using System.ComponentModel;

namespace VirtualStore.Catalog.Core.Configurations.Enums;

public enum ExceptionType
{
    [Description("Information")]
    Information,

    [Description("Warning")]
    Warning,

    [Description("Error")]
    Error
}

public static class ExceptionResponseExtensions
{
    public static string GetDescription(this UserClaimType value)
    {
        System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

        return attribute == null ? value.ToString() : attribute.Description;
    }
}