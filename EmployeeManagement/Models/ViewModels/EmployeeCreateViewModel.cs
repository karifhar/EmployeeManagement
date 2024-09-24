using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Contracts.Enums;

namespace EmployeeManagement.Models.ViewModels
{
    public class EmployeeCreateViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DepartementEnum Departement { get; set; }
        public GenderEnum Gender { get; set; }
        public IFormFile PhotoPath { get; set; }
    }
}