using System;
using System.ComponentModel;

namespace VirtualStore.Identity.Core.Configurations.Enums;

public  enum RoleType
{
    [Description("Administrator")]
    Admin,

    [Description("Customer")]
    Customer,

    [Description("Manager")]
    Manager,
}

public static class RoleTypeExtensions
{
    public static string GetDescription(this RoleType value)
    {
        System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

        return attribute == null ? value.ToString() : attribute.Description;
    }
}