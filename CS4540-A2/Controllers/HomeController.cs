using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS4540_A2.Models;

namespace CS4540_A2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Course")]
        public IActionResult Course()
        {
            return View("Course");
        }

        [Route("DCV")]
        public IActionResult DCV()
        {
            return View("DCV");
        }

        [Route("Admin")]
        public IActionResult Admin()
        {
            return View("Admin");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
