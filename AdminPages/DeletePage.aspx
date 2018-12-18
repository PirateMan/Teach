<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeletePage.aspx.cs" Inherits="AdminPages_DeletePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" name="viewport" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />

    <!-- js -->
    <script src="../scripts/jquery-3.2.1.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../TableEdit/jquery.tabledit.min.js"></script>
    <script src="../scripts/navSubMenu.js"></script>
    <script src="../AdminScripts/signSheetEdit.js"></script>

    <!-- style -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Stylesheet/mainStyle.css" rel="stylesheet" />
    <link rel="icon" href="../Images/FAVICON.png" />

    <title>Edit - Delete Page</title>

</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->

        <div class="container-fluid" id="topBar">
            <div class="col-md-8" id="titleText">
                <p><b id="trainingPackageText"><a href="Home.aspx">Training Package</a></b> | Edits | Delete Page</p>
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



        <div class="container">
            <h2>Delete Page:</h2>

            <br />

            <asp:DropDownList CssClass="form-control" ID="pagesList" runat="server" OnSelectedIndexChanged="pagesList_SelectedIndexChanged"></asp:DropDownList>

            <br />
            <br />

            <div class="deleteButton">
                <asp:Button CssClass="btn btn-new1" ID="deletBtn" runat="server" Text="Delete" OnClick="deletBtn_Click" />
                <asp:Button CssClass="btn btn-danger" ID="confirmBtn" runat="server" Text="Confirm" OnClick="confirmBtn_Click" />
            </div>

        <br />

            <asp:Label ID="error_lbl" runat="server"></asp:Label>
        </div>


    </form>
</body>
</html>
