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
        if (this.currentCustomer.Vehicles.Count > 0)
        {
            // Customer already has a vehicle registered
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, you already have a vehicle registered with us.')", true);
        }
        else
        {
            // Customer can now add their vehicle
            string vehicleData = this.GetVehicleData();

            if (this.services.VehicleDataIsValid(vehicleData))
            {
                // Customer vehicle data is valid
                Vehicle newVehicle = new Vehicle();

                newVehicle.CustomerID = this.currentCustomer.CustomerID;
                newVehicle.CarMake = vehicleData.Split(';')[0];
                newVehicle.CarModel = vehicleData.Split(';')[1];
                newVehicle.CarRegistration = vehicleData.Split(';')[2];
                newVehicle.OwnerName = vehicleData.Split(';')[3];

                // Update json data
                this.currentCustomer.Vehicles.Add(newVehicle);
                this.services.UpdateCustomerData(this.currentCustomer);
                this.services.SetCurrentCustomerData(this.currentCustomer);

                // Send user to the page where they can view their vehicle data
                Server.Transfer("~/ViewVehicle/viewvehicle.aspx", true);
            }
            else
            {
                // Customer vehicle data is not valid
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Oops! The data you have entered is not valid. Please try again.')", true);
            }
        }
    }

    // Method to send the user back to their account
    public void BackToAccount(object sender, EventArgs e)
    {
        Server.Transfer("~/AccountDetails/accountdetails.aspx", true);
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