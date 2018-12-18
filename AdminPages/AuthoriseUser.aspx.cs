using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TrainingApp.AdminPages
{
    public partial class AuthoriseUser : System.Web.UI.Page
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
                fillTable();

                List<string> menuList = new List<string>();
                menuList = GlobalMethods.populateAdminMenu();
                inductionLiteral.Text = menuList[0];
                techniquesLiteral.Text = menuList[1];
                dataEntryLiteral.Text = menuList[2];
                doseCalcLiteral.Text = menuList[3];
            }

        }

        public void fillTable()
        {
            List<string> datasoureList = new List<string>();

            using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
            {
               var dataset = (from x in db.TrainingPackage_User select new { x.FirstName, x.LastName, x.UserName, x.Authorisation, AdminRights = x.UserRoleID }).ToList();

                Repeater1.DataSource = dataset;
                Repeater1.DataBind();
            }
        }


        [WebMethod]
        public static void sqlInsert(string username, string authorisation, string adminRights)
        {

            int userRoleIdConverted = 0;

            if (adminRights == "NO")
            {
                userRoleIdConverted = 1;
            }
            if (adminRights == "YES")
            {
                userRoleIdConverted = 2;
            }

            using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
            {
                //select the user 
                var user = (from usr in db.TrainingPackage_User
                            where usr.UserName == username
                            select usr).FirstOrDefault();

                user.UserRoleID = userRoleIdConverted; 
                user.Authorisation = authorisation.ToString(); 

                db.SaveChanges();
            }
        }


        [WebMethod]
        public static string deleteRecord(string username)
        {

            using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
            {
                var user = (from usr in db.TrainingPackage_User
                            where usr.UserName == username
                            select usr).FirstOrDefault();

                    db.TrainingPackage_User.Remove(user);
                    db.SaveChanges();
            }

            return "done";
        }


        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            Label userRole = (Label)e.Item.FindControl("Label5");

            if (userRole != null)
            {
                string userRoleText = userRole.Text.ToString();

                if (userRoleText != "")
                {
                    if (userRoleText == "1")
                    {
                        // user is only user = no
                        userRole.Text = "NO";
                    }
                    if (userRoleText == "2")
                    {
                        //user is admin = yes
                        userRole.Text = "YES";
                    }
                }
            }
        }


    }
}