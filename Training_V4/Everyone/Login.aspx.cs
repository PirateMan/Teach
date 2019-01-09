using HashLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Everyone_Login : System.Web.UI.Page
{
    // --------------------------------------------------------------------------------------------------------------------------------------- //
    // ---------------------------------------------------     PAGE LOAD EVENT     ----------------------------------------------------------- //
    // --------------------------------------------------------------------------------------------------------------------------------------- //

    protected void Page_Load(object sender, EventArgs e)
    {
        //Page Load
    }

    // --------------------------------------------------------------------------------------------------------------------------------------- //
    // -------------------------------------------------     LOGIN AUTHENTICATION     -------------------------------------------------------- //
    // --------------------------------------------------------------------------------------------------------------------------------------- //

    protected void LoginControl_Authenticate(object sender, AuthenticateEventArgs e)
    {
        bool authenticated = this.ValidateCredentials(LoginControl.UserName, LoginControl.Password);

        if (authenticated)
        {
            FormsAuthentication.RedirectFromLoginPage(LoginControl.UserName, LoginControl.RememberMeSet);
        }
    }

    // --------------------------------------------------------------------------------------------------------------------------------------- //
    // ------------------------------------------------     ALPHANUMERIC FUNCTION     -------------------------------------------------------- //
    // --------------------------------------------------------------------------------------------------------------------------------------- //


    public bool IsAlphaNumeric(string text)
    {
        return Regex.IsMatch(text, "^[a-zA-Z0-9]+$");
    }


    // --------------------------------------------------------------------------------------------------------------------------------------- //
    // ---------------------------------------------------     MAIN VALIDATION     ----------------------------------------------------------- //
    // --------------------------------------------------------------------------------------------------------------------------------------- //


    private bool ValidateCredentials(string userName, string password)
    {
        bool returnValue = false;

        if (this.IsAlphaNumeric(userName) && userName.Length <= 50 && password.Length <= 50)
        {
            try
            {
                int selectCount = 0;
                string usernameInput = userName.Trim();
                string passwordInput = Hasher.HashString(password.Trim());

                using (TrainingDBEntities1 db = new TrainingDBEntities1())
                {
                    selectCount = (from o in db.Users
                                   where o.Username == usernameInput && o.Password == passwordInput
                                   select o).Count();
                }

                if (selectCount > 0)
                {
                    returnValue = true;
                }
            }
            catch (Exception ex)
            {
                //error
            }
        }
        else
        {
            // Error - not alphanumeric or too long
        }

        return returnValue;
    }
}