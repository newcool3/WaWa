using Microsoft.AspNetCore.Mvc;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModel;
using ReserverRideVar01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.Areas.admin.Controllers
{
    [Area("admin")]
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
        public IActionResult Index()
        {
            ProductViewModel productView = new ProductViewModel();
            productView.Products = GetProduct();
            return View(productView);
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

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Product prod = _db.Products.FirstOrDefault(i => i.ProductId == id);
            if (prod == null)
            {
                return RedirectToAction("Index");
            }
            return View(prod);

        }
        [HttpPost]
        public ActionResult Edit(ProductCreateEditViewModel p)
        {
            Product prod = _db.Products.FirstOrDefault(i => i.ProductId == p.ProductId);
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

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Product prod = _db.Products.FirstOrDefault(i => i.ProductId == id);
                if (prod != null)
                {
                    _db.Products.Remove(prod);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
