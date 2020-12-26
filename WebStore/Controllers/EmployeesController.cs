using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.Service;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
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
        #region Получение коллекци из формы
        /// <summary>
        /// Оставлю здесь, вариант нарушающий подход CRUD-интерфейса
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        //[HttpPost]
        //public IActionResult SaveOrDelete(IFormCollection form)
        //{
        //    if (form.TryGetValue("id",out var idStr))
        //    {
        //        if (Int32.TryParse(idStr,out int id))
        //        {
        //            var employee = _db.Employees.FirstOrDefault(item => item.Id == id);
        //            if (employee is not null)
        //            {
        //                if (form.ContainsKey("save"))
        //                {
        //                    form.TryGetValue("FirstName", out var FirstName);
        //                    form.TryGetValue("LastName", out var LastName);
        //                    form.TryGetValue("Age", out var AgeStr);
        //                    Int32.TryParse(AgeStr, out var Age);
        //                    if (!employee.FirstName.Equals(FirstName))
        //                        employee.FirstName = FirstName;
        //                    if (!employee.LastName.Equals(FirstName))
        //                        employee.LastName = LastName;
        //                    if (employee.Age != Age)
        //                        employee.Age = Age;
        //                    return RedirectToAction(nameof(Employees));
        //                }
        //                if (form.ContainsKey("del"))
        //                {
        //                    _db.Employees.Remove(employee);
        //                    return RedirectToAction(nameof(Employees));
        //                }
        //            }
        //        }
        //    }

        //    return NotFound();
        //} 
        #endregion
    }
}
