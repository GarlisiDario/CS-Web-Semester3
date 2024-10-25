namespace MVCSportStore.Models
{
    public class ResellerStock
    {
        public int ResellerStockId { get; set; }
        public int ResellerId { get; set; }
       
        public long ProductId { get; set; }
        public int Amount { get; set; }
        public Reseller? Reseller { get; set; }
        public Product? Product { get; set; }
    }
}
