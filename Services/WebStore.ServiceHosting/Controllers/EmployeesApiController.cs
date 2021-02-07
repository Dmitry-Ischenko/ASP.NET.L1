using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.Interfaces;
using Webstore.Interfaces.Services;
using WebStore.Domain.Models;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebAPI.Employees)]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _db;
        private readonly ILogger<EmployeesApiController> _Logger;

        public EmployeesApiController(IEmployeesData db, ILogger<EmployeesApiController> Logger)
        {
            _db = db;
            _Logger = Logger;
        }

        [HttpPost]
        public int Add(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                _Logger.LogWarning("Ошибка модели данных при добавлении нового сотрудника {0} {1}",
                    employee.LastName, employee.FirstName);
                return 0;
            }
            _Logger.LogInformation("Добавление сотрудника {0} {1}",
                employee.LastName, employee.FirstName);
            var id = _db.Add(employee);
            if (id > 0)
                _Logger.LogInformation("Cотрудник [id:{0}] {1} {2} добавлен успешно",
                    employee.Id, employee.LastName, employee.FirstName);
            else
                _Logger.LogWarning("Ошибка при добавлении сотрудника {0} {1}",
                    employee.LastName, employee.FirstName);
            return id;
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {

            var result = _db.Delete(id);
            if (result)
                _Logger.LogInformation("Сотрудник с id:{0} успешно удалён", id);
            else
                _Logger.LogWarning("ошибка при попытке удаления сотрдуника с id:{0}", id);

            return result;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _db.Get();
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _db.Get(id);
        }

        [HttpPut]
        public void Update(Employee employee)
        {
            _db.Update(employee);
        }
    }
}
