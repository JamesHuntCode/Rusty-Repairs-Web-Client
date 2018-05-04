<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rustys' Repairs - Login</title>
    <link rel="shortcut icon" type="image/x-icon" href="~/images/favicon.png" />

    <!-- LINKS TO ALL CSS FILES & CDN's -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.10/css/all.css" />
    <link rel="stylesheet" runat="server" media="screen" href="~/css/style.css" />
</head>
<body runat="server">
    <div id="page-content">
        <!-- Page Container -->
        <div class="container-fluid">
            <!-- Page Main Header -->
            <div class="container border-bottom border-dark mt-5" style="width: 50vw">
                <div class="row">
                    <div class="col text-center pt-5-5">
                        <h1><i class="fas fa-wrench"></i>Rustys' Repairs Login</h1>
                    </div>
                </div>
            </div>
            <!-- Email box -->
            <form method="post" runat="server">
                <div class="input-group mb-3 mt-5 mx-auto" style="width: 40vw">
                    <div class="input-group-prepend ">
                        <span class="input-group-text" style="width: 14vw" id="inputGroup-sizing-default">Email:</span>
                    </div>
                    <asp:textbox type="text" runat="server" id="inputEmail" class="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default" />
                </div>
                <!-- Password Box -->
                <div class="input-group mb-3 mx-auto" style="width: 40vw">
                    <div class="input-group-prepend">
                        <span class="input-group-text" style="width: 14vw" id="inputGroup-sizing-default2">Password:</span>
                    </div>
                    <asp:textbox type="text" runat="server" id="inputPassword" class="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default" />
                </div>
                <!-- Buttons for Login and Create an Account -->
                <asp:Button ID="btnLogin" runat="server" OnClick="Login" Text="Login" Style="width: 40vw" class="btn btn-outline-success btn-lg btn-block mx-auto mt-4" />
                <p class="text-center mt-5" style="color: grey"><i>Don't Have an Account?*</i></p>
                <asp:Button ID="btnCreateAccount" runat="server" OnClick="CreateAccount" Text="Create Account" Style="width: 27vw" class="btn btn-outline-info btn-lg btn-block mx-auto" />
            </form>
        </div>
    </div>
    <!-- ALL JAVASCRIPT CDN's NEEDED FOR BOOTSTRAP -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
</body>
</html>
