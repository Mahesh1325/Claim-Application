using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ClaimApplication.Data_Access;

namespace ClaimApplication.Buisness_Logics
{
    public class EmployeeBLL
    {
        private EmployeeDAL dal = new EmployeeDAL();

       public DataTable Login(string email, string password)
    {
        return dal.EmployeeLogin(email, password);
    }

        public DataTable GetAllEmployees()
        {
            return dal.GetAllEmployees();
        }

        public int AddEmployee(string name, string email,  string password, string mobile, decimal AL, decimal SL)
        {
            return dal.InsertEmployee(name, email, password, mobile, AL, SL);  
        }


        public DataTable GetEmployeeById(int empId)
        {
            DataTable dt = dal.GetEmployeeById(empId);
            if (dt == null || dt.Rows.Count == 0)
                throw new Exception("Employee record not found!");
            return dt;
        }

        public DataTable GetEmployeeBalance(int empId)
        {
            return dal.GetEmployeeBalance(empId);
        }

        public DataTable GetEmployeeByEmail(string email)
        {
            return dal.GetEmployeeByEmail(email);
        }


    }
}