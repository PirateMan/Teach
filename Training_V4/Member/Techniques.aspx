<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Techniques.aspx.cs" Inherits="Member_Techniques" MasterPageFile="~/Member/MemberMaster.master" %>

<asp:Content runat="server" ContentPlaceHolderID="headPH1">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <title>Techniques</title>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="BodyPH1">
    <asp:GridView 
        ID="TechniquesGridView" 
        runat="server" AutoGenerateColumns="False" 
        DataSourceID="techniquesDataSource"
        DataKeyNames="ID"
        >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="techniquesLabelID" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
            
            <asp:TemplateField>
                <HeaderTemplate>
                    Task Name
                </HeaderTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="Task_NameTextBox" style="text-align: center;" Width="100px" runat="server" Text='<%# Eval("Task_Name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Task_NameLabel" Width="80px" CssClass="SmallDefaultBoldText" runat="server" Text='<%# Eval("Task_Name") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="110px" HorizontalAlign="Center" />
            </asp:TemplateField>
        </Columns>













    </asp:GridView>


    <asp:ObjectDataSource ID="techniquesDataSource" runat="server" 
        SelectMethod="Entry" 
        TypeName="TrainingDBEntities1">

    </asp:ObjectDataSource>





    <div class="col-md-12">

    </div>
</asp:Content>