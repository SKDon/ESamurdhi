using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSystem.Repository;

namespace WebSystem.BLL
{
    public class CustomerBLL
    {
        CustomerRepo cRepo = new CustomerRepo();

        //check ref person availability
        public bool isRefpersonAvailable(string name)
        {
            if (cRepo.getRefPName(name)!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }


    }
}