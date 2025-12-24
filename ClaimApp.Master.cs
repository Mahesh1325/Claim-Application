using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClaimApplication
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNavMenu();
            }
            if (Session["Admin"] != null || Session["Employee"] != null)
            {
                lnkLogout.Visible = true;
            }
            else
            {
                lnkLogout.Visible = false;
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Features(pages)/Login.aspx");
        
        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
        
            Response.Redirect("~/Features(pages)/Home.aspx");
        }

        private void LoadNavMenu()
        {
            navContent.InnerHtml = ""; 

            if (Session["Admin"] != null)
            {
                // Admin menu
                navContent.InnerHtml = @"
                <li class='nav-item'><a class='nav-link' href='AdminDashboard.aspx'>Dashboard</a></li>
                <li class='nav-item'><a class='nav-link' href='AddEmployee.aspx'>Add Employee</a></li>
                <li class='nav-item'><a class='nav-link' href='AdminClaimView.aspx'>Manage Claim Requests</a></li>
                <li class='nav-item'><a class='nav-link' href='AdminReports.aspx'>Reports</a></li>";
            }
            else if (Session["Employee"] != null)
            {
                // Employee menu
                navContent.InnerHtml = @"
                <li class='nav-item'><a class='nav-link' href='EmployeeDashboard.aspx'>Dashboard</a></li>
                <li class='nav-item'><a class='nav-link' href='AddClaim.aspx'>Apply Claim</a></li>
                <li class='nav-item'><a class='nav-link' href='MyClaim.aspx'>My Claims</a></li>";
            }
            else
            {
               
                navContent.InnerHtml = "";
            }
        }
    }
}