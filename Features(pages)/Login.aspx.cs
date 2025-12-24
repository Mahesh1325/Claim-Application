using ClaimApplication.Buisness_Logics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimApplication.Features_pages_
{
    public partial class Login : System.Web.UI.Page
    {
        AdminBLL adminBLL = new AdminBLL();
        EmployeeBLL empBLL = new EmployeeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                Session.Clear();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = rblRole.SelectedValue;

            if (role == "Admin")
            {
                DataTable dt = adminBLL.Login(user, password);
                if (dt != null && dt.Rows.Count > 0)
                {
                    Session["Admin"] = dt.Rows[0]["Username"];
                    Session["AdminId"] = dt.Rows[0]["AdminId"];
                    Response.Redirect("Admin/AdminDashboard.aspx");
                }
                else
                {
                    lblMsg.Text = "Invalid Admin credentials!";
                }
            }
            else 
            {
                DataTable dt = empBLL.Login(user, password);
                if (dt != null && dt.Rows.Count > 0)
                {
                    Session["Employee"] = dt.Rows[0]["EmpId"];
                    Session["EmpName"] = dt.Rows[0]["EmpName"];
                    Response.Redirect("Employees/EmployeeDashboard.aspx");
                }
                else
                {
                    lblMsg.Text = "Invalid Employee credentials!";
                }
            }
        }
    }
}