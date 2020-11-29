﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            var employees = _db.Employees.FirstOrDefault(item => item.Id == id);
            if (employees is not null)
            {
                _db.Employees.Remove(employees);
                return RedirectToAction(nameof(Index));
            }                
            else
                return NotFound();
        }
        public IActionResult Details(int id)
        {
            var employees = _db.Employees.FirstOrDefault(item => item.Id == id);
            if (employees is not null)
                return View(employees);
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Details(int id,string FirstName,string LastName,int Age)
        {                        
            var employees = _db.Employees.FirstOrDefault(item => item.Id == id);
            if (employees is not null)
            {
                if (!employees.FirstName.Equals(FirstName))
                    employees.FirstName = FirstName;
                if (!employees.LastName.Equals(FirstName))
                    employees.LastName = LastName;
                if (employees.Age != Age)
                    employees.Age = Age;
                return View(employees);
            }                
            else
                return NotFound();
        }
    }
}
