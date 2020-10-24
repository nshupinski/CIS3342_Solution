using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Review
{
    public class Reservation
    {
        public int ID { get; set; }
        public String RestaurantName { get; set; }
        public String ReservationName { get; set; }
        public DateTime Time { get; set; }
        public String PhoneNumber { get; set; }
        public int PartySize { get; set; }
    }
}