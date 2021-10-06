using Microsoft.AspNetCore.Http;
using ReserverRideVar01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.ViewModels
{
    public class IslandViewModel
    {
        public Island island { get; set; }
        public IslandViewModel()
        {
            this.island = new Island();
        }
        public int IslandId 
        {
            get { return this.island.IslandId; }
            set { this.island.IslandId = value; }
        }
        public string IslandName
        {
            get { return this.island.IslandName; }
            set { this.island.IslandName = value; }
        }
        public IFormFile IslandPhoto { get; set; }
    }
}
