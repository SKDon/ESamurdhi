using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSystem.Repository;
using WebSystem.ViewModel;
using WebSystem.BLL;

namespace WebSystem.Controllers
{
    public class AccountController : Controller
    {
        AccountRepo repo = new AccountRepo();
        AccountBLL bll = new AccountBLL();
        // GET: Account
        public ActionResult Index()
        {
            return View("Account");
        }

        [HttpPost]
        public ActionResult NewAccount(AccountVM account)
        {
            string accno = account.Accpro.AccNo;
            string fullname = account.Accpro.FullName;
            string address = account.Accpro.Address;
            string nic = account.Accpro.NIC;
            string opendate = account.Accpro.AccOpenDate;
            string bank = account.Accpro.Bank;
            string dob = account.Accpro.DOB;
            string ocup = account.Accpro.Occupation;
            int? refperid = account.Accpro.ReferancePersonID;
            string memid = account.Accpro.MemberID;
            
                if (bll.isAcountExist(account.Accpro.AccNo) == true)
            {
                repo.createNewAccount(accno, fullname, address, nic, opendate, bank, dob, ocup, refperid, memid);
            }
            else
            {
                repo.updateAccount(accno, fullname, address, nic, opendate, bank, dob, ocup, refperid, memid);
            }

            return View("Account");
        }

        [HttpPost]
        public JsonResult getAccNo(string prefix)
        {
            var accno = repo.getAccno(prefix);
            return Json(accno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getAccountDetails(string accountNo)
        {
            var details = repo.accountDetails(accountNo);
            return Json(details, JsonRequestBehavior.AllowGet);
        }

        public ActionResult show()
        {
            return View();
        }

        public ActionResult show2()
        {
            return View();
        }
    }
}