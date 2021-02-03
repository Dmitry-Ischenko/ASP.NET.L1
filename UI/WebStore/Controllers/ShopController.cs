using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Domain;
using WebStore.Domain.ViewModels;
using WebStore.Domain.Entities;
using Webstore.Interfaces.Services;
using Webstore.Services.Mapping;

namespace WebStore.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductData _ProductData;

        public ShopController(IProductData ProductData) => _ProductData = ProductData;
        public IActionResult Index(int? BrandId, int? CategoryID)
        {
            var filter = new ProductFilter
            {
                BrandId = BrandId,
                СategoryId = CategoryID,

            };
            var productc = _ProductData.GetProducts(filter).FromDTO();
            var brends = _ProductData.GetBrands().FromDTO();
            var categories = _ProductData.GetСategories().FromDTO();
            



            return View(new ShopViewModel
            {
                Products = productc,
                Brands = brends,
                Categories = Categories(categories),
            });
        }

        private IEnumerable<CategoriesViewModel> Categories(IEnumerable<Category> Icategories)
        {
            var categories = Icategories;

            var parrent_categories = categories.Where(s => s.ParentId is null);

            var parrent_categories_views = parrent_categories
                .Select(s => new CategoriesViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Order = s.Order,
                }).ToList();
            foreach (var item in parrent_categories_views)
            {
                var childs = categories.Where(s => s.ParentId == item.Id);
                foreach (var child in childs)
                {
                    item.CildCategory.Add(new CategoriesViewModel
                    {
                        Id = child.Id,
                        Name = child.Name,
                        Order = child.Order,
                        ParentCategory = item
                    });
                }
                item.CildCategory.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order));
            }
            parrent_categories_views.Sort((a, b) => Comparer<int>.Default.Compare(a.Order, b.Order));

            return parrent_categories_views;
        }
        public IActionResult Product(int id)
        {
            var product = _ProductData.GetProductById(id).FromDTO();
            if (product is null)
                return NotFound();
            return View(product.ToView());
        }
    }
}
