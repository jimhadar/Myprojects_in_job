using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class NestedMasterPage1 : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            Button_for_EndEditUMK_RPD.Text = "Завершить редактирование, \nперейти к сохранению";
        }

        protected void Button_for_EndEditUMK_RPD_Click(object sender, EventArgs e) {
            Data_for_program data = ((Data_for_program)Session["data"]);
            //Обновить поля объекта data данными из состояния сенаса
            data.CodTypeEdu = Convert.ToByte(Session["CodTypeEdu"]);
            data.CodFacPrep = Convert.ToByte(Session["CodFacPrep"]);
            data.CodKafPrep = Convert.ToByte(Session["CodKafPrep"]);
            data.CodFormStudy = Convert.ToByte(Session["CodFormStudy"]);
            data.CodSub = Convert.ToInt16(Session["CodSub"]);
            data.CodPlan = Convert.ToInt32(Session["CodPlan"]);
            data.CodSpeciality = Session["CodSpeciality"].ToString();
            data.UchYear = Convert.ToInt32(Session["UchYear"]);
            data.Umk_or_Rpd = Convert.ToBoolean(Session["UMK_or_RPD"]);
            data.CodPrepWhoEdit = Convert.ToInt32(Session["CodPrepWhoEdit"]);
            data.CodPrep = Convert.ToInt32(Session["CodPrep_Plan"]);
            
            Session["data"] = data;
            Response.Redirect("~/Save");
        }

        protected void TitleForm_btn_Click(object sender, EventArgs e) {
            Response.Redirect("~/Title");
        }

        protected void CompetetionForm_btn_Click(object sender, EventArgs e) {
            Response.Redirect("~/Competetion");
        }

        protected void SoderjRazdDiscip_btn_Click(object sender, EventArgs e) {
            Response.Redirect("~/SoderjRazdDiscip");
        }

        protected void CurrentControl_btn_Click(object sender, EventArgs e) {
            Response.Redirect("~/CurrentControl");
        }

        protected void RPD_or_UMK_btn_Click(object sender, EventArgs e) {                       
            Response.Redirect("~/RPD");
        }

        protected void UMK_btn_Click(object sender, EventArgs e) {
            Response.Redirect("~/UMK");
        }

        protected void Find_btn_Click(object sender, EventArgs e) {
            Response.Redirect("~/Find");
        }        
    }
}