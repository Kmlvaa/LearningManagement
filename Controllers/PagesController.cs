using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        public IActionResult Team()
        {
            return View();
        }
        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult Testimonial()
        {
            return View();
        }
    }
}
