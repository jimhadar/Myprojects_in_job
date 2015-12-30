using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data.Linq;
using System.Diagnostics;
using System.Text;

using Api_narhoz_chita_Web.DataSetTableAdapters;

namespace Api_narhoz_chita_Web.employees {
    public partial class kaf : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            sformListForFaculty_and_kafs();
            //sw.Stop();
        }
        private void sformListForFaculty_and_kafs() {
            using (FacultyTableAdapter facultyAdapter = new FacultyTableAdapter()) {
                using (KafsTableAdapter KafsAdapter = new KafsTableAdapter()) {
                    using (itemprop_employeesTableAdapter EmployeesAdapter = new itemprop_employeesTableAdapter()) {
                        using (POSTTableAdapter PostAdapter = new POSTTableAdapter()) {
                            using (itemprop_prepod_disciplinesTableAdapter DiscipAdapter = new itemprop_prepod_disciplinesTableAdapter()) {
                                using (ArmKaf_PovKvalPrepodTableAdapter QualificAdapter = new ArmKaf_PovKvalPrepodTableAdapter()) {
                                    DataSet.itemprop_prepod_disciplinesDataTable DiscipTable = new DataSet.itemprop_prepod_disciplinesDataTable();

                                    DataSet.ArmKaf_PovKvalPrepodDataTable QualificTable = new DataSet.ArmKaf_PovKvalPrepodDataTable();

                                    DataSet.KafsDataTable kafsTable = new DataSet.KafsDataTable();

                                    DataSet.itemprop_employeesDataTable EmployeesTable = new DataSet.itemprop_employeesDataTable();

                                    DataSet.POSTDataTable PostTable = new DataSet.POSTDataTable();

                                    int StudyYear = (DateTime.Now.Month >= 9) ? DateTime.Now.Year : DateTime.Now.Year - 1;
                                    var h2 = new HtmlGenericControl("h2");
                                    h2.InnerText = "Педагогический состав";
                                    Content.Controls.Add(h2);

                                    DataSet.FacultyDataTable FacultyTable = new DataSet.FacultyDataTable();
                                    Func<DataRow, bool> func = (Row) => {
                                        return (int)Row["CodFaculty"] == 80 ? true : false;
                                    };

                                    facultyAdapter.Fill(FacultyTable);

                                    KafsAdapter.Fill(kafsTable);

                                    PostAdapter.Fill(PostTable);

                                    DiscipAdapter.Fill(DiscipTable, (short)StudyYear, string.Empty, "0", true);

                                    EmployeesAdapter.Fill(EmployeesTable, StudyYear);

                                    QualificAdapter.Fill(QualificTable);

                                    foreach (DataRow RowFac in FacultyTable.Rows) {
                                        var h3 = new HtmlGenericControl("h3");
                                        h3.InnerText = RowFac["NameFaculty"].ToString().Trim();
                                        Content.Controls.Add(h3);
                                        DataRow[] Kafs = kafsTable.Select("CodFaculty = " + RowFac["CodFaculty"].ToString());

                                        foreach (DataRow RowKaf in Kafs) {
                                            var h4 = new HtmlGenericControl("h4");
                                            h4.InnerText = "Кафедра " + RowKaf["NameKaf"].ToString().Trim().ToLower();
                                            Content.Controls.Add(h4);
                                            DataRow[] EmployeesListInKaf = EmployeesTable.Select("CodKaf = " + RowKaf["CodKaf"].ToString().Trim());
                                            Table table = new Table();
                                            table.Style.Add(HtmlTextWriterStyle.BorderCollapse, "collapse");
                                            table.Style.Add(HtmlTextWriterStyle.BorderColor, "black");
                                            table.Style.Add(HtmlTextWriterStyle.BorderStyle, "solid");
                                            table.Style.Add(HtmlTextWriterStyle.BorderWidth, "1px");
                                            table.Style.Add(HtmlTextWriterStyle.FontSize, "11px");
                                            table.Style.Add(HtmlTextWriterStyle.Width, "1000px");
                                            AddHtmlHeader(table);

                                            for (int i = 0; i < EmployeesListInKaf.Length; i++) {
                                                DataRow[] PostRows = PostTable.Select("CODPE = " + EmployeesListInKaf[i]["CodPrep"].ToString());
                                                DataRow[] DiscipRows = DiscipTable.Select("codprep = " + EmployeesListInKaf[i]["CodPrep"].ToString());
                                                DataRow[] QualificRows = QualificTable.Select("CodPrep = " + EmployeesListInKaf[i]["CodPrep"].ToString());
                                                string post = String.Empty;
                                                if (PostRows.Length != 0) {
                                                    post = PostRows[PostRows.Length - 1]["POSTNAM"].ToString();
                                                }
                                                AddHtmlRow(EmployeesListInKaf[i],
                                                            table,
                                                            post,
                                                            i + 1,
                                                            StudyYear,
                                                            DiscipRows,
                                                            QualificRows);
                                            }
                                            this.Content.Controls.Add(table);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }  
        /// <summary>
        /// добавление в таблицу строки-заголовка
        /// </summary>
        /// <param name="table"></param>
        private void AddHtmlHeader(Table table) {
            TableHeaderRow HeaderRow = new TableHeaderRow();
            string style = "border:solid 1px black;" +
                            "border-collapse:collapse;" +
                            "border-spacing: 10px;" +
                            "vertical-align:top;" +
                            "background-color: rgb(238, 238, 238);" +
                            "text-align:center;" +
                            "font-weight:bold;";
            for (int i = 0; i < 11; i++ ) {
                HeaderRow.Cells.Add(new TableCell());
            }
            HeaderRow.Cells[0].Text = "№\nп/п";
            HeaderRow.Cells[1].Text = "ФИО";
            HeaderRow.Cells[2].Text = "Должность";
            HeaderRow.Cells[3].Text = "Преподаваемые\nдисциплины";
            HeaderRow.Cells[4].Text = "Ученая\nстепень";
            HeaderRow.Cells[5].Text = "Ученое\nзвание";
            HeaderRow.Cells[6].Text = "Направление подготовки и (или)\nспециальности подготовки";
            HeaderRow.Cells[7].Text = "Повышение квалификации и (или)\nпрофессиональная переподготовка";
            HeaderRow.Cells[8].Text = "Общий стаж работы";
            HeaderRow.Cells[9].Text = "Стаж работы по специальности";
            //Для Столюца с Резюме
            HeaderRow.Cells[10].Text = "";

            HeaderRow.Cells[0].Attributes.Add("style", style + "width:40px;text-align:center;");
            HeaderRow.Cells[1].Attributes.Add("style", style + "width:110px;");
            HeaderRow.Cells[2].Attributes.Add("style", style + "width: 80px;");
            HeaderRow.Cells[3].Attributes.Add("style", style + "width:150px;");
            HeaderRow.Cells[4].Attributes.Add("style", style + "width:70px;");
            HeaderRow.Cells[5].Attributes.Add("style", style + "width: 70px;");
            HeaderRow.Cells[6].Attributes.Add("style", style + " width:100px;");
            HeaderRow.Cells[7].Attributes.Add("style", style + "width:50px;");
            HeaderRow.Cells[8].Attributes.Add("style", style + "width:80px;");
            HeaderRow.Cells[9].Attributes.Add("style", style + "width:50px;");
            HeaderRow.Cells[10].Attributes.Add("style", style + "width:55px;");

            table.Rows.Add(HeaderRow);
        } 
        /// <summary>
        /// добалвение в Html-таблицу новой строки с преподавателем
        /// </summary>
        /// <param name="RowPrepod">строка, содержащая всю необходимую информацию</param>
        /// <param name="table">Таблица, в котрую добавляется строка</param>
        /// <param name="PostNamPrep">Должность преподавателя</param>
        /// <param name="SequenceNumber">Номер преподавателя по порядку (для определения его порядкового номера в таблице)</param>
        private void AddHtmlRow(DataRow RowPrepod, Table table, string PostNamPrep, int SequenceNumber, int StudyYear, DataRow[] prepod_disciplinesTable, DataRow[] QualificRows) {                   
            TableRow row = new TableRow();
            string style  = "border:solid 1px black;" + 
                            "border-collapse:collapse;" +
                            "border-spacing: 10px;" +
                            "vertical-align:top;";
            for (int i = 0; i < 11; i++) {
                row.Cells.Add(new TableCell());
            }
            //Список направлений подготовки, дисциплины на которых ведет преподаватель
            List<string> Napravl = new List<string>();
            foreach(DataRow str in prepod_disciplinesTable){
                if (str["Speciality"].ToString() != String.Empty) {
                    Napravl.Add(str["Speciality"].ToString().Trim());
                }
            }
            IEnumerable<string> tmp_Napravl_List = Napravl.Distinct<string>();
            string tmp_Napravl = String.Empty;
            //номер направления
            int NumQualific = 1;
            //количество направлений
            int CountQualific = tmp_Napravl_List.Count<string>();      
            foreach(string str in tmp_Napravl_List){
                if (CountQualific > 1) {
                    tmp_Napravl += NumQualific.ToString() + "." + str.Trim() + "<br>";
                    NumQualific++;
                }
                else {
                    tmp_Napravl = str.Trim();
                }
            }
            List<string> tmp_ListDiscip = new List<string>();
            foreach(DataRow Row in prepod_disciplinesTable){
                tmp_ListDiscip.Add(Row["namesub"].ToString());
            }
            IEnumerable<string> tmpListDiscip = tmp_ListDiscip.Distinct<string>();
            //для повышения квалификации преподавателя 
            StringBuilder QualificList = new StringBuilder();
            for (int i = 0; i < QualificRows.Length; i++ ) {
                QualificList.AppendLine((i + 1).ToString() + ". " + QualificRows[i]["NameProg"].ToString() + ";<br>");
            }   

            row.Cells[0].Attributes.Add("style", style + "width:40px;text-align:center;");
            row.Cells[1].Attributes.Add("style", style + "width:110px;");
            row.Cells[2].Attributes.Add("style", style + "width: 80px;");
            row.Cells[3].Attributes.Add("style", style + "width:150px;");
            row.Cells[4].Attributes.Add("style", style + "width:70px;");
            row.Cells[5].Attributes.Add("style", style + "width: 70px;");
            row.Cells[6].Attributes.Add("style", style + "width:100px;");
            row.Cells[7].Attributes.Add("style", style + "width:50px;");
            row.Cells[8].Attributes.Add("style", style + "width:80px;vertical-align:top;text-align:center;");
            row.Cells[9].Attributes.Add("style", style + "width:50px;vertical-align:top;text-align:center;");
            row.Cells[10].Attributes.Add("style", style + "width:55px;");

            row.Cells[0].Text = SequenceNumber.ToString();
            //В стоблец "ФИО"
            row.Cells[1].Text = RowPrepod["FIO"].ToString().Trim();
            row.Cells[1].Attributes.Add("itemprop", "fio");
            //В столбец "Должность"
            row.Cells[2].Text = PostNamPrep;
            row.Cells[2].Attributes.Add("itemprop", "Post");
            //в столбец "Преподавапеые дисциплины"
            //row.Cells[3].Text = "<b>На направлениях бакалавриата:</b><br>";

            foreach (string str in tmpListDiscip) {
                row.Cells[3].Text += str + ";<br>";
            }
            row.Cells[3].Attributes.Add("itemprop", "TeachingDiscipline");
            //в столбец "Ученая степень"
            row.Cells[4].Text = (RowPrepod["DEGRENAM"].ToString().IndexOf("нет") < 0) ? RowPrepod["DEGRENAM"].ToString().Trim() : String.Empty;
            row.Cells[4].Attributes.Add("itemprop", "Degree");
            //в столбец "Ученое звание"
            row.Cells[5].Text = (RowPrepod["CLASSNAM"].ToString().IndexOf("нет") < 0) ? RowPrepod["CLASSNAM"].ToString().Trim() : String.Empty;
            row.Cells[5].Attributes.Add("itemprop", "AcademStat");
            //в столбец "Направление подготовки и (или) специальности работника"
            row.Cells[6].Text = tmp_Napravl;
            row.Cells[6].Attributes.Add("itemprop", "EmployeeQualification");
            //в столбец "повышение квалификации и (или) профессиональная переподготовка"
            row.Cells[7].Text = QualificList.ToString();
            row.Cells[7].Attributes.Add("itemprop", "ProfDevelopment");
            //в столбец "Общий стаж работы"
            row.Cells[8].Text = RowPrepod["YearAll"].ToString().Trim();
            row.Cells[8].Attributes.Add("itemprop", "GenExperience");
            //в столбец "Стаж работы по специальности"
            row.Cells[9].Text = RowPrepod["YearTeach"].ToString().Trim();
            row.Cells[9].Attributes.Add("itemprop", "SpecExperience");
            //в столбец "Резюме"
            if (RowPrepod["LinkSite"] != null && RowPrepod["LinkSite"].ToString().Trim() != String.Empty) {
                row.Cells[10].Text = "<a href=\"" + RowPrepod["LinkSite"].ToString().Trim() + "\" target=\"_blank\">Резюме</a>";
            }
            table.Rows.Add(row);
        }
    }
}