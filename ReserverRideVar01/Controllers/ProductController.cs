using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModel;
using ReserverRideVar01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.Controllers
{
    public class ProductController : Controller
    {
        MSITDbContext _db;

        public ProductController(MSITDbContext db)
        {
            _db = db;
        }

        private List<Product> GetProduct()
        {
            List<Product> product = new List<Product>();
            var products = _db.Products;
            foreach (var item in products)
            {
                product.Add(new Product()
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductCost = item.ProductCost,
                    ProductDescription = item.ProductDescription,
                    ProductPrice = item.ProductPrice,
                    ProductPhoto = item.ProductPhoto,
                    ProductQty = item.ProductQty
                });
            }
            return product;
        }
        
        private List<Island> GetIsland()
        {
            List<Island> island = new List<Island>();
            var islands = _db.Island;
            foreach (var item in islands)
            {
                island.Add(new Island() {
                    IslandId = item.IslandId,
                    IslandName = item.IslandName,
                    IslandPhoto = item.IslandPhoto
                });
            }
            return island;
        }
        public IActionResult List()
        {
            ProductViewModel productView = new ProductViewModel();
            productView.Products = GetProduct();
            productView.Islands = GetIsland();
            return View(productView);
            
        }
        public IActionResult index(int? id)
        {
            var products = _db.Products.Where(i => i.IslandId == id);
            return PartialView("_ProductCard", products);
        }

        public IActionResult indexString(string str)
        {
            var products = _db.Products.Where(i => EF.Functions.Like(i.ProductName, $"%{str}%"));
            return PartialView("_ProductCard", products);
        }
    }
}

