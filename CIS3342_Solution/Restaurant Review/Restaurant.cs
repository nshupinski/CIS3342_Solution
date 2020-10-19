using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Review
{
    public class Restaurant
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }
        public String Image { get; set; }
        public String Representative { get; set; }
    }
}