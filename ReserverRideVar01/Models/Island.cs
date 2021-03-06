using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ReserverRideVar01.Models
{
    public partial class Island
    {
        //public Island()
        //{
        //    Stores = new HashSet<Store>();
        //}

        public int IslandId { get; set; }
        [Display(Name ="島嶼")]
        public string IslandName { get; set; }
        public byte[] IslandPhoto { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        //public virtual ICollection<Store> Stores { get; set; }
    }
}
