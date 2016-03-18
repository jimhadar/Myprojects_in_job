<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="AdminForm.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.for_admin.AdminForm" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <link href="../../App_Themes/StyleSheet_for_FindForm.css" rel="stylesheet" />
    <label>
        Поиск по названию РПД:
        <asp:TextBox runat="server" ID="NameRpdTextBox" Width="350px"></asp:TextBox>
    </label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="Button_ControlDateSaveRPD" runat="server" Text="Найти" CssClass="bttn" OnClick="Button_ControlDateSaveRPD_Click" />
            <asp:Table runat="server" ID="Table_ControlSaveRpd" CssClass="GridViewCss">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="GridViewCss">Id_umk_rpd</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss">Дата сохранения</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss">Логин</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss">Ip адрес</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss">ФИО</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss">Название РПД</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            
            <%--<asp:GridView ID="GridView_ControlSaveRPD" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource_controlSaveRPD">
                <Columns>
                    <asp:BoundField DataField="Id_umk_rpd" HeaderText="Id_umk_rpd" SortExpression="Id_umk_rpd" ControlStyle-Width="100px"/>
                    <asp:BoundField DataField="DateSave" HeaderText="Дата сохранения" SortExpression="DateSave" ControlStyle-Width="150px"/>
                    <asp:BoundField DataField="Login" HeaderText="Логин" SortExpression="Login" ControlStyle-Width="100px" />
                    <asp:BoundField DataField="Ip" HeaderText="Ip адрес" SortExpression="Ip" ControlStyle-Width="100px" />
                    <asp:BoundField DataField="FIO" HeaderText="ФИО" SortExpression="FIO"   />
                    <asp:BoundField DataField="NameRpd" HeaderText="Название РПД" SortExpression="NameRpd" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource_controlSaveRPD" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByNameRpd" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.TmpUMK_rpd_ControlSignUpTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="NameRpdTextBox" Name="NameRpd" PropertyName="Text" Type="String" DefaultValue="" />
                </SelectParameters>
            </asp:ObjectDataSource>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
