using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Umk_and_Rpd_on_Web.AcademiaDataSetTableAdapters;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class CurrentControl : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(Page.IsPostBack && !Page.IsCallback){
                Data_for_program data = (Data_for_program)Session["data"];
                if(data != null){
                    this.UpdateCurrentControlTable(data.CurControlTable); 
                }
            }
            if(!Page.IsCallback){
                if(Session["data"] != null){
                    UpdateDataInHTMLTable(((Data_for_program)Session["data"]).CurControlTable);
                }
            }
        }

        private void UpdateCurrentControlTable(CurrentControlTable CurControl) {
            int RowCount = Convert.ToInt32(this.CurrentControlTableRowCount.Value.ToString());
            CurControl.Clear();
            for (int i = 0; i < RowCount; i++ ) {
                string[] Value_for_all_cells = new string[3];
                Value_for_all_cells[0] = Request["FormCurControl" + i.ToString()];
                Value_for_all_cells[1] = Request["NumberBalls" + i.ToString()];
                Value_for_all_cells[2] = Request["Themes" + i.ToString()];
                CurControl.AddRow(  (Value_for_all_cells[0] != null) ? Value_for_all_cells[0].ToString().Trim() : String.Empty,
                                    (Value_for_all_cells[1] != null) ? Value_for_all_cells[1].ToString().Trim() : String.Empty,
                                    (Value_for_all_cells[2] != null) ? Value_for_all_cells[2].ToString().Trim() : String.Empty);
            }
        }
       /// <summary>
       /// добавление новой строки в Html-таблицу текущего контроля успеваемости
       /// </summary>
       /// <param name="OcenSredstvTable">список оценочных средств</param>
       /// <param name="ListTheme">список с названиями всех изучаемых в дисциплине тем</param>
        private void AddStrToHtmlTable(AcademiaDataSet.OcenSredstvDataTable OcenSredstvTable, List<string[]> ListTheme) {
            HtmlSelect OcenSredstvSelect = new HtmlSelect();
            foreach (DataRow Row in OcenSredstvTable.Rows) {
                ListItem item = new ListItem();
                item.Value = Row["AbbrSredstv"].ToString().Trim();
                item.Text = Row["NameSredstv_with_abbr"].ToString().Trim();
                OcenSredstvSelect.Items.Add(item);
            }
            HtmlSelect ThemeSelect = new HtmlSelect();
            Data_for_program data = ((Data_for_program)Session["data"]);
            if (data != null) {
                foreach (string[] str in ListTheme) {
                    ListItem item = new ListItem();
                    item.Value = str[0].Trim();
                    item.Text = str[1].Trim();
                    ThemeSelect.Items.Add(item);
                }
                CurrentControlTable CurrentControl = data.CurControlTable;
                //таблица пуста из состояния сеанса, в THMLTаble добавляем только одну пустую строку
                HtmlTableRow row = new HtmlTableRow();
                for (int i = 0; i < 4; i++) {
                    row.Cells.Add(new HtmlTableCell());
                    row.Cells[i].Attributes.Add("class", "GridViewCss");
                }
                AddCellWithFormCurControl_or_ListOfTheme(row.Cells[0], OcenSredstvSelect);
                row.Cells[0].Attributes.Add("class", "GridViewCss");

                HtmlTextArea TextArea = new HtmlTextArea();
                TextArea.Attributes.Add("class", "TextBoxStyle");
                TextArea.Attributes.Add("oninput", "CurrentControl.AddRowInEnd();");
                row.Cells[1].Attributes.Add("class", "GridViewCss");
                row.Cells[1].Controls.Add(TextArea);
                               
                AddCellWithFormCurControl_or_ListOfTheme(row.Cells[2], ThemeSelect);
                row.Cells[2].Attributes.Add("class", "GridViewCss");

                //если в HTML таблице уже есть добавленная строка и таблица из состояния сеанса не пуста, то добавляем ячейку с кнопкой "Удалить"
                row.Cells[3].InnerHtml = "<input type=\"button\" class=\"bttn\" onclick=\"CurrentControl.ClickOnCell(event);CurrentControl.del_str(event);\" value=\"Удалить\"/>";
                row.Cells[3].Attributes.Add("class", "GridViewCss");

                CurrentControlHtmlTable.Rows.Add(row);
            }
        }
        /// <summary>
        /// добавление в ячейку td трех полей: TextBox, select, button,
        /// select зависит от того, какие данные будет содержать ячейка: список форм текущего контроля успеваемости или список тем по дисциплине
        /// </summary>
        /// <param name="cell">ячейка,в которую добавляется список тем</param>
        /// <param name="Select">список форм текущего контроля успеваемости/список тем по дисциплине</param>
        private void AddCellWithFormCurControl_or_ListOfTheme(HtmlTableCell cell, HtmlSelect Select) {
            HtmlInputText inputText = new HtmlInputText();
            inputText.Attributes.Add("class", "TextBoxOcenSredstv");
            cell.Controls.Add(inputText);

            Select.Attributes.Add("onchange", "CurrentControl.AddRowInEnd();");
            Select.Attributes.Add("class", "SelectStyle");
            cell.Controls.Add(Select);

            HtmlInputButton inputBtn = new HtmlInputButton();
            inputBtn.Attributes.Add("class", "bttn_AddOcenSredstv");
            inputBtn.Attributes.Add("onclick", "CurrentControl.AddTheme_or_ForCurControlToTextBox(event);");
            inputBtn.Value = "Добавить";
            cell.Controls.Add(inputBtn);

            cell.Attributes.Add("class", "");
        }

        /// <summary>
        /// перерисовка Html-таблицы текущего контроля успеваемости данными из таблицы, хранящейся в состоянии сеанса
        /// </summary>
        /// <param name="CurrentControlTable">таблица из состояния сеанса, из которой берется информация для заполнения</param>
        private void UpdateDataInHTMLTable(CurrentControlTable CurrentControlTable) {
            using (OcenSredstvTableAdapter OcenSredstvAdapter = new OcenSredstvTableAdapter()) {
                //для списка оценочных средств
                AcademiaDataSet.OcenSredstvDataTable OcenSredstvTable = new AcademiaDataSet.OcenSredstvDataTable();
                OcenSredstvAdapter.Fill(OcenSredstvTable);
                //для списка тем дисциплины
                List<string[]> ListTheme = new List<string[]>();
                Data_for_program data = ((Data_for_program)Session["data"]);
                SoderjRazdDiscip_DataTable SoderjRazdel = data.SoderjRazd_DataTable;
                int NumRazdel = 0;
                int NumTheme = 0;
                foreach (DataRow Row in SoderjRazdel) {
                    if (Row["VidColumn"].ToString() == "Раздел") {
                        NumRazdel++;
                        NumTheme = 0;
                    }
                    else if (Row["VidColumn"].ToString() == "Тема") {
                        NumTheme++;
                        ListTheme.Add(new string[2]{"Тема " + NumRazdel.ToString() + "." + NumTheme.ToString() + ".", Row["AboutColumn"].ToString()});
                    }
                }
                foreach (DataRow Row in CurrentControlTable) {
                    AddStrToHtmlTable(OcenSredstvTable, ListTheme);
                    HtmlTableRow HtmlRow = CurrentControlHtmlTable.Rows[CurrentControlHtmlTable.Rows.Count - 1];
                    ((HtmlInputText)HtmlRow.Cells[0].Controls[0]).Value = Row["FormCurControlColumn"].ToString().Trim();
                    ((HtmlTextArea)HtmlRow.Cells[1].Controls[0]).Value = Row["NumberBallColumn"].ToString();
                    ((HtmlInputText)HtmlRow.Cells[2].Controls[0]).Value = Row["ThemeColumn"].ToString().Trim();
                }
                if(CurrentControlTable.RowCount == 0){
                    AddStrToHtmlTable(OcenSredstvTable, ListTheme);
                }
            }
        }

        protected void Button_next_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/RPD");
        }

        protected void Button_for_pred_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/SoderjRazdDiscip");
        }
    }
}