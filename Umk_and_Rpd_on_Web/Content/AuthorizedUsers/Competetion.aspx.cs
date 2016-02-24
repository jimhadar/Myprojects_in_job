using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Umk_and_Rpd_on_Web {
    public partial class Competetion : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            if (Session["data"] != null && ((Data_for_program)Session["data"]).table_for_key_compet != null) {
                List<KeyCompetTable> List_with_key_compet = ((Data_for_program)Session["data"]).table_for_key_compet;
                InitTables_for_KeyCompet(ref this.PlaceHolder1, List_with_key_compet);
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            Data_for_program data = ((Data_for_program)Session["data"]);
            if (Page.IsPostBack && !Page.IsCallback && Request["UpdateTmpContents"] == null) {    
                if(data != null){
                    UpdateValues_in_Data();
                }               
            }
            if (!Page.IsPostBack && Request["UpdateTmpContents"] == null) {
                if (data != null) {                     
                    this.TextBox_for_GoalsDiscip.Text = (((Data_for_program)Session["data"]).GoalsDiscip != null) ? ((Data_for_program)Session["data"]).GoalsDiscip : String.Empty;
                    this.TextBox_for_PlaceOOP.Text = (((Data_for_program)Session["data"]).PlaceOOP != null) ? ((Data_for_program)Session["data"]).PlaceOOP : String.Empty;
                    this.TextBox_for_Student_doljen_umet.Text = (((Data_for_program)Session["data"]).Student_Doljen_Umet != null) ? ((Data_for_program)Session["data"]).Student_Doljen_Umet : String.Empty;
                    this.TextBox_for_Student_doljen_vladet.Text = (((Data_for_program)Session["data"]).Student_doljen_Vladet != null) ? (((Data_for_program)Session["data"]).Student_doljen_Vladet) : string.Empty;
                    this.TextBox_for_Student_doljen_znat.Text = (((Data_for_program)Session["data"]).Student_Doljen_Znat != null) ? ((Data_for_program)Session["data"]).Student_Doljen_Znat : String.Empty;                     
                    this.CheckBoxList_KeyCompet.DataBind();
                    List<KeyCompetTable> List_with_key_compet = ((Data_for_program)Session["data"]).table_for_key_compet;
                    foreach (KeyCompetTable table in List_with_key_compet) {
                        foreach (ListItem checkBox in this.CheckBoxList_KeyCompet.Items) {
                            if (checkBox.Text == table.TableName) {
                                checkBox.Selected = true;
                            }
                        }
                    }
                }
            }
            Page.Title = "Компетенции";
        }

        private void UpdateValues_in_Data() {
            //Занесение целей освоения дисциплины в состояние сеанса
            ((Data_for_program)Session["data"]).GoalsDiscip = TextBox_for_GoalsDiscip.Text.Trim();
            //Занесение целей места дисциплины в структуре ООП в состояние сеанса
            ((Data_for_program)Session["data"]).PlaceOOP = TextBox_for_PlaceOOP.Text.Trim();
            //Занесение ключевых компетенций дисциплины в состояние сеанса 
            //формирование списка ключевых компетенций
            List<KeyCompetTable> List_with_key_compet = ((Data_for_program)Session["data"]).table_for_key_compet;
            //формируем список ключевых компетенций
            SformSpisokKeyCompet(this.PlaceHolder1, ref List_with_key_compet);
            ((Data_for_program)Session["data"]).table_for_key_compet = List_with_key_compet;
            PlaceHolder1.Controls.Clear();
            //пересоздаем таблицы с компетенциями для их отображения на странице
            InitTables_for_KeyCompet(ref this.PlaceHolder1, List_with_key_compet);
            //что студент должен знать?
            ((Data_for_program)Session["data"]).Student_Doljen_Znat = TextBox_for_Student_doljen_znat.Text.Trim();
            //что студент дожен уметь?
            ((Data_for_program)Session["data"]).Student_Doljen_Umet = TextBox_for_Student_doljen_umet.Text.Trim();
            //чем студент должен владеть?
            ((Data_for_program)Session["data"]).Student_doljen_Vladet = TextBox_for_Student_doljen_vladet.Text.Trim();
        }

        #region Вспомогательные методы для работы страницы
        /// <summary>
        /// Инициализация таблиц с описанием ключевых компетенций при загрузке страницы, а также при нажатии на кнопку "Сформировать список клюевых компетенций"
        /// </summary>
        /// <param name="placeHolder">элемент управления, на который будут добавляться создаваемые таблицы</param>
        /// <param name="List_with_key_compet">Источник данных для таблиц</param>
        private void InitTables_for_KeyCompet(ref PlaceHolder placeHolder, List<KeyCompetTable> List_with_key_compet) {
            foreach (KeyCompetTable KeyTable in List_with_key_compet) {
                Table grid = new Table();
                grid.ID = KeyTable.TableName;
                grid.Width = Unit.Percentage(100);
                //создаем отформатированную таблицу для вывода на странице
                for (int j = 0; j < 4; j++) {
                    TableRow Row = new TableRow();
                    Row.Cells.Add(new TableCell());
                    Row.Cells[0].CssClass = "GridViewCss";
                    Row.Cells[0].Width = Unit.Pixel(270);
                    Row.Cells.Add(new TableCell());
                    Row.Cells[1].CssClass = "GridViewCss";
                    grid.Rows.Add(Row);
                }
                grid.Rows[0].Cells[0].Text = "Уровень освоения";
                grid.Rows[0].Cells[1].Text = "Описание уровня";
                grid.Rows[0].Font.Bold = true;
                grid.CssClass = "GridViewCss";
                grid.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                //Заполняем таблицу данными
                for (int j = 1; j < 4; j++) {
                    Label label = new Label();
                    label.ID = "Label" + j.ToString() + KeyTable.TableName;
                    label.Text = KeyTable[j - 1, 0].ToString();
                    grid.Rows[j].Cells[0].Controls.Add(label);
                    TextBox texBox = new TextBox();
                    texBox.ID = "TextBox" + j.ToString() + KeyTable.TableName;
                    texBox.TextMode = TextBoxMode.MultiLine;
                    texBox.Height = 50;
                    texBox.Width = Unit.Percentage(100);
                    texBox.Text = KeyTable[j - 1, 1].ToString();
                    grid.Rows[j].Cells[1].Controls.Add(texBox);
                }
                //Добавляем название компетенции
                Label nameComp = new Label();
                nameComp.Text = "Уровневое описание компетенции " + grid.ID;
                nameComp.CssClass = "CompetLabelStyle";
                placeHolder.Controls.Add(nameComp);
                //Добавляем созданную таблицу на PlaceHolder
                placeHolder.Controls.Add(grid);
            }    
        }
        /// <summary>
        /// Формирование списка ключевых компетенций и их хранение в состоянии сеанса
        /// </summary>
        /// <param name="placeHolder">Контрол, из которого берутся таблицы с компетенциями</param>
        /// <param name="List_with_key_compet">Переменная из состояния сеанса, в которую заносятся ключевые5 компетенции</param>
        private void SformSpisokKeyCompet(PlaceHolder placeHolder, ref List<KeyCompetTable> List_with_key_compet) {
            string[] urovni = new string[] { "Продвинутый (91 – 100 баллов)", "Базовый (71 – 90 баллов)", "Минимальный (41 – 70 баллов)" };
            if (List_with_key_compet == null) {
                List_with_key_compet = new List<KeyCompetTable>();
                foreach (ListItem checkBox in CheckBoxList_KeyCompet.Items) {
                    if (checkBox.Selected) {
                        KeyCompetTable tempTable = new KeyCompetTable(checkBox.Text);     
                        for (int i = 0; i < 3; i++) {
                            tempTable.AddRow(urovni[i], String.Empty);
                        }                              
                        //Добавляем таблицу в список всех таблиц с ключевыми компетенциями
                        List_with_key_compet.Add(tempTable);
                    }
                }
            }
            else {
                //создаем временный массив для ранее существовавшего списка ключевых компетенций
                List<string[]> tempTable_for_KeyCompet = new List<string[]>();
                for (int i = 0; i < placeHolder.Controls.Count; i++) {
                    if (placeHolder.Controls[i] is Table) {
                        Table KeyTable = (Table)placeHolder.Controls[i];
                        tempTable_for_KeyCompet.Add(new string[4]);                  
                        //имя ключевой компетенции
                        tempTable_for_KeyCompet[tempTable_for_KeyCompet.Count - 1][0] = KeyTable.ID;
                        //запоминаем описание признаков освоения
                        for (int j = 1; j < 4; j++) {
                            TextBox texBox = (TextBox)KeyTable.Rows[j].Cells[1].Controls[0];
                            tempTable_for_KeyCompet[tempTable_for_KeyCompet.Count - 1][j] = texBox.Text;
                        }
                    }
                }
                List_with_key_compet.Clear();
                //Создаем новый список ключевых компетенций
                foreach (ListItem checkBox in CheckBoxList_KeyCompet.Items) {
                    //если в CheckBoxList_KeyCompet компетенция отмечена как ключевая
                    if (checkBox.Selected) {
                        //проверяем, существует ли уже описание для данной компетенции                        
                        int indexComp = -1;//индекс компетенции в временном массиве tempTable_for_KeyCompet
                        for (int j = 0; j < tempTable_for_KeyCompet.Count; j++) {
                            if (tempTable_for_KeyCompet[j][0] == checkBox.Text) {
                                indexComp = j;
                                break;
                            }
                        }
                        //создаем таблицу для хранения в ней данных
                        KeyCompetTable tempTable = new KeyCompetTable(checkBox.Text);

                        for (int i = 0; i < 3; i++) {
                            tempTable.AddRow(urovni[i],
                                             (indexComp != -1 ? tempTable_for_KeyCompet[indexComp][i + 1] : String.Empty));
                        }
                        List_with_key_compet.Add(tempTable);
                    }
                }
            }
        }

        /// <summary>
        /// перегруженный FindControl
        /// </summary>
        /// <param name="rootControl"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        private Control FindControl(Control rootControl, string Id) {
            foreach (Control ctl in rootControl.Controls) {
                if (ctl.ID == Id) {
                    return ctl;
                }
                else {
                    Control subCtl = FindControl(ctl, Id);
                    if (subCtl != null) {
                        return subCtl;
                    }
                }
            }
            return null;
        }
        #endregion
        /// <summary>
        /// Формирование полного списка ключевых компетенций с их уровневым описанием
        /// </summary>
        protected void Button_for_keyCompet_Click(object sender, EventArgs e) {
            UpdateValues_in_Data();   
        }

        protected void Button_for_Title_Click(object sender, EventArgs e) {             
            //Перенаправляем на титульную страницу
            Response.Redirect("~/TitleForm");
        }

        protected void Button_for_MethodUkaz_Click(object sender, EventArgs e) {
            Response.Redirect("~/SoderjRazdDiscip");
        }

        protected void Button_for_pred_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/Title");
        }

        protected void Button_next_page_Click(object sender, EventArgs e) {
            Response.Redirect("~/SoderjRazdDiscip");
        }
    }
}