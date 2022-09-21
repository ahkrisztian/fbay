using fbay.Models;
using Microsoft.EntityFrameworkCore;

namespace fbay.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Image> Images { get; set; }
        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
