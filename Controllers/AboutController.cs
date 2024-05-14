using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
