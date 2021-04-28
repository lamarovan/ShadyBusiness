<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShadyBusiness.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
        <div class="form-group">
            <asp:TextBox ID="txtEmail" type="email" runat="server" placeholder="email address"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:TextBox ID="txtPassword" type="password" runat="server" placeholder="Password"></asp:TextBox>
        </div>
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
    </form>
</body>
</html>
