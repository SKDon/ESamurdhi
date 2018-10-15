using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSystem.Repository;
using WebSystem.ViewModel;

namespace WebSystem.BLL
{
    public class AccountBLL
    {
        AccountRepo repo = new AccountRepo();

        public bool isAcountExist(string accno)
        {
            if (repo.getAccNo(accno) != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}