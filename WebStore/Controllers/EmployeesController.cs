using Microsoft.AspNetCore.Http;
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
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            var employees = _db.Employees.FirstOrDefault(item => item.Id == id);
            if (employees is not null)
            {
                _db.Employees.Remove(employees);
                return RedirectToAction(nameof(Employees));
            }
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult SaveChangeEmployee(int id, string FirstName, string LastName, int Age)
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
        /// <summary>
        /// Оставлю здесь, вариант нарушающий подход CRUD-интерфейса
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SaveOrDelete(IFormCollection form)
        {
            if (form.TryGetValue("id",out var idStr))
            {
                if (Int32.TryParse(idStr,out int id))
                {
                    var employee = _db.Employees.FirstOrDefault(item => item.Id == id);
                    if (employee is not null)
                    {
                        if (form.ContainsKey("save"))
                        {
                            form.TryGetValue("FirstName", out var FirstName);
                            form.TryGetValue("LastName", out var LastName);
                            form.TryGetValue("Age", out var AgeStr);
                            Int32.TryParse(AgeStr, out var Age);
                            if (!employee.FirstName.Equals(FirstName))
                                employee.FirstName = FirstName;
                            if (!employee.LastName.Equals(FirstName))
                                employee.LastName = LastName;
                            if (employee.Age != Age)
                                employee.Age = Age;
                            return RedirectToAction(nameof(Employees));
                        }
                        if (form.ContainsKey("del"))
                        {
                            _db.Employees.Remove(employee);
                            return RedirectToAction(nameof(Employees));
                        }
                    }
                }
            }
            
            return NotFound();
        }
    }
}
