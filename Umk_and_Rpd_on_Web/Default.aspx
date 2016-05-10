<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Umk_and_Rpd_on_Web.Authorization" ErrorPage="~/KnownErrors.aspx"%>

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
    <!-- Yandex.Metrika counter -->
    <script type="text/javascript">
        (function (d, w, c) {
            (w[c] = w[c] || []).push(function () {
                try {
                    w.yaCounter36207040 = new Ya.Metrika({
                        id: 36207040,
                        clickmap: true,
                        trackLinks: true,
                        accurateTrackBounce: true,
                        webvisor: true
                    });
                } catch (e) { }
            });

            var n = d.getElementsByTagName("script")[0],
                s = d.createElement("script"),
                f = function () { n.parentNode.insertBefore(s, n); };
            s.type = "text/javascript";
            s.async = true;
            s.src = "https://mc.yandex.ru/metrika/watch.js";

            if (w.opera == "[object Opera]") {
                d.addEventListener("DOMContentLoaded", f, false);
            } else { f(); }
        })(document, window, "yandex_metrika_callbacks");
    </script>
    <noscript><div><img src="https://mc.yandex.ru/watch/36207040" style="position:absolute; left:-9999px;" alt="" /></div></noscript>
    <!-- /Yandex.Metrika counter -->
    <form id="AuthorizationForm" runat="server">
        <header class="header">
            <section class="name_university">
                Читинский институт Байкальского Государственного Университета
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
