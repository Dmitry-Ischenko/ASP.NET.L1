using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Mapping
{
    public static class ProductMapper
    {
        public static ProductViewModel ToView(this Product p) => new()
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
    }
}
