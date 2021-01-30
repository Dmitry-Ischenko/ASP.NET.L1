using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Webstore.Interfaces.Services;
using WebStore.Client.Base;
using WebStore.Domain.Models;

namespace WebStore.Client.Employees
{
    public class EmployeesClient: BaseClient, IEmployeesData
    {
        private readonly ILogger<EmployeesClient> logger;

        public EmployeesClient(IConfiguration Configuration, ILogger<EmployeesClient> Logger): base(Configuration, "api/employees")
        {
            logger = Logger;
        }

        public int Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
