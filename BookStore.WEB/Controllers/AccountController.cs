using BookStore.BLL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using BookStore.BLL.DTO;
using BookStore.WEB.ViewModels;
using BookStore.BLL.Infrastructure;
using System.Threading.Tasks;

namespace BookStore.WEB.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public IUserService UserService;

        public AccountController(IUserService service)
        {
            UserService = service;
        }
        //private IUserService UserService
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().GetUserManager<IUserService>();
        //    }
        //}

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO {Email = viewModel.Email, Password = viewModel.Password};
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if(claim==null)
                    ModelState.AddModelError("","Неверный логин или пароль");
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    },claim);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(viewModel);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel viewModel)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO user = new UserDTO
                {
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    Role = "user"
                    
                };
                OperationDetails operationDetails = await UserService.Create(user);
                
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }

            return View(viewModel);
        }
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "ad46D_ewr3",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }

    }
}