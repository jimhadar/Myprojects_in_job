using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Web.UI.HtmlControls;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class Question : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            switch(this.Request.QueryString["TypeQuestion"]){
                case "SfromPassportCompet":
                        this.Label_question.Text = string.Empty;                    
                        this.No_btn.Visible = false;
                        this.Clear_btn.Text = "Сформировать паспорт компетенций";
                    break;
                default:
                        this.Label_question.Text = "Удалить информацию, введенную для РПД предыдущей дисципины?";
                        this.Clear_btn.Text = "Удалить информацию";
                        this.No_btn.Text = "Не удалять информацию и использовать ее \nдля заполнения всех полей РПД выбранной дисциплины";
                    break;
            }
        }

        protected void No_btn_Click(object sender, EventArgs e) {
            switch (this.Request.QueryString["TypeQuestion"]) {
                case "SfromPassportCompet":
                    
                    break;
                default:
                    Response.Redirect("~/Title");
                    break;
            }                 
        }

        protected void Clear_btn_Click(object sender, EventArgs e) {
            Data_for_program data = (Data_for_program)Session["data"];
            switch (this.Request.QueryString["TypeQuestion"]) {
                case "SfromPassportCompet":
                    data.CodPlan = (int?)Session["CodPlan"];
                    string path = data.SaveDataToDataBase_and_toDocx(true, HowDoc_Save.SavePassportCompet, Request.PhysicalApplicationPath, Request.ApplicationPath);
                    HtmlGenericControl a = new HtmlGenericControl("a");
                    a.Attributes.Add("href", path);
                    a.InnerText = "Скачать паспорт компетенций";
                    a.Attributes.Add("class", "btn");
                    a.Attributes.Add("type", "application/file");
                    this.sect.Controls.Add(a);
                    break;
                default:                     
                    data.ClearAllFields();
                    Response.Redirect("~/Title");
                    break;
            }            
        }                            
    }
}