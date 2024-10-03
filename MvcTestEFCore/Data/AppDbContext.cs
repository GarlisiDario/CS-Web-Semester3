using Microsoft.EntityFrameworkCore;
using MvcTestEFCore.Models;
namespace MvcTestEFCore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }
        public DbSet<MvcTestEFCore.Models.FirstTable>? FirstTable { get; set; } 
    }
}
