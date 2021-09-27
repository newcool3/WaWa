using System;
using System.Collections.Generic;

#nullable disable

namespace ReserverRideVar01.Models
{
    public partial class Member
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberPhone { get; set; }
        public string MemberEmail { get; set; }
        public string MemberAddress { get; set; }
        public string MemberPassword { get; set; }
    }
}
