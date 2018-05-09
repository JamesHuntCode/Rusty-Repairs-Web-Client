using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RustyRepairsWebClient;

public partial class ViewVehicle_viewvehicle : System.Web.UI.Page
{
    private ProgramServices services = new ProgramServices();
    private Customer currentCustomer;

    protected void Page_Load(object sender, EventArgs e)
    {
        currentCustomer = this.services.GetCurrentCustomerData();

        Vehicle vehicle = currentCustomer.Vehicles[0];

        // Post vehicle data in text boxes

    }

    // Method to send user back to their dashboard
    public void ReturnHome(object sender, EventArgs e)
    {
        Server.Transfer("~/CustomerHomepage/customerhomepage.aspx", true);
    }
}