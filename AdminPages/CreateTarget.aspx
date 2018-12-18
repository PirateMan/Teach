<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateTarget.aspx.cs" Inherits="AdminPages_CreateMeeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  <meta charset="utf-8" /> <meta name="viewport" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />
    <!-- js -->
    <script src="../scripts/jquery-3.2.1.min.js"></script>
    <script src="../scripts/moment.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/bootstrap-datepicker.min.js"></script>
    <script src="../TableEdit/jquery.tabledit.min.js"></script>
    <script src="../scripts/navSubMenu.js"></script>
    <script src="../AdminScripts/targetSet.js"></script>

    <!-- style -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../Stylesheet/mainStyle.css" rel="stylesheet" />
    <link rel="icon" href="../Images/FAVICON.png" />

    <title>Create Target</title>
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->

        <div class="container-fluid" id="topBar">
            <div class="col-md-8" id="titleText">
                <p><b id="trainingPackageText"><a href="Home.aspx">Training Package</a></b> | Admin | Create Target</p>
            </div>
            <div class="col-md-4" id="loggedOnUser">Welcome
                <asp:LoginName ID="LoginName1" runat="server" />
                | <a>
                    <asp:LoginStatus ID="LoginStatus1" runat="server" />
                </a></div>
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
                    <ul class="nav navbar-nav" id="navBarItems">

                        <li class="dropdown hvr-underline-from-center" id="homeNav">
                            <a href="Home.aspx">Home </a>
                        </li>

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle hvr-underline-from-center" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Induction <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Sign Off Sheets <span class="caret caret-right"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="../MemberPages/CoreLearning.aspx">Core Learning Self Sign</a></li>
                                        <li><a href="../MemberPages/GenSelfSign.aspx">General Self Signs</a></li>
                                    </ul>
                                </li>
                                <li><a href="../MemberPages/Roles.aspx">Roles & Responsibilities</a></li>
                                <li><a href="../MemberPages/MapTour.aspx">Map & Tour</a></li>
                            </ul>
                        </li>

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle hvr-underline-from-center" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Mentorship <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="#">Appraisal</a></li>
                            </ul>
                        </li>

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle hvr-underline-from-center" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Techniques & Equipment <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Sign Off Sheets <span class="caret caret-right"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="../MemberPages/EquipmentUser.aspx">Equipment Sign Off Sheet</a></li>
                                        <li><a href="../MemberPages/LinacProcedures.aspx">Linac Procedures Sign Off Sheet</a></li>
                                        <li><a href="../MemberPages/TechniquesUser.aspx">Techniques Sign Off Sheet</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle hvr-underline-from-center" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Paperwork <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li><a href="#">Calculations Workbook</a></li>
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Sign Off Sheets <span class="caret caret-right"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="../MemberPages/Calculations.aspx">Calculations Sign Off Sheet</a></li>
                                        <li><a href="../MemberPages/DEOSignOff.aspx">DEO Sign Off Sheet</a></li>
                                    </ul>
                                </li>
                                <!--<li role="separator" class="divider"></li>-->
                            </ul>
                        </li>

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle hvr-underline-from-center" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Admin <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Approvals <span class="caret caret-right"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="CalculationApproval.aspx">Calculation Approval</a></li>
                                        <li><a href="CoreLearningApproval.aspx">CoreLearning Approval</a></li>
                                        <li><a href="DeoApproval.aspx">DEO Approval</a></li>
                                        <li><a href="EquipmentApproval.aspx">Equipment Approval</a></li>
                                        <li><a href="GeneralTaskApproval.aspx">General Task Approval</a></li>
                                        <li><a href="LinacProcedureApproval.aspx">Linac Procedure Approval</a></li>
                                        <li><a href="TechniquesApproval.aspx">Techniques Approval</a></li>
                                    </ul>
                                </li>

                                 <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Admin Tools <span class="caret caret-right"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="AuthoriseUser.aspx">Authorise User</a></li>
                                    </ul>
                                </li>

                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Edits <span class="caret caret-right"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="SignOffSheetEdit.aspx">Sign Off Sheet Edits</a></li>
                                    </ul>
                                </li>

                            </ul>
                        </li>
                    </ul>

                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </nav>

        <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->


        <div class="container" id="targetForm">

            <div class="col-md-12" id="targetCreateHeading">
                <h1>Create Meeting Target</h1>
            </div>

            <div class="row" id="TargetSelectUserRow">
                <div class="col-md-1 targetTitles">User</div>
                <div class="col-md-11" runat="server">
                    <asp:DropDownList ID="chosenUser" CssClass="form-control" runat="server" AppendDataBoundItems="true" AutoPostBack="True">
                        <asp:ListItem Value="Choose a User"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row" id="targetNameRow">
                <div class="col-md-1 targetTitles">Target</div>
                <div class="col-md-7">
                    <asp:TextBox ID="targetTextbox" class="form-control" placeholder="Create a target" runat="server"></asp:TextBox>
                </div>

                <div class="col-md-1 targetTitles">Date</div>
                <div class="col-md-3">
                    <asp:TextBox ID="targetDateTextBox" class="form-control myDate" type="input" placeholder="Date" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row" id="targetDescriptionRow">
                <div class="col-md-1 targetTitles">Description</div>
                <div class="col-md-11">
                    <asp:TextBox ID="targetDescTextBox"
                        class="form-control"
                        placeholder="Target Description"
                        TextMode="MultiLine"
                        Columns="50"
                        Rows="5"
                        runat="server">
                    </asp:TextBox>
                </div>
            </div>

            <div class="row" id="targetCreateButton">
                <div class="col-md-1"></div>
                <div class="col-md-2">
                    <asp:Button ID="createTarget" CssClass="btn btn-new1" runat="server" Text="Create" OnClick="createTarget_Click" />
                </div>
            </div>
            <!-- /.End of Container -->
        </div>


    </form>

    <script>

        $(document).ready(function () {

            $('#createTarget').prop('disabled', true);
            $('#createTarget').attr(
                          {
                              "title": "Fill In Blank Fields"
                          });

            //table functionality on user changes
            $("#targetForm").on("keyup change input", function () {

                var chosenUser = document.getElementById("chosenUser");
                var targetTextBox = document.getElementById("targetTextbox");
                var targetDateTextBox = document.getElementById("targetDateTextbox");
                    
                var targetInput = targetTextBox.value;
                var targetDescInput = $("#targetDescTextBox").val();

                var stop = 0;

                if (targetDescInput != "" && targetInput != "") {
                    $('#createTarget').prop('disabled', false);
                    $('#createTarget').attr(
                           {
                               "title": "Fill In Blank Fields"
                           });
                }
                else {
                    $('#createTarget').prop('disabled', true);
                    $('#createTarget').attr(
                           {
                               "title" : "Fill In Blank Fields"
                           });
                }


            });
        });



    </script>



</body>
</html>
