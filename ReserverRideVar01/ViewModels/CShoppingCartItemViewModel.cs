using ReserverRideVar01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.ViewModels
{
    public class CShoppingCartItemViewModel
    {
        public Product product { get; set; }
        public int ProductId { get; set; }
        public int count { get; set; }
        public Nullable<decimal> price { get; set; }
        public decimal 小計 { get { return Convert.ToDecimal(this.price) * this.count; } }
    }
}
