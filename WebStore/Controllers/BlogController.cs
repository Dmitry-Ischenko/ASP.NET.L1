using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogsData _db;
        public BlogController(IBlogsData db) => _db = db;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlogPost(int id)
        {
            var blog = _db.Get(id);
            if (blog is not null) 
                return View(_db.Get(id));
            else
                return RedirectToAction(nameof(Index));
        }
    }
}
