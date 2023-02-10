using Microsoft.AspNetCore.Identity;
using UserManagement.Common.Enums;
using UserManagement.Interfaces;
using UserManagement.Models.Entities;
using UserManagement.Models.ViewModels.AuthenticateViewModels;

namespace UserManagement.Services
{
    //Simple method/api using identity
    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthenticateStatus> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                return AuthenticateStatus.NotRegistered;
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return AuthenticateStatus.Success;
            }

            return AuthenticateStatus.Failure;
        }

        public async Task<AuthenticateStatus> Register(RegisterViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null) return AuthenticateStatus.NotRegistered;

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                return AuthenticateStatus.Success;
            }

            return AuthenticateStatus.Failure;
        }

        public async Task<AuthenticateResponse> ChangePassword(ChangePasswordViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
            if (user is null) return new AuthenticateResponse { Status = AuthenticateStatus.NotRegistered, Message = AuthenticateResponse.Messages.NotRegistered, Errors = null };

            var result = await _userManager.ChangePasswordAsync(user, model.Password, model.ConfirmPassword);
            return result.Succeeded
                ? new AuthenticateResponse { Status = AuthenticateStatus.Success, Message = AuthenticateResponse.Messages.UpdatePasswordSucceeded, Errors = null }
                : new AuthenticateResponse { Status = AuthenticateStatus.Failure, Message = AuthenticateResponse.Messages.PasswordCriteria, Errors = result.Errors.Select(x => x.Description).ToList() };
        }



    }
}
