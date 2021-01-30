using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.Interfaces.Services;
using WebStore.Domain.Models;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _db;

        public EmployeesApiController(IEmployeesData db)
        {
            _db = db;
        }

        [HttpPost]
        public int Add(Employee employee)
        {
            return _db.Add(employee);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _db.Delete(id);
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
