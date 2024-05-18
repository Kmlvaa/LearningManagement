using LearningManagement.Entities;
using LearningManagement.Models.AccountVM;
using LearningManagement.Services.AccountService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(IAuthService authService, SignInManager<AppUser> signInManager)
        {
            _authService = authService;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var (status, message) = await _authService.Login(model);
            if (status == 0)
            {
                return BadRequest(message);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid) { return BadRequest(model); }

            var (status, message) = await _authService.Register(model);
            if (status == 0)
            {
                return BadRequest(message);
            }
            return Ok(message);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
