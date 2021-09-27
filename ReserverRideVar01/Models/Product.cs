using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ReserverRideVar01.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQty { get; set; }
        public int ProductPrice { get; set; }
        public int ProductCost { get; set; }
        [MaxLength(300)]
        [Column(TypeName = "nvarchar")]
        public string ProductDescription { get; set; }

        public byte[] ProductPhoto { get; set; }
    }
}
