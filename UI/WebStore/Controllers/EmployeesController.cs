using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.Service;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _db;
        public EmployeesController(IEmployeesData db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Get());
        }
        public IActionResult Details(int id)
        {
            var employees = _db.Get(id);
            if (employees is not null)
                return View(new EmployeesViewModel { 
                    Id = employees.Id,
                     Age = employees.Age,
                      FirstName = employees.FirstName,
                       LastName = employees.FirstName,
                });
            else
                return NotFound();
        }
        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult DeleteEmployee(int id)
        {
            if (_db.Delete(id)) 
                return RedirectToAction(nameof(Index));
            else
                return NotFound();
        }
        public IActionResult NewEmployee()
        {
            return View("Details", new EmployeesViewModel());
        }
        [HttpPost]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult SaveChangeEmployee(EmployeesViewModel Model)
        {
            if (Model is null)
                throw new ArgumentNullException(nameof(Model));
            var employee = new Employee
            {
                Id = Model.Id,
                FirstName = Model.FirstName,
                LastName = Model.LastName,
                Age = Model.Age,
            };

            if (employee.Id == 0)
                _db.Add(employee);
            else
                _db.Update(employee);
            return RedirectToAction(nameof(Index));
        }        
    }
}
