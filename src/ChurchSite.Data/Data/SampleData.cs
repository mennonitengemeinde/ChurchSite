using System.Linq;
using ChurchSite.Data.Data;
using ChurchSite.Data.Models;

namespace ChurchSite.Data.Data
{
    public static class SampleData
    {
        public static void Initialize(ChurchContext context)
        {
            context.Database.EnsureCreated();

            if (context.Churches.Any())
            {
                return;
            }

            var churches = new Church[]
            {
                new Church { Id = 1, Name = "Church 1", StreetAddress = "123 Street", City = "Detroit", State = "Michigan", Country = "United States" },
                new Church { Id = 1, Name = "Church 2", StreetAddress = "231 Street", City = "Ann Arbour", State = "Michigan", Country = "United States" },
                new Church { Id = 1, Name = "Church 3", StreetAddress = "321 Street", City = "Taylor", State = "Michigan", Country = "United States" }
            };

            context.Churches.AddRange(churches);
            context.SaveChanges();
        }
    }
}