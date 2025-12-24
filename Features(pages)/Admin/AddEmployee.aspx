<%@ Page Language="C#" MasterPageFile="~/ClaimApp.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" UnobtrusiveValidationMode="None" inherits="ClaimApplication.Features_pages_.Admin.AddEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="card shadow-lg border-primary p-4">
            <h3 class="text-center mb-4 text-primary fw-bold"> Employee Creation Form</h3>
            <hr class="border-2 border-primary"/>

      

            <!-- Name & Email -->
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txtName" class="form-label fw-semibold">Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control border-primary" placeholder="Employee Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server"
                        ControlToValidate="txtName"
                        ErrorMessage="Employee name is required."
                        CssClass="text-danger" Display="Dynamic" />
                </div>

                <div class="col-md-6">
                    <label for="txtEmail" class="form-label fw-semibold">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control border-primary" placeholder="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="Email is required."
                        CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revEmail" runat="server"
                        ControlToValidate="txtEmail"
                        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                        ErrorMessage="Please enter a valid email address."
                        CssClass="text-danger" Display="Dynamic" />
                </div>
            </div>

            <!-- Password & Mobile -->
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txtPassword" class="form-label fw-semibold">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control border-primary" TextMode="Password" placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                        ControlToValidate="txtPassword"
                        ErrorMessage="Password is required."
                        CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revPassword" runat="server"
                        ControlToValidate="txtPassword"
                        ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$"
                        ErrorMessage="Password must be at least 6 characters long and include letters and numbers."
                        CssClass="text-danger" Display="Dynamic" />
                </div>

                <div class="col-md-6">
                    <label for="txtMobile" class="form-label fw-semibold">Mobile No</label>
                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control border-primary" placeholder="Mobile Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMobile" runat="server"
                        ControlToValidate="txtMobile"
                        ErrorMessage="Mobile number is required."
                        CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revMobile" runat="server"
                        ControlToValidate="txtMobile"
                        ValidationExpression="^[6-9]\d{9}$"
                        ErrorMessage="Enter a valid 10-digit mobile number."
                        CssClass="text-danger" Display="Dynamic" />
                </div>
            </div>

            <!-- Claim Limits -->
            <div class="row mb-4">
                <div class="col-md-6">
                    <label for="txtClaimAL" class="form-label fw-semibold">Claim Limit (AL)</label>
                    <asp:TextBox ID="txtClaimAL" runat="server" CssClass="form-control border-primary" placeholder="Allowance Claim Limit"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvClaimAL" runat="server"
                        ControlToValidate="txtClaimAL"
                        ErrorMessage="AL claim limit is required."
                        CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revClaimAL" runat="server"
                        ControlToValidate="txtClaimAL"
                        ValidationExpression="^\d+(\.\d{1,2})?$"
                        ErrorMessage="Enter a valid number for AL claim limit."
                        CssClass="text-danger" Display="Dynamic" />
                </div>

                <div class="col-md-6">
                    <label for="txtClaimSL" class="form-label fw-semibold">Claim Limit (SL)</label>
                    <asp:TextBox ID="txtClaimSL" runat="server" CssClass="form-control border-primary" placeholder="Standard Claim Limit"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvClaimSL" runat="server"
                        ControlToValidate="txtClaimSL"
                        ErrorMessage="SL claim limit is required."
                        CssClass="text-danger" Display="Dynamic" />
                    <asp:RegularExpressionValidator ID="revClaimSL" runat="server"
                        ControlToValidate="txtClaimSL"
                        ValidationExpression="^\d+(\.\d{1,2})?$"
                        ErrorMessage="Enter a valid number for SL claim limit."
                        CssClass="text-danger" Display="Dynamic" />
                </div>
            </div>
                 <asp:Label ID="lblMessage" runat="server" CssClass="fw-bold d-block text-center mb-3"></asp:Label>


            <div class="text-center mb-2">
                <asp:Button ID="btnAddEmployee" runat="server" CssClass="btn btn-primary btn-lg px-5 mt-3" Text="Add Employee" OnClick="btnAddEmployee_Click" />
            </div>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                CssClass="text-danger mt-3"
                HeaderText="Please correct the following errors:" 
                DisplayMode="BulletList" />
        </div>
    </div>
</asp:Content>
