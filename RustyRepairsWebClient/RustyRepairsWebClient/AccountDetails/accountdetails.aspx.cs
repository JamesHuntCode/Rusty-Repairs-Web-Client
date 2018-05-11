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
        this.customerID.Text = this.currentCustomer.CustomerID.ToString();
        this.firstName.Text = this.currentCustomer.FirstName;
        this.lastName.Text = this.currentCustomer.LastName;
        this.email.Text = this.currentCustomer.EmailAddress;
        this.dateJoined.Text = this.currentCustomer.JoinDate;

        this.password.Text = this.currentCustomer.Password;
        this.password.Attributes["type"] = "password";

        // Set all to read only initially
        this.customerID.Attributes.Add("readonly", "readonly");
        this.firstName.Attributes.Add("readonly", "readonly");
        this.lastName.Attributes.Add("readonly", "readonly");
        this.email.Attributes.Add("readonly", "readonly");
        this.dateJoined.Attributes.Add("readonly", "readonly");
        this.password.Attributes.Add("readonly", "readonly");
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
        if (this.btnUpdateDetails.Text == "Update Details")
        {
            // Change required text fields to editable
            this.firstName.Attributes.Remove("readonly");
            this.lastName.Attributes.Remove("readonly");
            this.email.Attributes.Remove("readonly");
            this.password.Attributes.Remove("readonly");

            this.btnUpdateDetails.Text = "Save Changes";
        }
        else
        {
            string customerData = this.GetCustomerData();

            if ((this.services.DetailsAreValid(customerData)) && !(this.services.AlreadyExists(customerData, true)))
            {
                // Save changes in data files
                this.currentCustomer.FirstName = customerData.Split(';')[0];
                this.currentCustomer.LastName = customerData.Split(';')[1];
                this.currentCustomer.EmailAddress = customerData.Split(';')[2];
                this.currentCustomer.Password = customerData.Split(';')[3];

                this.services.SetCurrentCustomerData(this.currentCustomer);
                this.services.UpdateCustomerData(this.currentCustomer);

                // Re-lock all inputs
                this.firstName.Attributes.Add("readonly", "readonly");
                this.lastName.Attributes.Add("readonly", "readonly");
                this.email.Attributes.Add("readonly", "readonly");
                this.password.Attributes.Add("readonly", "readonly");

                this.btnUpdateDetails.Text = "Update Details";

                Server.TransferRequest(Request.Url.AbsolutePath, false);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('One or more errors in your inputs or those details already exist within our system. Please try again.')", true);

                // Ensure text fields remain active until conditions have been met
                this.firstName.Attributes.Remove("readonly");
                this.lastName.Attributes.Remove("readonly");
                this.email.Attributes.Remove("readonly");
                this.password.Attributes.Remove("readonly");
            }
        }
    }

    // Method to fetch customer account data from page
    private string GetCustomerData()
    {
        List<string> data = new List<string>();

        data.Add(Request["firstName"]);
        data.Add(Request["lastName"]);
        data.Add(Request["email"]);
        data.Add(Request["password"]);

        return String.Join(";", data);
    }

    // Method to send user to page where they can view their vehicle details
    public void ViewVehicleDetails(object sender, EventArgs e)
    {   
        if ((this.currentCustomer.Vehicles.Count) > 0 && !(this.currentCustomer.Bookings == null))
        {
            Server.Transfer("~/ViewVehicle/viewvehicle.aspx", true);
        }
        else
        {
            // Alert the user that they do not have a registered vehicle on their account
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You don't have a registered vehicle. Pleade add one to your account.')", true);
        }
    }
}