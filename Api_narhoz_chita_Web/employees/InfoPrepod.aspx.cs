using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Api_narhoz_chita_Web.DataSetTableAdapters;
using System.Data;

namespace Api_narhoz_chita_Web.employees {
    public partial class InfoPrepod : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            sformListAboutPrepod();
        }
        private void sformListAboutPrepod() {
            using(itemprop_prepod_disciplinesTableAdapter prepodDiscipAdapter = new itemprop_prepod_disciplinesTableAdapter()){
                using ( itemprop_employeesTableAdapter employeesAdapter = new itemprop_employeesTableAdapter() ) {
                    using (POSTTableAdapter PostAdapter = new POSTTableAdapter()) {
                        using (ArmKaf_PovKvalPrepodTableAdapter QualificAdapter = new ArmKaf_PovKvalPrepodTableAdapter()) {
                            DataSet.itemprop_prepod_disciplinesDataTable PrepodDiscipTable = new DataSet.itemprop_prepod_disciplinesDataTable();
                            DataSet.itemprop_employeesDataTable EmployeesTable = new DataSet.itemprop_employeesDataTable();
                            DataSet.POSTDataTable postTable = new DataSet.POSTDataTable();
                            DataSet.ArmKaf_PovKvalPrepodDataTable QualificTable = new DataSet.ArmKaf_PovKvalPrepodDataTable();
                            int StudyYear = (DateTime.Now.Month >= 9) ? DateTime.Now.Year : DateTime.Now.Year - 1;
                            string FIO = Request.QueryString["fio"];
                            string CodPrep = Request.QueryString["CodPrep"];
                            if (FIO != null && FIO != String.Empty) {
                                prepodDiscipAdapter.Fill_ForDiscipPrepPage(PrepodDiscipTable, StudyYear, FIO, String.Empty, false);
                            }
                            else if (CodPrep != null && CodPrep != String.Empty) {
                                prepodDiscipAdapter.Fill_ForDiscipPrepPage(PrepodDiscipTable, StudyYear, String.Empty, CodPrep, false);
                            }
                            var PrepodDisciplines = new HtmlGenericControl("div");
                            if (PrepodDiscipTable.Rows.Count > 0) {
                                //кафедра, к которой "привязан преподаватель"
                                var h3 = new HtmlGenericControl("h3");
                                //h3.InnerText = "Кафедра " + PrepodDiscipTable.Rows[0]["NameKaf"].ToString().Trim().ToLower();
                                //this.AboutPrepod.Controls.Add(h3);
                                //код преподавателя
                                int CodPE = Convert.ToInt32(PrepodDiscipTable[0]["codprep"]);
                                employeesAdapter.Fill_onCodPE(EmployeesTable, StudyYear, CodPE);
                                PostAdapter.Fill(postTable);
                                QualificAdapter.Fill_Qualific_on_CodPrep(QualificTable, CodPE);

                                var p = new HtmlGenericControl("p");
                                //Должность
                                p = this.ZapAboutPrepWithAttr("Должность - ", postTable[0]["POSTNAM"].ToString().Trim(), "Post");
                                p.Attributes.Add("class", "p_AboutZaslugiPrep");
                                AboutPrepod.Controls.Add(p);
                                //ученая степень
                                p = this.ZapAboutPrepWithAttr("Ученая степень - ", EmployeesTable.Rows[0]["DEGRENAM"].ToString().Trim(), "Degree");
                                p.Attributes.Add("class", "p_AboutZaslugiPrep");
                                AboutPrepod.Controls.Add(p);
                                //ученое звание
                                p = this.ZapAboutPrepWithAttr("Ученое звание - ", EmployeesTable.Rows[0]["CLASSNAM"].ToString().Trim(), "AcademStat");
                                p.Attributes.Add("class", "p_AboutZaslugiPrep");
                                AboutPrepod.Controls.Add(p);
                                
                                //Повышение квалификации преподавателя
                                p = new HtmlGenericControl("h4");
                                p.InnerText = "Повышение квалификации:";
                                p.Attributes.Add("style", "font-weight:bold;");
                                AboutPrepod.Controls.Add(p);

                                Table QualificHtmlTable = new Table();
                                QualificHtmlTable.Attributes.Add("itemprop", "ProfDevelopment");
                                QualificHtmlTable.Style.Add(HtmlTextWriterStyle.BorderCollapse, "collapse");
                                QualificHtmlTable.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
                                QualificHtmlTable.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
                                QualificHtmlTable.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px");
                                //QualificHtmlTable.Style.Add(HtmlTextWriterStyle.FontSize, "8px");
                                QualificHtmlTable.Style.Add(HtmlTextWriterStyle.Width, "540px");
                                //стили для шапки таблицы
                                string style = "border:solid 1px black;" +
                                                "border-collapse:collapse;" +
                                                "border-spacing: 10px;" +
                                                "vertical-align:top;" +
                                                "background-color: rgb(238, 238, 238);" +
                                                "text-align:center;" +
                                                "font-weight:bold;" + 
                                                "font-size:1em;";
                                //для шапки таблицы с повышением квалификации
                                TableRow HtmlRow = new TableRow();
                                TableCell[] Cells = new TableCell[4];
                                (Cells[0] = new TableCell()).Text = "Наименование программы";
                                Cells[0].Attributes.Add("style", style + "width:230px;vertical-align:middle;");
                                (Cells[1] = new TableCell()).Text = "Часы";
                                Cells[1].Attributes.Add("style", style + "vertical-align:middle;");
                                (Cells[2] = new TableCell()).Text = "Год";
                                Cells[2].Attributes.Add("style", style + "vertical-align:middle;");
                                (Cells[3] = new TableCell()).Text = "Наименование образовательного учреждения, в котором осуществлялось повышение квалификации, профессиональная переподготовка";
                                Cells[3].Attributes.Add("style", style + "width:210px;vertical-align:middle;");

                                HtmlRow.Cells.AddRange(Cells);
                                QualificHtmlTable.Rows.Add(HtmlRow);
                                //добавление программ повышения квалаификации в таблицу
                                style = "border:solid 1px black;" +
                                        "border-collapse:collapse;" +
                                        "border-spacing: 10px;" +
                                        "vertical-align:top;" +
                                        "font-size:1em;";
                                foreach(DataRow Row in QualificTable.Rows){
                                    HtmlRow = new TableRow();
                                    Cells = new TableCell[4];
                                    (Cells[0] = new TableCell()).Text = Row["NameProg"].ToString().Trim();
                                    Cells[0].Attributes.Add("style", style  + "width:230px;");
                                    (Cells[1] = new TableCell()).Text = Row["Hours"].ToString().Trim();
                                    Cells[1].Attributes.Add("style", style + "text-align:center;");
                                    (Cells[2] = new TableCell()).Text = Row["Year"].ToString().Trim();
                                    Cells[2].Attributes.Add("style", style + "text-align:center;");
                                    (Cells[3] = new TableCell()).Text = Row["NameVuz"].ToString().Trim();
                                    Cells[3].Attributes.Add("style", style + "width:210px;");
                                    HtmlRow.Cells.AddRange(Cells);
                                    QualificHtmlTable.Rows.Add(HtmlRow);
                                }
                                if(QualificTable.Rows.Count == 0){
                                    QualificHtmlTable.Style.Add(HtmlTextWriterStyle.Display, "none");
                                }
                                AboutPrepod.Controls.Add(QualificHtmlTable);

                                //преподаваемые дисциплины                                       
                                h3 = new HtmlGenericControl("h4");
                                h3.InnerText = "В 2015-2016 учебном году преподает дисциплины:";
                                h3.Attributes.Add("style", "font-weight:bold;");
                                PrepodDisciplines.Controls.Add(h3);
                                //получаем 4 массива табличных строк: в первом - основные дисциплины преподавателя "на направлениях бакалавриата"
                                //во втором - основные дисциплины преподавателя "на специальностях"
                                //во третьем - дополнительная нагрузка преподавателя"на направлениях бакалавриата"
                                //в четвертом -  дополнительная нагрузка преподавателя"на специальностях"
                                DataRow[] MainNagruzka = PrepodDiscipTable.Select("TypeSub = 0");
                                DataRow[] DopNagruzka = PrepodDiscipTable.Select("TypeSub = 1");
                                DataRow[] MainNagruzkaBakalavr = PrepodDiscipTable.Select("TypeSub = 0 and TextNapravl = 'на направлениях бакалавриата:'");
                                DataRow[] MainNagruzkaSpec = PrepodDiscipTable.Select("TypeSub = 0 and TextNapravl = 'на специальностях:'");
                                DataRow[] DopNagruzkaBakalavr = PrepodDiscipTable.Select("TypeSub = 1 and TextNapravl = 'на направлениях бакалавриата:'");
                                DataRow[] DopNagruzkaSpec = PrepodDiscipTable.Select("TypeSub = 1 and TextNapravl = 'на специальностях:'");
                                //для дисциплин, уже добавленных на страницу для отрисовки
                                List<string> tmpListNameSub = new List<string>();


                                BulletedList list;

                                var h3_NameSub = new HtmlGenericControl("h4");
                                var span_TextNapravl = new HtmlGenericControl("span");
                                foreach (DataRow RowMainDiscip in MainNagruzka) {
                                    if (tmpListNameSub.IndexOf(RowMainDiscip["namesub"].ToString().Trim()) < 0) {
                                        tmpListNameSub.Add(RowMainDiscip["namesub"].ToString().Trim());
                                        MainNagruzkaBakalavr = PrepodDiscipTable.Select("TypeSub = 0 and TextNapravl = 'на направлениях бакалавриата:' and namesub = '" + RowMainDiscip["namesub"].ToString().Trim() + "'");
                                        MainNagruzkaSpec = PrepodDiscipTable.Select("TypeSub = 0 and TextNapravl = 'на специальностях:' and namesub = '" + RowMainDiscip["namesub"].ToString().Trim() + "'");
                                        h3_NameSub = new HtmlGenericControl("h4");
                                        h3_NameSub.InnerText = RowMainDiscip["namesub"].ToString();
                                        h3_NameSub.Attributes.Add("style", "font-weight:bold; font-size:1em");
                                        h3_NameSub.Attributes.Add("itemprop", "TeachingDiscipline");
                                        PrepodDisciplines.Controls.Add(h3_NameSub);

                                        list = new BulletedList();
                                        foreach (DataRow RowBakalavr in MainNagruzkaBakalavr) {
                                            if (RowBakalavr["Speciality"].ToString() != String.Empty) {
                                                list.Items.Add(RowBakalavr["Speciality"].ToString().Trim());
                                            }
                                        }
                                        if (list.Items.Count > 0) {
                                            span_TextNapravl = new HtmlGenericControl("span");
                                            span_TextNapravl.InnerText = "На направлениях бакалавриата:";
                                            span_TextNapravl.Attributes.Add("style", "margin-left:30px;font-size:1em;");
                                            PrepodDisciplines.Controls.Add(span_TextNapravl);
                                            list.Style.Add(HtmlTextWriterStyle.MarginLeft, "40px");
                                            list.Style.Add(HtmlTextWriterStyle.FontSize, "0.9em");
                                            PrepodDisciplines.Controls.Add(list);
                                        }

                                        list = new BulletedList();
                                        foreach (DataRow RowSpec in MainNagruzkaSpec) {
                                            if (RowSpec["Speciality"].ToString() != String.Empty) {
                                                list.Items.Add(RowSpec["Speciality"].ToString());
                                            }
                                        }
                                        if (list.Items.Count > 0) {
                                            span_TextNapravl = new HtmlGenericControl("span");
                                            span_TextNapravl.InnerText = "На специальностях:";
                                            span_TextNapravl.Attributes.Add("style", "margin-left:30px;font-size:1em;");
                                            PrepodDisciplines.Controls.Add(span_TextNapravl);
                                            list.Style.Add(HtmlTextWriterStyle.MarginLeft, "40px");
                                            list.Style.Add(HtmlTextWriterStyle.FontSize, "0.9em");
                                            PrepodDisciplines.Controls.Add(list);
                                        }
                                    }
                                }
                                tmpListNameSub.Clear();
                                if (DopNagruzka.Length > 0) {
                                    h3 = new HtmlGenericControl("h4");
                                    h3.InnerText = "Дополнительная нагрузка преподавателя";
                                    h3.Attributes.Add("style", "font-weight:bold;");
                                    PrepodDisciplines.Controls.Add(h3);
                                }
                                foreach (DataRow RowDopDiscip in DopNagruzka) {
                                    if (tmpListNameSub.IndexOf(RowDopDiscip["namesub"].ToString().Trim()) < 0) {
                                        tmpListNameSub.Add(RowDopDiscip["namesub"].ToString().Trim());
                                        DopNagruzkaBakalavr = PrepodDiscipTable.Select("TypeSub = 1 and TextNapravl = 'на направлениях бакалавриата:' and namesub = '" + RowDopDiscip["namesub"].ToString().Trim() + "'");
                                        DopNagruzkaSpec = PrepodDiscipTable.Select("TypeSub = 1 and TextNapravl = 'на специальностях:' and namesub = '" + RowDopDiscip["namesub"].ToString().Trim() + "'");
                                        h3_NameSub = new HtmlGenericControl("h4");
                                        h3_NameSub.InnerText = RowDopDiscip["namesub"].ToString();
                                        h3_NameSub.Attributes.Add("style", "font-weight:bold; font-size:1em");
                                        h3_NameSub.Attributes.Add("itemprop", "TeachingDiscipline");
                                        PrepodDisciplines.Controls.Add(h3_NameSub);

                                        list = new BulletedList();
                                        foreach (DataRow RowBakalavr in MainNagruzkaBakalavr) {
                                            if (RowBakalavr["Speciality"].ToString() != String.Empty) {
                                                list.Items.Add(RowBakalavr["Speciality"].ToString().Trim());
                                            }
                                        }
                                        if (list.Items.Count > 0) {
                                            span_TextNapravl = new HtmlGenericControl("span");
                                            span_TextNapravl.InnerText = "На направлениях бакалавриата:";
                                            span_TextNapravl.Attributes.Add("style", "margin-left:30px;font-size:1em;");
                                            PrepodDisciplines.Controls.Add(span_TextNapravl);
                                            list.Style.Add(HtmlTextWriterStyle.MarginLeft, "40px");
                                            list.Style.Add(HtmlTextWriterStyle.FontSize, "0.9em");
                                            PrepodDisciplines.Controls.Add(list);
                                        }

                                        list = new BulletedList();
                                        foreach (DataRow RowSpec in DopNagruzkaSpec) {
                                            if (RowSpec["Speciality"].ToString() != String.Empty) {
                                                list.Items.Add(RowSpec["Speciality"].ToString());
                                            }
                                        }
                                        if (list.Items.Count > 0) {
                                            span_TextNapravl = new HtmlGenericControl("span");
                                            span_TextNapravl.InnerText = "На специальностях:";
                                            span_TextNapravl.Attributes.Add("style", "margin-left:30px;font-size:1em;");
                                            PrepodDisciplines.Controls.Add(span_TextNapravl);
                                            list.Style.Add(HtmlTextWriterStyle.MarginLeft, "40px");
                                            list.Style.Add(HtmlTextWriterStyle.FontSize, "0.9em");
                                            PrepodDisciplines.Controls.Add(list);
                                        }
                                        tmpListNameSub.Add(RowDopDiscip["namesub"].ToString().Trim());
                                    }
                                }
                            }
                            AboutPrepod.Controls.Add(PrepodDisciplines);
                        }
                    }                                                  
                }                                                      
            }
        }
        /// <summary>
        /// обобщение для заполнения ученой степени/звания/должности работника
        /// </summary>
        /// <param name="About">название: ученое звание/степень/должность и т.п.</param>
        /// <param name="TextInSpan">текст, заключенный в теге "span"</param>
        /// <param name="ItemPropName">имя для атрибута "ItemProp"</param>
        /// <returns></returns>
        private HtmlGenericControl ZapAboutPrepWithAttr(string About, string TextInSpan, string ItemPropName) {
            var p = new HtmlGenericControl("p");
            p.InnerText = About;
            var span = new HtmlGenericControl("span");
            span.InnerText = TextInSpan;
            span.Attributes.Add("itemprop", ItemPropName);
            p.Controls.Add(span);
            return p;
        }
    }
}