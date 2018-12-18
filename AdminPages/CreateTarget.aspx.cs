using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPages_CreateMeeting : System.Web.UI.Page
{

    // --------------------------------------------------------------------------------------------------------------------------------------- //
    // -------------------------------------------------------     PAGE LOAD     ------------------------------------------------------------- //
    // --------------------------------------------------------------------------------------------------------------------------------------- //

    protected void Page_Load(object sender, EventArgs e)
    {
        string checkUser = GlobalMethods.checkUser();
        if (checkUser == "Unauthorised")
        {
            Response.Redirect("../MemberPages/InvalidAccess.aspx");
        }

        if (!IsPostBack)
        {
            populateUserAccounts();
        }
    }



    // --------------------------------------------------------------------------------------------------------------------------------------- //
    // --------------------------------------------------     POPULATE USER DROPDOWN     ----------------------------------------------------- //
    // --------------------------------------------------------------------------------------------------------------------------------------- //


    //populate user account dropdown list
    public void populateUserAccounts()
    {
        string userAccounts = "SELECT " +
                                "dbo.TrainingPackage_User.FirstName, " +
                                "dbo.TrainingPackage_User.LastName, " +
                                "dbo.TrainingPackage_User.UserName " +
                                "FROM " +
                                "dbo.TrainingPackage_User";

        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ServerBUConString"].ConnectionString))
        {
            con.Open();

            using (SqlCommand userCmd = new SqlCommand(userAccounts, con))
            {
                using (SqlDataReader dr = userCmd.ExecuteReader())
                {
                    dt.Load(dr);
                }
            }
            con.Close();
        }

        var count = dt.Rows.Count;
        for (int x = 0; x < count; x++)
        {
            var First = dt.Rows[x].ItemArray[0];
            var Last = dt.Rows[x].ItemArray[1];
            var Username = dt.Rows[x].ItemArray[2];

            string userConcat = "" + Username + " - " + First + " " + Last + "";

            chosenUser.Items.Add(new ListItem(userConcat));
        }
    }



    // --------------------------------------------------------------------------------------------------------------------------------------- //
    // -----------------------------------------------------     CREATE CLICK     ------------------------------------------------------------ //
    // --------------------------------------------------------------------------------------------------------------------------------------- //


    protected void createTarget_Click(object sender, EventArgs e)
    {

        //get userId from logged in user
        string getUserID = "SELECT dbo.TrainingPackage_User.ID FROM dbo.TrainingPackage_User " +
                               "WHERE dbo.TrainingPackage_User.UserName = @username";

        //insert data to sql
        string insertData = "INSERT INTO dbo.TrainingPackage_MeetingTargets (UserID, Target, Date, TargetDesc, CreatedBy, Completion) " +
                            "VALUES (@userID, @target, @date, @targetDesc, @createdBy, @completion)";

        //logged on users username
        string username = HttpContext.Current.User.Identity.Name;
        string selectedUser = chosenUser.SelectedValue;
        string[] selectedUserLine = selectedUser.Split(' ');
        
        //initialte userid
        int userID = 0;

        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ServerBUConString"].ConnectionString))
        {

            con.Open();

            using (SqlCommand cmd = new SqlCommand(getUserID, con))
            {
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = selectedUserLine[0];
                userID = Convert.ToInt32(cmd.ExecuteScalar());
            }


            //row count smaller than 1 no rows found insert
            using (SqlCommand insertCmd = new SqlCommand(insertData, con))
                {
                    insertCmd.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                    insertCmd.Parameters.Add("@target", SqlDbType.NVarChar, 50).Value = targetTextbox.Text;
                    insertCmd.Parameters.Add("@date", SqlDbType.NVarChar, 50).Value = targetDateTextBox.Text;
                    insertCmd.Parameters.Add("@targetDesc", SqlDbType.NVarChar, 500).Value = targetDescTextBox.Text;
                    insertCmd.Parameters.Add("@createdBy", SqlDbType.NVarChar, 50).Value = username;
                    insertCmd.Parameters.Add("@completion", SqlDbType.NVarChar, 50).Value = "Awaiting Completion";
                    insertCmd.ExecuteNonQuery();
                }
           
        }

        Response.Redirect("CreateTarget.aspx");
    }

    //end

}