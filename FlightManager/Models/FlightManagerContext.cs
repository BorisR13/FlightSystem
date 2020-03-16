using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models
{
    public class FlightManagerContext : DbContext
    {
        public FlightManagerContext()
        {

        }

        public FlightManagerContext(DbContextOptions<FlightManagerContext> options) :  base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
    }
}
