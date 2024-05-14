using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Controllers
{
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
