using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrainingApp
{
    public partial class InvalidAccess : System.Web.UI.Page
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
            }
        }
    }
}