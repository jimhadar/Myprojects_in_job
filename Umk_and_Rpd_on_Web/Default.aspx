<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Authorization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Менеджер УМК/РПД</title>
    <link rel="stylesheet" href="App_Themes/MainStyleSheet.css" />
    <link rel="stylesheet" href="App_Themes/StyleSheet_for_authorization.css" />
    <link rel="stylesheet" href="App_Themes/Style_for_MainMasterPage.css" />
</head>
<body>
    <form id="AuthorizationForm" runat="server">
        <header class="header">
            <section class="name_university">
                Читинский институт Байкальского Государственного Университета экономики и права
            </section>
            <br/>
            <section class="name-resource">
                Менеджер УМК / РПД
            </section>            
        </header>
        <br />
        
        <div class="parentLoginBlock">    
            <section style="vertical-align: top; text-align: center">
            <br />
            <br />
                <a href="Logins">Перейти к списку логинов</a>
                <a href="Content/AuthorizedUsers/rpd_shablon/Краткое руководство пользователя Веб-версии для составления РПДУМК.docx">Скачать инструкцию по составлению РПД</a>
            </section>    
            <div class="LoginBlock">
            <asp:Login ID="Login2"  runat="server" LabelStyle-CssClass="login-label-style" TextBoxStyle-CssClass="TextBoxStyle login" DisplayRememberMe="false" TitleText="Авторизация" LoginButtonStyle-CssClass="login-bttn" OnAuthenticate="Login1_Authenticate" VisibleWhenLoggedIn="false" OnLoggedIn="Login1_LoggedIn"></asp:Login>
            </div>
        </div>
    </form>
</body>
</html>
