using Microsoft.EntityFrameworkCore;
using trialmidterm.Data.Models;

namespace trialmidterm.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Guest> Guest { get; set; }

        public DbSet<Room> Room { get; set; }

    }
}
