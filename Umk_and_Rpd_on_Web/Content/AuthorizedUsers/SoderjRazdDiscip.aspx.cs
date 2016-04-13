using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters;
using Umk_and_Rpd_on_Web;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class SoderjRazdDiscip : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack && !Page.IsCallback && Request["UpdateTmpContents"] == null) {
                Data_for_program data = ((Data_for_program)Session["data"]);
                if (data != null) {
                    if (this.RowCountSoderjDiscip.Value == String.Empty) { this.RowCountSoderjDiscip.Value = data.SoderjRazd_DataTable.RowCount.ToString(); }
                    UpdateSoderjRazdelDiscip_table(data.SoderjRazd_DataTable, this.Request, Convert.ToInt32(this.RowCountSoderjDiscip.Value.ToString()));
                }
            }
            if (!Page.IsPostBack && !Page.IsCallback && Request["UpdateTmpContents"] == null) {                
                ViewSoderjRazdInClient();
                AddSemestrSelect_and_OcenSredstvSelectInClient();
            }
            Page.Title = "Содержание разделов дисциплины";
        }     
        /// <summary>
        /// обновление таблицы с содержанием занятий, хранящейся в состоянии сеанса, данными пришедшими с клиентра в результате обратной отправки 
        /// </summary>
        /// <param name="SoderjDiscipTable">Таблица с содержанием разделов дисциплины из состояния сеанса</param>
        /// <param name="Request">данные, отправленные клиентом</param>
        /// <param name="RowCount">количество строк в таблице SoderjDiscipTable</param>
        internal static void UpdateSoderjRazdelDiscip_table(SoderjRazdDiscip_DataTable SoderjDiscipTable, HttpRequest Request, int RowCount) {
            //int RowCount = Convert.ToInt32(this.RowCountSoderjDiscip.Value.ToString());
            SoderjDiscipTable.Clear();
            for (int i = 0; i < RowCount; i++) {
                var Value_for_all_cells = new object[5];
                Value_for_all_cells[0] = Request["Vid" + i.ToString()];
                Value_for_all_cells[1] = Request["Semestr" + i.ToString()];
                Value_for_all_cells[2] = Request["AboutTheme" + i.ToString()];
                Value_for_all_cells[3] = Request["Volume" + i.ToString()];
                Value_for_all_cells[4] = Request["FormCurControl" + i.ToString()];

                if (Value_for_all_cells[3] != null && Value_for_all_cells[3].ToString() != String.Empty) {
                    try {
                        Convert.ToDouble(Value_for_all_cells[3]);
                    }
                    catch {
                        Value_for_all_cells[3] = Value_for_all_cells[3].ToString().Replace('.', ',');
                    }
                    finally{
                       Value_for_all_cells[3] = Convert.ToDouble(Value_for_all_cells[3]);
                    }
                }

                SoderjDiscipTable.AddRow((Value_for_all_cells[0] != null) ? Value_for_all_cells[0].ToString().Trim() : String.Empty,
                                        (Value_for_all_cells[1] != null) ? Value_for_all_cells[1].ToString().Trim() : String.Empty,
                                        (Value_for_all_cells[2] != null) ? Value_for_all_cells[2].ToString().Trim() : String.Empty,
                                        (Value_for_all_cells[3] != null && Value_for_all_cells[3].ToString() != String.Empty) ? (double)Value_for_all_cells[3] : 0,
                                        (Value_for_all_cells[4] != null) ? Value_for_all_cells[4].ToString().Trim() : String.Empty);
            }
        }

        /// <summary>
        /// отрисовка таблицы с содержанием занятий
        /// </summary>
        private void ViewSoderjRazdInClient() {
            Data_for_program data = ((Data_for_program)Session["data"]);
            while (Table_for_soderjDiscip.Rows.Count != 1) {
                Table_for_soderjDiscip.Rows.RemoveAt(Table_for_soderjDiscip.Rows.Count - 1);
            }
            int? CodPlan = (int?)Session["CodPlan"];
            short? CodSub = (short?)Session["CodSub"];
            double HourLec = 0, HourLab = 0, HourSam = 0;
            if (CodPlan != null && CodSub != null) {
                if (data != null) {
                    data.podshet_hours_in_RazdelLesson();
                    SoderjRazdDiscip_DataTable SoderjRazdel = data.SoderjRazd_DataTable;
                    if (SoderjRazdel.RowCount > 0) {
                        //список семестров
                        List<string> Number_semestr = new List<string>();
                        Dictionary<int, string> List_of_OcenSredstv = new Dictionary<int, string>();
                        string CurrentSemestr = String.Empty;
                        //получение списка семестров, в которых изучается дисциплина
                        using (AcademiaDataSetTableAdapters.StudyTermTableAdapter adapter = new AcademiaDataSetTableAdapters.StudyTermTableAdapter()) {
                            AcademiaDataSet.StudyTermDataTable StudyTermTable = new AcademiaDataSet.StudyTermDataTable();
                            adapter.Fill(StudyTermTable, (int)CodPlan, (short)CodSub);
                            foreach (DataRow Row in StudyTermTable.Rows) {
                                Number_semestr.Add(Row["Course"].ToString().Trim() + "." + Row["NumTerm"].ToString().Trim());
                            }
                        }
                        //получение списка оценочных средств
                        using (AcademiaDataSetTableAdapters.OcenSredstvTableAdapter adapter = new AcademiaDataSetTableAdapters.OcenSredstvTableAdapter()) {
                            AcademiaDataSet.OcenSredstvDataTable OcenSredstvTable = new AcademiaDataSet.OcenSredstvDataTable();
                            adapter.Fill(OcenSredstvTable);
                            foreach (DataRow Row in OcenSredstvTable.Rows) {
                                List_of_OcenSredstv.Add(Convert.ToInt32(Row["IdSredstv"].ToString().Trim()), Row["NameSredstv_with_abbr"].ToString().Trim());
                            }
                        }
                        foreach (DataRow SoderjRazdelRow in SoderjRazdel) {
                            HtmlTableRow HtmlRow = new HtmlTableRow();
                            for (int j = 0; j < 6; j++) {
                                HtmlRow.Cells.Add(new HtmlTableCell());
                                HtmlRow.Cells[j].Attributes.Add("class", "GridViewCss LabelStyle");
                            }
                            //добавление вида занятия
                            HtmlInputText inputTExt = new HtmlInputText();
                            inputTExt.Attributes.Add("readonly", "true");
                            inputTExt.Value = SoderjRazdelRow["VidColumn"].ToString().Trim();
                            inputTExt.Attributes.Add("class", (inputTExt.Value == "Раздел" ? "VidColumn Razdel" : (inputTExt.Value == "Тема" ? "VidColumn Theme" : "VidColumn all")));

                            HtmlRow.Cells[0].Controls.Add(inputTExt);

                            HtmlSelect select = new HtmlSelect();
                            //добавление списков семестров в строку
                            if (SoderjRazdelRow["VidColumn"].ToString().Trim() == "Раздел" || SoderjRazdelRow["VidColumn"].ToString().Trim() == "Тема") {
                                //установка стиля для ячейки
                                if (SoderjRazdelRow["SemestrColumn"].ToString().Trim() != string.Empty) {
                                    CurrentSemestr = SoderjRazdelRow["SemestrColumn"].ToString().Trim();
                                }
                                //создание списка семестров
                                foreach (string Semestr in Number_semestr) {
                                    ListItem item = new ListItem(Semestr);
                                    if (Semestr == CurrentSemestr) {
                                        item.Selected = true;
                                    }
                                    select.Items.Add(item);
                                }
                                HtmlRow.Cells[1].Controls.Add(select);
                                //добавление обработчика событий
                                select.Attributes.Add("onchange", "SoderjRazdDiscip.Update_Semestr_in_thme_or_lec();");
                            }
                            else {
                                HtmlRow.Cells[1].InnerHtml = CurrentSemestr;
                            }
                            //добавление содержания занятий
                            HtmlTextArea htmlTextArea = new HtmlTextArea();
                            htmlTextArea.Attributes.Add("class", "TextBoxStyle SoderjLesson");
                            htmlTextArea.Value = SoderjRazdelRow["AboutColumn"].ToString();
                            HtmlRow.Cells[2].Controls.Add(htmlTextArea);
                            //добавление объема часов
                            if (SoderjRazdelRow["VidColumn"].ToString().Trim() == "Раздел" || SoderjRazdelRow["VidColumn"].ToString().Trim() == "Тема") {
                                HtmlRow.Cells[3].InnerText = SoderjRazdelRow["VolumeColumn"].ToString().Trim();
                                select = new HtmlSelect();
                                //создание списка оценочных средств
                                foreach (int OcenSredstv in List_of_OcenSredstv.Keys) {
                                    ListItem item = new ListItem(List_of_OcenSredstv[OcenSredstv], OcenSredstv.ToString());
                                    if (item.Value == SoderjRazdelRow["FormCurControlColumn"].ToString().Trim()) {
                                        item.Selected = true;
                                    }
                                    select.Items.Add(item);
                                }
                                select.Attributes.Add("class", "SelectStyle");

                                HtmlInputText inputText = new HtmlInputText();
                                inputText.Attributes.Add("class", "TextBoxOcenSredstv");
                                inputText.Value = SoderjRazdelRow["FormCurControlColumn"].ToString();
                                HtmlRow.Cells[4].Controls.Add(inputText);

                                HtmlRow.Cells[4].Controls.Add(select);

                                HtmlInputButton inputBtn = new HtmlInputButton();
                                inputBtn.Attributes.Add("class", "bttn_AddOcenSredstv");
                                inputBtn.Attributes.Add("onclick", "SoderjRazdDiscip.Add_OcenSredstv_to_TextBox();");
                                inputBtn.Value = "Добавить";

                                HtmlRow.Cells[4].Controls.Add(inputBtn);
                                HtmlRow.Cells[4].Attributes.Add("class", "GridViewCss formCurControlColumn");
                            }
                            else {
                                HtmlRow.Cells[3].InnerHtml = "<input type=\"number\" step=\"0.5\" min=\"0\" max=\"100\" " + "value=\"" + SoderjRazdelRow["VolumeColumn"].ToString().Trim().Replace(',', '.') + "\"" + " onchange=\"SoderjRazdDiscip.Update_value_of_hours_in_razdel_and_row();" + "\"/>";
                                //HtmlRow.Cells[4].InnerHtml = String.Empty;
                            }
                            HtmlRow.Cells[5].InnerHtml = "<input type=\"button\" class=\"bttn\" onclick=\"SoderjRazdDiscip.ClickOnCell_InRazdelLesson(event);SoderjRazdDiscip.del_str(event);\" value=\"Удалить\"/>";
                            Table_for_soderjDiscip.Rows.Add(HtmlRow);
                        }
                    }
                }
                using (AcademiaDataSetTableAdapters.StudyTermTableAdapter adapter = new AcademiaDataSetTableAdapters.StudyTermTableAdapter()) {
                    AcademiaDataSet.StudyTermDataTable StudyTermTable = new AcademiaDataSet.StudyTermDataTable();
                    adapter.Fill(StudyTermTable, (int)CodPlan, (short)CodSub);
                    foreach (DataRow Row in StudyTermTable.Rows) {
                        HourLab += System.Convert.ToDouble(Row["Sem"].ToString().Trim());
                        HourLec += System.Convert.ToDouble(Row["Lec"].ToString().Trim());
                        HourSam += System.Convert.ToDouble(Row["Sam"].ToString().Trim());
                    }
                }
            }
            Response.Write("<div id='HourLec' style='display:none;'>" + HourLec.ToString() + "</div>");
            Response.Write("<div id='HourSam' style='display:none;'>" + HourSam.ToString() + "</div>");
            Response.Write("<div id='HourLab' style='display:none;'>" + HourLab.ToString() + "</div>");
        }

        /// <summary>
        /// Добавленние списка семестров и списка 
        /// оценочных средств в скрытое поле для того, чтобы исключить 
        /// обращение к серверу для получения этих данных
        /// </summary>
        private void AddSemestrSelect_and_OcenSredstvSelectInClient() {
            //список, элементами которого являются оценочные средства
            HtmlSelect ocenSredstv = new HtmlSelect();
            //список, элементами которого являются семестры, в которых изучается дисциплина 
            HtmlSelect numberSemestr = new HtmlSelect();
            //добавление в список оценочных средств
            using (AcademiaDataSetTableAdapters.OcenSredstvTableAdapter adapter = new AcademiaDataSetTableAdapters.OcenSredstvTableAdapter()) {
                AcademiaDataSet.OcenSredstvDataTable OcenSredstvTable = new AcademiaDataSet.OcenSredstvDataTable();
                adapter.Fill(OcenSredstvTable);
                foreach (DataRow Row in OcenSredstvTable.Rows) {
                    ListItem item = new ListItem();
                    item.Value = Row["IdSredstv"].ToString().Trim();
                    item.Text = Row["NameSredstv_with_abbr"].ToString().Trim();
                    ocenSredstv.Items.Add(item);
                }
            }
            int? CodPlan = (int?)Session["CodPlan"];
            short? CodSub = (short?)Session["CodSub"];
            if(CodPlan != null && CodSub != null){
                //добавление в список семестров, в которых изучается дисциплина               
                using (AcademiaDataSetTableAdapters.StudyTermTableAdapter adapter = new AcademiaDataSetTableAdapters.StudyTermTableAdapter()) {
                    AcademiaDataSet.StudyTermDataTable StudyTermTable = new AcademiaDataSet.StudyTermDataTable();
                    adapter.Fill(StudyTermTable, (int)CodPlan, (short)CodSub);
                    foreach (DataRow Row in StudyTermTable.Rows) {
                        ListItem item = new ListItem();
                        item.Text = Row["Course"].ToString().Trim() + "." + Row["NumTerm"].ToString().Trim();
                        numberSemestr.Items.Add(item);
                    }
                }
            }            
            ocenSredstv.ID = "OcenSredstv";
            ocenSredstv.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            numberSemestr.ID = "NumberSemestr";
            numberSemestr.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            numberSemestr.Attributes.Add("onchange", "SoderjRazdDiscip.Update_Semestr_in_thme_or_lec()");
            this.ForSelectParams.Controls.Add(ocenSredstv);
            this.ForSelectParams.Controls.Add(numberSemestr);
        }

        protected void Button_for_pred_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/Competetion");
        }

        protected void Button_next_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/Literature");
        }
    }
}