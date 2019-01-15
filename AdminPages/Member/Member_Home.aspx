<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Member_Home.aspx.cs" Inherits="Member_Home" MasterPageFile="~/Member/MemberMaster.master"%>

    <asp:content runat="server" ContentPlaceHolderID="HeadPH1">


    <title>Home</title>
    </asp:content>

    <asp:content runat="server" ContentPlaceHolderID="BodyPH1">
        <%--Wrapper for carousel--%>
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Wrapper for slides -->
            <div class="carousel-inner" style="width: 100%">
                <div class="carousel-item active" style="margin:auto">
                    <img src="../Images/values.png" class="auto-style3" />
                </div>
                <div class="carousel-item">
                    <img src="../Images/ambitions.png" class="auto-style3"/>
                </div>                
                <div class="carousel-item">
                    <img src="../Images/programs.png" class="auto-style3" />
                </div>
            </div>

            <!-- Left and right controls -->
            <a class="carousel-control-prev" href="#myCarousel" data-slide="prev">
                <span class="carousel-control-prev-icon"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#myCarousel" data-slide="next">
                <span class="carousel-control-next-icon"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </asp:content>


