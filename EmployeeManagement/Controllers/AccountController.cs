using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel input) 
        {
            if(ModelState.IsValid) 
            {
                var user = new IdentityUser() {
                    UserName = input.Email,
                    Email = input.Email,
                };

                var result = await _userManager.CreateAsync(user, input.Password);

                if(result.Succeeded) 
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("index", "employee");
                } 
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                
            }

            return View(input);
        }

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel req) 
        {
            if(ModelState.IsValid) 
            {
                var result = await _signInManager.PasswordSignInAsync(req.Email, req.Password, false, false);

                if(!result.Succeeded) 
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Atempt");
                    return View();
                } 
                
            }
            return RedirectToAction("index", "employee");

        }

        [HttpPost]
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return Ok(new {success = true, redirectUrl = Url.Action("login", "account")});
        }
    }
}