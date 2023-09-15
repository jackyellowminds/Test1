using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RBookingWebApi.DataContext
{
    public class OrderTB
    {
        [Key]
        public int OrderId { get; set; }
        public int RTableId { get; set; }
        public DateTime DateTime { get; set; }
        public int CreatedBy { get; set; }
        public double TotalAmount { get; set; }
        public int UserNo { get; set; }
    }
}
