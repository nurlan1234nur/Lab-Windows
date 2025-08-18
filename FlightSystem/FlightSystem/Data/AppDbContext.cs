using Microsoft.EntityFrameworkCore;
using FlightSystem.Models;


namespace ApiWithSQLite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Flight> Flights => Set<Flight>();
        public DbSet<FlightInfo> FlightInfos => Set<FlightInfo>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Seat> Seats => Set<Seat>();

    }
}