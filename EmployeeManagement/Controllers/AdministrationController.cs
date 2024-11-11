using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel input)
        {
            IdentityRole newRole = new IdentityRole() 
            {
                Name = input.RoleName,
            };

            var result = await _roleManager.CreateAsync(newRole);

            if (!result.Succeeded) 
                throw new Exception("Failed to create role.");
            
            return Ok(new {success = true});
        }
    }
}