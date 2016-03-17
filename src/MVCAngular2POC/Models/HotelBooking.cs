using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAngular2POC.Models
{
    public class HotelBooking
    {
        public Guid HotelBookingId { get; set; }

        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int NumOfAdults { get; set; }
        public int NumOfChildren { get; set; }
        public int NumOfPets { get; set; }

        public DateTime CheckinDate { get; set; }
        public DateTime CheckoutDate { get; set; }
    }
}
