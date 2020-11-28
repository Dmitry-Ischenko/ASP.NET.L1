using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Service;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly TestDB _db;
        public EmployeesController(TestDB db)
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
        public IActionResult Details(int id)
        {
            var employees = _db.Employees.FirstOrDefault(item => item.Id == id);
            if (employees is not null)
                return View(employees);
            else
                return NotFound();
        }
    }
}
