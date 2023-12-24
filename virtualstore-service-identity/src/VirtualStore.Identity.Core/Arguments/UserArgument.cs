
using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Arguments;

public class UserArgument : EntityConventionsDTO
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string CPF { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public List<AddressArgument> Addresses { get; set; }
    public List<TelephoneArgument> Telephones { get; set; }
}