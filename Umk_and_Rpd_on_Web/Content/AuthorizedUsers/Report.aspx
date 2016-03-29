<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/Main.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.Report"  ViewStateMode="Enabled" EnableViewState="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <h2>Предметы</h2>
    <label style="display: block;">Выберите какие предметы вывести:</label>
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" ViewStateMode="Enabled" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
        <asp:ListItem Selected="True">
                    все предметы
        </asp:ListItem>
        <asp:ListItem>
                    предметы с пустыми РПД
        </asp:ListItem>
        <asp:ListItem>
                    предметы с заполненными РПД
        </asp:ListItem>
    </asp:RadioButtonList>

    <asp:CheckBox runat="server" ID="WriteSubsOnKafCheckBox" Text="Вывести предметы по кафедре" />
    <asp:DropDownList ID="DropDownList1" runat="server" Style="margin-left: 20px;" DataSourceID="ObjectDataSource_Kafs" DataTextField="NameKaf" DataValueField="CodKaf"></asp:DropDownList>
    <asp:ObjectDataSource ID="ObjectDataSource_Kafs" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData_without_param" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.KafsTableAdapter"></asp:ObjectDataSource>
    <div>
        <asp:Button ID="Button_report_subs" runat="server" Text="Показать отчет" OnClick="Button_report_subs_Click" />
    </div>
    <table style="border-collapse: collapse; width: auto;" runat="server" id="ReportOnSubsEmpty_or_notEmpty" class="GridViewCss" clientidmode="Static">
        <tr>
            <th class="GridViewCss HeaderGridView" style="width:70px; text-align:center;">№ п/п</th>
            <th class="GridViewCss HeaderGridView ColumnSub">Дисциплина</th>
            <th class="GridViewCss HeaderGridView ColumnPlan">Учебный план</th>
        </tr>
    </table>
    <hr />
    <h2>Отчет по направлениям подготовки</h2>
    <table style="border-collapse: collapse;" runat="server" id="ReportOnSpecialityTable" cssclass="GridViewCss">
        <tr>
            <th class="GridViewCss HeaderGridView">Направление подготовки</th>
            <th class="GridViewCss HeaderGridView">Учебный план</th>
            <th class="GridViewCss HeaderGridView">Дисциплин всего</th>
            <th class="GridViewCss HeaderGridView">Кол-во дисциплин, для которых выполнены РПД</th>
            <th class="GridViewCss HeaderGridView">% выполненных РПД</th>
        </tr>
    </table>    
    <hr />
    <h2>Отчет по кафедрам</h2>
    <asp:GridView ID="GridViewReportKafs" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource_report_Kafs" CssClass="GridViewCss">
        <Columns>
            <asp:BoundField DataField="ForReport" HeaderText="Кафедра" SortExpression="ForReport" HeaderStyle-CssClass="HeaderGridView" ItemStyle-CssClass="GridViewCss"/>
            <asp:BoundField DataField="AllCountSubs" HeaderText="Дисциплин всего" SortExpression="AllCountSubs" HeaderStyle-CssClass="HeaderGridView" ItemStyle-CssClass="GridViewCss"/>
            <asp:BoundField DataField="CountzapSubs" HeaderText="Кол-во дисциплин, для которых выполнены РПД" SortExpression="CountzapSubs" HeaderStyle-CssClass="HeaderGridView" ItemStyle-CssClass="GridViewCss" />
            <asp:BoundField DataField="PercentZap" HeaderText="% выполненных РПД" ReadOnly="True" SortExpression="PercentZap" HeaderStyle-CssClass="HeaderGridView" ItemStyle-CssClass="GridViewCss" />
        </Columns>
    </asp:GridView>
    <hr />
    <asp:ObjectDataSource ID="ObjectDataSource_report_Kafs" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.Umk_rpd_reportTableAdapter">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="TypeReport" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>    
</asp:Content>