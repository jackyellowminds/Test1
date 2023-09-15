using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBookingWebApi.Models
{
    public class MenuMD
    {
        
        public Nullable<int> MenuId { get; set; }
        public String ItemName { get; set; }
        public double Price { get; set; }
    }
}
