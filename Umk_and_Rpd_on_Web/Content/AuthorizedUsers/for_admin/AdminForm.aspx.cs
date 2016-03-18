using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers.for_admin {
    public partial class AdminForm : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Page.Title = "Админ";
        }

        protected void CreateTableFind() {
            if (this.NameRpdTextBox.Text != string.Empty) {
                using (AcademiaDataSetTableAdapters.TmpUMK_rpd_ControlSignUpTableAdapter controladapter = new AcademiaDataSetTableAdapters.TmpUMK_rpd_ControlSignUpTableAdapter()) {
                    DataTable tmpTable = controladapter.GetDataByNameRpd(this.NameRpdTextBox.Text != null ? this.NameRpdTextBox.Text : string.Empty);
                    foreach (DataRow tmpRow in tmpTable.Rows) {
                        TableRow row = new TableRow();
                        for (int i = 0; i < 6; i++) {
                            row.Cells.Add(new TableCell());
                            row.Cells[i].Text = tmpRow[i] != null ? tmpRow[i].ToString().Trim() : string.Empty;
                            row.Cells[i].CssClass = "GridViewCss";
                        }
                        this.Table_ControlSaveRpd.Rows.Add(row);
                    }
                }
            }
            //this.Table_ControlSaveRpd.Rows.
        }

        protected void Button_ControlDateSaveRPD_Click(object sender, EventArgs e) {
            CreateTableFind();
        }
    }
}