<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewvehicle.aspx.cs" Inherits="ViewVehicle_viewvehicle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rusty's Repairs - View Vehicle</title>
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
                    <h2 class="ml-5">View Your Vehicle Details</h2>
                </div>
            </div>
        </div>
        <form runat="server">
            <!-- Car Make and Model Box -->
            <div class="input-group mb-3 mt-5 mx-auto" style="width: 50vw">
                <div class="input-group-prepend">
                    <span class="input-group-text" style="width: 18vw" id="">Car Make and Model</span>
                </div>
                <asp:TextBox ID="carMake" type="text" class="form-control" runat="server" />
                <asp:TextBox ID="carModel" type="text" class="form-control" runat="server" />
            </div>
            <!-- Car Registration Box -->
            <div class="input-group mb-3 mx-auto" style="width: 50vw">
                <div class="input-group-prepend ">
                    <span class="input-group-text" style="width: 18vw" id="inputGroup-sizing-default">Car Registration:</span>
                </div>
                <asp:TextBox runat="server" ID="registration" type="text" class="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default" />
            </div>
            <!-- Owner Information Box -->
            <div class="input-group mb-3 mx-auto" style="width: 50vw">
                <div class="input-group-prepend ">
                    <span class="input-group-text" style="width: 18vw" id="inputGroup-sizing-default2">Owners Name:</span>
                </div>
                <asp:TextBox runat="server" ID="ownerName" type="text" class="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default2" />
            </div>
            <p class="text-center mt-5" style="color: grey"><i>Finished Viewing Your Vehicle?</i></p>
            <asp:Button runat="server" OnClick="ReturnHome" type="button" Style="width: 27vw" class="btn btn-outline-info btn-lg btn-block mx-auto" Text="Return Home" />
        </form>
    </div>
</body>
</html>
