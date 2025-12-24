using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClaimApplication.Data_Access
{
    public class AdminDAL
    {
        public DataTable AdminLogin(string username, string password)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Action", "Login"),
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            return DbConnection.ExecuteDataTable("SP_Admin",param);
        }
    }
}