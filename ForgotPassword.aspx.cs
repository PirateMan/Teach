using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Net.Mail;
using HashLibrary;

public partial class ForgotPassword : System.Web.UI.Page
{

    SqlCommand cmd;
    DataTable dt;
    SqlConnection con = new SqlConnection();
    SqlDataAdapter adp;

    // --------------------------------------------------------------------------------------------------------------------------------------- //
    //                                                          PAGE LOAD                                                                      //
    // --------------------------------------------------------------------------------------------------------------------------------------- //

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            afterEmail.Visible = false;
            afterConfirm.Visible = false;
        }

        con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["ServerBUConString"].ConnectionString;
        con.Open();

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
    }

    // --------------------------------------------------------------------------------------------------------------------------------------- //
    //                                                    RESET BUTTON CLICK                                                                   //
    // --------------------------------------------------------------------------------------------------------------------------------------- //


    protected void resetButtonIn_Click(object sender, EventArgs e)
    {

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        try
        {
            adp = new SqlDataAdapter("SELECT UserName, Email FROM dbo.TrainingPackage_User WHERE Email = @email AND UserName = @uname", con);
            adp.SelectCommand.Parameters.AddWithValue("@email", EmailTextBox.Text);
            adp.SelectCommand.Parameters.AddWithValue("@uname", userTextBox.Text);

            dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                lbl_msg.Text = "Email address or Username incorrect";
                EmailTextBox.Text = "";
                userTextBox.Text = "";
                return;
            }
            else
            {
                // create code
                string code;
                code = Guid.NewGuid().ToString();
                
                // update sql
                cmd = new SqlCommand("UPDATE dbo.TrainingPackage_User SET PasswordResetCode = @code WHERE Email = @email AND UserName = @uname", con);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@email", EmailTextBox.Text);
                cmd.Parameters.AddWithValue("@uname", userTextBox.Text);

                // compose email with code to be sent
                CreateEmailMessage("excas-l1.ulh.xlincs.nhs.uk", EmailTextBox.Text, userTextBox.Text, code);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

                // set current user
                currentUser.user = userTextBox.Text;

                // reset fields and alert user
                lbl_msg.Text = "Code has been sent to your email address";
                EmailTextBox.Text = "";
                userTextBox.Text = "";

                // show next stage
                beforeEmail.Visible = false;
                afterEmail.Visible = true;
            }
        }
        catch (Exception ex)
        {
            //display error
            lbl_msg.Text = ex.Message;
        }
        finally
        {
            con.Close();
        }

    }


    // --------------------------------------------------------------------------------------------------------------------------------------- //
    //                                                      SEND EMAIL TO USER                                                                 //
    // --------------------------------------------------------------------------------------------------------------------------------------- //

    public static void CreateEmailMessage(string server, string email, string username, string code)
    {
        string to = email;
        string from = "no-reply@trainingpackage.uk";
        MailMessage message = new MailMessage(from, to);
        message.Subject = "Training Package Password Reset";
        message.Body = 
        @" Reset Details
                          
        User:    {0}
        Email:    {1}
        Reset Code:    {2}

        Do not reply to this message.
        Sent from Training Package Web App.".Replace("{0}", username).Replace("{1}", email).Replace("{2}", code);

        SmtpClient client = new SmtpClient(server);
        // Credentials are necessary if the server requires the client 
        // to authenticate before it will send e-mail on the client's behalf.
        client.UseDefaultCredentials = true;
        client.EnableSsl = true;
        client.Send(message);
    }


    // --------------------------------------------------------------------------------------------------------------------------------------- //
    //                                                      CODE VALIDATION CLICK                                                              //
    // --------------------------------------------------------------------------------------------------------------------------------------- //


    protected void codeButtonIn_Click(object sender, EventArgs e)
    {
        //get current user who has requested password recovery code
        string username = currentUser.user;

        string checkCode = "SELECT COUNT(*) FROM dbo.TrainingPackage_User " +
                           "WHERE dbo.TrainingPackage_User.UserName = @user AND dbo.TrainingPackage_User.PasswordResetCode = @code";

        int confirm = 0;

        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ServerBUConString"].ConnectionString))
        {
            con.Open();

            using (SqlCommand cmd = new SqlCommand(checkCode, con))
            {
                cmd.Parameters.Add("@user", SqlDbType.NVarChar, 100).Value = username;
                cmd.Parameters.Add("@code", SqlDbType.NVarChar, 500).Value = codeTextBox.Text;
                confirm = (int)cmd.ExecuteScalar();
            }

            con.Close();
        }

        if (confirm > 0)
        {
            //user code is valid show next stage
            afterEmail.Visible = false;
            afterConfirm.Visible = true;
        }
        else
        {
            //invalid code
            error_msg.Text = "Invalid Code";
        }
    }


    // --------------------------------------------------------------------------------------------------------------------------------------- //
    //                                                CONFIRM NEW PASSWORD CLICK                                                               //
    // --------------------------------------------------------------------------------------------------------------------------------------- //


    protected void ConfirmButtonIn_Click(object sender, EventArgs e)
    {
        string newPwd = newPass.Text;

        string cUser = currentUser.user;

        string updatePassword = "UPDATE dbo.TrainingPackage_User SET Password = @pwd, PasswordResetCode = @code WHERE dbo.TrainingPackage_User.UserName = @username";

        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ServerBUConString"].ConnectionString))
        {
            con.Open();

            using (SqlCommand cmd = new SqlCommand(updatePassword, con))
            {
                cmd.Parameters.Add("@pwd", SqlDbType.NVarChar, 100).Value = Hasher.HashString(newPwd);
                cmd.Parameters.Add("@code", SqlDbType.NVarChar, 100).Value = "no code";
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = cUser;
                cmd.ExecuteNonQuery();
            }
                con.Close();
        }

        Response.Redirect("Login.aspx");
    }
}

