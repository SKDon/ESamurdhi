using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSystem.Models;

namespace WebSystem.Repository
{
    public class CustomerRepo
    {
        ESamurdhiEntities db = new ESamurdhiEntities();
       // reference Person 
       public void insertRefPerson(string name,string adrs,string bank,int accno)
        {
            var refP = new AccRefPerson { FullName = name, Address = adrs, AccNo = accno, Bank = bank };


            db.AccRefPersons.Add(refP);
            db.SaveChanges();
        }


        public string getRefPName(string name)
        {
            var refPname = (from  x in db.AccRefPersons where x.FullName.Equals(name) select x.FullName).FirstOrDefault();
            return refPname;
        }


        public void updateRefPerson(string name, string adrs, string bank, int accno)
        {
            var query = db.AccRefPersons.Where(FName => FName.FullName == name).FirstOrDefault();
            query.Address = adrs;
            query.Bank = bank;
            query.AccNo = accno;
            db.Entry(query).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();


        }

        public dynamic getNames(string prefix)
        {
            var name = (from x in db.AccRefPersons where x.FullName.Contains(prefix) select x.FullName);

            return name;
        }

        public dynamic getDetails(string name)
        {
            var details = (from x in db.AccRefPersons where x.FullName.Equals(name) select x).ToList();
            return details;
        }
    }
}