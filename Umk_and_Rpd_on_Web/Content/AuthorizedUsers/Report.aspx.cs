using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class Report : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            this.CreateTableForReportSpec();
        }

        private void CreateTableForReportSpec(){
            using (AcademiaDataSetTableAdapters.Umk_rpd_reportTableAdapter reportSpeciality = new AcademiaDataSetTableAdapters.Umk_rpd_reportTableAdapter()) {
                using (AcademiaDataSetTableAdapters.SpecialityTableAdapter Speciality = new AcademiaDataSetTableAdapters.SpecialityTableAdapter()) {
                    DataTable tmpReportTable = reportSpeciality.GetData(1);
                    DataTable tmpSpeciality = Speciality.GetData(10);
                    //для строки "Итого"
                    double? itogo_zap = 0;
                    double? itogo_all = 0;
                    HtmlTableRow rowForReportTable;
                    foreach (DataRow tmpRowSpeciality in tmpSpeciality.Rows) {
                        DataRow[] tmp = tmpReportTable.Select("CodForReport = " + tmpRowSpeciality["CodSpeciality"]);
                        if (tmp.Length != 0) {
                            //TableRow rowForReportTable = new TableRow();
                            rowForReportTable = new HtmlTableRow();
                            for (int i = 0; i < 5; i++) {
                                rowForReportTable.Cells.Add(new HtmlTableCell());
                                rowForReportTable.Cells[i].Attributes.Add("class", "GridViewCss");
                                rowForReportTable.Cells[i].InnerHtml = string.Empty;
                            }
                            rowForReportTable.Cells[0].InnerHtml = tmpRowSpeciality["Speciality"].ToString().Trim();
                            foreach (DataRow row in tmp) {
                                rowForReportTable.Cells[1].InnerHtml += (row["NamePlan"] != null ? row["NamePlan"].ToString().Trim() : string.Empty) + "<br>";
                                rowForReportTable.Cells[2].InnerHtml += (row["AllCountSubs"] != null ? row["AllCountSubs"].ToString().Trim() : string.Empty) + "<br>";
                                if(row["AllCountSubs"] != null){
                                    itogo_all += Convert.ToInt32(row["AllCountSubs"]);
                                }
                                rowForReportTable.Cells[3].InnerHtml += (row["CountzapSubs"] != null ? row["CountzapSubs"].ToString().Trim() : string.Empty) + "<br>";
                                if (row["CountzapSubs"] != null) {
                                    itogo_zap += Convert.ToInt32(row["CountzapSubs"]);
                                }
                                rowForReportTable.Cells[4].InnerHtml += (row["PercentZap"] != null ? row["PercentZap"].ToString().Trim() : string.Empty) + "<br>";
                            }
                            this.ReportOnSpecialityTable.Rows.Add(rowForReportTable);
                        }
                    }
                    rowForReportTable = new HtmlTableRow();
                    for (int i = 0; i < 5; i++) {
                        rowForReportTable.Cells.Add(new HtmlTableCell());
                        rowForReportTable.Cells[i].Attributes.Add("class", "GridViewCss");
                        rowForReportTable.Cells[i].InnerHtml = string.Empty;
                    }
                    rowForReportTable.Cells[0].Style.Add(HtmlTextWriterStyle.FontWeight, "700");
                    rowForReportTable.Cells[0].InnerHtml = "Итого";                                        
                    rowForReportTable.Cells[2].InnerHtml = itogo_all.ToString();
                    rowForReportTable.Cells[3].InnerHtml = itogo_zap.ToString();
                    rowForReportTable.Cells[4].InnerHtml = (Math.Round((double)itogo_zap / (double)itogo_all * 100)).ToString();
                    this.ReportOnSpecialityTable.Rows.Add(rowForReportTable);
                }
            }
        }

        private void CreateTableForREportSubs() {
            DataTable Subs_With_CodPlan_Table;
            byte? CodKaf;
            if(this.WriteSubsOnKafCheckBox.Checked){
                CodKaf = Convert.ToByte(this.DropDownList1.SelectedValue);
            }
            else {
                CodKaf = null;
            }
            using (AcademiaDataSetTableAdapters.ReportOnSubsTableAdapter report = new AcademiaDataSetTableAdapters.ReportOnSubsTableAdapter()) {
                Subs_With_CodPlan_Table = (this.RadioButtonList1.SelectedIndex == -1 || this.RadioButtonList1.SelectedIndex == 0) ? report.GetData(2015, 0, CodKaf) : 
                                          (this.RadioButtonList1.SelectedIndex == 1 ? report.GetDataEmptySubs(2015, 0, CodKaf) : report.GetDataNotEmpty(2015, 0, CodKaf));
                foreach(ListItem item in this.DropDownList1.Items){
                    DataRow[] tmpRowKafSubs = Subs_With_CodPlan_Table.Select("CodKaf = " + item.Value);
                    if (tmpRowKafSubs.Length != 0) {
                        HtmlTableRow htmlRow = new HtmlTableRow();
                        htmlRow.Cells.Add(new HtmlTableCell());
                        htmlRow.Cells[0].Attributes.Add("class", "GridViewCss HeaderGridView KafReportSubs");
                        htmlRow.Cells[0].Style.Add(HtmlTextWriterStyle.Width, "100%");
                        htmlRow.Cells[0].Style.Add(HtmlTextWriterStyle.FontWeight, "700");
                        htmlRow.Cells[0].Attributes.Add("colspan", "3");
                        htmlRow.Cells[0].InnerText = "Кафедра " + item.Text.Trim().ToLower();
                        this.ReportOnSubsEmpty_or_notEmpty.Rows.Add(htmlRow);
                        int numSub = 1;
                        foreach (DataRow row in tmpRowKafSubs) {
                            htmlRow = new HtmlTableRow();
                            for (int i = 0; i < 3; i++ ) {
                                htmlRow.Cells.Add(new HtmlTableCell());
                                htmlRow.Cells[i].Attributes.Add("class", "GridViewCss");
                            }
                            htmlRow.Cells[0].InnerText = (numSub++).ToString();
                            htmlRow.Cells[1].InnerText = row["NameSub"].ToString().Trim();
                            htmlRow.Cells[2].InnerText = row["NamePlan"].ToString().Trim();
                            this.ReportOnSubsEmpty_or_notEmpty.Rows.Add(htmlRow);
                        }
                    }
                }
            }
        }

        protected void Button_report_subs_Click(object sender, EventArgs e) {
            CreateTableForREportSubs();            
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e) {
            Session["TypeQueryForReportSub"] = this.RadioButtonList1.SelectedIndex;
        }
    }

    
}