<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/Main.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Отчет по кафедрам</h2>
    <asp:GridView ID="GridViewReportKafs" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource_report_Kafs" CssClass="GridViewCss">
        <Columns>
            <asp:BoundField DataField="ForReport" HeaderText="Кафедра" SortExpression="ForReport" HeaderStyle-CssClass="HeaderGridView" ItemStyle-CssClass="GridViewCss" />
            <asp:BoundField DataField="AllCountSubs" HeaderText="Дисциплин всего всего" SortExpression="AllCountSubs" HeaderStyle-CssClass="HeaderGridView" ItemStyle-CssClass="GridViewCss" />
            <asp:BoundField DataField="CountzapSubs" HeaderText="Кол-во дисциплин, для которых выполнены РПД" SortExpression="CountzapSubs" HeaderStyle-CssClass="HeaderGridView" ItemStyle-CssClass="GridViewCss" />
            <asp:BoundField DataField="PercentZap" HeaderText="% выполненных РПД" ReadOnly="True" SortExpression="PercentZap" HeaderStyle-CssClass="HeaderGridView" ItemStyle-CssClass="GridViewCss" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource_report_Kafs" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.Umk_rpd_reportTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="False" Name="TypeReport" Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <h2>Отчет по направлениям подготовки</h2>
    <asp:GridView ID="GridViewReportSpeciality" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource_report_Spec" CssClass="GridViewCss">
        <Columns>
            <asp:BoundField DataField="ForReport" HeaderText="Направление" SortExpression="ForReport" HeaderStyle-CssClass="HeaderGridView" ItemStyle-CssClass="GridViewCss" />
            <asp:BoundField DataField="AllCountSubs" HeaderText="Дисциплин всего" SortExpression="AllCountSubs" HeaderStyle-CssClass="HeaderGridView" ItemStyle-CssClass="GridViewCss" />
            <asp:BoundField DataField="CountzapSubs" HeaderText="Кол-во дисциплин, для которых выполнены РПД" SortExpression="CountzapSubs" HeaderStyle-CssClass="HeaderGridView" ItemStyle-CssClass="GridViewCss" />
            <asp:BoundField DataField="PercentZap" HeaderText="% выполненных РПД" ReadOnly="True" SortExpression="PercentZap" HeaderStyle-CssClass="HeaderGridView" ItemStyle-CssClass="GridViewCss" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource_report_Spec" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.Umk_rpd_reportTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="True" Name="TypeReport" Type="Boolean" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
