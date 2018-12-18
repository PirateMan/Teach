<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

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
            <p><b id="trainingPackageText"><a href="Home.aspx">Training Package</a></b> | Forgot Password </p>
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

    <form id="form1" runat="server">

        <asp:Panel runat="server" ID="beforeEmail">

            <div class="container">

                <!--col spacing -->
                <div class="col-md-4"></div>

                <!-- content -->
                <div class="col-md-4" id="resetPassContainer">
                    <div class="resetHeading">
                        <h2>Reset Password</h2>
                    </div>
                    <div class="resetInfo">
                        <p>Please insert your NHS email address to receive a password reset code</p>
                    </div>
                    <div class="resetSubHeading1">
                        <h3>Email:</h3>
                    </div>
                    <div id="emailInput">
                        <asp:TextBox class="form-control" placeholder="email" ID="EmailTextBox" runat="server"></asp:TextBox></div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                        ControlToValidate="EmailTextBox" ErrorMessage="Enter Valid Email address"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                    </asp:RegularExpressionValidator>
                    <div class="resetSubHeading2">
                        <h3>Username:</h3>
                    </div>
                    <div id="userInput">
                        <asp:TextBox class="form-control" placeholder="username" ID="userTextBox" runat="server"></asp:TextBox></div>
                    <div id="resetButton">
                        <asp:Button ID="resetButtonIn" CssClass="btn btn-new1" runat="server" CommandName="Submit" Text="Reset" OnClick="resetButtonIn_Click" /></div>
                    <br />
                    <asp:Label ID="lbl_msg" runat="server"></asp:Label>
                </div>

                <!--col spacing -->
                <div class="col-md-4"></div>

            </div>

        </asp:Panel>

        <asp:Panel runat="server" ID="afterEmail">

            <div class="container">

                <!--col spacing -->
                <div class="col-md-4"></div>

                <!-- content -->
                <div class="col-md-4" id="codeValidationContainer" >
                    <div class="resetHeading">
                        <h2>Reset Password</h2>
                    </div>
                    <div class="resetInfo">
                        <p>Use the code recieved to change password</p>
                    </div>
                    <div class="resetSubHeading1">
                        <h3>Code:</h3>
                    </div>
                    <div id="codeInput">
                        <asp:TextBox class="form-control" placeholder="validation code" ID="codeTextBox" runat="server"></asp:TextBox></div>
                    <div id="codeButton">
                        <asp:Button ID="codeButtonIn" CssClass="btn btn-new1" runat="server" CommandName="Submit" Text="Submit" OnClick="codeButtonIn_Click" /></div>
                    <br />
                    <asp:Label ID="error_msg" runat="server"></asp:Label>
                </div>

                <!--col spacing -->
                <div class="col-md-4"></div>

            </div>

        </asp:Panel>


        <asp:Panel runat="server" ID="afterConfirm">

            <div class="container">

                <!--col spacing -->
                <div class="col-md-4"></div>

                <!-- content -->
                <div class="col-md-4" id="confirmCodeContainer">

                    <div class="resetHeading">
                        <h2>Reset Password</h2>
                    </div>
                    <div class="resetInfo">
                        <p>Create a new password and confirm</p>
                    </div>

                    <div class="resetSubHeading1">
                        <h3>New Password:</h3>
                    </div>
                    <div id="newInput">
                        <asp:TextBox class="form-control" placeholder="New Password" ID="newPass" TextMode="Password" runat="server"></asp:TextBox></div>

                    <div class="resetSubHeading2">
                        <h3>Confirm Password:</h3>
                    </div>
                    <div id="newConfirmInput">
                        <asp:TextBox class="form-control" placeholder="Confirm Password" TextMode="Password" ID="confirmNewPass" runat="server"></asp:TextBox></div>

                    <div id="ConfirmButton">
                        <asp:Button ID="ConfirmButtonIn" CssClass="btn btn-new1" runat="server" CommandName="Confirm" Text="Submit" OnClick="ConfirmButtonIn_Click" /></div>

                    <br />

                    <div id="passwordMatch" runat="server">
                        <p>Passwords do not match.</p>
                    </div>

                    <asp:RegularExpressionValidator ID="passwordChars" runat="server"
                        ControlToValidate="newPass"
                        ErrorMessage="Password must be 8-20 characters."
                        ValidationExpression="[^\s]{8,20}">
                    </asp:RegularExpressionValidator>

                </div>

                <!--col spacing -->
                <div class="col-md-4"></div>

            </div>

        </asp:Panel>

    </form>
</body>
</html>
