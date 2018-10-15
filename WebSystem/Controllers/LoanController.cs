using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSystem.Controllers
{
    public class LoanController : Controller
    {
        // GET: Loan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoanType()
        {
            return View();
        }

        public ActionResult Guarantor()
        {
            return View();
        }

        public ActionResult LoanSummary()
        {
            return View();
        }
    }
}