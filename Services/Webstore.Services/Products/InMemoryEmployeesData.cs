using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.Interfaces.Services;
using WebStore.Domain.Models;
using Webstore.Services.Data;

namespace Webstore.Services.Products
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private List<Employee> _Employees = TestDB.Employees.ToList();


        public int Add(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));

            if (_Employees.Contains(employee))
                return employee.Id;
            employee.Id = _Employees
                .Select(item => item.Id)
                .DefaultIfEmpty()
                .Max() + 1;
            _Employees.Add(employee);

            return employee.Id;
        }

        public bool Delete(int id)
        {
            var item = Get(id);
            if (item is null) return false;
            return _Employees.Remove(item);
        }

        public IEnumerable<Employee> Get()
        {
            return _Employees;
        }

        public Employee Get(int id)
        {
            return _Employees.FirstOrDefault(item => item.Id == id);
        }

        public void Update(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));
            if (_Employees.Contains(employee))
                return;
            var item = Get(employee.Id);
            if (item is null)
                return;
            item.LastName = employee.LastName;
            item.FirstName = employee.FirstName;
            item.Age = employee.Age;
        }
    }
}
