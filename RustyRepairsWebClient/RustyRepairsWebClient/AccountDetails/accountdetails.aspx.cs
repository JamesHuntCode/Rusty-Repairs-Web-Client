using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RustyRepairsWebClient;

public partial class Account_Details_accountdetails : System.Web.UI.Page
{
    ProgramServices services = new ProgramServices();
    Customer currentCustomer;

	protected void Page_Load(object sender, EventArgs e)
	{
        currentCustomer = this.services.GetCurrentCustomerData();

        // Load current details into text fields

	}

    // Method to send the user back to the home page
    public void ReturnHome(object sender, EventArgs e)
    {
        Server.Transfer("~/CustomerHomepage/customerhomepage.aspx", true);
    }

    // Method to send user to the page where they can add a vehicle to their account
    public void AddVehicle(object sender, EventArgs e)
    {
        Server.Transfer("~/CreateVehicle/createvehicle.aspx", true);
    }

    // Method to allow user to update their details held within our system
    public void EditSaveDetails(object sender, EventArgs e)
    {
        
    }

    // Method to send user to page where they can view their vehicle details
    public void ViewVehicleDetails(object sender, EventArgs e)
    {
        Server.Transfer("~/ViewVehicle/viewvehicle.aspx", true);
    }
}