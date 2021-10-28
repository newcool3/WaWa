using ReserverRideVar01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.ViewModels
{
    public class AShoppingCartViewModel
    {
        public int OrderId { get; set; }
        public int? OrderGuid { get; set; }
        [Display(Name = "訂購人")]
        public string OrderName { get; set; }
        [Display(Name = "聯絡方式")]
        public string OrderPhone { get; set; }
        [Display(Name = "訂購日期")]
        public DateTime? OrderDate { get; set; }
        [Display(Name = "訂購時間")]
        public string OrderTimezone { get; set; }
        [Display(Name = "訂購金額")]
        public int? OrderTotalPrice { get; set; }
        [Display(Name = "訂購狀態")]
        public string OrderCheck { get; set; }
        [Display(Name = "訂購結單時間")]
        public DateTime? OrderUpdatetime { get; set; }
        [Display(Name = "訂購人數")]
        public int OrderCustom { get; set; }
        public int? ActivityId { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
