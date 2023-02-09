using Microsoft.AspNetCore.Identity;
using UserManagement.Common.Enums;
using UserManagement.Data.Entities;
using UserManagement.Interfaces;
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

        public async Task<StatusEnum> Login(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                return StatusEnum.NotRegister;
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password,false, lockoutOnFailure:true);

            if (result.Succeeded)
            {
                return StatusEnum.Success;
            }

            return StatusEnum.Failed;
        }

        public async Task<StatusEnum> Register(RegisterViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user is null)
            {
                return StatusEnum.NotRegister;
            }

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                return StatusEnum.Success;
            }

            return StatusEnum.Failed;
        }

        public async Task<Tuple<StatusEnum, List<string>?>> ChangePassword(ChangePasswordViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());

            if(user is null)
            {
                return new Tuple<StatusEnum, List<string>?>(StatusEnum.NotRegister, null);
            }

            var result = await _userManager.ChangePasswordAsync(user, model.Password, model.ConfirmPassword);

            if (result.Succeeded)
            {
                return new Tuple<StatusEnum, List<string>?>(StatusEnum.Success, null);
            }

            return new Tuple<StatusEnum, List<string>?>(StatusEnum.NotRegister, result.Errors.Select(x => x.Description).ToList());
        }
    }
}
