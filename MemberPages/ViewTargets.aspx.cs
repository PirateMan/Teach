using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MemberPages_ViewTargets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Populate Table on Page Load
        fillTable();
    }


    public void fillTable()
    {
        // current user
        string username = HttpContext.Current.User.Identity.Name;

        // initialte userid
        int userID = 0;

        //get userId from logged in user
        string selectUserID = "SELECT dbo.TrainingPackage_User.ID " +
                              "FROM  dbo.TrainingPackage_User " +
                              "WHERE dbo.TrainingPackage_User.UserName = @username";

        //get user id from logged in username
        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ServerBUConString"].ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(selectUserID, con))
            {
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = username;
                userID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            con.Close();
        }


        SqlDataSource SqlDataSource1 = new SqlDataSource();
        SqlDataSource1.ID = "SqlDataSource1";
        this.Page.Controls.Add(SqlDataSource1);

        SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServerBUConString"].ConnectionString;

        SqlDataSource1.SelectCommand = "SELECT " +

                                            "target = serverBU.dbo.TrainingPackage_MeetingTargets.Target, " +
                                            "targetDate = serverBU.dbo.TrainingPackage_MeetingTargets.Date, " +
                                            "targetDescription = serverBU.dbo.TrainingPackage_MeetingTargets.TargetDesc, " +
                                            "targetCreatedBy = serverBU.dbo.TrainingPackage_MeetingTargets.CreatedBy, " +
                                            "targetCompleted = serverBU.dbo.TrainingPackage_MeetingTargets.Completion " +

                                            "FROM serverBU.dbo.TrainingPackage_MeetingTargets " +

                                            "WHERE serverBU.dbo.TrainingPackage_MeetingTargets.UserID = @userId";

        SqlDataSource1.SelectParameters.Clear();
        SqlDataSource1.SelectParameters.Add("userId", DbType.String, userID.ToString());
        Repeater1.DataSource = SqlDataSource1;
        Repeater1.DataBind();

    }

    //end
}

//private static DataTable GetData(string query)
//{
//    string constr = ConfigurationManager.ConnectionStrings["ServerBUConString"].ConnectionString;

//    using (SqlConnection con = new SqlConnection(constr))
//    {
//        using (SqlCommand cmd = new SqlCommand())
//        {
//            cmd.CommandText = query;

//            using (SqlDataAdapter sda = new SqlDataAdapter())
//            {
//                cmd.Connection = con;
//                sda.SelectCommand = cmd;

//                using (DataSet ds = new DataSet())
//                {
//                    DataTable dt = new DataTable();
//                    sda.Fill(dt);
//                    return dt;
//                }
//            }
//        }
//    }
//}

//rptOrders.DataSource = GetData("SELECT " +
//                                        "target = dbo.TrainingPackage_MeetingTargets.Target, " +
//                                        "targetDate = dbo.TrainingPackage_MeetingTargets.Date " +
//                                    "FROM dbo.TrainingPackage_MeetingTargets " +
//                                    "WHERE dbo.TrainingPackage_MeetingTargets.UserID = 1");

//rptOrders.DataBind();



