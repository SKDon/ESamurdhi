using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebSystem.ViewModel;

namespace WebSystem.Controllers
{
    public class AuthenticationController : Controller
    {
       

        // GET: Authentication
        public ActionResult Index()
        {
            return View("Index");
        }

        //[HttpPost]
        //public ActionResult Login(LoginVM l)
        //{
        //    //if (a.LoginBLL(l.LoginName, l.Password)==true)
        //    //{
        //    //    return View("Customer/Index");
                
        //    //}
        //    //else
        //    //{
        //    //    return View("Index");
        //    //}
        //}
    }
}