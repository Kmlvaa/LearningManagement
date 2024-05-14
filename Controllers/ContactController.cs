using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
