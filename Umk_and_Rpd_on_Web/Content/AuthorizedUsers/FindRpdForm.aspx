<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="FindRpdForm.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.FindRpdForm" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager runat="server">

</asp:ScriptManager>
    <link href="../../App_Themes/StyleSheet_for_FindForm.css" rel="stylesheet" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>            
            <span style="font-size:0.75em;font-weight:600;display:block;">Выберите параметры на основе которых будет осуществляться поиск:</span>
            <label class="label_FindForm">
                <input type="checkbox" runat="server" clientidmode="static" id="Checkbox_StudyYear" checked="checked" />
                Учебный год</label>
            <label class="label_FindForm">
                <input type="checkbox" runat="server" id="CheckBox_FacDiscip" value="" clientidmode="static" />Факультет дисциплины</label>
            <label class="label_FindForm">
                <input type="checkbox" runat="server" clientidmode="static" id="CheckBoc_KafDiscip" />Кафедра дисциплины</label>
            <label class="label_FindForm">
                <input type="checkbox" runat="server" clientidmode="static" id="Checkbox_Prepod" />
                Преподаватель</label>            
            <label class="label_FindForm">
                <input type="checkbox" runat="server" clientidmode="static" id="Checkbox_Speciality" />Направление подготовки</label>
            <label class="label_FindForm">
                <input type="checkbox" runat="server" clientidmode="static" id="Checkbox_StudyPlan" />Учебный план</label>
            <hr />
            <div>
                <div class="group_dropdownlist_as_tablerow">
                    <span class="dropdownlist_as_tablecell_column1"> Факультет (дисциплины)</span>
                    <asp:DropDownList ID="DropDownList_facPrep" CssClass="dropdownlist_as_tablecell_column2" runat="server" DataSourceID="ObjectDataSource_faculty" DataTextField="NameFaculty" DataValueField="CodFaculty"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_faculty" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.FacultyTableAdapter"></asp:ObjectDataSource>
                    <span class="dropdownlist_as_tablecell_column3">Форма обучения</span>
                    <asp:DropDownList ID="DropDownList_FormaOb" runat="server" CssClass="dropdownlist_as_tablecell_column4" DataSourceID="ObjectDataSource_FormaStudy" DataTextField="FormStudy" DataValueField="CodFormStudy"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_FormaStudy" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.FormStudyTableAdapter"></asp:ObjectDataSource>
                </div>
                <div class="group_dropdownlist_as_tablerow">
                    <span class="dropdownlist_as_tablecell_column1">Кафедра (дисциплины)</span>
                    <asp:DropDownList ID="DropDownList_kafs" runat="server" CssClass="dropdownlist_as_tablecell_column2" DataSourceID="ObjectDataSource_Kafs" DataTextField="NameKaf" DataValueField="CodKaf"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_Kafs" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.KafsTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList_facPrep" DefaultValue="80" Name="OriginalCodFaculty" PropertyName="SelectedValue" Type="Byte" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <span class="dropdownlist_as_tablecell_column3">Тип обучения</span>
                    <asp:DropDownList ID="DropDownList_TypeEdu" runat="server" CssClass="dropdownlist_as_tablecell_column4" DataSourceID="ObjectDataSource_TypeEdu" DataTextField="TypeEdu" DataValueField="CodTypeEdu" AutoPostBack="True"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_TypeEdu" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.TypeEduTableAdapter"></asp:ObjectDataSource>
                </div>                
                <div class="group_dropdownlist_as_tablerow">
                    <span class="dropdownlist_as_tablecell_column1">Учебный год</span>
                    <asp:DropDownList ID="DropDownList_StudyYear" runat="server" CssClass="dropdownlist_as_tablecell_column2"></asp:DropDownList>
                    <span class="dropdownlist_as_tablecell_column3">Направление подготовки</span>
                    <asp:DropDownList ID="DropDownList_Speciality" CssClass="dropdownlist_as_tablecell_column4" runat="server" DataSourceID="ObjectDataSource_Speciality" DataTextField="CodSpec_with_NameSpec" DataValueField="CodSpeciality" AutoPostBack="True"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_Speciality" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.SpecialityTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList_TypeEdu" DefaultValue="10" Name="CodTypeEdu" PropertyName="SelectedValue" Type="Byte" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
                <div class="group_dropdownlist_as_tablerow">
                    <span class="dropdownlist_as_tablecell_column1">Преподаватель</span>
                    <asp:TextBox ID="PrepodTextBox" runat="server" CssClass="dropdownlist_as_tablecell_column2"></asp:TextBox>
                    <span class="dropdownlist_as_tablecell_column3">Учебный план</span>
                    <asp:DropDownList ID="DropDownList_StudyPlan" runat="server" CssClass="dropdownlist_as_tablecell_column4" DataSourceID="ObjectDataSource_StudyPlans" DataTextField="NamePlan1" DataValueField="CodPlan"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_StudyPlans" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.StudyPlansTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList_FormaOb" DefaultValue="" Name="CodFormStudy" PropertyName="SelectedValue" Type="Byte" />
                            <asp:ControlParameter ControlID="DropDownList_TypeEdu" DefaultValue="" Name="CodTypeEdu" PropertyName="SelectedValue" Type="Byte" />
                            <asp:ControlParameter ControlID="DropDownList_Speciality" DefaultValue="" Name="CodSpeciality" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <br />
            
        </ContentTemplate>
    </asp:UpdatePanel>    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Button ID="Button_poisk" runat="server" Text="Поиск РПД/УМК" CssClass="bttn" Width="300px" style="margin-bottom:30px;" OnClick="Button_poisk_Click"/>
            <br />
            <asp:Table runat="server" ID="Table_find_rpd" ClientIDMode="Static" CssClass="GridViewCss_FindForm" Font-Size="0.9em">
                <asp:TableHeaderRow HorizontalAlign="Center">
                    <asp:TableHeaderCell CssClass="GridViewCss_FindForm" Text="УМК/РПД"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss_FindForm" Text="Год"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss_FindForm" Text="Тип обучения"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss_FindForm" Text="Направление подготовки"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss_FindForm" Text="Учебный план"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss_FindForm" Text="Кафедра"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss_FindForm" Text="Дисциплина"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss_FindForm" Text="Преподаватель по нагрузке"></asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss_FindForm" Text="Кем выполнено"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </ContentTemplate>    
    </asp:UpdatePanel>
    </asp:Content>