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
    public class AccountController: Controller
    {
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // Get user
            
            // Validate Password

            //Sign In

            return View(model);
        }
    }
}
