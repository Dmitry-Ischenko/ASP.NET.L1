using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.ViewModels;
using Webstore.Interfaces.Services;

namespace WebStore.Components
{
    public class CategoriesViewComponent: ViewComponent
    {
        private readonly IProductData _ProductData;

        public CategoriesViewComponent(IProductData ProductData) => _ProductData = ProductData;

        public IViewComponentResult Invoke()
        {
            var categories = _ProductData.GetСategories().ToArray();

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

            return View(parrent_categories_views);
        }
    }
}
