using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace Umk_and_Rpd_on_Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.MapPageRoute("Default", "Default.aspx", "~/Default.aspx?{*}");
            routes.MapPageRoute("Title", "Title/", "~/Content/AuthorizedUsers/Title.aspx", true);
            routes.MapPageRoute("Competetion", "Competetion/", "~/Content/AuthorizedUsers/Competetion.aspx", true);
            routes.MapPageRoute("CurrentControl", "CurrentControl/", "~/Content/AuthorizedUsers/CurrentControl.aspx", true);
            routes.MapPageRoute("SoderjRazdDiscip", "SoderjRazdDiscip/", "~/Content/AuthorizedUsers/SoderjRazdDiscip.aspx", true);
            routes.MapPageRoute("RPD", "RPD/", "~/Content/AuthorizedUsers/RPD.aspx", true);
            routes.MapPageRoute("UMK", "UMK/", "~/Content/AuthorizedUsers/UMK.aspx", true);
            routes.MapPageRoute("Save", "Save/", "~/Content/AuthorizedUsers/save.aspx", true);
            routes.MapPageRoute("Logins", "Logins/", "~/Logins.aspx", true);
            routes.MapPageRoute("Find", "Find/", "~/Content/AuthorizedUsers/FindRpdForm.aspx");
            routes.MapPageRoute("FOS", "FOS/", "~/Content/AuthorizedUsers/FOS.aspx");
            routes.MapPageRoute("Question", "Question", "~/Content/AuthorizedUsers/Question.aspx");
            routes.MapPageRoute("Error", "Error/", "~/Error.aspx");
        }
    }
}