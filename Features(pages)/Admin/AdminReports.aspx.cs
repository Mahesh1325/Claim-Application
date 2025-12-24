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
    public partial class AdminReports : System.Web.UI.Page
    {
        ClaimBLL claimBLL = new ClaimBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
                Response.Redirect("Login.aspx");
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
                DateTime toDate = Convert.ToDateTime(txtToDate.Text);

                DataTable dt = claimBLL.GetReportByPeriod(fromDate, toDate);

                if (dt.Rows.Count > 0)
                {
                    gvReport.DataSource = dt;
                    gvReport.DataBind();
                    lblMessage.Text = "";
                }
                else
                {
                    gvReport.DataSource = null;
                    gvReport.DataBind();
                    lblMessage.Text = "⚠️ No records found for the selected period.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "⚠️ Error: " + ex.Message;
            }
        }
    }
}