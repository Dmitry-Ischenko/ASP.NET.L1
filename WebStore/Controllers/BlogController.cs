using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogsData _db;
        public BlogController(IBlogsData db) => _db = db;
        public IActionResult Index()
        {
            var blogs = _db.Get();
            return View(new BlogsViewModel { 
                Blogs = blogs,
            });
        }

        public IActionResult BlogPost(int id)
        {
            var blog = _db.Get(id);
            if (blog is not null)
            {
                List<BlogPost> Blogs = new List<BlogPost>();
                int count = 1;
                foreach (var item in _db.Get())
                {
                    Blogs.Add(item);
                    count++;
                    if (count >= 4) break;
                }
                return View(new BlogSingelPostViewModel { 
                Blog= blog,
                Blogs = Blogs,
                });
            }                
            else
                return RedirectToAction(nameof(Index));
        }
    }
}
