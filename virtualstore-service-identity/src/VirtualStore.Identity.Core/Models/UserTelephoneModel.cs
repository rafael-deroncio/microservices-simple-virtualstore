using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Catalog.Core.Configurations.DTOs;

namespace VirtualStore.Identity.Core.Models;

public class UserTelephoneModel : EntityConventionsDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TelephoneId { get; set; }
}
