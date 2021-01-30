using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.Interfaces.Services;
using WebStore.Domain;
using WebStore.Domain.Entities;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductData
    {
        private readonly IProductData _db;
        private readonly ILogger<ProductsApiController> _Logger;

        public ProductsApiController(IProductData db, ILogger<ProductsApiController> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        [HttpGet("brands")]
        public IEnumerable<Brand> GetBrands()
        {
            return _db.GetBrands();
        }

        [HttpGet("brands/{id}")]
        public Brand GetBrandsById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return _db.GetProductById(id);
        }

        
        [HttpPost]
        public IEnumerable<Product> GetProducts([FromBody]ProductFilter Filter = null)
        {
            return _db.GetProducts(Filter);
        }

        [HttpGet("categories")]
        public IEnumerable<Category> GetСategories()
        {
            return _db.GetСategories();
        }

        [HttpGet("categories/{id}")]
        public Category GetСategoriesById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
