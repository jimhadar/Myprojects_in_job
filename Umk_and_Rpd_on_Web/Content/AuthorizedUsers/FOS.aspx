<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="FOS.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.FOS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:Table ID="Table1" runat="server" CssClass="GridViewCss">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell Text="№п/п" CssClass="GridViewCss"></asp:TableHeaderCell>
            <asp:TableHeaderCell Text="Тема из рабочей программы" CssClass="GridViewCss"></asp:TableHeaderCell>
            <asp:TableHeaderCell Text="Закрываемая компетенция" CssClass="GridViewCss"></asp:TableHeaderCell>
            <asp:TableHeaderCell Text="Формируемые ЗУНы (З.1, У1, Н1 ...)" CssClass="GridViewCss"></asp:TableHeaderCell>
            <asp:TableHeaderCell Text="Вид и номер задания в ФОС" CssClass="GridViewCss"></asp:TableHeaderCell>
            <asp:TableHeaderCell Text="Критерий оценивания (по 100-балльной шкале)" CssClass="GridViewCss"></asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
