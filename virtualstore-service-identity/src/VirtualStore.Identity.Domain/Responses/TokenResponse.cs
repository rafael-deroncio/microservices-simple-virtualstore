using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualStore.Identity.Domain.Responses;

public class TokenResponse
{
    public string Token { get; set; }
    public string Message { get; set; }
    public DateTime Expires { get; set; }
}