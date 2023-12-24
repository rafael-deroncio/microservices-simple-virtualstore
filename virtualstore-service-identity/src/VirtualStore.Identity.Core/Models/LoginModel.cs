﻿using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Models;

public class LoginModel : EntityConventionsDTO
{
    public int LoginId { get; set; }
    public string LoginProvider { get; set; }
    public string ProviderKey { get; set; }
}