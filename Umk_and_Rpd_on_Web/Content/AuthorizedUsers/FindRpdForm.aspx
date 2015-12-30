<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="FindRpdForm.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.FindRpdForm" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="Content" runat="server">
<asp:ScriptManager runat="server">

</asp:ScriptManager>
    <link href="../../App_Themes/StyleSheet_for_FindForm.css" rel="stylesheet" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource_umk_and_rpd_with_opisanie" AutoGenerateColumns="False" CssClass="GridViewCss" DataKeyNames="Id_RPD_or_UMK">
                <Columns>
                    <asp:BoundField DataField="UMKRPD" HeaderText="Умк/РПД" ReadOnly="True" SortExpression="UMKRPD" />
                    <asp:BoundField DataField="Year" HeaderText="Год" SortExpression="Year" />
                    <asp:BoundField DataField="NameKaf" HeaderText="Кафедра" SortExpression="NameKaf" />
                    <asp:BoundField DataField="NameSub" HeaderText="Дисциплина" SortExpression="NameSub" />
                    <asp:BoundField DataField="FIO" HeaderText="Преподаватель по нагрузке" SortExpression="FIO" />
                    <asp:BoundField DataField="PrepodWhoEdit" HeaderText="Кем выполнено" SortExpression="PrepodWhoEdit" />
                    <asp:BoundField DataField="TypeEdu" HeaderText="Тип обучения" SortExpression="TypeEdu" />
                    <asp:BoundField DataField="Speciality" HeaderText="Направление подготовки" SortExpression="Speciality" />
                    <asp:BoundField DataField="NamePlan1" HeaderText="Название плана" ReadOnly="True" SortExpression="NamePlan1" />
                    <asp:BoundField DataField="DateSave" HeaderText="DateSave" SortExpression="DateSave" />
                </Columns>
                <HeaderStyle CssClass="HeaderGridView" />
            </asp:GridView>
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