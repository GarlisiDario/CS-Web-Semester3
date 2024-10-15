﻿using MVCSportStore.Data;
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
        private IEnumerable<Product> GetProducts(int productPage)
        {
            return _context.Products
            .OrderBy(p => p.ProductId)
            .Skip((productPage - 1) * PaginaSettings.ProductPagination)
            .Take(PaginaSettings.ProductPagination);
        }
        private PagingInfo GetPagingInfo(int productPage)
        {
            var pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = productPage;
            pagingInfo.PageItems = PaginaSettings.ProductPagination;
            pagingInfo.TotalItems = _context.Products.Count();
            return pagingInfo;
        }
        public ProductModel GetProductModel(int productPage)
        {
            var productModel = new ProductModel();
            productModel.Products = GetProducts(productPage);
            productModel.PagingInfo = GetPagingInfo(productPage);
            return productModel;
        }
    }
}
