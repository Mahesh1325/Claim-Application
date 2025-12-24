using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ClaimApplication.Data_Access
{
    public class DbConnection
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["ClaimAppDB"].ConnectionString;

    
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(connStr);
        }

        public static DataTable ExecuteDataTable(string spName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(spName, conn)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }

            }
        }



        public static int ExecuteNonQuery(string spName, params SqlParameter[] parameters)
        {
            using(SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(spName, conn))
                {
                    cmd.CommandType= CommandType.StoredProcedure;
                    if(parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();

                    return cmd.ExecuteNonQuery();
                }
            }
        }

  }
}