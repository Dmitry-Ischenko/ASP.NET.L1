using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Service;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestDB _db;
        public HomeController(TestDB db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Employees()
        {
            return View(_db.Employees);
        }
    }
}
