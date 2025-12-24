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
    public partial class MyClaim : System.Web.UI.Page
    {
        ClaimBLL claimBLL = new ClaimBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Employee"] == null)
                Response.Redirect("EmployeeLogin.aspx");

            if (!IsPostBack)
            {
                LoadClaims();
            }
        }

        protected string GetStatusClass(object status)
        {
            if (status == DBNull.Value || status == null || string.IsNullOrEmpty(status.ToString()))
                return "badge-status badge-pending";
            string s = status.ToString();
            if (s == "Approved") return "badge-status badge-approved";
            if (s == "Rejected") return "badge-status badge-rejected";
            return "badge-status badge-pending";
        }


        protected string GetStatusText(object status)
        {
            if (status == DBNull.Value || status == null || string.IsNullOrEmpty(status.ToString()))
                return "Pending";
            return status.ToString();
        }

        private void LoadClaims()
        {
            int empId = Convert.ToInt32(Session["Employee"]);
            DataTable dt = claimBLL.GetClaimByEmployee(empId);
            gvMyClaims.DataSource = dt;
            gvMyClaims.DataBind();
        }
    }
}