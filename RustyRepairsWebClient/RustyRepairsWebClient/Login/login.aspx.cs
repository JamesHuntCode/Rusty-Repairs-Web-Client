using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Method to control user logging into their account 
    public void Login(object sender, EventArgs e)
    {
        string userInputUsername = this.inputEmail.Text;
        string userInputPassword = this.inputPassword.Text;

        
    }

    // Method to take user to the page where they can create a new account
    public void CreateAccount(object sender, EventArgs e)
    {

    }
}