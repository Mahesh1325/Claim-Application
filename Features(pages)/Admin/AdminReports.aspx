<%@ Page Language="C#" MasterPageFile="~/ClaimApp.Master" AutoEventWireup="true" CodeBehind="AdminReports.aspx.cs" Inherits="ClaimApplication.Features_pages_.Admin.AdminReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
      
        <div class="card shadow-sm border-0 mb-4">
            <div class="card-body bg-primary text-white rounded-top">
                <h3 class="mb-0"><i class="bi bi-bar-chart-fill me-2"></i>Claims Reports</h3>
            </div>
        </div>

        
        <div class="card shadow-sm mb-4 border-0">
            <div class="card-body">
                <div class="row align-items-end">
                    <div class="col-md-3 mb-3">
                        <label class="form-label fw-semibold">From Date</label>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="col-md-3 mb-3">
                        <label class="form-label fw-semibold">To Date</label>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="col-md-3 mb-3">
                        <asp:Button ID="btnGenerateReport" runat="server"
                            CssClass="btn btn-success w-100 fw-semibold shadow-sm"
                            Text="Generate Report"
                            OnClick="btnGenerateReport_Click" />
                    </div>
                </div>
            </div>
        </div>

        
        <div class="card shadow-sm border-0">
            <div class="card-body">
                <h5 class="card-title mb-3 fw-semibold text-secondary">Report Summary</h5>

                <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-hover align-middle text-center border"
                    HeaderStyle-BackColor="#007BFF" HeaderStyle-ForeColor="White"
                    HeaderStyle-Font-Bold="True" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="ClaimType" HeaderText="Claim Type" />
                        <asp:BoundField DataField="TotalAmt" HeaderText="Total Amount (₹)" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Count" HeaderText="Number of Claims" />
                    </Columns>
                </asp:GridView>

                <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mt-3 d-block fw-semibold text-center"></asp:Label>
            </div>
        </div>
    </div>

    
</asp:Content>
