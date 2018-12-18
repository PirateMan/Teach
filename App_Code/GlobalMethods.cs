using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

/// <summary>
/// methods that the app uses on most pages
/// </summary>

public static class GlobalMethods
{

    // --------------------------------------------------------------------------------------------------------------------------------------- //
    // ---------------------------------------------     ADD & REMOVE CSS CLASS     ---------------------------------------------------------- //
    // --------------------------------------------------------------------------------------------------------------------------------------- //

    public static void  addCssClass(string classname, System.Web.UI.HtmlControls.HtmlGenericControl elementID)
    {
        elementID.Attributes.Add("class", string.Join(" ", elementID
                   .Attributes["class"]
                   .Split(' ')
                   .Except(new string[] { "", classname })
                   .Concat(new string[] { classname })
                   .ToArray()
           ));
    }


    public static void removeCssClass(string classname, System.Web.UI.HtmlControls.HtmlGenericControl elementID)
    {
        elementID.Attributes.Add("class", string.Join(" ", elementID
                  .Attributes["class"]
                  .Split(' ')
                  .Except(new string[] { "", classname })
                  .ToArray()
          ));
    }


    // ----------------------------------------------------------------------------------------------------------------------------------- //
    //                                                      CHECK CURRENT USER                                                             //
    // ----------------------------------------------------------------------------------------------------------------------------------- //


    public static string checkUser()
    {
        string user1 = HttpContext.Current.User.Identity.Name;
        string role = "";

        using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
        {
            role = (from i in db.TrainingPackage_User
                           join ii in db.TrainingPackage_UserRoles on i.UserRoleID equals ii.ID
                           where i.UserName == user1
                           select ii.RoleName).SingleOrDefault();
        }

        if (role == "Admin")
        {
            return "Authorised";
        }
        else
        {
            return "Unauthorised";
        }
    }


    public static List<string> populateMenu()
    {
        string inductionHtml = "";
        string techniquesHtml = "";
        string dataEntryHtml = "";
        string doseCalcHtml = "";

        using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
        {
            var inductionModules = (from i in db.TrainingPackage_Modules
                                    where i.CATEGORY_ID == 1
                                    select i.MODULE).ToList();

            var techniqueModules = (from i in db.TrainingPackage_Modules
                                    where i.CATEGORY_ID == 2
                                    select i.MODULE).ToList();

            var dataEntryModules = (from i in db.TrainingPackage_Modules
                                    where i.CATEGORY_ID == 3
                                    select i.MODULE).ToList();

            var DoseCalcModules = (from i in db.TrainingPackage_Modules
                                   where i.CATEGORY_ID == 4
                                   select i.MODULE).ToList();

            foreach (var element in inductionModules)
            {
                string oldlink = (element + ".aspx");
                string link = StripURLNotAllowedChars(oldlink);
                inductionHtml += "<li><a href=" + link + ">" + element + "</a></li>";
            }

            foreach (var element in techniqueModules)
            {
                string oldlink = (element + ".aspx");
                string link = StripURLNotAllowedChars(oldlink);
                techniquesHtml += "<li><a href=" + link + ">" + element + "</a></li>";
            }

            foreach (var element in dataEntryModules)
            {
                string oldlink = (element + ".aspx");
                string link = StripURLNotAllowedChars(oldlink);
                dataEntryHtml += "<li><a href=" + link + ">" + element + "</a></li>";
            }

            foreach (var element in DoseCalcModules)
            {
                string oldlink = (element + ".aspx");
                string link = StripURLNotAllowedChars(oldlink);
                doseCalcHtml += "<li><a href=" + link + ">" + element + "</a></li>";
            }
        }

        List<string> menuList = new List<string>();

        menuList.Add(inductionHtml);
        menuList.Add(techniquesHtml);
        menuList.Add(dataEntryHtml);
        menuList.Add(doseCalcHtml);

        return menuList;
    }


    public static List<string> populateAdminMenu()
    {
        string inductionHtml = "";
        string techniquesHtml = "";
        string dataEntryHtml = "";
        string doseCalcHtml = "";

        using (serverBUEntitiesConnection db = new serverBUEntitiesConnection())
        {
            var inductionModules = (from i in db.TrainingPackage_Modules
                                    where i.CATEGORY_ID == 1
                                    select i.MODULE).ToList();

            var techniqueModules = (from i in db.TrainingPackage_Modules
                                    where i.CATEGORY_ID == 2
                                    select i.MODULE).ToList();

            var dataEntryModules = (from i in db.TrainingPackage_Modules
                                    where i.CATEGORY_ID == 3
                                    select i.MODULE).ToList();

            var DoseCalcModules = (from i in db.TrainingPackage_Modules
                                   where i.CATEGORY_ID == 4
                                   select i.MODULE).ToList();

            foreach (var element in inductionModules)
            {
                string oldlink = (element + ".aspx");
                string link = StripURLNotAllowedChars(oldlink);
                inductionHtml += "<li><a href=../MemberPages/" + link + ">" + element + "</a></li>";
            }

            foreach (var element in techniqueModules)
            {
                string oldlink = (element + ".aspx");
                string link = StripURLNotAllowedChars(oldlink);
                techniquesHtml += "<li><a href=../MemberPages/" + link + ">" + element + "</a></li>";
            }

            foreach (var element in dataEntryModules)
            {
                string oldlink = (element + ".aspx");
                string link = StripURLNotAllowedChars(oldlink);
                dataEntryHtml += "<li><a href=../MemberPages/" + link + ">" + element + "</a></li>";
            }

            foreach (var element in DoseCalcModules)
            {
                string oldlink = (element + ".aspx");
                string link = StripURLNotAllowedChars(oldlink);
                doseCalcHtml += "<li><a href=../MemberPages/" + link + ">" + element + "</a></li>";
            }
        }

        List<string> menuList = new List<string>();

        menuList.Add(inductionHtml);
        menuList.Add(techniquesHtml);
        menuList.Add(dataEntryHtml);
        menuList.Add(doseCalcHtml);

        return menuList;
    }


    private static string StripURLNotAllowedChars(string htmlString)
    {
        string pattern = @"\s|\#|\$|\&|\||\!|\@|\%|\^|\*|\<\|\>|\\|\/|\+|\-|\=";
        return Regex.Replace(htmlString, pattern, "-");
    }



}

