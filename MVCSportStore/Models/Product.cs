using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MVCSportStore.Models
{
    public class Product
    {
        public Product() 
        {

        }
        public Product(string[] data)
        {
            //name;description;category;price
            Name = data[0];
            Description = data[1];
            Category = data[2];
            Price = decimal.Parse(data[3]);
        }
        public long ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName ="decimal(8,2)")]
        public decimal? Price {  get; set; }
        [Required]
        public string? Category { get; set; }
        public decimal ProductPrice =>
            (Price == null)?0 : (decimal)Price;
        public ICollection<ResellerStock> ResellerStocks { get; set; }
    }
}
