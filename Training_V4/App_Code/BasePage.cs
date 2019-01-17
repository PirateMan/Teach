using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

/// <summary>
/// Base for master pages and templates
/// </summary>
public class BasePage : System.Web.UI.Page
{
    private string _metadescription;
    private string _metakeywords;
    private string _ID;

    public string PageID
    {
        get { return _ID; }
        set { _ID = value; }
    }

    protected override void OnLoad(EventArgs e)
    {
        if (!String.IsNullOrEmpty(MetaKeywords))
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "keywords";
            tag.Content = MetaKeywords;
            Header.Controls.Add(tag);
        }

        if (!String.IsNullOrEmpty(MetaDescription))
        {
            HtmlMeta tag = new HtmlMeta();
            tag.Name = "description";
            tag.Content = MetaDescription;
            Header.Controls.Add(tag);
        }

        base.OnLoad(e);
    }

    ////webmethod doesnt support overloading methods
    //[System.Web.Services.WebMethod]
    //public static void sqlInsertOne(string taskDesc, string dated, string cmpln, string approval)
    //{
    //    //logged on users username
    //    string username = HttpContext.Current.User.Identity.Name;
    //    int userID = 0;
    //    int taskID = 0;
    //    int rowCount = 0;

    //    using (TrainingDBEntities1 db = new TrainingDBEntities1())
    //    {

    //        userID = (from o in db.Users
    //                  where o.Username == username
    //                  select o.ID).First();

    //        taskID = (from o in db.Tasks
    //                  where o.Description == taskDesc
    //                  select o.ID).First();

    //        rowCount = (from o in db.Cases
    //                    where o.User_ID == userID && o.Task_ID == taskID
    //                    select o).Count();



    //        //Make the task row if there is not one already
    //        if (rowCount < 1)
    //        {
    //            for (int i = 0; i < 3; i++)
    //            {
    //                //insert
    //                Case newcase = new Case()
    //                {
    //                    User_ID = userID,
    //                    Task_ID = taskID,
    //                    Approval_Date = dated,
    //                    Completion_Date = cmpln,
    //                    Approved_By = approval
    //                };

    //                db.Cases.Add(newcase);
    //                db.SaveChanges();
    //            }
    //        }

    //        else
    //        {
    //            //update
    //            var task = (from t in db.Cases
    //                        where t.User_ID == userID && t.Task_ID == taskID
    //                        select t).FirstOrDefault();

    //            task.Approval_Date = dated;
    //            task.Completion_Date = cmpln;
    //            task.Approved_By = approval;

    //            //save changes
    //            db.SaveChanges();

    //        }
    //    }
    //}


    //[System.Web.Services.WebMethod]
    //public static void sqlInsertTwo(string taskDesc, string demoBy, string dated, string cmpln, string approval)
    //{

    //    //logged on users username
    //    string username = HttpContext.Current.User.Identity.Name;
    //    int userID = 0;
    //    int taskID = 0;
    //    int rowCount = 0;

    //    using (TrainingDBEntities1 db = new TrainingDBEntities1())
    //    {

    //        userID = (from o in db.TrainingPackage_User
    //                  where o.UserName == username
    //                  select o.ID).First();

    //        taskID = (from o in db.TrainingPackage_Tasks
    //                  where o.TASK_DESC == taskDesc
    //                  select o.ID).First();

    //        rowCount = (from o in db.TrainingPackage_TaskSubmissions
    //                    where o.USER_ID == userID && o.TASK_ID == taskID
    //                    select o).Count();

    //        if (rowCount < 1)
    //        {
    //            //insert
    //            TrainingPackage_TaskSubmissions task = new TrainingPackage_TaskSubmissions()
    //            {
    //                USER_ID = userID,
    //                TASK_ID = taskID,
    //                DEMO_BY = demoBy,
    //                DATE = dated,
    //                COMPLETION = cmpln,
    //                APPROVED_BY = approval
    //            };

    //            db.TrainingPackage_TaskSubmissions.Add(task);
    //            db.SaveChanges();

    //        }
    //        else
    //        {
    //            //update
    //            var task = (from t in db.TrainingPackage_TaskSubmissions
    //                        where t.USER_ID == userID && t.TASK_ID == taskID
    //                        select t).FirstOrDefault();

    //            task.DEMO_BY = demoBy;
    //            task.DATE = dated;
    //            task.COMPLETION = cmpln;
    //            task.APPROVED_BY = approval;

    //            //save changes
    //            db.SaveChanges();

    //        }
    //    }
    //}


    //[System.Web.Services.WebMethod]
    //public static void sqlInsertCaseNumber(string taskDesc, string caseNumber, string dated, string cmpln, string approval)
    //{

    //    //logged on users username
    //    string username = HttpContext.Current.User.Identity.Name;
    //    int userID = 0;
    //    int taskID = 0;
    //    int rowCount = 0;

    //    using (TrainingDBEntities1 db = new TrainingDBEntities1())
    //    {

    //        userID = (from o in db.TrainingPackage_User
    //                  where o.UserName == username
    //                  select o.ID).First();

    //        taskID = (from o in db.TrainingPackage_Tasks
    //                  where o.TASK_DESC == taskDesc
    //                  select o.ID).First();

    //        rowCount = (from o in db.TrainingPackage_TaskSubmissions
    //                    where o.USER_ID == userID && o.TASK_ID == taskID
    //                    select o).Count();

    //        if (rowCount < 1)
    //        {
    //            //insert
    //            TrainingPackage_TaskSubmissions task = new TrainingPackage_TaskSubmissions()
    //            {
    //                USER_ID = userID,
    //                TASK_ID = taskID,
    //                DEMO_ON = caseNumber,
    //                DATE = dated,
    //                COMPLETION = cmpln,
    //                APPROVED_BY = approval
    //            };

    //            db.TrainingPackage_TaskSubmissions.Add(task);
    //            db.SaveChanges();

    //        }
    //        else
    //        {
    //            //update
    //            var task = (from t in db.TrainingPackage_TaskSubmissions
    //                        where t.USER_ID == userID && t.TASK_ID == taskID
    //                        select t).FirstOrDefault();

    //            task.DEMO_ON = caseNumber;
    //            task.DATE = dated;
    //            task.COMPLETION = cmpln;
    //            task.APPROVED_BY = approval;

    //            //save changes
    //            db.SaveChanges();

    //        }
    //    }
    //}




    //[System.Web.Services.WebMethod]
    //public static void sqlInsertThree(string taskDesc, string demoBy, string demoOn, string dated, string cmpln, string approval)
    //{
    //    //logged on users username
    //    string username = HttpContext.Current.User.Identity.Name;
    //    int userID = 0;
    //    int taskID = 0;
    //    int rowCount = 0;

    //    using (TrainingDBEntities1 db = new TrainingDBEntities1())
    //    {

    //        userID = (from o in db.TrainingPackage_User
    //                  where o.UserName == username
    //                  select o.ID).First();

    //        taskID = (from o in db.TrainingPackage_Tasks
    //                  where o.TASK_DESC == taskDesc
    //                  select o.ID).First();

    //        rowCount = (from o in db.TrainingPackage_TaskSubmissions
    //                    where o.USER_ID == userID && o.TASK_ID == taskID
    //                    select o).Count();

    //        if (rowCount < 1)
    //        {
    //            //insert

    //            TrainingPackage_TaskSubmissions task = new TrainingPackage_TaskSubmissions()
    //            {
    //                USER_ID = userID,
    //                TASK_ID = taskID,
    //                DEMO_BY = demoBy,
    //                DEMO_ON = demoOn,
    //                DATE = dated,
    //                COMPLETION = cmpln,
    //                APPROVED_BY = approval
    //            };

    //            db.TrainingPackage_TaskSubmissions.Add(task);
    //            db.SaveChanges();

    //        }
    //        else
    //        {
    //            //update

    //            var task = (from t in db.TrainingPackage_TaskSubmissions
    //                        where t.USER_ID == userID && t.TASK_ID == taskID
    //                        select t).FirstOrDefault();

    //            task.DEMO_BY = demoBy;
    //            task.DEMO_ON = demoOn;
    //            task.DATE = dated;
    //            task.COMPLETION = cmpln;
    //            task.APPROVED_BY = approval;

    //            //save changes
    //            db.SaveChanges();

    //        }
    //    }
    //}


    private void CreateCases(int taskID, int userID)
    {

    }
} //end
