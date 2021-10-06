using Microsoft.EntityFrameworkCore;
using ReserverRideVar01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ReserverRideVar01.DbContext
{
    public class MSITDbcontext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MSITDbcontext()
        {
        }

        public MSITDbcontext(DbContextOptions<MSITDbcontext> options): base(options) { }

        public DbSet<Island> Island { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }


    }
}
