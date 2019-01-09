<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Everyone_Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 

    <meta charset="utf-8" />
    <meta name="viewport" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />

    <!-- Favicon -->
    <link rel="shortcut icon" href="Images/a.ico" type="image/x-icon" />

    <!-- JavaScript -->
    <script src="../Scripts/jquery-3.3.1.min.js"></script>
    <script src="../Scripts/Registration.js"></script>
    <!-- Style -->
    <link rel="stylesheet" href="../Content/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/bootstrap-theme.min.css" />
    <link href="../Stylesheet/mainStyle.css" rel="stylesheet" />


    <!-- Title -->
    <title>Register</title>

</head>

<body>


    <form id="form1" runat="server">
        <!-- Register Info -->
        <div class="container">
            <div class="col-md-4"></div>
            <div class="col-md-4" id="regContainer">

                <h2 id="registerText">Register</h2>
                <h4>Please fill out the registration form</h4>

                <!-- Name -->
                <asp:TextBox ID="nameChoice" class="form-control" runat="server" placeholder="Full Name"></asp:TextBox>
                <div class="hideDiv" id="nameNull" runat="server">
                    <div id="nameNullAlert" class="regValidation">
                        <p>Field Is Empty!</p>
                    </div>
                </div>
                <br />

                <!-- Email -->
                <asp:TextBox ID="emailChoice" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
                <div class="hideDiv" id="emailNull" runat="server">
                    <div class="regValidation" id="emailNullAlert">
                        <p>Field Is Empty!</p>
                    </div>
                </div>
                <div class="hideDiv" id="emailTaken" runat="server">
                    <div class="regValidation" id="emailTakenAlert">
                        <p>Email Taken - Choose another</p>
                    </div>
                </div>
                <asp:RegularExpressionValidator ID="regularExpressionValidator1" runat="server" 
                    ControlToValidate="emailChoice" ErrorMessage="Enter Valid Email address" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>

                <br />

                <!-- User Name -->
                <asp:TextBox ID="userNameChoice" class="form-control" runat="server" placeholder="Choose a Username"></asp:TextBox>
                <div class="hideDiv" id="userNull" runat="server">
                    <div class="regValidation" id="userNullAlert">
                        <p>Field Is Empty!</p>
                    </div>
                </div>

                <div class="hideDiv" id="usernameTaken" runat="server">
                    <div class="regValidation" id="userTakenAlert">
                        <p>Username Taken - Choose another</p>
                    </div>
                </div>

                <div class="hideDiv" id="usernameInvalid" runat="server">
                    <div class="regValidation" id="userInvalidAlert">
                        <p>Username Invalid - Please use: a-z, A-Z, 0-9</p>
                    </div>
                </div>
                <br />

                <!-- Password -->
                <asp:TextBox ID="passwordChoice" class="form-control" TextMode="Password" runat="server" placeholder="Choose a Password"></asp:TextBox><br />
                <asp:TextBox ID="passwordConfirm" class="form-control" TextMode="Password" runat="server" placeholder="Confirm Password"></asp:TextBox>

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
