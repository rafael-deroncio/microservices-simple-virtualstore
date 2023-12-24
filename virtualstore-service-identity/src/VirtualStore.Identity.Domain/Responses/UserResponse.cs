namespace VirtualStore.Identity.Domain.Responses;

public class UserResponse
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<AddressResponse> Addresses { get; set; }
    public List<TelephoneResponse> Telephones { get; set; }
}