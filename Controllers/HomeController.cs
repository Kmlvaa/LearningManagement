using LearningManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearningManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
