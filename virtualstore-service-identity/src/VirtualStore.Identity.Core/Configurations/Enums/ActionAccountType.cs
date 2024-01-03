using System.ComponentModel;

namespace VirtualStore.Identity.Core.Configurations.Enums;

public enum ActionAccountType
{
    [Description("Login-Account")]
    LogIn,

    [Description("LogOut-Account")]
    LogOut,

    [Description("SigIn-Account")]
    SigIn,

    [Description("SignOut-Account")]
    SignOut,
}

public static class ActionAccountExtensions
{
    public static string GetDescription(this ActionAccountType value)
    {
        System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

        return attribute == null ? value.ToString() : attribute.Description;
    }
}