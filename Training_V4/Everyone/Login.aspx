<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Everyone_Login" %>

<!DOCTYPE html>

<head runat="server">  
  

    <meta charset="utf-8" />
    <meta name="viewport" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />

    <!-- Favicon -->
    <link rel="shortcut icon" href="Images/a.ico" type="image/x-icon" />

    <!-- Javascript -->
    <script src="../Scripts/jquery-3.3.1.min.js"></script>

    <!-- style -->
    <link rel="stylesheet" href="../Content/bootstrap.min.css" />
    <link href="../Stylesheet/mainStyle.css" rel="stylesheet" />
    <link rel="icon" href="../Images/FAVICON.png" />

    <!-- Title -->
    <title>Login</title>

</head>

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