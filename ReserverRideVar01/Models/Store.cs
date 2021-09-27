using System;
using System.Collections.Generic;

#nullable disable

namespace ReserverRideVar01.Models
{
    public partial class Store
    {
        //public Store()
        //{
        //    Products = new HashSet<Product>();
        //}

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int StorePhone { get; set; }
        public string StoreAddress { get; set; }
        public string StoreDescription { get; set; }
        public int IslandId { get; set; }

        //public virtual Island Island { get; set; }
        //public virtual ICollection<Product> Products { get; set; }
    }
}
