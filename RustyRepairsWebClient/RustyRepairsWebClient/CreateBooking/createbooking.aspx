<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createbooking.aspx.cs" Inherits="CreateBooking_createbooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rustys' Repairs - Request Booking</title>
    <link rel="shortcut icon" type="image/x-icon" href="~/images/favicon.png" />

    <!-- LINKS TO ALL CSS FILES & CDN's -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.10/css/all.css" />
    <link rel="stylesheet" runat="server" media="screen" href="~/css/style.css" />
</head>
<body>
    <div class="container-fluid">
        <div class="container border-bottom border-dark mt-5" style="width: 50vw">
            <div class="row">
                <div class="col text-center pt-5-5">
                    <h1><i class="fas fa-wrench mr-3"></i>Rustys' Repairs</h1>
                    <h2 class="ml-5">Create Booking</h2>
                </div>
            </div>
        </div>
        <form runat="server">
            <!-- Date and Time Wanted Box -->
            <div class="input-group mb-3 mt-5 mx-auto" style="width: 50vw">
                <div class="input-group-prepend">
                    <span class="input-group-text" style="width: 18vw" id="">Time and Date Preferred</span>
                </div>
                <asp:textbox id="time" type="text" class="form-control" runat="server" />
                <asp:textbox id="date" type="text" class="form-control" runat="server" />
            </div>
            <!-- Problem Summary Box -->
            <div class="input-group mb-3 mx-auto" style="width: 50vw">
                <div class="input-group-prepend ">
                    <span class="input-group-text" style="width: 18vw" style="height: 20vh" id="inputGroup-sizing-default">Problem Summary<br/>
                        - Describe the issue</span>
                </div>
                <asp:textbox runat="server" ID="problemSummary" type="text" class="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default" />
            </div>
            <!-- Create Booking Button -->
            <asp:Button runat="server" ID="btnCreate" OnClick="CreateBooking" type="button" style="width: 40vw" class="btn btn-outline-success btn-lg btn-block mx-auto mt-4" Text="Submit Booking Request" />
        </form>
    </div>
    <!-- ALL JAVASCRIPT CDN's NEEDED FOR BOOTSTRAP -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
</body>
</html>
