using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.DAL.Context;
using Webstore.Interfaces.Services;
using WebStore.Domain;
using WebStore.Domain.Entities;
using Webstore.Services.Mapping;
using WebStore.Domain.DTO.Products;

namespace Webstore.Services.Products.InSql
{
    public class InSqIProductData : IProductData
    {
        private readonly WebStoreDB _db;

        public InSqIProductData(WebStoreDB db)
        {
            _db = db;
        }

        public IEnumerable<BrandDTO> GetBrands() => _db.Brands.Include(brand => brand.Products).ToDTO();

        public BrandDTO GetBrandsById(int id)
        {
            return _db.Brands.Include(brand => brand.Products).FirstOrDefault(brand => brand.Id == id).ToDTO();
        }

        public ProductDTO GetProductById(int id)
        {
            return _db.Products.Include(p => p.Brand).Include(p => p.Category).FirstOrDefault(p => p.Id == id).ToDTO();
        }

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = _db.Products.Include(p => p.Category).Include(p => p.Brand);

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

            return query.AsEnumerable().ToDTO();
        }

        public IEnumerable<CategoryDTO> GetСategories() => _db.Categories.Include(category => category.Products).ToDTO();

        public CategoryDTO GetСategoriesById(int id)
        {
            return _db.Categories.Include(category => category.Products).FirstOrDefault(category => category.Id == id).ToDTO();
        }
    }
}
