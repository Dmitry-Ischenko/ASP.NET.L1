using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Webstore.Interfaces;
using Webstore.Interfaces.Services;
using WebStore.Client.Base;
using WebStore.Domain;
using WebStore.Domain.DTO.Products;

namespace WebStore.Client.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(IConfiguration Configuration) : base(Configuration, WebAPI.Products)
        {
        }

        public IEnumerable<BrandDTO> GetBrands()
        {
            return Get<IEnumerable<BrandDTO>>($"{Address}/brands");
        }

        public BrandDTO GetBrandsById(int id)
        {
            return Get<BrandDTO>($"{Address}/brands/{id}");
        }

        public ProductDTO GetProductById(int id)
        {
            return Get<ProductDTO>($"{Address}/{id}");
        }

        public IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null)
        {
            return Post(Address, Filter ?? new ProductFilter())
                .Content
                .ReadAsAsync<IEnumerable<ProductDTO>>()
                .Result;
        }

        public IEnumerable<CategoryDTO> GetСategories()
        {
            return Get<IEnumerable<CategoryDTO>>($"{Address}/categories");
        }

        public CategoryDTO GetСategoriesById(int id)
        {
            return Get<CategoryDTO>($"{Address}/categories/{id}");
        }
    }
}
