<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AuthorizedUsers/Main.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Content.AuthorizedUsers.Question" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <br/>
        <asp:Label ID="Label_question" CssClass="LabelStyle" runat="server" Text=""></asp:Label>
    </section>
    <br />
    <section runat="server" clientidmode="static" id="sect" style="text-align: center;">
        <asp:Button ID="Clear_btn" runat="server" CssClass="bttn" Text="" OnClick="Clear_btn_Click"/>
        <asp:Button ID="No_btn" runat="server" CssClass="bttn" Text="" OnClick="No_btn_Click"/>
    </section>
</asp:Content>
