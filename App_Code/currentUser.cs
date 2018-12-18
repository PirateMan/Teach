using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// current user for password recovery
/// </summary>
public static class currentUser
{  
    private static string username = "";

    public static string user
    {
        get { return username; }
        set { username = value; }
    }

}
