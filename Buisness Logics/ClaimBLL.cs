using ClaimApplication.Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;
using System.Xml;

namespace ClaimApplication.Buisness_Logics
{
    public class ClaimBLL
    {
        private CLaimDAL dal = new CLaimDAL();

        public int SubmitClaim(int empId, string type, decimal amount, string remarks, DateTime claimDate, string proofPath)
        {
            // Fetch current limits for the employee
            EmployeeBLL empBLL = new EmployeeBLL();
            DataTable dtEmp = empBLL.GetEmployeeById(empId);

            decimal remainingAL = dtEmp.Rows[0]["Remaining_AL"] != DBNull.Value
                ? Convert.ToDecimal(dtEmp.Rows[0]["Remaining_AL"])
                : Convert.ToDecimal(dtEmp.Rows[0]["ClaimLimit_AL"]);

            decimal remainingSL = dtEmp.Rows[0]["Remaining_SL"] != DBNull.Value
                ? Convert.ToDecimal(dtEmp.Rows[0]["Remaining_SL"])
                : Convert.ToDecimal(dtEmp.Rows[0]["ClaimLimit_SL"]);

            if (type.ToUpper() == "AL" && amount > remainingAL)
                throw new Exception("⚠️ Claim exceeds your remaining Allowance (AL) limit!");

            if (type.ToUpper() == "SL" && amount > remainingSL)
                throw new Exception("⚠️ Claim exceeds your remaining Standard (SL) limit!");

            return dal.InsertClaim(empId, type, amount, remarks, claimDate, proofPath);
        }


        public DataTable GetAllClaims()
        {
            return dal.GEtAllClaims();
        }

        public DataTable GetClaimByEmployee(int empId)
        {
            return dal.GetClaimByEmployee(empId);
        }

        public int ApproveClaim(int claimId)
        {
            return dal.ApproveClaim(claimId);
        }

        public int RejectClaim(int claimId)
        {
            return dal.RejectClaim(claimId);
        }

        public DataTable GetReportByPeriod(DateTime from, DateTime to)
        {
            return dal.GetReportByPeriod(from, to);
        }

        public DataTable GetClaimsByStatus(string status)
        {
            return dal.GetClaimsByStatus(status);
        }

        public DataTable GetClaimCounts()
        {
            return dal.GetClaimCounts();
        }

        public DataTable GetPendingClaims()
        {
            return dal.GetPendingClaims();
        }

        public DataTable GetClaimCountsByEmployee(int empId)
        {
            return dal.GetClaimCountsByEmployee(empId);
        }

        public DataTable GetEmployeeBalanceByClaimId(int claimId)
        {
            return dal.GetEmployeeBalanceByClaimId(claimId);
        }

        public void ResetEmployeeLimits()
        {
            dal.ResetEmployeeLimits();
        }


    }
}