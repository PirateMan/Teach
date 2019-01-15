using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Member_Techniques : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (TrainingDBEntities1 db = new TrainingDBEntities1())
        {
            string checkUser = GeneralMethods.checkUser();


            if (!IsPostBack)
            {
                List<string> menuList = new List<string>();
            }
        }
    }

    [System.Web.Services.WebMethod]
    public void fillTechniquesTable()
    {
        // current user
        string username = HttpContext.Current.User.Identity.Name;

        int taskID = 0;
        int userID = 0;

        string taskName = Page.Title;

        using (TrainingDBEntities1 db = new TrainingDBEntities1())
        {
            taskID = (from ui in db.Tasks
                      where ui.Module_Type_ID == 2
                      select ui.ID).First();

            userID = (from ui in db.Users
                      where ui.Username == username
                      select ui.ID).First();

            //usersCaseCount = (from o in db.Cases
            //                   where o.User_ID == userID && o.Task_ID == taskID
            //                   select o).Count();

            var techniqueTasks = (from i in db.Tasks
                                  where i.Module_Type_ID == 2
                                  select i.ID).ToList();
            //Make the task row if there is not one already
            foreach (var element in techniqueTasks)

                for (int i = 0; i < 3; i++)
                {
                    //insert
                    Case newcase = new Case()
                    {
                        User_ID = userID,
                        Task_ID = taskID,
                        Case_Number = (i + 1)
                        //Approval_Date = dated,
                        //Completion_Date = cmpln,
                        //Approved_By = approval
                    };

                    db.Cases.Add(newcase);
                    db.SaveChanges();
                }
             

            //else
            //{
            //    //update
            //    var task = (from t in db.Cases
            //                where t.User_ID == userID && t.Task_ID == taskID
            //                select t).FirstOrDefault();

            //    //task.Approval_Date = dated;
            //    //task.Completion_Date = cmpln;
            //    //task.Approved_By = approval;

            //    //save changes
            //    db.SaveChanges();

            //}
        }
    }



}


    


//    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
//    {
//        List<string> completed = new List<string>();

//        string strLabel1 = "";
//        string strLabel5 = "";
//        Label label5 = (Label)e.Item.FindControl("Label5");
//        Label label4 = (Label)e.Item.FindControl("Label4");
//        Label label1 = (Label)e.Item.FindControl("Label1");

//        if (label1 != null)
//        {
//            strLabel1 = label1.Text.ToString();
//        }

//        if (label4 != null)
//        {
            
//        }

//        if (label5 != null)
//        {
//            if (label5.Text == "")
//            {
//                label5.Text = "Unapproved";
//            }

//            strLabel5 = label5.Text.ToString();
//        }

//        HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("taskTable");

//        if (strLabel5.StartsWith("Approved"))
//        {
//            tr.Style.Add("background-color", "#aee666");
//            tr.Style.Add("color", "#000");
//        }
//        if (strLabel5 == "Awaiting Approval")
//        {
//            tr.Style.Add("background-color", "#66aee6");
//            tr.Style.Add("color", "#fff");
//        }

//    }
//}


