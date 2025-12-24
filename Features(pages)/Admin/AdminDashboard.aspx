<%@ Page Language="C#" MasterPageFile="~/ClaimApp.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="ClaimApplication.Features_pages_.Admin.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3>Welcome, Admin!</h3>
        <hr />
        <p>Use the navigation above to manage employees, view or approve claims, and check reports.</p>

        <div class="row mt-4">

            <!-- Total Employees -->
            <div class="col-md-3">
                <div class="card text-white bg-primary mb-3">
                    <div class="card-header">Total Employees</div>
                    <div class="card-body">
                        <h4 class="card-title" id="lblTotalEmployees" runat="server">0</h4>
                    </div>
                </div>
            </div>

            <!-- Pending Claims -->
            <div class="col-md-3">
                <asp:LinkButton runat="server" CssClass="card text-white bg-warning mb-3 text-decoration-none"
                                PostBackUrl="~/Features(pages)/Admin/AdminClaimView.aspx?status=Pending">
                    <div class="card-header">Pending Claims</div>
                    <div class="card-body">
                        <h4 class="card-title" id="lblPendingClaims" runat="server">0</h4>
                    </div>
                </asp:LinkButton>
            </div>

            <!-- Approved Claims -->
            <div class="col-md-3">
                <asp:LinkButton runat="server" CssClass="card text-white bg-success mb-3 text-decoration-none"
                                PostBackUrl="~/Features(pages)/Admin/AdminClaimView.aspx?status=Approved">
                    <div class="card-header">Approved Claims</div>
                    <div class="card-body">
                        <h4 class="card-title" id="lblApprovedClaims" runat="server">0</h4>
                    </div>
                </asp:LinkButton>
            </div>

            <!-- Rejected Claims -->
            <div class="col-md-3">
                <asp:LinkButton runat="server" CssClass="card text-white bg-danger mb-3 text-decoration-none"
                                PostBackUrl="~/Features(pages)/Admin/AdminClaimView.aspx?status=Rejected">
                    <div class="card-header">Rejected Claims</div>
                    <div class="card-body">
                        <h4 class="card-title" id="lblRejectedClaims" runat="server">0</h4>
                    </div>
                </asp:LinkButton>
            </div>

        </div>
    </div>
</asp:Content>
