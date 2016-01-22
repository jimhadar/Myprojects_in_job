<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="FOS.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.FOS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager runat="server" />
    <script src="../../Scripts/FOS.js">

    </script>
    <div>
        <asp:Timer runat="server" Interval="600000" ID="Timer1"></asp:Timer>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
        </Triggers>
        <ContentTemplate>            
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <section>
        <asp:Button ID="Button_for_pred_page" CssClass="bttn btn-pred-and-next" runat="server" Text="<< Предыдущая страница" OnClick="Button_for_pred_page_Click"/>
    </section>
</asp:Content>
