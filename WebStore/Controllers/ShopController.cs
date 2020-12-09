using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Domain;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductData _ProductData;

        public ShopController(IProductData ProductData) => _ProductData = ProductData;
        public IActionResult Index(int? BrandId, int? СategoryId)
        {
            var filter = new ProductFilter
            {
                BrandId = BrandId,
                СategoryId = СategoryId,

            };
            var productc = _ProductData.GetProducts(filter);
            var brends = _ProductData.GetBrands();
            var categories = _ProductData.GetСategories();

            return View(new ShopViewModel
            {
                Products = productc,
                Brands = brends,
                Сategories = categories,
            });
        }
        public IActionResult Product()
        {
            return View();
        }
    }
}
