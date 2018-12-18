<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreatePage.aspx.cs" Inherits="CreatePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  
    
    <meta charset="utf-8" /> <meta name="viewport" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />
    
    <!-- js -->
    <script src="../scripts/jquery-3.2.1.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/bootstrap-datepicker.min.js"></script>
    <script src="../TableEdit/jquery.tabledit.min.js"></script>
    <script src="../scripts/navSubMenu.js"></script>
    <script src="../AdminScripts/CreatePage.js"></script>

    <!-- style -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker.min.css" rel="stylesheet" /> 
    <link href="../Stylesheet/mainStyle.css" rel="stylesheet" />
    <link rel="icon" href="../Images/FAVICON.png" />

    <title>Create Sign-off Sheet</title>
</head>

<body>

    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <div class="container-fluid" id="topBar">
            <div class="col-md-8" id="titleText">
                <p><b id="trainingPackageText"><a href="Home.aspx">Training Package</a></b> | Edit | Create a Page</p>
            </div>
            <div class="col-md-4" id="loggedOnUser">
                Welcome
                <asp:LoginName ID="LoginName1" runat="server" />
                | <a>
                    <asp:LoginStatus ID="LoginStatus1" runat="server" />
                </a>
            </div>
        </div>

        <div class="container-fluid" id="underTopBar"></div>

         <!-- navigation -->
        <nav class="navbar navbar-default" id="navbarContainer">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1" aria-expanded="false">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>


            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav" id="navBarItems">

                    <!-- Home -->
                    <li class="dropdown hvr-underline-from-center" id="homeNav">
                        <a href="../MemberPages/Home.aspx">Home </a>
                    </li>


                    <!-- Induction -->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Induction <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="../MemberPages/Roles.aspx">Roles & Responsibilities</a></li>
                            <li><a href="../MemberPages/MapTour.aspx">Department Map</a></li>
                            <li><a href="../MemberPages/PhoneNumbers.aspx">Phone Numbers</a></li>
                            <asp:Literal ID="inductionLiteral" runat="server"></asp:Literal>
                        </ul>
                    </li>


                    <!-- Mentorship -->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Mentorship <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="../memberpages/appraisal.aspx">Appraisal</a></li>
                        </ul>
                    </li>


                    <!-- Techniques -->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Techniques <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                                <asp:Literal ID="techniquesLiteral" runat="server"></asp:Literal>
                        </ul>
                    </li>


                    <!-- Data Entry -->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Data Entry <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <asp:Literal ID="dataEntryLiteral" runat="server"></asp:Literal>
                        </ul>
                    </li>


                    <!-- Dose Calculations -->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dose Calculations <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <asp:Literal ID="doseCalcLiteral" runat="server"></asp:Literal>
                        </ul>
                    </li>
                     

                    <!-- Admin -->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle hvr-underline-from-center" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Admin <span class="caret"></span></a>
                        <ul class="dropdown-menu">
       
                            <li><a href="Approvals.aspx">Approvals</a></li>

                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Edits <span class="caret caret-right"></span></a>
                                <ul class="dropdown-menu">
                                    <li><a href="CreatePage.aspx">Add Page</a></li>
                                    <li><a href="SignOffSheetEdit.aspx">Add Task</a></li>
                                    <li><a href="DeletePage.aspx">Delete Page</a></li>
                                </ul>
                            </li>
                                
                            <li><a href="AuthoriseUser.aspx">User Database</a></li>

                        </ul>
                    </li>

                    </ul>

                </div>
            </div>
        </nav>
        <!-- end of nav -->


        <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->

        
        <div class="container">
            <h2>Page Location:</h2>
            <asp:DropDownList CssClass="form-control" ID="menuSectionDropDown" runat="server" OnSelectedIndexChanged="menuSectionDropDown_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem>Choose a menu item</asp:ListItem>
                <asp:ListItem>Induction</asp:ListItem>
                <asp:ListItem>Techniques</asp:ListItem>
                <asp:ListItem>Data Entry</asp:ListItem>
                <asp:ListItem>Dose Calculations</asp:ListItem>
            </asp:DropDownList>
        </div>

        <br />

        <hr />

        <!-- induction selection -->

        <asp:Panel ID="createPanel" runat="server">

            <div id="createPageContainer" class="container">

                <div class="col-md-12">
                    <h3>Page Title:</h3>
                    <asp:TextBox CssClass="form-control" ID="txtTitle" runat="server"></asp:TextBox>
                </div>

                <br />
                <br />

                <div class="col-md-12">
                    <h3>Select a page template:</h3>
                    <asp:DropDownList CssClass="form-control" ID="TemplateChoice" runat="server" OnSelectedIndexChanged="TemplateChoice_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem>Choose a page template</asp:ListItem>
                        <asp:ListItem>Sign-off Sheet - Default</asp:ListItem>
                        <asp:ListItem>Sign-off Sheet - Demo</asp:ListItem>
                        <asp:ListItem>Sign-off Sheet - Demo & Case Number</asp:ListItem>
                        <asp:ListItem>Sign-off Sheet - Case Number</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-md-12" id="InductionButtonContainer">
                    <asp:Button ID="CreateButton" CssClass="btn btn-new1" runat="server" OnClick="btnCreate_Click" Text="Create" />
                </div>

                <div class="col-md-12" id="CPerrorLabel">
                    <asp:Label ID="error_lbl" runat="server"></asp:Label>
                </div>

            </div>

        </asp:Panel>

        <asp:Panel ID="previewPanelDefault" runat="server">
            <div class="container previewPanels">              
                <div class="col-md-12">
                    <h3>Preview</h3>
                </div>            
                <br />
                <div class="col-md-12">
                    <table class="table table-striped">
                        <tr>
                            <th>Task</th>
                            <th>Date Completed</th>
                            <th>Completion</th>
                            <th>Approval</th>
                        </tr>
                        <tr>
                            <td>Task Preview</td>
                            <td></td>
                            <td>Incomplete</td>
                            <td>Unapproved</td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="previewPanelDemo" runat="server">
            <div class="container previewPanels">              
                <div class="col-md-12">
                    <h3>Preview</h3>
                </div>            
                <br />
                <div class="col-md-12">
                    <table class="table table-striped">
                        <tr>
                            <th>Task</th>
                            <th>Demonstration By</th>
                            <th>Date Completed</th>
                            <th>Completion</th>
                            <th>Approval</th>
                        </tr>
                        <tr>
                            <td>Task Preview</td>
                            <td></td>
                            <td></td>
                            <td>Incomplete</td>
                            <td>Unapproved</td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="previewPanelDemoCase" runat="server">
            <div class="container previewPanels">              
                <div class="col-md-12">
                    <h3>Preview</h3>
                </div>            
                <br />
                <div class="col-md-12">
                    <table class="table table-striped">
                        <tr>
                            <th>Task</th>
                            <th>Demonstration By</th>
                            <th>Case Number</th>
                            <th>Date Completed</th>
                            <th>Completion</th>
                            <th>Approval</th>
                        </tr>
                        <tr>
                            <td>Task Preview</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>Incomplete</td>
                            <td>Unapproved</td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="previewPanelCase" runat="server">
            <div class="container previewPanels">              
                <div class="col-md-12">
                    <h3>Preview</h3>
                </div>            
                <br />
                <div class="col-md-12">
                    <table class="table table-striped">
                        <tr>
                            <th>Task</th>
                            <th>Case Number</th>
                            <th>Date Completed</th>
                            <th>Completion</th>
                            <th>Approval</th>
                        </tr>
                        <tr>
                            <td>Task Preview</td>
                            <td></td>
                            <td></td>
                            <td>Incomplete</td>
                            <td>Unapproved</td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>


    </form>
</body>

</html>
