using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class NestedMasterPage1 : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            Button_for_EndEditUMK_RPD.Text = "Завершить редактирование, \nперейти к сохранению";
            this.Save_Data_to_TmpContentsField();
            if (Request.Path == "/Find") {
                this.Button_for_EndEditUMK_RPD.Style.Add("display", "none");
            }
            if (Page.User.Identity.Name != "(ok)") {
                this.Find_btn.Visible = false;
            }
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
        /// <summary>
        /// сохраняем объект data типа Data_for_program в поле TmpContents таблицы UMK_and_RPD для того, 
        /// чтобы можно было восстановить это объект в случае какого-либо сбоя на сервере.
        /// Поле очищается, как только пользователь нажал кнопку "Завершить редактирование, перейти к сохранению"
        /// </summary>
        private void Save_Data_to_TmpContentsField() {
            //обновляем данные во временном поле Tmp_Contents таблицы UMK_and_RPD 
            if (Request["UpdateTmpContents"] != null && Session["CodSub"] != null) {
                using (AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter adapter = new AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter()) {
                    BinaryFormatter BinFormat = new BinaryFormatter();
                    Data_for_program data = (Data_for_program)Session["data"];
                    using (MemoryStream MemStream = new MemoryStream()) {                       
                        switch(Request.Path){
                            case @"/Competetion":
                                    data.GoalsDiscip = Request["GoalsDiscip"] != null ? Request["GoalsDiscip"].ToString() : string.Empty;
                                    data.PlaceOOP = Request["PlaceOOP"] != null ? Request["PlaceOOP"].ToString() : String.Empty;
                                    data.Student_Doljen_Znat = Request["Student_doljen_znat"] != null ? Request["Student_doljen_znat"].ToString() : String.Empty;
                                    data.Student_Doljen_Umet = Request["Student_doljen_umet"] != null ? Request["Student_doljen_umet"].ToString() : String.Empty;
                                    data.Student_doljen_Vladet = Request["Student_doljen_vladet"] != null ? Request["Student_doljen_vladet"].ToString() : String.Empty;
                                break;
                            case "/SoderjRazdDiscip":
                                    SoderjRazdDiscip.UpdateSoderjRazdelDiscip_table(data.SoderjRazd_DataTable, Request, Convert.ToInt32(Request["RowCountSoderjDiscip"]));
                                    LiteratureDataTable LiterTable = data.LiteratureTable;
                                    int RowCount = Convert.ToInt32(Request["RowCountLiteratureTable"]);
                                    LiterTable.Clear();
                                    for (int i = 0; i < RowCount; i++) {
                                        LiterTable.AddRow(Request["TypeLiter" + (i + 1).ToString()], Request["AboutLiter" + (i + 1).ToString()]);
                                    }
                                break;
                            case "/CurrentControl":
                                    CurrentControl.UpdateCurrentControlTable(data.CurControlTable, Convert.ToInt32(Request["RowCountCurControl"]), Request);    
                                break;
                            case "/RPD":
                                    data.othersFieldsForRPD.UpdateFields(Request["TypeAndFormCertification"] != null ? Request["TypeAndFormCertification"] : String.Empty,
                                                                        Request["UsedEcucateTechnology"] != null ? Request["UsedEcucateTechnology"] : String.Empty,
                                                                        Request["ExampleTestCurControl"] != null ? Request["ExampleTestCurControl"] : String.Empty,
                                                                        Request["ThemesOfEsseReferats"] != null ? Request["ThemesOfEsseReferats"] : String.Empty,
                                                                        Request["ThemesOfCourseJob"] != null ? Request["ThemesOfCourseJob"] : String.Empty,
                                                                        Request["OrganizationOfIndependentWork"] != null ? Request["OrganizationOfIndependentWork"] : String.Empty,
                                                                        Request["InterMediateControl"] != null ? Request["InterMediateControl"] : String.Empty,
                                                                        Request["ExampleTest"] != null ? Request["ExampleTest"] : String.Empty,
                                                                        Request["QuestionForExam"] != null ? Request["QuestionForExam"] : String.Empty,
                                                                        Request["LogisticsDiscipline"] != null ? Request["LogisticsDiscipline"] : String.Empty,
                                                                        Request["Part_InteractiveMethods"] != null ? Request["Part_InteractiveMethods"] : String.Empty);       
                                break;
                            case "/UMK":
                                    data.othersFieldsForUMK.UpdateFileds(Request["FormAndRulesCertification"] != null ? Request["FormAndRulesCertification"] : String.Empty,
                                                                        Request["QuestionForExam"] != null ? Request["QuestionForExam"] : String.Empty,
                                                                        Request["ExampleExamTests"] != null ? Request["ExampleExamTests"] : String.Empty);
                                break;
                            
                        }                           
                        if (data.Id_rpd != null) {
                            BinFormat.Serialize(MemStream, data);
                            MemStream.Seek(0, SeekOrigin.Begin);
                            adapter.UpdateTmpContents(MemStream.ToArray(), (int)data.Id_rpd);
                        }
                        if (data.Id_umk != null) {
                            BinFormat.Serialize(MemStream, data);
                            MemStream.Seek(0, SeekOrigin.Begin);
                            adapter.UpdateTmpContents(MemStream.ToArray(), (int)data.Id_umk);
                        }
                    }
                }
            }
        }
    }
}