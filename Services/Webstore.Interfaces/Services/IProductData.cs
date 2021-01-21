using System.Collections.Generic;
using WebStore.Domain;
using WebStore.Domain.Entities;

namespace Webstore.Interfaces.Services
{
    public interface IProductData
    {
        IEnumerable<Category> GetСategories();

        IEnumerable<Brand> GetBrands();

        IEnumerable<Product> GetProducts(ProductFilter Filter = null);

        Product GetProductById(int id);
    }
}
