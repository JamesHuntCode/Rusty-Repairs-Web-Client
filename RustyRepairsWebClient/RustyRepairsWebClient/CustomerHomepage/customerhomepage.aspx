<%@ Page Language="C#" AutoEventWireup="true" CodeFile="customerhomepage.aspx.cs" Inherits="Customer_Homepage_customerhomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rustys' Repairs - Home</title>
    <link rel="shortcut icon" type="image/x-icon" href="~/images/favicon.png" />

    <!-- LINKS TO ALL CSS FILES & CDN's -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.10/css/all.css" />
    <link rel="stylesheet" runat="server" media="screen" href="~/css/style.css" />
</head>
<body runat="server">
    <form runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="#"><i class="fas fa-wrench mr-1"></i>Rustys' Repairs</a>
            <asp:Button ID="btnLogout" runat="server" OnClick="Logout" class="btn btn-outline-success my-2 my-sm-0" text="Logout" type="submit"></asp:Button>
        </nav>
        <div class="container-fluid">
            <div class="row mt-5">
                <div class="col-1"></div>
                <div class="col-5 mx-auto">
                    <button type="button" class="btn btn-outline-success btn-block" style="height: 30vh">
                        <h2>Create Booking</h2>
                    </button>
                </div>
                <div class="col-5 mx-auto">
                    <button type="button" class="btn btn-outline-info btn-block" style="height: 30vh">
                        <h2>View Booking</h2>
                    </button>
                </div>
                <div class="col-1"></div>
            </div>
            <div class="row mt-5">
                <div class="col-1"></div>
                <div class="col-5 mx-auto">
                    <button type="button" class="btn btn-outline-warning btn-block" style="height: 15vh">
                        <h2>Update Booking</h2>
                    </button>
                    <button type="button" class="btn btn-outline-warning btn-block" style="height: 15vh">
                        <h2>Update Account</h2>
                    </button>
                </div>
                <div class="col-5 mx-auto">
                    <button type="button" class="btn btn-outline-danger btn-block" style="height: 15vh">
                        <h2>Cancel Booking</h2>
                    </button>
                    <button type="button" class="btn btn-outline-danger btn-block" style="height: 15vh">
                        <h2>Delete Booking</h2>
                    </button>
                </div>
                <div class="col-1"></div>
            </div>
        </div>
    </form>
    <!-- ALL JAVASCRIPT CDN's NEEDED FOR BOOTSTRAP -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
</body>
</html>
