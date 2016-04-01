using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Runtime.Serialization.Formatters.Binary;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers.for_admin {
    public partial class AdminForm : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Page.Title = "Админ";
        }

        private DataTable GetData() {
            byte? CodFac = null;
            byte? CodKaf = null;
            int? StudyYear = null;
            int? CodPlan = null;
            string CodSpec = null;
            byte? CodTypeEdu = null;
            byte? CodFormStudy = null;
            bool? umk_or_rpd = null;
            int BeginYear = (DateTime.Now.Month >= 9) ? DateTime.Now.Year : DateTime.Now.Year - 1;
            string NameRpd = string.Empty;
            if (this.CheckBoxListParams.Items[0].Selected == true)
                CodKaf = Convert.ToByte(this.DropDownList_kafs.SelectedValue);
            if (this.CheckBoxListParams.Items[1].Selected == true)
                CodSpec = this.DropDownList_Speciality.SelectedItem.Text.Trim();
            if (this.CheckBoxListParams.Items[2].Selected == true)
                if (this.DropDownList_StudyPlan.SelectedValue != null)
                    CodPlan = Convert.ToInt32(this.DropDownList_StudyPlan.SelectedValue);
            using(AcademiaDataSetTableAdapters.UMK_and_RPD_with_opisanieTableAdapter adapter = new AcademiaDataSetTableAdapters.UMK_and_RPD_with_opisanieTableAdapter()){
                return adapter.GetData_admin(CodFac, CodKaf, StudyYear, CodPlan, CodSpec, CodTypeEdu, CodFormStudy, BeginYear, NameRpd);
            }
        }

        private void DrawHtmlTAble() {
            DataTable tableWithRpd = this.GetData();
            DataRow[] tmp = null;
            switch (this.RadioBtnParams.SelectedIndex) {
                case 0 :
                    tmp = tableWithRpd.Select("Name=''");
                    break;
                case 1 :
                    tmp = tableWithRpd.Select("Name<>''");
                    break;
            }                                   
            foreach(DataRow row in tmp){
                if ((bool?)row["UMK_or_RPD"] == false) {
                    using (MemoryStream memStream = new MemoryStream()) {
                        Data_for_program data = new Data_for_program();
                        if (row["Tmp_contents"] != null || (row["Tmp_contents"].ToString() == string.Empty && ((byte[])row["Tmp_contents"]).Length == 0)) {
                            string Data = row["Contents"].ToString();
                            StreamWriter writer = new StreamWriter(memStream, System.Text.Encoding.UTF8);
                            writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Data);
                            writer.Flush();
                            StreamReader reader = new StreamReader(memStream, System.Text.Encoding.UTF8);
                            reader.BaseStream.Seek(0, SeekOrigin.Begin);
                            System.Xml.XmlTextReader xmlReader = new System.Xml.XmlTextReader(reader);
                            data.Load_RPD_To_Program_from_XML(ref xmlReader);
                        }
                        else {
                            byte[] tmp_content = (byte[])row["Tmp_contents"];
                            if (tmp != null && tmp.Length > 0) {
                                BinaryFormatter BinFormat = new BinaryFormatter();
                                memStream.Write(tmp_content, 0, tmp_content.Length);
                                memStream.Seek(0, SeekOrigin.Begin);
                                Session["data"] = (Data_for_program)BinFormat.Deserialize(memStream);
                            }
                        }
                        string EmptyField = this.GetEmptyField(data);
                        HtmlTableRow tableRow = new HtmlTableRow();
                        for (int i = 0; i < 8; i++) {
                            tableRow.Cells.Add(new HtmlTableCell());
                            tableRow.Cells[i].Attributes.Add("class", "GridViewCss");
                        }
                        tableRow.Cells[0].InnerHtml = (row["Name"] != null && row["Name"].ToString() != string.Empty) ? "+" : "-";
                        tableRow.Cells[1].InnerHtml = Convert.ToDateTime(row["DateSave"]).ToString();
                        tableRow.Cells[2].InnerHtml = row["Name"].ToString();
                        tableRow.Cells[3].InnerHtml = row["Id_RPD_or_UMK"].ToString();
                        tableRow.Cells[4].InnerHtml = tableWithRpd.Select("CodPlan=" + row["CodPlan"].ToString() + " and CodSub=" + row["CodSub"].ToString() + " and Year=" + row["Year"].ToString() + " and UMK_or_RPD=1")[0]["Id_RPD_or_UMK"].ToString();
                        tableRow.Cells[5].InnerHtml = row["Year"].ToString();
                        tableRow.Cells[6].InnerHtml = row["NamePlan1"].ToString();
                        tableRow.Cells[7].InnerHtml = string.Empty;
                        tableRow.Cells[7].InnerHtml = EmptyField;
                        this.informTable.Rows.Add(tableRow);
                    }
                }
            }
        }

        #region
        protected void CreateTableFind() {
            //if (this.NameRpdTextBox.Text != string.Empty) {
            //    using (AcademiaDataSetTableAdapters.TmpUMK_rpd_ControlSignUpTableAdapter controladapter = new AcademiaDataSetTableAdapters.TmpUMK_rpd_ControlSignUpTableAdapter()) {
            //        DataTable tmpTable = controladapter.GetDataByNameRpd(this.NameRpdTextBox.Text != null ? this.NameRpdTextBox.Text : string.Empty);
            //        foreach (DataRow tmpRow in tmpTable.Rows) {
            //            TableRow row = new TableRow();
            //            for (int i = 0; i < 6; i++) {
            //                row.Cells.Add(new TableCell());
            //                row.Cells[i].Text = tmpRow[i] != null ? tmpRow[i].ToString().Trim() : string.Empty;
            //                row.Cells[i].CssClass = "GridViewCss";
            //            }
            //            this.Table_ControlSaveRpd.Rows.Add(row);
            //        }
            //    }
            //}
        }

        protected void Button_ControlDateSaveRPD_Click(object sender, EventArgs e) {
            CreateTableFind();
            DrawHtmlTAble();
        }

        private void CreateInformTable() {
            
        }

        private string GetEmptyField(Data_for_program data) {
            List<string> emptyField = new List<string>();
            if (data.GoalsDiscip.Trim() == string.Empty) {
                emptyField.Add("Цели освоения дисциплины");
            }
            if(data.PlaceOOP.Trim() == string.Empty)
                emptyField.Add("Место дисциплины в структуре ООП");
            if(data.Student_Doljen_Znat.Trim() == string.Empty)
                emptyField.Add("Студент должен знать");
            if (data.Student_Doljen_Umet.Trim() == string.Empty)
                emptyField.Add("Студент должен уметь");
            if (data.Student_doljen_Vladet.Trim() == string.Empty)
                emptyField.Add("Студент должен владеть");
            if (data.table_for_key_compet == null || data.table_for_key_compet.Count == 0)
                emptyField.Add("Ключевые компетенции");
            if (data.SoderjRazd_DataTable.RowCount == 0)
                emptyField.Add("Содержание дисциплины");
            if (data.LiteratureTable.RowCount == 0 || (data.LiteratureTable.RowCount != 0 && data.LiteratureTable[0, 1] == string.Empty))
                emptyField.Add("Рекомендуемая литература");
            StringBuilder tmp = new StringBuilder();
            foreach(string str in emptyField){
                tmp.AppendLine(str + "<br />");
            }
            return tmp.ToString();
        }

        private string GetNotEmptyField(Data_for_program data) {
            StringBuilder emptyField = new StringBuilder();
            if (data.GoalsDiscip.Trim() == string.Empty) {
                emptyField.AppendLine("Цели освоения дисциплины");
            }
            if(data.PlaceOOP.Trim() != string.Empty)
                emptyField.AppendLine("Место дисциплины в структуре ООП");
            if(data.Student_Doljen_Znat.Trim() != string.Empty)
                emptyField.AppendLine("Студент должен знать");
            if (data.Student_Doljen_Umet.Trim() != string.Empty)
                emptyField.AppendLine("Студент должен уметь");
            if (data.Student_doljen_Vladet.Trim() != string.Empty)
                emptyField.AppendLine("Студент должен владеть");
            if (data.table_for_key_compet != null && data.table_for_key_compet.Count != 0)
                emptyField.AppendLine("Ключевые компетенции");
            if (data.SoderjRazd_DataTable.RowCount != 0)
                emptyField.AppendLine("Содержание дисциплины");
            if (data.LiteratureTable.RowCount != 0)
                emptyField.AppendLine("Рекомендуемая литература");
            return emptyField.ToString();
        }
        #endregion
    }
}