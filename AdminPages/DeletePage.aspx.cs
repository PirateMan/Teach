using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPages_DeletePage : System.Web.UI.Page
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
            populatePages();

            confirmBtn.Visible = false;

            List<string> menuList = new List<string>();
            menuList = GlobalMethods.populateAdminMenu();
            inductionLiteral.Text = menuList[0];
            techniquesLiteral.Text = menuList[1];
            dataEntryLiteral.Text = menuList[2];
            doseCalcLiteral.Text = menuList[3];
        }
    }


    public void populatePages()
    {
        using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
        {
            List<string> pages = new List<string>();

            pages = (from i in db.TrainingPackage_Modules
                    select i.MODULE).ToList();

            pages.Insert(0, "Choose a Page");


            pagesList.DataSource = pages;
            pagesList.DataBind();

        }
    }

    protected void deletBtn_Click(object sender, EventArgs e)
    {
        if(pagesList.SelectedItem.Text != "Choose a Page")
        {
            confirmBtn.Visible = true;
        }
        else
        {
            error_lbl.Text = "Error: select a page";
        }
        


    }

    protected void confirmBtn_Click(object sender, EventArgs e)
    {

        string selectedPage = pagesList.SelectedItem.Text;

        using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
        {
            var page = (from d in db.TrainingPackage_Modules
                          where d.MODULE == selectedPage
                          select d).Single();

            db.TrainingPackage_Modules.Remove(page);
            db.SaveChanges();
        }

        string root = Server.MapPath("~");
        string chosenPage = "";

        chosenPage = root + "\\Memberpages\\" + selectedPage.Replace(" ", "-") + ".aspx";
      
        if ((System.IO.File.Exists(chosenPage)))
        {
            System.IO.File.Delete(chosenPage);
        }

        Response.Redirect("DeletePage.aspx");

    }

    protected void pagesList_SelectedIndexChanged(object sender, EventArgs e)
    {
        error_lbl.Text = "";
        confirmBtn.Visible = false;
    }
}