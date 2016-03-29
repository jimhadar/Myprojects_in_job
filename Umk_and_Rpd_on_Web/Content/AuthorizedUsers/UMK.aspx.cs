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
            if (Page.IsPostBack && Request["UpdateTmpContents"] == null) {
                if (Session["data"] != null) {
                    //OthersFieldsForUMK othersFields = ((Data_for_program)Session["data"]).othersFieldsForUMK;                     
                    ((Data_for_program)Session["data"]).othersFieldsForUMK.UpdateFileds(this.FormPromejAttestatTextBox.Text.Trim(),
                                                                                        this.QuestionForExamTextBox.Text.Trim(),
                                                                                        this.ExampleExTestTextBox.Text.Trim());
                }
            }
            if (!Page.IsPostBack && Request["UpdateTmpContents"] == null) {
                if (Session["data"] != null) {
                    if (((Data_for_program)Session["data"]).othersFieldsForUMK.Form_And_Rules_Certification.Count == 1 &&
                        ((Data_for_program)Session["data"]).othersFieldsForUMK.Form_And_Rules_Certification[0].Trim() == string.Empty) {
                        ((Data_for_program)Session["data"]).othersFieldsForUMK.FormAndRulesCertification = ((Data_for_program)Session["data"]).othersFieldsForRPD.TypeAndFormCertification;
                    }
                    if (((Data_for_program)Session["data"]).othersFieldsForUMK.Question_For_Exam.Count == 1 &&
                        ((Data_for_program)Session["data"]).othersFieldsForUMK.Question_For_Exam[0].Trim() == string.Empty) {
                        ((Data_for_program)Session["data"]).othersFieldsForUMK.QuestionForExam = ((Data_for_program)Session["data"]).othersFieldsForRPD.QuestionForExam;
                    }
                    if (((Data_for_program)Session["data"]).othersFieldsForUMK.Example_Exam_Tests.Count == 1 &&
                        ((Data_for_program)Session["data"]).othersFieldsForUMK.Example_Exam_Tests[0].Trim() == string.Empty) {
                        ((Data_for_program)Session["data"]).othersFieldsForUMK.Example_Exam_Tests = ((Data_for_program)Session["data"]).othersFieldsForRPD.Example_Test;
                    }
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