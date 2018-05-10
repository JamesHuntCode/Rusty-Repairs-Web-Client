using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RustyRepairsWebClient;

public partial class ViewBookings_viewbookings : System.Web.UI.Page
{
    private ProgramServices services = new ProgramServices();
    private Customer currentCustomer;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.currentCustomer = this.services.GetCurrentCustomerData();

        // Make all fields read-only initially
        this.time.Attributes.Add("readonly", "readonly");
        this.date.Attributes.Add("readonly", "readonly");
        this.problemSummary.Attributes.Add("readonly", "readonly");

        // Append all customer booking data:
        this.AppendBookingDataToPage();
    }

    // Method to allow user to update the selected booking
    public void UpdateBooking(object sender, EventArgs e)
    {

    }

    // Method to allow the user to cancel the selected booking
    public void CancelBooking(object sender, EventArgs e)
    {

    }

    // Method to allow the user to return home
    public void ReturnHome(object sender, EventArgs e)
    {
        Server.Transfer("~/CustomerHomepage/customerhomepage.aspx", true);
    }

    // Method to append all booking data from current customer to page
    private void AppendBookingDataToPage()
    {
        this.time.Text = this.currentCustomer.Bookings[0].Time;
        this.date.Text = this.currentCustomer.Bookings[0].Date;
        this.problemSummary.Text = this.currentCustomer.Bookings[0].ProblemSummary;
    }
}