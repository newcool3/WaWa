using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ReserverRideVar01.Models
{
    public partial class Activity
    {
        //public Activity()
        //{
        //    ActivityOrders = new HashSet<ActivityOrder>();
        //}
        public int ActivityId { get; set; }
        [Display(Name = "活動名稱")]
        [Required(ErrorMessage = "請填寫活動名稱")]
        public string ActivityName { get; set; }
        [Display(Name = "活動種類")]
        [Required(ErrorMessage = "請選擇活動種類")]
        public string ActivityType { get; set; }
        [Display(Name = "開始日")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "請選擇活動開始日期")]
        public DateTime? ActivityStartDate { get; set; }
        [Display(Name = "結束日")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "請選擇活動結束日期")]
        public DateTime? ActivityEndDate { get; set; }
        [Display(Name = "活動時間")]
        public string ActivityTimezone { get; set; }
        [Display(Name = "活動金額")]
        [Required(ErrorMessage = "確認每場活動金額")]
        [Range(1, 50000)]
        public int ActivityPrice { get; set; }
        [Display(Name = "活動地址")]
        public string ActivityLocation { get; set; }
        [Display(Name = "活動狀態")]

        public string ActivityState { get; set; }
        [Display(Name = "單日人數限制")]
        [Range(1, 100)]
        public int? ActivityNumberLimit { get; set; }
        [Display(Name = "報名期限")]
        [DataType(DataType.Date)]
        public DateTime? ActivityDeadline { get; set; }
        [Display(Name = "活動圖片")]
        public byte[] ActivityPhoto { get; set; }

        public int? IslandId { get; set; }
        [Display(Name = "活動描述")]
        [StringLength(200, ErrorMessage = "超過限定字數")]
        public string ActivityDescription { get; set; }
      
        public virtual Island Island { get; set; }
        public virtual ICollection<ActivityOrder> ActivityOrders { get; set; }
    }
}
