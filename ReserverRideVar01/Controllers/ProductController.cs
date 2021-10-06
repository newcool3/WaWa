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

            //var product = _db.Products.Include(i => i.Island).ToList();

            productView.Products = GetProduct();
            productView.Islands = GetIsland();
            return View(productView);
            
        }
        public IActionResult index(int? id)
        {
            //MSITDbContext db = new MSITDbContext();
            //Product products = db.Products.Where(i => i.IslandId == id);

            var products = _db.Products.Where(i => i.IslandId == id);
            return PartialView("_ProductCard", products);
        }
        
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(ProductCreateEditViewModel p)
        {
            Product prod = new Product();
            if (p.ProductPhoto != null)
            {
                using var fileStream = p.ProductPhoto.OpenReadStream();
                prod.ProductPhoto = new byte[(int)p.ProductPhoto.Length];
                fileStream.Read(prod.ProductPhoto, 0, (int)p.ProductPhoto.Length);
            }
            prod.ProductName = p.ProductName;
            prod.ProductPrice = p.ProductPrice;
            prod.ProductCost = p.ProductCost;
            prod.ProductQty = p.ProductQty;
            prod.ProductDescription = p.ProductDescription;
            prod.IslandId = p.IslandId;
            _db.Products.Add(prod);
            _db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }

            Product prod = _db.Products.FirstOrDefault(i => i.ProductId == id);
            if (prod == null)
            {
                return RedirectToAction("List");
            }
            return View(prod);

        }
        [HttpPost]
        public ActionResult Edit(ProductCreateEditViewModel p)
        {
            //MSITDbContext db = new MSITDbContext();
            Product prod = (new MSITDbContext()).Products.FirstOrDefault(i => i.IslandId == p.ProductId);
            //Product prod = _db.Products.FirstOrDefault(i => i.ProductId == p.ProductId);
            if (p.ProductPhoto != null)
            {
                using var fileStream = p.ProductPhoto.OpenReadStream();
                prod.ProductPhoto = new byte[(int)p.ProductPhoto.Length];
                fileStream.Read(prod.ProductPhoto, 0, (int)p.ProductPhoto.Length);
            }

            prod.ProductName = p.ProductName;
            prod.ProductPrice = p.ProductPrice;
            prod.ProductCost = p.ProductCost;
            prod.ProductQty = p.ProductQty;
            prod.ProductDescription = p.ProductDescription;
            prod.IslandId = p.IslandId;
            _db.SaveChanges();

            return RedirectToAction("List");
        }
        public ActionResult Delete(int? id)
        {
            if (id!=null)
            {
                Product prod = _db.Products.FirstOrDefault(i => i.ProductId == id);
                if (prod != null)
                {
                    _db.Products.Remove(prod);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
    }
}

