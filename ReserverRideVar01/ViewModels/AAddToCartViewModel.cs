using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.ViewModels
{
    public class AAddToCartViewModel
    {
        public int txtFId { get; set; }
        public string txtName { get; set; }
        public string txtPhone { get; set; }
        public int txtCount { get; set; }
        [DataType(DataType.Date)]
        public DateTime txtDay { get; set; }
        public int NumCal { get; set; }
    }
}
