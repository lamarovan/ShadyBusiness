<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="ShadyBusiness.Dashboard" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css" />

<style>
    .description{
        margin-top: 40px;
        margin-bottom: 30px;
    }
</style>
<div class="container-fluid px-lg-4">
<div class="row">
<div class="col-md-12 mt-lg-4 mt-4">
          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Dashboard</h1>
            <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-download fa-sm text-white-50"></i> 
			Generate Report</a>
          </div>
		  </div>
<div class="col-md-12">
       <div class="row">
									<div class="col-sm-3">
										<div class="card">
											<div class="card-body">
												<h5 class="card-title mb-4">Number of Sales</h5>
												<h1 class="display-5 mt-1 mb-3">2.382</h1>
												<div class="mb-1">
													<span class="text-danger"> <i class="mdi mdi-arrow-bottom-right"></i> -3.65% </span>
													<span class="text-muted">Since last week</span>
												</div>
											</div>
										</div>
										
									</div>
									<div class="col-sm-3">
										<div class="card">
											<div class="card-body">
												<h5 class="card-title mb-4">Customers</h5>
												<h1 class="display-5 mt-1 mb-3">2.382</h1>
												<div class="mb-1">
													<span class="text-danger"> <i class="mdi mdi-arrow-bottom-right"></i> -3.65% </span>
													<span class="text-muted">Since last week</span>
												</div>
											</div>
										</div>
										
									</div>
									<div class="col-sm-3">
										<div class="card">
											<div class="card-body">
												<h5 class="card-title mb-4">Items in Inventory</h5>
												<h1 class="display-5 mt-1 mb-3">2.382</h1>
												<div class="mb-1">
													<span class="text-danger"> <i class="mdi mdi-arrow-bottom-right"></i> -3.65% </span>
													<span class="text-muted">Since last week</span>
												</div>
											</div>
										</div>
										
									</div>
									<div class="col-sm-3">
										<div class="card">
											<div class="card-body">
												<h5 class="card-title mb-4">Revenue</h5>
												<h1 class="display-5 mt-1 mb-3">$21.300</h1>
												<div class="mb-1">
													<span class="text-success"> <i class="mdi mdi-arrow-bottom-right"></i> 6.65% </span>
													<span class="text-muted">Since last week</span>
												</div>
											</div>
										</div>
										
									</div>
									
									
								</div>
</div>


     <hr>
    <p class="description"> Shady bussiness. management stock blablabla</p>
    <hr>
                    <!-- column -->
    <div class="col-md-12 mt-4">
                                    <div class="card">
                                        <div class="card-body">
                                            <!-- title -->
                                            <div class="d-md-flex align-items-center">
                                                <div>
                                                    <h4 class="card-title">Top Selling Products</h4>
                                                    <h5 class="card-subtitle">Overview of Top Selling Items</h5>
                                                </div>
                                                 <div class="ml-auto">
                                                <asp:DropDownList class="custom-select" ID="DropDownList2" runat="server"
                                                    AutoPostBack="True"
                                                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                    <asp:ListItem  Value="Month"> Monthly </asp:ListItem>
                                                    <asp:ListItem Value="Year"> Yearly </asp:ListItem>
                                                </asp:DropDownList>
                                                </div>
                                            </div>
                                            <br>
                  <asp:GridView ID="GridView4"  class="table table-striped  table-bordered" runat="server"></asp:GridView>
                   </div>
                 </div>
                </div>            
    
    <div class="col-md-12 mt-4">
                                    <div class="card">
                                        <div class="card-body">
                                            <!-- title -->
                                            <div class="d-md-flex align-items-center">
                                                <div>
                                                    <h4 class="card-title">Top Selling Products</h4>
                                                    <h5 class="card-subtitle">Overview of Top Selling Items</h5>
                                                </div>
                                                <div class="ml-auto">
                                                    <div class="dl">
                                                        <select class="custom-select">
                                                            <option value="0" selected="">Monthly</option>
                                                            <option value="1">Daily</option>
                                                            <option value="2">Weekly</option>
                                                            <option value="3">Yearly</option>
                                                        </select>
                                                    </div>
                                                </div>
                                            </div><br>
                  <asp:GridView ID="GridView1"  class="table table-striped  table-bordered" runat="server"></asp:GridView>
                   </div>
                 </div>
                </div>
   
            <div class="col-md-6 mt-4">
                                    <div class="card">
                                        <div class="card-body">
                                            <!-- title -->
                                            <div class="d-md-flex align-items-center">
                                                <div>
                                                    <h4 class="card-title">Top Selling Products</h4>
                                                    <h5 class="card-subtitle">Overview of Top Selling Items</h5>
                                                </div>
                                                <div class="ml-auto">
                                                    <div class="dl">
                                                        <select class="custom-select">
                                                            <option value="0" selected="">Monthly</option>
                                                            <option value="1">Daily</option>
                                                            <option value="2">Weekly</option>
                                                            <option value="3">Yearly</option>
                                                        </select>
                                                    </div>
                                                </div>
                                            </div><br>
                  <asp:GridView ID="GridView2"  class="table table-striped  table-bordered" runat="server"></asp:GridView>
                   </div>
                 </div>
                </div>

                <div class="col-md-6 mt-4">
                                    <div class="card">
                                        <div class="card-body">
                                            <!-- title -->
                                            <div class="d-md-flex align-items-center">
                                                <div>
                                                    <h4 class="card-title">Top Selling Products</h4>
                                                    <h5 class="card-subtitle">Overview of Top Selling Items</h5>
                                                </div>
                                                <div class="ml-auto">
                                                    <div class="dl">
                                                        <select class="custom-select">
                                                            <option value="0" selected="">Monthly</option>
                                                            <option value="1">Daily</option>
                                                            <option value="2">Weekly</option>
                                                            <option value="3">Yearly</option>
                                                        </select>
                                                    </div>
                                                </div>
                                            </div><br>
                  <asp:GridView ID="GridView3"  class="table table-striped  table-bordered" runat="server"></asp:GridView>
                   </div>
                 </div>
                </div>

        </div>

        </div>
    
</asp:Content>