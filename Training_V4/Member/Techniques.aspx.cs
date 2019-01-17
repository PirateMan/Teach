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

        //TechniquesSelect();
    }


    //public void fillTechniquesTable()
    //{
    //    // current user
    //    string username = HttpContext.Current.User.Identity.Name;

    //    int taskID = 0;
    //    int userID = 0;

    //    string taskName = Page.Title;

    //    using (TrainingDBEntities1 db = new TrainingDBEntities1())
    //    {
    //        taskID = (from ui in db.Tasks
    //                  where ui.Module_Type_ID == 2
    //                  select ui.ID).First();

    //        userID = (from ui in db.Users
    //                  where ui.Username == username
    //                  select ui.ID).First();

    //        ////usersCaseCount = (from o in db.Cases
    //        ////                   where o.User_ID == userID && o.Task_ID == taskID
    //        ////                   select o).Count();

    //        //var techniqueTasks = (from i in db.Tasks
    //        //                      where i.Module_Type_ID == 2
    //        //                      select i.ID).ToList();
    //        ////Make the task row if there is not one already
    //        //foreach (var element in techniqueTasks)

    //        //    for (int i = 0; i < 3; i++)
    //        //    {
    //        //        //insert
    //        //        Case newcase = new Case()
    //        //        {
    //        //            User_ID = userID,
    //        //            Task_ID = taskID,
    //        //            Case_Number = (i + 1)
    //        //            //Approval_Date = dated,
    //        //            //Completion_Date = cmpln,
    //        //            //Approved_By = approval
    //        //        };

    //        //        db.Cases.Add(newcase);
    //        //        db.SaveChanges();
    //        //    }


    //        //else
    //        //{
    //        //    //update
    //        //    var task = (from t in db.Cases
    //        //                where t.User_ID == userID && t.Task_ID == taskID
    //        //                select t).FirstOrDefault();

    //        //    //task.Approval_Date = dated;
    //        //    //task.Completion_Date = cmpln;
    //        //    //task.Approved_By = approval;

    //        //    //save changes
    //        //    db.SaveChanges();

    //        //}
    //    }
}

    //private static void TechniquesSelect()
    //{

    //    string username = HttpContext.Current.User.Identity.Name;

    //    int taskID = 0;
    //    int userID = 0;

    //    using (TrainingDBEntities1 db = new TrainingDBEntities1())
    //    {
    //        taskID = (from ui in db.Tasks
    //                  where ui.Module_Type_ID == 2
    //                  select ui.ID).First();

    //        userID = (from ui in db.Users
    //                  where ui.Username == username
    //                  select ui.ID).First();
    //    }
    //    string connString = "Server=IT047053\\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;";
    //    using (SqlConnection conn = new SqlConnection(connString))
    //    {
    //        conn.Open();
    //        using (SqlCommand selectCmd = new SqlCommand("SELECT Task.Task_Name, Task.Description FROM Case INNER JOIN Task ON Case.Task_ID = Task.ID INNER JOIN User ON Case.User_ID = User.ID WHERE Case.Task_ID = @taskID AND User.ID = @userID", conn))
    //        {
    //            selectCmd.Parameters.AddWithValue("taskID", taskID);
    //            selectCmd.Parameters.AddWithValue("userID", userID);

    //            SqlDataReader reader = selectCmd.ExecuteReader();
    //        }
        //}
    //}


//}





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














//    #Region "Page PreInit & Page Load"

//    '*********************************************************
//    '*                     Page_PreInit                      *
//    '*                    --------------                     *
//    '* Set Selected Menu style in Header                     *
//    '* Also load appropriate User Control in Left Hand Panel *
//    '*********************************************************
//    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

//        Dim TopMenuAnchor As HyperLink
//        Dim PageTitleLabel As Label

//        Dim myLeftPanel As Panel
//        Dim myMenuUserControl As UserControl

//        'Set Style for Administration Pages hyperlink
//        TopMenuAnchor = Page.Master.FindControl("hypAdmin")
//        TopMenuAnchor.ImageUrl = "~/images/Header/Admin2.jpg"
//        TopMenuAnchor.ToolTip = "Administration - you are currently viewing these pages"

//        PageTitleLabel = Page.Master.FindControl("lblPageTitle")
//        PageTitleLabel.Text = "Administration - General Settings"

//        'Load Appropriate Left Menu Control
//        myMenuUserControl = LoadControl("../UserControls/LeftMenuAdmin.ascx")
//        myLeftPanel = Page.Master.FindControl("pnlLeftMenu")
//        myLeftPanel.Controls.Add(myMenuUserControl)

//    End Sub

//    '***********************************************
//    '*                  Page_Load                  *
//    '*                 -----------                 *
//    '* Load the data controls on initial Page Load *
//    '* Don't do for a page postback though         *
//    '***********************************************
//    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

//        If Not Page.IsPostBack Then
//            LoadControls()
//        End If

//    End Sub

//#End Region



//#Region "Load and Reload Controls"

//    '************************************************
//    '*                 LoadControls                 *
//    '*                --------------                *
//    '* This Sub populates the various DropDownLists *
//    '************************************************
//    Protected Sub LoadControls()

//        ddListAddLocalisation.DataSource = BLL_PatientPrescription.GetRTLocalisation
//        ddListAddLocalisation.DataValueField = "ID"
//        ddListAddLocalisation.DataTextField = "Localisation"
//        ddListAddLocalisation.DataBind()

//        ddListAddTumourSite.DataSource = BLL_ChemotherapyRegimes.GetTumourSites
//        ddListAddTumourSite.DataValueField = "ID"
//        ddListAddTumourSite.DataTextField = "TumourSite"
//        ddListAddTumourSite.DataBind()

//        ddListAddMachineEnergy.DataSource = BLL_RTTreatmentInformation.GetRTEnergies(False)
//        ddListAddMachineEnergy.DataValueField = "ID"
//        ddListAddMachineEnergy.DataTextField = "Energy"
//        ddListAddMachineEnergy.DataBind()

//        ddListAddMLC.DataSource = BLL_RTTreatmentInformation.GetRTMLC(False)
//        ddListAddMLC.DataValueField = "ID"
//        ddListAddMLC.DataTextField = "MLC"
//        ddListAddMLC.DataBind()

//        ddListAddTreatmentMachine.DataSource = BLL_RTTreatmentInformation.GetRTTreatmentMachines(False)
//        ddListAddTreatmentMachine.DataValueField = "ID"
//        ddListAddTreatmentMachine.DataTextField = "MachineName"
//        ddListAddTreatmentMachine.DataBind()

//    End Sub

//    '******************************************************************
//    '*                         ReLoadControls                         *
//    '*                        ----------------                        *
//    '* This Sub is called when the Refresh button is clicked          *
//    '* This is a Hidden button only used during a Child Form Update   *
//    '* It updates all the DropDownLists on the page                   *
//    '******************************************************************
//    Protected Sub ReloadControls()

//        ddListAddLocalisation.DataSource = BLL_PatientPrescription.GetRTLocalisation
//        ddListAddLocalisation.DataValueField = "ID"
//        ddListAddLocalisation.DataTextField = "Localisation"
//        ddListAddLocalisation.DataBind()

//        ddListAddTumourSite.DataSource = BLL_ChemotherapyRegimes.GetTumourSites
//        ddListAddTumourSite.DataValueField = "ID"
//        ddListAddTumourSite.DataTextField = "TumourSite"
//        ddListAddTumourSite.DataBind()


//        ddListAddMachineEnergy.DataSource = BLL_RTTreatmentInformation.GetRTEnergies(False)
//        ddListAddMachineEnergy.DataValueField = "ID"
//        ddListAddMachineEnergy.DataTextField = "Energy"
//        ddListAddMachineEnergy.DataBind()

//        ddListAddMLC.DataSource = BLL_RTTreatmentInformation.GetRTMLC(False)
//        ddListAddMLC.DataValueField = "ID"
//        ddListAddMLC.DataTextField = "MLC"
//        ddListAddMLC.DataBind()

//        ddListAddTreatmentMachine.DataSource = BLL_RTTreatmentInformation.GetRTTreatmentMachines(False)
//        ddListAddTreatmentMachine.DataValueField = "ID"
//        ddListAddTreatmentMachine.DataTextField = "MachineName"
//        ddListAddTreatmentMachine.DataBind()

//    End Sub

//#End Region



//#Region "btnRefresh_Click"

//    '********************************************************************
//    '*                         btnRefresh_Click                         *
//    '*                        ------------------                        *
//    '* This is called when the Hidden Refresh button is clicked         *
//    '* The button is clicked from any Child Modal Updates on this page  *
//    '* Reload all DropDownList controls from the database               *
//    '********************************************************************
//    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

//        ' Call Sub to Update all DropDownList controls
//        ReloadControls()

//    End Sub

//#End Region




//#Region "gViewApplicationSettings_RowUpdating"

//    '********************************************************************************************
//    '*                           gViewApplicationSettings_RowUpdating                           *
//    '*                          --------------------------------------                          *
//    '* This event is called when the Application Settings GridView Update button is clicked     *
//    '* Need to get the current row number to enable us to use the 'FindControl' keyword         *
//    '* Read values of controls, validate, and if ok call Function to write changes to database  *
//    '********************************************************************************************
//    Protected Sub gViewApplicationSettings_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gViewApplicationSettings.RowUpdating

//        Dim ApplicationSettingsRow As Integer

//        'Get Current Row
//        ApplicationSettingsRow = e.RowIndex

//        'Create instances of GridView controls for current row
//        ApplicationSettingsIDLabel = gViewApplicationSettings.Rows(ApplicationSettingsRow).FindControl("lblApplicationSettingsID")
//        ApplicationSettingsDefaultDeferralPeriodTextBox = gViewApplicationSettings.Rows(ApplicationSettingsRow).FindControl("txtDefaultDeferralPeriod")
//        ApplicationSettingsBestWorkflowPeriodTextBox = gViewApplicationSettings.Rows(ApplicationSettingsRow).FindControl("txtBestWorkflowPeriod")
//        ApplicationSettingsBreechPeriodTextBox = gViewApplicationSettings.Rows(ApplicationSettingsRow).FindControl("txtBreechPeriod")
//        ApplicationSettingsActionPeriodTextBox = gViewApplicationSettings.Rows(ApplicationSettingsRow).FindControl("txtActionPeriod")
//        ApplicationSettingsRTStageActionPeriodTextBox = gViewApplicationSettings.Rows(ApplicationSettingsRow).FindControl("txtRTStageActionPeriod")

//        'Get ApplicationSettingsID value
//        ApplicationSettingsID = ApplicationSettingsIDLabel.Text

//        'Validate and read Default Deferral Period
//        If ApplicationSettingsDefaultDeferralPeriodTextBox.Text.Length< 1 Or ApplicationSettingsRTStageActionPeriodTextBox.Text.Length> 10 Then
//            lblMessage.Text = "Please enter a valid Default Deferral Period."
//            Exit Sub
//        End If
//        Try
//            ApplicationSettingsDefaultDeferralPeriod = CInt(ApplicationSettingsDefaultDeferralPeriodTextBox.Text)
//            If ApplicationSettingsDefaultDeferralPeriod < 0 Then
//                ApplicationSettingsDefaultDeferralPeriod = 0
//            End If
//        Catch ex As Exception
//            lblMessage.Text = "Please enter a valid Default Deferral Period."
//            Exit Sub
//        End Try


//        'Validate and read Best Workflow Period
//        If ApplicationSettingsBestWorkflowPeriodTextBox.Text.Length< 1 Or ApplicationSettingsBestWorkflowPeriodTextBox.Text.Length> 10 Then
//            lblMessage.Text = "Please enter a valid Best Workflow Period."
//            Exit Sub
//        End If
//        Try
//            ApplicationSettingsBestWorkflowPeriod = CInt(ApplicationSettingsBestWorkflowPeriodTextBox.Text)
//            If ApplicationSettingsBestWorkflowPeriod < 0 Then
//                ApplicationSettingsBestWorkflowPeriod = 0
//            End If
//        Catch ex As Exception
//            lblMessage.Text = "Please enter a valid Best Workflow Period"
//            Exit Sub
//        End Try


//        'Validate and read Breech Period
//        If ApplicationSettingsBreechPeriodTextBox.Text.Length< 1 Or ApplicationSettingsBreechPeriodTextBox.Text.Length> 10 Then
//            lblMessage.Text = "Please enter a valid Breech Period."
//            Exit Sub
//        End If
//        Try
//            ApplicationSettingsBreechPeriod = CInt(ApplicationSettingsBreechPeriodTextBox.Text)
//            If ApplicationSettingsBreechPeriod < 0 Then
//                ApplicationSettingsBreechPeriod = 0
//            End If
//        Catch ex As Exception
//            lblMessage.Text = "Please enter a valid Breech Period"
//            Exit Sub
//        End Try


//        'Validate and read Action Period
//        If ApplicationSettingsActionPeriodTextBox.Text.Length< 1 Or ApplicationSettingsActionPeriodTextBox.Text.Length> 10 Then
//            lblMessage.Text = "Please enter a valid Action Period."
//            Exit Sub
//        End If
//        Try
//            ApplicationSettingsActionPeriod = CInt(ApplicationSettingsActionPeriodTextBox.Text)
//            If ApplicationSettingsActionPeriod < 0 Then
//                ApplicationSettingsActionPeriod = 0
//            End If
//        Catch ex As Exception
//            lblMessage.Text = "Please enter a valid Action Period"
//            Exit Sub
//        End Try


//        'Validate and read RT Stage Action Period
//        If ApplicationSettingsRTStageActionPeriodTextBox.Text.Length< 1 Or ApplicationSettingsRTStageActionPeriodTextBox.Text.Length> 10 Then
//            lblMessage.Text = "Please enter a valid RT Stage Action Period."
//            Exit Sub
//        End If
//        Try
//            ApplicationSettingsRTStageActionPeriod = CInt(ApplicationSettingsRTStageActionPeriodTextBox.Text)
//            If ApplicationSettingsRTStageActionPeriod < 0 Then
//                ApplicationSettingsRTStageActionPeriod = 0
//            End If
//        Catch ex As Exception
//            lblMessage.Text = "Please enter a valid RT Stage Action Period."
//            Exit Sub
//        End Try

//        'Create an ApplicationConstants Object and Populate
//        Dim myOBJ_ApplicationConstants As OBJ_ApplicationConstants = New OBJ_ApplicationConstants

//        myOBJ_ApplicationConstants.ID = ApplicationSettingsID
//        myOBJ_ApplicationConstants.DefaultDeferralPeriod = ApplicationSettingsDefaultDeferralPeriod
//        myOBJ_ApplicationConstants.BestWorkflowPeriod = ApplicationSettingsBestWorkflowPeriod
//        myOBJ_ApplicationConstants.BreechPeriod = ApplicationSettingsBreechPeriod
//        myOBJ_ApplicationConstants.ActionPeriod = ApplicationSettingsActionPeriod
//        myOBJ_ApplicationConstants.RTStageActionPeriod = ApplicationSettingsRTStageActionPeriod

//        'Call BLL Function to Update Application Settings
//        If BLL_Administration.UpdateApplicationConstants(myOBJ_ApplicationConstants) = False Then
//            lblMessage.Text = "Unable to update Record. Please contact the System Administrator"
//            Exit Sub
//        End If

//        'All Good so clear message and refresh data control
//        lblMessage.Text = ""
//        gViewApplicationSettings.DataBind()

//    End Sub

//#End Region

