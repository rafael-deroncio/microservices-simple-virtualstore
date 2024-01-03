using System.ComponentModel;

namespace VirtualStore.Cart.Core.Configurations.Enums;

public enum RequestRoleType
{
    [Description("Microservice")]
    Microservice,

    [Description("Client")]
    Client,
}

public static class RequestRoleExtensions
{
    public static string GetDescription(this RequestRoleType value)
    {
        System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

        return attribute == null ? value.ToString() : attribute.Description;
    }
}

