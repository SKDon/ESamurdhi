using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSystem.BLL;
using WebSystem.Repository;
using WebSystem.ViewModel;
using WebSystem.Models;

namespace WebSystem.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepo customerRepo = new CustomerRepo();
      
        CustomerBLL customerBLL = new CustomerBLL();
        
        // GET: Customer
        public ActionResult Index()
        {
            return View("RefPerson");
        }

        [HttpPost]
        public ActionResult NewRefPerson(CustomerVM refc)
        {
            string namei = refc.AccRef.FullName;//name to insert
            try
            {
                if (customerBLL.isRefpersonAvailable(namei) != true)
                {
                    customerRepo.insertRefPerson(refc.AccRef.FullName, refc.AccRef.Address, refc.AccRef.Bank, refc.AccRef.AccNo);
                    ViewBag.success = "Form Submission Success !";
                }
                else
                {
                    string nameu = refc.AccRef.FullName;
                    string bank = refc.AccRef.Bank;
                    string adrs = refc.AccRef.Address;
                    int accno = refc.AccRef.AccNo;

                    customerRepo.updateRefPerson(nameu, adrs, bank, accno);
                    ViewBag.update="Update Success !";
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult getName(string prefix)
        {
            var names = customerRepo.getNames(prefix);

           return Json(names,JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult getDetails(string name)
        {
            var details = customerRepo.getDetails(name);
            return Json(details, JsonRequestBehavior.AllowGet);
        }
       
  
    }
}