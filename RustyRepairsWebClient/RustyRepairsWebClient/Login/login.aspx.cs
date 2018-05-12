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
        
    }

    // Method to control user logging into their account 
    public void Login(object sender, EventArgs e)
    {
        string userInputEmail = this.inputEmail.Text;
        string userInputPassword = this.inputPassword.Text;

        if ((userInputEmail == "ADMIN") && (userInputPassword == "ADMIN"))
        {
            // Send Garage Manager to their homepage
            Server.Transfer("~/ManagerHomepage/ManagerHomepage.aspx", true);
        }
        else if (this.services.LoginDetailsCorrect(userInputEmail, userInputPassword))
        {
            // Log user into account
            Customer cust = this.services.GetAllDetails(userInputEmail + ";" + userInputPassword);
            this.services.SetCurrentCustomerData(cust);

            if (cust.HasActiveAccount)
            {
                
                Server.Transfer("~/CustomerHomepage/customerhomepage.aspx", true);
            }
            else
            {
                // Alert the user their account has been deactivated
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry! That account has been deactivated. Please create a new one.')", true);
            }
        }
        else
        {
            // Display failed login attempt
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your email or password is incorrect. Please try again.')", true);
        }
    }

    // Method to take user to the page where they can create a new account
    public void CreateAccount(object sender, EventArgs e)
    {
        Server.Transfer("~/CreateAccount/createaccount.aspx", true);
    }
}