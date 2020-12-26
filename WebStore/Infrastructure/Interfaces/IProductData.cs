using System.Collections.Generic;
using WebStore.Domain;
using WebStore.Domain.Entities;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Category> GetСategories();

        IEnumerable<Brand> GetBrands();

        IEnumerable<Product> GetProducts(ProductFilter Filter = null);

        Product GetProductById(int id);
    }
}
