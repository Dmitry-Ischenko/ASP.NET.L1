using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog() => View();

        public IActionResult Blog_single() => View();

        public IActionResult Cart() => View();

        public IActionResult Contact() => View();

        public IActionResult Product() => View();

        public IActionResult Regular() => View();

        public IActionResult Shop() => View();
    }
}
