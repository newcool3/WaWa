using Microsoft.EntityFrameworkCore;
using ReserverRideVar01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReserverRideVar01.ViewModel
{
    [Keyless]
    public class MemberViewModel
    {
        public Member _member { get; set; }
        public MemberViewModel ()
        {
            this._member = new Member();
        }
        
        public int MemberID { get; set; } //int 型別

        [Required]//不能空值
        [MaxLength(50)]//最大長度
        [Column(TypeName = "nvarchar")]
        public string MemberName
        {
            get { return this._member.MemberName; }
            set { this._member.MemberName = value; }
        }

        [Required]//不能空值
        [MaxLength(50)]//最大長度
        [Column(TypeName = "varchar")]
        public string MemberPhone
        {
            get { return this._member.MemberPhone; }
            set { this._member.MemberPhone = value; }
        }

        [Required]//不能空值
        [MaxLength(50)]//最大長度
        [Column(TypeName = "nvarchar")]
        public string MemberPassword
        {
            get { return this._member.MemberPassword; }
            set { this._member.MemberPassword = value; }
        }

        [Required]//不能空值
        [MaxLength(50)]//最大長度
        [Column(TypeName = "nvarchar")]
        public string MemberPassword2
        {
            get { return this._member.MemberPassword; }
            set { this._member.MemberPassword = value; }
        }

        [Required]//不能空值
        [Column(TypeName = "datetime")]
        public DateTime MemberBirthday 
        {
            get { return this._member.MemberBirthday; }
            set {this._member.MemberBirthday=value; } 
        }

        [Required]//不能空值
        [MaxLength(10)]//最大長度
        [Column(TypeName = "varchar")]
        public string MemberNumberID 
        { 
            get { return this._member.MemberNumberID; } 
            set { this._member.MemberNumberID = value; } 
        }

        [MaxLength(50)]//最大長度
        [Column(TypeName = "nvarchar")]
        public string MemberAddress { get; set; }

        [Required]//不能空值
        [MaxLength(50)]//最大長度
        [Column(TypeName = "nvarchar")]
        public string MemberEmail
        {
            get { return this._member.MemberEmail; }
            set { this._member.MemberEmail = value; }
        }


        [Display(Name = "會員種類")]
        public string MemberType
        {
            get { return this._member.MemberType; }
            set { this._member.MemberType = value; }
        }

        public DateTime MemberModifyDate{ get; set; }
    }
}
