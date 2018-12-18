using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public static class myCounter
{
    public static int count { get; set; }
}


public partial class AdminPages_SignOffSheetEdit : System.Web.UI.Page
{

    // ----------------------------------------------------------------------------------------------------------------------------------- //
    //                                                           PAGE LOAD                                                                 //
    // ----------------------------------------------------------------------------------------------------------------------------------- //

    protected void Page_Load(object sender, EventArgs e)
    {
        myCounter.count = 0;

        string checkUser = GlobalMethods.checkUser();
        if (checkUser == "Unauthorised")
        {
            Response.Redirect("../MemberPages/InvalidAccess.aspx");
        }

        if (!(IsPostBack))
        {
            populateTaskDropdown();

            List<string> menuList = new List<string>();
            menuList = GlobalMethods.populateAdminMenu();
            inductionLiteral.Text = menuList[0];
            techniquesLiteral.Text = menuList[1];
            dataEntryLiteral.Text = menuList[2];
            doseCalcLiteral.Text = menuList[3];
        }
    }


    // ----------------------------------------------------------------------------------------------------------------------------------- //
    //                                                      POPULATE USER ACCOUNTS                                                         //
    // ----------------------------------------------------------------------------------------------------------------------------------- //


    //populate user account dropdown list
    public void populateTaskDropdown()
    {
        string modules = "SELECT * " +
                         "FROM " +
                         "dbo.TrainingPackage_Modules";

        DataTable dt = new DataTable();

        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ServerBUConString"].ConnectionString))
        {
            con.Open();

            using (SqlCommand userCmd = new SqlCommand(modules, con))
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
            string module = dt.Rows[x].ItemArray[1].ToString();

            signOffEditList.Items.Add(new ListItem(module));
        }
    }


    // ----------------------------------------------------------------------------------------------------------------------------------- //
    //                                                    SELECTED INDEX CHANGE EVENT                                                      //
    // ----------------------------------------------------------------------------------------------------------------------------------- //


    protected void signOffSheetEdit_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (signOffEditList.SelectedItem.Text != "Choose a Sign Off Sheet")
        {
            GlobalMethods.removeCssClass("hideDiv", tableContent);
            GlobalMethods.addCssClass("showDiv", tableContent);
            GlobalMethods.removeCssClass("hideDiv", addItemButton);
            GlobalMethods.addCssClass("showDiv", addItemButton);

            var selectedItem = signOffEditList.SelectedItem.Text;

            fillTable(selectedItem);
        }
        else
        {
            GlobalMethods.removeCssClass("showDiv", tableContent);
            GlobalMethods.addCssClass("hideDiv", tableContent);
            GlobalMethods.removeCssClass("showDiv", addItemButton);
            GlobalMethods.addCssClass("hideDiv", addItemButton);
        }
    }


    // ----------------------------------------------------------------------------------------------------------------------------------- //
    //                                                        FILL THE TABLE                                                               //
    // ----------------------------------------------------------------------------------------------------------------------------------- //

    public void fillTable(string selectedItem)
    {
        SqlDataSource SqlDataSource1 = new SqlDataSource();
        SqlDataSource1.ID = "SqlDataSource1";
        this.Page.Controls.Add(SqlDataSource1);

        SqlDataSource1.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ServerBUConString"].ConnectionString;

        SqlDataSource1.SelectCommand = "SELECT " +
                                        "taskName = dbo.TrainingPackage_Tasks.TASK_DESC " +
                                        "FROM dbo.TrainingPackage_Tasks " +
                                        "INNER JOIN dbo.TrainingPackage_Modules ON dbo.TrainingPackage_Tasks.MODULE_ID = dbo.TrainingPackage_Modules.ID " +
                                        "WHERE dbo.TrainingPackage_Modules.MODULE = @moduleName";

        SqlDataSource1.SelectParameters.Clear();
        SqlDataSource1.SelectParameters.Add("moduleName", DbType.String, selectedItem);
        Repeater1.DataSource = SqlDataSource1;
        Repeater1.DataBind();
    }


    // ----------------------------------------------------------------------------------------------------------------------------------- //
    //                                                        ON DATABOUND EVENT                                                           //
    // ----------------------------------------------------------------------------------------------------------------------------------- //

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("tableRow");
        HtmlButton btn = (HtmlButton)e.Item.FindControl("deleteB");

        if (tr != null)
        {
            btn.Attributes.Add("id", myCounter.count.ToString());

            myCounter.count++;
        }
    }


    // ----------------------------------------------------------------------------------------------------------------------------------- //
    //                                                         DELETE TASK                                                                 //
    // ----------------------------------------------------------------------------------------------------------------------------------- //

    [System.Web.Services.WebMethod]
    public static void deleteTask(string moduleName, string taskName)
    {

        string deleteRecord =   "DELETE dbo.TrainingPackage_Tasks FROM dbo.TrainingPackage_Tasks " +
                                "INNER JOIN dbo.TrainingPackage_Modules ON dbo.TrainingPackage_Tasks.MODULE_ID = dbo.TrainingPackage_Modules.ID " +
                                "WHERE dbo.TrainingPackage_Tasks.TASK_DESC = @taskDesc AND dbo.TrainingPackage_Modules.MODULE = @module"; 

        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ServerBUConString"].ConnectionString))
        {
            con.Open();
            //row count smaller than 1 no rows found insert
            using (SqlCommand cmd = new SqlCommand(deleteRecord, con))
            {
                cmd.Parameters.Add("@taskDesc", SqlDbType.NVarChar, 500).Value = taskName;
                cmd.Parameters.Add("@module", SqlDbType.NVarChar, 500).Value = moduleName;
                cmd.ExecuteNonQuery();
            }
        }
    }

    // ----------------------------------------------------------------------------------------------------------------------------------- //
    //                                                        INSERT TASK                                                                  //
    // ----------------------------------------------------------------------------------------------------------------------------------- //


    [System.Web.Services.WebMethod]
    public static void insert(string dbtable, string taskName)
    {

        string findModuleID = "SELECT dbo.TrainingPackage_Modules.ID " +
                              "FROM dbo.TrainingPackage_Modules " +
                              "WHERE dbo.TrainingPackage_Modules.MODULE = @moduleName";

        string insert = "INSERT INTO dbo.TrainingPackage_Tasks (MODULE_ID, TASK_DESC) " +
                        "VALUES (@moduleID, @taskname)";

        int moduleID = 0;

        using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ServerBUConString"].ConnectionString))
        {
            con.Open();

            using (SqlCommand cmd = new SqlCommand(findModuleID, con))
            {
                cmd.Parameters.Add("@moduleName", SqlDbType.NVarChar, 500).Value = dbtable;
                moduleID = (int)cmd.ExecuteScalar();
            }

            //row count smaller than 1 no rows found insert
            using (SqlCommand cmd = new SqlCommand(insert, con))
            {
                cmd.Parameters.Add("@moduleID", SqlDbType.NVarChar, 500).Value = moduleID;
                cmd.Parameters.Add("@taskname", SqlDbType.NVarChar, 500).Value = taskName;
                cmd.ExecuteNonQuery();
            }
        }

    }



}
