using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers.RPD {
    public partial class RPD : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack && !Page.IsCallback && Request["UpdateTmpContents"] == null) {
                if (Session["data"] != null) {
                    Data_for_program data = (Data_for_program)Session["data"];
                    data.othersFieldsForRPD.UpdateFields(this.TypeAndFormCertificationTextBox.Text.Trim(),
                                                        this.UsedEcucateTechnologyTextBox.Text.Trim(),
                                                        this.ExampleTestCurControlTextBox.Text.Trim(),
                                                        this.ThemesOfEsseReferatsTextBox.Text.Trim(),
                                                        this.ThemesOfCourseJobTextBox.Text.Trim(),
                                                        this.OrganizationOfIndependentWorkTextBox.Text.Trim(),
                                                        this.InterMediateControlTextBox.Text.Trim(),
                                                        this.ExampleTestTextBox.Text.Trim(),
                                                        this.QuestionForExamTextBox.Text.Trim(),
                                                        this.LogisticsDisciplineTextBox.Text.Trim(),
                                                        TextBox_Part_InteractiveMethods.Text.Trim());
                    Session["data"] = data;
                }
            }
            if (!Page.IsCallback && Request["UpdateTmpContents"] == null) {
                if(Session["data"] != null){
                    OthersFieldsForRPD RPDFields = ((Data_for_program)Session["data"]).othersFieldsForRPD;
                    this.TypeAndFormCertificationTextBox.Text = RPDFields.TypeAndFormCertification;
                    this.UsedEcucateTechnologyTextBox.Text = RPDFields.UsedEcucateTechnology;
                    this.ExampleTestCurControlTextBox.Text = RPDFields.ExampleTestCurControl;
                    this.ThemesOfEsseReferatsTextBox.Text = RPDFields.ThemesOfEsseReferats;
                    this.ThemesOfCourseJobTextBox.Text = RPDFields.ThemesOfCourseJob;
                    this.OrganizationOfIndependentWorkTextBox.Text = RPDFields.OrganizationOfIndependentWork;
                    this.InterMediateControlTextBox.Text = RPDFields.InterMediateControl;
                    this.ExampleTestTextBox.Text = RPDFields.ExampleTest;
                    this.QuestionForExamTextBox.Text = RPDFields.QuestionForExam;
                    this.LogisticsDisciplineTextBox.Text = RPDFields.LogisticsDiscipline;
                    TextBox_Part_InteractiveMethods.Text = RPDFields.PartInteractiveMethods;
                }
            }
            Page.Title = "РПД";
        }

        protected void Button_for_pred_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/CurrentControl");
        }

        protected void Button_next_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/UMK");
        }
    }
}