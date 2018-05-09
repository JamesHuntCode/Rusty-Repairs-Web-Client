using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RustyRepairsWebClient;

public partial class CreateAccount_createaccount : System.Web.UI.Page
{
    ProgramServices services = new ProgramServices();

    protected void Page_Load(object sender, EventArgs e)
	{

	}

    // Method to create a new customer account
    public void CreateAccount(object sender, EventArgs e)
    {
        string customerData = this.GetCustomerData();

        if (this.services.DetailsAreValid(customerData))
        {
            if (!(this.services.AlreadyExists(customerData, false)))
            {
                // Update JSON data
                string[] breakdown = customerData.Split(';');

                Customer newCust = new Customer();

                // Base user properties
                newCust.FirstName = breakdown[0];
                newCust.LastName = breakdown[1];
                newCust.EmailAddress = breakdown[2];
                newCust.Password = breakdown[3];

                // Specific customer properies
                newCust.CustomerID = this.services.GetNewCustomerID();
                newCust.JoinDate = DateTime.Now.ToShortDateString();

                // Append data to JSON file
                this.services.WriteJSON(newCust, null);

                // Log user into account
                this.services.SetCurrentCustomerData(newCust);
                Server.Transfer("~/CustomerHomepage/customerhomepage.aspx", true);
            }
            else
            {
                // Display credentials are already taken
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('An account with these details already exists. Try logging back in')", true);
            }
        }
        else
        {
            // Display failed account creation attempt
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('One or more errors in your inputs. Please try again.')", true);
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

    // Method to take user to login page
    public void Login(object sender, EventArgs e)
    {
        Server.Transfer("~/Login/login.aspx", true);
    }
}