using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services.EmployeeRepo
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployeeList();
        Employee GetEmployeeById(int id);
    }
}