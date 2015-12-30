<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="SoderjRazdDiscip.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.SoderjRazdDiscip" EnableViewState="false" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/SoderjRazdDiscip.js" />
        </Scripts>
    </asp:ScriptManager>
    <section id="wrap_for_pop-up-window">
        <div id="pop-up-window">
            <div class="close-pop-up">
                <img onclick="SoderjRazdDiscip.ShowPopUp_for_find_liter('none'); SoderjRazdDiscip.ClearAllElement_in_findLiterWindow();" src="http://sergey-oganesyan.ru/wp-content/uploads/2014/01/close.png" />
            </div>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="margin: 0 auto; width: 400px;">
                        <div class="Key_Liter">
                            <asp:Label runat="server" CssClass="Label_Liter">Ключевые слова:</asp:Label>
                            <asp:TextBox ClientIDMode="Static" ID="TextBox_KeyWord" runat="server" CssClass="TextBox_Liter"></asp:TextBox>
                        </div>
                        <div class="Key_Liter">
                            <asp:Label runat="server" CssClass="Label_Liter">Автор:</asp:Label>
                            <asp:TextBox ClientIDMode="Static" runat="server" ID="TextBox_Author" CssClass="TextBox_Liter"></asp:TextBox>
                        </div>
                        <div class="Key_Liter">
                            <asp:Label runat="server" CssClass="Label_Liter">Название:</asp:Label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="TextBox_NameBook" CssClass="TextBox_Liter"></asp:TextBox>
                        </div>
                        <div class="Key_Liter">
                            <asp:Label runat="server" CssClass="Label_Liter">Год издания:</asp:Label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="TextBox_Year" CssClass="TextBox_Liter" TextMode="Number"></asp:TextBox>
                        </div>
                        <br />
                        <div>
                            <asp:Button runat="server" ID="Button_for_FindLiter" OnClick="Button_for_FindLiter_Click" Style="text-align: center; width: 190px;" class="bttn" Text="Начать поиск" />
                        </div>
                        <br />
                    </div>
                    <div style="max-height: 400px; max-width: 1280px; overflow: scroll; margin: 0 auto;">
                        <table runat="server" clientidmode="Static" id="Table_for_liter" class="GridViewCss" style="width: auto" ondblclick="SoderjRazdDiscip.AddLiterToTextBox(event);">
                            <tr class="HeaderGridView">
                                <th class="GridViewCss">Название</th>
                                <th class="GridViewCss">Автор</th>
                                <th class="GridViewCss">Место издания</th>
                                <th class="GridViewCss">Издательство</th>
                                <th class="GridViewCss">Год</th>
                                <th class="GridViewCss"></th>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
    <section style="width: 100%; position: fixed; z-index: 50;">
        <input id="AddRazdel_Btn" runat="server" type="button" value="Раздел" class="bttn" onclick="SoderjRazdDiscip.AddRazdelRow();" clientidmode="Static" />
        <input id="AddTheme_Btn" runat="server" type="button" value="Тема" class="bttn" onclick="SoderjRazdDiscip.AddThemeRow();" clientidmode="Static" />
        <input id="AddLec_Btn" runat="server" type="button" value="Лекция" class="bttn" onclick="SoderjRazdDiscip.Add_Lec_or_Prakt_or_SamJob('Лекция'); " />
        <input id="AddPraktik_Btn" runat="server" type="button" value="Семинар/Лаборат./Практич."
            class="bttn" onclick="SoderjRazdDiscip.Add_Lec_or_Prakt_or_SamJob('Семинар'); " />
        <input id="AddSamJob_Btn" runat="server" type="button" value="Самостоятельная работа" class="bttn" onclick="SoderjRazdDiscip.Add_Lec_or_Prakt_or_SamJob('Сам. работа'); " />
    </section>
    <section style="overflow-y:hidden">
        <section class="ContainerForSoderjTable" style="margin-bottom: 70px;">
            <div style="width: 100%;">
                <asp:Label ID="Label_for_hours" ClientIDMode="Static" runat="server"></asp:Label>
            </div>
            <table runat="server" style="width: 100%;" class="GridViewCss" id="Table_for_soderjDiscip" clientidmode="Static" onclick="SoderjRazdDiscip.ClickOnCell_InRazdelLesson(event);" onkeyup="SoderjRazdDiscip.ClickOnCell_InRazdelLesson(event);">
                <caption>Содержание тем / занятий.</caption>
                <tr class="HeaderGridView">
                    <th class="HeaderGridView VidColumn">Вид</th>
                    <th class="HeaderGridView semestrColumn">Семестр</th>
                    <th class="HeaderGridView">Содержание тем / занятий</th>
                    <th class="HeaderGridView VolumeColumn">Объем, час</th>
                    <th class="HeaderGridView formCurControlColumn">Форма текущего контроля успеваемости</th>
                    <th class="HeaderGridView buttonColumn"></th>
                </tr>
            </table>
            <div style="width: 100%;">
                <asp:Label ID="Label_for_hours1" ClientIDMode="Static" runat="server"></asp:Label>
            </div>
            <div>
                <h3 style="text-align: center;">Рекомендуемая литература</h3>
            </div>
            <table runat="server" style="width: 100%;" class="GridViewCss" id="Table_for_Literature" clientidmode="Static" onclick="SoderjRazdDiscip.ClickOnCell_intbl_liter(event);" onkeyup="SoderjRazdDiscip.ClickOnCell_intbl_liter(event);">
                <tr class="HeaderGridView">
                    <th class="HeaderGridView TypeLiterColumn">Литература</th>
                    <th class="HeaderGridView">Описание источника</th>
                    <th class=" HeaderGridView FindLiterBtnColumn"></th>
                </tr>
            </table>
            <a name="end"></a>            
        </section>
    </section>
    <section>
        <asp:Button ID="Button_next_page" CssClass="bttn btn-pred-and-next" runat="server" Text="Следующая страница >>" OnClick="Button_next_page_Click" />
        <asp:Button ID="Button_for_pred_page" CssClass="bttn btn-pred-and-next" runat="server" Text="<< Предыдущая страница" OnClick="Button_for_pred_page_Click" />
    </section>
   
    <section>
        <div id="test" style="background-color: black; display: none;"></div>
    </section>
    <div>
        <input type="hidden" runat="server" id="RowCountSoderjDiscip" clientidmode="Static" value="0" />
        <input type="hidden" runat="server" id="RowCountLiterTable" clientidmode="static" value="0" />
        <input type="hidden" runat="server" id="ForHourLec" clientidmode="static" value="0" />
        <input type="hidden" runat="server" id="ForHourLab" clientidmode="static" value="0" />
        <input type="hidden" runat="server" id="ForHourSam" clientidmode="static" value="0" /> 
    </div>
    <script src="../../Scripts/SoderjRazdDiscip.js"></script>
    <script>
        onload = SoderjRazdDiscip.onloadForm();
        document.forms[0].onkeypress = function (a) {
            a = a || window.event;
            if (a.keyCode == 13 || a.which == 13)
                a.preventDefault ? a.preventDefault() : a.returnValue = false;
        };
    </script>
</asp:Content>