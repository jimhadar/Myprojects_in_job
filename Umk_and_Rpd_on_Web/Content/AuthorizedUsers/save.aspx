<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/Main.master" AutoEventWireup="true" CodeBehind="save.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.save" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager runat="server">

</asp:ScriptManager>
    <br/>
    <asp:Button ID="Button_toEditRPD" runat="server" CssClass="bttn" Text="<<Перейти к редактированию РПД/УМК" OnClick="Button_toEditRPD_Click"/>
    <br />
    <hr />
    <asp:UpdatePanel ID="UpdatePanel_SaveRPD" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_SaveRPD" runat="server" AssociatedUpdatePanelID="UpdatePanel_SaveRPD">
                <ProgressTemplate>
                    Подождите, идет формирование РПД...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div runat="server" id="Link_SaveRPD">
                <asp:Button id="SaveRPD_btn" runat="server" text="Сформировать РПД" CssClass="bttn" OnClick="SaveRPD_Click"/>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SaveUMK" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgess_SaveUMK" runat="server" AssociatedUpdatePanelID="UpdatePanel_SaveUMK">
                <ProgressTemplate>
                    Подождите, идет формирование УМК...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div runat="server" id="Link_SaveUMK">
                <asp:Button ID="SaveUMK_btn" runat="server" Text="Сформировать УМК" CssClass="bttn" OnClick="SaveUMK_btn_Click" />
            </div>
        </ContentTemplate>        
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SaveAnnotationRPD" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_SaveAnnotaionRPD" runat="server" AssociatedUpdatePanelID="UpdatePanel_SaveAnnotationRPD">
                <ProgressTemplate>
                    Подождите, идет формирование аннотации к рабочей программе...
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div runat="server" id="Link_SaveAnnotationToRPD">
                <asp:Button ID="SaveAnnotation_btn" runat="server" Text="Сформировать аннотацию к РПД" CssClass="bttn" OnClick="SaveAnnotation_btn_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel_SaveFos" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress_SaveFos" runat="server" AssociatedUpdatePanelID="UpdatePanel_SaveFos">
                <ProgressTemplate>
                    Подождите, идет формирование документа Фонда оценочных средств...               
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div runat="server" id="Link_ToFos">
                <asp:Button ID="SaveFos_btn" runat="server" Text="Сформировать ФОС" CssClass="bttn" OnClick="SaveFos_btn_Click" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>