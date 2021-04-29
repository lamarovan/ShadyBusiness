<%@ Page Language="C#" MasterPageFile="~/Site.Master" title="Profile"  AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ShadyBusiness.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="container">
        <div class="form-group">
            <label>Name</label>
            <asp:TextBox ID="txtName" runat="server" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Email</label>
            <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True"></asp:TextBox>
        </div><div class="form-group">
            <label>Password</label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
    </div>
</asp:Content>