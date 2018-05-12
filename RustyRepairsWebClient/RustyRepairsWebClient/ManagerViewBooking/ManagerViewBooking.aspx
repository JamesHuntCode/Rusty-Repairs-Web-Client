<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerViewBooking.aspx.cs" Inherits="ManagerViewBooking_ManagerViewBooking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" type="image/x-icon" href="~/images/favicon.png" />

    <!-- LINKS TO ALL CSS FILES & CDN's -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.0.10/css/all.css" />
    <link rel="stylesheet" runat="server" media="screen" href="~/css/style.css" />
</head>
<body oncontextmenu="return false">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
        <div class="container">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row mt-3">
                        <div class="col" style="border-width: 2px; border-style: solid">
                            <asp:Label ID="lblWorkplanInfo" runat="server" Text="Workplan Info" Font-Size="X-Large"></asp:Label>
                            <div class="input-group mb-3" style="width: 100%">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" style="width: 14vw" id="">Staff ID:</span>
                                </div>
                                <asp:TextBox ID="txtStaffID" type="text" class="form-control" runat="server" ReadOnly="True" />
                            </div>

                            <div class="input-group mb-3" style="width: 100%">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" style="width: 14vw" id="">Staff name:</span>
                                </div>
                                <asp:TextBox ID="txtStaffName" type="text" class="form-control" runat="server" ReadOnly="True" />
                            </div>

                            <div class="input-group mb-3" style="width: 100%">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" style="width: 14vw" id="">Workplan description:</span>
                                </div>
                                <asp:TextBox ID="txtWorkplanDesc" type="text" class="form-control" runat="server" TextMode="MultiLine" />
                            </div>
                        </div>
                        <div class="col" style="border-width: 2px; border-style: solid">
                            <asp:Label ID="lblBookingInfo" runat="server" Text="Booking Info" Font-Size="X-Large"></asp:Label>
                            <div class="input-group mb-3" style="width: 100%">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" style="width: 14vw" id="">First and Last name:</span>
                                </div>
                                <asp:TextBox ID="txtFirstName" type="text" class="form-control" runat="server" ReadOnly="True" />
                                <asp:TextBox ID="txtLastName" type="text" class="form-control" runat="server" ReadOnly="True" />
                            </div>

                            <div class="input-group mb-3" style="width: 100%">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" style="width: 14vw" id="">Booking date:</span>
                                </div>
                                <asp:TextBox ID="txtDate" type="text" class="form-control" runat="server" ReadOnly="True" />
                            </div>
                            <div class="input-group mb-3" style="width: 100%">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" style="width: 14vw" id="">Booking time:</span>
                                </div>
                                <asp:TextBox ID="txtTime" type="text" class="form-control" runat="server" ReadOnly="True" />
                            </div>
                            <div class="input-group mb-3" style="width: 100%">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" style="width: 14vw" id="">Owner name:</span>
                                </div>
                                <asp:TextBox ID="txtOwnerName" type="text" class="form-control" runat="server" ReadOnly="True" />
                            </div>

                            <div class="input-group mb-3" style="width: 100%">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" style="width: 14vw" id="">Vehicle make:</span>
                                </div>
                                <asp:TextBox ID="txtVehicleMake" type="text" class="form-control" runat="server" ReadOnly="True" />
                            </div>

                            <div class="input-group mb-3" style="width: 100%">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" style="width: 14vw" id="">Vehicle model:</span>
                                </div>
                                <asp:TextBox ID="txtVehicleModel" type="text" class="form-control" runat="server" ReadOnly="True" />
                            </div>

                            <div class="input-group mb-3" style="width: 100%">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" style="width: 14vw" id="">Vehicle registration:</span>
                                </div>
                                <asp:TextBox ID="txtVehicleReg" type="text" class="form-control" runat="server" ReadOnly="True" />
                            </div>

                            <div class="input-group mb-3" style="width: 100%">
                                <div class="input-group-prepend">
                                    <span class="input-group-text" style="width: 14vw" id="">Previous no show:</span>
                                </div>
                                <asp:TextBox ID="txtNoShow" type="text" class="form-control" runat="server" ReadOnly="True" />
                            </div>
                        </div>
                    </div>
                    <div class="row mt-3 mb-3 text-center">
                        <div class="col">
                            <asp:Button ID="btnBack" CssClass="btn-secondary" runat="server" Text="Back" />
                        </div>
                        <div class="col">
                            <asp:Button ID="btnEdit" CssClass="btn-warning" runat="server" Text="Edit" />
                        </div>
                        <div class="col">
                            <asp:Button ID="btnDelete" CssClass="btn-danger" runat="server" Text="Delete" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>

    <!-- ALL JAVASCRIPT CDN's NEEDED FOR BOOTSTRAP -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
</body>
</html>

