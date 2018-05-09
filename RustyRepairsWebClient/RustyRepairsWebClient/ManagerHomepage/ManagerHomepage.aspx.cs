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
        this.services = new ProgramServices();
        this.currentBookingNum = 0;
        this.bookings = services.GetCustomerBookingData();
        this.currentDateFrame = DateTime.Now;

        for (int y = 0; y < 9; y++)
        {
            TableRow tRow = new TableRow();
            this.calenderTable.Rows.Add(tRow);
            for (int x = 0; x < 7; x++)
            {
                TableCell tCell = new TableCell
                {
                    Text = "Row " + y + ", Cell " + x
                };
                tCell.Style.Add("text-align", "center");
                tRow.Cells.Add(tCell);
            }
        }
        this.calenderTable.Rows[0].Cells[0].Text = "<";
        this.calenderTable.Rows[0].Cells[6].Text = ">";

        for (int x = 1; x <= 5; x++)
        {
            this.calenderTable.Rows[0].Cells[x].Text = Enum.Parse(typeof(DayOfWeek), x.ToString()).ToString();
        }
        TimeSpan time = new TimeSpan(9, 0, 0);
        for (int y = 1; y <= 8; y++)
        {
            this.calenderTable.Rows[y].Cells[0].Text = (time.Hours + ":00 - " + (time.Hours + 1) + ":00").ToString();
            time = time.Add(new TimeSpan(1, 0, 0));
        }

        this.NextBooking(null, null);
    }

    public void NextBooking(object sender, EventArgs e)
    {
        Booking booking = this.bookings[this.currentBookingNum];
        Customer customer = this.services.GetCustomerDataFromBookingID(booking.BookingID);
        this.firstNameLastName.InnerText = string.Format("First name & Last name: {0} {1}", customer.FirstName, customer.LastName);
        this.requestDate.InnerText = string.Format("Booking request time: {0}", booking.Date);
        this.previousNoShow.InnerText = string.Format("Previous no show: {0}", customer.HasMissedBooking);

        this.currentBookingNum++;
        if (this.currentBookingNum > this.bookings.Count)
            this.currentBookingNum = 0;
    }

    public void PreviousBooking(object sender, EventArgs e)
    {
        Booking booking = this.bookings[this.currentBookingNum];
        Customer customer = this.services.GetCustomerDataFromBookingID(booking.BookingID);
        this.firstNameLastName.InnerText = string.Format("First name & Last name: {0} {1}", customer.FirstName, customer.LastName);
        this.requestDate.InnerText = string.Format("Booking request time: {0}", booking.Date);
        this.previousNoShow.InnerText = string.Format("Previous no show: {0}", customer.HasMissedBooking);

        this.currentBookingNum--;
        if (this.currentBookingNum < 0)
            this.currentBookingNum = this.bookings.Count;
    }
}