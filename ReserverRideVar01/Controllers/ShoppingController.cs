using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReserverRideVar01.Controllers
{
    public class ShoppingController : Controller
    {
        MSITDbContext _db;

        public ShoppingController(MSITDbContext db)
        {
            _db = db;
        }
        public ActionResult RemoveCart(int id)
        {
            List<CShoppingCartItemViewModel> cart = null;
            Product prod = _db.Products.FirstOrDefault(p => p.ProductId == id);
            if (HttpContext.Session.Keys.Contains(
                Dictionary.SK_PURCHASED_PRODUCTS_IN_SHOPPINGCART))
            {
                string json = HttpContext.Session.GetString(
                    Dictionary.SK_PURCHASED_PRODUCTS_IN_SHOPPINGCART);
                cart = JsonSerializer.Deserialize<List<CShoppingCartItemViewModel>>(json);
                HttpContext.Session.Remove(Dictionary.SK_PURCHASED_PRODUCTS_IN_SHOPPINGCART);
                var itemToRemove = cart.Single(i => i.ProductId == id);
                cart.Remove(itemToRemove);
                json = JsonSerializer.Serialize(cart);
                HttpContext.Session.SetString(Dictionary.SK_PURCHASED_PRODUCTS_IN_SHOPPINGCART, json);
                cart = JsonSerializer.Deserialize<List<CShoppingCartItemViewModel>>(json);
            }
            else
                return PartialView("_CartCard", cart);

            return PartialView("_CartCard", cart);
        }

        public ActionResult RemoveAllCart()
        {
            HttpContext.Session.Remove(Dictionary.SK_PURCHASED_PRODUCTS_IN_SHOPPINGCART);
            List<CShoppingCartItemViewModel> cart = null;
            return PartialView("_CartCard", cart);
        }
        public ActionResult ViewCart()
        {
            List<CShoppingCartItemViewModel> cart = null;
            if (HttpContext.Session.Keys.Contains(
                Dictionary.SK_PURCHASED_PRODUCTS_IN_SHOPPINGCART))
            {
                string json = HttpContext.Session.GetString(
                    Dictionary.SK_PURCHASED_PRODUCTS_IN_SHOPPINGCART);
                cart = JsonSerializer.Deserialize<List<CShoppingCartItemViewModel>>(json);
            }
            else
                return View(cart);
            return View(cart);
        }
        public IActionResult AddToCart(int? id)
        {
            Product prod = null;
            if (id != null)
            {
                prod = _db.Products.FirstOrDefault(p => p.ProductId == id);
            }
            if (prod == null)
            {
                return RedirectToAction("List","product");
            }
            return View(prod);
        }
        [HttpPost]
        public IActionResult AddToCart(CAddToCartViewModel model)
        {
            string json = "";
            Product prod = _db.Products.FirstOrDefault(p => p.ProductId == model.txtFid);
            if (prod != null)
            {
                List<CShoppingCartItemViewModel> cart = null;
                if (!HttpContext.Session.Keys.Contains(Dictionary.SK_PURCHASED_PRODUCTS_IN_SHOPPINGCART))
                    cart = new List<CShoppingCartItemViewModel>();
                else
                {
                    json = HttpContext.Session.GetString(Dictionary.SK_PURCHASED_PRODUCTS_IN_SHOPPINGCART);
                    cart = JsonSerializer.Deserialize<List<CShoppingCartItemViewModel>>(json);
                }
                CShoppingCartItemViewModel item = new CShoppingCartItemViewModel()
                {
                    count = model.txtCount,
                    price = prod.ProductPrice,
                    product = prod,
                    ProductId = prod.ProductId
                };
                cart.Add(item);
                json = JsonSerializer.Serialize(cart);
                HttpContext.Session.SetString(Dictionary.SK_PURCHASED_PRODUCTS_IN_SHOPPINGCART, json);
            }
            return RedirectToAction("ViewCart", "shopping");

        }
    }
}
