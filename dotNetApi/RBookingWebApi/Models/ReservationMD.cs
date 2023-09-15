using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBookingWebApi.Models
{
    public class ReservationMD
    {
        public Nullable<int> ReservationId { get; set; }
        public int MenuId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int RTableId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public String ItemName { get; set; }
        public String TableNumber { get; set; }
        public int UserNo { get; set; }
        public String User { get; set; }
        public int UserCapacity { get; set; }
    }
}
