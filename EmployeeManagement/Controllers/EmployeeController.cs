using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.Services.EmployeeRepo;
using EmployeeManagement.Contracts.Request;

namespace EmployeeManagement.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
    {
        _employeeService = employeeService;
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        List<Employee> model = _employeeService.GetEmployeeList();
        return View(model);
    }

    public IActionResult Details(int id)
    {
        Employee employee = _employeeService.GetEmployeeById(id);

        if(employee == null)
            return BadRequest();
        
        return View(employee);
    }

    [HttpGet]
    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Employee input) 
    {
        if(input == null || string.IsNullOrWhiteSpace(input.Name) || string.IsNullOrWhiteSpace(input.Email) || input.Name.Length > 10)
            return View();

        var newEmployee = _employeeService.CreateEmployee(input);

        return RedirectToAction("details", new {id = newEmployee.Id});
    }

    [HttpPost]
    public IActionResult Delete(int id) 
    {
        Debug.WriteLine("inside");
        Employee employee = _employeeService.GetEmployeeById(id);

        if (employee != null)
            _employeeService.Delete(id);
        
        return RedirectToAction("index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
