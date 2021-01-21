using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.ViewModels;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _CartService;

        public CartController(ICartService CartService)
        {
            _CartService = CartService;
        }

        public IActionResult AddToCart(int id)
        {
            _CartService.AddToCart(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Index()
        {
            return View(_CartService.TransformFromCart());
        }

        public IActionResult RemoveFromCart(int id)
        {
            _CartService.RemoveFromCart(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DecrementFromCart(int id)
        {
            _CartService.DecrementFromCart(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Clear()
        {
            _CartService.Clear();
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public IActionResult CheckOut()
        {
            return View(new CartOrderViewModel {Cart= _CartService.TransformFromCart() });
        }
        [Authorize,HttpPost]
        public async Task<IActionResult> CheckOut(OrderViewModel OrderModel, [FromServices] IOrderService OrderService)
        {
            if (!ModelState.IsValid)
                return View(nameof(CheckOut), new CartOrderViewModel
                {
                    Cart = _CartService.TransformFromCart(),
                    Order = OrderModel
                });

            var order = await OrderService.CreateOrder(
                User.Identity!.Name,
                _CartService.TransformFromCart(),
                OrderModel);

            _CartService.Clear();

            return RedirectToAction("OrderConfirmed", new { order.Id });
        }

        public IActionResult OrderConfirmed(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }
    }
}
