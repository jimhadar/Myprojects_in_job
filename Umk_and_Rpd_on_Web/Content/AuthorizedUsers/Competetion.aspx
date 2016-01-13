<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Competetion.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Competetion" EnableViewState="true" ViewStateMode="Enabled" %>
<%--Форма для заполнения полей разделов: Пояснительная записка, Место дисциплины в структуре ООП бакалавриата и компетенций студента--%>
<asp:Content ID="MainContent" ContentPlaceHolderID="Content" runat="server"> 
    <asp:ScriptManager ID="ScriptManager1" runat="server">

    </asp:ScriptManager>
    <!--<asp:Table ID="Table1" runat="server" align="center">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="Button_for_Title" runat="server" Text="Титул" CssClass="bttn" OnClick="Button_for_Title_Click"/>
                <asp:Button ID="Button_for_MethodUkaz" runat="server" Text="Методические указания" CssClass="bttn" OnClick="Button_for_MethodUkaz_Click"/>
                <%--<a href="#" class="bttn"><span>Помощь</span></a>--%>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>-->
    <%--Форма для заполнения полей разделов: Пояснительная записка, Место дисциплины в структуре ООП бакалавриата и компетенций студента--%>
    <section style="overflow-y: hidden">
        <section class="ContainerForSoderjTable" style="margin-bottom: 70px;">
    <h2>Цели освоения дисциплины</h2>
    <asp:TextBox ID="TextBox_for_GoalsDiscip" runat="server" TextMode="MultiLine"  CssClass="TextBoxStyle" ClientIDMode="Static"></asp:TextBox>

    <h2>Место дисциплины в структуре ООП бакалавриата</h2>
    <asp:TextBox ID="TextBox_for_PlaceOOP" runat="server" CssClass="TextBoxStyle" TextMode="MultiLine" ClientIDMode="Static"></asp:TextBox>
    <br/>
    <br/>
    <hr class="hrStyle"/>
    <%--Пояснительная записка, Место дисциплины в структуре ООП бакалавриата--%>
    <h2>Компетенции обучающегося</h2>
    <%--Описание компетенций--%>
    <div>
        <asp:GridView ID="CompetetionGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCompet" DataSourceID="ObjectDataSource_Competetion" HorizontalAlign="Left" ViewStateMode="Disabled" EnableViewState="false" CssClass="GridViewCss" HeaderStyle-CssClass="HeaderGridView" ClientIDMode="Static"> 
            <Columns>
                <asp:BoundField DataField="AbbrComp" HeaderText="Компетенция" SortExpression="AbbrComp" />
                <asp:BoundField DataField="AboutComp" HeaderText="Описание компетенции" SortExpression="AboutComp" />
            </Columns>               
            <HeaderStyle CssClass="HeaderGridView" />
            <SelectedRowStyle BackColor="#3399FF" />
        </asp:GridView>    
        <asp:ObjectDataSource ID="ObjectDataSource_Competetion" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.CompetetionTableAdapter">
            <SelectParameters>
                <asp:SessionParameter Name="CodSpeciality" SessionField="CodSpeciality" Type="String" />
                <asp:SessionParameter DefaultValue="" Name="CodSub" SessionField="CodSub" Type="Int16" />
                <asp:SessionParameter DefaultValue="" Name="CodPlan" SessionField="CodPlan" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>  
    </div>
    <h3>Выберите ключевые компетенции:</h3>
    <asp:CheckBoxList ID="CheckBoxList_KeyCompet" runat="server" DataSourceID="ObjectDataSource_Competetion" DataTextField="AbbrComp" style="width:100%" >
    </asp:CheckBoxList>
    <%--Список всех компетенций выбранной дисциплины--%>    
    <%--Для выбора ключевых компетенций--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" EnableViewState="true">
        <ContentTemplate>  
            <asp:Button ID="Button_for_keyCompet" runat="server" Text="Сформировать список ключевых компетенций" OnClick="Button_for_keyCompet_Click" CssClass="bttn"/>
            <br/>
            <br/>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--Кнопка для формирования списка ключевых компетенций--%>    
    <%--Уровневое описание ключевых компетенций--%>
    <h2>Требования к уровню усвоения дисциплины</h2>

    <h3>Студент должен знать:</h3>
    <asp:TextBox ID="TextBox_for_Student_doljen_znat" runat="server" SkinID="TextBoxSkin" TextMode="MultiLine" CssClass="TextBoxStyle" ClientIDMode="Static"></asp:TextBox>

    <h3>Студент должен уметь:</h3>
    <asp:TextBox ID="TextBox_for_Student_doljen_umet" runat="server" SkinID="TextBoxSkin" TextMode="MultiLine" CssClass="TextBoxStyle" ClientIDMode="Static"></asp:TextBox>

    <h3>Студент должен владеть:</h3>
    <asp:TextBox ID="TextBox_for_Student_doljen_vladet" runat="server" SkinID="TextBoxSkin" TextMode="MultiLine" CssClass="TextBoxStyle" ClientIDMode="Static"></asp:TextBox>
    </section>
    </section>
    <div>        
        <asp:Button ID="Button_next_page" CssClass="bttn btn-pred-and-next" runat="server" Text="Следующая страница >>" OnClick="Button_next_page_Click" />
        <asp:Button ID="Button_for_pred_page" CssClass="bttn btn-pred-and-next" runat="server" Text="<< Предыдущая страница" OnClick="Button_for_pred_page_Click" />
    </div>
</asp:Content>
