using Microsoft.AspNetCore.Http;
using ReserverRideVar01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.ViewModels
{
    public class ProductCreateEditViewModel
    {
        public Product product { get; set; }
        public ProductCreateEditViewModel()
        {
            this.product = new Product();
        }
        public int ProductId
        {
            get { return this.product.ProductId; }
            set { this.product.ProductId = value; }
        }
        public string ProductName
        {
            get { return this.product.ProductName; }
            set { this.product.ProductName = value; }
        }
        public int ProductQty
        {
            get { return this.product.ProductQty; }
            set { this.product.ProductQty = value; }
        }
        public int ProductPrice
        {
            get { return this.product.ProductPrice; }
            set { this.product.ProductPrice = value; }
        }
        public int ProductCost
        {
            get { return this.product.ProductCost; }
            set { this.product.ProductCost = value; }
        }
        public string ProductDescription
        {
            get { return this.product.ProductDescription; }
            set { this.product.ProductDescription = value; }
        }
        public IFormFile ProductPhoto { get; set; }
        public int IslandId { get; set; }
        public virtual Island Island { get; set; }
    }
}
