<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="FindRpdForm.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.FindRpdForm" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager runat="server">

</asp:ScriptManager>
    <link href="../../App_Themes/StyleSheet_for_FindForm.css" rel="stylesheet" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <label>
                <input type="checkbox" runat="server" id="CheckBox_FacDiscip" value="" clientidmode="static" />Факультет дисциплины</label>
            <label>
                <input type="checkbox" runat="server" clientidmode="static" id="CheckBoc_KafDiscip" />Кафедра дисциплины</label>
            <label>
                <input type="checkbox" runat="server" clientidmode="static" id="Checkbox_Prepod" />
                Преподаватель</label>
            <label>
                <input type="checkbox" runat="server" clientidmode="static" id="Checkbox_StudyYear" />
                Учебный год</label>
            <label>
                <input type="checkbox" runat="server" clientidmode="static" id="Checkbox_Speciality" />Направление подготовки</label>
            <label>
                <input type="checkbox" runat="server" clientidmode="static" id="Checkbox_StudyPlan" />Учебный план</label>
            <div class="all_select_params">
                <div class="group_dropdownlist_as_tablerow">
                    <span class="dropdownlist_as_tablecell_column1"> Факультет (дисциплины)</span>
                    <asp:DropDownList ID="DropDownList_facPrep" CssClass="dropdownlist_as_tablecell_column2" runat="server" DataSourceID="ObjectDataSource_faculty" DataTextField="NameFaculty" DataValueField="CodFaculty" AutoPostBack="True"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_faculty" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.FacultyTableAdapter"></asp:ObjectDataSource>
                    <span class="dropdownlist_as_tablecell_column3">Форма обучения</span>
                    <asp:DropDownList ID="DropDownList_FormaOb" runat="server" CssClass="dropdownlist_as_tablecell_column4" DataSourceID="ObjectDataSource_FormaStudy" DataTextField="FormStudy" DataValueField="CodFormStudy" AutoPostBack="True"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_FormaStudy" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.FormStudyTableAdapter"></asp:ObjectDataSource>
                </div>
                <div class="group_dropdownlist_as_tablerow">
                    <span class="dropdownlist_as_tablecell_column1">Кафедра (дисциплины)</span>
                    <asp:DropDownList ID="DropDownList_kafs" runat="server" CssClass="dropdownlist_as_tablecell_column2" DataSourceID="ObjectDataSource_Kafs" DataTextField="NameKaf" DataValueField="CodKaf" AutoPostBack="True"></asp:DropDownList>
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
                    <asp:DropDownList ID="DropDownList_StudyYear" runat="server" CssClass="dropdownlist_as_tablecell_column2" AutoPostBack="True"></asp:DropDownList>
                    <span class="dropdownlist_as_tablecell_column3">Направление подготовки</span>
                    <asp:DropDownList ID="DropDownList_Speciality" CssClass="dropdownlist_as_tablecell_column4" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource_Speciality" DataTextField="CodSpec_with_NameSpec" DataValueField="CodSpeciality"></asp:DropDownList>
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
                    <asp:DropDownList ID="DropDownList_StudyPlan" runat="server" CssClass="dropdownlist_as_tablecell_column4" AutoPostBack="True" DataSourceID="ObjectDataSource_StudyPlans" DataTextField="NamePlan1" DataValueField="CodPlan"></asp:DropDownList>
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
            <asp:Button ID="Button_poisk" runat="server" Text="Поиск" CssClass="bttn" Width="300px" />
            <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource_umk_rpd_with_opisanie" AutoGenerateColumns="False" CssClass="GridViewCss" DataKeyNames="Id_RPD_or_UMK">
                <Columns>
                    <asp:CheckBoxField DataField="UMK_or_RPD" HeaderText="UMK_or_RPD" SortExpression="UMK_or_RPD" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="CodFac" HeaderText="CodFac" SortExpression="CodFac" />
                    <asp:BoundField DataField="CodKaf" HeaderText="CodKaf" SortExpression="CodKaf" />
                    <asp:BoundField DataField="CodPrep" HeaderText="CodPrep" SortExpression="CodPrep" />
                    <asp:BoundField DataField="CodSub" HeaderText="CodSub" SortExpression="CodSub" />
                    <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
                    <asp:BoundField DataField="CodSpec" HeaderText="CodSpec" SortExpression="CodSpec" />
                    <asp:BoundField DataField="CodTypeEdu" HeaderText="CodTypeEdu" SortExpression="CodTypeEdu" />
                    <asp:BoundField DataField="DateSave" HeaderText="DateSave" SortExpression="DateSave" />
                    <asp:BoundField DataField="CodPrepWhoDo" HeaderText="CodPrepWhoDo" SortExpression="CodPrepWhoDo" />
                    <asp:BoundField DataField="CodFormStudy" HeaderText="CodFormStudy" SortExpression="CodFormStudy" />
                    <asp:BoundField DataField="CodPlan" HeaderText="CodPlan" SortExpression="CodPlan" />
                    <asp:BoundField DataField="Id_RPD_or_UMK" HeaderText="Id_RPD_or_UMK" InsertVisible="False" ReadOnly="True" SortExpression="Id_RPD_or_UMK" />
                    <asp:BoundField DataField="NameFaculty" HeaderText="NameFaculty" SortExpression="NameFaculty" />
                    <asp:BoundField DataField="NameKaf" HeaderText="NameKaf" SortExpression="NameKaf" />
                    <asp:BoundField DataField="NameSub" HeaderText="NameSub" SortExpression="NameSub" />
                    <asp:BoundField DataField="FIO" HeaderText="FIO" SortExpression="FIO" />
                    <asp:BoundField DataField="PrepodWhoEdit" HeaderText="PrepodWhoEdit" SortExpression="PrepodWhoEdit" />
                    <asp:BoundField DataField="Speciality" HeaderText="Speciality" SortExpression="Speciality" />
                    <asp:BoundField DataField="TypeEdu" HeaderText="TypeEdu" SortExpression="TypeEdu" />
                    <asp:BoundField DataField="UMKRPD" HeaderText="UMKRPD" ReadOnly="True" SortExpression="UMKRPD" />
                    <asp:BoundField DataField="NamePlan1" HeaderText="NamePlan1" ReadOnly="True" SortExpression="NamePlan1" />
                </Columns>
                <HeaderStyle CssClass="HeaderGridView" />
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource_umk_rpd_with_opisanie" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.UMK_and_RPD_with_opisanieTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList_facPrep" Name="CodFac" PropertyName="SelectedValue" Type="Byte" />
                    <asp:ControlParameter ControlID="DropDownList_kafs" Name="CodKaf" PropertyName="SelectedValue" Type="Byte" />
                    <asp:SessionParameter Name="CodPrep" SessionField="CodPrepForOpisanie" Type="Int32" />
                    <asp:ControlParameter ControlID="DropDownList_StudyYear" Name="Year" PropertyName="SelectedValue" Type="Int16" />
                    <asp:ControlParameter ControlID="DropDownList_StudyPlan" Name="CodPlan" PropertyName="SelectedValue" Type="Int32" />
                    <asp:ControlParameter ControlID="DropDownList_Speciality" Name="CodSpeciality" PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="DropDownList_TypeEdu" Name="CodTypeEdu" PropertyName="SelectedValue" Type="Byte" />
                    <asp:ControlParameter ControlID="DropDownList_FormaOb" Name="CodFormStudy" PropertyName="SelectedValue" Type="Byte" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            
        </ContentTemplate>    
    </asp:UpdatePanel>
    <asp:SqlDataSource ID="SqlDataSource_umk_and_rpd_with_opisanie" runat="server" ConnectionString="<%$ ConnectionStrings:AcademiaConnectingString %>" SelectCommand="SELECT DISTINCT 
                         UMK_and_RPD.UMK_or_RPD, UMK_and_RPD.Name, UMK_and_RPD.CodFac, UMK_and_RPD.CodKaf, UMK_and_RPD.CodPrep, UMK_and_RPD.CodSub, UMK_and_RPD.Year, UMK_and_RPD.CodSpec, 
                         UMK_and_RPD.CodTypeEdu, UMK_and_RPD.DateSave, UMK_and_RPD.CodPrepWhoDo, UMK_and_RPD.CodFormStudy, UMK_and_RPD.CodPlan, UMK_and_RPD.Id_RPD_or_UMK, Faculty.NameFaculty, 
                         Kafs.NameKaf, Subs.NameSub, personal.dbo.PEOPLEN.FIO, PEOPLEN_1.FIO AS PrepodWhoEdit, Speciality.Speciality, TypeEdu.TypeEdu, 
                         CASE WHEN UMK_and_RPD.UMK_or_RPD = 1 THEN 'УМК' ELSE 'РПД' END AS UMKRPD, CASE WHEN CHARINDEX('-', studyplans.NamePlan, LEN(studyplans.NamePlan) - 1) 
                         &gt; 0 THEN SUBSTRING(studyplans.NamePlan, 0, LEN(studyplans.NamePlan) - 1) WHEN CHARINDEX('-', studyplans.NamePlan, LEN(studyplans.NamePlan) - 1) 
                         &lt;= 0 THEN studyplans.NamePlan END AS NamePlan1
FROM            UMK_and_RPD INNER JOIN
                         Faculty ON UMK_and_RPD.CodFac = Faculty.CodFaculty INNER JOIN
                         Kafs ON UMK_and_RPD.CodKaf = Kafs.CodKaf INNER JOIN
                         Subs ON UMK_and_RPD.CodSub = Subs.CodSub INNER JOIN
                         personal.dbo.PEOPLEN ON UMK_and_RPD.CodPrep = personal.dbo.PEOPLEN.CODPE INNER JOIN
                         Speciality ON UMK_and_RPD.CodSpec = Speciality.CodSpeciality INNER JOIN
                         TypeEdu ON UMK_and_RPD.CodTypeEdu = TypeEdu.CodTypeEdu INNER JOIN
                         StudyTerm AS st_term ON st_term.CodPlan = UMK_and_RPD.CodPlan INNER JOIN
                         personal.dbo.PEOPLEN AS PEOPLEN_1 ON UMK_and_RPD.CodPrepWhoDo = PEOPLEN_1.CODPE INNER JOIN
                         StudyPlans ON StudyPlans.CodPlan = UMK_and_RPD.CodPlan
WHERE        (UMK_and_RPD.CodFac = @CodFac OR
                         @CodFac IS NULL) AND (UMK_and_RPD.CodKaf = @CodKaf OR
                         @CodKaf IS NULL) AND (UMK_and_RPD.CodPrep = @CodPrep OR
                         @CodPrep IS NULL) AND (UMK_and_RPD.Year = @Year OR
                         @Year IS NULL) AND (UMK_and_RPD.CodPlan = @CodPlan OR
                         @CodPlan IS NULL) AND (UMK_and_RPD.CodSpec = @CodSpeciality OR
                         @CodSpeciality IS NULL) AND (UMK_and_RPD.CodTypeEdu = @CodTypeEdu OR
                         @CodTypeEdu IS NULL) AND (UMK_and_RPD.CodFormStudy = @CodFormStudy OR
                         @CodFormStudy IS NULL)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList_facPrep" Name="CodFac" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="DropDownList_kafs" Name="CodKaf" PropertyName="SelectedValue" />
            <asp:SessionParameter Name="CodPrep" SessionField="CodPreppodavatel" />
            <asp:ControlParameter ControlID="DropDownList_StudyYear" Name="Year" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="DropDownList_StudyPlan" Name="CodPlan" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="DropDownList_Speciality" Name="CodSpeciality" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="DropDownList_TypeEdu" Name="CodTypeEdu" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="DropDownList_FormaOb" Name="CodFormStudy" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>