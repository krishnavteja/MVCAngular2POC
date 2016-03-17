using MVCAngular2POC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAngular2POC.Migrations
{
    public class Seeder
    {
        private readonly ApplicationDbContext Context;

        private readonly Guid HiltonHotelId = Guid.Parse("3721D2CE-F654-4D44-886D-EE51D87F797B");
        private readonly Guid MarriottHotelId = Guid.Parse("FDE50A9F-156F-404D-AF89-403A9A9716E3");
        private readonly Guid HyattHotelId = Guid.Parse("B057DCFB-8776-4A35-9D71-7F7A99F4C2F3");

        public Seeder(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public async Task EnsureSeedData()
        {
            // Seed Hotel data
            SeedHotel(HiltonHotelId, "Hilton", "100 Hilton Ave", "Chicago", "IL", "60110", true, false, false);
            SeedHotel(MarriottHotelId, "Mariott", "100 Mariott Ave", "Phoenix", "AZ", "80115", false, false, true);
            SeedHotel(HyattHotelId, "Hyatt", "100 Hyatt Ave", "Sacramento", "CA", "95835", true, true, true);

            await this.Context.SaveChangesAsync();
        }

        private void SeedHotel(Guid id, string name, string streetAddress, string city, string state, string zipcode, bool allowsPets, bool hasFreeBF, bool hasFreeWifi)
        {
            if (!this.Context.Hotels.Any(h => h.Id == id))
            {
                this.Context.Hotels.Add(new Hotel
                {
                    Id = id,
                    Name = name,
                    AllowsPets = allowsPets,
                    HasFreeBreakfast = hasFreeBF,
                    HasFreeWiFi = hasFreeWifi,
                    StreetAddress = streetAddress,
                    City = city,
                    State = state,
                    ZipCode = zipcode
                });
            }
        }
    }
}
