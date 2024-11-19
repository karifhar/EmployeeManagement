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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public List<RoleViewModel> GetRolesList() 
        {
            List<RoleViewModel> result = new List<RoleViewModel>();
            var data = _roleManager.Roles.ToList();

            foreach (var item in data)
            {
                var role = new RoleViewModel();
                role.Id = item.Id;
#pragma warning disable CS8601 // Possible null reference assignment.
                role.RoleName = item.Name;
#pragma warning restore CS8601 // Possible null reference assignment.

                result.Add(role);
            }

            return result;
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id) 
        {
            IdentityRole roleData = await _roleManager.FindByIdAsync(id);

            if (roleData == null) 
            {
                return BadRequest($"Role with id : {id} is not found");
            }

            RoleViewModel model = new RoleViewModel();
            model.Id = roleData.Id;
#pragma warning disable CS8601 // Possible null reference assignment.
            model.RoleName = roleData.Name;
#pragma warning restore CS8601 // Possible null reference assignment.

            return View(model);
        }

        [HttpPut]
        public async Task<IActionResult> EditRole(RoleViewModel input) 
        {
            var roleData = await _roleManager.FindByIdAsync(input.Id);
            if (roleData == null)
                throw new ArgumentException("Id is not found");


            roleData.Name = input.RoleName;

            var result = await _roleManager.UpdateAsync(roleData);

            if (!result.Succeeded) {
                 return Ok(new {success = false});
            }

            return Ok(new {success = true, redirectUrl = "/administration/index"});
        }

    }
}