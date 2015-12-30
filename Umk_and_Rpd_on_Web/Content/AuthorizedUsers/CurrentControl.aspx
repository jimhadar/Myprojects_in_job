<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="CurrentControl.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.CurrentControl" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager runat="server">

    </asp:ScriptManager>
    <link rel="stylesheet" href="../../Scripts/CurrentControl.js" />
    <section style="overflow-y: hidden">
        <section class="ContainerForSoderjTable" style="margin-bottom: 70px;">
            <!--Организация текущего контроля-->
            <h2>Организация текущего контроля</h2>
            <table id="CurrentControlHtmlTable" runat="server" class="for_CurControlTable GridViewCss" onclick="CurrentControl.ClickOnCell(event);" onkeyup="CurrentControl.ClickOnCell(event);" clientidmode="Static">
                <tr>
                    <th class="HeaderGridView formCurControlColumn">Форма текущего контроля успеваемости</th>
                    <th class="HeaderGridView NumberBallColumn">Количество баллов</th>
                    <th class="HeaderGridView">Раздел и тема дисциплины</th>
                    <th class="HeaderGridView for_del_str"></th>
                </tr>
            </table>
    </section>
    </section>
    <div>
        <asp:Button ID="Button_next_page" CssClass="bttn btn-pred-and-next" runat="server" Text="Следующая страница >>" OnClick="Button_next_page_Click" />
        <asp:Button ID="Button_for_pred_page" CssClass="bttn btn-pred-and-next" runat="server" Text="<< Предыдущая страница" OnClick="Button_for_pred_page_Click" />
    </div>
    <input type="hidden" runat="server" id="CurrentControlTableRowCount" clientidmode="static" />
    <script src="../../Scripts/CurrentControl.js" >
    </script>
</asp:Content>
