using Microsoft.AspNetCore.Mvc;
using VirtualStore.Web.Core.ViewModels;
using VirtualStore.Web.Core.Services.Interfaces;

namespace VirtualStore.Web.Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityManagementService _identityManagementService;

        public AccountController(IIdentityManagementService identityManagementService)
        {
            _identityManagementService = identityManagementService;
        }

        [HttpGet]
        public async Task<IActionResult> Login() 
            => await Task.FromResult(View());

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Login(user)
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult Signin()
        {
            return View();
        }
    }
}
