using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entityes;
using WebStore.Infrastructure.Interfaces;
using WebStore.Service;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryProductsData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => TestDB.Brands;

        public IEnumerable<Сategory> GetСategories() => TestDB.Сategories;

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
