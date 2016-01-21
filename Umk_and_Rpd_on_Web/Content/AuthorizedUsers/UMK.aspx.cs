using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Web.UI.HtmlControls;
using Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters;
using Umk_and_Rpd_on_Web;
using System.Data;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers.UMK {
    public partial class UMK : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack) {
                if (Session["data"] != null) {
                    //OthersFieldsForUMK othersFields = ((Data_for_program)Session["data"]).othersFieldsForUMK;
                    ((Data_for_program)Session["data"]).othersFieldsForUMK.UpdateFileds(this.FormPromejAttestatTextBox.Text.Trim(),
                                                                                        this.QuestionForExamTextBox.Text.Trim(),
                                                                                        this.ExampleExTestTextBox.Text.Trim());
                }
            }
            if(!Page.IsPostBack){
                if (Session["data"] != null) {
                    OthersFieldsForUMK othersFields = ((Data_for_program)Session["data"]).othersFieldsForUMK;
                    this.FormPromejAttestatTextBox.Text = othersFields.FormAndRulesCertification;
                    this.ExampleExTestTextBox.Text = othersFields.ExampleExamTests;
                    this.QuestionForExamTextBox.Text = othersFields.QuestionForExam;
                }
            }
            Page.Title = "УМК";
        }

        protected void Button_for_pred_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/RPD");
        }

        protected void Button_next_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/FOS");
        }
    }
}