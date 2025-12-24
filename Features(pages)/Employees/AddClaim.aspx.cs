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
    public partial class AddClaim : System.Web.UI.Page
    {
        ClaimBLL claimBLL = new ClaimBLL();
        EmployeeBLL empBLL = new EmployeeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Employee"] == null)
                Response.Redirect("EmployeeLogin.aspx");

            if (!IsPostBack)
            {
                txtClaimDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void rblClaimType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show proof upload only for AL
            pnlProof.Visible = (rblClaimType.SelectedValue == "AL");
        }

        protected void btnSubmitClaim_Click(object sender, EventArgs e)
        {
            try
            {
                int empId = Convert.ToInt32(Session["Employee"]);
                string category = ddlCategory.SelectedValue;
                string type = rblClaimType.SelectedValue; // AL or SL
                string claimType = $"{category}-{type}";
                decimal amount = Convert.ToDecimal(txtClaimAmount.Text.Trim());
                DateTime claimDate = Convert.ToDateTime(txtClaimDate.Text.Trim());
                string remarks = txtRemarks.Text.Trim();
                string proofPath = "";

                // ✅ Proof mandatory check for AL only
                if (type == "AL")
                {
                    if (!fuProof.HasFile)
                    {
                        lblMessage.CssClass = "text-danger";
                        lblMessage.Text = "⚠️ Proof document is required for AL claim!";
                        return;
                    }

                    // Save proof file safely
                    string folder = Server.MapPath("~/Documents/");
                    if (!System.IO.Directory.Exists(folder))
                        System.IO.Directory.CreateDirectory(folder);

                    string fileName = Guid.NewGuid().ToString() + "_" + fuProof.FileName;
                    string fullPath = System.IO.Path.Combine(folder, fileName);
                    fuProof.SaveAs(fullPath);
                    proofPath = "~/Documents/" + fileName;
                }

                // --- FETCH CURRENT REMAINING LIMITS ---
                DataTable dtEmp = empBLL.GetEmployeeById(empId);
                if (dtEmp.Rows.Count == 0)
                {
                    lblMessage.CssClass = "text-danger";
                    lblMessage.Text = "⚠️ Employee not found!";
                    return;
                }

                decimal remainingAL = dtEmp.Rows[0]["Remaining_AL"] != DBNull.Value
                    ? Convert.ToDecimal(dtEmp.Rows[0]["Remaining_AL"])
                    : Convert.ToDecimal(dtEmp.Rows[0]["ClaimLimit_AL"]);

                decimal remainingSL = dtEmp.Rows[0]["Remaining_SL"] != DBNull.Value
                    ? Convert.ToDecimal(dtEmp.Rows[0]["Remaining_SL"])
                    : Convert.ToDecimal(dtEmp.Rows[0]["ClaimLimit_SL"]);

                decimal remaining = (type == "AL") ? remainingAL : remainingSL;

                // --- VALIDATE CLAIM AMOUNT ---
                if (amount > remaining)
                {
                    lblMessage.CssClass = "text-danger";
                    lblMessage.Text = $"⚠️ Cannot apply claim! Remaining {(type == "AL" ? "AL" : "SL")} balance is {remaining:C2}.";
                    return;
                }

                // --- INSERT CLAIM RECORD ---
                int result = claimBLL.SubmitClaim(empId, claimType, amount, remarks, claimDate, proofPath);

                if (result > 0)
                {
                    lblMessage.CssClass = "text-success";
                    lblMessage.Text = "✅ Claim submitted successfully!";
                    ClearFields();
                }
                else
                {
                    lblMessage.CssClass = "text-danger";
                    lblMessage.Text = "❌ Failed to submit claim.";
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
            ddlCategory.SelectedIndex = 0;
            rblClaimType.ClearSelection();
            pnlProof.Visible = false;
            txtClaimAmount.Text = "";
            txtRemarks.Text = "";
            txtClaimDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}