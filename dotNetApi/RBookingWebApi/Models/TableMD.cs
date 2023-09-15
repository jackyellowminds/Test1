using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBookingWebApi.Models
{
    public class TableMD
    {
        public Nullable<int> RTableId { get; set; }
        public String TableNumber { get; set; }
        public int Capacity { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
