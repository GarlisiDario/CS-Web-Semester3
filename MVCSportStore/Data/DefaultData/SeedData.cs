﻿using MVCSportStore.Models;

namespace MVCSportStore.Data.DefaultData
{
    public static class SeedData
    {
        public static void EnsurePopulated(WebApplication app)
        {

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
                if (!context.Products.Any()) 
                {
                    foreach (var productString in DefaultData.Products) 
                    {
                        var product = new Product(productString.Split(';'));
                        context.Products.Add(product);
                    }
                    context.SaveChanges();
                }
                
            }
        }
        private static IEnumerable<string> Products => GetProductList();
        private static IEnumerable<string> GetProductList()
        {
            List<string> products = new List<string>();
            //Teams data
            return products;
        }

    }
}
