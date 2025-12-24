<%@ Page Language="C#" MasterPageFile="~/ClaimApp.Master" AutoEventWireup="true" 
    CodeBehind="EmployeeDashboard.aspx.cs" 
    Inherits="ClaimApplication.Features_pages_.Employees.EmployeeDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h3 class="text-center mb-4">Welcome, <asp:Label ID="lblEmpName" runat="server" CssClass="text-primary fw-bold"></asp:Label>!</h3>
        <hr />

        <!-- Claim Summary Cards -->
        <div class="row text-center mt-4">
            <div class="col-md-3">
                <div class="card shadow-sm border-0 rounded-4 bg-primary text-white">
                    <div class="card-header fw-bold">Total Claims</div>
                    <div class="card-body">
                        <h2 class="card-title" id="lblTotalClaims" runat="server">0</h2>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card shadow-sm border-0 rounded-4 bg-warning text-white">
                    <div class="card-header fw-bold">Pending Claims</div>
                    <div class="card-body">
                        <h2 class="card-title" id="lblPendingClaims" runat="server">0</h2>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card shadow-sm border-0 rounded-4 bg-success text-white">
                    <div class="card-header fw-bold">Approved Claims</div>
                    <div class="card-body">
                        <h2 class="card-title" id="lblApprovedClaims" runat="server">0</h2>
                    </div>
                </div>
            </div>

            <div class="col-md-3">
                <div class="card shadow-sm border-0 rounded-4 bg-danger text-white">
                    <div class="card-header fw-bold">Rejected Claims</div>
                    <div class="card-body">
                        <h2 class="card-title" id="lblRejectedClaims" runat="server">0</h2>
                    </div>
                </div>
            </div>
        </div>

       <!-- Claimable Balance -->
<div class="row mt-5 text-center">
  
    <div class="col-md-6 mb-3">
        <div class="card shadow-sm border-0 rounded-4 bg-light">
            <div class="card-header bg-info text-white fw-bold">
                Allocated Standard Limit
            </div>
            <div class="card-body">
                <h3 class="card-title text-black fw-semibold" id="lblAlocLimitSL" runat="server">₹0</h3>
            </div>
        </div>
    </div>

 
    <div class="col-md-6 mb-3">
        <div class="card shadow-sm border-0 rounded-4 bg-light">
            <div class="card-header bg-info text-white fw-bold">
                Allocated Allowance Limit
            </div>
            <div class="card-body">
                <h3 class="card-title text-black fw-semibold" id="lblAlocLimitAL" runat="server">₹0</h3>
            </div>
        </div>
    </div>
</div>

<div class="row mt-5 text-center">

    <div class="col-md-6 mb-3">
        <div class="card shadow-sm border-0 rounded-4 bg-light">
            <div class="card-header bg-secondary text-white fw-bold">
                Standard Limit Available Balance
            </div>
            <div class="card-body">
                <h3 class="card-title text-black fw-semibold" id="lblRemainingSL" runat="server">₹0</h3>
            </div>
        </div>
    </div>


    <div class="col-md-6 mb-3">
        <div class="card shadow-sm border-0 rounded-4 bg-light">
            <div class="card-header bg-secondary text-white fw-bold">
                Allowance Limit Available Balance
            </div>
            <div class="card-body">
                <h3 class="card-title text-black fw-semibold" id="lblRemainingAL" runat="server">₹0</h3>
            </div>
        </div>
    </div>
</div>
        </div>

    
</asp:Content>