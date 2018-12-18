<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mentorMeeting.aspx.cs" Inherits="MemberPages_mentorMeeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">  <meta charset="utf-8" /> <meta name="viewport" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />
    <!-- js -->
    <script src="../scripts/jquery-3.2.1.min.js"></script>
    <script src="../scripts/moment.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/bootstrap-datepicker.min.js"></script>
    <script src="../TableEdit/jquery.tabledit.min.js"></script>
    <script src="../MemberScripts/tableditThreeInputs.js"></script>
    <script src="../scripts/navSubMenu.js"></script>

    <!-- style -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../Stylesheet/mainStyle.css" rel="stylesheet" />
    

    <title>Calculations</title>
</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->

        <div class="container-fluid" id="topBar">
            <div class="col-md-6" id="titleText"><p><b id="trainingPackageText"><a href="Home.aspx">Training Package</a></b> | PaperWork | Calculation Sign Off Sheet</p></div>
            <div class="col-md-2"></div>
            <div class="col-md-4" id="loggedOnUser">Welcome <asp:LoginName ID="LoginName1" runat="server" /> | <a><asp:LoginStatus ID="LoginStatus1" runat="server" /></a></div>
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
                                        <li><a href="CoreLearning.aspx">Core Learning Self Sign</a></li>
                                        <li><a href="GenSelfSign.aspx">General Self Signs</a></li>
                                    </ul>
                                </li>
                                <li><a href="Roles.aspx">Roles & Responsibilities</a></li>
                                <li><a href="MapTour.aspx">Map & Tour</a></li>
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
                                        <li><a href="EquipmentUser.aspx">Equipment Sign Off Sheet</a></li>
                                        <li><a href="LinacProcedures.aspx">Linac Procedures Sign Off Sheet</a></li>
                                        <li><a href="TechniquesUser.aspx">Techniques Sign Off Sheet</a></li>  
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
                                        <li><a href="Calculations.aspx">Calculations Sign Off Sheet</a></li>
                                        <li><a href="DEOSignOff.aspx">DEO Sign Off Sheet</a></li>
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
                                        <li><a href="../AdminPages/CalculationApproval.aspx">Calculation Approval</a></li>
                                        <li><a href="../AdminPages/CoreLearningApproval.aspx">CoreLearning Approval</a></li>
                                        <li><a href="../AdminPages/DeoApproval.aspx">DEO Approval</a></li>
                                        <li><a href="../AdminPages/EquipmentApproval.aspx">Equipment Approval</a></li>
                                        <li><a href="../AdminPages/GeneralTaskApproval.aspx">General Task Approval</a></li>
                                        <li><a href="../AdminPages/LinacProcedureApproval.aspx">Linac Procedure Approval</a></li>
                                        <li><a href="../AdminPages/TechniquesApproval.aspx">Techniques Approval</a></li>
                                    </ul>
                                </li>

                                 <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Admin Tools <span class="caret caret-right"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="../AdminPages/AuthoriseUser.aspx">Authorise User</a></li>
                                    </ul>
                                </li>

                                <li class="dropdown">
                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Edits <span class="caret caret-right"></span></a>
                                    <ul class="dropdown-menu">
                                        <li><a href="../AdminPages/SignOffSheetEdit.aspx">Sign Off Sheet Edits</a></li>
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



    </form>
</body>
</html>
