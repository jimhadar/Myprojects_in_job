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
    public partial class SoderjRazdDiscip : System.Web.UI.Page, ICallbackEventHandler {
        protected void Page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack && !Page.IsCallback && Request["UpdateTmpContents"] == null) {
                Data_for_program data = ((Data_for_program)Session["data"]);
                if (data != null) {
                    if (this.RowCountSoderjDiscip.Value == String.Empty) { this.RowCountSoderjDiscip.Value = data.SoderjRazd_DataTable.RowCount.ToString(); }
                    //if (this.RowCountLiterTable.Value == String.Empty) { this.RowCountLiterTable.Value = data.LiteratureTable.RowCount.ToString(); }
                    UpdateSoderjRazdelDiscip_table(data.SoderjRazd_DataTable, this.Request, Convert.ToInt32(this.RowCountSoderjDiscip.Value.ToString()));
                    //UpdateLiteratureTable(data.LiteratureTable);
                }
            }
            if (!Page.IsPostBack && !Page.IsCallback && Request["UpdateTmpContents"] == null) { ViewSoderjRazdInClient(); }
            if (!Page.IsPostBack || Page.IsCallback && Request["UpdateTmpContents"] == null) {
                string callbackref_razdel = Page.ClientScript.GetCallbackEventReference(this, "document.getElementById(\"AddRazdel_Btn\").id", "SoderjRazdDiscip.Get_Inf_for_Razdel_ClientCallBack", "null", true);
                AddRazdel_Btn.Attributes["onclick"] = "SoderjRazdDiscip.AddRazdelRow();" + callbackref_razdel + ";";
                string callbackref_theme = Page.ClientScript.GetCallbackEventReference(this, "document.getElementById(\"AddTheme_Btn\").id", "SoderjRazdDiscip.Get_Inf_for_Razdel_ClientCallBack", "null", true);
                AddTheme_Btn.Attributes["onclick"] = "SoderjRazdDiscip.AddThemeRow();" + callbackref_theme + ";";
                //если произошел обратный запрос и произошла частичная отправка формы
                //тогда обновляем данные в классе таблицы SoderjRazdDiscip              
            }
            //if (!Page.IsPostBack && !Page.IsCallback && Request["UpdateTmpContents"] == null) {
            //    Data_for_program data = (Data_for_program)Session["data"];
            //    if (data != null) {
            //        LiteratureDataTable LiteratureTable = data.LiteratureTable;
            //        ViewTable_for_Literature_InClient(LiteratureTable);
            //        if (LiteratureTable.RowCount == 0) {
            //            LiteratureTable.AddRow("Основная", "");
            //            AddStrToHtmlTableLiterature();
            //        }
            //    }                
            //}
            Page.Title = "Содержание разделов дисциплины";
        }

        protected void Initialize_Table_for_SoderjRazdDiscip() {
        }
        protected void Button1_Click(object sender, EventArgs e) {
            //Response.Redirect("Competetion.aspx");
        }
        #region  Для Ajax
        /*
         
        */
        int CodPlan;
        short CodSub;
        private string eventArgument;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgument"></param>
        public void RaiseCallbackEvent(string eventArgument) {
            this.eventArgument = eventArgument;
        }
        /// <summary>
        /// Получаем из состояния сеанса значения всех основных переменных
        /// </summary>
        private void GetValues() {
            CodPlan = System.Convert.ToInt32(Session["CodPlan"].ToString().Trim());
            CodSub = System.Convert.ToInt16(Session["CodSub"].ToString().Trim());
        }
        /// <summary>
        /// 
        /// </summary>
        delegate void Ocensredstv();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetCallbackResult() {
            GetValues();
            StringBuilder Number_semestr = new StringBuilder();
            Ocensredstv OcenSredstv = () => {
                //добавление в список оценочных средств
                using (AcademiaDataSetTableAdapters.OcenSredstvTableAdapter adapter = new AcademiaDataSetTableAdapters.OcenSredstvTableAdapter()) {
                    AcademiaDataSet.OcenSredstvDataTable OcenSredstvTable = new AcademiaDataSet.OcenSredstvDataTable();
                    adapter.Fill(OcenSredstvTable);
                    foreach (DataRow Row in OcenSredstvTable.Rows) {
                        //разделение знаком | ID и названия оценочного средства
                        Number_semestr.Append(Row["IdSredstv"].ToString().Trim() + "|" + Row["NameSredstv_with_abbr"].ToString().Trim());
                        //Разделитель для разных оценочных средств
                        Number_semestr.Append("||");
                    }
                }
            };
            //если в таблицу добавляется раздел
            if (this.eventArgument == "AddRazdel_Btn") {
                //список, элементами которого являются семестры, в которых изучается дисциплина                
                using (AcademiaDataSetTableAdapters.StudyTermTableAdapter adapter = new AcademiaDataSetTableAdapters.StudyTermTableAdapter()) {
                    AcademiaDataSet.StudyTermDataTable StudyTermTable = new AcademiaDataSet.StudyTermDataTable();
                    adapter.Fill(StudyTermTable, CodPlan, CodSub);
                    foreach (DataRow Row in StudyTermTable.Rows) {
                        Number_semestr.Append(Row["Course"].ToString().Trim() + "." + Row["NumTerm"].ToString().Trim());
                        //разделитель для разных элементов
                        Number_semestr.Append("|");
                    }
                    Number_semestr.Append("}{");
                    //разделитель для разных данных: семестров в левой части и списка оценочных средств в правой части
                    OcenSredstv();
                    Number_semestr.Append("}{");
                    double HourLec = 0, HourLab = 0, HourSam = 0;
                    foreach (DataRow Row in StudyTermTable.Rows) {
                        HourLab += System.Convert.ToDouble(Row["Sem"].ToString().Trim());
                        HourLec += System.Convert.ToDouble(Row["Lec"].ToString().Trim());
                        HourSam += System.Convert.ToDouble(Row["Sam"].ToString().Trim());
                    }
                    Number_semestr.Append(HourLec.ToString().Trim() + "||" + HourLab.ToString().Trim() + "||" + HourSam.ToString().Trim());
                }
            }
            else {
                OcenSredstv();
            }
            return Number_semestr.ToString();
        }
        #endregion
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
            if (data != null) {
                data.podshet_hours_in_RazdelLesson();
                this.ForHourLec.Value = data.HourLec.ToString();
                this.ForHourLab.Value = data.HourLab.ToString();
                this.ForHourSam.Value = data.HourSam.ToString();
                SoderjRazdDiscip_DataTable SoderjRazdel = data.SoderjRazd_DataTable;
                if (SoderjRazdel.RowCount > 0) {
                    GetValues();
                    //список семестров
                    List<string> Number_semestr = new List<string>();
                    Dictionary<int, string> List_of_OcenSredstv = new Dictionary<int, string>();
                    string CurrentSemestr = String.Empty;
                    //получение списка семестров, в которых изучается дисциплина
                    using (AcademiaDataSetTableAdapters.StudyTermTableAdapter adapter = new AcademiaDataSetTableAdapters.StudyTermTableAdapter()) {
                        AcademiaDataSet.StudyTermDataTable StudyTermTable = new AcademiaDataSet.StudyTermDataTable();
                        adapter.Fill(StudyTermTable, CodPlan, CodSub);
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
                        if (SoderjRazdelRow["VidColumn"].ToString().Trim() == "Раздел") {
                            //установка стиля для ячейки
                            CurrentSemestr = SoderjRazdelRow["SemestrColumn"].ToString().Trim();
                            //создание списка семестров
                            foreach (string Semestr in Number_semestr) {
                                ListItem item = new ListItem(Semestr);
                                if (Semestr == SoderjRazdelRow["SemestrColumn"].ToString().Trim()) {
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
                GetValues();
                adapter.Fill(StudyTermTable, CodPlan, CodSub);
                double HourLec = 0, HourLab = 0, HourSam = 0;
                foreach (DataRow Row in StudyTermTable.Rows) {
                    HourLab += System.Convert.ToDouble(Row["Sem"].ToString().Trim());
                    HourLec += System.Convert.ToDouble(Row["Lec"].ToString().Trim());
                    HourSam += System.Convert.ToDouble(Row["Sam"].ToString().Trim());
                }
                Response.Write("<div id='HourLec' style='display:none'>" + HourLec.ToString().Trim() + "</div>");
                Response.Write("<div id='HourLab' style='display:none'>" + HourLab.ToString().Trim() + "</div>");
                Response.Write("<div id='HourSam' style='display:none'>" + HourSam.ToString().Trim() + "</div>");
            }
        }
        /// <summary>
        /// обновление таблицы с списком литературы, хранящейся в состоянии сеанса, данными пришедшими с клиентра в результате обратной отправки 
        /// </summary>
        /// <param name="LiterTable"></param>
        private void UpdateLiteratureTable(LiteratureDataTable LiterTable) {
            int RowCount = Convert.ToInt32(this.RowCountLiterTable.Value.ToString());
            LiterTable.Clear();
            for (int i = 0; i < RowCount; i++) {
                LiterTable.AddRow(Request["TypeLiter" + (i + 1).ToString()], Request["AboutLiter" + (i + 1).ToString()]);
            }
        }

        private void AddStrToHtmlTableLiterature() {
            HtmlTableRow Row = new HtmlTableRow();
            for (int i = 0; i < 3; i++) {
                Row.Cells.Add(new HtmlTableCell());
                Row.Cells[i].Attributes.Add("class", "GridViewCss");
            }

            Row.Cells[0].Attributes.Add("class", "GridViewCss TypeLiterColumn");
            Row.Cells[2].Attributes.Add("class", "GridViewCss FindLiterBtnColumn");

            HtmlSelect TypeLiter = new HtmlSelect();
            TypeLiter.Attributes.Add("onchange", "SoderjRazdDiscip.AddRowInEnd_for_literature();");
            TypeLiter.Items.AddRange(new ListItem[] { new ListItem("Основная"), new ListItem("Дополнительная"), new ListItem("Электронный ресурс") });
            TypeLiter.Attributes.Add("class", "");
            Row.Cells[0].Controls.Add(TypeLiter);

            HtmlInputText inputText = new HtmlInputText();
            inputText.Value = string.Empty;
            inputText.Attributes.Add("class", "textBox_AboutLiter");
            inputText.Attributes.Add("oninput", "SoderjRazdDiscip.AddRowInEnd_for_literature();");
            Row.Cells[1].Controls.Add(inputText);

            HtmlInputButton btn = new HtmlInputButton();
            btn.Attributes.Add("class", "bttn");
            btn.Value = "Найти";
            btn.Attributes.Add("onclick", "SoderjRazdDiscip.AddRowInEnd_for_literature();SoderjRazdDiscip.ShowPopUp_for_find_liter('block');");
            Row.Cells[2].Controls.Add(btn);

            //this.Table_for_Literature.Rows.Add(Row);
        }

        /// <summary>
        /// отрисовка таблицы с списком литературы
        /// </summary>
        private void ViewTable_for_Literature_InClient(LiteratureDataTable Table) {
            //foreach (DataRow Row in Table) {
            //    AddStrToHtmlTableLiterature();
            //    HtmlTableRow HtmlRow = Table_for_Literature.Rows[Table_for_Literature.Rows.Count - 1];
            //    HtmlSelect select = (HtmlSelect)HtmlRow.Cells[0].Controls[0];
            //    foreach (ListItem Item in select.Items) {
            //        if (Item.Value.ToString() == Row["Type_liter"].ToString()) {
            //            Item.Selected = true;
            //            break;
            //        }
            //    }
            //    ((HtmlInputText)HtmlRow.Cells[1].Controls[0]).Value = Row["AboutLiter"].ToString();
            //}
        }

        protected void Button_for_pred_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/Competetion");
        }

        protected void Button_next_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/Literature");
        }

        protected void Button_for_FindLiter_Click(object sender, EventArgs e) {
            if (this.TextBox_NameBook.Text == String.Empty &&
                this.TextBox_Author.Text == String.Empty &&
                this.TextBox_KeyWord.Text == String.Empty &&
                this.TextBox_Year.Text == String.Empty) {
                return;
            }
            DataTable TempTable = new DataTable();
            using (AcademiaDataSetTableAdapters.Lib_BookTableAdapter LibBookAdapter = new Lib_BookTableAdapter()) {
                LibBookAdapter.Fill(new AcademiaDataSet.Lib_BookDataTable(), TextBox_NameBook.Text, TextBox_Author.Text, TextBox_Year.Text, TextBox_KeyWord.Text);
                TempTable = LibBookAdapter.GetData(TextBox_NameBook.Text, TextBox_Author.Text, TextBox_Year.Text, TextBox_KeyWord.Text);
            }
            while (this.Table_for_liter.Rows.Count != 1) {
                this.Table_for_liter.Rows.RemoveAt(this.Table_for_liter.Rows.Count - 1);
            }
            foreach (DataRow Row in TempTable.Rows) {
                HtmlTableRow htmlRow = new HtmlTableRow();
                for (int i = 0; i < 5; i++) {
                    htmlRow.Cells.Add(new HtmlTableCell());
                    htmlRow.Cells[i].Attributes.Add("class", "GridViewCss");
                    htmlRow.Cells[i].InnerText = Row[i + 1].ToString();
                }
                htmlRow.Cells[0].Attributes.Add("class", "nameBookColumn GridViewCss");
                htmlRow.Cells[1].Attributes.Add("class", "AuthorColumn GridViewCss");
                htmlRow.Cells[3].Attributes.Add("class", "NameIzdColumn GridViewCss");
                htmlRow.Cells.Add(new HtmlTableCell());
                htmlRow.Cells[htmlRow.Cells.Count - 1].Attributes.Add("class", "GridViewCss");
                htmlRow.Cells[htmlRow.Cells.Count - 1].InnerHtml = "<input type=\"button\" class=\"bttn\" value=\"Выбрать\" onclick='SoderjRazdDiscip.AddLiterToTextBox(event);'/>";
                htmlRow.Attributes.Add("onmouseover", "SoderjRazdDiscip.BackgroundColor_SelectStr_inFindLiter(event);");
                htmlRow.Attributes.Add("onmouseout", "SoderjRazdDiscip.BackGround_OutStr_inFindLiter(event);");
                this.Table_for_liter.Rows.Add(htmlRow);
            }
        }
    }
}