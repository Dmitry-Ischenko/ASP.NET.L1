using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;

namespace Webstore.Services.Mapping
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToDTO(this Category Category) => Category is null ? null
            : new CategoryDTO
            {
                Id = Category.Id,
                 Name = Category.Name,
                  Order = Category.Order,
                   ParentId = Category.ParentId,
                    ProductsCount = Category.Products.Count()
            };
        public static Category FromDTO(this CategoryDTO Category) => Category is null ? null
            : new Category
            {
                 Id = Category.Id,
                  Name = Category.Name,
                   Order = Category.Order,
                    ParentId = Category.ParentId
            };
        public static IEnumerable<CategoryDTO> ToDTO(this IEnumerable<Category> Categories) => Categories.Select(ToDTO);

        public static IEnumerable<Category> FromDTO(this IEnumerable<CategoryDTO> Categories) => Categories.Select(FromDTO);
    }
}
