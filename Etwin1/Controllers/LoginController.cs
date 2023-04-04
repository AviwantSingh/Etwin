using Etwin.BAL.Services;
using EtwLogin.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

using System.Web;
namespace Etwin1.Controllers
{
    public class LoginController : Controller
    {
        public readonly AuthenticationService _service;
        const string userName = "_UserName";

        public LoginController(AuthenticationService service) 
        {
        _service= service;
        }    
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
       
        public ActionResult Loginview(string username, string Password)
        {
            var issuccess = _service.AuthenticateUser(username, Password);

            if(username==null)
            {
                return View();
            }
            if (issuccess.Result != null)
            {
                string name = HttpContext.Session.GetString(username);
                //ViewBag.username = string.Format("Successfully logged-in", username);

                //TempData["username"] = username;
                //TempData["TempModel"] = "test";
                TempData["Key"] = username;
                //ViewBag.issuccess = issuccess;
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", username);
               
                return View("Loginview");
            }
           
        }

        public ActionResult Welcome()
        {

            var data = TempData["Key"];
            TempData.Keep("Key");
            return View();
        }
        public ActionResult Department()
        {

            var data = TempData["Key"];
            TempData.Keep("Key");
            return View();
        }
        public ActionResult PasswordRecovery()
        {
            return View();
        }
    }
}
