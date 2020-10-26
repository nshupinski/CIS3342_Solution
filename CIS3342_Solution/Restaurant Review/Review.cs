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
        public int FoodQuality { get; set; }
        public int ServiceQuality { get; set; }
        public int AtmosphereQuality { get; set; }
        public int PriceQuality { get; set; }
        public String Comment { get; set; }
    }
}