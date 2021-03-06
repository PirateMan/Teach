using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

//basepage for masterpages/templates

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

    //webmethod doesnt support overloading methods
    [System.Web.Services.WebMethod]
    public static void sqlInsertOne(string taskDesc, string dated, string cmpln, string approval)
    {
        //logged on users username
        string username = HttpContext.Current.User.Identity.Name;
        int userID = 0;
        int taskID = 0;
        int rowCount = 0;

        using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
        {

            userID = (from o in db.TrainingPackage_User
                      where o.UserName == username
                      select o.ID).First();

            taskID = (from o in db.TrainingPackage_Tasks
                      where o.TASK_DESC == taskDesc
                      select o.ID).First();

            rowCount = (from o in db.TrainingPackage_TaskSubmissions
                        where o.USER_ID == userID && o.TASK_ID == taskID
                        select o).Count();
                        
            if(rowCount < 1)
            {
                //insert

                TrainingPackage_TaskSubmissions task = new TrainingPackage_TaskSubmissions()
                {
                    USER_ID = userID,
                    TASK_ID = taskID,
                    DATE = dated,
                    COMPLETION = cmpln,
                    APPROVED_BY = approval
                };

                db.TrainingPackage_TaskSubmissions.Add(task);
                db.SaveChanges();

            }
            else
            {
                //update

                var task = (from t in db.TrainingPackage_TaskSubmissions
                           where t.USER_ID == userID && t.TASK_ID == taskID
                           select t).FirstOrDefault();

                task.DATE = dated;
                task.COMPLETION = cmpln;
                task.APPROVED_BY = approval;

                //save changes
                db.SaveChanges();
                
            }
        }
    }


    [System.Web.Services.WebMethod]
    public static void sqlInsertTwo(string taskDesc, string demoBy, string dated, string cmpln, string approval)
    {

        //logged on users username
        string username = HttpContext.Current.User.Identity.Name;
        int userID = 0;
        int taskID = 0;
        int rowCount = 0;

        using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
        {

            userID = (from o in db.TrainingPackage_User
                                     where o.UserName == username
                                     select o.ID).First();

            taskID = (from o in db.TrainingPackage_Tasks
                     where o.TASK_DESC == taskDesc
                     select o.ID).First();

            rowCount = (from o in db.TrainingPackage_TaskSubmissions
                        where o.USER_ID == userID && o.TASK_ID == taskID
                        select o).Count();

            if (rowCount < 1)
            {
                //insert
                TrainingPackage_TaskSubmissions task = new TrainingPackage_TaskSubmissions()
                {
                    USER_ID = userID,
                    TASK_ID = taskID,
                    DEMO_BY = demoBy,
                    DATE = dated,
                    COMPLETION = cmpln,
                    APPROVED_BY = approval
                };

                db.TrainingPackage_TaskSubmissions.Add(task);
                db.SaveChanges();

            }
            else
            {
                //update
                var task = (from t in db.TrainingPackage_TaskSubmissions
                            where t.USER_ID == userID && t.TASK_ID == taskID
                            select t).FirstOrDefault();

                task.DEMO_BY = demoBy;
                task.DATE = dated;
                task.COMPLETION = cmpln;
                task.APPROVED_BY = approval;

                //save changes
                db.SaveChanges();

            }
        }
    }


    [System.Web.Services.WebMethod]
    public static void sqlInsertCaseNumber(string taskDesc, string caseNumber, string dated, string cmpln, string approval)
    {

        //logged on users username
        string username = HttpContext.Current.User.Identity.Name;
        int userID = 0;
        int taskID = 0;
        int rowCount = 0;

        using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
        {

            userID = (from o in db.TrainingPackage_User
                      where o.UserName == username
                      select o.ID).First();

            taskID = (from o in db.TrainingPackage_Tasks
                      where o.TASK_DESC == taskDesc
                      select o.ID).First();

            rowCount = (from o in db.TrainingPackage_TaskSubmissions
                        where o.USER_ID == userID && o.TASK_ID == taskID
                        select o).Count();

            if (rowCount < 1)
            {
                //insert
                TrainingPackage_TaskSubmissions task = new TrainingPackage_TaskSubmissions()
                {
                    USER_ID = userID,
                    TASK_ID = taskID,
                    DEMO_ON = caseNumber,
                    DATE = dated,
                    COMPLETION = cmpln,
                    APPROVED_BY = approval
                };

                db.TrainingPackage_TaskSubmissions.Add(task);
                db.SaveChanges();

            }
            else
            {
                //update
                var task = (from t in db.TrainingPackage_TaskSubmissions
                            where t.USER_ID == userID && t.TASK_ID == taskID
                            select t).FirstOrDefault();

                task.DEMO_ON = caseNumber;
                task.DATE = dated;
                task.COMPLETION = cmpln;
                task.APPROVED_BY = approval;

                //save changes
                db.SaveChanges();

            }
        }
    }




    [System.Web.Services.WebMethod]
    public static void sqlInsertThree(string taskDesc, string demoBy, string demoOn, string dated, string cmpln, string approval)
    {
        //logged on users username
        string username = HttpContext.Current.User.Identity.Name;
        int userID = 0;
        int taskID = 0;
        int rowCount = 0;

        using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
        {

            userID = (from o in db.TrainingPackage_User
                      where o.UserName == username
                      select o.ID).First();

            taskID = (from o in db.TrainingPackage_Tasks
                      where o.TASK_DESC == taskDesc
                      select o.ID).First();

            rowCount = (from o in db.TrainingPackage_TaskSubmissions
                        where o.USER_ID == userID && o.TASK_ID == taskID
                        select o).Count();

            if (rowCount < 1)
            {
                //insert

                TrainingPackage_TaskSubmissions task = new TrainingPackage_TaskSubmissions()
                {
                    USER_ID = userID,
                    TASK_ID = taskID,
                    DEMO_BY = demoBy,
                    DEMO_ON = demoOn,
                    DATE = dated,
                    COMPLETION = cmpln,
                    APPROVED_BY = approval
                };

                db.TrainingPackage_TaskSubmissions.Add(task);
                db.SaveChanges();

            }
            else
            {
                //update

                var task = (from t in db.TrainingPackage_TaskSubmissions
                            where t.USER_ID == userID && t.TASK_ID == taskID
                            select t).FirstOrDefault();

                task.DEMO_BY = demoBy;
                task.DEMO_ON = demoOn;
                task.DATE = dated;
                task.COMPLETION = cmpln;
                task.APPROVED_BY = approval;

                //save changes
                db.SaveChanges();

            }
        }
    }

} //end
