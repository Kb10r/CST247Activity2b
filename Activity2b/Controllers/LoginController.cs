using Activity2b.Models;
using Activity2b.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Activity2b.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel userModel) 
        {
            SecurityService ss = new SecurityService();
            if (ss.isValid(userModel)) 
            {
                return View("LoginSuccess", userModel);
            }
            else 
            {
                return View("LoginFailure", userModel);
            }
        }
    }
}
