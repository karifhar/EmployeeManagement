using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Contracts.Request;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services.EmployeeRepo
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployeeList();
        Employee GetEmployeeById(int id);
        Employee CreateEmployee(Employee input);
        Employee Update(Employee input);
        void Delete(int id);
    }
}