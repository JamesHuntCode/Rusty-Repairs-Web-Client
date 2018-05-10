<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewbookings.aspx.cs" Inherits="ViewBookings_viewbookings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rustys' Repairs - Your Bookings</title>
    <link rel="shortcut icon" type="image/x-icon" href="~/images/favicon.png" />

    <!-- LINKS TO ALL CSS FILES & CDN's -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.10/css/all.css" />
    <link rel="stylesheet" runat="server" media="screen" href="~/css/style.css" />
</head>
<body runat="server">
    <div class="container-fluid">
        <div class="container border-bottom border-dark mt-5" style="width: 50vw">
            <div class="row">
                <div class="col text-center pt-5-5">
                    <h1><i class="fas fa-wrench mr-3"></i>Rustys' Repairs</h1>
                    <h2 class="ml-5">Your Bookings</h2>
                </div>
            </div>
        </div>
        <form runat="server">
            <!-- Time and Date of Booking Box -->
            <div class="input-group mb-3 mt-5 mx-auto" style="width: 50vw">
                <div class="input-group-prepend">
                    <span class="input-group-text" style="width: 18vw" id="">Selected Time and Date</span>
                </div>
                <asp:TextBox ID="time" type="text" class="form-control" runat="server" />
                <asp:TextBox ID="date" type="text" class="form-control" runat="server" />
            </div>
            <!-- Problem Summary Box -->
            <div class="input-group mb-3 mx-auto" style="width: 50vw">
                <div class="input-group-prepend ">
                    <span class="input-group-text" style="width: 18vw" id="inputGroup-sizing-default">Problem Summary</span>
                </div>
                <asp:TextBox runat="server" ID="problemSummary" type="text" class="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default" />
            </div>
            <!-- Booking Status Box -->
            <div class="input-group mb-3 mx-auto" style="width: 50vw">
                <div class="input-group-prepend ">
                    <span class="input-group-text" style="width: 18vw" id="inputGroup-sizing-default2">Booking Status</span>
                </div>
                <asp:TextBox runat="server" ID="status" type="text" class="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default" />
            </div>
            <!-- Buttons for Editing & Deleting Bookings -->
            <div class="row">
                <div class="col-4">
                    <asp:Button runat="server" ID="btnUpdate" OnClick="UpdateBooking" type="button" Style="width: 20vw" class="btn btn-outline-success btn-lg btn-block mx-auto mt-4" Text="Update Booking" />
                </div>
                <div class="col-4">
                    <asp:Button runat="server" ID="btnCancel" OnClick="CancelBooking" type="button" Style="width: 20vw" class="btn btn-outline-success btn-lg btn-block mx-auto mt-4" Text="Cancel Booking" />
                </div>
                <div class="col-4">
                    <asp:Button runat="server" ID="btnReturnHome" OnClick="ReturnHome" type="button" Style="width: 20vw" class="btn btn-outline-success btn-lg btn-block mx-auto mt-4" Text="Return Home" />
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
