using ClaimApplication.Buisness_Logics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ClaimApplication.Features_pages_.Admin
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        EmployeeBLL empBLL = new EmployeeBLL();
        ClaimBLL claimBLL = new ClaimBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
                Response.Redirect("~/Features(pages)/Login.aspx");

            if (!IsPostBack)
                LoadDashboardCounts();
        }

        private void LoadDashboardCounts()
        {
            try
            {
                // --- Total Employees ---
                DataTable empDt = empBLL.GetAllEmployees();
                lblTotalEmployees.InnerText = empDt.Rows.Count.ToString();

                // --- Claim Counts ---
                DataTable claimCountsDt = claimBLL.GetClaimCounts(); // DAL returns PendingCount, ApprovedCount, RejectedCount
                if (claimCountsDt.Rows.Count > 0)
                {
                    DataRow row = claimCountsDt.Rows[0];

                    lblPendingClaims.InnerText = row["PendingCount"] != DBNull.Value ? row["PendingCount"].ToString() : "0";
                    lblApprovedClaims.InnerText = row["ApprovedCount"] != DBNull.Value ? row["ApprovedCount"].ToString() : "0";
                    lblRejectedClaims.InnerText = row["RejectedCount"] != DBNull.Value ? row["RejectedCount"].ToString() : "0";
                }
                else
                {
                    lblPendingClaims.InnerText = "0";
                    lblApprovedClaims.InnerText = "0";
                    lblRejectedClaims.InnerText = "0";
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error loading dashboard: " + ex.Message + "');</script>");
            }
        }
    }
}