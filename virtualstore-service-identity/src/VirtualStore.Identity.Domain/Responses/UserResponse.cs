namespace VirtualStore.Identity.Domain.Responses;

public class UserResponse : ApiResponse
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string CPF { get; set; }

    public DateTime DateOfBirth { get; set; }

    public int Age { get; set; }

    public string Gender { get; set; }

    public bool Active { get; set; }
}