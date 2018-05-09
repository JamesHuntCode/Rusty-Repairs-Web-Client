using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RustyRepairsWebClient;

public partial class Create_Vehicle_createvehicle : System.Web.UI.Page
{
    private ProgramServices services = new ProgramServices();
    private Customer currentCustomer;

	protected void Page_Load(object sender, EventArgs e)
	{
        currentCustomer = this.services.GetCurrentCustomerData();
    }

    // Method to allow the customer to add a vehicle to their record
    public void CreateVehicle(object sender, EventArgs e)
    {

    }

    // Method to send the user back to their account
    public void BackToAccount(object sender, EventArgs e)
    {
        Server.Transfer("~/CustomerHomepage/customerhomepage.aspx", true);
    }

    private string GetVehicleData()
    {
        List<string> data = new List<string>();

        data.Add(Request["carMake"]);
        data.Add(Request["carModel"]);
        data.Add(Request["registration"]);
        data.Add(Request["ownerName"]);

        return String.Join(";", data);
    }
}