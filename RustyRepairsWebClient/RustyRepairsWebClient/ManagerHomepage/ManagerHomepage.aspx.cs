using RustyRepairsWebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerHomepage_ManagerHomepage : System.Web.UI.Page
{
    private ProgramServices services;
    private List<Booking> bookings;
    private int currentBookingNum;
    private DateTime currentDateFrame;

    protected void Page_Load(object sender, EventArgs e)
    {
        //I hate James' code
        this.lstBookings.Items.Clear();
        this.services = new ProgramServices();
        this.currentBookingNum = 0;
        this.bookings = services.GetCustomerBookingData();
        foreach (Booking booking in this.bookings)
        {
            Customer cust = this.services.GetCustomerDataFromBookingID(booking.BookingID);
            this.lstBookings.Items.Add(string.Format("{0}: {1}", cust.FirstName + " " + cust.LastName, booking.Date));
        }
        //for (int i = 0; i < 50; i++)
        //{
        //    this.lstBookings.Items.Add(i.ToString());
        //} //this.txtInput.Attributes.Add("readonly", "readonly");

        //    for (int y = 0; y < 9; y++)
        //    {
        //        TableRow tRow = new TableRow();
        //        this.calenderTable.Rows.Add(tRow);
        //        for (int x = 0; x < 7; x++)
        //        {
        //            TableCell tCell = new TableCell
        //            {
        //                Text = "Row " + y + ", Cell " + x
        //            };
        //            tCell.Style.Add("text-align", "center");
        //            tRow.Cells.Add(tCell);
        //        }
        //    }
        //    this.calenderTable.Rows[0].Cells[0].Text = "<";
        //    this.calenderTable.Rows[0].Cells[6].Text = ">";

        //    for (int x = 1; x <= 5; x++)
        //    {
        //        this.calenderTable.Rows[0].Cells[x].Text = Enum.Parse(typeof(DayOfWeek), x.ToString()).ToString();
        //    }
        //    TimeSpan time = new TimeSpan(9, 0, 0);
        //    for (int y = 1; y <= 8; y++)
        //    {
        //        this.calenderTable.Rows[y].Cells[0].Text = (time.Hours + ":00 - " + (time.Hours + 1) + ":00").ToString();
        //        time = time.Add(new TimeSpan(1, 0, 0));
        //    }
        //}
    }

    public void lstBookings_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = this.lstBookings.SelectedIndex;
        //if (index < 0 || index > this.bookings.Count)
        //    return;

        Booking booking = this.bookings[index];
        Customer cust = this.services.GetCustomerDataFromBookingID(booking.BookingID);
        this.txtFirstName.Text = cust.FirstName;
        this.txtLastName.Text = cust.LastName;
    }
}