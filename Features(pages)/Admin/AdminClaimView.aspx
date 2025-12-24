<%@ Page Language="C#" MasterPageFile="~/ClaimApp.Master" AutoEventWireup="true"
    CodeBehind="AdminClaimView.aspx.cs"
    UnobtrusiveValidationMode="None"
    Inherits="ClaimApplication.Features_pages_.Admin.AdminClaimView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="container mt-4">
  
        <div class="card shadow-sm mb-4 border-primary">
            <div class="card-body bg-primary text-white">
                <h3 id="lblClaimTitle" runat="server" class="mb-0 fw-bold"></h3>
            </div>
        </div>

        <div class="card shadow-sm">
            <div class="card-body">
                <asp:GridView ID="gvClaims" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-hover table-bordered table-striped"
                    OnRowCommand="gvClaims_RowCommand"
                    HeaderStyle-CssClass="table-primary text-center fw-bold"
                    RowStyle-CssClass="align-middle">
                    <Columns>
                        <asp:BoundField DataField="ClaimId" HeaderText="Claim ID" />
                        <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                        <asp:BoundField DataField="ClaimType" HeaderText="Claim Type" />
                        <asp:BoundField DataField="ClaimAmount" HeaderText="Amount" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="ClaimDate" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" />
                        
                     <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Literal ID="litStatus" runat="server" Text='<%# GetStatusBadgeText(Eval("Status")) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>


                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />

                        <asp:TemplateField HeaderText="Proof Document">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkViewProof" runat="server" Text="View"
                                    CssClass="btn btn-info btn-sm me-1 mb-1"
                                    CommandName="ViewProof"
                                    CommandArgument='<%# Eval("ProofDocument") %>'
                                    Visible='<%# !string.IsNullOrEmpty(Eval("ProofDocument").ToString()) %>'>
                                </asp:LinkButton>

                                <asp:LinkButton ID="lnkDownloadProofRow" runat="server" Text="Download"
                                    CssClass="btn btn-primary btn-sm mb-1"
                                    CommandName="DownloadProof"
                                    CommandArgument='<%# Eval("ProofDocument") %>'
                                    Visible='<%# !string.IsNullOrEmpty(Eval("ProofDocument").ToString()) %>'>
                                </asp:LinkButton>

                                <asp:Label ID="lblNoProof" runat="server" Text="—"
                                    CssClass="text-muted"
                                    Visible='<%# string.IsNullOrEmpty(Eval("ProofDocument").ToString()) %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnApprove" runat="server" CommandName="Approve"
                                    CommandArgument='<%# Eval("ClaimId") %>'
                                    Text="Approve" CssClass="btn btn-success btn-sm me-1 mb-1"
                                    Enabled='<%# Eval("Status") == DBNull.Value %>' />
                                <asp:Button ID="btnReject" runat="server" CommandName="Reject"
                                    CommandArgument='<%# Eval("ClaimId") %>'
                                    Text="Reject" CssClass="btn btn-danger btn-sm mb-1"
                                    Enabled='<%# Eval("Status") == DBNull.Value %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

<div class="modal fade" id="proofModal" tabindex="-1" role="dialog" aria-labelledby="proofModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content">

            <!-- Modal Header -->
            <div class="modal-header bg-primary text-white justify-content-center position-relative">
                <h5 class="modal-title" id="proofModalLabel">View Proof</h5>

                <button type="button" class="close position-absolute" style="right: 1rem;" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true" class="text-black">&times;</span>
                </button>
            </div>

            <!-- Modal Body -->
            <div class="modal-body text-center">
                <asp:Image ID="imgProof" runat="server" CssClass="img-fluid mb-3 rounded border" />
                <br />
                <asp:HyperLink ID="lnkDownloadProof" runat="server" Text="Download Proof"
                    Target="_blank" CssClass="btn btn-primary" />
            </div>

        </div>
    </div>
</div>
        <asp:Label ID="Label1" runat="server" CssClass="text-success mt-3 fw-bold d-block"></asp:Label>

<!-- Reset Limits Button (Initially Hidden) -->
<div class="text-center mt-3">
     <asp:Label ID="lblMessage" runat="server" CssClass="text-success mt-3 fw-bold d-block"></asp:Label>
    <asp:Button ID="btnResetLimits" runat="server" 
        Text="🔄 Reset Claim Limits" 
        CssClass="btn btn-warning fw-bold px-4"
        Visible="false"
        OnClick="btnResetLimits_Click" />
</div>


       
    </div>

   
</asp:Content>
