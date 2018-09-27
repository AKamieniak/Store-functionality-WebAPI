using System.Collections.Generic;
using WebApiCore.Models;

namespace WebApiCore.Repository
{
    public interface IEmployeesRepository
    {
        //---interface of EmployeesRepository methods---

        List<Employee> GetEmployeesByShopId(int shopId);
        List<Employee> GetEmployeesByPositionId(int positionId);
        int GetLastIndexOfEmployee();
        void AddEmployee(Employee employee);
        void DeleteEmployee(int id);
        
    }
}