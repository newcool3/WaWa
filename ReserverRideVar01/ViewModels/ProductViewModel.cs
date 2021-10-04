using Microsoft.AspNetCore.Http;
using ReserverRideVar01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.ViewModel
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Island> Islands { get; set; }
        //public Product product { get; set; }
        //public ProductViewModel()
        //{
        //    this.product = new Product();
        //}
        public int ProductId 
        {
            get { return this.ProductId; }
            set { this.ProductId = value; } 
        }
        public string ProductName
        {
            get { return this.ProductName; }
            set { this.ProductName = value; }
        }
        public int ProductQty
        {
            get { return this.ProductQty; }
            set { this.ProductQty = value; }
        }
        public int ProductPrice
        {
            get { return this.ProductPrice; }
            set { this.ProductPrice = value; }
        }
        public int ProductCost
        {
            get { return this.ProductCost; }
            set { this.ProductCost = value; }
        }
        public string ProductDescription
        {
            get { return this.ProductDescription; }
            set { this.ProductDescription = value; }
        }
        public IFormFile ProductPhoto { get; set; }
        public int IslandId { get; set; }
        public virtual Island Island { get; set; }
    }
}
