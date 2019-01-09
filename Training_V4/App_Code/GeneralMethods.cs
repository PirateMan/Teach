using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Methods shared by all
/// </summary>
public class GeneralMethods
{
    public static string StripURLNotAllowedChars(string htmlString)
    {
        string pattern = @"\s|\#|\$|\&|\||\!|\@|\%|\^|\*|\<\|\>|\\|\/|\+|\-|\=";
        return Regex.Replace(htmlString, pattern, "-");
    }

    /// <summary>
    /// See authorisation level of user
    /// </summary>
    /// <returns>string authorisation level</returns>
    public static string checkUser()
    {
        string user1 = HttpContext.Current.User.Identity.Name;
        int role = 0;

        using (TrainingDBEntities1 db = new TrainingDBEntities1())
        {
            role = (from i in db.Users
                    where i.Username == user1
                    select i.Role_ID).SingleOrDefault();
        }

        if (role == 1)
        {
            return "SuperAuthorised";
        }
        if (role == 2)
        {
            return "AdminAuthorised";
        }
        else if (role == 3)
        {
            return "MemberAuthorised";
        }
        else
        {
            return "Unauthorised";
        }
    }

    // --------------------------------------------------------------------------------------------------------------------------------------- //
    // ---------------------------------------------     ADD & REMOVE CSS CLASS     ---------------------------------------------------------- //
    // --------------------------------------------------------------------------------------------------------------------------------------- //

    public static void addCssClass(string classname, System.Web.UI.HtmlControls.HtmlGenericControl elementID)
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
}