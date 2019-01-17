<%@ Page Language="C#" AutoEventWireup="true" Codefile="AuthoriseUser.aspx.cs" Inherits="Admin_AuthoriseUser" MasterPageFile="../Member/MemberMaster.master" %>

<asp:Content runat="server" ContentPlaceHolderID="headPH1">
    <title>Authorise User</title>


</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="BodyPH1">
       

    <div class="container">

        <div id="dataTableWrapper" style="width:100%" class="dataTableParentHidden">
            <div class="container" id="tableContainer" runat="server">


            <div class="col-md-12">
                <h2>Current Users Database</h2>
            </div>

            <div class="col-md-12" id="currentUsersText">
                <p>When editing fields 'Authorisation' and 'Admin Rights', Fields MUST be either 'YES' or 'NO'</p>
            </div>

            <br />

            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">

                <HeaderTemplate>

                    <table id="usersTable" class="table table-bordered">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Username</th>
                                <th>Email</th>
                                <th>Role_ID</th>
                            </tr>
                        </thead>
                </HeaderTemplate>

                <ItemTemplate>

                            <tr id="tableRowData" runat="server">
                                <td><asp:Label runat="server" ID="Label1" Text='<%#Eval("Name") %>'/></td>       
                                <td><asp:Label runat="server" ID="Label3" Text='<%#Eval("UserName")%>'/></td>
                                <td><asp:Label runat="server" ID="Label2" Text='<%#Eval("Email")%>'/></td>
                                <td><asp:Label runat="server" ID="Label5" Text='<%#Eval("Role_ID")%>'/></td>
                            </tr>

                </ItemTemplate>

                <FooterTemplate>
                    </table>

                </FooterTemplate>

            </asp:Repeater>
        </div>
        </div>

        <br />
        <br />

        </div>
</asp:Content>