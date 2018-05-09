<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerHomepage.aspx.cs" Inherits="ManagerHomepage_ManagerHomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manager Homepage</title>
    <link rel="shortcut icon" type="image/x-icon" href="~/images/favicon.png" />

    <!-- LINKS TO ALL CSS FILES & CDN's -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.10/css/all.css" />
    <link rel="stylesheet" runat="server" media="screen" href="~/css/style.css" />
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="#"><i class="fas fa-wrench mr-1"></i>Rustys' Repairs</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNavDropdown">
            <ul class="navbar-nav">
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">My Account
                    </a>
                    <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                        <a class="dropdown-item" href="#">View Account Details</a>
                        <a class="dropdown-item" href="#">Update Account Details</a>
                        <a class="dropdown-item" href="#">Add Vehicle To Account</a>
                        <a class="dropdown-item" href="#">Deactivate Account</a>
                    </div>
                </li>
            </ul>
        </div>
        <button class="btn btn-outline-success my-2 my-sm-0" type="submit"><i class="fas mr-2 fa-sign-out-alt"></i>Logout</button>
    </nav>
    <div class="container">
        <form runat="server">
            <asp:ScriptManager runat="server" ID="sm1">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <div class="row mt-3">
                        <div class="col" style="border: 2px solid black;">
                            <h1 class="border-bottom">Customer info:</h1>
                            <h5 id="firstNameLastName" runat="server">First name & Last name:</h5>
                            <h5 id="requestDate" runat="server">Booking request date time:</h5>
                            <h5 id="carMake" runat="server">Car make:</h5>
                            <h5 id="carModel" runat="server">Car model:</h5>
                            <h5 id="carRegistration" runat="server">Car registration:</h5>
                            <h5 id="previousNoShow" runat="server">Previous no-show:</h5>
                        </div>
                        <div class="col" style="border: 2px solid black;">
                            <h1 class="border-bottom">Workplan:</h1>
                            <h5 id="staffMemberID" runat="server">Staff member ID:</h5>
                            <h5 id="staffMemberName" runat="server">Staff member name:</h5>
                            <h5 id="staffDescription" runat="server">Description:</h5>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" />
                    <asp:AsyncPostBackTrigger ControlID="Button2" />
                </Triggers>
            </asp:UpdatePanel>
            <div class="row mt-3" style="text-align: center;">
                <div class="col">
                    <div class="float-left">
                        <asp:Button runat="server" ID="Button1" OnClick="PreviousBooking" Text="Previous" Style="font-size: 24px" CssClass="btn-primary" />
                    </div>
                </div>
                <div class="col">
                    <button type="button" class="btn btn-success btn-lg">Allocate</button>
                </div>
                <div class="col">
                    <button type="button" class="btn btn-warning btn-lg">Update</button>
                </div>
                <div class="col">
                    <button type="button" class="btn btn-danger btn-lg">Deny</button>
                </div>
                <div class="col">
                    <div class="float-right">
                        <asp:Button runat="server" ID="Button2" OnClick="NextBooking" Text="Next" Style="font-size: 24px" CssClass="btn-primary" />
                    </div>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col mb-5">
                    <asp:Table ID="calenderTable" runat="server" BorderStyle="Solid" BorderColor="Black" BorderWidth="2px" GridLines="Both" Width="100%" HorizontalAlign="NotSet"></asp:Table>
                </div>
            </div>
        </form>
    </div>

    <!-- ALL JAVASCRIPT CDN's NEEDED FOR BOOTSTRAP -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
</body>
</html>
