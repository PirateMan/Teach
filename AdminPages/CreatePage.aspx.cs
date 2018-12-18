using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

public partial class CreatePage : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string checkUser = GlobalMethods.checkUser();
        if (checkUser == "Unauthorised")
        {
            Response.Redirect("../MemberPages/InvalidAccess.aspx");
        }

        if (!IsPostBack)
        {
            createPanel.Visible = false;
            previewPanelDefault.Visible = false;
            previewPanelDemo.Visible = false;
            previewPanelDemoCase.Visible = false;
            previewPanelCase.Visible = false;

            List<string> menuList = new List<string>();
            menuList = GlobalMethods.populateAdminMenu();
            inductionLiteral.Text = menuList[0];
            techniquesLiteral.Text = menuList[1];
            dataEntryLiteral.Text = menuList[2];
            doseCalcLiteral.Text = menuList[3];
        }
    }


    protected void btnCreate_Click(object sender, EventArgs e)
    {
            createPage();
    }



    private string StripURLNotAllowedChars(string htmlString)
    {
        string pattern = @"\s|\#|\$|\&|\||\!|\@|\%|\^|\*|\<\|\>|\\|\/|\+|\-|\=";
        return Regex.Replace(htmlString, pattern, "-");
    }


    private void createModuleInDB(string moduleName, int category)
    {
        using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
        {
            TrainingPackage_Modules module = new TrainingPackage_Modules()
            {
                MODULE = txtTitle.Text,
                CATEGORY_ID = category
            };

            db.TrainingPackage_Modules.Add(module);
            db.SaveChanges();
        }
    }


    protected void menuSectionDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        //set all false
        createPanel.Visible = false;

        //enable panel on selection
        if (menuSectionDropDown.SelectedItem.Text == "Induction" || menuSectionDropDown.SelectedItem.Text == "Techniques" || menuSectionDropDown.SelectedItem.Text == "Data Entry" || menuSectionDropDown.SelectedItem.Text == "Dose Calculations")
        {
            createPanel.Visible = true;
        }
    }


    public void createPage()
    {

        if (string.IsNullOrWhiteSpace(txtTitle.Text) || TemplateChoice.SelectedIndex == 0)
        {
            error_lbl.Text = "Error: Module title or template is empty";
        }
        else
        {

            int count = 0;
            using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
            {
                count = (from o in db.TrainingPackage_Modules
                         where o.MODULE == txtTitle.Text
                         select o).Count();
            }

            if (count < 1)
            {

                string root = Server.MapPath("~");
                string SignOffTemplate = "";

                if (TemplateChoice.SelectedIndex == 1)
                {
                    SignOffTemplate = root + "\\SignOffDefault.temp";
                }

                if (TemplateChoice.SelectedIndex == 2)
                {
                    SignOffTemplate = root + "\\SignOffOne.temp";
                }

                if (TemplateChoice.SelectedIndex == 3)
                {
                    SignOffTemplate = root + "\\SignOffAll.temp";
                }

                if (TemplateChoice.SelectedIndex == 4)
                {
                    SignOffTemplate = root + "\\SignOffCaseNumber.temp";
                }


                // create sign off sheet page
                StringBuilder line = new StringBuilder();
                using (StreamReader rwOpenTemplate = new StreamReader(SignOffTemplate))
                {
                    while (!rwOpenTemplate.EndOfStream)
                    {
                        line.Append(rwOpenTemplate.ReadToEnd());
                    }
                }

                int ID = 0;
                string SaveFilePath = "";
                string SaveFileName = "";
                Random ran = new Random();
                ID = ran.Next();

                //Page Name Creator   
                string PageName = StripURLNotAllowedChars(txtTitle.Text);
                SaveFileName = "\\" + PageName + ".aspx";
                SaveFilePath = root + "\\MemberPages\\" + SaveFileName;
                FileStream fsSave = File.Create(SaveFilePath);

                if (line != null)
                {
                    line.Replace("[Title]", txtTitle.Text.Replace("<", "&lt;").Replace(">", "&gt;").Replace('"', ' ').Replace('"', ' '));
                    line.Replace("[PageContent]", "<p>" + txtTitle.Text + "</p>");
                    line.Replace("[titleContent]", "<div class='col-md-6' id='titleText'><p><b id='trainingPackageText'><a href='Home.aspx'>Training Package</a></b> | Sign-Off Sheet | " + txtTitle.Text + "</p></div>");
                    line.Replace("[ID]", ID.ToString());

                    StreamWriter sw = null;
                    try
                    {
                        sw = new StreamWriter(fsSave);
                        sw.Write(line);

                        int moduleCategory = menuSectionDropDown.SelectedIndex;
                        createModuleInDB(txtTitle.Text, moduleCategory);

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

                string redirectLocation = "../Memberpages/" + PageName + ".aspx";
                Response.Redirect(redirectLocation);
            }
            else
            {
                error_lbl.Text = "Error: Module name already exists";
            }
        }
    }


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
