using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Components
{
    public class CartHeaderViewComponent : ViewComponent
    {
        private readonly ICartService _CartService;

        public CartHeaderViewComponent(ICartService CartService)
        {
            _CartService = CartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_CartService.TransformFromCart());
        }
    }
}
