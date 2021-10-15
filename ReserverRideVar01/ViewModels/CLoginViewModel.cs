using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.ViewModel
{
    public class CLoginViewModel
    {
        [Required(ErrorMessage = "請輸入Email")]
        public string txtAccount { get; set; }
        [Required(ErrorMessage = "請輸入密碼")]
        public string txtPassword { get; set; }
    }
}
