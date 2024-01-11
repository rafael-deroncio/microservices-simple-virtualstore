using System.ComponentModel;

namespace VirtualStore.Discount.Core.Configurations.Enums;

public enum ExceptionType
{
    [Description("Information")]
    Information,

    [Description("Warning")]
    Warning,

    [Description("Error")]
    Error
}