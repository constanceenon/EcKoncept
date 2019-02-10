using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcKoncept.Areas.AdminArea.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcKoncept.Areas.AdminArea.Controllers
{
    public class AccountController : Controller
    {
       // private SignManager _signManager;

        public AccountController(SignManager signManager)
        {
            //_signManager = signManager
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }



        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    //await _signManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}




        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }



        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //       //// var result = await _signManager.PasswordSignInAsync(model.Username,
        //       //    model.Password, model.RememberMe, false);

        //       // if (result.Succeeded)
        //       // {
        //       //     if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
        //       //     {
        //       //         return Redirect(model.ReturnUrl);
        //       //     }
        //       //     else
        //       //     {
        //       //         return RedirectToAction("Index", "Home");
        //       //     }
        //       // }
        //    }
        //    ModelState.AddModelError("", "Invalid login attempt");
        //    return View(model);
        //}
    }
}