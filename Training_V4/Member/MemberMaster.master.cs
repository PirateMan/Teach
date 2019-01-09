using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class Member_MemberMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //check user authorisation
        string userRole = GeneralMethods.checkUser();
        if (userRole == "Unauthorised")
        {
            //Response.Redirect("../Everyone/Login.aspx");
        }
        
        //populate navbar with pages
        if (!IsPostBack)
        {
            List<string> menuList = new List<string>();
            menuList = MemberMethods.populateMemberMenu();
            inductionLiteral.Text = menuList[0];
            techniquesLiteral.Text = menuList[1];
            dataEntryLiteral.Text = menuList[2];
            doseCalcLiteral.Text = menuList[3];

            if (userRole == "AdminAuthorised" || userRole == "SuperAuthorised")
            {
                adminDrop.Style.Add("visibility", "visible");
            }
        }
    }



    private static string StripURLNotAllowedChars(string htmlString)
    {
        string pattern = @"\s|\#|\$|\&|\||\!|\@|\%|\^|\*|\<\|\>|\\|\/|\+|\-|\=";
        return Regex.Replace(htmlString, pattern, "-");
    }

 

}
