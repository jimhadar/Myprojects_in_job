<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Literature.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.Literature" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager runat="server">

    </asp:ScriptManager>
    <section id="wrap_for_pop-up-window">
        <div id="pop-up-window">
            <div class="close-pop-up">
                <img onclick="Literature.ShowPopUp_for_find_liter('none'); Literature.ClearAllElement_in_findLiterWindow();" src="http://sergey-oganesyan.ru/wp-content/uploads/2014/01/close.png" />
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
                        <table runat="server" clientidmode="Static" id="Table_for_liter" class="GridViewCss" style="width: auto" ondblclick="Literature.AddLiterToTextBox(event);">
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
    <section style="overflow-y: hidden">
        <section class="ContainerForSoderjTable" style="margin-bottom: 70px;">
            <div>
                <h3 style="text-align: center;">Рекомендуемая литература</h3>
            </div>
            <table runat="server" style="width: 100%;" class="GridViewCss" id="Table_for_Literature" clientidmode="Static" onclick="Literature.ClickOnCell_intbl_liter(event);" onkeyup="Literature.ClickOnCell_intbl_liter(event);">
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

    <div>
        <input type="hidden" runat="server" id="RowCountLiterTable" clientidmode="static" value="0" />
    </div>
    <script src="../../Scripts/Literature.js"></script>
    <script>
        document.forms[0].onkeypress = function (a) {
            a = a || window.event;
            if (a.keyCode == 13 || a.which == 13)
                a.preventDefault ? a.preventDefault() : a.returnValue = false;
        };
    </script>
</asp:Content>
