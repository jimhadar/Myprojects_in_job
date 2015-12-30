using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Umk_and_Rpd_on_Web {
    public partial class Authorization : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Page.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None; 
        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e) {
            Page.Validate();
            if (!Page.IsValid) {
                e.Authenticated = false;
                return;
            }
            if (Classes.Validate_password(Login2.UserName, Login2.Password)) {
                e.Authenticated = true;
                return;
            }
            else {
                e.Authenticated = false;
            }
        }

        protected void Login1_LoggedIn(object sender, EventArgs e) {
            FormsAuthentication.RedirectFromLoginPage(Login2.UserName, false);              
            using (AcademiaDataSetTableAdapters.PeoplenPassTableAdapter adapter = new AcademiaDataSetTableAdapters.PeoplenPassTableAdapter()) {
                adapter.Fill(new AcademiaDataSet.PeoplenPassDataTable());
                Session["CodPrepWhoEdit"] = Convert.ToInt32(adapter.GetCodPrep(Login2.UserName));
                //Session["CodPrepWhoEdit"] = 1293;
            }
            Session["CodPrep"] = null;
            //Переменная в состоянии сеанса для определения, что заполняется: умк или РПД
            Session["UMK_or_RPD"] = false;
            Session["CodFacPrep"] = 80;
            //Session["CodKafPrep"] = 24;
            Session["UchYear"] = DateTime.Now.Year;
            Session["CodFormStudy"] = 0;
            Session["CodTypeEdu"] = 10;
            Data_for_program data = new Data_for_program(1, false, 83, 70, DateTime.Now.Year - 1);
            Session["data"] = data;
            Session["Id_umk"] = null;
            Session["Id_rpd"] = null;
            //Session["CodPlan"] = 0;
            Response.Redirect("~/Title");
        }
    }
}