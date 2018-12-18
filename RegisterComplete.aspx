<%@ Page Language="C#" AutoEventWireup="true" Codefile="RegisterComplete.aspx.cs" Inherits="TrainingApp.RegisterComplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  <meta charset="utf-8" /> <meta name="viewport" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />

    <meta charset="utf-8" name="viewport" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />

    <!-- Favicon -->
    <link rel="icon" href="../Images/FAVICON.png" />

    <!-- Scripts -->
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
 
    <!-- Own StyleSheet -->
    <link href="Stylesheet/mainStyle.css" rel="stylesheet" />
    <link rel="stylesheet" href="Content/bootstrap.min.css"/>
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css"/>

    <!-- Title -->
    <title>Register</title>

</head>
<body>
    <form id="form1" runat="server">
      
    <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->

        <div class="container-fluid" id="topBar">
            <div class="col-md-8" id="titleText"><p><b id="trainingPackageText"><a href="Home.aspx">Training Package</a></b> | Register Completed</p></div>
            <div class="col-md-4" id="loggedOnUser"><a><asp:LoginStatus ID="LoginStatus1" runat="server" /></a></div>
        </div>

    <div class="container-fluid" id="underTopBar"></div>

    <nav class="navbar navbar-default" id="navbarContainer">
        
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <!--<a class="navbar-brand" href="#">Brand</a>-->
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                
                <ul class="nav navbar-nav">
                    <li class="dropdown hvr-underline-from-center-login">
                        <a href="Login.aspx">Login </a>
                    </li>
                    <li class="dropdown hvr-underline-from-center-login">
                        <a href="Register.aspx">Register </a>
                    </li>
                </ul>

            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>

        <!-- Register Message --> 
        <div class="container">
            <div class="col-md-4"></div>
                <div class="col-md-4" id="regContainer" >    
                    <h2>Register</h2>
                        <h4>Thank you for registering.<br /> Your system administrator has been notified to authorise your log on details. <br /></h4>
			            <h4 id="notAuthorisedText">You will not be able to log on until you are authorised to do so.</h4>      
               </div> 
            <div class="col-md-4"></div>
        </div>


    </form>
</body>


</html>
