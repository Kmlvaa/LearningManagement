using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
