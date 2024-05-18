using LearningManagement.Models.AccountVM;

namespace LearningManagement.Services.AccountService
{
    public interface IAuthService
    {
        Task<(int, string)> Login(LoginVM model);
        Task<(int, string)> Register(RegisterVM model);
    }
}
