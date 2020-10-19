using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Review
{
    public class Review
    {
        public int ID { get; set; }
        public String ReviewerName { get; set; }
        public String RestaurantName { get; set; }
        public String FoodQuality { get; set; }
        public String ServiceQuality { get; set; }
        public String AtmosphereQuality { get; set; }
        public String PriceQuality { get; set; }
        public String Comment { get; set; }
    }
}