using RustyRepairsWebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerViewBooking_ManagerViewBooking : System.Web.UI.Page
{
    private ProgramServices services;
    private Workplan workplan;
    private Customer customer;
    private Booking booking;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.services = new ProgramServices();
        this.btnBack.Click += BtnBack_Click;
        this.btnEdit.Click += BtnEdit_Click;
        this.btnDelete.Click += BtnDelete_Click;

        this.txtWorkplanDesc.Attributes.Add("readonly", "readonly");

        this.customer = this.services.GetCustomerDataFromBookingID(int.Parse(Application["bookingID"].ToString()));
        this.workplan = this.services.Getworkplans().Find(wp => wp.WorkPlanID == int.Parse(Application["workplanID"].ToString()));
        this.booking = this.services.GetBookingFromWorkplan(workplan);
        this.txtFirstName.Text = customer.FirstName;
        this.txtLastName.Text = customer.LastName;
        this.txtDate.Text = booking.Date;
        this.txtTime.Text = workplan.Time;
        this.txtOwnerName.Text = customer.Vehicles[0].OwnerName;
        this.txtVehicleMake.Text = customer.Vehicles[0].CarMake;
        this.txtVehicleModel.Text = customer.Vehicles[0].CarModel;
        this.txtVehicleReg.Text = customer.Vehicles[0].CarRegistration;
        this.txtNoShow.Text = customer.HasMissedBooking.ToString();

        this.txtStaffID.Text = workplan.AssignedStaffMemberID.ToString();
        Staff staffMember = this.services.GetStaffData().Find(stf => stf.ID == workplan.AssignedStaffMemberID);
        this.txtStaffName.Text = staffMember.FirstName + " " + staffMember.LastName;

        if (!this.IsPostBack)
         this.txtWorkplanDesc.Text = booking.ProblemSummary;
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
        this.services.UpdateWorkplans(true, this.workplan);
        Response.Redirect("~/ManagerHomepage/ManagerHomepage.aspx", true);
    }

    private void BtnEdit_Click(object sender, EventArgs e)
    {
        if (this.btnEdit.Text == "Save")
        {
            this.btnEdit.Text = "Edit";
            this.services.UpdateBooking("update", this.booking, this.txtWorkplanDesc.Text);

            this.txtWorkplanDesc.Attributes.Add("readonly", "readonly");
            Response.Redirect(Request.Url.AbsolutePath);
        }
        else
        {
            this.btnEdit.Text = "Save";
            this.txtWorkplanDesc.Attributes.Remove("readonly");
        }
    }

    private void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ManagerHomepage/ManagerHomepage.aspx", true);
    }
}