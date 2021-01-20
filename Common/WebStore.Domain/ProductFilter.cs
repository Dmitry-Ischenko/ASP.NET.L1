using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain
{
    public class ProductFilter
    {
        public int? СategoryId { get; set; }

        public int? BrandId { get; set; }

        public int[] Ids { get; set; }
    }
}
