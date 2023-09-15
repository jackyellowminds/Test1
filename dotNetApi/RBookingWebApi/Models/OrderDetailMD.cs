using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBookingWebApi.Models
{
    public class OrderDetailMD
    {
        public Nullable<int> OrderDetailsId { get; set; } 
        public int MenuId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public String ItemName { get; set; }

    }
}
