using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TrainingApp.AdminPages
{
    public partial class Approvals : System.Web.UI.Page
    {

        // ----------------------------------------------------------------------------------------------------------------------------------- //
        //                                                            PAGE LOAD                                                                //
        // ----------------------------------------------------------------------------------------------------------------------------------- //

        //page load event
        protected void Page_Load(object sender, EventArgs e)
        {
            string checkUser = GlobalMethods.checkUser();
            if (checkUser == "Unauthorised")
            {
                Response.Redirect("../MemberPages/InvalidAccess.aspx");
            }

            if (!IsPostBack)
            {
                userAccountList.Enabled = false;
                populateSignOfSheets();
                populateUserAccounts();

                List<string> menuList = new List<string>();
                menuList = GlobalMethods.populateAdminMenu();
                inductionLiteral.Text = menuList[0];
                techniquesLiteral.Text = menuList[1];
                dataEntryLiteral.Text = menuList[2];
                doseCalcLiteral.Text = menuList[3];
            }
        }


        // ----------------------------------------------------------------------------------------------------------------------------------- //
        //                                                      POPULATE SO DROPDOWN                                                           //
        // ----------------------------------------------------------------------------------------------------------------------------------- //

        //populate SO dropdown list
        public void populateSignOfSheets()
        {
            using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
            {
                string[] modules = (from o in db.TrainingPackage_Modules
                                   select o.MODULE).ToArray();

                for (int i = 0; i < modules.Length; i++)
                {
                    signOffDropDown.Items.Add(new ListItem(modules[i]));
                } 
            }
        }



        // ----------------------------------------------------------------------------------------------------------------------------------- //
        //                                                      POPULATE USER ACCOUNTS                                                         //
        // ----------------------------------------------------------------------------------------------------------------------------------- //

        //populate user account dropdown list
        public void populateUserAccounts()
        {
            using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
            {
                var userAccount = (from o in db.TrainingPackage_User select new { o.FirstName, o.LastName, o.UserName }).ToArray();
                    
                foreach(var item in userAccount)
                {
                    userAccountList.Items.Add(new ListItem(item.UserName + " - " + item.FirstName + " " + item.LastName));
                }
            }
        }



        // ----------------------------------------------------------------------------------------------------------------------------------- //
        //                                           USER ACCOUNTS SELECTION CHANGE EVENT                                                      //
        // ----------------------------------------------------------------------------------------------------------------------------------- //

        protected void userAccountList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userAccountList.SelectedItem.Text != "Choose a User")
            {
                populateApprovalTable();
            }
            else
            {
                ApprovalTablePanel.Visible = false;
                ApprovalTablePanelAll.Visible = false;
                GlobalMethods.removeCssClass("showDiv", approvalButtonDiv);
                GlobalMethods.addCssClass("hideDiv", approvalButtonDiv);
            }
        }



        // ----------------------------------------------------------------------------------------------------------------------------------- //
        //                                                       APPROVAL CLICK EVENT                                                          //
        // ----------------------------------------------------------------------------------------------------------------------------------- //

        protected void approvalButton_Click(object sender, EventArgs e)
        {
            //logged on users username
            string approvalUsername = HttpContext.Current.User.Identity.Name;
            string selectedUser = userAccountList.SelectedItem.Text;
            string[] usernameParse = selectedUser.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string selectedUsername = usernameParse[0];
            int userID = 0;

            using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
            {
                userID = (from ui in db.TrainingPackage_User
                          where ui.UserName == selectedUsername
                          select ui.ID).First();
            }

            List<string> selected = new List<string>();

            if (signOffDropDown.SelectedItem.Text == "All Sheets")
            {
                foreach (RepeaterItem item in Repeater2.Items)
                {
                    CheckBox chk = (CheckBox)item.FindControl("selectUser");
                    if (chk.Checked)
                    {
                        selected.Add(chk.ClientID.ToString());
                    }
                }
            }
            else
            {
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    CheckBox chk = (CheckBox)item.FindControl("selectUser");
                    if (chk.Checked)
                    {
                        selected.Add(chk.ClientID.ToString());
                    }
                }
            }

            for (int i = 0; i < selected.Count; i++)
            {

                if (signOffDropDown.SelectedItem.Text == "All Sheets")
                {
                    //get label text from repeater from selection.
                    int checkCheckbox = Convert.ToInt32(selected[i].Replace("Repeater2_selectUser_", ""));
                    Label LabelChosen = (Label)Repeater2.Items[checkCheckbox].FindControl("Label1");

                    string checkedName = LabelChosen.Text.ToString();
                    int taskID = 0;

                    using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
                    {
                        taskID = (from ti in db.TrainingPackage_Tasks
                                  where ti.TASK_DESC == checkedName
                                  select ti.ID).First();

                        TrainingPackage_TaskSubmissions task = (from ta in db.TrainingPackage_TaskSubmissions
                                                                where ta.TASK_ID == taskID && ta.USER_ID == userID
                                                                select ta).First();

                        task.APPROVED_BY = ("Approved By {0}").Replace("{0}", approvalUsername);
                        db.SaveChanges();
                    }
                }
                else
                {
                    //get label text from repeater from selection.
                    int checkCheckbox = Convert.ToInt32(selected[i].Replace("Repeater1_selectUser_", ""));
                    Label LabelChosen = (Label)Repeater1.Items[checkCheckbox].FindControl("Label1");


                    string checkedName = LabelChosen.Text.ToString();
                    int taskID = 0;


                    using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
                    {
                        taskID = (from ti in db.TrainingPackage_Tasks
                                  where ti.TASK_DESC == checkedName
                                  select ti.ID).First();

                        TrainingPackage_TaskSubmissions task = (from ta in db.TrainingPackage_TaskSubmissions
                                                                where ta.TASK_ID == taskID && ta.USER_ID == userID
                                                                select ta).First();

                        task.APPROVED_BY = ("Approved By {0}").Replace("{0}", approvalUsername);
                        db.SaveChanges();
                    }
                }

            }

            Response.Redirect("Approvals.aspx");
        }




        // ----------------------------------------------------------------------------------------------------------------------------------- //
        //                                               TABLE REPEATER ITEM BOUND EVENT                                                       //
        // ----------------------------------------------------------------------------------------------------------------------------------- //

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            string label5 = "";

            Label la = (Label)e.Item.FindControl("Label5");
            if (la != null)
            {
                label5 = la.Text.ToString();
            }

            HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("tableRow");
            CheckBox chk = (CheckBox)e.Item.FindControl("selectUser");

            if (tr != null)
            {
                if (label5.StartsWith("Approved"))
                {
                    tr.Style.Add("background-color", "#aee666");
                    tr.Style.Add("color", "#000");
                }

                if (label5 == "Awaiting Approval")
                {
                    tr.Style.Add("background-color", "#66aee6");
                    tr.Style.Add("color", "#fff");
                }
                else
                {
                    chk.Attributes.Add("class", "hideDiv");     //remove checkbox if not "awaiting approval"
                }
            }

        }



        // ----------------------------------------------------------------------------------------------------------------------------------- //
        //                                                 SIGN OFF SHEET CHANGE INDEX                                                         //
        // ----------------------------------------------------------------------------------------------------------------------------------- //

        protected void signOffDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {

            ApprovalTablePanel.Visible = false;
            ApprovalTablePanelAll.Visible = false;
            GlobalMethods.removeCssClass("showDiv", approvalButtonDiv);
            GlobalMethods.addCssClass("hideDiv", approvalButtonDiv);

            if (signOffDropDown.SelectedItem.Text == "Choose a Sheet")
            {
                userAccountList.Enabled = false;
                userAccountList.SelectedIndex = 0;
                ApprovalTablePanel.Visible = false;
            }
            else
            {
                userAccountList.Enabled = true;
            }

            if (userAccountList.SelectedItem.Text != "Choose a User" && signOffDropDown.SelectedItem.Text != "Choose a Sheet")
            {
                populateApprovalTable();
            }

        }



        // ----------------------------------------------------------------------------------------------------------------------------------- //
        //                                                     POPULATE APPROVAL TABLE                                                         //
        // ----------------------------------------------------------------------------------------------------------------------------------- //

        public void populateApprovalTable()
        {

            string selectedUser = userAccountList.SelectedItem.Text;
            string[] usernameParse = selectedUser.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            string selectedUsername = usernameParse[0];
            int userID = 0;
            string taskName = signOffDropDown.SelectedItem.Text;

            using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
            {
                userID = (from ui in db.TrainingPackage_User
                          where ui.UserName == selectedUsername
                          select ui.ID).First();
            }

            if (signOffDropDown.SelectedItem.Text == "All Sheets")
            {

                ApprovalTablePanelAll.Visible = true;

                using (var db = new serverBUEntitiesConnection())
                {
                    //call stored procedure and bind repeater/ called like function with entity
                    var repeaterDataSource = db.TrainingPackage_ApprovalProcedure(userID);
                    Repeater2.DataSource = repeaterDataSource;
                    Repeater2.DataBind();
                }

                    //set default value
                    foreach (RepeaterItem ri in Repeater2.Items)
                    {
                        Label label5 = ri.FindControl("Label5") as Label;
                        if (label5.Text == "")
                        {
                            label5.Text = "Unapproved";
                        }

                        Label label4 = ri.FindControl("Label4") as Label;
                        if (label4.Text == "")
                        {
                            label4.Text = "Incomplete";
                        }
                    }
            }
            else
            {

                ApprovalTablePanel.Visible = true;

                using (var db = new serverBUEntitiesConnection())
                {
                    //call stored procedure and bind repeater/ called like function with entity
                    var repeaterDataSource = db.TrainingPackage_ApprovalProcedure_Task(userID, taskName);
                    Repeater1.DataSource = repeaterDataSource;
                    Repeater1.DataBind();
                }


                //set default value
                foreach (RepeaterItem ri in Repeater1.Items)
                {
                    Label label5 = ri.FindControl("Label5") as Label;
                    if (label5.Text == "")
                    {
                        label5.Text = "Unapproved";
                    }

                    Label label4 = ri.FindControl("Label4") as Label;
                    if (label4.Text == "")
                    {
                        label4.Text = "Incomplete";
                    }
                }
            }

            GlobalMethods.removeCssClass("hideDiv", approvalButtonDiv);
            GlobalMethods.addCssClass("showDiv", approvalButtonDiv);

        }

    } //end class

} // end namespace