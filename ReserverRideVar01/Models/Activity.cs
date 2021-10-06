using System;
using System.Collections.Generic;

#nullable disable

namespace test02.Models
{
    public partial class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityType { get; set; }
        public string ActivityTimezone { get; set; }
        public DateTime ActivityStartDate { get; set; }
        public DateTime ActivityEndDate { get; set; }
        public int ActivityPrice { get; set; }
        public string ActivityLocation { get; set; }
        public string ActivityState { get; set; }
        public int ActivityNumberLimit { get; set; }
        public DateTime ActivityDeadline { get; set; }
    }
}
