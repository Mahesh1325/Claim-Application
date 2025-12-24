<%@ Page Language="C#" MasterPageFile="~/ClaimApp.Master" AutoEventWireup="true" 
    CodeBehind="AddClaim.aspx.cs" Inherits="ClaimApplication.Features_pages_.Employees.AddClaim" 
    UnobtrusiveValidationMode="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row justify-content-center mt-5">
        <div class="col-md-6 claim-card">
            <h3 class="text-center text-primary">Claim Approval Form</h3>

            

            <!-- Claim Date -->
            <div class="mb-3">
                <label class="form-label">Claim Date</label>
                <asp:TextBox ID="txtClaimDate" runat="server" CssClass="form-control" TextMode="Date" />
                <asp:RequiredFieldValidator ID="rfvClaimDate" runat="server" 
                    ControlToValidate="txtClaimDate" 
                    ErrorMessage="Claim Date is required." 
                    CssClass="text-danger" Display="Dynamic" />
            </div>

            <!-- Claim Category -->
            <div class="mb-3">
                <label class="form-label">Claim Category</label>
                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select">
                    <asp:ListItem Value="">-- Select Category --</asp:ListItem>
                    <asp:ListItem Value="Food">Food</asp:ListItem>
                    <asp:ListItem Value="Travel">Travel</asp:ListItem>
                    <asp:ListItem Value="Medical">Medical</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategory" runat="server" 
                    ControlToValidate="ddlCategory" 
                    InitialValue=""
                    ErrorMessage="Please select a category." 
                    CssClass="text-danger" Display="Dynamic" />
            </div>

            <!-- Claim Type -->
            <div class="mb-3">
                <label class="form-label">Claim Type</label>
                <asp:RadioButtonList ID="rblClaimType" runat="server" CssClass="form-check" AutoPostBack="true"
                                     OnSelectedIndexChanged="rblClaimType_SelectedIndexChanged">
                    <asp:ListItem Value="AL">AL</asp:ListItem>
                    <asp:ListItem Value="SL">SL</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="rfvClaimType" runat="server" 
                    ControlToValidate="rblClaimType" 
                    ErrorMessage="Please select a claim type." 
                    CssClass="text-danger" Display="Dynamic" />
            </div>

  
            <asp:Panel ID="pnlProof" runat="server" Visible="false" CssClass="mb-3">
                <label class="form-label">Upload Proof (Required for AL)</label>
                <asp:FileUpload ID="fuProof" runat="server" CssClass="form-control-file" />
            </asp:Panel>

            <div class="mb-3">
                <label class="form-label">Claim Amount</label>
                <asp:TextBox ID="txtClaimAmount" runat="server" CssClass="form-control" Placeholder="Enter Amount" />
                <asp:RequiredFieldValidator ID="rfvAmount" runat="server" 
                    ControlToValidate="txtClaimAmount" 
                    ErrorMessage="Claim amount is required." 
                    CssClass="text-danger" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revAmount" runat="server" 
                    ControlToValidate="txtClaimAmount"
                    ValidationExpression="^\d+(\.\d{1,2})?$"
                    ErrorMessage="Enter a valid amount (only numbers allowed)." 
                    CssClass="text-danger" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label class="form-label">Remarks</label>
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                <asp:RequiredFieldValidator ID="rfvRemarks" runat="server" 
                    ControlToValidate="txtRemarks"
                    ErrorMessage="Remarks are required." 
                    CssClass="text-danger" Display="Dynamic" />
            </div>
            
            <asp:Label ID="lblMessage" runat="server" CssClass="text-center fw-bold d-block"></asp:Label>


     
            <asp:Button ID="btnSubmitClaim" runat="server" CssClass="btn btn-submit w-100 text-white" Text="Submit Claim"
                        OnClick="btnSubmitClaim_Click" />

            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                CssClass="text-danger mt-3"
                HeaderText="Please correct the following errors:" 
                DisplayMode="BulletList" />
        </div>
    </div>
</asp:Content>
