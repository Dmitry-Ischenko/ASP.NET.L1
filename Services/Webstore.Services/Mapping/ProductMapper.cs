using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels;

namespace Webstore.Services.Mapping
{
    public static class ProductMapper
    {
        public static ProductViewModel ToView(this Product p) => new ProductViewModel()
        {
            Id = p.Id,
            Brand = p.Brand,
            BrandId = p.BrandId,
            Category = p.Category,
            CategoryId = p.CategoryId,
            Description = p.Description,
            Discount = p.Discount,
            ImageUrl = p.ImageUrl,
            Name = p.Name,
            Order = p.Order,
            Price = p.Price           
        };

        public static IEnumerable<ProductViewModel> ToView(this IEnumerable<Product> p) => p.Select(ToView);

        public static ProductDTO ToDTO(this Product product) => product is null ? null
            : new ProductDTO 
            { 
                 Id = product.Id,
                 Name = product.Name,
                  Order = product.Order,
                   Price = product.Price,
                    ImageUrl = product.ImageUrl,
                     Brand = product.Brand.ToDTO(),
                     Category = product.Category.ToDTO(),
                      Description = product.Description,
                       Discount = product.Discount
            };

        public static Product FromDTO(this ProductDTO Product) => Product is null ? null
            : new Product
            {
                Id = Product.Id,
                 Name = Product.Name,
                  Order = Product.Order,
                   Price = Product.Price,
                    ImageUrl = Product.ImageUrl,
                     Description = Product.Description,
                      Discount = Product.Discount,
                       Brand = Product.Brand.FromDTO(),
                       Category = Product.Category.FromDTO(),
                        BrandId = Product.Brand.Id,
                        CategoryId = Product.Category.Id
                     
            };
        public static IEnumerable<ProductDTO> ToDTO(this IEnumerable<Product> products) => products.Select(ToDTO);

        public static IEnumerable<Product> FromDTO(this IEnumerable<ProductDTO> products) => products.Select(FromDTO);
    }
}
