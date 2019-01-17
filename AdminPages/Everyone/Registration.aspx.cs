using HashLibrary;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Diagnostics;

public partial class Everyone_Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // --------------------------------------------------------------------------------------------------------------------------------------- //
    // ---------------------------------------------    SUBMIT BUTTON CLICK EVENT     -------------------------------------------------------- //
    // --------------------------------------------------------------------------------------------------------------------------------------- //

    protected void registerButton_Click(object sender, EventArgs e)
    {
        Debug.Write("Name" + nameChoice.Text + "User" + userNameChoice.Text + "email" + emailChoice.Text);
        //remove alert messages
        GeneralMethods.removeCssClass("showDiv", nameNull);
        GeneralMethods.addCssClass("hideDiv", nameNull);
        GeneralMethods.removeCssClass("showDiv", emailNull);
        GeneralMethods.addCssClass("hideDiv", emailNull);
        GeneralMethods.removeCssClass("showDiv", userNull);
        GeneralMethods.addCssClass("hideDiv", userNull);
        GeneralMethods.removeCssClass("showDiv", usernameTaken);
        GeneralMethods.addCssClass("hideDiv", usernameTaken);
        GeneralMethods.removeCssClass("showDiv", usernameInvalid);
        GeneralMethods.addCssClass("hideDiv", usernameInvalid);
        GeneralMethods.removeCssClass("showDiv", passwordCharacters);
        GeneralMethods.addCssClass("hideDiv", passwordCharacters);
        Debug.Write("Css done");
        //check for nulls
        if (nameChoice.Text.Trim() != "" && userNameChoice.Text.Trim() != "" && emailChoice.Text.Trim() != "")
        {
            Debug.Write("check 1 done");
            //check pass length
            if (passwordChoice.Text == passwordConfirm.Text && passwordConfirm.Text.Length > 5)
            {
                // alphanumeric check
                if (this.IsAlphaNumeric(userNameChoice.Text) && userNameChoice.Text.Length <= 50 && passwordChoice.Text.Length <= 50)
                {
                    //variables
                    int userCount = 0;
                    int emailCount = 0;
                    string usernameInsert = userNameChoice.Text;
                    string emailInsert = emailChoice.Text;
                    string nameInsert = nameChoice.Text;
                    string passwordInsert = Hasher.HashString(passwordChoice.Text);

                    //count if exist
                    using (TrainingDBEntities1 db = new TrainingDBEntities1())
                    {
                        userCount = (from o in db.Users
                                     where o.Username == usernameInsert
                                     select o).Count();

                        emailCount = (from o in db.Users
                                      where o.Email == emailInsert
                                      select o).Count();
                    }


                    // email and username check
                    if (emailCount < 1 && userCount < 1)
                    {

                        try
                        {

                            using (TrainingDBEntities1 db = new TrainingDBEntities1())
                            {
                                User usr = new User
                                {
                                    Name = nameInsert,
                                    Username = usernameInsert,
                                    Password = passwordInsert,
                                    Email = emailInsert,
                                    Role_ID = 3
                                };

                                db.Users.Add(usr);
                                db.SaveChanges();

                            }

                            //create email
                            CreateEmailMessage("excas-l1.ulh.xlincs.nhs.uk", usernameInsert, nameInsert, emailInsert);

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
                            GeneralMethods.removeCssClass("hideDiv", emailTaken);
                            GeneralMethods.addCssClass("showDiv", emailTaken);
                        }

                        if (userCount > 0)
                        {
                            GeneralMethods.removeCssClass("hideDiv", usernameTaken);
                            GeneralMethods.addCssClass("showDiv", usernameTaken);
                        }
                    }
                }
                else //show Invalid alert message
                {
                    GeneralMethods.removeCssClass("hideDiv", usernameInvalid);
                    GeneralMethods.addCssClass("showDiv", usernameInvalid);
                }
            }
            else //password doesnt = 8 characters
            {
                GeneralMethods.removeCssClass("hideDiv", passwordCharacters);
                GeneralMethods.addCssClass("showDiv", passwordCharacters);
            }
        }
        else //show hide null alert message
        {
            if (nameChoice.Text == "")
            {
                GeneralMethods.removeCssClass("hideDiv", nameNull);
                GeneralMethods.addCssClass("showDiv", nameNull);
            }
            if (userNameChoice.Text == "")
            {
                GeneralMethods.removeCssClass("hideDiv", userNull);
                GeneralMethods.addCssClass("showDiv", userNull);
            }
            if (emailChoice.Text == "")
            {
                GeneralMethods.removeCssClass("hideDiv", emailNull);
                GeneralMethods.addCssClass("showDiv", emailNull);
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

    public static void CreateEmailMessage(string server, string username, string name, string emailText)
    {

        try
        {
            string to = "Ciaran.Hickey@ULH.nhs.uk";
            string from = "no-reply@trainingpackage.uk";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Radiotherapy Training Package User Authentication";
            message.Body =
            @" Authentication required for 
                          
                Email:   {3}
                User:    {2}
                Name:    {1}


                This is an automated message.
                Sent from Radiotherapy Training Package.".Replace("{0}", username).Replace("{1}", name).Replace("{2}", emailText);

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