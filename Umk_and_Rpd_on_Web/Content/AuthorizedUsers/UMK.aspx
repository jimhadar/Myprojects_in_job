<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="UMK.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.UMK.UMK" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager runat="server">

    </asp:ScriptManager>
    
    <section style="overflow-y: hidden">
        <section class="ContainerForSoderjTable" style="margin-bottom: 70px;">
            <!--Форма и правила проведения промежуточной аттестации-->
            <h2>Форма и правила проведения промежуточной аттестации (зачета/экзамена)</h2>
            <asp:TextBox ID="FormPromejAttestatTextBox" runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" Height="150px" ClientIDMode="Static"></asp:TextBox>

            <!--Перечень вопросов к зачету/экзамену-->
            <h2>Перечень вопросов к зачету/экзамену</h2>
            
    <asp:TextBox ID="QuestionForExamTextBox" runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" Height="250px" ClientIDMode="Static"></asp:TextBox>    
            <!--Образцы экзаменационных тестов, заданий-->
            <h2>Образцы экзаменационных тестов, заданий</h2>
            
    <asp:TextBox ID="ExampleExTestTextBox" runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" Height="250px" ClientIDMode="Static"></asp:TextBox>
            <br />
        </section>
     </section>
    <div>
        <asp:Button ID="Button_for_pred_page" CssClass="bttn btn-pred-and-next" runat="server" Text="<< Предыдущая страница" OnClick="Button_for_pred_page_Click" />
    </div>
    <script src="../../../Scripts/UMK.js"></script>
</asp:Content>