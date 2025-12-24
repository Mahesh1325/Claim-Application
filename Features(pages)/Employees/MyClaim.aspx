<%@ Page Language="C#" MasterPageFile="~/ClaimApp.Master" AutoEventWireup="true" 
    CodeBehind="MyClaim.aspx.cs" Inherits="ClaimApplication.Features_pages_.Employees.MyClaim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Card styling */
        .claim-card {
            background-color: #f8f9fa;
            border-radius: 10px;
            padding: 25px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.08);
        }

        .claim-card h3 {
            color: #343a40;
            font-weight: 700;
            margin-bottom: 20px;
        }

        /* Status badges */
        .badge-status {
            padding: 5px 10px;
            border-radius: 12px;
            color: #fff;
            font-weight: 600;
            font-size: 0.85rem;
            text-align: center;
            display: inline-block;
        }

        .badge-pending {
            background-color: #ffc107; /* yellow */
            color: #212529;
        }

        .badge-approved {
            background-color: #28a745; /* green */
        }

        .badge-rejected {
            background-color: #dc3545; /* red */
        }

        /* Grid styling */
        .table th, .table td {
            vertical-align: middle;
        }

        .table thead th {
            background-color: #007bff;
            color: #fff;
            font-weight: 600;
        }

    </style>

    <div class="container mt-4 claim-card">
        <h3 class="text-center">My Claims</h3>
        <hr />

        <asp:GridView ID="gvMyClaims" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
            <Columns>
                <asp:BoundField DataField="ClaimId" HeaderText="Claim ID" />
                <asp:BoundField DataField="ClaimType" HeaderText="Claim Type" />
                <asp:BoundField DataField="ClaimAmount" HeaderText="Amount" DataFormatString="{0:C}" />
                <asp:BoundField DataField="ClaimDate" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" />

             
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" CssClass='<%# GetStatusClass(Eval("Status")) %>' 
                                   Text='<%# GetStatusText(Eval("Status")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
            </Columns>
        </asp:GridView>
    </div>

   
</asp:Content>
