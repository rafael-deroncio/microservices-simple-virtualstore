using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Arguments;

public class UserAddressArgument : EntityConventionsDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int AddressId { get; set; }
}