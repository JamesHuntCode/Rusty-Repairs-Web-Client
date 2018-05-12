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
        this.currentCustomer = this.services.GetCurrentCustomerData();
	}

    // Method to log customer out of their account
    public void Logout(object sender, EventArgs e)
    {
        Server.Transfer("~/Login/login.aspx", true);
    }

    // Method to allow the customer to request a booking
    public void CreateBooking(object sender, EventArgs e)
    {
        if (this.currentCustomer.Vehicles.Count > 0)
        {
            if (this.currentCustomer.Bookings.Count == 0)
            {
                Server.Transfer("~/CreateBooking/createbooking.aspx", true);
            }
            else
            {
                // Alert the user they already have a booking
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You already have an active booking. You cannot request another.')", true);
            }
        }
        else
        {
            // Alert the user they don't have a recorded vehicle to create a booking with
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please add a vehicle to your account and then request a booking again.')", true);
        }
    }

    // Method to allow the customer to view their current bookings
    public void ViewBookings(object sender, EventArgs e)
    {
        if ((this.currentCustomer.Vehicles.Count > 0) && !(this.currentCustomer.GetAllCustomerBookings("upcoming").Count == 0))
        {
            Server.Transfer("~/ViewBookings/viewbookings.aspx", true);
        }
        else
        {
            // Alert the user they don't have any upcoming bookings to view
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You do not have any upcoming bookings.')", true);
        }
    }

    // Method to allow the customer to edit their current bookings
    public void EditBooking(object sender, EventArgs e)
    {
        if ((this.currentCustomer.Vehicles.Count > 0) && !(this.currentCustomer.GetAllCustomerBookings("upcoming").Count == 0))
        {
            Server.Transfer("~/ViewBookings/viewbookings.aspx", true);
        }
        else
        {
            // Alert the user they don't have any upcoming bookings to edit
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You do not have any upcoming bookings to update.')", true);
        }
    }

    // Method to allow the customer to edit their account details
    public void EditAccount(object sender, EventArgs e)
    {
        Server.Transfer("~/AccountDetails/accountdetails.aspx", true);
    }

    // Method to allow the customer to cancel an arranged booking
    public void CancelBooking(object sender, EventArgs e)
    {
        if ((this.currentCustomer.Vehicles.Count > 0) && !(this.currentCustomer.GetAllCustomerBookings("upcoming").Count == 0))
        {
            Server.Transfer("~/ViewBookings/viewbookings.aspx", true);
        }
        else
        {
            // Alert the user they don't have a recorded vehicle
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You do not have any upcoming bookings to cancel.')", true);
        }
    }

    // Method to allow the customer to delete their account
    public void DeleteAccount(object sender, EventArgs e)
    {
        if (!(this.currentCustomer.HasUpcomingBooking() && !(this.currentCustomer.HasMissedBooking)))
        {
            // Alert the user that their account is being deleted
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your account is being deleted. This action is not reversible.')", true);

            // Set account status to deactive & update.json data
            this.currentCustomer.HasActiveAccount = false;

            this.services.SetCurrentCustomerData(this.currentCustomer);
            this.services.UpdateCustomerData(this.currentCustomer);

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