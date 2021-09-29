using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.Models
{
    public partial class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public string ShoppingName { get; set; }
        public int? ShoppingQty { get; set; }
        public int? ShoppingCost { get; set; }
        public int? ShoppingPrice { get; set; }
        public byte[] ShoppingPhoto { get; set; }
    }
}
