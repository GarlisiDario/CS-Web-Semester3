using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCSportStore.Models;
using MVCSportStore.ViewModels;

namespace MVCSportStore.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) 
        {

        }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Reseller> Resellers { get; set; }
        public DbSet<ResellerStock> ResellerStocks { get; set; }
        
    }
}
