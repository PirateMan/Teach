using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Methods for all member but not admin pages
/// </summary>
public class MemberMethods
{
    /// <summary>
    /// Fill member navbar
    /// </summary>
    /// <returns></returns>
    public static List<string> populateMemberMenu()
    {
        string inductionHtml = "";
        string techniquesHtml = "";
        string dataEntryHtml = "";
        string doseCalcHtml = "";

        using (TrainingDBEntities1 db = new TrainingDBEntities1())
        {
            var inductionModules = (from i in db.Tasks
                                    where i.Module_Type_ID == 1
                                    select i.Task_Name).ToList();

            var techniqueModules = (from i in db.Tasks
                                    where i.Module_Type_ID == 2
                                    select i.Task_Name).ToList();

            var dataEntryModules = (from i in db.Tasks
                                    where i.Module_Type_ID == 3
                                    select i.Task_Name).ToList();

            var DoseCalcModules = (from i in db.Tasks
                                   where i.Module_Type_ID == 4
                                   select i.Task_Name).ToList();

            foreach (var element in inductionModules)
            {
                string oldlink = (element + ".aspx");
                string link = GeneralMethods.StripURLNotAllowedChars(oldlink);
                inductionHtml += "<li><a href=../Member/" + link + ">" + element + "</a></li>";
            }

            foreach (var element in techniqueModules)
            {
                string oldlink = (element + ".aspx");
                string link = GeneralMethods.StripURLNotAllowedChars(oldlink);
                techniquesHtml += "<li><a href=../Member/" + link + ">" + element + "</a></li>";
            }

            foreach (var element in dataEntryModules)
            {
                string oldlink = (element + ".aspx");
                string link = GeneralMethods.StripURLNotAllowedChars(oldlink);
                dataEntryHtml += "<li><a href=../Member/" + link + ">" + element + "</a></li>";
            }

            foreach (var element in DoseCalcModules)
            {
                string oldlink = (element + ".aspx");
                string link = GeneralMethods.StripURLNotAllowedChars(oldlink);
                doseCalcHtml += "<li><a href=../Member/" + link + ">" + element + "</a></li>";
            }

            
        }


        //Fill in created pages in navbar
        List<string> menuList = new List<string>();

        //menuList.Add(inductionHtml);
        //menuList.Add(techniquesHtml);
        //menuList.Add(dataEntryHtml);
        //menuList.Add(doseCalcHtml);

        return menuList;
    }


}
