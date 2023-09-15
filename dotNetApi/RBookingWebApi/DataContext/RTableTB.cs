using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RBookingWebApi.DataContext
{
    public class RTableTB
    {
        [Key]
        public int RTableId { get; set; }
        public String TableNumber { get; set; }
        public int Capacity { get; set; }

    }
}
