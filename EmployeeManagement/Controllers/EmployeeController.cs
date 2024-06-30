using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using EmployeeManagement.Services.EmployeeRepo;

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
