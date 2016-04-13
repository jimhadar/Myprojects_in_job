using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Diagnostics;
using System.Web.UI.HtmlControls;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class save : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Page.Title = "Формирование файла *.docx";
            if (!Page.IsPostBack) {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Data_for_program data = (Data_for_program)Session["data"];
                using (AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter adapter = new AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter()) {
                    if ((bool?)Session["AllowEditRpd"] == false) {
                        this.SaveAnnotation_btn.Visible = false;
                        this.SaveFos_btn.Visible = false;
                        this.SaveRPD_btn.Visible = false;
                        this.SaveUMK_btn.Visible = false;
                        return;
                    }
                }
                data.GetValues();
                Session["data"] = data;
                using (AcademiaDataSetTableAdapters.TmpUMK_rpd_ControlSignUpTableAdapter tmpContentControl = new AcademiaDataSetTableAdapters.TmpUMK_rpd_ControlSignUpTableAdapter()) {
                    using(AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter rpd_adapter = new AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter()){
                        string oldData = rpd_adapter.GetContents(data.Id_rpd);
                        data.SaveDataToDataBase_and_toDocx(true, HowDoc_Save.SaveToDataBase, "", "");
                        tmpContentControl.Insert1(data.Id_rpd, 
                                                    DateTime.Now, 
                                                    oldData,
                                                    data.Data_with_RPD.Substring(0, 19) + data.Data_with_RPD.Substring(36, data.Data_with_RPD.Length - 36), 
                                                    Page.User.Identity.Name, 
                                                    HttpContext.Current.Request.UserHostAddress);
                    }
                }
                sw.Stop();
            }
            else {

            } 
            /*if (Page.User.Identity.Name != "(ok)" && Page.User.Identity.Name != "test") {
                this.SaveFos_btn.Visible = false;
            } */
        }

        protected void SaveRPD_Click(object sender, EventArgs e) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //сохраняем даные из состояния сеанса в базу данных
            Data_for_program data = (Data_for_program)Session["data"];
            string path = String.Empty;
            if (data != null) {
                path = data.SaveDataToDataBase_and_toDocx(false, HowDoc_Save.SaveRPD, Request.PhysicalApplicationPath, Request.ApplicationPath);
            }
            sw.Stop();
            HtmlGenericControl a = new HtmlGenericControl("a");
            a.Attributes.Add("href", path);
            a.InnerText = "Скачать РПД";
            a.Attributes.Add("class", "btn");
            a.Attributes.Add("type", "application/file"); 
            this.Link_SaveRPD.Controls.Add(a);
        }

        protected void SaveUMK_btn_Click(object sender, EventArgs e) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //сохраняем УМК из состояния сеанса в базу данных
            Data_for_program data = (Data_for_program)Session["data"];
            string path = String.Empty;
            if(data != null){
                path = data.SaveDataToDataBase_and_toDocx(true, HowDoc_Save.SaveUmk, Request.PhysicalApplicationPath, Request.ApplicationPath);
            }
            sw.Stop();
            HtmlGenericControl a = new HtmlGenericControl("a");
            a.Attributes.Add("href", path);
            a.InnerText = "Скачать УМК";
            a.Attributes.Add("class", "btn");
            a.Attributes.Add("type", "application/file");
            this.Link_SaveUMK.Controls.Add(a);
        }

        protected void SaveAnnotation_btn_Click(object sender, EventArgs e) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //сохраняем УМК из состояния сеанса в базу данных
            Data_for_program data = (Data_for_program)Session["data"];
            string path = String.Empty;
            if (data != null) {
                path = data.SaveDataToDataBase_and_toDocx(true, HowDoc_Save.SaveAnnotationToRPD, Request.PhysicalApplicationPath, Request.ApplicationPath);
            }
            sw.Stop();
            HtmlGenericControl a = new HtmlGenericControl("a");
            a.Attributes.Add("href", path);
            a.InnerText = "Скачать аннотацию к РПД";
            a.Attributes.Add("class", "btn");
            a.Attributes.Add("type", "application/file");
            this.Link_SaveAnnotationToRPD.Controls.Add(a);
        }

        protected void Button_toEditRPD_Click(object sender, EventArgs e) {
            ((Data_for_program)Session["data"]).DeleteDocFiles();
            Response.Redirect("~/Title");
        }

        protected void SaveFos_btn_Click(object sender, EventArgs e) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //сохраняем УМК из состояния сеанса в базу данных
            Data_for_program data = (Data_for_program)Session["data"];
            string path = String.Empty;
            if (data != null) {
                path = data.SaveDataToDataBase_and_toDocx(true, HowDoc_Save.SaveFOS, Request.PhysicalApplicationPath, Request.ApplicationPath);
            }
            sw.Stop();
            HtmlGenericControl a = new HtmlGenericControl("a");
            a.Attributes.Add("href", path);
            a.InnerText = "Скачать ФОС";
            a.Attributes.Add("class", "btn");
            a.Attributes.Add("type", "application/file");
            this.Link_ToFos.Controls.Add(a);
        }
    }
}