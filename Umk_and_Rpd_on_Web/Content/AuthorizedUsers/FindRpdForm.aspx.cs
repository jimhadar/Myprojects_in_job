using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Umk_and_Rpd_on_Web.Content.AuthorizedUsers {
    public partial class FindRpdForm : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(!Page.IsPostBack){
                Load_DropDownList_for_uch_year();
            }
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
    }
}