using HashLibrary;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace TrainingApp
{

    public partial class Register : System.Web.UI.Page
    {
        // --------------------------------------------------------------------------------------------------------------------------------------- //
        // ---------------------------------------------------     PAGE LOAD EVENT     ----------------------------------------------------------- //
        // --------------------------------------------------------------------------------------------------------------------------------------- //

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // --------------------------------------------------------------------------------------------------------------------------------------- //
        // ---------------------------------------------    SUBMIT BUTTON CLICK EVENT     -------------------------------------------------------- //
        // --------------------------------------------------------------------------------------------------------------------------------------- //

        protected void registerButton_Click(object sender, EventArgs e)
        {
            //remove alert messages
            GlobalMethods.removeCssClass("showDiv", FirstNameNull);
            GlobalMethods.addCssClass("hideDiv", FirstNameNull);
            GlobalMethods.removeCssClass("showDiv", SecondNameNull);
            GlobalMethods.addCssClass("hideDiv", SecondNameNull);
            GlobalMethods.removeCssClass("showDiv", UserNull);
            GlobalMethods.addCssClass("hideDiv", UserNull);
            GlobalMethods.removeCssClass("showDiv", emailNull);
            GlobalMethods.addCssClass("hideDiv", emailNull);
            GlobalMethods.removeCssClass("showDiv", emailTaken);
            GlobalMethods.addCssClass("hideDiv", emailTaken);
            GlobalMethods.removeCssClass("showDiv", usernameTaken);
            GlobalMethods.addCssClass("hideDiv", usernameTaken);
            GlobalMethods.removeCssClass("showDiv", usernameInvalid);
            GlobalMethods.addCssClass("hideDiv", usernameInvalid);
            GlobalMethods.removeCssClass("showDiv", passwordCharacters);
            GlobalMethods.addCssClass("hideDiv", passwordCharacters);

            //check for nulls
            if (FirstNameChoice.Text.Trim() != "" && SecondNameChoice.Text.Trim() != "" && UserNameChoice.Text.Trim() != "" && emailChoice.Text.Trim() != "")
            {
                //check pass length
                if (PasswordChoice.Text == PasswordConfirm.Text && PasswordConfirm.Text.Length > 7)
                {

                    // alphanumeric check
                    if (this.IsAlphaNumeric(UserNameChoice.Text) && UserNameChoice.Text.Length <= 50 && PasswordChoice.Text.Length <= 50)
                    {

                        //variables
                        int userCount = 0;
                        int emailCount = 0;
                        string usernameInsert = UserNameChoice.Text;
                        string emailInsert = emailChoice.Text;
                        string firstNameInsert = FirstNameChoice.Text;
                        string secondNameInsert = SecondNameChoice.Text;
                        string passwordInsert = Hasher.HashString(PasswordChoice.Text);

                        //count if exist
                        using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
                        {
                            userCount = (from o in db.TrainingPackage_User
                                         where o.UserName == usernameInsert
                                         select o).Count();

                            emailCount = (from o in db.TrainingPackage_User
                                         where o.Email == emailInsert
                                         select o).Count();
                        }


                        // email and username check
                        if (emailCount < 1 && userCount < 1)
                        {

                            try
                            {

                                using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
                                {
                                    TrainingPackage_User usr = new TrainingPackage_User
                                    {
                                        FirstName = firstNameInsert,
                                        LastName = secondNameInsert,
                                        UserName = usernameInsert,
                                        Password = passwordInsert,
                                        Email = emailInsert,
                                        UserRoleID = 1,
                                        Authorisation = "NO"
                                    };

                                    db.TrainingPackage_User.Add(usr);
                                    db.SaveChanges();

                                }

                                //create email
                                CreateEmailMessage("excas-l1.ulh.xlincs.nhs.uk", usernameInsert, firstNameInsert, secondNameInsert, emailInsert);

                                //redirect to completion page
                                Response.Redirect("RegisterComplete.aspx", false);

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                        }
                        else //show Username Taken alert message
                        {
                            if (emailCount > 0)
                            {
                                GlobalMethods.removeCssClass("hideDiv", emailTaken);
                                GlobalMethods.addCssClass("showDiv", emailTaken);
                            }

                            if (userCount > 0)
                            {
                                GlobalMethods.removeCssClass("hideDiv", usernameTaken);
                                GlobalMethods.addCssClass("showDiv", usernameTaken);
                            }
                        }
                    }
                    else //show Invalid alert message
                    {
                        GlobalMethods.removeCssClass("hideDiv", usernameInvalid);
                        GlobalMethods.addCssClass("showDiv", usernameInvalid);
                    }
                }
                else //password doesnt = 8 characters
                {
                    GlobalMethods.removeCssClass("hideDiv", passwordCharacters);
                    GlobalMethods.addCssClass("showDiv", passwordCharacters);
                }
            }
            else //show hide null alert message
            {
                if (FirstNameChoice.Text == "")
                {
                    GlobalMethods.removeCssClass("hideDiv", FirstNameNull);
                    GlobalMethods.addCssClass("showDiv", FirstNameNull);
                }
                if (SecondNameChoice.Text == "")
                {
                    GlobalMethods.removeCssClass("hideDiv", SecondNameNull);
                    GlobalMethods.addCssClass("showDiv", SecondNameNull);
                }
                if (UserNameChoice.Text == "")
                {
                    GlobalMethods.removeCssClass("hideDiv", UserNull);
                    GlobalMethods.addCssClass("showDiv", UserNull);
                }
                if (emailChoice.Text == "")
                {
                    GlobalMethods.removeCssClass("hideDiv", emailNull);
                    GlobalMethods.addCssClass("showDiv", emailNull);
                }
            }
        }

        public bool IsAlphaNumeric(string text)
        {
            return Regex.IsMatch(text, "^[a-zA-Z0-9]+$");
        }


        // --------------------------------------------------------------------------------------------------------------------------------------- //
        // ------------------------------------------- SEND EMAIL TO SYSTEM ADMIN ---------------------------------------------------------------- //
        // --------------------------------------------------------------------------------------------------------------------------------------- //

        public static void CreateEmailMessage(string server, string username, string fname, string sname, string emailText)
        {

            try
            {
                string to = "Niall.Logan@ULH.nhs.uk";
                string from = "no-reply@trainingpackage.uk";
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Radiotherapy Training Package User Authentication";
                message.Body =
                @" Authentication required for 
                          
                Email:   {3}
                User:    {0}
                Name:    {1}
                Surname: {2}

                Do not reply to this message.
                Sent from Radiotherapy Training Package.".Replace("{0}", username).Replace("{1}", fname).Replace("{2}", sname).Replace("{3}", emailText);

                SmtpClient client = new SmtpClient(server);
                // Credentials are necessary if the server requires the client 
                // to authenticate before it will send e-mail on the client's behalf.
                client.UseDefaultCredentials = true;
                client.EnableSsl = true;
                client.Send(message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
