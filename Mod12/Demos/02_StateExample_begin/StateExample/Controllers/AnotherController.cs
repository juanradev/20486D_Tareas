using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace StateExample.Controllers
{
    public class AnotherController : Controller
    {
        public IActionResult Index()
        {
            int? overallVisitsNumber = HttpContext.Session.GetInt32("Overall")??0;
            int? controllerVisitsNumber = HttpContext.Session.GetInt32("Another")??0;
            overallVisitsNumber++;
            controllerVisitsNumber++;
 
            HttpContext.Session.SetInt32("Overall", overallVisitsNumber.Value);
            HttpContext.Session.SetInt32("Another", controllerVisitsNumber.Value);

            return View();
        }
    }
}