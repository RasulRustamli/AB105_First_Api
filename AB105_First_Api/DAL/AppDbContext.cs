using AB105_First_Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AB105_First_Api.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
    }
}
