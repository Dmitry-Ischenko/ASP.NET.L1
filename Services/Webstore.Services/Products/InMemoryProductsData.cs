using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.Interfaces.Services;
using WebStore.Domain;
using WebStore.Domain.Entities;
using Webstore.Services.Data;
using WebStore.Domain.DTO.Products;
using Webstore.Services.Mapping;

namespace Webstore.Services.Products
{
    [Obsolete("Класс устарел и не реализует необходимые методы")]
    public class InMemoryProductsData : IProductData
    {
        public IEnumerable<BrandDTO> GetBrands() => TestDB.Brands.ToDTO();

        public IEnumerable<CategoryDTO> GetСategories() => TestDB.Сategories.ToDTO();

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null)
        {
            var query = TestDB.Products;

            if (Filter?.СategoryId is { } category_id)
                query = query.Where(product => product.CategoryId == category_id).ToList();
            if (Filter?.BrandId is { } brand_id)
                query = query.Where(product => product.BrandId == brand_id).ToList();
            return query.ToDTO();
        }

        public ProductDTO GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO GetСategoriesById(int id)
        {
            throw new NotImplementedException();
        }

        public BrandDTO GetBrandsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
