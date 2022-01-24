using DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementWebAPI.DatabaseContext
{
    public class AirportSystemContext : DbContext
    {
        public AirportSystemContext(DbContextOptions<AirportSystemContext> options)
            : base(options)
        {

        }

        //tablica
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
    }
}
