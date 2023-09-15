using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RBookingWebApi.DataContext
{
    public class MenuTB
    {
        [Key]
        public int MenuId { get; set; }
        public String ItemName { get; set; }
        public double Price { get; set; }
    }
}
