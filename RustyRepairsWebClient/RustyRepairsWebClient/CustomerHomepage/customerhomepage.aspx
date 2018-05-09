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
            <!-- LOGOUT BUTTON -->
            <asp:Button ID="btnLogout" runat="server" OnClick="Logout" class="btn btn-outline-success my-2 my-sm-0" Text="Logout" type="button" />
        </nav>
        <div class="container-fluid">
            <div class="row mt-5">
                <div class="col-1"></div>
                <!-- CREATE BOOKING SECTION -->
                <div class="col-5 mx-auto">
                    <asp:Button runat="server" OnClick="CreateBooking" type="button" class="btn btn-outline-success btn-block" Style="height: 30vh" Text="Create Booking" />
                </div>
                <!-- VIEW BOOKINGS SECTION -->
                <div class="col-5 mx-auto">
                    <asp:Button runat="server" OnClick="ViewBookings" type="button" class="btn btn-outline-info btn-block" Style="height: 30vh" Text="View Your Bookings" />
                </div>
                <div class="col-1"></div>
            </div>
            <div class="row mt-5">
                <div class="col-1"></div>
                <!-- UPDATE BOOKING SECTION -->
                <div class="col-5 mx-auto">
                    <asp:Button runat="server" OnClick="EditBooking" type="button" class="btn btn-outline-warning btn-block" Style="height: 15vh" Text="Update A Booking" />
                    <!-- UPDATE ACCOUNT SECTION -->
                    <asp:Button runat="server" OnClick="EditAccount" type="button" class="btn btn-outline-warning btn-block" Style="height: 15vh" Text="Update Your Account Details" />
                </div>
                <div class="col-5 mx-auto">
                    <!-- CANCEL BOOKING SECTION -->
                    <asp:Button runat="server" OnClick="CancelBooking" type="button" class="btn btn-outline-danger btn-block" Style="height: 15vh" Text="Cancel A Booking" />
                    <!-- DELETE ACCOUNT SECTION -->
                    <asp:Button runat="server" OnClick="DeleteAccount" type="button" class="btn btn-outline-danger btn-block" Style="height: 15vh" Text="Deactivate Your Account" />
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
