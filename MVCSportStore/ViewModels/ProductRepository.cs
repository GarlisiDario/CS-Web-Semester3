using MVCSportStore.Data;
using MVCSportStore.Models;

namespace MVCSportStore.ViewModels
{
    public class ProductRepository
    {
        StoreDbContext _context;
        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }
        private IEnumerable<Product> GetProducts(int productPage,string category)
        {
            return _context.Products
            .Where(p => p.Category == null || p.Category == category)
            .OrderBy(p => p.ProductId)
            .Skip((productPage - 1) * PagingSettings.ProductPagination)
            .Take(PagingSettings.ProductPagination);
        }
        private PagingInfo GetPagingInfo(int productPage,string category)
        {
            var pagingInfo = new PagingInfo();
            var totalItems = (category == null)
                ? _context.Products.Count() 
                : _context.Products.Where(p => p.Category == category).Count();
            pagingInfo.CurrentPage = productPage;
            pagingInfo.Category = category;
            pagingInfo.PageItems = PagingSettings.ProductPagination;
            pagingInfo.TotalItems = totalItems;
            return pagingInfo;
        }
        public ProductModel GetProductModel(int productPage,string category)
        {
            var productModel = new ProductModel();
            productModel.Products = GetProducts(productPage,category);
            productModel.PagingInfo = GetPagingInfo(productPage, category);
            return productModel;
        }
       
    }
}
