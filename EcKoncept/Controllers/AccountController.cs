using EcKoncept.Models;
using EcKoncept.Models.Domain;
using EcKoncept.Models.View;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcKoncept.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Get user
            var user = await _signInManager.UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                TempData["error"] = "Invalid Email or Password";
                return View(model);
            }

            // Validate Password
            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (signInResult.Succeeded)
            {
                //Sign In
                await _signInManager.SignInAsync(user, model.RememberMe);
                if (Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("index", "home");
                }
            }
            else if (signInResult.IsLockedOut)
            {
                TempData["error"] = "You have been locked out";
            }
            else
            {
                TempData["error"] = "Invalid Email or Password";
            }
            return View(model);
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            var user = new User
            {
                Email = model.Email,
            };
            var createResult = await _signInManager.UserManager.CreateAsync(user);
            if (!createResult.Succeeded)
            {
                IEnumerable<string> errors = createResult.Errors.Select(e => e.Description);
                TempData["error"] = string.Join("", errors);
                return View(model);
            }

            var addPasswordResult = await _signInManager.UserManager.AddPasswordAsync(user, model.Password);
            if (!addPasswordResult.Succeeded)
            {
                IEnumerable<string> errors = createResult.Errors.Select(e => e.Description);
                TempData["error"] = string.Join("", errors);
                return View(model);
            }
            return Redirect("login");
        }
    }
}
