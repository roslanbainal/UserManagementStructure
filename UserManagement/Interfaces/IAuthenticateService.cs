using UserManagement.Common.Enums;
using UserManagement.Models.ViewModels.AuthenticateViewModels;

namespace UserManagement.Interfaces
{
    public interface IAuthenticateService
    {
        Task<Tuple<StatusEnum, List<string>?>> ChangePassword(ChangePasswordViewModel model);
        Task<StatusEnum> Login(LoginViewModel model);
        Task<StatusEnum> Register(RegisterViewModel model);
    }
}
