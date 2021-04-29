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
          </div>
		  </div>
<div class="col-md-12">
       <div class="row">
									<div class="col-sm-3">
										<div class="card">
											<div class="card-body">
												<h5 class="card-title mb-4">Number of Sales</h5>
												<h1 class="display-5 mt-1 mb-3">           
                                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                                </h1>
												<div class="mb-1">
	                                                  <span class="text-muted">In last 31 days</span>
												</div>
											</div>
										</div>
										
									</div>
									<div class="col-sm-3">
										<div class="card">
											<div class="card-body">
												<h5 class="card-title mb-4">Customers</h5>
												<h1 class="display-5 mt-1 mb-3">
                                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></h1>
												<div class="mb-1">
													<span class="text-muted">Registered system</span>
												</div>
											</div>
										</div>
										
									</div>
									<div class="col-sm-3">
										<div class="card">
											<div class="card-body">
												<h5 class="card-title mb-4">Items in Inventory</h5>
												<h1 class="display-5 mt-1 mb-3">
                                                   <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></h1>
												</h1>
												<div class="mb-1">
													<span class="text-muted">Items in inventoey</span>
												</div>
											</div>
										</div>
										
									</div>
									<div class="col-sm-3">
										<div class="card">
											<div class="card-body">
												<h5 class="card-title mb-4">Revenue</h5>
												<h1 class="display-5 mt-1 mb-3">
                                                        Rs. <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
												</h1>
												<div class="mb-1">
													<span class="text-muted">In last 31 days</span>
												</div>
											</div>
										</div>
										
									</div>
									
									
								</div>
</div>


<br />
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
                  <asp:GridView ID="GridView4"  class="table table-striped  table-bordered" runat="server" EmptyDataText="No records has been added."></asp:GridView>
                   </div>
                 </div>
                </div>            
    
    <div class="col-md-12 mt-4">
                                    <div class="card">
                                        <div class="card-body">
                                            <!-- title -->
                                            <div class="d-md-flex align-items-center">
                                                <div>
                                                    <h4 class="card-title">Purchase Details</h4>
                                                    <h5 class="card-subtitle">Purchase Records of Customer's last 31 days </h5>
                                                </div>
                                                <div class="ml-auto">
                                                    <asp:DropDownList class="custom-select"  ID="DropDownList1" AutoPostBack="True" runat="server" DataSourceID="SqlDataSource1" DataTextField="customer_name" DataValueField="member_number" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sbConnectionString %>" SelectCommand="SELECT [customer_name], [member_number] FROM [customer]"></asp:SqlDataSource>
                                                </div>
                                            </div><br>
                  <asp:GridView ID="GridView1"  class="table table-striped  table-bordered" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                      AutoGenerateSelectButton="True"                       EmptyDataText="No records has been added."
                      ></asp:GridView>
                   </div>
                 </div>
                </div>
   
            <div class="col-md-12 mt-4">
                                    <div class="card">
                                        <div class="card-body">
                                            <!-- title -->
                                            <div class="d-md-flex align-items-center">
                                                <div>
                                                    <h4 class="card-title">Items out of stock</h4>
                                                    <h5 class="card-subtitle">List of items that are out of stock.</h5>
                                                </div>

                                                <div class="ml-auto">
                                                    <div class="dl">Sort By:
                                                <asp:DropDownList class="custom-select" ID="DropDownList3" runat="server"
                                                    AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                                    <asp:ListItem  Value="name"> Item Name </asp:ListItem>
                                                    <asp:ListItem Value="date"> Stock Date </asp:ListItem>
                                                    <asp:ListItem Value="quantity"> Quantity </asp:ListItem>
                                                </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div><br>
                  <asp:GridView ID="GridView2"  class="table table-striped  table-bordered" runat="server"
                                            EmptyDataText="No records has been added."></asp:GridView>
                   </div>
                 </div>
                </div>


                                <div class="col-md-12 mt-4">
                                    <div class="card">
                                        <div class="card-body">
                                            <!-- title -->
                                            <div class="d-md-flex align-items-center">
                                                <div>
                                                    <h4 class="card-title">Unpopular Items</h4>
                                                    <h5 class="card-subtitle">Items that hasn't be sold since last 31 days</h5>
                                                </div>
                                                <!--<div class="ml-auto">
                                                    <div class="dl">
                                                        <select class="custom-select">
                                                            <option value="0" selected="">Monthly</option>
                                                            <option value="1">Daily</option>
                                                            <option value="2">Weekly</option>
                                                            <option value="3">Yearly</option>
                                                        </select>
                                                    </div>
                                                </div>-->
                                            </div><br>
                  <asp:GridView ID="GridView5"  class="table table-striped  table-bordered" runat="server"
                        OnRowDeleting="GridView5_RowDeleting"
                                  DataKeyNames="ID"
                      OnRowDataBound="GridView5_RowDataBound"  
                      EmptyDataText="No records has been added."
                       AutoGenerateDeleteButton="True"
                      ></asp:GridView>
                   </div>
                 </div>
                </div>

                

                <div class="col-md-12 mt-4">
                                    <div class="card">
                                        <div class="card-body">
                                            <!-- title -->
                                            <div class="d-md-flex align-items-center">
                                                <div>
                                                    <h4 class="card-title">In-active customers</h4>
                                                    <h5 class="card-subtitle">Customers who have not made a purchase for last 31 days</h5>
                                                </div>
                                            </div><br>
                  <asp:GridView ID="GridView3"  class="table table-striped  table-bordered" runat="server"
                                            EmptyDataText="No records has been added."></asp:GridView>
                   </div>
                 </div>
                </div>

        </div>

        </div>
    
</asp:Content>