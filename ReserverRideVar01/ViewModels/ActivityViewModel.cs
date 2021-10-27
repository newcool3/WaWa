using Microsoft.AspNetCore.Http;
using ReserverRideVar01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.ViewModels
{
    public class ActivityViewModel
    {
        public Models.Activity activity { get; set; }

        public ActivityViewModel()
        {
            this.activity = new Activity();
        }

        public int ActivityId { get; set; }

        public string ActivityName { get; set; }

        public string ActivityType { get; set; }

        public DateTime ActivityStartDate { get; set; }

        public DateTime ActivityEndDate { get; set; }

        public string ActivityTimezone { get; set; }

        public int ActivityPrice { get; set; }

        public string ActivityLocation { get; set; }

        public string ActivityState { get; set; }

        public int ActivityNumberLimit { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime ActivityDeadline { get; set; }
        public IFormFile ActivityPhoto { get; set; }
        public int IslandId { get; set; }

        public virtual Island Island { get; set; }

    }
}

