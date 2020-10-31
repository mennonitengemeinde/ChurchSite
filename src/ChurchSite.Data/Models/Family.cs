using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSite.Data.Models
{
    public class Family
    {
        public int Id { get; set; }

        public int FatherId { get; set; }
        public Person Father { get; set; }

        public int MotherId { get; set; }
        public Person Mother { get; set; }

        public List<Person> Children { get; set; }
    }
}
