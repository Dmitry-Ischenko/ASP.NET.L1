﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels.Base;

namespace WebStore.Domain.ViewModels
{
    public class ShopViewModel : ViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<Brand> Brands { get; set; }

        public IEnumerable<CategoriesViewModel> Categories { get; set; }
    }
}
