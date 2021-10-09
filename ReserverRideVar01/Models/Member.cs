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
        public string MemberName { get; set; }

        [Required]//不能空值
        [MaxLength(50)]//最大長度
        [Column(TypeName = "varchar")]
        public string MemberPhone { get; set; }

        [Required]//不能空值
        [MaxLength(50)]//最大長度
        [Column(TypeName = "nvarchar")]
        public string MemberPassword { get; set; }


        [MaxLength(50)]//最大長度
        [Column(TypeName = "nvarchar")]
        public string MemberAddress { get; set; }

        [Required]//不能空值
        [Column(TypeName = "datetime")]
        public DateTime MemberBirthday { get; set; }

        [Required]//不能空值
        [MaxLength(10)]//最大長度
        [Column(TypeName = "varchar")]
        public string MemberNumberID { get; set; }

        [MaxLength(10)]//最大長度
        [Column(TypeName = "varchar")]
        public string MemberEnable { get; set; }

        [MaxLength]//最大長度
        [Column(TypeName = "varbinary")]
        public byte[] MemberPhoto { get; set; }

        public int MemberType { get; set; } //int 型別

        [Column(TypeName = "datetime")]
        public DateTime MemberCreateDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime MemberModifyDate { get; set; }

        [Required]//不能空值
        [MaxLength(50)]//最大長度
        [Column(TypeName = "nvarchar")]
        public string MemberEmail { get; set; }
        [MaxLength(50)]
        public string Role { get; set; }
    }
}
