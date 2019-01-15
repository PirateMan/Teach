<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Techniques.aspx.cs" Inherits="Member_Techniques" MasterPageFile="~/Member/MemberMaster.master" %>

<asp:Content runat="server" ContentPlaceHolderID="headPH1">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <title>Techniques</title>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="BodyPH1">
 

                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="ID" Height="169px" Width="993px">
                    <Columns>
                        <asp:BoundField DataField="Task_Name" HeaderText="Task_Name" SortExpression="Task_Name" />
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    </Columns>
    </asp:GridView>



    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TrainingDBConnectionString %>" SelectCommand="SELECT DISTINCT Task.ID, Task.UID, Task.Task_Name, Task.Description, Task.Module_Type_ID FROM [Case] INNER JOIN Task ON [Case].Task_ID = Task.ID INNER JOIN [User] ON [Case].User_ID = [User].ID WHERE (Task.Module_Type_ID = 2)"></asp:SqlDataSource>
    <br />



</asp:Content>