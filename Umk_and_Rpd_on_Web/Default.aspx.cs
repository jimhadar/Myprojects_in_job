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
            if (Classes.IsConnectedAcademia("Data Source=SQL;Initial Catalog=academia;Integrated Security=True")) {
                if (Classes.Validate_password(Login2.UserName, Login2.Password)) {
                    e.Authenticated = true;
                    return;
                }
                else {
                    e.Authenticated = false;
                }
            }
            else {
                e.Authenticated = false;
                Response.Redirect("~/Error");
            }
        }

        protected void Login1_LoggedIn(object sender, EventArgs e) {
            FormsAuthentication.RedirectFromLoginPage(Login2.UserName, false);
            //try {
                using (AcademiaDataSetTableAdapters.PeoplenPassTableAdapter adapter = new AcademiaDataSetTableAdapters.PeoplenPassTableAdapter()) {
                    adapter.Fill(new AcademiaDataSet.PeoplenPassDataTable());
                    Session["CodPrepWhoEdit"] = Convert.ToInt32(adapter.GetCodPrep(Login2.UserName));
                    //Session["CodPrepWhoEdit"] = 1293;
                }
                Session["CodPrep"] = null;
                if (Session["CodFacPrep"] == null) {
                    Session["CodFacPrep"] = 80;
                }
                //Session["CodKafPrep"] = 24;
                if (Session["UchYear"] == null) {
                    Session["UchYear"] = DateTime.Now.Year;
                }
                if (Session["CodFormStudy"] == null) {
                    Session["CodFormStudy"] = 0;
                }
                if (Session["CodTypeEdu"] == null) {
                    Session["CodTypeEdu"] = 10;
                }
                if (Session["data"] == null) {
                    Data_for_program data = new Data_for_program(1, false, 83, 70, (DateTime.Now.Month < 9) ? DateTime.Now.Year - 1 : DateTime.Now.Year);
                    Session["data"] = data;
                }
                //Session["CodPlan"] = 0;
                Response.Redirect("~/Title");
            //}
            //catch {
            //    Response.Redirect("~/Error");
            //}
        }
    }
}