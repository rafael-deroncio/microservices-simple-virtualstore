using System.ComponentModel;

namespace VirtualStore.Identity.Core.Configurations.Enums;

public enum RequestType
{
    [Description("Microservice")]
    Microservice,

    [Description("Client")]
    Client,
}

public static class RequestTypeExtensions
{
    public static string GetDescription(this RequestType value)
    {
        System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

        return attribute == null ? value.ToString() : attribute.Description;
    }
}