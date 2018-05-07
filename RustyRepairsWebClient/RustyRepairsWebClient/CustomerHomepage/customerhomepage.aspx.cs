using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RustyRepairsWebClient;

public partial class Customer_Homepage_customerhomepage : System.Web.UI.Page
{
    private ProgramServices services = new ProgramServices();
    public Customer currentCustomer;

	protected void Page_Load(object sender, EventArgs e)
	{

	}

    // Method to log customer out of their account
    public void Logout(object sender, EventArgs e)
    {
        Server.Transfer("~/Login/login.aspx", true);
    }

    // Method to allow the customer to request a booking
    public void CreateBooking()
    {

    }

    // Method to allow the customer to view their current bookings
    public void ViewBookings()
    {

    }

    // Method to allow the customer to edit their current bookings
    public void EditBooking()
    {

    }

    // Method to allow the customer to view their account details
    public void ViewAccount()
    {

    }

    // Method to allow the customer to edit their account details
    public void EditAccount()
    {

    }

    // Method to allow the customer to cancel an arranged booking
    public void CancelBooking()
    {

    }

    // Method to allow the customer to delete their account
    public void DeleteAccount()
    {
        if (!(this.currentCustomer.HasUpcomingBooking() && !(this.currentCustomer.HasMissedBooking)))
        {
            // Set account status to deactive & update.json data
            this.currentCustomer.HasActiveAccount = false;
            this.services.WriteJSON(this.currentCustomer, null);

            // Send the customer back to the login page
            Server.Transfer("~/Login/login.aspx", true);
        }
        else
        {
            // Alert the user they have outstanding payments
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unable to delete your account. You have outstanding payments or a due booking.')", true);
        }
    }
}