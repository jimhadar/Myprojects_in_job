﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace Umk_and_Rpd_on_Web {
    public partial class TitlePage : System.Web.UI.Page {
        private void GetValuesInSession() {
            if (this.DropDownList_FacDiscip.SelectedValue != String.Empty) {
                Session["CodFacPrep"] = Convert.ToByte(this.DropDownList_FacDiscip.SelectedValue);
            }
            if (this.DropDownList_KafDiscip.SelectedValue != String.Empty) {
                Session["CodKafPrep"] = Convert.ToByte(this.DropDownList_KafDiscip.SelectedValue);
            }
            if (this.DropDownList_TypeEdu.SelectedValue != String.Empty) {
                Session["CodTypeEdu"] = Convert.ToByte(this.DropDownList_TypeEdu.SelectedValue);
            }
            if (this.DropDownList_FormStudy.SelectedValue != String.Empty) {
                Session["CodFormStudy"] = Convert.ToByte(this.DropDownList_FormStudy.SelectedValue);
            }
            if (this.DropDownList_StudyYear.SelectedValue != String.Empty) {
                Session["UchYear"] = Convert.ToInt32(this.DropDownList_StudyYear.SelectedValue);
            }
            if (this.DropDownList_Speciality.SelectedValue != String.Empty) {
                Session["CodSpeciality"] = this.DropDownList_Speciality.SelectedValue;
            }
            if (this.DropDownList_StudyPlans.SelectedValue != String.Empty) {
                Session["CodPlan"] = Convert.ToInt32(this.DropDownList_StudyPlans.SelectedValue);
            }
            else if( this.DropDownList_StudyPlans.Items.Count != 0 ) {
                this.DropDownList_StudyPlans.Items[0].Selected = true;
                Session["CodPlan"] = Convert.ToInt32(this.DropDownList_StudyPlans.SelectedValue);
            }
            if (this.DropDownList_StudyPlans.SelectedValue == String.Empty) {
                Session["CodPlan"] = 0;
            }
        }              
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["data"] == null) {
                Session["data"] = new Data_for_program( (int)Session["CodPrepWhoEdit"],
                                                        (bool)Session["UMK_or_RPD"],
                                                        (byte)Session["CodFacPrep"],
                                                        (byte)Session["CodKafPrep"],
                                                        (int)Session["UchYear"]);
            }
            if (!Page.IsPostBack) {
                Load_DropDownList_for_uch_year();
                Load_All_selectLists_SelectedValue(); 
                //Выделение строки в NagruzkaOnPrepGridView 
                int SelectRow;
                if ((SelectRow = GetSelectRowInNazguzkaOnPrepGridView()) != -1) {
                    NagruzkaOnPrepGridView.SelectRow(SelectRow);
                    CurrentSelectSub.InnerText = "РПД / УМК будет составляться для дисциплины\"" + NagruzkaOnPrepGridView.Rows[NagruzkaOnPrepGridView.SelectedIndex].Cells[3].Text + "\"";
                }
                else if (NagruzkaOnPrepGridView.Rows.Count > 0) {
                    NagruzkaOnPrepGridView.SelectRow(-1);
                }                
            }
            using (AcademiaDataSetTableAdapters.PEOPLENTableAdapter peolpelen = new AcademiaDataSetTableAdapters.PEOPLENTableAdapter()) {
                AcademiaDataSet.PEOPLENDataTable PeopleLenTable = new AcademiaDataSet.PEOPLENDataTable();
                peolpelen.Fill(PeopleLenTable);
                Label_for_hello_user.Text += peolpelen.GetFIO(Convert.ToInt32(Session["CodPrepWhoEdit"]));
            }
        }

        protected void Page_PreRender(object sender, EventArgs e) {
        }

        protected void Page_UnLoad(object sender, EventArgs e) {
            this.GetValuesInSession();
        }

        #region Вспомогательные методы
        /// <summary>
        /// Заполнение DropDownList_for_uch_year данными
        /// </summary>
        protected void Load_DropDownList_for_uch_year() {
            if (this.DropDownList_StudyYear.Items.Count != 0) {
                Session["UchYear"] = Convert.ToInt32(this.DropDownList_StudyYear.SelectedValue);
            }
            DropDownList_StudyYear.Items.Clear();
            int NowYear = DateTime.Now.Year;
            int[] mas_year = new int[6];
            for (int i = 0; i < 6; i++ ) {
                mas_year[i] = NowYear - i + 3;
            }          
            for (int i = 0; i < 6; i++) {
                ListItem item = new ListItem();
                item.Text = mas_year[i].ToString() + @" / " + (mas_year[i] + 1).ToString();
                item.Value = mas_year[i].ToString();
                this.DropDownList_StudyYear.Items.Add(item);
            }            
            if (Session["UchYear"] == null) {
                Session["UchYear"] = NowYear;
            }
            DropDownList_StudyYear.SelectedValue = Session["UchYear"].ToString();
            ((Data_for_program)Session["data"]).UchYear = (int)Session["UchYear"];
        }
        /// <summary>
        /// Определение фона для отдельных строк GridView, в зависимости от того, существует или нет в базе данных РПД/УМК для дисциплины
        /// </summary>
        protected void backcolor_Items_for_GridView() {
            /*if ( this.NagruzkaOnPrepGridView.Rows.Count != 0 ) {
                using(AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter adapter = new AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter()){
                    adapter.Fill(new AcademiaDataSet.UMK_and_RPDDataTable());
                    object row;
                    short   CodSub,
                            CodPlan = Convert.ToInt16(Session["CodPlan"]);
                    byte CodKafDiscip = Convert.ToByte(Session["CodKafPrep"]);
                    int? CodPrepPlan;
                    bool Umk_or_RPD = (bool)(Session["UMK_or_RPD"]);
                    foreach (GridViewRow Row in NagruzkaOnPrepGridView.Rows) {
                        CodSub = Convert.ToInt16(Row.Cells[2].Text);
                        CodPrepPlan = Convert.ToInt32(Row.Cells[4].Text);
                        row = adapter.GetRow(CodSub,
                                             CodPlan,
                                             Umk_or_RPD,
                                             Convert.ToInt16(this.DropDownList_StudyYear.SelectedValue),
                                             CodKafDiscip,
                                             CodPrepPlan);
                        Row.BackColor = System.Drawing.Color.FromArgb(235, 243, 242);
                        if (row != null) {
                            Row.BackColor = System.Drawing.Color.Lime;
                        }
                    }
                }
                if (this.NagruzkaOnPrepGridView.SelectedRow != null && this.NagruzkaOnPrepGridView.SelectedRow.BackColor != System.Drawing.Color.Lime) {
                    this.NagruzkaOnPrepGridView.SelectedRow.BackColor = System.Drawing.Color.FromArgb(153, 204, 255);
                }
            } */
        }
        /// <summary>
        /// получение Id РПД/УМК на основе параметров
        /// </summary>
        protected void GetId_umk_and_rpd_in_DB(short CodSub, 
            short CodPlan, 
            short StudyYear,
            byte CodKafDiscip,
            int? CodPrepPlan,
            out int? id_umk, 
            out int? id_rpd) {
            using (AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter adapter = new AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter()) {
                adapter.Fill(new AcademiaDataSet.UMK_and_RPDDataTable());
                object row_id_umk;
                object row_id_rpd;
                row_id_rpd = adapter.GetId(CodSub, false, StudyYear, CodPlan, CodKafDiscip, CodPrepPlan);
                row_id_umk = adapter.GetId(CodSub, true, StudyYear, CodPlan, CodKafDiscip, CodPrepPlan);
                id_umk = (int?)row_id_umk;
                id_rpd = (int?)row_id_rpd;
                /*if(id_umk != null || id_rpd != null){
                    Data_for_program data = (Data_for_program)Session["data"];
                    data.Id_umk = id_umk;
                    data.Id_rpd = id_rpd;
                    data.LoadDataToProgramFromDataBase();
                }     */
            }
        }

        protected int GetSelectRowInNazguzkaOnPrepGridView() {
            if (NagruzkaOnPrepGridView.Rows.Count > 0 && Session["CodSub"] != null) {
                foreach (GridViewRow Row in this.NagruzkaOnPrepGridView.Rows) {
                    if (Row.Cells[2].Text == Session["CodSub"].ToString()) {
                        return Row.RowIndex;
                    }
                }
                return 0;
            }
            else {
                return -1;
            } 
        }

        protected void Load_All_selectLists_SelectedValue() {
            this.DropDownList_FacDiscip.SelectedValue = Session["CodFacPrep"].ToString();
            if (Session["CodKafPrep"] != null) {
                this.DropDownList_KafDiscip.SelectedValue = Session["CodKafPrep"].ToString();
            }
            this.DropDownList_TypeEdu.SelectedValue = Session["CodTypeEdu"].ToString();
            this.DropDownList_FormStudy.SelectedValue = Session["CodFormStudy"].ToString();
            this.DropDownList_StudyYear.SelectedValue = Session["UchYear"].ToString();  
            if(Session["CodSpeciality"] != null){
                this.DropDownList_Speciality.SelectedValue = Session["CodSpeciality"].ToString();
            }
            if(Session["CodPlan"] != null && Convert.ToInt32(Session["CodPlan"]) != 0 && this.DropDownList_StudyPlans.Items.Count > 0){
                this.DropDownList_StudyPlans.SelectedValue = Session["CodPlan"].ToString();
            }
        }
        #endregion

        protected void DropDownList_for_uch_year_SelectedIndexChanged(object sender, EventArgs e) {
            //this.GetValuesInSession();             
            Session["UchYear"] = Convert.ToInt32(this.DropDownList_StudyYear.SelectedValue);
            ((Data_for_program)Session["data"]).UchYear = (int)Session["UchYear"];
            backcolor_Items_for_GridView();
            NagruzkaOnPrepGridView.SelectRow(-1);
            //Load_All_selectLists_SelectedValue();
        } 
        protected void NagruzkaOnPrepGridView_DataBound(object sender, EventArgs e) {
            backcolor_Items_for_GridView();
        }

        protected void NagruzkaOnPrepGridView_SelectedIndexChanged(object sender, EventArgs e) {
            if(NagruzkaOnPrepGridView.SelectedRow != null){
                Session["CodSub"] = Convert.ToInt16(this.NagruzkaOnPrepGridView.SelectedRow.Cells[2].Text);

                Session["CodPrep_Plan"] = Convert.ToInt32(this.NagruzkaOnPrepGridView.SelectedRow.Cells[4].Text);

                backcolor_Items_for_GridView();
                CurrentSelectSub.InnerText = "РПД / УМК будет составляться для дисциплины\"" + NagruzkaOnPrepGridView.Rows[NagruzkaOnPrepGridView.SelectedIndex].Cells[3].Text + "\"";
                int? id_rpd, id_umk;
                GetId_umk_and_rpd_in_DB(Convert.ToInt16(Session["CodSub"]),
                                        Convert.ToInt16(Session["CodPlan"]),
                                        Convert.ToInt16(Session["UchYear"]),
                                        (byte)Session["CodKafPrep"],
                                        (int?)Session["CodPrep_Plan"],
                                        out id_umk,
                                        out id_rpd);
                Data_for_program data = (Data_for_program)Session["data"];
                if(id_umk != data.Id_umk || id_rpd != data.Id_rpd){
                    data.Id_rpd = id_rpd;
                    data.Id_umk = id_umk;
                    data.LoadDataToProgramFromDataBase();
                }
            }
        }

        protected void FacultyDropDownList_SelectedIndexChanged(object sender, EventArgs e) {
            Session["CodFacPrep"] = Convert.ToByte(this.DropDownList_FacDiscip.SelectedValue);
            ((Data_for_program)Session["data"]).CodFacPrep = (byte?)Session["CodFacPrep"];
            Session["CodKafPrep"] = null;
        }

        protected void KafsDropDownList_SelectedIndexChanged(object sender, EventArgs e) {
            Session["CodKafPrep"] = Convert.ToByte(this.DropDownList_KafDiscip.SelectedValue);
            ((Data_for_program)Session["data"]).CodKafPrep = (byte?)Session["CodKafPrep"];
        }

        protected void Button_for_GoalsDiscip_Click(object sender, EventArgs e) {
            Response.Redirect("Competetion.aspx");
        }

        protected void Button_for_MethodUkaz_Click(object sender, EventArgs e) {
            Response.Redirect("SoderjRazdDiscip.aspx");
        }

        protected void Button_for_InfUMK_or_RPD_Click(object sender, EventArgs e) {
            Response.Redirect("UMK/UMK.aspx");
        }

        protected void Button_next_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/Competetion");
        }

        protected void DropDownList_FormStudy_SelectedIndexChanged(object sender, EventArgs e) {
            if(this.DropDownList_FormStudy.SelectedValue != null){
                Session["CodFormStudy"] = Convert.ToByte(this.DropDownList_FormStudy.SelectedValue);
                ((Data_for_program)Session["data"]).CodFormStudy = (byte?)Session["CodFormStudy"];
                Session["CodSpeciality"] = null;
                Session["CodPlan"] = 0;
            }
            else {
                ((Data_for_program)Session["data"]).CodFormStudy = null;
            }            
        }

        protected void DropDownList_TypeEdu_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.DropDownList_TypeEdu.SelectedValue != null) {
                Session["CodTypeEdu"] = Convert.ToByte(this.DropDownList_TypeEdu.SelectedValue);
                ((Data_for_program)Session["data"]).CodTypeEdu = Convert.ToByte(this.DropDownList_TypeEdu.SelectedValue);
                Session["CodSpeciality"] = null;
                Session["CodPlan"] = 0;
            }
            else {
                Session["CodTypeEdu"] = 10;
                ((Data_for_program)Session["data"]).CodTypeEdu = 10;
            }
        }

        protected void DropDownList_Speciality_SelectedIndexChanged(object sender, EventArgs e) {
            if(this.DropDownList_Speciality.SelectedValue != null){
                Session["CodSpeciality"] = this.DropDownList_Speciality.SelectedValue;
                ((Data_for_program)Session["data"]).CodSpeciality = this.DropDownList_Speciality.SelectedValue;
                Session["CodPlan"] = 0;
            }
            else {
                Session["CodSpeciality"] = null;
                ((Data_for_program)Session["data"]).CodSpeciality = null;
            }
        }

        protected void DropDownList_StudyPlans_SelectedIndexChanged(object sender, EventArgs se) {
            if (this.DropDownList_StudyPlans.SelectedValue != null) {
                Session["CodPlan"] = Convert.ToInt32(this.DropDownList_StudyPlans.SelectedValue);
                ((Data_for_program)Session["data"]).CodPlan = Convert.ToInt32(this.DropDownList_StudyPlans.SelectedValue);
                NagruzkaOnPrepGridView.SelectRow(-1);
            }
            else {
                Session["CodPlan"] = null;
                ((Data_for_program)Session["data"]).CodPlan = null;
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            GetValuesInSession();
        }

        protected void DropDownList_KafDiscip_DataBound(object sender, EventArgs e) {
            //если был выбран другой факультет, то новый код кафедры = кафедре первой в списке
            if(Session["CodKafPrep"] == null){
                Session["CodKafPrep"] = Convert.ToByte(this.DropDownList_KafDiscip.Items[0].Value);
                ((Data_for_program)Session["data"]).CodKafPrep = (byte?)Session["CodKafPrep"];
            }
            else {
                this.DropDownList_KafDiscip.SelectedValue = Session["CodKafPrep"].ToString();
            }
        }

        protected void DropDownList_StudyPlans_DataBound(object sender, EventArgs e) {
            if(DropDownList_StudyPlans.Items.Count != 0 && (Session["CodPlan"] == null || (int)Session["CodPlan"] == 0)) {
                Session["CodPlan"] = Convert.ToInt32(this.DropDownList_StudyPlans.SelectedValue);
            }
            else if (DropDownList_StudyPlans.Items.Count == 0) {
                Session["CodPlan"] = 0;
            }
            else {
                this.DropDownList_StudyPlans.SelectedValue = Session["CodPlan"].ToString();
            }
        }

        protected void DropDownList_Speciality_DataBound(object sender, EventArgs e) {
            if (Session["CodSpeciality"] == null) {
                Session["CodSpeciality"] = this.DropDownList_Speciality.SelectedValue;
                ((Data_for_program)Session["data"]).CodSpeciality = this.DropDownList_Speciality.SelectedValue;
            }
            else {
                this.DropDownList_Speciality.SelectedValue = Session["CodSpeciality"].ToString();
            }
        }
    }   
}