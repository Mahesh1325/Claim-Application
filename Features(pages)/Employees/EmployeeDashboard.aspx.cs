
using ClaimApplication.Buisness_Logics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimApplication.Features_pages_.Employees
{
    public partial class EmployeeDashboard : System.Web.UI.Page
    {
        ClaimBLL claimBLL = new ClaimBLL();
        EmployeeBLL empBLL = new EmployeeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Employee"] == null)
                Response.Redirect("~/Features(pages)/Login.aspx");

            if (!IsPostBack)
                LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                int empId = Convert.ToInt32(Session["Employee"]);
                string empName = Session["EmpName"].ToString();
                lblEmpName.Text = empName;

                // 1️⃣ Get claim counts
                DataTable dtClaims = claimBLL.GetClaimCountsByEmployee(empId);
                if (dtClaims.Rows.Count > 0)
                {
                    lblTotalClaims.InnerText = dtClaims.Rows[0]["TotalClaims"].ToString();
                    lblPendingClaims.InnerText = dtClaims.Rows[0]["PendingCount"].ToString();
                    lblApprovedClaims.InnerText = dtClaims.Rows[0]["ApprovedCount"].ToString();
                    lblRejectedClaims.InnerText = dtClaims.Rows[0]["RejectedCount"].ToString();
                }

                // 2️⃣ Get remaining balance
                DataTable dtBalance = empBLL.GetEmployeeBalance(empId);
                if (dtBalance.Rows.Count > 0)
                {
                    decimal remainingAL = dtBalance.Rows[0]["Remaining_AL"] != DBNull.Value
                         ? Convert.ToDecimal(dtBalance.Rows[0]["Remaining_AL"])
                         : Convert.ToDecimal(dtBalance.Rows[0]["ClaimLimit_AL"]);

                    decimal remainingSL = dtBalance.Rows[0]["Remaining_SL"] != DBNull.Value
                        ? Convert.ToDecimal(dtBalance.Rows[0]["Remaining_SL"])
                        : Convert.ToDecimal(dtBalance.Rows[0]["ClaimLimit_SL"]);

                    decimal AlocLimitAL = Convert.ToDecimal(dtBalance.Rows[0]["ClaimLimit_AL"]);
                    decimal AlocLimitSL = Convert.ToDecimal(dtBalance.Rows[0]["ClaimLimit_SL"]);

                    lblRemainingAL.InnerText = remainingAL.ToString("0.00");
                    lblRemainingSL.InnerText = remainingSL.ToString("0.00");
                    lblAlocLimitAL.InnerText = AlocLimitAL.ToString("0.00");
                    lblAlocLimitSL.InnerText = AlocLimitSL.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
    }
}
