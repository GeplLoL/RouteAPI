using Microsoft.EntityFrameworkCore;
using RouteAPI.Models;

namespace RouteAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Bus> Buses { get; set; }
        public DbSet<MyRoute> Routes { get; set; }
        public DbSet<User> Users{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>()
                .ToTable("Buses");

            modelBuilder.Entity<MyRoute>()
                .ToTable("MyRoutes")
                .HasOne(r => r.Bus)
                .WithMany(b => b.Routes)
                .HasForeignKey(r => r.BusId)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
