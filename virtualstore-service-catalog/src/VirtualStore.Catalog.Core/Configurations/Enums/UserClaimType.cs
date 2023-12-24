using System.ComponentModel;

namespace VirtualStore.Catalog.Core.Configurations.Enums;

public enum UserClaimType
{
    [Description("Administrator")]
    Admin,

    [Description("Customer")]
    Customer,

    [Description("Manager")]
    Manager,
}

public static class UserRoleExtensions
{
    public static string GetDescription(this UserClaimType value)
    {
        System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

        return attribute == null ? value.ToString() : attribute.Description;
    }
}
