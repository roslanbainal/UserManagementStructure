using UserManagement.Common.Enums;
using UserManagement.Models.ViewModels.AuthenticateViewModels;

namespace UserManagement.Interfaces
{
    public interface IAuthenticateService
    {
        Task<AuthenticateResponse> ChangePassword(ChangePasswordViewModel model);
        Task<AuthenticateStatus> Login(LoginViewModel model);
        Task<AuthenticateStatus> Register(RegisterViewModel model);
    }
}
