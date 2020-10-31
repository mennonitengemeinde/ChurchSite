using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSite.Data.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OtherChurch { get; set; }
        public bool Active { get; set; }

        public int ChurchId { get; set; }
        public Church Church { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
