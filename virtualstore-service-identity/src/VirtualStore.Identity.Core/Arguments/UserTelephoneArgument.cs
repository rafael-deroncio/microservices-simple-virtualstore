using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Arguments;

public class UserTelephoneArgument : EntityConventionsDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TelephoneId { get; set; }
}
