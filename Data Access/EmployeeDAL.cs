using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ClaimApplication.Data_Access
{
    public class EmployeeDAL
    {
        public int InsertEmployee(string name, string email, string password, string mobileNo, decimal AL, decimal SL)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Action", "INSERT"),
                new SqlParameter("@EmpName", name),
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password),
                new SqlParameter("@MobileNo", mobileNo),
                new SqlParameter("@ClaimLimit_AL", AL),
                new SqlParameter("@ClaimLimit_SL", SL)
            };
            return DbConnection.ExecuteNonQuery("SP_Employee", param);
        }

        public DataTable EmployeeLogin(string email, string password)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Action", "LOGIN"),
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password)
            };
            return DbConnection.ExecuteDataTable("SP_Employee", param);
        }

        public DataTable GetAllEmployees()
        {
            SqlParameter[] param = { new SqlParameter("@Action", "SELECTALL") };
            return DbConnection.ExecuteDataTable("SP_Employee", param);
        }

        public DataTable GetEmployeeById(int empId)
        {
            SqlParameter[] param = { 
                new SqlParameter("@Action", "SELECTBYID"),
                new SqlParameter("@EmpId", empId)
            };
            DataTable dt =  DbConnection.ExecuteDataTable("SP_Employee", param);
            return dt ?? new DataTable();
        }

        public DataTable GetEmployeeBalance(int empId)
        {
            SqlParameter[] param = {
                new SqlParameter("@Action", "GETBALANCE"),
                new SqlParameter("@EmpId", empId)
            };
            return DbConnection.ExecuteDataTable("SP_Employee", param);
        }

        public DataTable GetEmployeeByEmail(string email)
        {
            SqlParameter[] param = {
        new SqlParameter("@Action", "SELECTBYEMAIL"),
        new SqlParameter("@Email", email)
    };
            return DbConnection.ExecuteDataTable("SP_Employee", param);
        }

    }

}