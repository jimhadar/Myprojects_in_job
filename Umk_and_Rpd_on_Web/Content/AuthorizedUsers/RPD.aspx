<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="RPD.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.RPD.RPD" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager runat="server">

    </asp:ScriptManager>
    <section style="overflow-y: hidden">
        <section class="ContainerForSoderjTable" style="margin-bottom: 70px;">
            <!--Вид и форма проведения промежуточной аттестации-->
            <h2>Вид и форма проведения промежуточной аттестации</h2>
            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" ID="TypeAndFormCertificationTextBox"></asp:TextBox>

            <!--Используемые образовательные технологии-->
            <h2>Используемые образовательные технологии</h2>
            <p>Доля занятий с использованием активных и интерактивных методов составляет:
                <asp:TextBox ID="TextBox_Part_InteractiveMethods" runat="server" Width="88px"></asp:TextBox>
            </p>
            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" ID="UsedEcucateTechnologyTextBox"></asp:TextBox>

            <!--Образцы тестов и контрольных занятий текущего контроля-->
            <h2>Образцы тестов и контрольных занятий текущего контроля</h2>
            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" ID="ExampleTestCurControlTextBox"></asp:TextBox>

            <!--примерная тематика эссе, рефератов, докладов-->
            <h2>Примерная тематика эссе, рефератов, докладов</h2>
            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" ID="ThemesOfEsseReferatsTextBox"></asp:TextBox>

            <!--Примерные темы курсовых работ, критерии оценивания-->
            <h2>Примерные темы курсовых работ, критерии оценивания</h2>
            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" ID="ThemesOfCourseJobTextBox"></asp:TextBox>

            <!--Методические указания по организации самостоятельной работы-->
            <h2>Методические указания по организации самостоятельной работы</h2>
            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" ID="OrganizationOfIndependentWorkTextBox"></asp:TextBox>

            <!--Промежуточный контроль-->
            <h2>Промежуточный контроль</h2>
            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" ID="InterMediateControlTextBox"></asp:TextBox>

            <!--Образцы тестов, заданий-->
            <h2>Образцы тестов, заданий</h2>
            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" ID="ExampleTestTextBox"></asp:TextBox>

            <!--Перечень вопросов к экзамену (зачету)-->
            <h2>Перечень вопросов к экзамену (зачету)</h2>
            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" ID="QuestionForExamTextBox"></asp:TextBox>

            <!--Материально-техническое обеспечение дисциплины-->
            <h2>Материально-техническое обеспечение дисциплины</h2>
            <asp:TextBox runat="server" TextMode="MultiLine" CssClass="TextBoxStyle" ID="LogisticsDisciplineTextBox"></asp:TextBox>

            <br/>
        </section>
    </section>
    <div>
        <asp:Button ID="Button_next_page" CssClass="bttn btn-pred-and-next" runat="server" Text="Следующая страница >>" OnClick="Button_next_page_Click" />
        <asp:Button ID="Button_for_pred_page" CssClass="bttn btn-pred-and-next" runat="server" Text="<< Предыдущая страница" OnClick="Button_for_pred_page_Click" />
    </div>
</asp:Content>
