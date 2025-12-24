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
    public partial class AddEmployee : System.Web.UI.Page
    {
        EmployeeBLL empBLL = new EmployeeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("AdminLogin.aspx");
            }
        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();
                string mobile = txtMobile.Text.Trim();
                decimal claimAL = Convert.ToDecimal(txtClaimAL.Text.Trim());
                decimal claimSL = Convert.ToDecimal(txtClaimSL.Text.Trim());

                // Check if email already exists
                DataTable dtCheck = empBLL.GetEmployeeByEmail(email);
                if (dtCheck != null && dtCheck.Rows.Count > 0)
                {
                    lblMessage.CssClass = "text-danger";
                    lblMessage.Text = "❌ Email already exists! Please use a different email.";
                    return; // stop further execution
                }

                // Add new employee
                int result = empBLL.AddEmployee(name, email, password, mobile, claimAL, claimSL);

                if (result > 0)
                {
                    lblMessage.CssClass = "text-success";
                    lblMessage.Text = "✅ Employee added successfully!";
                    ClearFields();
                }
                else
                {
                    lblMessage.CssClass = "text-danger";
                    lblMessage.Text = "❌ Failed to add employee.";
                }
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "⚠️ Error: " + ex.Message;
            }
        }

        private void ClearFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtMobile.Text = "";
            txtClaimAL.Text = "";
            txtClaimSL.Text = "";
        }
    }
}