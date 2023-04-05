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
using EtwLogin.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;


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
            Boolean issucess = false;
            var issuccess = _service.AuthenticateUser(username, Password);

            if(username==null)
            {
                return View();
            }
            if (issuccess.Result != null)
            {
                string name = HttpContext.Session.GetString(username);
                TempData["Key"] = username;
                return RedirectToAction("Department");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", username);
                return Json(new { Message = ViewBag.username, System.Web.Mvc.JsonRequestBehavior.AllowGet });
            }
           
        }

        public ActionResult Welcome()
        {

            var data = TempData["Key"];
            TempData.Keep("Key");
            return View();
        }
        public ViewResult Department()
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
