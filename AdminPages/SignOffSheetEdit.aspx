<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignOffSheetEdit.aspx.cs" Inherits="AdminPages_SignOffSheetEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  
    
    <meta charset="utf-8" /> 
    <meta name="viewport" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />
 
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

    <title>Edit - Sign Off Sheet</title>

</head>
<body>

   <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->

        <div class="container-fluid" id="topBar">
            <div class="col-md-8" id="titleText">
                <p><b id="trainingPackageText"><a href="Home.aspx">Training Package</a></b> | Edits | Sign Off Sheet Edits</p>
            </div>
            <div class="col-md-4" id="loggedOnUser">Welcome
                <asp:LoginName ID="LoginName1" runat="server" />
                | <a>
                    <asp:LoginStatus ID="LoginStatus1" runat="server" />
                </a></div>
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
            
            <div class="col-md-12" id="signOffHeaderContent"><p><b>Edit</b> - Sign Off Sheet</p></div>

            <br />
            <br />
            <hr />
            <br />

                <div><h3>Select A Sign Off Sheet:</h3></div>

                <br />

                <!-- user dropdownlist -->

                <div class="col-md-12" runat="server">
                    <asp:DropDownList ID="signOffEditList" CssClass="form-control" runat="server" OnSelectedIndexChanged="signOffSheetEdit_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="True">
                        <asp:ListItem Value="Choose a Sign Off Sheet"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="showDiv" id="tableContent" runat="server">

                    <br />
                    <br />
                    <br />
                    
                

                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">

                    <HeaderTemplate>

                        <table id="training" class="table table-bordered">
                            <tr>
                                <th>Task</th>
                                <th class="editColumnClosed" id="editTableHeader">Edit</th>
                            </tr>
                    </HeaderTemplate>

                    <ItemTemplate>

                        <tr id="tableRow" runat="server">
                            <td><asp:Label runat="server" ID="Label1" Text='<%#Eval("taskName")%>'/></td>
                            <td id="deleteButton"><button id="deleteB" class="btn btn-sm btn-danger" runat="server" type="button">Delete <i class="glyphicon glyphicon-trash"></i></button></td>
                        </tr>

                    </ItemTemplate>

                    <FooterTemplate>
                        </table>

                    </FooterTemplate>

                </asp:Repeater>

                    <div class="container" id="additemContainer">
                        <div class="hideDiv" id="addItemButton" runat="server">
                            <button id="addItemB" class="btn btn-sm btn-success addItem" type="button" data-toggle="tooltip" data-placement="right" title="Add item to Sheet"><i class="glyphicon glyphicon-plus"></i> Add Item</button>
                        </div>
                    </div>

                     <br />
                     <br />
                     <br />

            </div>

        </div>

    </form>
</body>

    <script>
        $(document).ready(function () {

            $(function () {
                $('[data-toggle="tooltip"]').tooltip()
            })

        });

    </script>


</html>


