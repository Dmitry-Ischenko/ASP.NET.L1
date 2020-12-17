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

        public IEnumerable<Brand> GetBrands()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetСategories() => _db.Categories.Include(category => category.Products);
    }
}
