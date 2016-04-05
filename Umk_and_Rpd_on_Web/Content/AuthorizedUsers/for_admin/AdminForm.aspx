<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/NestedMasterPage1.master" AutoEventWireup="true" CodeBehind="AdminForm.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.for_admin.AdminForm" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <link href="../../App_Themes/StyleSheet_for_FindForm.css" rel="stylesheet" />
    <script>
        function delRPDFromBase(id_rpd, id_umk) {
            var formdata = new FormData();
            formdata.append("id_rpd", id_rpd);
            formdata.append("id_umk", id_umk);
            var xhr = new XMLHttpRequest();
            xhr.open("POST", "", true);
            xhr.send(formdata);
        }
    </script>
    <%--<label>
        Поиск по названию РПД:
        <asp:TextBox runat="server" ID="NameRpdTextBox" Width="350px"></asp:TextBox>
    </label>--%>
    <label runat="server" style="font-size: 0.75em; font-weight: 600;">Выберите параметры для отображения</label>
    <div style="display: table; width: 100%;">
        <div class="group_dropdownlist_as_tablerow">
            <asp:RadioButtonList runat="server" ID="RadioBtnParams" style="display:table-cell; width:50%;">
                <asp:ListItem Selected="true" Text="Вывести пустые РПД/УМК (в БД добавлены, но все поля пусты/или не сохранены окончательно в БД)" Value="0" />
                <asp:ListItem Text="Вывести заполненные РПД/УМК (в БД сохранены и некоторые/все поля заполнены)" Value="1" />
            </asp:RadioButtonList>        
            <asp:CheckBoxList runat="server" ID="CheckBoxListParams" Style="display: table-cell; width:50%;" >
                <asp:ListItem Selected="True" Text="Кафедра" />
                <asp:ListItem Text="Направление подготовки" />
                <asp:ListItem Text="Учебный план" />
                <asp:ListItem Text="Дисциплина" />
            </asp:CheckBoxList>
        </div>
    </div>
    <asp:RadioButtonList runat="server" ID="RadioBtnParams1" CssClass="group_dropdownlist_as_tablerow" Visible="false">
        <asp:ListItem Text="Вывести РПД/УМК, у которых поле Tmp_contents = null" Value="0" />
        <asp:ListItem Text="Вывести РПД/УМК, у которых поле Tmp_contents != null" Value="1" />
        <asp:ListItem Selected="true" Text="Вывести РПД/УМК со всеми Tmp_Contents" Value="2" />
    </asp:RadioButtonList>
    <hr />
    <asp:UpdatePanel runat="server" ID="UpdatePanel2">
        <ContentTemplate>
            <div>
                <div class="group_dropdownlist_as_tablerow">
                    <span class="dropdownlist_as_tablecell_column1">Факультет (дисциплины)</span>
                    <asp:DropDownList ID="DropDownList_facPrep" CssClass="dropdownlist_as_tablecell_column2" runat="server" DataSourceID="ObjectDataSource_faculty" DataTextField="NameFaculty" DataValueField="CodFaculty" AutoPostBack="True"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_faculty" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.FacultyTableAdapter"></asp:ObjectDataSource>
                    <span class="dropdownlist_as_tablecell_column3">Форма обучения</span>
                    <asp:DropDownList ID="DropDownList_FormaOb" runat="server" CssClass="dropdownlist_as_tablecell_column4" DataSourceID="ObjectDataSource_FormaStudy" DataTextField="FormStudy" DataValueField="CodFormStudy" AutoPostBack="True"></asp:DropDownList>
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
                    <span class="dropdownlist_as_tablecell_column1">Дисциплина</span>
                    <asp:TextBox runat="server" ID="TextBox_NameSub" CssClass="dropdownlist_as_tablecell_column2" />
                    <span class="dropdownlist_as_tablecell_column3">Направление подготовки</span>
                    <asp:DropDownList ID="DropDownList_Speciality" CssClass="dropdownlist_as_tablecell_column4" runat="server" DataSourceID="ObjectDataSource_Speciality" DataTextField="CodSpec_with_NameSpec" DataValueField="CodSpeciality" AutoPostBack="True"></asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_Speciality" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.SpecialityTableAdapter">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList_TypeEdu" DefaultValue="10" Name="CodTypeEdu" PropertyName="SelectedValue" Type="Byte" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
                <div class="group_dropdownlist_as_tablerow">
                    <span class="dropdownlist_as_tablecell_column1"></span>
                    <span class="dropdownlist_as_tablecell_column2"></span>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <hr />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="Button_ControlDateSaveRPD" runat="server" Text="Найти" CssClass="bttn" OnClick="Button_ControlDateSaveRPD_Click" />
            <table runat="server"  id="informTable" Class="GridViewCss" style="width:100%;">
                <tr>                    
                    <th class="HeaderGridView " style="width:100px;">Дата сохранения</th>                    
                    <th class="HeaderGridView" style="width:100px;">Имя в БД</th>
                    <th class="HeaderGridView">ID РПД</th>
                    <th class="HeaderGridView">ID УМК</th>
                    <th class="HeaderGridView">Год</th>
                    <th class="HeaderGridView">План</th>
                    <th class="HeaderGridView" style="width: 80px;">Дисциплина</th>
                    <th class="HeaderGridView KafColumnInform">Кафедра</th>  
                    <th class="HeaderGridView NameSubColumnInform">По нагрузке</th>
                    <th class="HeaderGridView">Кто сделал</th>
                    <th class="HeaderGridView">Пустые поля</th>
                    <th class="HeaderGridView"></th>
                </tr>
            </table>
            <%--<Table runat="server" ID="informTable" Class="GridViewCss">
                <TableCell CssClass="HeaderGridView">
                    <asp:TableHeaderCell Text="Сохранена окончательно в БД" CssClass="HeaderGridView"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Дата сохранения" CssClass="HeaderGridView"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Имя в БД" CssClass="HeaderGridView"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="ID РПД" CssClass="HeaderGridView"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="ID УМК" CssClass="HeaderGridView"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Год" CssClass="HeaderGridView"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="План" CssClass="HeaderGridView"></asp:TableHeaderCell>    
                    <asp:TableHeaderCell Text="Заполненные поля" CssClass="HeaderGridView"></asp:TableHeaderCell>
                    <asp:TableHeaderCell Text="Пустые поля" CssClass="HeaderGridView"></asp:TableHeaderCell>         
                </TableCell>
            </Table>--%>
            <%--<asp:Table runat="server" ID="Table_ControlSaveRpd" CssClass="GridViewCss">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell CssClass="GridViewCss">Id_umk_rpd</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss">Дата сохранения</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss">Логин</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss">Ip адрес</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss">ФИО</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="GridViewCss">Название РПД</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>--%>
            
            <%--<asp:GridView ID="GridView_ControlSaveRPD" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource_controlSaveRPD">
                <Columns>
                    <asp:BoundField DataField="Id_umk_rpd" HeaderText="Id_umk_rpd" SortExpression="Id_umk_rpd" ControlStyle-Width="100px"/>
                    <asp:BoundField DataField="DateSave" HeaderText="Дата сохранения" SortExpression="DateSave" ControlStyle-Width="150px"/>
                    <asp:BoundField DataField="Login" HeaderText="Логин" SortExpression="Login" ControlStyle-Width="100px" />
                    <asp:BoundField DataField="Ip" HeaderText="Ip адрес" SortExpression="Ip" ControlStyle-Width="100px" />
                    <asp:BoundField DataField="FIO" HeaderText="ФИО" SortExpression="FIO"   />
                    <asp:BoundField DataField="NameRpd" HeaderText="Название РПД" SortExpression="NameRpd" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource_controlSaveRPD" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByNameRpd" TypeName="Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters.TmpUMK_rpd_ControlSignUpTableAdapter">
                <SelectParameters>
                    <asp:ControlParameter ControlID="NameRpdTextBox" Name="NameRpd" PropertyName="Text" Type="String" DefaultValue="" />
                </SelectParameters>
            </asp:ObjectDataSource>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
