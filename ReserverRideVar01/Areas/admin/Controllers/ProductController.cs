using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModel;
using ReserverRideVar01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReserverRideVar01.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        string hashKey = "OLkdjTkzOoNYjDmeFmCk7CORlRTo4F47";
        string hashIV = "CHsEQUu2AbRqDtQP";
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
        public IActionResult invoice()
        {
            var status = Request.Form["Status"];
            var MerchantID = Request.Form["MerchantID"];
            var TradeInfo = Request.Form["TradeInfo"];
            var TradeSha = Request.Form["TradeSha"];
            string aes = DecryptAES256(TradeInfo);
            
            JObject json = JObject.Parse(aes);
            ViewBag.MerchantOrderNo = json["Result"]["MerchantOrderNo"];
            ViewBag.PayTime = json["Result"]["PayTime"];
            ViewBag.AccountNo = json["Result"]["AccLinkNo"];
            ViewBag.Amt = json["Result"]["Amt"];
            ViewBag.TradeNo = json["Result"]["TradeNo"];

            return View();
        }
        public IActionResult Index()
        {
            ProductViewModel productView = new ProductViewModel();
            productView.Products = GetProduct();
            return View(productView);
        }
        [Authorize(Roles = "manager")]
        public ActionResult create()
        {
            return View();
        }
        [Authorize(Roles = "manager")]
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
        [Authorize(Roles = "manager")]
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
        [Authorize(Roles = "manager")]
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
        [Authorize(Roles = "manager")]
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

        public string DecryptAES256(string encryptData)//解密
        {
            string sSecretKey = hashKey;
            string iv = hashIV;
            var encryptBytes = HexStringToByteArray(encryptData.ToUpper());
            var aes = new RijndaelManaged();
            aes.Key = Encoding.UTF8.GetBytes(sSecretKey);
            aes.IV = Encoding.UTF8.GetBytes(iv);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.None;
            ICryptoTransform transform = aes.CreateDecryptor();
            return
            Encoding.UTF8.GetString(RemovePKCS7Padding(transform.TransformFinalBlock(encryptBytes, 0, encryptBytes.Length)));
        }
        private static byte[] RemovePKCS7Padding(byte[] data)
        {
            int iLength = data[data.Length - 1];
            var output = new byte[data.Length - iLength];
            Buffer.BlockCopy(data, 0, output, 0, output.Length);
            return output;
        }
        private static byte[] HexStringToByteArray(string hexString)
        {
            int hexStringLength = hexString.Length;
            byte[] b = new byte[hexStringLength / 2];
            for (int i = 0; i < hexStringLength; i += 2)
            {
                int topChar = (hexString[i] > 0x40 ? hexString[i] - 0x37 : hexString[i] - 0x30) << 4;
                int bottomChar = hexString[i + 1] > 0x40 ? hexString[i + 1] - 0x37 : hexString[i + 1] - 0x30;
                b[i / 2] = Convert.ToByte(topChar + bottomChar);
            }
            return b;
        }
    }
}
