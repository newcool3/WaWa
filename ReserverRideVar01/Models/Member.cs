using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ReserverRideVar01.Models
{
    public partial class Member
    {

        [Key]//pk
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//識別規格
        public int MemberID { get; set; } //int 型別

        [Required]//不能空值
        [MaxLength(50)]//最大長度
        [Column(TypeName = "nvarchar")]
        [Display(Name = "姓名")]
        public string MemberName { get; set; }

        [Required]//不能空值
        [MaxLength(50)]//最大長度
        [Column(TypeName = "varchar")]
        [Display(Name = "電話")]
        public string MemberPhone { get; set; }

        [Required]//不能空值
        [MaxLength(50)]//最大長度
        [Column(TypeName = "nvarchar")]
        [Display(Name = "密碼")]
        public string MemberPassword { get; set; }


        [MaxLength(50)]//最大長度
        [Column(TypeName = "nvarchar")]
        [Display(Name = "地址")]
        public string MemberAddress { get; set; }

        [Required]//不能空值
        [Column(TypeName = "datetime")]
        [Display(Name = "生日")]
        public DateTime MemberBirthday { get; set; }

        [Required]//不能空值
        [MaxLength(10)]//最大長度
        [Column(TypeName = "varchar")]
        [Display(Name = "身分證字號")]
        public string MemberNumberID { get; set; }

        [MaxLength(10)]//最大長度
        [Column(TypeName = "varchar")]
        [Display(Name = "是否激活")]
        public string MemberEnable { get; set; }

        [MaxLength]//最大長度
        [Column(TypeName = "varbinary")]
        [Display(Name = "照片")]
        public byte[] MemberPhoto { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "會員種類")]
        public string MemberType { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "創建日期")]
        public DateTime MemberCreateDate { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "修改日期")]
        public DateTime MemberModifyDate { get; set; }

        [Required]//不能空值
        [MaxLength(50)]//最大長度
        [Column(TypeName = "nvarchar")]
        [Display(Name = "帳號")]
        [EmailAddress(ErrorMessage = "這不是Email格式")]
        public string MemberEmail { get; set; }
        [MaxLength(50)]
        public string Role { get; set; }
    }
}
