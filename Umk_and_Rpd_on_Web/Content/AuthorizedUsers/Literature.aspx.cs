using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class Literature : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Page.IsPostBack && !Page.IsCallback && Request["UpdateTmpContents"] == null) {
                Data_for_program data = ((Data_for_program)Session["data"]);
                if (data != null) {
                    if (this.RowCountLiterTable.Value == String.Empty) { this.RowCountLiterTable.Value = data.LiteratureTable.RowCount.ToString(); }
                    UpdateLiteratureTable(data.LiteratureTable);
                }
            }
            if (!Page.IsPostBack && !Page.IsCallback && Request["UpdateTmpContents"] == null) {
                Data_for_program data = (Data_for_program)Session["data"];
                if (data != null) {
                    LiteratureDataTable LiteratureTable = data.LiteratureTable;
                    ViewTable_for_Literature_InClient(LiteratureTable);
                    if (LiteratureTable.RowCount == 0) {
                        LiteratureTable.AddRow("Основная", "");
                        AddStrToHtmlTableLiterature();
                    }
                }
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
            TypeLiter.Attributes.Add("onchange", "Literature.AddRowInEnd_for_literature();");
            TypeLiter.Items.AddRange(new ListItem[] { new ListItem("Основная"), new ListItem("Дополнительная"), new ListItem("Электронный ресурс") });
            TypeLiter.Attributes.Add("class", "");
            Row.Cells[0].Controls.Add(TypeLiter);

            HtmlInputText inputText = new HtmlInputText();
            inputText.Value = string.Empty;
            inputText.Attributes.Add("class", "textBox_AboutLiter");
            inputText.Attributes.Add("oninput", "Literature.AddRowInEnd_for_literature();");
            Row.Cells[1].Controls.Add(inputText);

            HtmlInputButton btn = new HtmlInputButton();
            btn.Attributes.Add("class", "bttn");
            btn.Value = "Найти";
            btn.Attributes.Add("onclick", "Literature.AddRowInEnd_for_literature();Literature.ShowPopUp_for_find_liter('block');");
            Row.Cells[2].Controls.Add(btn);

            this.Table_for_Literature.Rows.Add(Row);
        }

        /// <summary>
        /// отрисовка таблицы с списком литературы
        /// </summary>
        private void ViewTable_for_Literature_InClient(LiteratureDataTable Table) {
            foreach (DataRow Row in Table) {
                AddStrToHtmlTableLiterature();
                HtmlTableRow HtmlRow = Table_for_Literature.Rows[Table_for_Literature.Rows.Count - 1];
                HtmlSelect select = (HtmlSelect)HtmlRow.Cells[0].Controls[0];
                foreach (ListItem Item in select.Items) {
                    if (Item.Value.ToString() == Row["Type_liter"].ToString()) {
                        Item.Selected = true;
                        break;
                    }
                }
                ((HtmlInputText)HtmlRow.Cells[1].Controls[0]).Value = Row["AboutLiter"].ToString();
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

        protected void Button_for_FindLiter_Click(object sender, EventArgs e) {
            if (this.TextBox_NameBook.Text == String.Empty &&
                this.TextBox_Author.Text == String.Empty &&
                this.TextBox_KeyWord.Text == String.Empty &&
                this.TextBox_Year.Text == String.Empty) {
                return;
            }
            DataTable TempTable = new DataTable();
            using (AcademiaDataSetTableAdapters.Lib_BookTableAdapter LibBookAdapter = new AcademiaDataSetTableAdapters.Lib_BookTableAdapter()) {
                TempTable = LibBookAdapter.GetData(TextBox_NameBook.Text, TextBox_Author.Text, TextBox_Year.Text, TextBox_KeyWord.Text, (DateTime.Now.Year - 15).ToString());
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
                htmlRow.Cells[htmlRow.Cells.Count - 1].InnerHtml = "<input type=\"button\" class=\"bttn\" value=\"Выбрать\" onclick='Literature.AddLiterToTextBox(event);'/>";
                htmlRow.Attributes.Add("onmouseover", "Literature.BackgroundColor_SelectStr_inFindLiter(event);");
                htmlRow.Attributes.Add("onmouseout", "Literature.BackGround_OutStr_inFindLiter(event);");
                this.Table_for_liter.Rows.Add(htmlRow);
            }
        }

        protected void Button_next_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/CurrentControl");
        }

        protected void Button_for_pred_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/SoderjRazdDiscip");
        }
    } 
}