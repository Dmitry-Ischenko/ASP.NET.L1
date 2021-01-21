using Microsoft.AspNetCore.Mvc;
using Webstore.Interfaces.Services;

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
