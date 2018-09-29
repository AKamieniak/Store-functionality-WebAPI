using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Models;
using WebApiCore.Repository;

namespace WebApiCore.Controllers
{
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        // GET api/employees/get-last-index 
        /// <summary>
        /// Get last index of employee.
        /// </summary>
        [Route("get-last-index")]
        [HttpGet]
        public int GetLastIndexOfEmployee() 
        {
            //---get last index of employee---
            return _employeesRepository.GetLastIndexOfEmployee();
        }

        // GET api/employees/get-by-shop-id/{0}
        /// <summary>
        /// Get employees with same shop ID.
        /// </summary>
        [Route("get-by-shop-id/{id}")]
        [HttpGet]
        public List<Employee> GetEmployeesByShopId(int id)
        {
            return _employeesRepository.GetEmployeesByShopId(id);
        }

        // POST api/employees/add
        /// <summary>
        /// Add an employee.
        /// </summary>
        [Route("add")]
        [HttpPost]
        public void AddEmployee([FromBody]Employee employee)
        {
            _employeesRepository.AddEmployee(employee);
        }

        // DELETE api/employees/delete/{0}
        /// <summary>
        /// Deletes an employee by ID.
        /// </summary>
        [Route("delete/{id}")]
        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            _employeesRepository.DeleteEmployee(id);
        }
    }
}
