using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace ClaimApplication.Data_Access
{
    public class CLaimDAL
    {
        public int InsertClaim(int empId, string type, decimal amount, string remarks, DateTime claimDate, string proofPath)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Action", "INSERT"),
                new SqlParameter("@EmpId", empId),
                new SqlParameter("@ClaimType", type),
                new SqlParameter("@ClaimAmount", amount),
                new SqlParameter("@Remarks", remarks),
                 new SqlParameter("@ClaimDate", claimDate),
                new SqlParameter("@ProofDocument", string.IsNullOrEmpty(proofPath) ? (object)DBNull.Value : proofPath)
            };
            return DbConnection.ExecuteNonQuery("SP_Claim", param);
        }

        public DataTable GEtAllClaims()
        {
            SqlParameter[] param = { new SqlParameter("@Action", "SELECTALL") };
            return DbConnection.ExecuteDataTable("SP_Claim", param);
        }

        public DataTable GetClaimByEmployee(int empId)
        {
            SqlParameter[] param = {
                new SqlParameter("@Action","SELECTBYEMP"),
                new SqlParameter("@EmpId",empId)
            };
            return DbConnection.ExecuteDataTable("SP_Claim", param);
        }


        public int ApproveClaim(int claimId)
        {
            SqlParameter[] param =
            {
        new SqlParameter("@Action", "APPROVE_UPDATE"),
        new SqlParameter("@ClaimId", claimId)
    };

            try
            {
                return DbConnection.ExecuteNonQuery("SP_Claim", param);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }





        public int RejectClaim(int claimId)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@Action", "REJECT"),
                new SqlParameter("ClaimId", claimId)
            };
            return DbConnection.ExecuteNonQuery("SP_Claim", param) ;    
        }

        public DataTable GetReportByPeriod(DateTime from, DateTime to)
        {
            SqlParameter[] param =
            {
                new SqlParameter("Action", "REPORTbyPERIOD"),
                new SqlParameter("@FromDate", from),
                new SqlParameter("@ToDate", to)
            };
            return DbConnection.ExecuteDataTable("SP_Claim", param);
        }

        public DataTable GetClaimCounts()
        {
            SqlParameter[] param = { new SqlParameter("@Action", "COUNTBYSTATUS") };
            return DbConnection.ExecuteDataTable("SP_Claim", param);
        }


        public DataTable GetClaimsByStatus(string status)
        {
            SqlParameter[] param = {
        new SqlParameter("@Action", "SELECTBYSTATUS"),
        new SqlParameter("@Status", status)
    };
            return DbConnection.ExecuteDataTable("SP_Claim", param);
        }

        public DataTable GetPendingClaims()
        { 
            SqlParameter[] param = {
        new SqlParameter("@Action", "SELECTBYSTATUS"),
        new SqlParameter("@Status", DBNull.Value) // NULL = pending
    };
            return DbConnection.ExecuteDataTable("SP_Claim", param);
        }

        public DataTable GetClaimCountsByEmployee(int empId)
        {
            SqlParameter[] param = {
                new SqlParameter("@Action", "COUNTBYSTATUSBYEMP"),
                new SqlParameter("@EmpId", empId)
            };
            return DbConnection.ExecuteDataTable("SP_Claim", param);
        }


        public DataTable GetEmployeeBalanceByClaimId(int claimId)
        {
            SqlParameter[] param = {
        new SqlParameter("@Action", "GETBALANCEBYCLAIMID"),
        new SqlParameter("@ClaimId", claimId)
    };
            return DbConnection.ExecuteDataTable("SP_Claim", param);
        }



        public int ResetEmployeeLimits()
        {
            SqlParameter[] param = {
        new SqlParameter("@Action", "RESETLIMITS")
    };
            return DbConnection.ExecuteNonQuery("SP_Employee", param);
        }





    }
}