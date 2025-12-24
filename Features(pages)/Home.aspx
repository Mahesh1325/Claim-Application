<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ClaimApp.Master" CodeBehind="Home.aspx.cs" Inherits="ClaimApplication.Features_pages_.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
 
        <div class="text-center mb-5">
            <h2 class="fw-bold text-primary">Welcome to Claim Management System</h2>
            <p class="text-secondary fs-5 mt-2">
                A unified platform to manage, monitor, and process employee claims seamlessly.
            </p>
            <hr class="w-25 mx-auto border-primary" />
        </div>

 
        <div class="card shadow-sm border-0 mb-5">
            <div class="card-body p-4">
                <h4 class="text-primary fw-semibold mb-3">
                    <i class="bi bi-info-circle-fill me-2"></i>System Overview
                </h4>
                <p class="text-muted fs-6">
                    The <strong>Claim Management System (CMS)</strong> is designed to automate the employee claim process,
                    enabling smooth submission, tracking, and approval of various claim types such as
                    <em>Allowance (AL)</em> and <em>Standard Leave (SL)</em>. It reduces manual paperwork,
                    ensures transparency, and maintains accurate financial control for both employees and administrators.
                </p>
            </div>
        </div>

        
        <div class="mb-5">
            <h4 class="fw-bold text-primary text-center mb-4">📊 Application Workflow</h4>

            <div class="row g-4">
                <div class="col-md-4">
                    <div class="card h-100 shadow-sm border-0">
                        <div class="card-body text-center">
                            <i class="bi bi-person-plus-fill text-primary fs-1 mb-3"></i>
                            <h5 class="fw-semibold">1️⃣ Employee Registration & Login</h5>
                            <p class="text-muted">
                                Employees register and log in to the system using their credentials to access their dashboard
                                and view claimable allowances.
                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card h-100 shadow-sm border-0">
                        <div class="card-body text-center">
                            <i class="bi bi-file-earmark-plus-fill text-success fs-1 mb-3"></i>
                            <h5 class="fw-semibold">2️⃣ Claim Submission</h5>
                            <p class="text-muted">
                                Employees apply for claims by selecting claim type, entering details, uploading proof (for AL),
                                and submitting for review.
                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-md-4">
                    <div class="card h-100 shadow-sm border-0">
                        <div class="card-body text-center">
                            <i class="bi bi-check2-circle text-warning fs-1 mb-3"></i>
                            <h5 class="fw-semibold">3️⃣ Admin Review & Approval</h5>
                            <p class="text-muted">
                                The administrator reviews pending claims, verifies proofs, and either approves or rejects
                                based on eligibility and available limits.
                            </p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row g-4 mt-3">
                <div class="col-md-6">
                    <div class="card h-100 shadow-sm border-0">
                        <div class="card-body text-center">
                            <i class="bi bi-graph-up-arrow text-danger fs-1 mb-3"></i>
                            <h5 class="fw-semibold">4️⃣ Dashboard Analytics</h5>
                            <p class="text-muted">
                                Both Admin and Employees can monitor claim history, status summaries, and view remaining balances
                                with visually rich dashboards.
                            </p>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="card h-100 shadow-sm border-0">
                        <div class="card-body text-center">
                            <i class="bi bi-file-earmark-bar-graph-fill text-info fs-1 mb-3"></i>
                            <h5 class="fw-semibold">5️⃣ Reports & Insights</h5>
                            <p class="text-muted">
                                Admin can generate time-based reports to track claim distribution, analyze spending patterns,
                                and maintain financial transparency.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

       
        <div class="card shadow-sm border-0 bg-light mb-5">
            <div class="card-body">
                <h4 class="fw-bold text-primary mb-3"><i class="bi bi-lightbulb-fill me-2"></i>Quick User Guide</h4>
                <ul class="list-group list-group-flush">
                    <li class="list-group-item">
                        <strong>Employee:</strong> Login → View Dashboard → Apply for Claim → Track Status
                    </li>
                    <li class="list-group-item">
                        <strong>Admin:</strong> Login → Review Pending Claims → Approve / Reject → Generate Reports
                    </li>
                    <li class="list-group-item">
                        <strong>System:</strong> Automatically updates remaining limits and claim status dynamically.
                    </li>
                </ul>
            </div>
        </div>

        <!-- Footer Text -->
        <div class="text-center mt-4 text-muted small">
            <i class="bi bi-shield-lock-fill me-1"></i>
            All data and documents are securely managed within the Claim Management System.
        </div>
    </div>

    <!-- Custom Styling -->
    <style>
        .card {
            border-radius: 12px;
            transition: all 0.3s ease;
        }
        .card:hover {
            transform: translateY(-4px);
            box-shadow: 0 6px 16px rgba(0, 0, 0, 0.1);
        }
        .list-group-item {
            background: transparent;
        }
    </style>
</asp:Content>
