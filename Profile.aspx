<%@ Page Language="C#" MasterPageFile="~/Site.Master" title="Profile"  AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ShadyBusiness.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pt-3">
        <h3>Profile Settings</h3><br />
    <div class="container">
        <div class="form-group">
            <label>Name</label>
            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Email</label>
            <asp:TextBox ID="txtEmail"  CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
        </div><div class="form-group">
            <label>Password</label>
            <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnUpdate" runat="server" Text="      UPDATE      " CssClass="btn btn-primary float-right" OnClick="btnUpdate_Click" /> <br /> <br />
    </div>
</div>
</asp:Content>