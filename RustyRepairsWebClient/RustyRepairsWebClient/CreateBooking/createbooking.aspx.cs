﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RustyRepairsWebClient;

public partial class CreateBooking_createbooking : System.Web.UI.Page
{
    private ProgramServices services = new ProgramServices();
    private Customer currentCustomer;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.currentCustomer = this.services.GetCurrentCustomerData();

        // Output a couple of placeholders to show user what format to use
        this.time.Text = DateTime.Now.ToShortTimeString();
        this.date.Text = DateTime.Now.ToShortDateString();
    }
    
    // Method to validate booking and send user to their upcoming bookings page
    public void CreateBooking(object sender, EventArgs e)
    {
        string bookingData = this.GetBookingData();

        if ((this.services.DateAndTimeInputsAreValid(bookingData)) && !(bookingData[2].Equals(String.Empty)))
        {
            if (this.services.BookingHasEnoughNotice(bookingData.Split(';')[1]))
            {
                if (this.currentCustomer.HasMissedBooking)
                {
                    // Alert the user they will need to pay upfront if they have missed a previous booking or canceled without enough notice
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Due to your payment history, payment will be taken upfront.')", true);
                }

                Booking newBooking = new Booking();

                // Set booking data
                newBooking.CustomerID = this.currentCustomer.CustomerID;
                newBooking.BookingID = this.services.GetNewBookingID();

                newBooking.Pending = true;
                newBooking.ManagerApproved = false;
                newBooking.Completed = false;

                newBooking.Time = bookingData.Split(';')[0];
                newBooking.Date = bookingData.Split(';')[1];
                newBooking.ProblemSummary = bookingData.Split(';')[2];

                // Update customer json data
                this.currentCustomer.Bookings.Add(newBooking);
                this.services.UpdateCustomerData(this.currentCustomer);
                this.services.SetCurrentCustomerData(this.currentCustomer);

                // Send user to page where they can view their bookings
                Server.Transfer("~/ViewBookings/viewbookings.aspx", true);
            }
            else
            {
                // Display the booking doesn't have enough notice
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('That time does not allow the garage manager enough notice. Please try again.')", true);
            }
        }
        else
        {
            // Display the booking data input was invalid
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('One or more errors in your inputs. Please try again.')", true);
        }
    }

    // Method used to fetch data from input boxes
    private string GetBookingData()
    {
        List<string> data = new List<string>();

        data.Add(Request["time"]);
        data.Add(Request["date"]);
        data.Add(Request["problemSummary"]);

        return String.Join(";", data);
    }
}