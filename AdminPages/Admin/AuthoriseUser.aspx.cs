using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Admin_AuthoriseUser : System.Web.UI.Page
{ 

        protected void Page_Load(object sender, EventArgs e)
        {

            string checkUser = GeneralMethods.checkUser();

            if (!IsPostBack)
            {
               //
            }

        }

        public void fillTable()
        {
            List<string> datasoureList = new List<string>();

            using (TrainingDBEntities1 db = new TrainingDBEntities1())
            {
               var dataset = (from x in db.Users select new { x.Name, x.Username, x.Role, x.Email }).ToList();

                Repeater1.DataSource = dataset;
                Repeater1.DataBind();
            }
        }


        [WebMethod]
        public static void sqlInsert(string username, string authorisation, string adminRights)
        {

            int userRoleIdConverted = 0;

            if (adminRights == "SuperAuthorised")
            {
                userRoleIdConverted = 1;
            }
            if (adminRights == "AdminAuthorised")
            {
                userRoleIdConverted = 2;
            }
            if (adminRights == "MemberAuthorised")
            {
                userRoleIdConverted = 3;
            }

            using (TrainingDBEntities1 db = new TrainingDBEntities1())
            {
                //select the user 
                var user = (from usr in db.Users
                            where usr.Username == username
                            select usr).FirstOrDefault();

                user.Role_ID = userRoleIdConverted; 

                db.SaveChanges();
            }
        }


        [WebMethod]
        public static string deleteRecord(string username)
        {

            using (TrainingDBEntities1 db = new TrainingDBEntities1())
            {
                var user = (from usr in db.Users
                            where usr.Username == username
                            select usr).FirstOrDefault();

            db.Users.Remove(user);
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
