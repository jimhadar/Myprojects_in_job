<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/Main.Master" AutoEventWireup="true" CodeBehind="Logins.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Logins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource_logins_prepod" BorderStyle="Solid" CaptionAlign="Top" CssClass="GridViewCss" Font-Size="1em">
        <Columns>
            <asp:BoundField DataField="ФИО" HeaderText="ФИО" SortExpression="ФИО" />
            <asp:BoundField DataField="Логин" HeaderText="Логин" SortExpression="Логин" />
        </Columns>
        <HeaderStyle CssClass="HeaderGridView" />
    </asp:GridView>
    <br />
    <asp:SqlDataSource ID="SqlDataSource_logins_prepod" runat="server" ConnectionString="<%$ ConnectionStrings:personalConnectionString %>" SelectCommand="SELECT itemprop_employees_1.FIO as 'ФИО', PeoplenPass.nik as 'Логин' FROM academia.dbo.itemprop_employees(@StudyYear) AS itemprop_employees_1 INNER JOIN PeoplenPass ON PeoplenPass.CodPE = itemprop_employees_1.CodPrep">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="2015" Name="StudyYear" SessionField="Year" />
        </SelectParameters>
    </asp:SqlDataSource>    
</asp:Content>
