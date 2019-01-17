using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

public partial class Admin_AdminMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //check user authorisation


        //populate navbar with pages
        if (!IsPostBack)
        {
            List<string> menuList = new List<string>();
            menuList = AdminMethods.populateAdminMenu();
            inductionLiteral.Text = menuList[0];
            techniquesLiteral.Text = menuList[1];
            dataEntryLiteral.Text = menuList[2];
            doseCalcLiteral.Text = menuList[3];


        }
    }

   


}
