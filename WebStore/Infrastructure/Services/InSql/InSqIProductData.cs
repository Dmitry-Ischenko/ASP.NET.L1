using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.DAL.Context;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services.InSql
{
    public class InSqIProductData : IProductData
    {
        private readonly WebStoreDB _db;

        public InSqIProductData(WebStoreDB db)
        {
            _db = db;
        }

        public IEnumerable<Brand> GetBrands() => _db.Brands.Include(brand => brand.Products);

        public Product GetProductById(int id)
        {
            return _db.Products.Include(p => p.Brand).Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = _db.Products;

            if (Filter?.Ids?.Length > 0)
            {
                query = query.Where(product => Filter.Ids.Contains(product.Id));
            }
            else
            {
                if (Filter?.BrandId != null)
                    query = query.Where(product => product.BrandId == Filter.BrandId);

                if (Filter?.СategoryId != null)
                    query = query.Where(product => product.CategoryId == Filter.СategoryId);
            }

            return query;
        }

        public IEnumerable<Category> GetСategories() => _db.Categories.Include(category => category.Products);
    }
}
