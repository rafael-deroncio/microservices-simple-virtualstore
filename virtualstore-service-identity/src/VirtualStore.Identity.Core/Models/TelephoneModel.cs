using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Models;

public class TelephoneModel : EntityConventionsDTO
{
    public int TelephoneId { get; set; }
    public string PhoneNumber { get; set; }
    public string PhoneType { get; set; }
}
