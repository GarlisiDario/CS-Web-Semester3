using Microsoft.EntityFrameworkCore;
using MVCFifa.Models;
namespace MVCFifa.Data
{
    public class ApplicationDbContext : DbContext
    {
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) 
        {

        }
        public DbSet<Player>? Players { get; set; }
    }
}
