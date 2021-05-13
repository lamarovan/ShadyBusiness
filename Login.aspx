<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShadyBusiness.Login" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<title>My Awesome Login Page</title>
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<style>
    body {
        font-family: "Lato", sans-serif;
        color: lightslategrey;
        background-color: whitesmoke;
    }

    .main-head {
        height: 150px;
        background: #FFF;
    }

    .sidenav {
        height: 100%;
        overflow-x: hidden;
        padding-top: 20px;
        background-image: url("pink.jpg");
        -webkit-transform: scaleX(-1);
        transform: scaleX(-1);
    }

    .main {
        padding: 0px 10px;
    }

    @media screen and (max-height: 450px) {
        .sidenav {
            padding-top: 15px;
        }
    }

    @media screen and (max-width: 450px) {
        .login-form {
            margin-top: 10%;
        }
    }

    @media screen and (min-width: 768px) {
        .main {
            margin-left: 46%;
        }

        .sidenav {
            width: 45%;
            position: fixed;
            z-index: 1;
            top: 0;
            left: 0;
        }

        .login-form {
            margin-top: 55%;
        }
    }


    .login-main-text {
        margin-top: 70%;
        padding: 30px;
        color: white;
        font-family: Verdana;
        -webkit-transform: scaleX(-1);
        transform: scaleX(-1);
        background-color: black;
        opacity: 0.5;
    }

        .login-main-text h2 {
            font-weight: 300;
            font-family: Lucida Handwriting;
            color: white;
            opacity: 1.0;
        }

    .btn-block {
        margin-top: 5%;
        padding: 2%;
    }

    .btn-outline-dark {
        color: dimgrey;
        border-color: lightslategrey;
    }

    a {
        font-size: 13px;
        margin-left: 34%;
        cursor: pointer;
    }

        a.hover {
            color: red;
            text-decoration: none;
        }
</style>
<body>
    <form id="form1" runat="server">
        <div class="sidenav">
            <div class="login-main-text">
                <h2>The Shady Business</h2>
                <p>&nbsp;Get the right kind of shadiness.</p>
            </div>
        </div>
        <div class="main">
            <div class="col-md-6 col-sm-12">
                <div class="login-form">
                    <form>
                        <div class="form-group">
                            <label>User Name:</label>
                            <asp:TextBox ID="txtEmail" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Password:</label>
                            <asp:TextBox ID="txtPassword" class="form-control" runat="server" type="Password"></asp:TextBox>
                        </div>
                       <asp:Button ID="btnLogin" class="btn-outline-dark btn-block"  OnClick="btnLogin_Click"  runat="server" Text="Login" />

                    </form>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

