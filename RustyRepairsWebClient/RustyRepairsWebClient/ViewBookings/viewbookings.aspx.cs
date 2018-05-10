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
        this.selectedBookingIndex = -1;

        // Make all fields read-only initially
        this.time.Attributes.Add("readonly", "readonly");
        this.date.Attributes.Add("readonly", "readonly");
        this.problemSummary.Attributes.Add("readonly", "readonly");
        this.status.Attributes.Add("readonly", "readonly");

        // Append all customer booking data:
        this.AppendBookingDataToPage();
    }

    // Method to allow user to update the selected booking
    public void UpdateBooking(object sender, EventArgs e)
    {
        if (this.selectedBookingIndex != -1)
        {
            if (this.btnUpdate.Text == "Save Changes")
            {
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
                    this.btnUpdate.Text = "Update Selected Booking";

                    this.time.Attributes.Add("readonly", "readonly");
                    this.date.Attributes.Add("readonly", "readonly");
                    this.problemSummary.Attributes.Add("readonly", "readonly");
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
        else
        {
            // Inform the user they need to select a booking 
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Oops! Please select a booking to edit.')", true);
        }
    }

    // Method to allow the user to cancel the selected booking
    public void CancelBooking(object sender, EventArgs e)
    {
        if (this.selectedBookingIndex != -1)
        {
            this.currentCustomer.Bookings[this.selectedBookingIndex].Canceled = true;
        }
        else
        {
            // Inform the user they need to select a booking 
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Oops! Please select a booking to edit.')", true);
        }
    }

    // Method to allow the user to return home
    public void ReturnHome(object sender, EventArgs e)
    {
        Server.Transfer("~/CustomerHomepage/customerhomepage.aspx", true);
    }

    // Method to append all booking data from current customer to page
    private void AppendBookingDataToPage()
    {
        // ONLY APPEND DATA WHERE CANCELED == FASLE (DO NOT APPEND CANCELED BOOKINGS TO THE PAGE)
        this.time.Text = this.currentCustomer.Bookings[0].Time;
        this.date.Text = this.currentCustomer.Bookings[0].Date;
        this.problemSummary.Text = this.currentCustomer.Bookings[0].ProblemSummary;
        
        if (this.currentCustomer.Bookings[0].Pending)
        {
            this.status.Text = "Pending.";
        }
        else
        {
            if ((this.currentCustomer.Bookings[0].ManagerApproved) && !(this.currentCustomer.Bookings[0].ManagerDeclined))
            {
                this.status.Text = "Approved.";
            }
            else if ((this.currentCustomer.Bookings[0].ManagerDeclined) && !(this.currentCustomer.Bookings[0].ManagerApproved))
            {
                this.status.Text = "Declined.";
            }
        }
    }

    // Method to fetch new updated data from the page
    private string GetNewBookingData()
    {
        List<string> data = new List<string>();

        data.Add(Request[""]);
        data.Add(Request[""]);
        data.Add(Request[""]);

        return String.Join(";", data);
    }
}