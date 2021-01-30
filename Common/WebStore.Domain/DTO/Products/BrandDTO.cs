using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;

namespace WebStore.Domain.DTO.Products
{
    public class BrandDTO: NamedEntity
    {
        public int Order { get; set; }

        public int ProductsCount { get; set; }
    }
}
