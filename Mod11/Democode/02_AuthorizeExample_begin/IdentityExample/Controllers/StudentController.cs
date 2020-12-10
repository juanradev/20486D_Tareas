using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using IdentityExample.Data;

namespace IdentityExample.Controllers
{
    public class StudentController : Controller
    {


        private StudentContext _studentContext;

        public StudentController(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            /*
             * No lo necetitamos porque ya se encarga [Authorize]
             if (!this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            */

            return View();
        }
        [AllowAnonymous]
        public IActionResult CourseDetails()
        {
            return View(_studentContext.Courses.ToList());
        }
    }
}