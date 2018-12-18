<%@ Page Language="C#" AutoEventWireup="true" Codefile="Register.aspx.cs" Inherits="TrainingApp.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 

    <meta charset="utf-8" />
    <meta name="viewport" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />

    <!-- Favicon -->
    <link rel="shortcut icon" href="Images/a.ico" type="image/x-icon" />

    <!-- JavaScript -->
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/registerScript.js"></script>

    <!-- Style -->
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
    <link rel="stylesheet" href="Content/bootstrap-theme.min.css" />
    <link href="Stylesheet/mainStyle.css" rel="stylesheet" />
    <link rel="icon" href="Images/FAVICON.png" />

    <!-- Title -->
    <title>Register</title>

</head>
<body>
    <form id="form1" runat="server">
      
    <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->

        <div class="container-fluid" id="topBar">
            <div class="col-md-8" id="titleText"><p><b id="trainingPackageText"><a href="Home.aspx">Training Package</a></b> | Register</p></div>
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

        <!-- Register Info -->
        <div class="container">
            <div class="col-md-4"></div>
            <div class="col-md-4" id="regContainer">

                <h2 id="registerText">Register</h2>
                <h4>Please fill out the registration form</h4>

                <!-- First Name -->
                <asp:TextBox ID="FirstNameChoice" class="form-control" runat="server" placeholder="First Name"></asp:TextBox>
                <div class="hideDiv" id="FirstNameNull" runat="server">
                    <div id="FirstNameNullAlert" class="regValidation">
                        <p>Field Is Empty!</p>
                    </div>
                </div>
                <br />

                <!-- Second Name -->
                <asp:TextBox ID="SecondNameChoice" class="form-control" runat="server" placeholder="Last Name"></asp:TextBox>
                <div class="hideDiv" id="SecondNameNull" runat="server">
                    <div class="regValidation" id="SecondNameNullAlert">
                        <p>Field Is Empty!</p>
                    </div>
                </div>
                <br />

                <!-- Email -->
                <asp:TextBox ID="emailChoice" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
                <div class="hideDiv" id="emailNull" runat="server">
                    <div class="regValidation" id="EmailNullAlert">
                        <p>Field Is Empty!</p>
                    </div>
                </div>
                <div class="hideDiv" id="emailTaken" runat="server">
                    <div class="regValidation" id="EmailTakenAlert">
                        <p>Email Taken - Choose another</p>
                    </div>
                </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="emailChoice" ErrorMessage="Enter Valid Email address" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>

                <br />

                <!-- User Name -->
                <asp:TextBox ID="UserNameChoice" class="form-control" runat="server" placeholder="Choose a Username"></asp:TextBox>
                <div class="hideDiv" id="UserNull" runat="server">
                    <div class="regValidation" id="UserNullAlert">
                        <p>Field Is Empty!</p>
                    </div>
                </div>

                <div class="hideDiv" id="usernameTaken" runat="server">
                    <div class="regValidation" id="UserTakenAlert">
                        <p>Username Taken - Choose another</p>
                    </div>
                </div>

                <div class="hideDiv" id="usernameInvalid" runat="server">
                    <div class="regValidation" id="UserInvalidAlert">
                        <p>Username Invalid - Please use: a-z, A-Z, 0-9</p>
                    </div>
                </div>
                <br />

                <!-- Password -->
                <asp:TextBox ID="PasswordChoice" class="form-control" TextMode="Password" runat="server" placeholder="Choose a Password"></asp:TextBox><br />
                <asp:TextBox ID="PasswordConfirm" class="form-control" TextMode="Password" runat="server" onChange="checkPasswordMatch()" placeholder="Confirm Password"></asp:TextBox>

                <div class="hideDiv" id="passwordsDontMatch" runat="server">
                    <div class="regValidation" id="passwordDontMatchAlert">
                         <p>Passwords Do Not Match!</p>
                    </div>
                </div>

                <div class="hideDiv" id="passwordsMatch" runat="server">
                    <div class="regValidationTrue" id="passwordMatchAlert">
                         <p>Passwords Match</p>
                    </div>
                </div>

                <div class="hideDiv" id="passwordCharacters" runat="server">
                    <div class="regValidation" id="passwordCharactersAlert">
                        <p>Password must be 8 or more Characters</p>
                    </div>

                </div>
                <br />

                <!-- Register Button -->
                <div id="registerButtonContainer">
                    <asp:Button ID="registerButton" CssClass="btn btn-new1" runat="server" Text="Submit" OnClick="registerButton_Click" />
                </div>
            </div>

        </div>
    </form>
</body>

</html>
