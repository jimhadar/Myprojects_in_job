﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class FOS : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            AcademiaDataSet.CompetetionDataTable compTable;
            using (AcademiaDataSetTableAdapters.CompetetionTableAdapter compadapter = new AcademiaDataSetTableAdapters.CompetetionTableAdapter()) {
                compTable = compadapter.GetData(Session["CodSpeciality"].ToString(),
                                                (short?)Session["CodSub"],
                                                (int?)Session["CodPlan"]);
            }
            Data_for_program data = (Data_for_program)Session["data"];
            if (!Page.IsPostBack) { data.SformFosTable(); }
            int NumTheme = 1;
            TableRow htmlRow;
            foreach (DataRow Row in data.fosTable) {
                htmlRow = AddStrToHtmlTable(compTable);
                htmlRow.Cells[0].Text = NumTheme.ToString();
                htmlRow.Cells[1].Text = Row["NameTheme"].ToString();
                NumTheme++;
            }
        }
        protected void Page_Load(object sender, EventArgs e) {
            FosTable fosTable = ((Data_for_program)Session["data"]).fosTable;       
            if (Page.IsPostBack) {                
                for (int i = 0; i < fosTable.RowCount; i++ ) {
                    HtmlSelect seleclCompet = ((HtmlSelect)Table1.Rows[i + 1].Cells[2].Controls[0]);
                    fosTable.EditRow(i, 
                                    fosTable[i, "NameTheme"].ToString(), 
                                    seleclCompet.Items[seleclCompet.SelectedIndex].Text,
                                    ((HtmlTextArea)Table1.Rows[i + 1].Cells[3].Controls[0]).Value,
                                    ((HtmlTextArea)Table1.Rows[i + 1].Cells[4].Controls[0]).Value,
                                    ((HtmlTextArea)Table1.Rows[i + 1].Cells[5].Controls[0]).Value);
                }
                ((Data_for_program)Session["data"]).fosTable = fosTable;
                using (AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter adapter = new AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter()) {
                    BinaryFormatter BinFormat = new BinaryFormatter();
                    Data_for_program data = (Data_for_program)Session["data"];
                    MemoryStream MemStream = new MemoryStream();
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
            this.UpdateHtmlTable(fosTable);
        }

        private TableRow AddStrToHtmlTable(AcademiaDataSet.CompetetionDataTable compTable) {
            TableRow htmlRow = new TableRow();
            for (int i = 0; i < 6; i++) {
                htmlRow.Cells.Add(new TableCell());
                htmlRow.Cells[i].CssClass = "GridViewCss";
            }
            //Закрываемая компетенция
            htmlRow.Cells[2].Style.Add(HtmlTextWriterStyle.TextAlign, "center");            
            HtmlSelect compSelect = new HtmlSelect();            
            foreach (DataRow compRow in compTable.Rows) {
                ListItem item = new ListItem();
                item.Text = compRow["AbbrComp"].ToString();
                compSelect.Items.Add(item);
            }
            htmlRow.Cells[2].Controls.Add(compSelect);
            HtmlTextArea textArea = new HtmlTextArea();
            textArea.Attributes.Add("class", "TextBoxStyle");
            //Формируемые ЗУНы
            htmlRow.Cells[3].Controls.Add(textArea);
            //Вид и номер задания в ФОС
            textArea = new HtmlTextArea();
            textArea.Attributes.Add("class", "TextBoxStyle");
            htmlRow.Cells[4].Controls.Add(textArea);
            //Критерий оценивания
            textArea = new HtmlTextArea();
            textArea.Attributes.Add("class", "TextBoxStyle");
            htmlRow.Cells[5].Controls.Add(textArea);
            this.Table1.Rows.Add(htmlRow);
            return htmlRow;
        }

        private void UpdateHtmlTable(FosTable fosTable) {
            TableRow htmlRow;
            for (int i = 0; i < fosTable.RowCount; i++) {
                htmlRow = this.Table1.Rows[i + 1];
                HtmlSelect selectCompet = (HtmlSelect)htmlRow.Cells[2].Controls[0];
                if (fosTable[i, "NameTheme"].ToString() != "Итого по текущей аттестации") {
                    foreach (ListItem item in selectCompet.Items) {
                        if (item.Text == fosTable[i, "Competetion"].ToString()) {
                            item.Selected = true;
                            break;
                        }
                    }
                }
                else {
                    selectCompet.Visible = false;
                }
                ((HtmlTextArea)htmlRow.Cells[3].Controls[0]).Value = fosTable[i, "ZUNS"].ToString();
                ((HtmlTextArea)htmlRow.Cells[4].Controls[0]).Value = fosTable[i, "TypeandNumberInFos"].ToString();
                ((HtmlTextArea)htmlRow.Cells[5].Controls[0]).Value = fosTable[i, "Criteria"].ToString();
            }
        }
    }
}