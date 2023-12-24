using System.ComponentModel;

namespace VirtualStore.Identity.Core.Configurations.Enums;

public enum RequestRoleType
{
    [Description("Microservice")]
    Microservice,

    [Description("Client")]
    Client,
}

public static class RequestRoleExtensions
{
    public static string GetDescription(this UserClaimType value)
    {
        System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

        return attribute == null ? value.ToString() : attribute.Description;
    }
}