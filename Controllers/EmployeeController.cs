using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeApp.Models;
using DAL;
using DBMan;

namespace EmployeeApp.Controllers;

public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ShowEmployee()
    {
        List<Employee> emp = EmployeeAccess.GetAllEmployee();
        ViewData["catalog"]=emp;
        return View();
    }


}
