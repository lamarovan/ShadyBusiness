<%@ Page Language="C#" MasterPageFile="~/Site.Master" title="Purchase" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="ShadyBusiness.Purchase" %>

<asp:Content ID="Purchaser" ContentPlaceHolderID="MainContent" runat="server">
     <br/> <h3>Purchase Form </h3><br />

    <div class="form-row">
    <div class="form-group col-md-12">
        <label>Customer</label>
        <asp:DropDownList class="form-control" ID="ddlMember" runat="server" DataSourceID="customerData" DataTextField="customer_name" DataValueField="member_number"></asp:DropDownList>
        <asp:SqlDataSource ID="customerData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionStringSB.ProviderName %>" SelectCommand="SELECT [member_number], [customer_name] FROM [customer]"></asp:SqlDataSource>
    </div>
    <div  class="form-row rounded" style="background-color:gainsboro; width:100%;padding:15px;">
        <div class="form-group col-md-6">
            <label>Items</label>
            <asp:DropDownList class="form-control" ID="ddlItem" runat="server" DataSourceID="itemData" DataTextField="item_name" DataValueField="item_code"></asp:DropDownList>
            <asp:SqlDataSource ID="itemData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionStringSB.ProviderName %>" SelectCommand="SELECT [item_code], [item_name] FROM [item]"></asp:SqlDataSource>
        </div>
        <div class="form-group col-md-6">
            <label>Purchase unit</label>
            <asp:TextBox class="form-control" ID="txtPurchaseUnit" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-md-10">
            
        </div>
        <div class="form-group col-md-2">
            <asp:Button ID="btnAddItem" runat="server"  Text="        ADD ITEM        " CssClass="btn btn-primary" OnClick="btnAddItem_Click" />
        </div>
        </div>
        </div>
    <br /><br /><hr/><br />
        <b style="font-size:24px;">Items in CART:</b><br/><br/>
        
    <div class="form-group">
    
        <asp:GridView ID="itemsGrid"  EmptyDataText="No records has been added." CssClass="table table-striped  table-bordered" runat="server"></asp:GridView>
    </div>    
    <div>
    
        <asp:Button ID="btnPurchase" runat="server" Text="  RECORD PURCHASE  "  CssClass="btn btn-primary float-right" OnClick="btnPurchase_Click" /></div><br/><br/>
</asp:Content>