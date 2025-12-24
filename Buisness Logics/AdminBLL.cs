using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ClaimApplication.Data_Access;

namespace ClaimApplication.Buisness_Logics
{
    public class AdminBLL
    {
        private AdminDAL dal  = new AdminDAL();

        public DataTable Login(string username, string password)
        {
            return dal.AdminLogin(username, password); // returns DataTable from SP_Admin
        }


    }
}