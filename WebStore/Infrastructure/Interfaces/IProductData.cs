using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entityes;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Сategory> GetСategories();

        IEnumerable<Brand> GetBrands();

        IEnumerable<Product> GetProducts();
    }
}
