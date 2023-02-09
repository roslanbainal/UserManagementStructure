using Microsoft.AspNetCore.Mvc;
using UserManagement.Interfaces;

namespace UserManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticateService _authService;

        public AccountController(IAuthenticateService authService)
        {
            _authService = authService;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
