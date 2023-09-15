using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBookingWebApi.Models
{
    public class OrderMD
    {
        public int OrderId { get; set; }
        public int RTableId { get; set; }
        public DateTime DateTime { get; set; }
        public int CreatedBy { get; set; }
        public double TotalAmount { get; set; }
        public String TableNumber { get; set; }
        public int UserNo { get; set; }
        public String User { get; set; }
        public IEnumerable<OrderDetailMD> CartList { get; set; }
    }
}
