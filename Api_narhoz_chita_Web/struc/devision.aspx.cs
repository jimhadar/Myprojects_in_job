using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Api_narhoz_chita_Web.DataSetTableAdapters;
using Api_narhoz_chita_Web;

namespace Api_narhoz_chita_Web.struc {
    public partial class devision : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            sformListPodrazdn();
        }
        private void sformListPodrazdn() {
            using (itemprop_podrazdnTableAdapter PodrazdnAdapter = new itemprop_podrazdnTableAdapter()) {
                DataSet.itemprop_podrazdnDataTable PodrazdnTable = new DataSet.itemprop_podrazdnDataTable();
                PodrazdnAdapter.Fill(PodrazdnTable);
                foreach (DataRow Row in PodrazdnTable.Rows) {
                    short type = Convert.ToInt16(Row["type"]);

                    var div_about = new HtmlGenericControl("div");

                    var h3_name = new HtmlGenericControl("h4");
                    if ((byte)Row["Type"] == 2) {
                        string name = Row["Name"].ToString().Trim().ToLower();
                        h3_name.InnerText = name.Substring(0, 1).ToUpper() + name.Substring(1, name.Length - 1);
                    }
                    else {
                        h3_name.InnerText = Row["Name"].ToString().Trim();
                    }
                    h3_name.Attributes.Add("itemprop", "Name");
                    h3_name.Attributes.Add("style", "font-weight:bold; line-height:3;");

                    var p = new HtmlGenericControl("p");

                    var span_fio = new HtmlGenericControl("span");
                    switch (type) {
                        case 0:
                            p.InnerText = "Начальник отдела - ";
                            span_fio.InnerText = Row["Fio"].ToString();
                            span_fio.Attributes.Add("itemprop", "Fio");
                            div_about = OtherPodrazdn;
                            break;
                        case 1:
                            p.InnerText = "Декан - ";
                            span_fio.InnerText = Row["Fio"].ToString();
                            span_fio.Attributes.Add("itemprop", "Fio");
                            div_about = this.Faculties;
                            break;
                        case 2:
                            p.InnerText = "Заведующий кафедрой - ";
                            span_fio.InnerText = Row["Fio"].ToString();
                            span_fio.Attributes.Add("itemprop", "Fio");
                            div_about = Kafs;
                            break;
                    }
                    p.Attributes.Add("class", "line_height_for_aboutOtdel");
                    p.Controls.Add(span_fio);
                    p.Attributes.Add("style", "margin-left:30px");
                    div_about.Controls.Add(h3_name);
                    div_about.Controls.Add(p);

                    p = new HtmlGenericControl("p");
                    p.InnerText = "Местоположение - ";
                    p.Attributes.Add("style", "margin-left:30px");
                    var span_AddressStr = new HtmlGenericControl("span");
                    span_AddressStr.InnerText = Row["Adres"].ToString();
                    span_AddressStr.Attributes.Add("itemprop", "AddressStr");
                    p.Controls.Add(span_AddressStr);
                    p.Attributes.Add("class", "line_height_for_aboutOtdel");
                    div_about.Controls.Add(p);
                    if (Row["Site"].ToString() != null && Row["Site"].ToString() != String.Empty) {
                        p = new HtmlGenericControl("p");
                        p.InnerText = "Сайт - ";
                        var a_Site = new HtmlGenericControl("span");
                        a_Site.InnerHtml = "<a href=\"" + Row["Site"].ToString() + "\" target=\"_blank\">" + Row["Site"].ToString() + "</a>";
                        a_Site.Attributes.Add("itemprop", "Site");
                        p.Controls.Add(a_Site);
                        p.Attributes.Add("class", "line_height_for_aboutOtdel");
                        p.Attributes.Add("style", "margin-left:30px");
                        div_about.Controls.Add(p);
                    }
                    if (Row["Email"].ToString() != null && Row["Email"].ToString() != String.Empty) {
                        p = new HtmlGenericControl("p");
                        p.InnerText = "E-mail: ";
                        p.InnerHtml = "E-mail: " + "<a href=\"mailto:" + Row["Email"].ToString().Trim() + "\">" + Row["Email"].ToString().Trim() + "</a>";
                        p.Attributes.Add("class", "line_height_for_aboutOtdel");
                        p.Attributes.Add("style", "margin-left:30px");
                        div_about.Controls.Add(p);
                    }
                    if (Row["DivisionClause_DocLink"].ToString() != null && Row["DivisionClause_DocLink"].ToString() != string.Empty) {
                        var P_DivisionClauseDocLink = new HtmlGenericControl("a");
                        P_DivisionClauseDocLink.InnerHtml = "<a href=\"" + Row["DivisionClause_DocLink"].ToString() + "\" target=\"_blank\">Положение о подразделении</a>";
                        P_DivisionClauseDocLink.Attributes.Add("itemprop", "DivisionClause_DocLink");
                        P_DivisionClauseDocLink.Attributes.Add("style", "margin-left:30px");
                        div_about.Controls.Add(P_DivisionClauseDocLink);
                    }
                }
            }
        }
    }
}