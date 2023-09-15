using Microsoft.EntityFrameworkCore;
using OnlineBookStoreWebApi.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RBookingWebApi.DataContext
{
    public class RBookingWeApiDataContext:DbContext
    {
        public RBookingWeApiDataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<RTableTB> RTableTB { get; set; }
        public DbSet<MenuTB> MenuTB { get; set; }
        public DbSet<ReservationTB> ReservationTB { get; set; }
        public DbSet<OrderTB> OrderTB { get; set; }
        public DbSet<OrderDetailTB> OrderDetailTB { get; set; }
        public DbSet<UsersTB> UsersTB { get; set; }
    }
}
