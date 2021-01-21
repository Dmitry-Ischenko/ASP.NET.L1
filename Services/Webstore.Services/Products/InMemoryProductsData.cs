using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.Interfaces.Services;
using WebStore.Domain;
using WebStore.Domain.Entities;
using Webstore.Services.Data;

namespace Webstore.Services.Products
{
    [Obsolete("Класс устарел и не реализует необходимые методы")]
    public class InMemoryProductsData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => TestDB.Brands;

        public IEnumerable<Category> GetСategories() => TestDB.Сategories;

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            var query = TestDB.Products;

            if (Filter?.СategoryId is { } category_id)
                query = query.Where(product => product.CategoryId == category_id).ToList();
            if (Filter?.BrandId is { } brand_id)
                query = query.Where(product => product.BrandId == brand_id).ToList();
            return query;
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
