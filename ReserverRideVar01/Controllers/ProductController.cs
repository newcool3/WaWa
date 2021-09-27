using Microsoft.AspNetCore.Mvc;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.Controllers
{
    public class ProductController : Controller
    {
        MSITDbcontext _db;

        public ProductController(MSITDbcontext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var products = _db.Products;
            List<ProductViewModel> list = new List<ProductViewModel>();
            foreach (var item in products)
            {
                list.Add(new ProductViewModel() { product = item });
            }
            return View(list);
        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(ProductViewModel p)
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
            _db.Products.Add(prod);
            _db.SaveChanges();

            return RedirectToAction("Index");
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
        public ActionResult Edit(ProductViewModel p)
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
            _db.SaveChanges();

            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}

