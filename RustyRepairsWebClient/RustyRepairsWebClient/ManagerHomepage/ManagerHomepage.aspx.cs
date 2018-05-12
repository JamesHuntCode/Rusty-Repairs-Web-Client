using RustyRepairsWebClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerHomepage_ManagerHomepage : System.Web.UI.Page
{
    private ProgramServices services;
    private List<Booking> bookings;
    private DateTime startOfWeek;
    private List<Staff> staffMembers;

    protected void Page_Load(object sender, EventArgs e)
    {
        //I hate James' code
        this.services = new ProgramServices();
        this.bookings = services.GetCustomerBookingData().Where(booking => booking.Pending).ToList();
        this.staffMembers = this.services.GetStaffData();
        if (!IsPostBack)
        {
            foreach (Booking booking in this.bookings)
            {
                Customer cust = this.services.GetCustomerDataFromBookingID(booking.BookingID);
                this.lstBookings.Items.Add(string.Format("{0}: {1}", cust.FirstName + " " + cust.LastName, booking.Date));
            }
            foreach (Staff staff in this.staffMembers)
            {
                this.lstStaff.Items.Add(string.Format("{0}: {1}", staff.FirstName + " " + staff.LastName, staff.ID));
            }
        }

        this.lstBookings.Attributes.Add("ondblclick", ClientScript.GetPostBackEventReference(this.lstBookings, "move"));
        this.lstStaff.Attributes.Add("ondblclick", ClientScript.GetPostBackEventReference(this.lstStaff, "move"));

        if (ViewState["date"] != null)
        {
            this.startOfWeek = DateTime.Parse(ViewState["date"].ToString());
        }
        else
        {
            //assign a value to the stateValue
            int delta = DayOfWeek.Monday - DateTime.Now.DayOfWeek;
            DateTime monday = DateTime.Now.AddDays(delta);
            this.startOfWeek = monday;
        }

        this.drawTable();
    }

    private void NextWeek_Click(object sender, EventArgs e)
    {
        this.startOfWeek = this.startOfWeek.AddDays(7);
        this.calenderTable.Rows[0].Cells[0].Text = "Date: " + this.startOfWeek.ToLongDateString() + " Week: " + GetWeekOfYear(this.startOfWeek);
        this.drawTable();
    }

    private void PreviousWeek_Click(object sender, EventArgs e)
    {
        this.startOfWeek = this.startOfWeek.AddDays(-7);
        this.calenderTable.Rows[0].Cells[0].Text = "Date: " + this.startOfWeek.ToLongDateString() + " Week: " + GetWeekOfYear(this.startOfWeek);
        this.drawTable();
    }

    private void drawTable()
    {
        this.calenderTable.Rows.Clear();
        TableRow row = new TableRow();
        TableCell cell = new TableCell();
        cell.Style.Add("text-align", "center");
        cell.Text = "Date: " + this.startOfWeek.ToLongDateString() + " Week: " + GetWeekOfYear(this.startOfWeek);
        cell.ColumnSpan = 8;
        row.Cells.Add(cell);
        this.calenderTable.Rows.Add(row);

        List<Workplan> workplans = this.services.Getworkplans();
        TimeSpan timeHours = new TimeSpan(8, 0, 0);
        for (int y = 1; y < 10; y++)
        {
            TableRow tRow = new TableRow();
            this.calenderTable.Rows.Add(tRow);
            for (int x = 0; x < 6; x++)
            {
                //Button addWorkPlan = new Button();
                //addWorkPlan.Click += AddWorkPlan_Click;
                //addWorkPlan.CssClass = "btn-success";
                //addWorkPlan.Text = "Allocate";

                TableCell tCell = new TableCell();

                if (x != 0 && y != 1)
                {
                    Workplan workplanTime = workplans.Find(workplan => {
                        if (DateTime.Parse(workplan.Date) == this.startOfWeek.AddDays(x - 1).Date &&
                            (timeHours.TotalHours).ToString() + ":00" == workplan.Time)
                            return true;

                        return false;
                        });

                    //Booking booking = null;
                    //if (workplanTime != null)
                    //    booking = this.services.GetBookingFromWorkplan(workplanTime);

                    Button btnCell = new Button();
                    if (workplanTime != null)
                    {
                        btnCell.Attributes.Add("date", this.startOfWeek.AddDays(x - 1).Date.ToString());
                        btnCell.Attributes.Add("time", (timeHours.TotalHours).ToString());
                        btnCell.Attributes.Add("workplanID", workplanTime.WorkPlanID.ToString());
                        btnCell.Attributes.Add("bookingID", workplanTime.BookingID.ToString());
                        btnCell.Attributes.Add("staffID", workplanTime.AssignedStaffMemberID.ToString());
                        btnCell.Click += viewWorkPlan_Click;
                        btnCell.CssClass = "btn-warning";
                        btnCell.Text = "View";
                    }
                    else
                    {
                        btnCell.Attributes.Add("date", this.startOfWeek.AddDays(x - 1).Date.ToString());
                        btnCell.Attributes.Add("time", (timeHours.TotalHours).ToString());

                        btnCell.Click += AddWorkPlan_Click;
                        btnCell.CssClass = "btn-success";
                        btnCell.Text = "Allocate";
                    }
                    tCell.Controls.Add(btnCell);
                }
                tCell.Style.Add("text-align", "center");

                tRow.Cells.Add(tCell);
            }
            timeHours = timeHours.Add(new TimeSpan(1, 0, 0));
        }

        Button previousWeek = new Button();
        previousWeek.Click += PreviousWeek_Click;
        previousWeek.CssClass = "btn-secondary";
        previousWeek.Text = "Previous";

        Button nextWeek = new Button();
        nextWeek.Click += NextWeek_Click;
        nextWeek.CssClass = "btn-secondary";
        nextWeek.Text = "Next";

        this.calenderTable.Rows[1].Cells[0].Controls.Add(previousWeek);
        this.calenderTable.Rows[1].Cells.Add(new TableCell());
        this.calenderTable.Rows[1].Cells[6].Controls.Add(nextWeek);

        for (int x = 1; x <= 5; x++)
        {
            this.calenderTable.Rows[1].Cells[x].Text = this.startOfWeek.AddDays(x - 1).ToShortDateString() + " " + Enum.Parse(typeof(DayOfWeek), x.ToString()).ToString();
        }
        TimeSpan time = new TimeSpan(9, 0, 0);
        for (int y = 2; y <= 9; y++)
        {
            this.calenderTable.Rows[y].Cells[0].Text = (time.Hours + ":00 - " + (time.Hours + 1) + ":00").ToString();
            time = time.Add(new TimeSpan(1, 0, 0));
        }
    }

    private void btnDeclineBooking_Click(object sender, EventArgs e)
    {
        int index = this.lstBookings.SelectedIndex;
        if (index < 0 || index > this.bookings.Count)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select a booking')", true);
            return;
        }
        Booking booking = this.bookings[index];
        this.services.UpdateBooking("NAH", booking);
        Response.Redirect(Request.RawUrl);
    }

    private void AddWorkPlan_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        DateTime date = DateTime.Parse(button.Attributes["date"].ToString());
        int hours = int.Parse(button.Attributes["time"].ToString());

        int index = this.lstBookings.SelectedIndex;
        if (index < 0 || index > this.bookings.Count)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select a booking')", true);
            return;
        }

        Booking booking = this.bookings[index];
        if (booking.Date != date.ToShortDateString())
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", string.Format("alert('Booking requested for {0}, please select a time within this date')", booking.Date), true);
            return;
        }

        index = this.lstStaff.SelectedIndex;
        if (index < 0 || index > this.staffMembers.Count)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please selected a staff member')", true);
            return;
        }

        Staff stf = this.staffMembers[index];
        if (stf.BusyDates.Contains(date.Date.ToShortDateString()))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry this staff member is unavailable on this day')", true);
            return;
        }

        Workplan workplan = new Workplan()
        {
            WorkPlanID = this.services.GetNewWorkPlanID(),
            BookingID = booking.BookingID,
            AssignedStaffMemberID = stf.ID,
            Date = date.ToShortDateString(),
            Time = (hours.ToString() + ":00"),
        };
        this.services.UpdateBooking("Approve", booking);
        this.services.UpdateWorkplans(false, workplan);
        Response.Redirect(Request.RawUrl);
    }

    private void viewWorkPlan_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        DateTime date = DateTime.Parse(button.Attributes["date"].ToString());
        int hours = int.Parse(button.Attributes["time"].ToString());
        string workplanID = button.Attributes["workplanID"];
        string staffID = button.Attributes["staffID"];
        string bookingID = button.Attributes["bookingID"];

        Application["workplanID"] = workplanID;
        Application["staffID"] = staffID;
        Application["bookingID"] = bookingID;

        Response.Redirect("~/ManagerViewBooking/ManagerViewBooking.aspx", true);
    }

    public void lstBookings_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = this.lstBookings.SelectedIndex;
        if (index < 0 || index > this.bookings.Count)
            return;

        Booking booking = this.bookings[index];
        Customer cust = this.services.GetCustomerDataFromBookingID(booking.BookingID);
        this.txtFirstName.Text = cust.FirstName;
        this.txtLastName.Text = cust.LastName;
        this.txtDate.Text = booking.Date;
        this.txtOwnerName.Text = cust.Vehicles[0].OwnerName;
        this.txtVehicleMake.Text = cust.Vehicles[0].CarMake;
        this.txtVehicleModel.Text = cust.Vehicles[0].CarModel;
        this.txtVehicleReg.Text = cust.Vehicles[0].CarRegistration;
        this.txtNoShow.Text = cust.HasMissedBooking.ToString();

        //Workplan workplan =
    }

    public int GetWeekOfYear(DateTime time)
    {
        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
        System.Globalization.Calendar cal = dfi.Calendar;
        return cal.GetWeekOfYear(time, dfi.CalendarWeekRule, DayOfWeek.Monday);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState.Add("date", this.startOfWeek);
    }
}