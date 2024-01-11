using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualStore.Cart.Core.Models;

namespace VirtualStore.Cart.Core.Arguments;

public class CartArgument
{
    public int CartId { get; set; }
    public CartHeaderArgument Header { get; set; }
    public IEnumerable<CartItemArgument> Items { get; set; }
}