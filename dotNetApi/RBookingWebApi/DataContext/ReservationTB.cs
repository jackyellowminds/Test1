using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RBookingWebApi.DataContext
{
    public class ReservationTB
    {
        [Key]
        public int ReservationId { get; set; }
        public int MenuId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int RTableId { get; set; }
        public Nullable<int> OrderId { get; set; }
        public int UserNo { get; set; }
        public int UserCapacity { get; set; }
    }
}
