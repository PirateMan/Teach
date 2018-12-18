<%@ Page Language="C#" AutoEventWireup="true" Codefile="Roles.aspx.cs" Inherits="TrainingApp.Roles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" id="rolesHtml">
<head runat="server">  
    
    <meta charset="utf-8" /> <meta name="viewport" http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />
    
    <!-- js -->
    <script src="../scripts/jquery-3.2.1.min.js"></script>
    <script src="../scripts/bootstrap.min.js"></script>
    <script src="../scripts/navSubMenu.js"></script>

    <!-- style -->
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../Stylesheet/mainStyle.css" rel="stylesheet" />
    <link rel="icon" href="../Images/FAVICON.png" />

    <title>Roles & Responsibilities</title>

</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->

        <div class="container-fluid" id="topBar">
            <div class="col-md-8" id="titleText">
                <p><b id="trainingPackageText"><a href="Home.aspx">Training Package</a></b> | Induction | Roles & Responsibilities</p>
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
                        <a href="Home.aspx">Home </a>
                    </li>


                    <!-- Induction -->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Induction <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="Roles.aspx">Roles & Responsibilities</a></li>
                            <li><a href="MapTour.aspx">Department Map</a></li>
                            <li><a href="PhoneNumbers.aspx">Phone Numbers</a></li>
                            <asp:Literal ID="inductionLiteral" runat="server"></asp:Literal>
                        </ul>
                    </li>


                    <!-- Mentorship -->
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Mentorship <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li><a href="Appraisal.aspx">Appraisal</a></li>
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
                    <li class="dropdown" id="adminDrop" runat="server">
                        <a href="#" class="dropdown-toggle hvr-underline-from-center" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Admin <span class="caret"></span></a>
                        <ul class="dropdown-menu">
       
                            <li><a href="../AdminPages/Approvals.aspx">Approvals</a></li>

                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Edits <span class="caret caret-right"></span></a>
                                <ul class="dropdown-menu">
                                    <li><a href="../AdminPages/CreatePage.aspx">Add Page</a></li>
                                    <li><a href="../AdminPages/SignOffSheetEdit.aspx">Add Task</a></li>
                                    <li><a href="../AdminPages/DeletePage.aspx">Delete Page</a></li>
                                </ul>
                            </li>
                                
                            <li><a href="../AdminPages/AuthoriseUser.aspx">User Database</a></li>

                        </ul>
                    </li>

                    </ul>

                </div>
            </div>
        </nav>
        <!-- end of nav -->

        <!-- ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// -->

        <div class="container-fluid" id="rolesContainer">
            <div class="container">

                <div class="col-md-12" id="signOffHeaderContent">
                    <p>Roles and Responsibilities</p>
                </div>

                <br />
                <br />

                <br />
                <br />
                <h2>In the department we have the following groups of  radiotherapy staff:</h2>
                <h3>
                    <br />
                    <strong>Radiotherapy Manager:</strong> Lee Beresford                                     
                <br />
                    <br />
                    <strong>Consultant Radiographer:</strong> Nicky Cornelius
                <br />
                    <br />
                    <strong>Superintendents:</strong> Liz Gascoyne, Karen Cook, Sandy Mappin
                <br />
                    <br />
                    <strong>Portal Image Radiographers:</strong> Debbie Edison, Heather Crust, Alison Dakin, Tracy Harrison, Sandy Mappin 
                <br />
                    <br />
                    <strong>Radiographer Review radiographers:</strong> Allison Chappell, Kerry Geeson, Heidi Mitchell, Helen Norton, Liz Gascoyne, Jane Hall, Angela Turbin
                <br />
                    <br />
                    <strong>Breast Mark-up radiographers:</strong> Rachel Goddard, Jonathon Gordon, Simon Johnson
                <br />
                    <br />
                    <strong>Brachytherapy Radiographers:</strong> Melanie Fisher, Lucy Darby
                <br />
                    <br />
                    <strong>Information Support Radiographer:</strong> Jane Hall, Angela Turbin
                <br />
                    <br />
                    <strong>Radiotherapy Helpers:</strong> Claire Griffiths ,Beth Felton, Mary Campbell, Dawn Annibal </h3>
                <br />
                <br />
                <h2>If you need help in any of the above areas please see a member of that team.</h2>
                <hr />
                <div class="col-md-6">
                    <h3>
                        <br />
                        <strong>CONSULTANTS:</strong>
                        <br />
                        <br />
                        •	Dr Panades 
                            <br />
                        •	Dr Sreenivasan
                            <br />
                        •	Dr Fernandez-Ots
                            <br />
                        •	Dr Chaudhuri
                            <br />
                        •	Dr Papakostidi
                            <br />
                        •	Dr Stokes
                            <br />
                        •	Dr Sanz-Torres
                            <br />
                        •	Dr Sanganalmath
                            <br />
                        •	Dr Ruiz- Echarri
                            <br />
                        <br />
                    </h3>
                </div>

                <div class="col-md-6">
                    <h3>
                        <br />
                        Other groups of staff in the department are:
                            <br />
                        <br />
                        Physicist
                            <br />
                        Dosimetrists
                            <br />
                        Technicians 
                            <br />
                        Schedulers
                            <br />
                        Reception staff
                            <br />
                        Clinic staff
                            <br />
                        Pharmacists
                            <br />
                        Chemo nurses
                            <br />
                        CNS   
                    </h3>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
