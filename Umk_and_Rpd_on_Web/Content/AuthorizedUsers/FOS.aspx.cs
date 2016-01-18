using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class FOS : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            AcademiaDataSet.CompetetionDataTable compTable;
            using (AcademiaDataSetTableAdapters.CompetetionTableAdapter compadapter = new AcademiaDataSetTableAdapters.CompetetionTableAdapter()) {
                compTable = compadapter.GetData(Session["CodSpeciality"].ToString(),
                                                (short?)Session["CodSub"],
                                                (int?)Session["CodPlan"]);
            }
            if (!Page.IsPostBack) {
                //Data_for_program data = (Data_for_program)Session["data"];
                //SoderjRazdDiscip_DataTable SoderjDiscip = data.SoderjRazd_DataTable;
                //if(data.fosTable.RowCount == 0){
                //    FosTable fosTable = data.fosTable;
                //    foreach(DataRow Row in SoderjDiscip){
                //        if (Row["VidColumn"].ToString() == "Тема") {
                //            fosTable.AddRow(Row["VidColumn"].ToString(), string.Empty, string.Empty, Row["FormCurControlColumn"].ToString(), string.Empty);
                //        }
                //    }
                //}
                //else {
                //    FosTable fosTable = data.fosTable;
                //    DataRow[] themeRows = SoderjDiscip.Select("VidColumn ==" + "Тема");
                //    foreach(DataRow Row in SoderjDiscip){
                //        int CurRowInTableFos = 0;
                //        if(Row["VidColumn"].ToString() == "Тема"){
                //            int numRow = fosTable.FindRowByNameTheme(Row["AboutColumn"].ToString());
                //            if(numRow < 0){
                //                fosTable.InsertRow(++CurRowInTableFos, Row["AboutColumn"].ToString(), string.Empty, string.Empty, Row["FormCurControlColumn"].ToString(), string.Empty);
                //            }
                //        }
                //    }
                //    for(int i = 0; i < fosTable){

                //    }
                //}
                //else {
                //    int NumTheme = 1;
                //    HtmlTableRow htmlRow;
                //    foreach (DataRow Row in SoderjDiscip) {
                //        if(Row["VidColumn"].ToString().Trim() == "Тема"){
                //            htmlRow = new HtmlTableRow();
                //            for (int i = 0; i < 6; i++) {
                //                htmlRow.Cells.Add(new HtmlTableCell());
                //            }
                //            htmlRow.Cells[0].InnerText = NumTheme.ToString();
                //            //название темы
                //            htmlRow.Cells[1].InnerText = Row["AboutColumn"].ToString();
                //            //Закрываемая компетенция
                //            HtmlSelect compSelect = new HtmlSelect();
                //            foreach(DataRow compRow in compTable.Rows){
                //                ListItem item = new ListItem();
                //                item.Text = compRow["AbbrComp"].ToString();
                //                compSelect.Items.Add(item);
                //            }
                //            htmlRow.Cells[2].Controls.Add(compSelect);
                //            //Формируемые ЗУНы
                //            htmlRow.Cells[3].Controls.Add(new HtmlTextArea());
                //            //Вид и номер задания в ФОС
                //            htmlRow.Cells[4].Controls.Add(new HtmlTextArea());                            
                //            //Критерий оценивания
                //            htmlRow.Cells[5].Controls.Add(new HtmlTextArea());                            
                //            NumTheme++;
                //        }
                //    }
                //    htmlRow = new HtmlTableRow();
                //    HtmlTableRow htmlRow1 = new HtmlTableRow();
                //    for (int i = 0; i < 6; i++ ) {
                //        htmlRow.Cells.Add(new HtmlTableCell());
                //        htmlRow1.Cells.Add(new HtmlTableCell());
                //    }
                //    htmlRow.Cells[0].InnerText = (NumTheme + 1).ToString();
                //    htmlRow1.Cells[0].InnerText = (NumTheme + 2).ToString();
                //    htmlRow.Cells[1].InnerText = "Итого по текущей аттестации";
                //    htmlRow1.Cells[1].InnerText = "Промежуточная аттестация";
                //    for (int i = 2; i < 6; i++ ) {
                //        htmlRow.Cells[i].Controls.Add(new HtmlTextArea());
                //        htmlRow1.Cells[i].Controls.Add(new HtmlTextArea());
                //    }
                //}
            }
        }               
    }
}