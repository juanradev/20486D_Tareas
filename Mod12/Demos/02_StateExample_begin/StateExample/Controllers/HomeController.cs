using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace StateExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int? overallVisitsNumber = HttpContext.Session.GetInt32("Overall") ?? 0;
            int? controllerVisitsNumber = HttpContext.Session.GetInt32("Home") ?? 0;
            int? AnotherControllerVisitsNumber = HttpContext.Session.GetInt32("Another")??0;
 
                overallVisitsNumber++;
 
                controllerVisitsNumber++;
            HttpContext.Session.SetInt32("Overall", overallVisitsNumber.Value);
            HttpContext.Session.SetInt32("Home", controllerVisitsNumber.Value);
            HttpContext.Session.SetInt32("Another", AnotherControllerVisitsNumber.Value);
            return View();
        }
    }
}