using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcKoncept.Models;
using EcKoncept.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcKoncept.Controllers
{
    public class HomeController : Controller
    {
        private IContactManager _contactManager;

        public HomeController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        [HttpPost]
        public IActionResult Contactus(ContactUs contact)
        {
            if (ModelState.IsValid)
            {
                _contactManager.AddContact(contact);
                return Content("Done");
            }
            string name = contact.Name;
            return Content(name);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }

       public IActionResult Portraits()
        {
            return View();
        }


        public IActionResult PrintPub()
        {
            return View();
        }

        public IActionResult Makeup()
        {
            return View();
        }

        public IActionResult Event()
        {
            return View();
        }

        public IActionResult Photography()
        {
            return View();
        }

        public IActionResult Street()
        {
            return View();
        }

        public IActionResult Contactus()
        {   
            return View();
        }

       
        public IActionResult Aboutus()
        {
            return View();
        }

        public IActionResult Career()
        {
            return View();
        }

        public IActionResult Videography()
        {
            return View();
        }

        public IActionResult Graphics()
        {
            return View();
        }

        public IActionResult Branding()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult BlogPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Subcribe(string name, string email)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("index");
            }
            return View();
        }
    }
}