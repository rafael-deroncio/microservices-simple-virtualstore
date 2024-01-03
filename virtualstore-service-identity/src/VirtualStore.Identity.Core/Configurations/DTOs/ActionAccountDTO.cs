using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Configurations.DTOs;

public class ActionAccountDTO : EntityConventionsDTO
{
    public int LoginId { get; set; }
    public string UserName { get; set; }
    public string LoginProvider { get; set; }
    public string ProviderKey { get; set; }
    public string RequestIdentifier { get; set; }
    public string IpAddressess { get; set; }
    public string UserAgent { get; set; }
}