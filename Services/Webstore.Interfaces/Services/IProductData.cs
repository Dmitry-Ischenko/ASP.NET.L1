using System.Collections.Generic;
using WebStore.Domain;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;

namespace Webstore.Interfaces.Services
{
    public interface IProductData
    {
        IEnumerable<CategoryDTO> GetСategories();

        CategoryDTO GetСategoriesById(int id);

        IEnumerable<BrandDTO> GetBrands();
        
        BrandDTO GetBrandsById(int id);

        IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null);

        ProductDTO GetProductById(int id);
    }
}
