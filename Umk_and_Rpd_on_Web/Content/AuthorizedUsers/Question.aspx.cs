using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class Question : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            this.Label_question.Text = "Удалить информацию, введенную для РПД предыдущей дисципины?";
            this.Clear_btn.Text = "Удалить информацию";
            this.No_btn.Text = "Не удалять информацию и использовать ее \nдля заполнения всех полей РПД выбранной дисциплины";
        }

        protected void No_btn_Click(object sender, EventArgs e) {
            Response.Redirect("~/Title");
        }

        protected void Clear_btn_Click(object sender, EventArgs e) {
            Data_for_program data = (Data_for_program)Session["data"];
            data.ClearAllFields();
            Response.Redirect("~/Title");
        }                            
    }
}