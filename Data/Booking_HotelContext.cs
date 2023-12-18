using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Booking_Hotel.Models;

namespace Booking_Hotel.Data
{
    public class Booking_HotelContext : DbContext
    {
        public Booking_HotelContext (DbContextOptions<Booking_HotelContext> options)
            : base(options)
        {
        }

        public DbSet<Booking_Hotel.Models.User> User { get; set; } = default!;

        public DbSet<Booking_Hotel.Models.LevelHotel>? LevelHotel { get; set; }

        public DbSet<Booking_Hotel.Models.Product>? Product { get; set; }
    }
}
