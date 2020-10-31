using ChurchSite.Data.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSite.Data.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

        public int FatherOfId { get; set; }
        public Family FatherOf { get; set; }

        public int MotherOfId { get; set; }
        public Family MotherOf { get; set; }

        public int ChildOfId { get; set; }
        public Family ChildOf { get; set; }

        //public List<Family> Families { get; set; }

        public List<Membership> Memberships { get; set; }
    }
}
