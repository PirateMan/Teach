using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CreatePage : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {
        //check user has access - replaced

        //hide all table previews
        if (!IsPostBack)
        {
            createPanel.Visible = false;
            previewPanelDefault.Visible = false;
            previewPanelDemo.Visible = false;
            previewPanelDemoCase.Visible = false;
            previewPanelCase.Visible = false;
        }
    }


    /// <summary>
    /// Adds task title and its category type to the database
    /// </summary>
    private void createModuleInDB(int category, int newUID)
    {
        using (TrainingDBEntities1 db = new TrainingDBEntities1())
        {

            //create row instance of task table called module
            Task task = new Task()
            {
                UID = newUID,
                Task_Name = txtTitle.Text,
                Module_Type_ID = category,

            };

            //add row to Tasks db
            db.Tasks.Add(task);
            db.SaveChanges();
        }
    }

    /// <summary>
    /// Create 3 cases for a user on a given task UID
    /// </summary>
    private void CreateCasesInDB(int taskUID)
    {
        string username = HttpContext.Current.User.Identity.Name;

        //using db
        using (TrainingDBEntities1 db = new TrainingDBEntities1())
        {
            var userID = (from j in db.Users
                          where j.Username == username
                          select j.ID).SingleOrDefault();

            for (int i = 1; i < 4; i++)
            {
                Case caseName = new Case()
                {
                    Case_Number = i,
                    Task_ID = taskUID,
                    User_ID = userID
                };

                db.Cases.Add(caseName);
                db.SaveChanges();
            }
        }
    }

    
    

    /// <summary>
    /// Call createPage function (could be swapped for createPage?)
    /// </summary>
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        createPage();
    }






    /// <summary>
    /// Allows viewing of createPanel when something is selected from dropdown
    /// </summary>
    protected void menuSectionDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        //set all false
        createPanel.Visible = false;

        //enable panel on selection
        if (menuSectionDropDown.SelectedItem.Text == "Induction" || menuSectionDropDown.SelectedItem.Text == "Techniques" || menuSectionDropDown.SelectedItem.Text == "Data Entry" || menuSectionDropDown.SelectedItem.Text == "Dose Calculations" || menuSectionDropDown.SelectedItem.Text == "Mentoring")
        {
            createPanel.Visible = true;
        }
    }





    /// <summary>
    /// Creates new page based on selections
    /// </summary>
    public void createPage()
    {
        //If no title or module type is selected, show error
        if (string.IsNullOrWhiteSpace(txtTitle.Text) || TemplateChoice.SelectedIndex == 0)
        {
            error_lbl.Text = "Error: Module title or template is empty";
        }
        else
        {
            //prevents duplication
            int count = 0;
            using (TrainingDBEntities1 db = new TrainingDBEntities1())
            {
                count = (from o in db.Tasks
                         where o.Task_Name == txtTitle.Text
                         select o).Count();
            }

            if (count < 1)
            {
                //gives file path of server
                string root = Server.MapPath("~");
                //full template path of new page
                string SignOffTemplate = "";

                //makes template file path from .temp file
                if (TemplateChoice.SelectedIndex == 1)
                {
                    SignOffTemplate = root + "\\Member\\DefaultTaskPage.temp";
                }

                //if (TemplateChoice.SelectedIndex == 2)
                //{
                //    SignOffTemplate = root + "\\SignOffOne.temp";
                //}

                //if (TemplateChoice.SelectedIndex == 3)
                //{
                //    SignOffTemplate = root + "\\SignOffAll.temp";
                //}

                //if (TemplateChoice.SelectedIndex == 4)
                //{
                //    SignOffTemplate = root + "\\SignOffCaseNumber.temp";
                //}


                // create sign off sheet page from temp file selected
                StringBuilder line = new StringBuilder();
                using (StreamReader rwOpenTemplate = new StreamReader(SignOffTemplate))
                {
                    //while it has not finished reading the template
                    while (!rwOpenTemplate.EndOfStream)
                    {
                        //copy the template to the end
                        line.Append(rwOpenTemplate.ReadToEnd());
                    }
                }

                //give random ID
                int UID = 0;
                string SaveFilePath = "";
                string SaveFileName = "";
                Random ran = new Random();
                UID = ran.Next();

                //Creates page file name 
                string PageName = GeneralMethods.StripURLNotAllowedChars(txtTitle.Text);
                SaveFileName = "\\" + PageName + ".aspx";
                SaveFilePath = root + "\\Member\\" + SaveFileName;
                FileStream fsSave = File.Create(SaveFilePath);

                //Replaces important parts of page using featured sectionas of template file
                if (line != null)
                {
                    line.Replace("[Title]", txtTitle.Text.Replace("<", "&lt;").Replace(">", "&gt;").Replace('"', ' ').Replace('"', ' '));
                    line.Replace("[PageContent]", "<p>" + txtTitle.Text + "</p>");
                    line.Replace("[titleContent]", "<div class='col-md-6' id='titleText'><p><b id='trainingPackageText'><a href='Home.aspx'>Training Package</a></b> | Sign-Off Sheet | " + txtTitle.Text + "</p></div>");
                    line.Replace("[ID]", UID.ToString());

                    StreamWriter sw = null;
                    try
                    {
                        sw = new StreamWriter(fsSave);
                        sw.Write(line);

                        int moduleCategory = menuSectionDropDown.SelectedIndex;
                        createModuleInDB(moduleCategory, UID);
                        CreateCasesInDB(UID);

                    }
                    catch (Exception ex)
                    {
                        //
                    }
                    finally
                    {
                        sw.Close();
                    }
                }

                string redirectLocation = "../Member/" + PageName + ".aspx";
                Response.Redirect(redirectLocation);
            }
            else
            {
                error_lbl.Text = "Error: Module name already exists";
            }
        }
    }





    /// <summary>
    /// Makes selected template visible when dropdown choice is made
    /// </summary>
    protected void TemplateChoice_SelectedIndexChanged(object sender, EventArgs e)
    {
        previewPanelDefault.Visible = false;
        previewPanelDemo.Visible = false;
        previewPanelDemoCase.Visible = false;
        previewPanelCase.Visible = false;

        if (TemplateChoice.SelectedItem.Text == "Sign-off Sheet - Default")
        {
            previewPanelDefault.Visible = true;
        }

        if (TemplateChoice.SelectedItem.Text == "Sign-off Sheet - Demo")
        {
            previewPanelDemo.Visible = true;
        }

        if (TemplateChoice.SelectedItem.Text == "Sign-off Sheet - Demo & Case Number")
        {
            previewPanelDemoCase.Visible = true;
        }

        if (TemplateChoice.SelectedItem.Text == "Sign-off Sheet - Case Number")
        {
            previewPanelCase.Visible = true;
        }
    }
}