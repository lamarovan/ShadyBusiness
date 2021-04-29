<%@ Page Title="Purchase Details"  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseDetails.aspx.cs" Inherits="ShadyBusiness.PurchaseDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .word {
            font-size: 19px;
            line-height:36px;
            color: dimgray;
        }
        .value {
            font-size: 17px;
            line-height:36px;
            
        }
    </style>
    <br/>
    <h2><%: Title %></h2>
    <%--<h3>Your purchase details page.</h3>--%>
    <asp:Label ID="Label7" CssClass="word" runat="server" Text="Purchase ID: "></asp:Label><asp:Label ID="lblPID" CssClass="value" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="Label3" CssClass="word"  runat="server" Text="Member number: "></asp:Label><asp:Label ID="lblMeme"  CssClass="value" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label1" CssClass="word"  runat="server" Text="Customer Name: "></asp:Label><asp:Label ID="lblCus" CssClass="value" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label5" CssClass="word"  runat="server" Text="Address: "></asp:Label><asp:Label ID="lblAddress" CssClass="value" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label6" CssClass="word" runat="server" Text="Email Address: "></asp:Label><asp:Label ID="lblEmail" CssClass="value" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Label2" CssClass="word"  runat="server" Text="Purchase Date: "></asp:Label><asp:Label ID="lblDate" CssClass="value" runat="server" Text="Label"></asp:Label><br /><br />
    <asp:GridView ID="GridView1" CssClass="table table-striped  table-bordered" runat="server"></asp:GridView>
    <asp:Label ID="Label4" runat="server"  CssClass="word" Text="Total amount: "></asp:Label><asp:Label ID="lblTotal" CssClass="value" runat="server" Text="Label"></asp:Label><br />
</asp:Content>