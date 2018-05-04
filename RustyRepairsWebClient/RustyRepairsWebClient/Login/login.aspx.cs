using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RustyRepairsWebClient;

public partial class index : System.Web.UI.Page
{
    ProgramServices services = new ProgramServices();

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Customer> custs = this.services.GetCustomerData();
        for (int i = 0; i < custs.Count; i++)
        {
            System.Diagnostics.Debug.WriteLine(custs[i].EmailAddress + ":" + custs[i].Password);
        }
    }

    // Method to control user logging into their account 
    public void Login(object sender, EventArgs e)
    {
        string userInputEmail = this.inputEmail.Text;
        string userInputPassword = this.inputPassword.Text;

        if (this.services.LoginDetailsCorrect(userInputEmail, userInputPassword))
        {
            // Log user into account
            Server.Transfer("~/CustomerHomepage/customerhomepage.aspx", true);
        }
        else
        {
            // Display failed login attempt
            System.Diagnostics.Debug.WriteLine("INCORRECT CREDENTIALS");
        }
    }

    // Method to take user to the page where they can create a new account
    public void CreateAccount(object sender, EventArgs e)
    {

    }
}