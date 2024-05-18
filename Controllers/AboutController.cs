using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
