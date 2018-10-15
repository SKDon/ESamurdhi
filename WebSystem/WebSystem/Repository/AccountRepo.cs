using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSystem.BLL;
using WebSystem.Models;
using WebSystem.ViewModel;

namespace WebSystem.Repository
{
    public class AccountRepo
    {
        ESamurdhiEntities db = new ESamurdhiEntities();

        // Create a new Account
        public void createNewAccount(string accno,string fullname,string address,string nic,
            string opendate,string bank,string dob,string ocup,int? refperid,string memid)
        {
            var account = new AccountProfile
            {
                AccNo = accno,
                FullName = fullname,
                Address = address,
                NIC = nic,
                AccOpenDate = opendate,
                Bank = bank,
                DOB = dob,
                Occupation = ocup,
                ReferancePersonID = refperid,
                MemberID = memid
            };
            db.AccountProfiles.Add(account);
            db.SaveChanges();

        }

        // Update an existing Account

            public void updateAccount(string accno, string fullname, string address, string nic,
            string opendate, string bank, string dob, string ocup, int? refperid, string memid)
        {
            var upquery = db.AccountProfiles.Where(acc => acc.AccNo == accno).FirstOrDefault();

            upquery.FullName = fullname;
            upquery.Address = address;
            upquery.NIC = nic;
            upquery.AccOpenDate = opendate;
            upquery.Bank = bank;
            upquery.DOB = dob;
            upquery.Occupation = ocup;
            upquery.ReferancePersonID = refperid;
            upquery.MemberID = memid;
            db.Entry(upquery).State = System.Data.Entity.EntityState.Modified;
            try
            {
                db.SaveChanges();
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }


        }
        //for BLL
        public string getAccNo(string accno)
        {
            var no = (from x in db.AccountProfiles where x.AccNo.Equals(accno) select x.AccNo).FirstOrDefault();
            return no;
        }

        // reference person id is foreign key so it needs to validate
        public int getRefPid(int? refid)
        {
            var id = (from x in db.AccRefPersons where x.ReferancePersonID.Equals(refid) select x.ReferancePersonID).FirstOrDefault();
            return id;
           
        }
        // for autocomplete Json
        public dynamic getAccno(string prefix)
        {
            var accno = (from x in db.AccountProfiles where x.AccNo.Contains(prefix) select x.AccNo);
            return accno;
        }

        public dynamic accountDetails(string accountno)//
        {
            var details = (from x in db.AccountProfiles where x.AccNo.Equals(accountno) select 
                           new { Accno = x.AccNo,
                               Name =x.FullName,
                               Addres =x.Address,
                               nic =x.NIC,
                               AOdate =x.AccOpenDate,
                               bank =x.Bank,
                               dob =x.DOB,
                               ocup =x.Occupation,
                               refP =x.ReferancePersonID,
                               memId =x.MemberID
                           });
            return details;
        }
    }
}