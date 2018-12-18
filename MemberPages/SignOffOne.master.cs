using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class SignOffOneMaster : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {

        string checkUser = GlobalMethods.checkUser();
        if (checkUser == "Unauthorised")
        {
            adminDrop.Visible = false;
        }

        if (!IsPostBack)
        {
            List<string> menuList = new List<string>();
            menuList = GlobalMethods.populateMenu();
            inductionLiteral.Text = menuList[0];
            techniquesLiteral.Text = menuList[1];
            dataEntryLiteral.Text = menuList[2];
            doseCalcLiteral.Text = menuList[3];

            fillTable();
        }
    }

    public void fillTable()
    {
        // current user
        string username = HttpContext.Current.User.Identity.Name;

        // initialte userid
        int userID = 0;
        string taskName = Page.Title;

        using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
        {
            userID = (from ui in db.TrainingPackage_User
                      where ui.UserName == username
                      select ui.ID).First();

            //call stored procedure and bind repeater/ called like function with entity
            var repeaterDataSource = db.TrainingPackage_SignOffOne_Table(userID, taskName);
            Repeater1.DataSource = repeaterDataSource;
            Repeater1.DataBind();
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        List<string> completed = new List<string>();

        string strLabel1 = "";
        string strLabel5 = "";
        Label label5 = (Label)e.Item.FindControl("Label5");
        Label label4 = (Label)e.Item.FindControl("Label4");
        Label label1 = (Label)e.Item.FindControl("Label1");

        if (label1 != null)
        {
            strLabel1 = label1.Text.ToString();
        }

        if (label4 != null)
        {
            if (label4.Text == "")
            {
                label4.Text = "Incomplete";
            }

            if (label4.Text == "Completed")
            {
                completed.Add(label4.ClientID.ToString());

                for (int i = 0; i < completed.Count; i++)
                {
                    int checkCheckbox = Convert.ToInt32(completed[i].Replace("Repeater1_Label4_", ""));
                }
            }
        }

        if (label5 != null)
        {
            if (label5.Text == "")
            {
                label5.Text = "Unapproved";
            }

            strLabel5 = label5.Text.ToString();
        }

        HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("taskTable");

        if (strLabel5.StartsWith("Approved"))
        {
            tr.Style.Add("background-color", "#aee666");
            tr.Style.Add("color", "#000");
        }
        if (strLabel5 == "Awaiting Approval")
        {
            tr.Style.Add("background-color", "#66aee6");
            tr.Style.Add("color", "#fff");
        }

    }
}

