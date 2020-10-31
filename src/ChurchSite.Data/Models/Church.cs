using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSite.Data.Models
{
    public class Church
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public List<Membership> Memberships { get; set; }
    }
}
