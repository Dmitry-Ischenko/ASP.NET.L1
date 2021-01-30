using System.Collections.Generic;
using WebStore.Domain;
using WebStore.Domain.Entities;

namespace Webstore.Interfaces.Services
{
    public interface IProductData
    {
        IEnumerable<Category> GetСategories();

        Category GetСategoriesById(int id);

        IEnumerable<Brand> GetBrands();
        
        Brand GetBrandsById(int id);

        IEnumerable<Product> GetProducts(ProductFilter Filter = null);

        Product GetProductById(int id);
    }
}
