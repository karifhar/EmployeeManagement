using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.Services.EmployeeRepo;
using EmployeeManagement.Contracts.Request;
using EmployeeManagement.Models.ViewModels;

namespace EmployeeManagement.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly ILogger<EmployeeController> _logger;
    private readonly IWebHostEnvironment _hostingEnv;

    public EmployeeController(ILogger<EmployeeController> logger, 
        IEmployeeService employeeService, 
        IWebHostEnvironment environment)
    {
        _employeeService = employeeService;
        _logger = logger;
        _hostingEnv = environment;
    }
    
    public IActionResult Index()
    {
        List<Employee> model = _employeeService.GetEmployeeList();
        return View(model);
    }

    public IActionResult Details(int id)
    {
        Employee employee = _employeeService.GetEmployeeById(id);
        return View(employee);
    }

    [HttpGet]
    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public IActionResult Create(EmployeeCreateViewModel input) 
    {
        if(input == null || string.IsNullOrWhiteSpace(input.Name) || string.IsNullOrWhiteSpace(input.Email) || input.Name.Length > 10)
            return View();
            
        string uniqueFileName = ProceedUploadPhotoFile(input);

        Employee newEmployeeData = new Employee() 
        {
            Name = input.Name,
            Email = input.Email,
            Departement = input.Departement,
            Gender = input.Gender,
            PhotoPath = uniqueFileName,
        };

        var newEmployee = _employeeService.CreateEmployee(newEmployeeData);

        return RedirectToAction("details", new {id = newEmployee.Id});
    }

    [HttpPost]
    public IActionResult Delete(int id) 
    {
        Employee employee = _employeeService.GetEmployeeById(id);

        if (employee != null)
            _employeeService.Delete(id);
        
        return RedirectToAction("index");
    }

    [HttpGet]
    public IActionResult Edit(int id) 
    {
        Employee employee = _employeeService.GetEmployeeById(id);

        EmployeeEditViewModel model = new EmployeeEditViewModel() 
        {
            Id = employee.Id,
            Name = employee.Name,
            Departement = employee.Departement,
            Email = employee.Email,
            Gender = employee.Gender,
            ExistingPhotoPath = employee.PhotoPath
        };
        return View(model);
        
    }

    [HttpPost]
    public IActionResult Edit(EmployeeEditViewModel input)
    {
        Employee employee = _employeeService.GetEmployeeById(input.Id);
        employee.Name = input.Name;
        employee.Departement = employee.Departement;
        employee.Email = employee.Email;
        employee.Gender = employee.Gender;
        employee.PhotoPath = ProceedUploadPhotoFile(input);

        _employeeService.Update(employee);
        return RedirectToAction("details", new { id = employee.Id });
    }

    private string ProceedUploadPhotoFile(EmployeeCreateViewModel input)
    {
        string uniqueFileName = string.Empty;

        if (input.PhotoPath != null)
        {
            string uploadFolder = Path.Combine(_hostingEnv.WebRootPath, "img");
            uniqueFileName = Guid.NewGuid().ToString() + input.PhotoPath.FileName;
            string filePath = Path.Combine(uploadFolder, uniqueFileName);
            input.PhotoPath.CopyTo(new FileStream(filePath, FileMode.Create));
        }

        return uniqueFileName;
    }
}
