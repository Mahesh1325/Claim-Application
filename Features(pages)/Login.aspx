<%@ Page Language="C#" MasterPageFile="~/ClaimApp.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" unobtrusiveValidationMode="None" Inherits="ClaimApplication.Features_pages_.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-100 bg-light">
    
        <div class="card shadow-lg rounded-4 border-0" style="width: 100%; max-width: 460px;">
            <div class="card-body p-5">
                <h3 class="card-title text-center mb-4 fw-bold text-primary">Login</h3>

       
                <div class="mb-4">
                    <asp:TextBox ID="txtUser" runat="server" CssClass="form-control form-control-lg" Placeholder="Username / Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtUser"
                        ErrorMessage="Username / Email is required" CssClass="text-danger small" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

        
                <div class="mb-4">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-lg" TextMode="Password" Placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="Password is required" CssClass="text-danger small" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>

                <div class="mb-4 text-center">
    <asp:RadioButtonList ID="rblRole" runat="server"
        RepeatDirection="Horizontal"
        RepeatLayout="Flow"
        CssClass="d-flex justify-content-center gap-4">
        
        <asp:ListItem Value="Admin" Selected="True" Text="Admin" CssClass="text-primary"></asp:ListItem>
        <asp:ListItem Value="Employee" Text="Employee" CssClass="text-success"></asp:ListItem>

    </asp:RadioButtonList>
</div>



                <div class="d-grid mb-3">
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-lg fw-semibold shadow-sm" Text="Login" OnClick="btnLogin_Click" />
                </div>

        
                <asp:Label ID="lblMsg" runat="server" CssClass="text-danger mt-2 d-block text-center small"></asp:Label>


                <div class="text-center mt-3">
                    <a href="#" class="text-decoration-none text-primary small">Forgot Password?</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
