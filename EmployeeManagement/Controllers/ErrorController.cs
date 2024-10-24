using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Controllers
{
    [Route("[controller]")]
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index() 
        {
            IExceptionHandlerPathFeature exceptionDetail = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exceptionDetail!.Path;
            ViewBag.ExceptionMessage =  exceptionDetail.Error.Message;
            ViewBag.StackTrace = exceptionDetail.Error.StackTrace;

            return View("Error");
        }

        [HttpGet("{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage =  "Sorry, The url could not be found";
                    break;
                case 405:
                    ViewBag.ErrorMessage =  "Sorry, you are fucked up";
                    break;
                default:
                    break;
            }
            return View("ErrorNotFoundPage");
        }

    }
}