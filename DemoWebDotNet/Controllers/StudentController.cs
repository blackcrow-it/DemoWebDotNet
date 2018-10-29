using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebDotNet.Controllers
{
    public class StudentController : Controller
    {

        [HttpGet("/create")]
        public IActionResult CreateStudent()
        {
            return View();
        }
    }
}