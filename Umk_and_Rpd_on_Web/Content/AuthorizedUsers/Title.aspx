<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="Title.aspx.cs" Inherits="Umk_and_Rpd_on_Web.TitlePage" %>
<asp:Content ID="MainContent" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" OnAsyncPostBackError="ScriptManager1_AsyncPostBackError">
    </asp:ScriptManager>
    <asp:ObjectDataSource ID="FacultyObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.FacultyTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="KafsObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.KafsTableAdapter">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="null" Name="OriginalCodFaculty" SessionField="CodFacPrep" Type="Byte" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource_for_NagruzkaOnPrep" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.NagruzkaOnPrepTableAdapter">
        <SelectParameters>
            <asp:SessionParameter Name="CodPlan" SessionField="CodPlan" Type="Int32" DefaultValue="80" />
            <asp:SessionParameter Name="CodKafDiscip" SessionField="CodKafPrep" Type="Byte" DefaultValue="24" />
            <asp:SessionParameter DefaultValue="2015" Name="Year" SessionField="UchYear" Type="Int16" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource_FormStudy" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.FormStudyTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource_TypeEdu" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.TypeEduTableAdapter"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource_Speciality" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.SpecialityTableAdapter">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="10" Name="CodTypeEdu" SessionField="CodTypeEdu" Type="Byte" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource_StudyPlan" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.StudyPlansTableAdapter">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="CodFormStudy" SessionField="CodFormStudy" Type="Byte" />
            <asp:SessionParameter DefaultValue="10" Name="CodTypeEdu" SessionField="CodTypeEdu" Type="Byte" />
            <asp:SessionParameter DefaultValue="null" Name="CodSpeciality" SessionField="CodSpeciality" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource> 
    <asp:ObjectDataSource ID="ObjectDataSource_SubsNotTeach" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.Subs_not_teachTableAdapter">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="0" Name="CodPlan" SessionField="CodPlan" Type="Int32" />
            <asp:SessionParameter DefaultValue="0" Name="CodKafDiscip" SessionField="CodKafPrep" Type="Byte" />
            <asp:SessionParameter DefaultValue="0" Name="Course" SessionField="Course" Type="Byte" />
        </SelectParameters>
    </asp:ObjectDataSource> 
    <br/>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="div_with_all_select_params">
                <!--Отображение текущего пользователя и выбранного шаблона для заполнения-->
                <section>
                <asp:Label EnableViewState="false" ViewStateMode="Disabled" ID="Label_for_hello_user" runat="server" Text="Текущий пользователь: "></asp:Label>
                </section>
                <br />
                <br/>
            </div>
            <div class="div_with_select_params">
                <asp:Label ID="Label3" runat="server" CssClass="label_titleform" Text="Факультет: <br/>(для дисциплины)"></asp:Label>
                <asp:DropDownList ID="DropDownList_FacDiscip" CssClass="selectliststyle" runat="server" AutoPostBack="True" DataSourceID="FacultyObjectDataSource" DataTextField="NameFaculty" DataValueField="CodFaculty" OnSelectedIndexChanged="FacultyDropDownList_SelectedIndexChanged" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <div class="div_with_select_params">
                <asp:Label ID="Label4" runat="server" CssClass="label_titleform" Text="Кафедра: <br/>(для дисциплины)"></asp:Label>
                <asp:DropDownList ID="DropDownList_KafDiscip" runat="server" CssClass="selectliststyle" DataSourceID="KafsObjectDataSource" DataTextField="NameKaf" DataValueField="CodKaf" OnSelectedIndexChanged="KafsDropDownList_SelectedIndexChanged" AutoPostBack="True" ViewStateMode="Enabled" OnDataBound="DropDownList_KafDiscip_DataBound" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <div class="div_with_select_params">
                <asp:Label ID="Label5" runat="server" CssClass="label_titleform" Text="Форма обучения: "></asp:Label>
                <asp:DropDownList ID="DropDownList_FormStudy" CssClass="selectliststyle" runat="server" DataSourceID="ObjectDataSource_FormStudy" DataTextField="FormStudy" DataValueField="CodFormStudy" OnSelectedIndexChanged="DropDownList_FormStudy_SelectedIndexChanged" AutoPostBack="True" ViewStateMode="Enabled" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <div class="div_with_select_params">
                <asp:Label ID="Label6" runat="server" CssClass="label_titleform" Text="Тип обучения: "></asp:Label>
                <asp:DropDownList ID="DropDownList_TypeEdu" CssClass="selectliststyle" runat="server" DataSourceID="ObjectDataSource_TypeEdu" DataTextField="TypeEdu" DataValueField="CodTypeEdu" OnSelectedIndexChanged="DropDownList_TypeEdu_SelectedIndexChanged" AutoPostBack="True" ViewStateMode="Enabled" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <div class="div_with_select_params">
                <asp:Label ID="Label7" runat="server" CssClass="label_titleform" Text="Направление подготовки: "></asp:Label>
                <asp:DropDownList ID="DropDownList_Speciality" CssClass="selectliststyle" runat="server" DataSourceID="ObjectDataSource_Speciality" DataTextField="CodSpec_with_NameSpec" DataValueField="CodSpeciality" OnSelectedIndexChanged="DropDownList_Speciality_SelectedIndexChanged" AutoPostBack="True" ViewStateMode="Enabled" OnDataBound="DropDownList_Speciality_DataBound" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <div class="div_with_select_params">
                <asp:Label ID="Label8" runat="server" CssClass="label_titleform" Text="Учебный план: "></asp:Label>
                <asp:DropDownList ID="DropDownList_StudyPlans" CssClass="selectliststyle" runat="server" DataSourceID="ObjectDataSource_StudyPlan" DataTextField="NamePlan1" DataValueField="CodPlan" OnSelectedIndexChanged="DropDownList_StudyPlans_SelectedIndexChanged" AutoPostBack="True" ViewStateMode="Enabled" OnDataBound="DropDownList_StudyPlans_DataBound" ClientIDMode="Static"></asp:DropDownList>
            </div>
            <div class="div_with_select_params">
                <asp:Label ID="Label9" runat="server" CssClass="label_titleform" Text="Учебный год"></asp:Label>
                <asp:DropDownList ID="DropDownList_StudyYear" CssClass="selectliststyle" runat="server" OnSelectedIndexChanged="DropDownList_for_uch_year_SelectedIndexChanged" AutoPostBack="True" ViewStateMode="Enabled" ClientIDMode="Static"></asp:DropDownList>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>  
    <asp:UpdatePanel ID="UpdatePanelSformPassportCompet" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_SavePassportCompet" runat="server" AssociatedUpdatePanelID="UpdatePanelSformPassportCompet">
                <ProgressTemplate>
                    Подождите, идет формирование паспорта компетенций...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <section runat="server" id="SformPassportCompetSect">
                <asp:Button ID="SformPassportCompet" CssClass="bttn" runat="server" Text="Сформировать паспорт компетенций" OnClick="SformPassportCompet_Click"/>
            </section>
        </ContentTemplate>                
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanelSformOOP" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_SformOOP" runat="server" AssociatedUpdatePanelID="UpdatePanelSformOOP">
                <ProgressTemplate>
                    Подождите, идет формирование ООП...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <section runat="server" id="SformOOPSect">
                <asp:Button ID="SformOOP_btn" CssClass="bttn" runat="server" Text="Сформировать ООП" OnClick="SformOOP_btn_Click" />
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
    <hr />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                    
            <asp:Button ID="Button_UpdateListDiscip" CssClass="bttn" runat="server" Text="Обновить список дисциплин"  OnClick="Button1_Click"/>
            <p runat="server" id="CurrentSelectSub" style="font-size:0.9em;">
                
            </p>
            <asp:GridView ID="NagruzkaOnPrepGridView" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource_for_NagruzkaOnPrep" CssClass="GridViewCss" HeaderStyle-CssClass="HeaderGridView" CellPadding="10" EnableViewState="False" ViewStateMode="Disabled" OnSelectedIndexChanged="GridViewSelectedIndexChanged" ClientIDMode="Static">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Выбрать дисциплину" SelectImageUrl="~/App_Themes/selectSubBtn.jpg" HeaderText="Выбрать дисциплину" HeaderStyle-Width="133px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <HeaderStyle Width="133px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:BoundField DataField="Year" HeaderText="Год" SortExpression="Year" />
                    <asp:BoundField DataField="CodSub" HeaderText="CodSub" SortExpression="CodSub" />
                    <asp:BoundField DataField="NameSub" HeaderText="Дисциплина" SortExpression="NameSub" />
                    <asp:BoundField DataField="CodPrep_On_Plan" HeaderText="Код преподавателя" SortExpression="CodPrep_On_Plan" />
                    <asp:BoundField DataField="Prep_on_plan" HeaderText="Преподаватель по нагрузке" SortExpression="Prep_on_plan" />
                </Columns>
                <HeaderStyle CssClass="HeaderGridView"></HeaderStyle>
                <SelectedRowStyle BackColor="#99CCFF" />
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel> 
    <hr />
    <h2 runat="server" id="Subs_not_teach">Дисциплины по выбору (не ведутся)</h2>
    <asp:UpdatePanel runat="server" ID="UpdatePanel3" UpdateMode="Always">
        <ContentTemplate>
            <asp:GridView runat="server" ID="SubsNotTeach_GridView" AutoGenerateColumns="False" DataKeyNames="CodSub" DataSourceID="ObjectDataSource_SubsNotTeach" CssClass="GridViewCss" HeaderStyle-CssClass="HeaderGridView" OnSelectedIndexChanged="GridViewSelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" ButtonType="Image" SelectText="Выбрать дисциплину" SelectImageUrl="~/App_Themes/selectSubBtn.jpg" HeaderText="Выбрать дисциплину" HeaderStyle-Width="133px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                        <HeaderStyle Width="133px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:BoundField DataField="CodSub" HeaderText="Код предмета" ReadOnly="True" SortExpression="CodSub" />
                    <asp:BoundField DataField="NameSub" HeaderText="Дисциплина" SortExpression="NameSub" />
                    <asp:BoundField DataField="CodPrep" HeaderText="Код преподавателя" ReadOnly="True" SortExpression="CodPrep" Visible="false"/>
                    <asp:BoundField DataField="PrepOnPlan" HeaderText="Преподаватель по нагрузке" ReadOnly="True" SortExpression="PrepOnPlan" Visible="false"/>
                </Columns>
                <SelectedRowStyle BackColor="#99CCFF" />
            </asp:GridView>                    
        </ContentTemplate>
    </asp:UpdatePanel>
    <div>
        <asp:Button ID="Button_next_page" CssClass="bttn btn-pred-and-next" runat="server" Text="Следующая страница >>" OnClick="Button_next_page_Click" />
    </div>
</asp:Content>