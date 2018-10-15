using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSystem.Repository;
using WebSystem.BLL;
using WebSystem.ViewModel;

namespace WebSystem.Controllers
{
    public class TransactionController : Controller
    {
        TransactionRepo repo = new TransactionRepo();
        TransactionBLL bll = new TransactionBLL();
        
        // GET: Transaction
        public ActionResult Index()
        {
            return View("Transaction");
        }

        public ActionResult NewTransaction(TransactionVM transactionVM)
        {
            
            int lno = transactionVM.transaction.LoanNo;
            string month = transactionVM.transaction.Month;
            double amount = transactionVM.transaction.PaidAmount;
            string pdate = transactionVM.transaction.PaidDate;
            int transn = transactionVM.transaction.TransactionNo;

            if (bll.validTransaction(transn,lno) == true)
            {
                repo.newTransaction(lno, month, amount, pdate, transn);
                return View("Transaction");
            }
            else
            {
                return View("Error");
            }
            
            
        }
        [HttpPost]
        public JsonResult transactionDetails(int loanNo)
        {
            var details = repo.getDetails(loanNo);
            return Json(details, JsonRequestBehavior.AllowGet);
        }
    }
}