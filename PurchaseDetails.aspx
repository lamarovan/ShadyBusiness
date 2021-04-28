<%@ Page Title="Purchase Details"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseDetails.aspx.cs" Inherits="ShadyBusiness.PurchaseDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <%--<h3>Your purchase details page.</h3>--%>
    <asp:Label ID="Label7" runat="server" Text="Purchase ID: "></asp:Label><asp:Label ID="lblPID" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="Label3" runat="server" Text="Member number: "></asp:Label><asp:Label ID="lblMeme" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label1" runat="server" Text="Customer Name: "></asp:Label><asp:Label ID="lblCus" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label5" runat="server" Text="Address: "></asp:Label><asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label6" runat="server" Text="Email Address: "></asp:Label><asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label2" runat="server" Text="Purchase Date: "></asp:Label><asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label><br />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <asp:Label ID="Label4" runat="server" Text="Total amount: "></asp:Label><asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label><br />
</asp:Content>