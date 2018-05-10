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
    private int selectedBookingIndex;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.currentCustomer = this.services.GetCurrentCustomerData();
        this.selectedBookingIndex = 0;

        // Make all fields read-only initially
        this.time.Attributes.Add("readonly", "readonly");
        this.date.Attributes.Add("readonly", "readonly");
        this.problemSummary.Attributes.Add("readonly", "readonly");
        this.status.Attributes.Add("readonly", "readonly");

        // Append booking data to form
        this.AppendBookingDataToPage(this.selectedBookingIndex);
    }

    // Method to allow user to update the selected booking
    public void UpdateBooking(object sender, EventArgs e)
    {
        if (this.btnUpdate.Text == "Save Changes")
        {
            this.btnUpdate.Text = "Update Booking";
            string newBookingData = this.GetNewBookingData();

            if ((this.services.DateAndTimeInputsAreValid(newBookingData)) && !(newBookingData[2].Equals(String.Empty)))
            {
                // Update JSON data
                this.currentCustomer.Bookings[this.selectedBookingIndex].Time = newBookingData.Split(';')[0];
                this.currentCustomer.Bookings[this.selectedBookingIndex].Date = newBookingData.Split(';')[1];
                this.currentCustomer.Bookings[this.selectedBookingIndex].ProblemSummary = newBookingData.Split(';')[2];

                this.services.SetCurrentCustomerData(this.currentCustomer);
                this.services.UpdateCustomerData(this.currentCustomer);

                // Re-lock all text input fields
                this.time.Attributes.Add("readonly", "readonly");
                this.date.Attributes.Add("readonly", "readonly");
                this.problemSummary.Attributes.Add("readonly", "readonly");

                // Reload page
                Server.TransferRequest(Request.Url.AbsolutePath, false);
            }
            else
            {
                // Alert user that their inputs are not valid
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Oops! One or more of your inputs isn't valid. Please try again.')", true);
            }
        }
        else
        {
            // Allow user to make changes to the data
            this.btnUpdate.Text = "Save Changes";

            this.time.Attributes.Remove("readonly");
            this.date.Attributes.Remove("readonly");
            this.problemSummary.Attributes.Remove("readonly");
        }       
    }

    // Method to allow the user to cancel the selected booking
    public void CancelBooking(object sender, EventArgs e)
    {
        // CHECK DATES (SET CUSTOMER TO BAD IF THEY CANCEL WITHIN A WEEK)
        this.currentCustomer.Bookings[this.selectedBookingIndex].Canceled = true;
    }

    // Method to allow the user to return home
    public void ReturnHome(object sender, EventArgs e)
    {
        Server.Transfer("~/CustomerHomepage/customerhomepage.aspx", true);
    }

    // Method to append all booking data from current customer to page
    private void AppendBookingDataToPage(int index)
    {
        this.time.Text = this.currentCustomer.Bookings[index].Time;
        this.date.Text = this.currentCustomer.Bookings[index].Date;
        this.problemSummary.Text = this.currentCustomer.Bookings[index].ProblemSummary;
        
        if (this.currentCustomer.Bookings[index].Pending)
        {
            this.status.Text = "Pending.";
        }
        else
        {
            if ((this.currentCustomer.Bookings[index].ManagerApproved) && !(this.currentCustomer.Bookings[index].ManagerDeclined))
            {
                this.status.Text = "Approved.";
            }
            else if ((this.currentCustomer.Bookings[index].ManagerDeclined) && !(this.currentCustomer.Bookings[index].ManagerApproved))
            {
                this.status.Text = "Declined.";
            }
        }
    }

    // Method to fetch new updated data from the page
    private string GetNewBookingData()
    {
        List<string> data = new List<string>();

        data.Add(Request["time"]);
        data.Add(Request["date"]);
        data.Add(Request["problemSummary"]);

        return String.Join(";", data);
    }
}