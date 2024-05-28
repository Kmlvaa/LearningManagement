using LearningManagement.Entities;
using LearningManagement.Models.AccountVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser == null)
            {
                model.ErrorMessage = "Username or password is incorrect!";
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(existingUser, model.Password, false, false);
            if (!result.Succeeded)
            {
                model.ErrorMessage = "Username or password is incorrect!";
                return View(model);
            }

            if(model.Email == "admin@mail.ru" && model.Password == "admin123")
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
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
            if (!ModelState.IsValid) { return View(model); }

            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                model.ErrorMessage = "User already exists!";
                return View(model);
            }

            AppUser user = new AppUser()
            {
                Firstname = model.Name,
                Lastname = model.Surname,
                Email = model.Email,
                UserName = model.Username,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                model.ErrorMessage = string.Join(" ", result.Errors.Select(x => x.Description));
                return View(model);
            }

            return RedirectToAction("Login", "Account");
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
