<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createvehicle.aspx.cs" Inherits="Create_Vehicle_createvehicle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rusty's Repairs - Add Vehicle</title>
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
                    <h2 class="ml-5">Add Vehicle</h2>
                </div>
            </div>
        </div>
        <form runat="server">
            <!-- Car Make and Model Box -->
            <div class="input-group mb-3 mt-5 mx-auto" style="width: 40vw">
                <div class="input-group-prepend">
                    <span class="input-group-text" style="width: 14vw" id="">Car Make and Model:</span>
                </div>
                <asp:TextBox ID="carMake" type="text" class="form-control" runat="server" />
                <asp:TextBox ID="carModel" type="text" class="form-control" runat="server" />
            </div>
            <!-- Car Registration Box -->
            <div class="input-group mb-3 mx-auto" style="width: 40vw">
                <div class="input-group-prepend ">
                    <span class="input-group-text" style="width: 14vw" id="inputGroup-sizing-default">Car Registration:</span>
                </div>
                <asp:TextBox runat="server" ID="registration" type="text" class="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default" />
            </div>
            <!-- Owner Details Box -->
            <div class="input-group mb-3 mx-auto" style="width: 40vw">
                <div class="input-group-prepend">
                    <span class="input-group-text" style="width: 14vw" id="inputGroup-sizing-default2">Owners Name:</span>
                </div>
                <asp:TextBox runat="server" ID="ownerName" type="text" class="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default2" />
            </div>
            <!-- Buttons To Add Vehicle Or Return To Account -->
            <asp:Button runat="server" ID="btnAddVehicle" OnClick="CreateVehicle" type="button" Style="width: 40vw" class="btn btn-outline-success btn-lg btn-block mx-auto mt-4" Text="Add Vehicle" />
            <p class="text-center mt-5" style="color: grey"><i>Already Added Your Vehicle To Your Account?</i></p>
            <asp:Button runat="server" ID="btnBack" OnClick="BackToAccount" type="button" Style="width: 27vw" class="btn btn-outline-info btn-lg btn-block mx-auto" Text="Back To Account Details" />
        </form>
    </div>
    <!-- ALL JAVASCRIPT CDN's NEEDED FOR BOOTSTRAP -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
</body>
</html>
