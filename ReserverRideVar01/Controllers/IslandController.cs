using Microsoft.AspNetCore.Mvc;
using ReserverRideVar01.DbContext;
using ReserverRideVar01.Models;
using ReserverRideVar01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.Controllers
{
    public class IslandController : Controller
    {
        MSITDbContext _db;
        public IslandController(MSITDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        
    }
}
