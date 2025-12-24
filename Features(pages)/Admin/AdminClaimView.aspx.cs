using ClaimApplication.Buisness_Logics;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimApplication.Features_pages_.Admin
{
    public partial class AdminClaimView : System.Web.UI.Page
    {
        ClaimBLL claimBLL = new ClaimBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
                Response.Redirect("~/Features(pages)/Login.aspx");

            if (!IsPostBack)
            {
                string status = Request.QueryString["status"];
                if (!string.IsNullOrEmpty(status))
                {
                    LoadClaimsByStatus(status);
                    lblClaimTitle.InnerText = $"{status} Employee Claims";
                }
                else
                {
                    lblClaimTitle.InnerText = " Claims Requests";
                    LoadPendingClaims();
                }
            }
        }

        private void LoadClaims()
        {
            DataTable dt = claimBLL.GetAllClaims();
            gvClaims.DataSource = dt;
            gvClaims.DataBind();
        }

        private void LoadPendingClaims()
        {
            DataTable dt = claimBLL.GetPendingClaims();
            gvClaims.DataSource = dt;
            gvClaims.DataBind();
        }


        private void LoadClaimsByStatus(string status)
        {
            string dbStatus = status.Equals("Pending", StringComparison.OrdinalIgnoreCase) ? null : status;
            DataTable dt = claimBLL.GetClaimsByStatus(dbStatus);
            gvClaims.DataSource = dt;
            gvClaims.DataBind();
        }

        
        private void ShowProofModal(string proofPath)
        {
            if (!string.IsNullOrEmpty(proofPath))
            {
                if (proofPath.StartsWith("~"))
                    proofPath = proofPath.Substring(1);

                imgProof.ImageUrl = proofPath;
                lnkDownloadProof.NavigateUrl = proofPath;
                lnkDownloadProof.Attributes.Add("download", "");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowProofModal",
                    "$('#proofModal').modal('show');", true);
            }
        }

        protected string GetStatusBadgeText(object statusObj)
        {
            string status = statusObj?.ToString();

            if (string.IsNullOrEmpty(status))
            {
                return "<span class='badge-pending'>Pending</span>";
            }
            else if (status == "Approved")
            {
                return "<span class='badge-approved'>Approved</span>";
            }
            else if (status == "Rejected")
            {
                return "<span class='badge-rejected'>Rejected</span>";
            }
            else
            {
                return "<span>" + status + "</span>";
            }
        }



        protected void gvClaims_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Approve" || e.CommandName == "Reject")
                {
                    int claimId = Convert.ToInt32(e.CommandArgument);

                    if (e.CommandName == "Approve")
                    {
                        try
                        {
                            
                            DataTable dtBalance = claimBLL.GetEmployeeBalanceByClaimId(claimId);

                            if (dtBalance.Rows.Count > 0)
                            {
                                decimal remainingAL = Convert.ToDecimal(dtBalance.Rows[0]["Remaining_AL"]);
                                decimal remainingSL = Convert.ToDecimal(dtBalance.Rows[0]["Remaining_SL"]);
                                decimal claimAmount = Convert.ToDecimal(dtBalance.Rows[0]["ClaimAmount"]);
                                string claimType = dtBalance.Rows[0]["ClaimType"].ToString();

                                bool isAllowance = claimType.Contains("-AL");
                                bool isStandard = claimType.Contains("-SL");

                             
                                if ((isAllowance && remainingAL < claimAmount) ||
                                    (isStandard && remainingSL < claimAmount))
                                {
                                    lblMessage.CssClass = "text-danger fw-bold";
                                    lblMessage.Text = $"❌ Cannot approve Claim #{claimId}. Claim Limit Reached for Employee (ID:[{dtBalance.Rows[0]["EmpId"]}] {dtBalance.Rows[0]["EmpName"]}!";

                                    ViewState["LastEmpId"] = dtBalance.Rows[0]["EmpId"];
                                    ViewState["LastEmpName"] = dtBalance.Rows[0]["EmpName"].ToString();

                                    btnResetLimits.Visible = true;
                                    return;
                                }
                            }

                            claimBLL.ApproveClaim(claimId);

                            lblMessage.CssClass = "text-success";
                            lblMessage.Text = $"✅ Claim {claimId} approved successfully!";
                            btnResetLimits.Visible = false;
                        }
                        catch (Exception ex)
                        {
                            lblMessage.CssClass = "text-danger";
                            lblMessage.Text = $"❌ Cannot approve claim {claimId}: {ex.Message}";
                        }
                    }
                    else
                    {
                        claimBLL.RejectClaim(claimId);
                        lblMessage.CssClass = "text-danger";
                        lblMessage.Text = $"❌ Claim {claimId} rejected.";
                    }

                   
                    string statusFilter = Request.QueryString["status"];
                    if (!string.IsNullOrEmpty(statusFilter))
                        LoadClaimsByStatus(statusFilter);
                    else
                        LoadClaims();
                }
                else if (e.CommandName == "ViewProof")
                {
                    string proofPath = e.CommandArgument.ToString();
                    ShowProofModal(proofPath);
                }
                else if (e.CommandName == "DownloadProof")
                {
                    string proofPath = e.CommandArgument.ToString();
                    if (!string.IsNullOrEmpty(proofPath))
                    {
                        string fullPath = Server.MapPath(proofPath);
                        string fileName = System.IO.Path.GetFileName(fullPath);

                        Response.Clear();
                        Response.ContentType = "application/octet-stream";
                        Response.AppendHeader("Content-Disposition", $"attachment; filename={fileName}");
                        Response.TransmitFile(fullPath);
                        Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "text-warning";
                lblMessage.Text = "⚠️ Error: " + ex.Message;
            }
        }

        protected void btnResetLimits_Click(object sender, EventArgs e)
        {
            try
            {   
                
                claimBLL.ResetEmployeeLimits();
                lblMessage.CssClass = "text-success fw-bold";
                lblMessage.Text = $"✅ Claim limits for {ViewState["LastEmpName"]} (ID:{ViewState["LastEmpId"]})  have been reset successfully ";
                btnResetLimits.Visible = false;

                // Reload page
                LoadPendingClaims();
            }
            catch (Exception ex)
            {
                lblMessage.CssClass = "text-danger";
                lblMessage.Text = "❌ Failed to reset limits: " + ex.Message;
            }
        }




    }
}
