using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Umk_and_Rpd_on_Web;
using System.Data;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class FindRpdForm : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!Page.IsPostBack){
                Load_DropDownList_for_uch_year();
                this.PrepodTextBox.Text = String.Empty;
            }
            Page.Title = "Поиск РПД и УМК";
        }
        /// <summary>
        /// Заполнение DropDownList_for_uch_year данными
        /// </summary>
        protected void Load_DropDownList_for_uch_year() {
            DropDownList_StudyYear.Items.Clear();
            int NowYear = DateTime.Now.Year;
            int[] mas_year = new int[6];
            for (int i = 0; i < 6; i++) {
                mas_year[i] = NowYear - i + 3;
            }
            for (int i = 0; i < 6; i++) {
                ListItem item = new ListItem();
                item.Text = mas_year[i].ToString() + @" / " + (mas_year[i] + 1).ToString();
                item.Value = mas_year[i].ToString();
                this.DropDownList_StudyYear.Items.Add(item);
            }
            DropDownList_StudyYear.SelectedValue = (DateTime.Now.Month <= 8) ? (DateTime.Now.Year - 1).ToString() : DateTime.Now.Year.ToString();
        }

        protected void Button_poisk_Click(object sender, EventArgs e) {
            using(AcademiaDataSetTableAdapters.UMK_and_RPD_with_opisanieTableAdapter adapter = new AcademiaDataSetTableAdapters.UMK_and_RPD_with_opisanieTableAdapter()){
                while(Table_find_rpd.Rows.Count != 1){
                    Table_find_rpd.Rows.RemoveAt(Table_find_rpd.Rows.Count - 1);
                }
                byte?   CodFac = null,
                        CodKaf = null,
                        CodTypeEdu = null,
                        CodFormStudy = null;
                short? Year = null;
                int? CodPlan = null;
                string  CodSpeciality = null,
                        PrepodWhoEdit = null;
                if(this.Checkbox_StudyYear.Checked){
                    Year = Convert.ToInt16(this.DropDownList_StudyYear.SelectedValue);
                }
                if(this.CheckBox_FacDiscip.Checked){
                    CodFac = Convert.ToByte(this.DropDownList_facPrep.SelectedValue);
                }
                if(this.CheckBoc_KafDiscip.Checked){
                    CodKaf = Convert.ToByte(this.DropDownList_kafs.SelectedValue);
                }
                if (this.Checkbox_Prepod.Checked) {
                    PrepodWhoEdit = this.PrepodTextBox.Text.Trim();
                }
                if(this.Checkbox_Speciality.Checked){
                    CodSpeciality = this.DropDownList_Speciality.SelectedValue;
                }
                if(this.Checkbox_StudyPlan.Checked){
                    CodPlan = Convert.ToInt32(this.DropDownList_StudyPlan.SelectedValue);
                }
                AcademiaDataSet.UMK_and_RPD_with_opisanieDataTable tmpTable = new AcademiaDataSet.UMK_and_RPD_with_opisanieDataTable();
                adapter.Fill(tmpTable, CodFac, CodKaf, Year, CodPlan, CodSpeciality, CodTypeEdu, CodFormStudy, PrepodWhoEdit, this.RadioButtonList1.SelectedIndex == 0 ? false : true);                    
                for(int i = 0; i < tmpTable.Rows.Count; i++){
                    DataRow Row = tmpTable.Rows[i];
                    TableRow HtmlTableRow = new TableRow();
                    for (int j = 0; j < 9; j++ ) {
                        HtmlTableRow.Cells.Add(new TableCell());
                        HtmlTableRow.Cells[j].CssClass = "GridViewCss_FindForm";
                    }
                    HtmlTableRow.Cells[0].Text = (i + 1).ToString();
                    HtmlTableRow.Cells[1].Text = Row["Year"] != null ? Row["Year"].ToString() : String.Empty;
                    HtmlTableRow.Cells[2].Text = Row["TypeEdu"] != null ? Row["TypeEdu"].ToString() : String.Empty;
                    HtmlTableRow.Cells[3].Text = Row["Speciality"] != null ? Row["Speciality"].ToString() : String.Empty;
                    HtmlTableRow.Cells[4].Text = Row["NamePlan1"] != null ? Row["NamePlan1"].ToString() : String.Empty;
                    HtmlTableRow.Cells[5].Text = Row["NameKaf"] != null ? Row["NameKaf"].ToString() : String.Empty;
                    HtmlTableRow.Cells[6].Text = Row["NameSub"] != null ? Row["NameSub"].ToString() : String.Empty;
                    HtmlTableRow.Cells[7].Text = Row["FIO"] != null ? Row["FIO"].ToString() : String.Empty;
                    HtmlTableRow.Cells[8].Text = Row["PrepodWhoEdit"] != null ? Row["PrepodWhoEdit"].ToString() : String.Empty;
                    this.Table_find_rpd.Rows.Add(HtmlTableRow);
                }
            }
        }
    }
}