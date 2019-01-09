<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreatePage.aspx.cs" Inherits="Admin_CreatePage" MasterPageFile="~/Member/MemberMaster.master" %>

<asp:Content runat="server" ContentPlaceHolderID="headPH1">
    <title>Create Sheet</title>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="BodyPH1">
    <%--Picker for new page position--%>
    <div class="container">
        <h2>Page Location:</h2>
        <asp:DropDownList CssClass="form-control" ID="menuSectionDropDown" runat="server" OnSelectedIndexChanged="menuSectionDropDown_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem>Choose a menu item</asp:ListItem>
            <asp:ListItem>Induction</asp:ListItem>
            <asp:ListItem>Techniques</asp:ListItem>
            <asp:ListItem>Data Entry</asp:ListItem>
            <asp:ListItem>Dose Calculations</asp:ListItem>
            <asp:ListItem>Mentoring</asp:ListItem>
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
                            <th>Description</th>
                            <th>Approval</th>
                            
                        </tr>
                        <tr>
                            <td>Task Preview</td>
                            <td></td>
                            <td>Incomplete</td>
                            <td>A preview for a task</td>
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
</asp:Content>

