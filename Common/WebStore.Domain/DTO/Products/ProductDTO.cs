using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.DTO.Products
{
    public class ProductDTO: NamedEntity
    {
        public int Order { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public BrandDTO Brand { get; set; }
        public CategoryDTO Category { get; set; }
        public string Description { get; set; }
        public int Discount { get; set; }

    }
}
