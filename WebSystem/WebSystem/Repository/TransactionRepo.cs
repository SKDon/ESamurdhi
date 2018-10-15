using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSystem.Models;
namespace WebSystem.Repository
{
    public class TransactionRepo
    {
        ESamurdhiEntities db = new ESamurdhiEntities();

        public void newTransaction(int loanno,string month,double amount,string date,int transno)
        {
            var newTrans = new Transaction
            {
                LoanNo = loanno,
                Month = month,
                PaidAmount = amount,
                PaidDate = date,
                TransactionNo = transno
            };

            db.Transactions.Add(newTrans);
            db.SaveChanges();
        }

        public int? getTransNo(int tno)
        {
            var result = (from x in db.Transactions where x.TransactionNo==tno  select x.TransactionNo).FirstOrDefault();
            return result;
        }

        public int? getLoanNo(int lno)
        {
            var result = (from x in db.LoneLedgers where x.LoanNo==lno select x.LoanNo).FirstOrDefault();
            return result;
        }
       
        public dynamic getDetails(int lno)
        {
            var result = (from x in db.Transactions where x.LoanNo == lno select new {
                pDate = x.PaidDate,
                amount = x.PaidAmount,
                month = x.Month
            }).ToList();

            return result;
        }
    }
}