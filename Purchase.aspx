<%@ Page Language="C#" MasterPageFile="~/Site.Master" title="Purchase" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="ShadyBusiness.Purchase" %>

<asp:Content ID="Purchaser" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-group">
        <label>Customer</label>
        <asp:DropDownList ID="ddlMember" runat="server" DataSourceID="customerData" DataTextField="customer_name" DataValueField="member_number"></asp:DropDownList>
        <asp:SqlDataSource ID="customerData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSB %>" ProviderName="<%$ ConnectionStrings:ConnectionStringSB.ProviderName %>" SelectCommand="SELECT [member_number], [customer_name] FROM [customer]"></asp:SqlDataSource>
    </div>
    <div class="form-group">
        <label>Items</label>
        <asp:DropDownList ID="ddlItem" runat="server" DataSourceID="itemData" DataTextField="item_name" DataValueField="item_code"></asp:DropDownList>
        <asp:SqlDataSource ID="itemData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSB %>" ProviderName="<%$ ConnectionStrings:ConnectionStringSB.ProviderName %>" SelectCommand="SELECT [item_code], [item_name] FROM [item]"></asp:SqlDataSource>
    </div>
    <div class="form-group">
        <label>Purchase unit</label>
        <asp:TextBox ID="txtPurchaseUnit" runat="server"></asp:TextBox>
    </div>
    <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" />
    <div class="form-group">
        <label>Items</label>
        <asp:GridView ID="itemsGrid" runat="server"></asp:GridView>
    </div>    
    <div>
        <asp:Button ID="btnPurchase" runat="server" Text="Confirm Purchase" OnClick="btnPurchase_Click" /></div>
</asp:Content>