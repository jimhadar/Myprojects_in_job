using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace Umk_and_Rpd_on_Web {
    public partial class Main : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void Login1_LoggingOut(object sender, LoginCancelEventArgs e) {
            ((Data_for_program)Session["data"]).DeleteDocFiles();
            Session["data"] = null;
            Session["CodPrep"] = null;
            Session["CodKafPrep"] = 24;
            Session["CodFacPrep"] = 80;
            //Переменная в состоянии сеанса для определения, что заполняется: умк или РПД
            Session["UMK_or_RPD"] = false;
            //Session["CodKafPrep"] = 24;
            Session["UchYear"] = DateTime.Now.Year;
            Session["CodFormStudy"] = 0;
            Session["CodTypeEdu"] = 10;
            Session["Id_umk"] = null;
            Session["Id_rpd"] = null;
            Session["CodPlan"] = null;
            Session["CodSub"] = null;
        }
    }
}