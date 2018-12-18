<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Approvals.aspx.cs" Inherits="TrainingApp.AdminPages.Approvals" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" charset="utf-8" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />

    <!-- js -->
    <script src="../scripts/jquery-3.2.1.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../TableEdit/jquery.tabledit.min.js"></script>
    <script src="../scripts/navSubMenu.js"></script>

    <!-- style -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Stylesheet/mainStyle.css" rel="stylesheet" />
    <link rel="icon" href="../Images/FAVICON.png" />

    <title>Approvals</title>

</head>
<body>

    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->

        <div class="container-fluid" id="topBar">
            <div class="col-md-8" id="titleText">
                <p><b id="trainingPackageText"><a href="Home.aspx">Training Package</a></b> | Admin |  Approval</p>
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

            <div class="col-md-12" id="signOffHeaderContent">
                <p>Approvals</p>
            </div>

            <br />
            <br />
            <hr />
            <br />


            <h3>Select A Sign-Off Sheet To Approve:</h3>

            <br />

            <!-- Signoff dropdownlist -->

            <div class="col-md-12" runat="server">
                <asp:DropDownList ID="signOffDropDown" CssClass="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="signOffDropDown_SelectedIndexChanged">
                    <asp:ListItem Value="Choose a Sheet"></asp:ListItem>
                    <asp:ListItem disabled="true">----------</asp:ListItem>
                    <asp:ListItem Value="All Sheets"></asp:ListItem>
                    <asp:ListItem disabled="true">----------</asp:ListItem>
                </asp:DropDownList>
            </div>


            <br />


            <div class="approvalHeading1">
                <h3>Select A User:</h3>
            </div>

            <br />

            <!-- user dropdownlist -->

            <div class="col-md-12" runat="server">
                <asp:DropDownList ID="userAccountList" CssClass="form-control" runat="server" OnSelectedIndexChanged="userAccountList_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="True">
                    <asp:ListItem Value="Choose a User"></asp:ListItem>
                    <asp:ListItem disabled="true">----------</asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Panel ID="ApprovalTablePanel" runat="server" Visible="false">

                <br />
                <br />
                <br />


                <table class="table table-bordered" id="training">

                    <tr id="tableRowId" runat="server">
                        <th>Task</th>
                        <th>Demonstrated By</th>
                        <th>Case Number</th>
                        <th>Date Completed</th>
                        <th>Completion</th>
                        <th>Approval</th>
                        <th>Approve</th>
                    </tr>

                    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">

                        <ItemTemplate runat="server">

                            <tr id="tableRow" runat="server">
                                <td><asp:Label runat="server" ID="Label1" Text='<%# Eval("Task")%>' /></td>
                                <td id="demoByLabl" runat="server"><asp:Label runat="server" ID="Label3" Text='<%# Eval("DemoBy") %>' /></td>
                                <td><asp:Label runat="server" ID="Label6" Text='<%# Eval("DemoOn") %>' /></td>
                                <td><asp:Label runat="server" ID="Label2" Text='<%# Eval("date") %>' /></td>
                                <td><asp:Label runat="server" ID="Label4" Text='<%# Eval("completion") %>' /></td>
                                <td><asp:Label runat="server" ID="Label5" Text='<%# Eval("approval")%>' /></td>
                                <td id="approvalCheckbox"><asp:CheckBox ID="selectUser" runat="server" /></td>
                            </tr>

                        </ItemTemplate>

                    </asp:Repeater>

                </table>

            </asp:Panel>

            <asp:Panel ID="ApprovalTablePanelAll" runat="server" Visible="false">

                <br />
                <br />
                <br />

                <table class="table table-bordered" id="training1">

                    <tr id="Tr1" runat="server">
                        <th>Module</th>
                        <th>Task</th>
                        <th>Demonstrated By</th>
                        <th>Case Number</th>
                        <th>Date Completed</th>
                        <th>Completion</th>
                        <th>Approval</th>
                        <th>Approve</th>
                    </tr>

                    <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater1_ItemDataBound">

                        <ItemTemplate runat="server">

                            <tr id="tableRow" runat="server">
                                <td><asp:Label runat="server" ID="Label7" Text='<%# Eval("ModuleName")%>' /></td>
                                <td><asp:Label runat="server" ID="Label1" Text='<%# Eval("Task")%>' /></td>
                                <td id="demoByLabl" runat="server"><asp:Label runat="server" ID="Label3" Text='<%# Eval("DemoBy") %>' /></td>
                                <td><asp:Label runat="server" ID="Label6" Text='<%# Eval("DemoOn") %>' /></td>
                                <td><asp:Label runat="server" ID="Label2" Text='<%# Eval("date") %>' /></td>
                                <td><asp:Label runat="server" ID="Label4" Text='<%# Eval("completion") %>' /></td>
                                <td><asp:Label runat="server" ID="Label5" Text='<%# Eval("approval")%>' /></td>
                                <td id="approvalCheckbox"><asp:CheckBox ID="selectUser" runat="server" /></td>
                            </tr>

                        </ItemTemplate>

                    </asp:Repeater>

                </table>

            </asp:Panel>

            <div id="approvalButtonDiv" class="hideDiv" runat="server">
                <div class="col-md-12" id="buttonCol">
                    <asp:Button ID="approvalButton" CssClass="btn btn-new1" runat="server" Text="Approve" OnClick="approvalButton_Click" />
                </div>
            </div>

        </div><!-- end of container -->

        <br />
        <br />
        <br />

    </form>

</body>
</html>