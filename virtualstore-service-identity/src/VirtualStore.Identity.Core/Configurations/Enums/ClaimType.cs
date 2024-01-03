using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VirtualStore.Identity.Core.Configurations.Enums;

public enum ClaimType
{
    // Product
    [Description("Create-Product")]
    CreateProduct,

    [Description("Read-Product")]
    ReadProduct,

    [Description("Update-Product")]
    UpdateProduct,

    [Description("Delete-Product")]
    DeleteProduct,

    // Catalog
    [Description("Create-Catalog")]
    CreateCatalog,

    [Description("Read-Catalog")]
    ReadCatalog,

    [Description("Update-Catalog")]
    UpdateCatalog,

    [Description("Delete-Catalog")]
    DeleteCatalog,

    // User
    [Description("Create-User")]
    CreateUser,

    [Description("Read-User")]
    ReadUser,

    [Description("Update-User")]
    UpdateUser,

    [Description("Delete-User")]
    DeleteUser

}

public static class ClaimTypeExtensions
{
    public static string GetDescription(this ClaimType value)
    {
        System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

        DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

        return attribute == null ? value.ToString() : attribute.Description;
    }
}
