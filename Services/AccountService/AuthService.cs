using LearningManagement.Entities;
using LearningManagement.Models.AccountVM;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearningManagement.Services.AccountService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<(int, string)> Login(LoginVM model)
        {
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser == null)
            {
                return (0, "Email or password is incorrect!");
            }
            var result = await _signInManager.PasswordSignInAsync(existingUser, model.Password, false, false);
            if (!result.Succeeded)
            {
                return (0, "Email or password is incorrect!");
            }

            return (1, "User logged in!");
        }
        public async Task<(int, string)> Register(RegisterVM model)
        {
            var existingUser = await _userManager.FindByNameAsync(model.Name);
            if (existingUser != null)
            {
                return (0, "User already exists!");
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
                return (0, "User creation failed! Please check user details and try again.");
            }

            return (1, "User created successfully!");
        }
    }
}
