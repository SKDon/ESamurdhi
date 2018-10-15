using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSystem.Repository;

namespace WebSystem.BLL
{
    public class TransactionBLL
    {
        TransactionRepo repo = new TransactionRepo();
        
        public bool validTransaction(int tno,int lno)
        {
            if (repo.getLoanNo(lno) != 0)
            {
                if (repo.getTransNo(tno) != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            else
            {
                return false;
            }
            //if (repo.trans(tno, lno) == null)
            //        {
            //            return true;
            //        }
            //        else
            //        {
            //            return false;
            //        }
                //if (repo.getTransNo(tno) != null && repo.getLoanNo(lno) != null)
                //{
                //    return false;
                //}
                //else
                //{
                //    return true;
                //}
        }
    }
}