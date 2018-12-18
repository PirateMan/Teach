<%@ Page Language="C#" AutoEventWireup="true" Codefile="Login.aspx.cs" Inherits="TrainingApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">  
  
    <!-- Designed By Niall Logan -->
    <meta charset="utf-8" />
    <meta name="viewport" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />

    <!-- Favicon -->
    <link rel="shortcut icon" href="Images/a.ico" type="image/x-icon" />

    <!-- Bootstrap Responsive Design -->
    <script src="scripts/jquery-3.2.1.min.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="../scripts/navSubMenu.js"></script>

    <!-- style -->
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link href="Stylesheet/mainStyle.css" rel="stylesheet" />
    <link rel="icon" href="Images/FAVICON.png" />

    <!-- Title -->
    <title>Login</title>

</head>

<body>

    <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->

    <div class="container-fluid" id="topBar">
        <div class="col-md-12" id="titleText">
            <p><b id="trainingPackageText"><a href="Home.aspx">Training Package</a></b> | Login </p>
        </div>
    </div>

    <div class="container-fluid" id="underTopBar"></div>

    <nav class="navbar navbar-default" id="navbarContainerLogin">
        
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

    <!-- /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->

    <!-- Membership Login Form -->
    <form id="form1" runat="server">
        
        <div class="container">
            
            <div class="col-md-4"></div>
            
            <div class="col-md-4" id="regContainer">
                
                <asp:Login ID="LoginControl" runat="server" OnAuthenticate="LoginControl_Authenticate">

                    <LayoutTemplate>
   
                        <h2>Please Log In</h2>

                        <div id="userLoginText">
                            <asp:TextBox ID="UserName" class="form-control" placeholder="Username" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                        </div>

                        <asp:TextBox ID="Password" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>     
                                        
                        <div id="LoginButtonContainer"> 
                            <asp:Button ID="LoginButton" CssClass="btn btn-new1" runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" />
                            <a href="ForgotPassword.aspx">Forgot Password</a>
                        </div>    
                        
                        <div id="failureTextContainer">
                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"><br /></asp:Literal>
                        </div>         

                    </LayoutTemplate>
                </asp:Login>
            </div>

            <div class="col-md-4"></div>

        </div>
    </form>

</body>
</html>
