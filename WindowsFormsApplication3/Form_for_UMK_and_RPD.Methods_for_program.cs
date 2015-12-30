using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Xml.Xsl;
using Word = Microsoft.Office.Interop.Word;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace UMK_RPD
{
    internal partial class Form_for_UMK_and_RPD {
        #region необходимые переменные
        /// <summary>
        /// Зав. кафедрой для группы
        /// </summary>
        string ZavKafGroup;
        /// <summary>
        /// код факультета для группы
        /// </summary>
        byte? CodFacGroup = null; 
        /// <summary>
        /// название факультета группы
        /// </summary>
        string NameFacGroup;
        /// <summary>
        /// Заместитель директора по учебной работе
        /// </summary>
        string ZamDir_po_uchJob;
        //Перечисляем все необходимые (но необязательные) переменные для сохранения данных в XML-формате
        /// <summary>
        /// название кафедры преподавателя
        /// </summary>
        string Name_Kaf;
        /// <summary>
        /// название дисциплины
        /// </summary>
        string Name_discipline;
        /// <summary>
        /// Шифр дисциплины
        /// </summary>
        string shifr_discipline;
        /// <summary>
        /// Код специальности
        /// </summary>
        string CodSpeciality;
        /// <summary>
        /// Название специальности
        /// </summary>
        string Name_speciality;
        /// <summary>
        /// Профиль подготовки
        /// </summary>
        string specialization;
        /// <summary>
        /// Составитель РПД/УМК
        /// </summary>
        string sostavitel;
        /// <summary>
        /// Зав. кафедрой для кафедры, которая составляет УМК/РПД
        /// </summary>
        string ZavKaf;
        /// <summary>
        /// Декан факультета группы
        /// </summary>
        string Dekan;
        /// <summary>
        /// Название формы обучения
        /// </summary>
        string NameFormStudy;
        /// <summary>
        /// Количество зачетных единиц
        /// </summary>
        int ZET;
        /// <summary>
        /// ФИО преподавателя: если в плане CodPrep = 0, то FIO_prepod берется на основе CodPrepWhoEdit,
        /// иначе, если CodPrep != 0, то FIO_prepod берется на основе Cod_prep
        /// </summary>
        string FIO_prepod;
        #endregion

        /// <summary>
        /// Формирование всплывающих подсказок для всех необходимых компонентов
        /// </summary>
        private void ToolTip_for_all_components() {
            ToolTip tooltip = new ToolTip();
            tooltip.SetToolTip(this.Add_compet_btn, "Добавить компетенцию");
            tooltip.SetToolTip(this.Del_compet_btn, "Удалить компетенцию");
            tooltip.SetToolTip(this.Sform_keyCompet_btn, "Сформировать список ключевых компетенций");
            tooltip.SetToolTip(this.Add_razdel_btn, "Добавить раздел");
            tooltip.SetToolTip(this.Add_theme_btn, "Добавить тему");
            tooltip.SetToolTip(this.Add_lec_btn, "Добавить лекционное занятие");
            tooltip.SetToolTip(this.Add_prakt_btn, "Добавить практическое занятие");
            tooltip.SetToolTip(this.Add_sam_Job_btn, "Добавить самостоятельную работу");
            tooltip.SetToolTip(this.textBox_for_Dolya_interaktiv_method, "Удельный вес занятий, проводимых в интерактивных формах, определяется главной целью (миссией) программы, особенностью контингента обучающихся и содержанием конкретных дисциплин");
        }

        #region вспомогательные методы для работы с DataGridViewRazdelLesson
        /// <summary>
        /// Добавление строки для заполнения лекций/практик/самостоятельной работы в DataGridViewRazdelLesson
        /// </summary>
        /// <param name="Lec_or_Prakt_or_SamJob">тип занятия : лекция/практика/самостоятельная работа</param>
        private void Add_Lec_or_Prakt_or_SamJob(string Lec_or_Prakt_or_SamJob) {
            this.dataGridViewRazdelLesson.EndEdit();
            if (this.dataGridViewRazdelLesson.RowCount > 0) {
                int CurrentIndex = this.dataGridViewRazdelLesson.CurrentRow.Index + 1;
                for (int i = CurrentIndex - 1; i >= 0; i--) {
                    if (this.dataGridViewRazdelLesson.Rows[i].Cells["ColumnType"].Value.ToString() == "Тема") {
                        break;
                    }
                    else
                        if (this.dataGridViewRazdelLesson.Rows[i].Cells["ColumnType"].Value.ToString() == "Раздел") {
                            string message = (Lec_or_Prakt_or_SamJob == "Лекция") ? "Добавление лекции невозможно, так как сначала нужно добавить в текущий раздел тему!" :
                                             ((Lec_or_Prakt_or_SamJob == "Семинар") ? "Добавление семинара невозможно, так как сначала нужно добавить в текущий раздел тему!" :
                                             "Добавление самостоятельной работы невозможно, так как сначала нужно добавить в текущий раздел тему!");
                            MessageBox.Show(this, message,
                                            "Предупреждение",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            return;
                        }
                }
                this.dataGridViewRazdelLesson.Rows.Insert(CurrentIndex, 1);
                this.dataGridViewRazdelLesson.Rows[CurrentIndex].Cells["ColumnType"].Style.Alignment = DataGridViewContentAlignment.TopRight;
                this.dataGridViewRazdelLesson.Rows[CurrentIndex].Cells["ColumnTheme"].Style.Alignment = DataGridViewContentAlignment.TopLeft;
                this.dataGridViewRazdelLesson.Rows[CurrentIndex].Cells["ColumnType"].Value = Lec_or_Prakt_or_SamJob;
                this.dataGridViewRazdelLesson.Rows[CurrentIndex].Cells["Semestr"].Value = this.dataGridViewRazdelLesson.Rows[CurrentIndex - 1].Cells["Semestr"].Value;
                this.dataGridViewRazdelLesson.Rows[CurrentIndex].Cells["Semestr"].ReadOnly = true;
                this.dataGridViewRazdelLesson.Rows[CurrentIndex].Cells["FormCurControlColumn"].ReadOnly = true;
                this.dataGridViewRazdelLesson.CurrentCell = this.dataGridViewRazdelLesson.Rows[CurrentIndex].Cells["ColumnTheme"];
            }
        }
        /// <summary>
        /// Проверка на правильность введенных данных в поле "ColumnVolume" DataGridViewRazdelLesson
        /// </summary>
        /// <returns></returns>
        private bool Validate_VolumnColumn(int CurrentRow) {
            if (this.dataGridViewRazdelLesson.Rows[CurrentRow].Cells["ColumnVolume"].Value == null) {
                this.dataGridViewRazdelLesson.Rows[CurrentRow].Cells["ColumnVolume"].Value = "0";
                return false;
            }
            string temp = this.dataGridViewRazdelLesson.Rows[CurrentRow].Cells["ColumnVolume"].Value.ToString();
            foreach (char c in temp) {
                if (!char.IsNumber(c)) {
                    MessageBox.Show("Вы ввели неверные данные в поле, предназначенное для заполнения объема часов!",
                                    "Ошибка!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    this.dataGridViewRazdelLesson.Rows[CurrentRow].Cells["ColumnVolume"].Value = "0";
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Формирование полного списка ключевых компетенций с их уровневым описанием
        /// </summary>
        private void sform_spisok_key_compet() {
            this.Competetion_dataGridView.Update();
            this.Competetion_dataGridView.EndEdit();
            string[] urovni = new string[] { "Продвинутый (91 – 100 баллов)", "Базовый (71 – 90 баллов)", "Минимальный (41 – 70 баллов)" };
            int count_comp = Competetion_dataGridView.RowCount;//Общее оличество компетенций 
            int count_page = Ur_compit_TabCotrol.TabCount;//Количество ключевых компетенций до момента их перезаписи
            //пройдемся по строчкам с компетенциями в таблице
            //Если формирование списка ключевых компетенций происходит впервые
            if (table_for_key_compet == null) {
                table_for_key_compet = new DataGridView[20];
                for (int i = 0; i < count_comp; i++) {
                    //если стоит галочка "Ключевая"
                    if (Competetion_dataGridView[2, i].Value != null && Competetion_dataGridView[2, i].Value.ToString().ToLower() == "True") {
                        Ur_compit_TabCotrol.TabPages.Add(Competetion_dataGridView.Rows[i].Cells["CodKompetencii"].Value.ToString());//Добавить вкладку в случае, если найдена ключевая компетенция
                    }
                }
                //добавляем на каждую созданную вкладку таблицы с расшифровкой компетенций
                for (int i = 0; i < Ur_compit_TabCotrol.TabCount; i++) {
                    Ur_compit_TabCotrol.Dock = DockStyle.Fill;
                    table_for_key_compet[i] = new DataGridView();
                    table_for_key_compet[i].Location = new Point();
                    table_for_key_compet[i].Dock = DockStyle.Fill;
                    Ur_compit_TabCotrol.TabPages[i].Controls.Add(table_for_key_compet[i]);
                    table_for_key_compet[i].Columns.Add("Uroven", "Уровень");
                    table_for_key_compet[i].Columns["Uroven"].ReadOnly = true;
                    table_for_key_compet[i].Columns["Uroven"].Width = 160;
                    table_for_key_compet[i].Columns["Uroven"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    table_for_key_compet[i].Columns.Add("Opisanie", "Описание уровня");
                    table_for_key_compet[i].Columns["Opisanie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    table_for_key_compet[i].Columns["Opisanie"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    table_for_key_compet[i].AllowUserToAddRows = false;
                    table_for_key_compet[i].AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    table_for_key_compet[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    table_for_key_compet[i].ScrollBars = ScrollBars.Both;
                    for (int j = 0; j < 3; j++) {
                        //добавляем строчки с уровнями компетенции
                        table_for_key_compet[i].Rows.Add(urovni[j]);
                    }
                }
            }
            //Если уже есть сущестующий список ключевых компетенций
            else {
                //попробуем переписывать всё заново. Берем всё что было, хватаем все во временные таблицы. Удаляем все вкладки, создаём новые. Из временных таблиц все перетаскиваем.
                string[][] tempTable = new string[Ur_compit_TabCotrol.TabPages.Count][];
                count_page = Ur_compit_TabCotrol.TabPages.Count;
                //количество записанных таблиц
                int count_tt = 0;
                for (int i = 0; i < count_page; i++) {
                    tempTable[i] = new string[4];
                    tempTable[i][0] = Ur_compit_TabCotrol.TabPages[i].Text;
                    for (int j = 0; j < 3; j++) {
                        if (table_for_key_compet[i][1, j].Value != null)
                            tempTable[i][j + 1] = table_for_key_compet[i].Rows[j].Cells["Opisanie"].Value.ToString();
                    }
                    count_tt++;
                }
                for (int i = 0; i < count_page; i++) {
                    Ur_compit_TabCotrol.TabPages.Remove(Ur_compit_TabCotrol.TabPages[count_page - i - 1]);
                }

                for (int i = 0; i < count_comp; i++) {
                    //если стоит галочка "Ключевая"
                    if (Competetion_dataGridView.Rows[i].Cells["Key_compet"].Value != null && Competetion_dataGridView.Rows[i].Cells["Key_compet"].Value.ToString().ToLower() == "true") {
                        Ur_compit_TabCotrol.TabPages.Add(Competetion_dataGridView.Rows[i].Cells["CodKompetencii"].Value.ToString());
                    }
                }
                //добавляем на каждую созданную вкладку таблицы с расшифровкой компетенций
                //переменная которая считает количество вкладок
                int inDussCode = 0;
                for (int i = 0; i < Ur_compit_TabCotrol.TabCount; i++) {
                    Ur_compit_TabCotrol.Dock = DockStyle.Fill;
                    table_for_key_compet[i] = new DataGridView();
                    table_for_key_compet[i].Location = new Point();
                    table_for_key_compet[i].Dock = DockStyle.Fill;
                    Ur_compit_TabCotrol.TabPages[i].Controls.Add(table_for_key_compet[i]);
                    table_for_key_compet[i].Columns.Add("Uroven", "Уровень");
                    table_for_key_compet[i].Columns["Uroven"].ReadOnly = true;
                    table_for_key_compet[i].Columns["Uroven"].Width = 160;
                    table_for_key_compet[i].Columns["Uroven"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    table_for_key_compet[i].Columns.Add("Opisanie", "Описание уровня");
                    table_for_key_compet[i].Columns["Opisanie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    table_for_key_compet[i].AllowUserToAddRows = false;
                    table_for_key_compet[i].Columns["Opisanie"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    table_for_key_compet[i].AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    table_for_key_compet[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    table_for_key_compet[i].ScrollBars = ScrollBars.Both;
                    for (int j = 0; j < 3; j++) {
                        //добавляем строчки с уровнями компетенции
                        table_for_key_compet[i].Rows.Add(urovni[j]);
                    }
                    while (inDussCode < count_tt) {
                        if (Ur_compit_TabCotrol.TabPages[i].Text == tempTable[inDussCode][0]) {
                            for (int u = 0; u < 3; u++) {
                                table_for_key_compet[i].Rows[u].Cells["Opisanie"].Value = tempTable[inDussCode][u + 1];
                            }
                        }
                        inDussCode++;
                    }
                    inDussCode = 0;
                }
            }  
        }
        /// <summary>
        /// Подсчет суммы часов лекций DatagridViewRazdelLeson
        /// </summary>
        /// <returns></returns>
        private double SumLec() {
            double temp = 0;
            foreach(DataGridViewRow Row in this.dataGridViewRazdelLesson.Rows){
                if(Row.Cells["ColumnType"].Value.ToString() == "Лекция"){
                    temp += Convert.ToDouble(Row.Cells["ColumnVolume"].Value);
                }                
            }
            return temp;
        }
        /// <summary>
        /// Подсчет суммы часов практик DatagridViewRazdelLeson
        /// </summary>
        /// <returns></returns>
        private double SumPraktik() {
            double temp = 0;
            foreach (DataGridViewRow Row in this.dataGridViewRazdelLesson.Rows) {
                if (Row.Cells["ColumnType"].Value.ToString() == "Семинар") {
                    temp += Convert.ToDouble(Row.Cells["ColumnVolume"].Value);
                }
            }
            return temp;
        }
        /// <summary>
        /// Подсчет суммы часов сам. работ DatagridViewRazdelLeson
        /// </summary>
        /// <returns></returns>
        private double SumSamost_job() {
            double temp = 0;
            foreach (DataGridViewRow Row in this.dataGridViewRazdelLesson.Rows) {
                if (Row.Cells["ColumnType"].Value.ToString() == "Сам. работа") {
                    temp += Convert.ToDouble(Row.Cells["ColumnVolume"].Value);
                }
            }
            return temp;
        }
        /// <summary>
        /// Пересчет объема часов для тем и разделов в DataGridRazdelLesson
        /// </summary>
        /// <returns></returns>
        private void podshet_hours_in_RazdelLesson() {
            double temp = 0;
            for (int i = 0; i < this.dataGridViewRazdelLesson.RowCount; i++) {
                int j;
                switch (this.dataGridViewRazdelLesson.Rows[i].Cells["ColumnType"].Value.ToString().Trim()) {                    
                    case "Раздел":
                        j = i + 1;
                        while (j <= this.dataGridViewRazdelLesson.RowCount - 1 && this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnType"].Value.ToString().Trim() != "Раздел") {
                            if (this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnType"].Value.ToString().Trim() == "Лекция" ||
                                this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnType"].Value.ToString().Trim() == "Семинар" ||
                                this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnType"].Value.ToString().Trim() == "Сам. работа") {
                                temp += Convert.ToDouble(this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnVolume"].Value);
                            }
                            j++;
                        }
                        this.dataGridViewRazdelLesson.Rows[i].Cells["ColumnVolume"].Value = temp;
                        temp = 0;
                        break;
                    case "Тема":
                        j = i + 1;
                        while (j <= this.dataGridViewRazdelLesson.RowCount - 1 && this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnType"].Value.ToString().Trim() != "Тема") {
                            if (this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnType"].Value.ToString().Trim() == "Лекция" ||
                                this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnType"].Value.ToString().Trim() == "Семинар" ||
                                this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnType"].Value.ToString().Trim() == "Сам. работа") {
                                temp += Convert.ToDouble(this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnVolume"].Value);
                            }
                            j++;
                        }
                        this.dataGridViewRazdelLesson.Rows[i].Cells["ColumnVolume"].Value = temp;
                        temp = 0;
                        break;
                }
            }
        }
        #endregion

        #region вспомогательные методы для основных методов заполнения файла формата *.xml данными из программы
        /// <summary>
        /// Получение составителя УМК в формате: И.О. Фамилия
        /// </summary>
        /// <returns>И.О. Фамилия</returns>
        private string about_prepod(int CodPE) {
            string temp = this.prepodTableAdapter.Get_FIO(CodPE).ToString().Trim();
            //Получаем инициалы + фамилию препода
            string I_O_Fam = temp.Substring(0, temp.IndexOf(' '));
            temp = temp.Remove(0, temp.IndexOf(' ') + 1);
            string I = temp.Substring(0, 1);//инициалы: имя
            temp = temp.Remove(0, temp.IndexOf(" ") + 1);
            string O = temp.Substring(0, 1);//инициалы: отчество
            I_O_Fam = I + "." + O + ". " + I_O_Fam;
            return I_O_Fam;
        }
        /// <summary>
        /// возвращает название факультета в родительном падеже
        /// </summary>
        /// <param name="fac_name">навазние факультета</param>
        /// <returns></returns>
        private string Name_fac_in_rod_padej(byte Cod_fac) {
            string fac_name = this.facultyTableAdapter.Get_NameFaculty(Cod_fac).ToString();
            fac_name = fac_name.Substring(0, fac_name.IndexOf("факультет") - 1);
            return (fac_name.Substring(0, fac_name.Length - 2) + "ого").ToLower();
        }
        /// <summary>
        /// Получение (Фамилия И.О.) в формате (И.О. Фамилия) 
        /// </summary>
        /// <param name="FIO">Фамилия И.О.</param>
        /// <returns></returns>
        private string I_O_Fam_for_ZavKaf_and_Dekan(string FIO) {
            string temp = FIO.Substring(0, FIO.Length - 5);
            temp = FIO.Substring(FIO.IndexOf(' ') + 1, 4) + ' ' + temp;
            return temp;
        }
        /// <summary>
        /// ПОлная информация о преподе: степень + должность + И.О. Фамилия 
        /// </summary>
        /// <param name="CODPE">код преподаваетля</param>
        /// <param name="I_O_Fam">И.О. Фамилия преподавателя</param>
        /// <returns>строка формата: степень + должность + И.О. Фамилия </returns>
        private string full_inf_about_prepod(int CODPE, string I_O_Fam) {            
            string Doljnost = this.doljnost_prepodTableAdapter.Get_Doljnost(CODPE);
            int? Cod_Degree = this.pEOPLENTableAdapter.Get_CodDegree(CODPE);
            if(Doljnost != null){
                if(Doljnost.IndexOf(',') > 0){
                    Doljnost = Doljnost.Substring(0, Doljnost.IndexOf(','));
                }
            }
            if (Cod_Degree != null && Cod_Degree != 0) {
                string Stepen;
                Stepen = this.dEGREETableAdapter.Get_Name_Degree((int)Cod_Degree);
                if (Doljnost != null) {
                    return Stepen.Trim().ToLower() + ", " + Doljnost.Trim().ToLower() + ' ' + I_O_Fam;
                }
                else if(Stepen != null) {
                    return Stepen.Trim().ToLower() + ", " + I_O_Fam;
                }
                else {
                    return I_O_Fam;
                }
            }
            else{
                return Doljnost != null ? Doljnost.Trim().ToLower() + ' ' + I_O_Fam : I_O_Fam; 
            }                
        }
        /// <summary>
        /// Формирует запись с информацией о курсахобучения по выбранной дисциплине
        /// </summary>
        /// <returns>Запись с информацией о курсах, на которых изучалась дисциплина</returns>
        private string Get_Course_obuch() {
            string temp = string.Empty;
            List<int> temp_mas = new List<int>();
            int i = 0;
            foreach(DataGridViewRow Row in this.dataGridView_for_StudyTerm.Rows){
                int temp_int = Convert.ToInt32(Row.Cells["CourseColumn"].Value.ToString());
                if(temp_mas.IndexOf(temp_int) < 0){
                    temp_mas.Add(temp_int);    
                }
            }
            foreach (int temp_int in temp_mas) {
                temp += temp_int.ToString() + ", ";
            }
            return temp.Substring(0, temp.Length - 2);
        }
        /// <summary>
        /// Возвращает семестр, в котором должна быть по дисциплине курсовая работа, если есть
        /// иначе возвращает "-"
        /// </summary>
        /// <returns></returns>
        private string Get_Sem_kurs_job() {
            string temp = string.Empty;
            foreach (DataGridViewRow Row in this.dataGridView_for_studyExams.Rows) {
                if(Row.Cells["CodExType"].Value.ToString().Trim() == "4"){
                    temp += Row.Cells["courseTextBoxColumn"].Value.ToString().Trim() + "." + Row.Cells["numTermTextBoxColumn"].Value.ToString().Trim() + ", ";
                }
            }
            if (temp != string.Empty) {
                return temp.Substring(0, temp.Length - 2);
            }
            else {
                return "-";
            }
        }
        /// <summary>
        /// Возвращает семестр, в котором по дисциплине должен быть зачет, если есть, иначе возвращает "-"
        /// </summary>
        /// <returns></returns>
        private string Get_Sem_zachet() {
            string temp = string.Empty;
            foreach(DataGridViewRow Row in this.dataGridView_for_studyExams.Rows){
                if (Row.Cells["CodExType"].Value.ToString().Trim() == "2" || Row.Cells["CodExType"].Value.ToString().Trim() == "6") {
                    temp += Row.Cells["courseTextBoxColumn"].Value.ToString().Trim() + "." + Row.Cells["numTermTextBoxColumn"].Value.ToString().Trim() + ", "; 
                }
            }
            if(temp != string.Empty){
                return temp.Substring(0, temp.Length - 2);
            }
            else{
                return "-";
            }
        }
        /// <summary>
        /// Возвращает семестр, в котором по дисциплине должен быть экзамен, если есть, иначе возвращает "-"
        /// </summary>
        /// <returns></returns>
        private string Get_Sem_Ekzamen() {
            string temp = string.Empty;
            foreach (DataGridViewRow Row in this.dataGridView_for_studyExams.Rows) {
                if (Row.Cells["CodExType"].Value.ToString().Trim() == "1") {
                    temp += Row.Cells["courseTextBoxColumn"].Value.ToString().Trim() + "." + Row.Cells["numTermTextBoxColumn"].Value.ToString().Trim() + ", "; 
                }
            }
            if (temp != string.Empty) {
                return temp.Substring(0, temp.Length - 2);
            }
            else {
                return "-";
            }
        }
        /// <summary>
        /// Возвращает список семестров, в которых ведется дисциплина
        /// </summary>
        /// <returns></returns>
        private string Get_Sem() {
            string temp = String.Empty;
            foreach (DataGridViewRow Row in this.dataGridView_for_StudyTerm.Rows) {
                temp += Row.Cells["CourseColumn"].Value.ToString().Trim() + "." + Row.Cells["NumTermColumn"].Value.ToString().Trim() + ", ";     
            }
            return temp.Substring(0, temp.Length - 2);
        }
        /// <summary>
        /// Сумма часов лекций/практик/самостоятельной работы, в зависимости от параметра  Value_of_columnType 
        /// для раздела или темы, в зависимости от параметра Razdel_or_Theme
        /// </summary>
        /// <param name="CurrentRow">Строка, с которой начинается описание раздела (или темы)</param>
        /// <param name="Value_of_columnType">Равен "Лекция", "Семинар" или "Сам. работа"</param>
        /// <param name="Razdel_or_Theme">равен "Раздел" или "Тема"</param>
        /// <returns></returns>
        private double Sum_hour_for_razdel_or_theme(int CurrentRow, string Value_of_columnType, string Razdel_or_Theme) {
            double temp = 0;
            CurrentRow++;
            while (CurrentRow < this.dataGridViewRazdelLesson.RowCount && this.dataGridViewRazdelLesson.Rows[CurrentRow].Cells["ColumnType"].Value.ToString() != Razdel_or_Theme) {
                if (this.dataGridViewRazdelLesson.Rows[CurrentRow].Cells["ColumnType"].Value.ToString() == Value_of_columnType) {
                    temp += Convert.ToDouble(this.dataGridViewRazdelLesson.Rows[CurrentRow].Cells["ColumnVolume"].Value);
                }
                CurrentRow++;
            }
            return temp;    
        }
        private string GetShifrDiscip() {
            //шифр дисциплины
            if (this.studyContentsTableAdapter.Get_CodGrSubject((int)Cod_Plan, (short)CodSub) != null) {
                byte cod_uch_circle = Convert.ToByte(this.studyContentsTableAdapter.Get_CodGrSubject((int)Cod_Plan, (short)CodSub).ToString());//CodGrSubject
                string abbr_uch_circle = this.subjectGrsTableAdapter.Get_SubjectGRS(cod_uch_circle).ToString();//аббревиатура учебного цикла SubjectGRS
                int? CodComp = Convert.ToInt32(this.studyContentsTableAdapter.Get_codComp((int)Cod_Plan, (short)CodSub).ToString());//номер по порядку в учебном цикле или плане AbrrComp
                int? Num_discip_in_plan = Convert.ToInt32(this.studyContentsTableAdapter.Get_Num_In_Gr((int)Cod_Plan, (short)CodSub));
                object type_subject = this.studycomponents_plus_studycontentsTableAdapter.Get_AbrrComp((int)CodComp);//тип предметам (например базовый) это CodComp
                return abbr_uch_circle + "." + (type_subject != null ? type_subject.ToString() : string.Empty) + "." + Num_discip_in_plan.ToString();
            }
            else {
                return String.Empty;
            }
        }
        /// <summary>
        /// Обновление значений всех основных переменных, необходимых для сохранения данных программы в формате *.XML
        /// </summary>
        private void GetValues() {
            this.CodFac = (byte?)this.comboBoxFacPrep.SelectedValue;
            this.CodKaf = (byte?)this.comboBoxKaf.SelectedValue;
            this.Cod_Form_study = (byte?)this.comboBox_FormStudy.SelectedValue;
            this.CodTypeEdu = (byte)this.comboBox_TypeEdu.SelectedValue;
          
            this.Cod_Plan = Convert.ToInt32(this.dataGridViewNagruzkaPrep.CurrentRow.Cells["codPlanColumn1"].Value.ToString());

            this.Cod_prep = (int?)this.dataGridViewNagruzkaPrep.CurrentRow.Cells["codPrepOnPlanColumn"].Value;

            this.CodSub = Convert.ToInt16(this.dataGridViewNagruzkaPrep.CurrentRow.Cells["codSubColumn1"].Value.ToString());
            
            ZamDir_po_uchJob = this.pEOPLENTableAdapter.SelectZamDir_po_uch_job();
            Name_Kaf = this.comboBoxKaf.Text;
            CodFacGroup = (byte?)this.grupTableAdapter.GetCodFac_onCodgroup((int)Cod_Plan);  
            Name_discipline = this.dataGridViewNagruzkaPrep.CurrentRow.Cells["nameSubColumn"].Value.ToString().Trim();
            //Шифр дисциплины
            shifr_discipline = this.GetShifrDiscip();

            CodSpeciality = this.specialityTableAdapter.Get_CodSpecGroup((int)Cod_Plan).ToString();
            Name_speciality = (string)this.specialityTableAdapter.Get_NameSpecialityOKSO((int)Cod_Plan);
            //профиль подготовки
            specialization = (string)this.specialityTableAdapter.Get_NameSpecialization((int)Cod_Plan);
            sostavitel = about_prepod( (Cod_prep != 0) ?  (int)Cod_prep : (int) CodPrepWhoEdit);
            //Заведующая кафедрой
            ZavKaf = this.kafsTableAdapter.Get_ZavKaf((byte)CodKaf).ToString().Trim();
            Dekan = this.facultyTableAdapter.Get_Dean((byte)CodFacGroup).ToString().Trim();
            NameFormStudy = this.formStudyTableAdapter.Get_name_formStudy((byte)Cod_Form_study).ToString().Trim();
            HourLab = 0; HourLec = 0; HourSam = 0;
            foreach (DataGridViewRow Row in this.dataGridView_for_StudyTerm.Rows) {
                HourLec += Convert.ToInt32(Row.Cells["LecColumn"].Value);
                HourSam += Convert.ToInt32(Row.Cells["SamColumn"].Value);
                HourLab += Convert.ToInt32(Row.Cells["SemColumn"].Value);
            }
            this.FIO_prepod = this.prepodTableAdapter.Get_FIO((this.Cod_prep != 0) ? (int)this.Cod_prep : (int)this.CodPrepWhoEdit).ToString();
        }
        private void EndEdit_All_DataGRidView() {
            this.dataGridView_for_Liter.EndEdit();
            this.dataGridViewRazdelLesson.EndEdit();
            this.dataGridViewNagruzkaPrep.EndEdit();
            this.Competetion_dataGridView.EndEdit();
            this.dataGridView_Vopros_k_ekz.EndEdit();
            this.dataGridView_for_CurrentControl.EndEdit();
            //Повторное формирование списка ключевых компетенций
            this.sform_spisok_key_compet();
            if (Ur_compit_TabCotrol.TabPages.Count > 0) {
                this.Ur_compit_TabCotrol.Update();
                this.Ur_compit_TabCotrol.SelectedIndex = 0;
                this.table_for_key_compet[0].Update();
                this.table_for_key_compet[0].EndEdit();
            }
        }
        #endregion

        #region методы для заполнения отдельных блоков *.xml файла данными из программы
        /// <summary>
        /// Формирование списка, в котором текст из richTextBox разбивается на абзацы,
        /// в каждый элемент списка представляет собой отдельный абзац, затем  занесение этого списка в XML-документ (writer)
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <returns></returns>
        private void zap_XMl_with_abzac(RichTextBox richTextBox, ref XmlTextWriter writer) {
            List<string> format_result = new List<string>();
            string temp = richTextBox.Text.Trim();
            int number_abzac;
            while ((number_abzac = temp.IndexOf('\n')) >= 0) {
                format_result.Add(temp.Substring(0, number_abzac));
                temp = temp.Remove(0, number_abzac + 1);
            }
            if (temp != String.Empty) {
                format_result.Add(temp.Substring(0, temp.Length));
            }
            if (format_result != null) {
                foreach (string s in format_result) {
                    writer.WriteStartElement("Abzac");
                        writer.WriteAttributeString("Value", s);
                    writer.WriteEndElement();
                }
            }
            else {
                writer.WriteStartElement("Abzac");
                    writer.WriteAttributeString("Value", String.Empty);
                writer.WriteEndElement();
            }
        }
        /// <summary>
        /// Заполнение в XML-документе раздела, содержащего информацию для титульного листа
        /// </summary>
        private void zap_XML_Title_List(ref XmlTextWriter writer) {
            //Информация для считывания информации из XML-файла и дальнейшего открытия этого файла в программе
            writer.WriteStartElement("Title_inf_for_program");
                writer.WriteAttributeString("comboBoxFacPrep", this.comboBoxFacPrep.SelectedValue.ToString().Trim());
                //код кафедры для дициплины/преподавателя (не стал изменять для совместимости со старыми РПД/УМК)
                writer.WriteAttributeString("CodKafPrep", this.comboBoxKaf.SelectedValue.ToString().Trim());
                writer.WriteAttributeString("CodFac", CodFac.ToString().Trim());
                //код преподавателя по нагрузке
                writer.WriteAttributeString("Cod_prep", this.Cod_prep.ToString().Trim());
                //код преподавателя, который сделал РПД/УМК
                writer.WriteAttributeString("CodPrepWhoEdit", (this.CodPrepWhoEdit != null) ? this.CodPrepWhoEdit.ToString() : String.Empty);
                writer.WriteAttributeString("CodPlan", this.Cod_Plan.ToString());
                //а фиг знает, зачем надо теперь) -> writer.WriteAttributeString("CodGroup", Cod_group.ToString().Trim());
                writer.WriteAttributeString("CodSub", CodSub.ToString().Trim());
                //Год учебного плана
                writer.WriteAttributeString("Year", numericUpDown.Value.ToString().Trim());
                writer.WriteAttributeString("DateSave", this.dateTimePicker1.Value.ToString().Trim());
            writer.WriteEndElement();
            writer.WriteStartElement("Title");
                int CodZamDir = Convert.ToInt32(this.prepodTableAdapter.Get_CodPE_po_Fam(ZamDir_po_uchJob.Trim()));
                writer.WriteAttributeString("ZamDir_po_uchJob", full_inf_about_prepod(Convert.ToInt32(this.prepodTableAdapter.Get_CodPE_po_Fam(ZamDir_po_uchJob.Substring(0, ZamDir_po_uchJob.IndexOf(' ')))), about_prepod(CodZamDir)));          
                writer.WriteAttributeString("Kaf_for_prep", Name_Kaf.Trim());
                writer.WriteAttributeString("ZavKaf_forKaf_for_prep", full_inf_about_prepod(Convert.ToInt32(this.prepodTableAdapter.Get_CodPE_po_Fam(ZavKaf.Substring(0, ZavKaf.Length - 5)).ToString()), I_O_Fam_for_ZavKaf_and_Dekan(ZavKaf)));
                writer.WriteAttributeString("Name_discip", Name_discipline);
                writer.WriteAttributeString("Shift_discip", shifr_discipline);
                writer.WriteAttributeString("Cod_Speciality", CodSpeciality);
                writer.WriteAttributeString("Name_speciality", Name_speciality);
                writer.WriteAttributeString("Specialization", specialization);
                if (this.Text == "РПД") {
                    writer.WriteAttributeString("FormaOb", this.formStudyTableAdapter.Get_name_formStudy((byte)Cod_Form_study).ToString());
                }
                writer.WriteAttributeString("Year", System.DateTime.Now.Year.ToString());
            writer.WriteEndElement();
            //Для второй страницы
            writer.WriteStartElement("Two_str");                
                writer.WriteAttributeString("Sostavitel", sostavitel);
                if (this.Text == "УМК") {
                    writer.WriteAttributeString("Full_inf_about_Sostavitel", full_inf_about_prepod( this.Cod_prep != 0 ?  (int)Cod_prep : (int)this.CodPrepWhoEdit, sostavitel));
                }
                else {
                    string temp = full_inf_about_prepod(this.Cod_prep != 0 ? (int)Cod_prep : (int)this.CodPrepWhoEdit, sostavitel);
                    writer.WriteAttributeString("Full_inf_about_Sostavitel", temp.Substring(0, temp.Length - sostavitel.Length));
                }
                writer.WriteAttributeString("Kaf_for_prep", Name_Kaf.Trim().ToLower());
                //факультет плана(группы)
                writer.WriteAttributeString("NameFac", this.Name_fac_in_rod_padej((byte)CodFacGroup));
                //кафедра плана (группы)
                writer.WriteAttributeString("NameKaf", this.kafsTableAdapter.GetNameKaf(Convert.ToByte(this.dataGridViewNagruzkaPrep.CurrentRow.Cells["codKafPlanColumn"].Value)).ToLower());
                //Зав. кафедрой для плана (группы)
                string ZavKaf_for_Plan = this.kafsTableAdapter.Get_ZavKaf(Convert.ToByte(this.dataGridViewNagruzkaPrep.CurrentRow.Cells["codKafPlanColumn"].Value)).ToString();
                writer.WriteAttributeString("ZavKafForKafPlan", full_inf_about_prepod(Convert.ToInt32(this.prepodTableAdapter.Get_CodPE_po_Fam(ZavKaf_for_Plan.Substring(0, ZavKaf_for_Plan.Length - 5)).ToString()), I_O_Fam_for_ZavKaf_and_Dekan(ZavKaf_for_Plan)));
                writer.WriteAttributeString("Dean", full_inf_about_prepod(Convert.ToInt32(this.prepodTableAdapter.Get_CodPE_po_Fam(Dekan.Substring(0, Dekan.Length - 5)).ToString()), I_O_Fam_for_ZavKaf_and_Dekan(Dekan)));
            writer.WriteEndElement();
        }
        /// <summary>
        /// Заполнение в XML-документе разделов, содержащих информацию о целях изучения дисциплины, ее месте в структуре ООП
        /// и компетенции обучающегося
        /// </summary>
        /// <param name="writer"></param>
        private void zap_XML_GoalsDisc_PlaceOOP_Compet(ref XmlTextWriter writer) {
            //"Цели изучения дисциплины"
            writer.WriteStartElement("GoalsDisciplin");                  
                zap_XMl_with_abzac(richTextBox1, ref  writer);
            writer.WriteEndElement();
            //"Место дисциплины в структуре ООП бакалавриата"
            writer.WriteStartElement("PlaceOOP");
                //печатаем первое предложение раздела "Место дисциплины в структуре ООП"
                writer.WriteStartElement("AboutPlaceOOP");
                    if (this.studyContentsTableAdapter.Get_CodGrSubject((int)Cod_Plan, (short)CodSub) != null) {
                        byte CodGrSubject = Convert.ToByte(this.studyContentsTableAdapter.Get_CodGrSubject((int)Cod_Plan, (short)CodSub).ToString());//CodGrSubject
                        string NameGrSubject = this.subjectGrsTableAdapter.GetNameGRSub(CodGrSubject).ToString().Trim().ToLower();
                        writer.WriteAttributeString("Value", "Дисциплина " + shifr_discipline.Trim() + " «" + Name_discipline + "» " + "входит в " + NameGrSubject + ".");
                    }                      
                writer.WriteEndElement();
                zap_XMl_with_abzac(richTextBox2, ref writer);
            writer.WriteEndElement();
            writer.WriteStartElement("Competetion");
            //Вывод компетенций
                for (int i = 0; i < Competetion_dataGridView.RowCount; i++) {
                    writer.WriteStartElement("Row");
                    writer.WriteAttributeString("CodCompetencii", Competetion_dataGridView.Rows[i].Cells["CodKompetencii"].Value.ToString());
                    writer.WriteAttributeString("Competencia", Competetion_dataGridView.Rows[i].Cells["Kompetenc"].Value.ToString());
                    if (Competetion_dataGridView["Key_compet", i].Value != null && Competetion_dataGridView["Key_compet", i].Value.ToString() == "True") {
                        writer.WriteAttributeString("KeyCompet", "True");
                    }
                    else {
                        writer.WriteAttributeString("KeyCompet", "False");
                    }
                    writer.WriteEndElement();
                }
            writer.WriteEndElement();
            string s = String.Empty;
                            
            if (this.Ur_compit_TabCotrol.Controls.Count > 0) {
                this.Ur_compit_TabCotrol.TabPages.GetEnumerator().Reset();
                foreach (System.Windows.Forms.TabPage Page in this.Ur_compit_TabCotrol.TabPages) {
                    this.Ur_compit_TabCotrol.TabPages.GetEnumerator();
                    s += Page.Text.ToString().Trim() + ", ";
                    this.Ur_compit_TabCotrol.TabPages.GetEnumerator().MoveNext();
                }
                s = s.Substring(0, s.Length - 2);
            }
            //Вывод списком всех ключевых компетенций
            writer.WriteStartElement("All_key_compet"); 
                writer.WriteAttributeString("Value", s); 
            writer.WriteEndElement();
            //Вывод ключевых компетенций с их описанием
            writer.WriteStartElement("Key_compet");
                for (int i = 0; i < this.Ur_compit_TabCotrol.TabPages.Count; i++) {
                    writer.WriteStartElement("Competetion");
                    writer.WriteAttributeString("Name", Ur_compit_TabCotrol.TabPages[i].Text.Trim());
                    foreach (DataGridViewRow grid in table_for_key_compet[i].Rows) {
                        writer.WriteStartElement("Yr_compet");
                        //Уровень освоения
                        writer.WriteAttributeString("ur_osv", grid.Cells["Uroven"].Value.ToString().Trim());
                        //признак освоения
                        writer.WriteAttributeString("priznak_osv", grid.Cells["Opisanie"].Value != null ? grid.Cells["Opisanie"].Value.ToString().Trim() : String.Empty);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
            writer.WriteEndElement();
            //"Студент должен знать"
            writer.WriteStartElement("Student_must_znat");
                zap_XMl_with_abzac(richTextBoxTreb31, ref writer); 
            writer.WriteEndElement();
            //"Студент должен уметь"
            writer.WriteStartElement("Student_must_umet");
                zap_XMl_with_abzac(richTextBoxTreb32, ref writer); 
            writer.WriteEndElement();
            //"Студент должен владеть"
            writer.WriteStartElement("Student_must_vladet");
                zap_XMl_with_abzac(richTextBoxTreb33, ref writer);
            writer.WriteEndElement();
        }
        /// <summary>
        /// Заполнение в XML-документе раздела, описывающего содержание разделов дисциплины
        /// только для УМК
        /// </summary>
        private void zap_XML_soderj_discip(ref XmlTextWriter writer) {
            //временные переменные для хранения суммы часов лекций, практик и самостоятельных DataGridViewRazdelLesson
            double sum_hour_Lec, sum_hour_Sem, sum_hour_samjob;
            int number_razdel = 1;
            int number_theme = 1;
            int number_Lec = 1;
            int number_Praktik = 1;
            int number_SamJob = 1;
            string name_theme = string.Empty;
            for (int i = 0; i < this.dataGridViewRazdelLesson.RowCount; i++) {
                if((this.dataGridViewRazdelLesson.Rows[i].Cells["ColumnType"].Value.ToString().Trim() == "Раздел")){
                    writer.WriteStartElement("Razdel");
                        //Номер раздела
                        writer.WriteAttributeString("Id", number_razdel.ToString());
                        //Полное название раздела
                        writer.WriteAttributeString("Name", "Раздел " + number_razdel.ToString() + '.');
                        //Семестр, в котором изучается раздел
                        writer.WriteAttributeString("Semestr", (this.dataGridViewRazdelLesson.Rows[i].Cells["Semestr"].Value != null) ? this.dataGridViewRazdelLesson.Rows[i].Cells["Semestr"].Value.ToString() : String.Empty);
                        //Описание раздела (название темы)
                        writer.WriteAttributeString("About_razdel", this.dataGridViewRazdelLesson.Rows[i].Cells["ColumnTheme"].Value.ToString());
                        //Объем часов для раздела (лекции)
                        writer.WriteAttributeString("SumLec", this.Sum_hour_for_razdel_or_theme(i, "Лекция", "Раздел").ToString());
                        //Объем часов для раздела (практические занятия)
                        writer.WriteAttributeString("SumPraktik", this.Sum_hour_for_razdel_or_theme(i, "Семинар", "Раздел").ToString());
                        //Объем часов для раздела (самостоятенльая работа)
                        writer.WriteAttributeString("SumSamJob", this.Sum_hour_for_razdel_or_theme(i, "Сам. работа", "Раздел").ToString());
                        //Если столбец с формой текущего контроля успеваемости datagridViewRazdelLesson видим, а значит заполняется РПД
                        if (this.dataGridViewRazdelLesson.Columns["FormCurControlColumn"].Visible == true) {
                            /*if (this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value != null) {
                                //это IdSredstv из таблицы EvaluationTools для того, чтобы было возможно корректно загрузить данные в программу из фалйа *.Xml
                                writer.WriteAttributeString("IdFormCurControl", this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value.ToString());
                                //Аббревиатура формы оценочного средства успеваемости
                                writer.WriteAttributeString("FormCurControl", this.ocenSredstvTableAdapter.GetAbbrSredstv((Int16)this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value).ToString().Trim());
                            }
                            else {
                                //это IdSredstv из таблицы EvaluationTools для того, чтобы было возможно корректно загрузить данные в программу из фалйа *.Xml
                                writer.WriteAttributeString("IdFormCurControl", (this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value != null) ? this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value.ToString() : String.Empty);
                                //Аббревиатура формы оценочного средства успеваемости
                                writer.WriteAttributeString("FormCurControl", (this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value != null) ? this.ocenSredstvTableAdapter.GetAbbrSredstv((Int16)this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value).ToString().Trim() : String.Empty);
                            }*/
                            writer.WriteAttributeString("FormCurControl", (this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value != null) ? this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value.ToString() : string.Empty);
                        }
                        int j = i + 1;
                        while (j < this.dataGridViewRazdelLesson.RowCount && this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnType"].Value.ToString() != "Раздел") {
                            if (this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnType"].Value.ToString() == "Тема") {
                                writer.WriteStartElement("Theme");
                                    name_theme = this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnTheme"].Value.ToString();
                                    //Номер темы
                                    writer.WriteAttributeString("Id", number_razdel.ToString() + '.' + number_theme.ToString());
                                    //Полное название темы  
                                    writer.WriteAttributeString("Name", "Тема " + number_razdel.ToString() + '.' + number_theme.ToString() + '.');
                                    //Семестр, в котором изучается тема
                                    writer.WriteAttributeString("Semestr", (this.dataGridViewRazdelLesson.Rows[j].Cells["Semestr"].Value != null) ? this.dataGridViewRazdelLesson.Rows[j].Cells["Semestr"].Value.ToString() : String.Empty);
                                    //Описание темы (название темы)
                                    writer.WriteAttributeString("About_theme", name_theme);
                                    //Объем часов для темы (лекции)
                                    sum_hour_Lec = this.Sum_hour_for_razdel_or_theme(j, "Лекция", "Тема");
                                    writer.WriteAttributeString("SumLec", sum_hour_Lec != 0 ? sum_hour_Lec.ToString() : "-");
                                    //Объем часов для темы (практические занятия)
                                    sum_hour_Sem = this.Sum_hour_for_razdel_or_theme(j, "Семинар", "Тема");
                                    writer.WriteAttributeString("SumPraktik", sum_hour_Sem != 0 ? sum_hour_Sem.ToString() : "-");
                                    //Объем часов для темы (самостоятенльая работа)
                                    sum_hour_samjob = this.Sum_hour_for_razdel_or_theme(j, "Сам. работа", "Тема");
                                    writer.WriteAttributeString("SumSamJob", sum_hour_samjob != 0 ? sum_hour_samjob.ToString() : "-");
                                    //Если столбец с формой текущего контроля успеваемости datagridViewRazdelLesson видим, а значит заполняется РПД
                                    if(this.dataGridViewRazdelLesson.Columns["FormCurControlColumn"].Visible == true){                                           
                                        /*if(this.dataGridViewRazdelLesson.Rows[j].Cells["FormCurControlColumn"].Value != null){
                                            //это IdSredstv из таблицы EvaluationTools для того, чтобы было возможно корректно загрузить данные в программу из фалйа *.Xml
                                            writer.WriteAttributeString("IdFormCurControl", this.dataGridViewRazdelLesson.Rows[j].Cells["FormCurControlColumn"].Value.ToString());
                                            //Аббревиатура формы оценочного средства успеваемости
                                            writer.WriteAttributeString("FormCurControl", this.ocenSredstvTableAdapter.GetAbbrSredstv((Int16)this.dataGridViewRazdelLesson.Rows[j].Cells["FormCurControlColumn"].Value).ToString().Trim());
                                        }
                                        else {
                                            //это IdSredstv из таблицы EvaluationTools для того, чтобы было возможно корректно загрузить данные в программу из фалйа *.Xml
                                            writer.WriteAttributeString("IdFormCurControl", (this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value != null) ? this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value.ToString() : String.Empty);
                                            //Аббревиатура формы оценочного средства успеваемости
                                            writer.WriteAttributeString("FormCurControl", (this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value != null) ? this.ocenSredstvTableAdapter.GetAbbrSredstv((Int16)this.dataGridViewRazdelLesson.Rows[i].Cells["FormCurControlColumn"].Value).ToString().Trim() : String.Empty);
                                        } */
                                        writer.WriteAttributeString("FormCurControl", (this.dataGridViewRazdelLesson.Rows[j].Cells["FormCurControlColumn"].Value != null) ? this.dataGridViewRazdelLesson.Rows[j].Cells["FormCurControlColumn"].Value.ToString() : string.Empty);
                                    }                                    
                                    j++;
                                    int k = j;
                                    //Описание содержания лекционных занятий
                                    writer.WriteStartElement("Lecsii");
                                        while (k < this.dataGridViewRazdelLesson.RowCount && this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnType"].Value.ToString() != "Тема") {
                                            if (this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnType"].Value.ToString() == "Лекция") {
                                                writer.WriteStartElement("Lec");
                                                    writer.WriteAttributeString("Name", "Лекция " + number_Lec.ToString() + '.');
                                                    writer.WriteAttributeString("About_Lec", this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnTheme"].Value.ToString());
                                                    writer.WriteAttributeString("Hours", (this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnVolume"].Value != null ? this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnVolume"].Value.ToString() : "0"));
                                                    writer.WriteAttributeString("Name_Theme", name_theme);
                                                writer.WriteEndElement();
                                                number_Lec++;
                                            }
                                            k++;
                                        }        
                                    writer.WriteEndElement();
                                    k = j;
                                    //Описание содержания Практических занятий
                                    writer.WriteStartElement("Praktiki");
                                        while (k < this.dataGridViewRazdelLesson.RowCount &&  this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnType"].Value.ToString() != "Тема") {
                                            if (this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnType"].Value.ToString() == "Семинар") {
                                                writer.WriteStartElement("Praktika");
                                                    writer.WriteAttributeString("Name", "Занятие " + number_Praktik.ToString() + '.');
                                                    writer.WriteAttributeString("About_praktik", (this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnTheme"].Value != null) ? this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnTheme"].Value.ToString() : String.Empty);
                                                    writer.WriteAttributeString("Hours", (this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnVolume"].Value != null ? this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnVolume"].Value.ToString() : "0"));
                                                    writer.WriteAttributeString("NumRazdel", "Раздел " + number_razdel.ToString());
                                                    writer.WriteAttributeString("NumTheme", "Тема " + number_theme.ToString());
                                                writer.WriteEndElement();
                                                number_Praktik++;
                                            }
                                            k++;
                                        } 
                                    writer.WriteEndElement();
                                    k = j;
                                    //Описание содержания самостоятеных работ
                                    writer.WriteStartElement("Sam_Job");
                                        while (k < this.dataGridViewRazdelLesson.RowCount && this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnType"].Value.ToString() != "Тема") {
                                            if (this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnType"].Value.ToString() == "Сам. работа") {
                                                writer.WriteStartElement("SamJob");
                                                    writer.WriteAttributeString("Name", "Занятие " + number_SamJob.ToString() + '.');
                                                writer.WriteAttributeString("About_samJob", (this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnTheme"].Value != null) ? this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnTheme"].Value.ToString() : String.Empty);
                                                    writer.WriteAttributeString("Hours", (this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnVolume"].Value != null ? this.dataGridViewRazdelLesson.Rows[k].Cells["ColumnVolume"].Value.ToString() : "0"));
                                                    writer.WriteAttributeString("Name_Theme", name_theme.Trim());
                                                writer.WriteEndElement();
                                                number_SamJob++;
                                            }
                                            k++;
                                        }
                                    writer.WriteEndElement();
                                writer.WriteEndElement();
                                number_Lec = 1;
                                number_Praktik = 1;
                                number_SamJob = 1;
                                number_theme++;
                            }
                            j++;
                        }
                    writer.WriteEndElement();
                    number_razdel++;
                    number_theme = 1;
                }
            }                        
        }
        /// <summary>
        /// Заполнение в XML-документе раздела, содержащего список используемой литературы
        /// </summary>
        /// <param name="writer"></param>
        private void zap_XML_Recommand_literature(ref XmlTextWriter writer){
            //Основная литература
            for(int i = 0 ; i < this.dataGridView_for_Liter.RowCount - 1; i++){
                switch (this.dataGridView_for_Liter.Rows[i].Cells["Type_liter"].Value.ToString()) {
                    case "Основная" :
                        writer.WriteStartElement("Main_Liter");
                            writer.WriteAttributeString("Author", this.dataGridView_for_Liter.Rows[i].Cells["Author"].Value.ToString().Trim());
                        writer.WriteEndElement();
                        break;
                    case "Дополнительная" :
                        writer.WriteStartElement("Dop_Liter");
                            writer.WriteAttributeString("Author", this.dataGridView_for_Liter.Rows[i].Cells["Author"].Value.ToString().Trim());
                        writer.WriteEndElement();
                        break;
                    case "Электронный ресурс" :
                        writer.WriteStartElement("Elektr_Resourse");
                            writer.WriteAttributeString("Author", this.dataGridView_for_Liter.Rows[i].Cells["Author"].Value.ToString().Trim());
                        writer.WriteEndElement();
                        break;
                }
                
            }
        }
        /// <summary>
        /// Заполнение *.Xml файла данными из sdataGridView_for_CurrentControl
        /// </summary>
        /// <param name="writer"></param>
        private void Zap_XML_Data_from_DatagridviewCurrentControl(ref XmlTextWriter writer) {
            for (int i = 0; i < this.dataGridView_for_CurrentControl.RowCount - 1; i++) {
                DataGridViewRow Row = this.dataGridView_for_CurrentControl.Rows[i];
                writer.WriteStartElement("Row");
                // ячейка "Контрольные мероприятия по дисциплине"
                writer.WriteAttributeString("Name_meropriyatie", (Row.Cells["ControlColumn"].Value != null ? Row.Cells["ControlColumn"].Value.ToString() : String.Empty));
                //Количество баллов 
                writer.WriteAttributeString("Ball", Row.Cells["Kol_vo_ball"].Value != null ? Row.Cells["Kol_vo_ball"].Value.ToString() : String.Empty);
                //Номера тем в формате: Тема + Номер раздела + "." + Номер темы + "."
                writer.WriteAttributeString("Num_theme", Row.Cells["Razdel_theme_column"].Value != null ? Row.Cells["Razdel_theme_column"].Value.ToString() : String.Empty);
                writer.WriteEndElement();
            }
                
            /*for (int i = 0; i < this.dataGridView_for_CurrentControl.RowCount - 1; i++) {
                    NumRazdel = 0;
                    NumTheme = 0;
                    writer.WriteStartElement("Row");
                        // ячейка "Контрольные мероприятия по дисциплине"
                        writer.WriteAttributeString("Idmeropriyatie", 
                                                    (this.dataGridView_for_CurrentControl.Rows[i].Cells["ControlColumn"].Value != null ? 
                                                    this.dataGridView_for_CurrentControl.Rows[i].Cells["ControlColumn"].Value.ToString() : 
                                                    string.Empty));                                                    
                        writer.WriteAttributeString("Name_meropriyatie",
                                                    (this.dataGridView_for_CurrentControl.Rows[i].Cells["ControlColumn"].Value != null ?
                                                    this.ocenSredstvTableAdapter.GetNameSredstv((Int16)this.dataGridView_for_CurrentControl.Rows[i].Cells["ControlColumn"].Value).ToString().Trim() : 
                                                    string.Empty));
                        //Количество баллов
                        writer.WriteAttributeString("Ball", this.dataGridView_for_CurrentControl.Rows[i].Cells["Kol_vo_ball"].Value != null ? 
                                                            this.dataGridView_for_CurrentControl.Rows[i].Cells["Kol_vo_ball"].Value.ToString() : 
                                                            "0");
                        //Номер раздела и темы
                        for(int j = 0; j < this.dataGridViewRazdelLesson.RowCount; j++){
                            if(this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnType"].Value.ToString() == "Раздел"){
                                NumRazdel++;
                                NumTheme = 0;
                            } 
                            if(this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnType"].Value.ToString() == "Тема"){
                                NumTheme++;
                                if (this.dataGridViewRazdelLesson.Rows[j].Cells["ColumnTheme"].Value.ToString() == this.dataGridView_for_CurrentControl.Rows[i].Cells["Razdel_theme_column"].Value.ToString()) {
                                    break;
                                }
                            }
                        }
                        writer.WriteAttributeString("Num_razdel", "Раздел " + NumRazdel.ToString().Trim() + ".");
                        writer.WriteAttributeString("Num_theme", "Тема " + NumRazdel.ToString().Trim() + "." + NumTheme.ToString().Trim() + ".");
                    writer.WriteAttributeString("Name_Theme", (this.dataGridView_for_CurrentControl.Rows[i].Cells["Razdel_theme_column"].Value != null) ? this.dataGridView_for_CurrentControl.Rows[i].Cells["Razdel_theme_column"].Value.ToString() : String.Empty);
                    writer.WriteEndElement();
                }
                 */
        }

        /// <summary>
        /// Заполнение в XML-документе раздела, содержащего инфомрацию об организации текущего контроля
        /// </summary>
        /// <param name="writer"></param>
        private void zap_XML_CurrentControl(ref XmlTextWriter writer) {
            //string Name_razdel, Name_Theme;
            dataGridView_for_CurrentControl.EndEdit();
            dataGridView_Vopros_k_ekz.EndEdit();
            //int NumRazdel = 0, NumTheme = 0;
            writer.WriteStartElement("CurControl");
                //Для пункта "4.1. Организация текущего контроля"
                Zap_XML_Data_from_DatagridviewCurrentControl(ref writer);                 
            writer.WriteEndElement();
            //Форма и правила проведения зачета/экзамена
            writer.WriteStartElement("Form_and_rules_attestat");
                zap_XMl_with_abzac(richTextBox_for_pravila_proved_attest, ref writer);
            writer.WriteEndElement();
            //Вопросы к экзамену/зачету
            writer.WriteStartElement("Voprosy_k_ekz");
                for (int i = 0; i < this.dataGridView_Vopros_k_ekz.RowCount - 1; i++) {
                    writer.WriteStartElement("Vopros");
                        writer.WriteAttributeString("Value", this.dataGridView_Vopros_k_ekz.Rows[i].Cells[0].Value.ToString().Trim());
                    writer.WriteEndElement();
                }            
            writer.WriteEndElement();
            //Образцы экзаменационных тестов, заданий
            writer.WriteStartElement("Example_ekz_Unit");
                zap_XMl_with_abzac(richTextBox3, ref writer);
            writer.WriteEndElement();
        }
        /// <summary>
        /// Общая структура дисциплины
        /// </summary>
        /// <param name="writer"></param>
        private void zap_XML_Struct_discip(ref XmlTextWriter writer) {
            ZET = 0;
            for (int i = 0; i < this.dataGridView_for_StudyTerm.RowCount; i++) {
                ZET += Convert.ToInt32(this.dataGridView_for_StudyTerm.Rows[i].Cells["ECTScredits"].Value.ToString());
            }
            //количество зачетных единиц
            writer.WriteAttributeString("ZET", ZET.ToString());
            //общее количество часов
            writer.WriteAttributeString("All_hours", (36 * ZET).ToString());
            //Форма обучения
            writer.WriteAttributeString("FormaOb", NameFormStudy.Substring(0, NameFormStudy.Length - 2) + "ое обучение");
            //Курс обучения
            writer.WriteAttributeString("Course", Get_Course_obuch());
            //Семесры, в которых должна преподаваться дисциплина
            writer.WriteAttributeString("Semestr", Get_Sem());
            //Часы лекций
            writer.WriteAttributeString("HourLec", HourLec.ToString());
            //Часы практик (саминары + лабы)
            writer.WriteAttributeString("HourPraktik", (HourLab).ToString());
            //Часы самостоятельных работ
            writer.WriteAttributeString("HourSam", HourSam.ToString());
            //Семестр курсовой работы, если конечно есть)
            writer.WriteAttributeString("Kursov_job", Get_Sem_kurs_job());
            //Семестр зачета, если конечно есть)
            writer.WriteAttributeString("Zachet", Get_Sem_zachet());
            //Семестр экзамена, если есть
            writer.WriteAttributeString("Ekzamen", Get_Sem_Ekzamen());
        }        
        /// <summary>
        /// Открытие диалога SaveFileDialog для выбора пути сохранения *.XML документа
        /// </summary>
        /// <returns>Если ошибок не возникло, то функция возвратит True, иначе - False</returns>
        private bool SaveDialogOpen(HowDoc_Save howdocsave) {
            //Начинаем заполнять *.xml файл
            Stream myStream = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = (this.Text == "УМК") ? Properties.Settings.Default.Setting_for_SaveUMK : Properties.Settings.Default.Setting_for_SaveRPD;
            saveFileDialog.FileName = saveFileDialog.InitialDirectory + "\\" +
                                    ( howdocsave == HowDoc_Save.SaveAnnotationToRPD ? "Аннотация к РПД" : this.Text )  + "_" +
                                    this.GetShifrDiscip() + "_" +
                                    this.specialityTableAdapter.Get_CodSpecGroup((short)Cod_Plan).ToString().Trim() + "_" +
                                    this.dataGridViewNagruzkaPrep.CurrentRow.Cells["nameSubColumn"].Value.ToString().Trim() + "_" +
                                    this.FIO_prepod.Trim();
            if (howdocsave == HowDoc_Save.SaveToXml) {
                saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";    
            }
            else {
                saveFileDialog.Filter = "WordDoc (*.docx)|*.docx|All files (*.*)|*.*";
            }
            saveFileDialog.FilterIndex = 1;
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                try {
                    if ((myStream = saveFileDialog.OpenFile()) != null) {
                        using (myStream) {
                            save_path = saveFileDialog.FileName;
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка: Невозможно прочитать файл с диска. Original error: " + ex.Message);
                    return false;
                }
            }
            else {
                return false;
            }
            return true;
        }
        #endregion

        #region методы для окончательного заполнения файла *.xml данными из программы
        /// <summary>
        /// Сохранение УМК в формате XML
        /// </summary>
        private void Save_UMK_to_xml(ref XmlTextWriter writer) {
            this.EndEdit_All_DataGRidView();
            writer.WriteStartDocument();
            writer.WriteStartElement("umk");
                zap_XML_Title_List(ref writer);
                //Для раздела "Пояснительная записка"
                writer.WriteStartElement("UMK_razdel_1");
                    writer.WriteStartElement("Data");
                        zap_XML_GoalsDisc_PlaceOOP_Compet(ref writer);
                    writer.WriteEndElement();
                writer.WriteEndElement();
                //Формирования раздела 2 "Структура дисциплины"
                writer.WriteStartElement("Razdel_2");
                    //Для раздела 2.1. "Трудоемкость дисциплины и ее общая структура"
                    writer.WriteStartElement("Struct_discip");
                        //Здесь содержится информации о курсе обучения, 
                        //семестрах, сумме часов лекций, практик и самостятельных работ
                        writer.WriteStartElement("Main_inform");
                            zap_XML_Struct_discip(ref writer);
                        writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteStartElement("Soderjanie_razd_discip");
                        writer.WriteAttributeString("FormaOb", this.formStudyTableAdapter.Get_name_formStudy((byte)Cod_Form_study).ToString());
                        zap_XML_soderj_discip(ref writer);
                    writer.WriteEndElement();
                writer.WriteEndElement();
                //Формирование раздела 3.2. "Список используемой литературы"
                writer.WriteStartElement("Recommand_literature");
                    zap_XML_Recommand_literature(ref writer);
                writer.WriteEndElement();
                //Формирование раздела 4. "Организация текущего контроля успеваемости и промежуточной аттестации по итогам освоения дисциплины "
                writer.WriteStartElement("CurrentControl");
                    zap_XML_CurrentControl(ref writer);
                writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            if (!(writer.BaseStream is MemoryStream)) {
                writer.Close();
            }
        }         
        /// <summary>
        /// Сохранение РПД в файл *.XML
        /// </summary>
        private void Save_RPD_to_XML(ref XmlTextWriter writer) {
            //this.GetValues();
            writer.WriteStartDocument();                 
                writer.WriteStartElement("RPD");
                    //Для титульного листа
                    zap_XML_Title_List(ref writer);
                    //Заполнение информации для разделов "1. Цели освоения дисциплины",
                    //"2. Место дисциплины в структуре ООП бакалавриата",
                    //"3. Компетенции обучающегося, формируемые в результате освоения дисциплины"
                    writer.WriteStartElement("RPD_1_2_3");
                        writer.WriteStartElement("Data");
                            zap_XML_GoalsDisc_PlaceOOP_Compet(ref writer);
                        writer.WriteEndElement();
                        //Для заполнения таблицы "Структура дисциплины" титульного листа
                        writer.WriteStartElement("Struct_Discip");
                            //Здесь содержится информации о курсе обучения, 
                            //семестрах, сумме часов лекций, практик и самостятельных работ
                            zap_XML_Struct_discip(ref writer);
                        writer.WriteEndElement();
                    writer.WriteEndElement();                    
                    writer.WriteStartElement("RPD_4_5");
                        //Формирования разделов "4. Структура и содержание дисциплины"
                        writer.WriteStartElement("Soderjanie_razd_discip");
                            zap_XML_soderj_discip(ref writer);
                            //Заполнение перечня оценочных средств для формы текущего контроля успеваемости
                            writer.WriteStartElement("SpisokOcenSredstv");
                                DataTable OcenSredstvTable = this.ocenSredstvTableAdapter.GetData();
                                foreach (DataRow Row in OcenSredstvTable.Rows) {
                                    writer.WriteStartElement("OcenSredstv");
                                        writer.WriteAttributeString("AbbrSredstv", Row["AbbrSredstv"].ToString().Trim());
                                        writer.WriteAttributeString("NameSredstv", Row["NameSredstv"].ToString().Trim());
                                    writer.WriteEndElement();
                                }
                            writer.WriteEndElement();
                            //"4.4. Вид и форма промежуточной аттестации"
                            writer.WriteStartElement("Type_and_Form_promej_control");
                                zap_XMl_with_abzac(this.richTextBox4, ref writer);
                            writer.WriteEndElement();
                        writer.WriteEndElement();
                        //"5. Используемые образовательные технологии"
                        writer.WriteStartElement("Obraz_technology");
                            zap_XMl_with_abzac(this.richTextBox5, ref writer);
                            //"Доля занятий с использованием активных и интерактивных методов"
                            writer.WriteStartElement("Part_zanyatii");
                                writer.WriteAttributeString("Value", this.textBox_for_Dolya_interaktiv_method.Text.Trim());
                            writer.WriteEndElement();
                        writer.WriteEndElement();
                    writer.WriteEndElement();
                    //"Оценочные средства для текущего контроля успеваемости, 
                    //промежуточной аттестации по итогам освоения дисциплины и 
                    //учебно-методическое обеспечение самостоятельной работы студентов"
                    writer.WriteStartElement("RPD_6");
                        //"6.1. Текущий контроль"
                        writer.WriteStartElement("CurrentControl");
                            //zap_XMl_with_abzac(this.richTextBox6, ref writer);
                            Zap_XML_Data_from_DatagridviewCurrentControl(ref writer);
                        writer.WriteEndElement();
                        //"6.2. Образцы тестовых и контрольных заданий текущего контроля"
                        writer.WriteStartElement("Example_Zad_CurControl");
                            zap_XMl_with_abzac(this.richTextBox9, ref writer);
                        writer.WriteEndElement();
                        //"6.3. Примерная тематика рефератов, эссе, докладов "
                        writer.WriteStartElement("Theme_Referats");
                            zap_XMl_with_abzac(this.richTextBox8, ref writer);
                        writer.WriteEndElement();
                        //"6.4. Примерные темы курсовых работ, критерии оценивания"
                        writer.WriteStartElement("Theme_KursJob");
                            zap_XMl_with_abzac(this.richTextBox7, ref writer);
                        writer.WriteEndElement();
                        //"6.5. Методические указания по организации самостоятельной работы"
                        writer.WriteStartElement("MethodUkaz_SamJob");
                            zap_XMl_with_abzac(this.richTextBox14, ref writer);
                        writer.WriteEndElement();
                        //"6.6. Промежуточный контроль"
                        writer.WriteStartElement("Promej_Control");
                            //первый раздел без названия
                            writer.WriteStartElement("About_promej_Control");
                                zap_XMl_with_abzac(this.richTextBox12, ref writer);
                            writer.WriteEndElement();
                            writer.WriteStartElement("Example_Zad");
                                zap_XMl_with_abzac(this.richTextBox11, ref writer);
                            writer.WriteEndElement();
                            writer.WriteStartElement("Vopros_k_Ekz");
                                zap_XMl_with_abzac(this.richTextBox10, ref writer);
                            writer.WriteEndElement();
                        writer.WriteEndElement();
                    writer.WriteEndElement();
                    //"7. Учебно-методическое и информационное обеспечение дисциплины"
                    writer.WriteStartElement("Recommand_literature");
                        zap_XML_Recommand_literature(ref writer);
                    writer.WriteEndElement();
                    //"8. Материально-техническое обеспечение дисциплины"
                    writer.WriteStartElement("Technical_Obespech");
                        zap_XMl_with_abzac(this.richTextBox13, ref writer);
                    writer.WriteEndElement();
                writer.WriteEndElement();
            writer.WriteEndDocument();
            if (!(writer.BaseStream is MemoryStream)) {
                writer.Close();
            }
        }
        /// <summary>
        /// сохранение данных из программы в *.XML в памяти или на диск.
        /// </summary>
        /// <param name="SaveInMemory_or_InDisk">true, если сохранение в *.docx, false, если сохранение в файл на диске в *.xml</param>
        private void SaveToXml_or_DOCX(HowDoc_Save howdocsave) {
            if (!this.NotIsEmptyData()) {
                MessageBox.Show(this, "Недостаточно данных для сохранения документа!", String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.GetValues();
            if (HourLab - SumPraktik() != 0 || HourLec - SumLec() != 0 || HourSam - SumSamost_job() != 0) {
                var msg = MessageBox.Show(this, "Проверьте объем часов, предназначенных для занятий! Присутствуют несоответствие общего объема часов с планом. Продолжить сохранение документа?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (msg != System.Windows.Forms.DialogResult.OK) {
                    return;
                }
            }
            if (save_path == String.Empty && !SaveDialogOpen(howdocsave)) {
                return;
            }
            XmlTextWriter writer = null;
            if (howdocsave == HowDoc_Save.SaveToXml) {
                writer = new XmlTextWriter(save_path, System.Text.Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                switch (this.Text) {
                    case "УМК":
                        this.Save_UMK_to_xml(ref writer);
                        break;
                    case "РПД":
                        this.Save_RPD_to_XML(ref writer);
                        break;
                }
            }
            else {
                MemoryStream memstream = new MemoryStream();                 
                writer = new XmlTextWriter(memstream, System.Text.Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                switch (this.Text) {
                    case "УМК":
                        this.Save_UMK_to_xml(ref writer);
                        break;
                    case "РПД":
                        this.Save_RPD_to_XML(ref writer);
                        break;
                }
                writer.Flush();
                memstream.Seek(0, SeekOrigin.Begin);
                using (StreamReader Reader = new StreamReader(memstream)){
                    memstream.Seek(0, SeekOrigin.Begin);
                    StringReader stringReader = new StringReader(Reader.ReadToEnd());
                    this.SaveToDocx(ref stringReader, howdocsave);
                }
            }
            save_path = string.Empty;
        }
        /// <summary>
        /// обеспечивает сохранение данных из программа в файл формата *.docx. Метод вызывается, если в программе выбран пункт меню "сохранить -> в *.docx"
        /// </summary>
        /// <param name="xmlDataFile">путь к файлу xml, содержащему данные для преобразования в документ Word</param>
        private void SaveToDocx(ref StringReader Data, HowDoc_Save howDocSave) {
            XmlTextReader xmlDataFile = new XmlTextReader(Data);
            //содержит шаблон для создаваемого документа в формате .docx
            string templateDocument = string.Empty;
            //новый выходной создаваемый файл
            string outputDocument = save_path;
            //вариант для отладки, когда шаблоны считываются не из ресурсов, а с диска
            /*//путь к файлу XSLT, содержащему стили преобразования
            string  xsltReader = string.Empty;
            switch(howDocSave){
                case HowDoc_Save.SaveRPD:
                    xsltReader = UMK_RPD.Properties.Settings.Default.Path_to_Files + "RPD.xslt";
                    templateDocument = UMK_RPD.Properties.Settings.Default.Path_to_Files + "RPD_template.docx";
                    break;
                case HowDoc_Save.SaveUmk:
                    xsltReader = UMK_RPD.Properties.Settings.Default.Path_to_Files + "UMK.xslt";
                    templateDocument = UMK_RPD.Properties.Settings.Default.Path_to_Files + "UMK_template.docx";
                    break;
                case HowDoc_Save.SaveAnnotationToRPD:
                    xsltReader = UMK_RPD.Properties.Settings.Default.Path_to_Files + "AnnotationToRPD_template.xslt";
                    templateDocument = UMK_RPD.Properties.Settings.Default.Path_to_Files + "AnnotationToRPD_template.docx";
                    break;
            } */
            
            //путь к файлу XSLT, содержащему стили преобразования
            StringReader Data_xslt = new StringReader(string.Empty);
            byte[] DocFromRes = new byte[1];
            switch (howDocSave) {
                case HowDoc_Save.SaveRPD:
                    Data_xslt = new StringReader(UMK_RPD.Properties.Resources.RPD); 
                    DocFromRes = UMK_RPD.Properties.Resources.RPD_template;
                    break;
                case HowDoc_Save.SaveUmk:
                    Data_xslt = new StringReader(UMK_RPD.Properties.Resources.UMK); 
                    DocFromRes = UMK_RPD.Properties.Resources.UMK_template;
                    break;
                case HowDoc_Save.SaveAnnotationToRPD:
                    Data_xslt = new StringReader(UMK_RPD.Properties.Resources.AnnotationToRPD); 
                    DocFromRes = UMK_RPD.Properties.Resources.AnnotationToRPD_template;
                    break;
            }
            XmlTextReader xsltReader = new XmlTextReader(Data_xslt);
            //содержит шаблон для создаваемого документа в формате .docx
            templateDocument = Directory.GetCurrentDirectory() + "\\Template_doc.docx";
            File.WriteAllBytes(templateDocument, DocFromRes);
             
            //Создать писатель для выходного XSL преобразования.
            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter);    
            //Создание объекта преобразования XSL.
            XslCompiledTransform transform = new XslCompiledTransform();
            //загружаем таблиц#у стилей  
            transform.Load(xsltReader);                        
            //Преобразование данных XML в Open XML 2.0 формата Wordprocessing.
            transform.Transform(xmlDataFile, xmlWriter);                  
            //Создать XML-документа новым содержанием.
            XmlDocument newWordContent = new XmlDocument();
            newWordContent.LoadXml(stringWriter.ToString());
            try {
                if(outputDocument.IndexOf(".docx", 0, outputDocument.Length) <= 0){
                    outputDocument += ".docx";
                }
                //Скопируйте исходный документ Word 2007 в выходной файл.
                System.IO.File.Copy(templateDocument, outputDocument, true);
                
                //Используйте Open XML SDK версии 2.0, чтобы открыть 
                //выходной документ в режиме редактирования.
                using (WordprocessingDocument output =
                  WordprocessingDocument.Open(outputDocument, true)) {
                    //Использование элемента тело в новой 
                    //содержимому XmlDocument создать новый открытый объект Xml тела.
                    Body updatedBodyContent =
                      new Body(newWordContent.DocumentElement.InnerXml); 
                    //Заменить существующий теле документа с новым содержанием.
                    output.MainDocumentPart.Document.Body = updatedBodyContent;    
                    //Сохраните обновленный выходной документ.
                    output.MainDocumentPart.Document.Save();
                }
                //Запуск документа MS Word
                System.Diagnostics.Process.Start(outputDocument);
            }
            catch (Exception message) {
                MessageBox.Show(message.Message);
            }
            finally {
                //для готового варианта (не отладка)
                File.Delete(templateDocument);
            }
        }         
        #endregion
        /// <summary>
        /// Выделение строк, с дисциплинами, у которых уже есть сохраненные в БД УМК/РПД, зеленым цветом
        /// </summary>
        private void FindFirst_Umk_Rpd_on_data() {
            foreach(DataGridViewRow Row in this.dataGridViewNagruzkaPrep.Rows){
                bool temp = (this.Text == "РПД") ? false : true;
                if (this.uMK_and_RPDTableAdapter.GetRow(Convert.ToInt16(Row.Cells["codSubColumn1"].Value), (int?)this.comboBox_plan.SelectedValue, temp, (short)this.numericUpDown.Value, this.CodKaf, (int?)Row.Cells["codPrepOnPlanColumn"].Value) != null) {
                    Row.DefaultCellStyle.BackColor = System.Drawing.Color.LimeGreen;
                }
                else {
                    Row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }
            }
        }
        /// <summary>
        /// проверка на то, чтобы ни одна из тем таблицы dataGridViewRazdelLesson не была пустой (содержала лекци/практики/лабораторные занятия)
        /// </summary>
        /// <returns></returns>
        private bool CorrectFilling_SoderjRazdDiscipGridView(){
            foreach(DataGridViewRow Row in this.dataGridViewRazdelLesson.Rows){
                if (Row.Cells["ColumnType"].Value.ToString().Trim() == "Тема") {
                    if(Row.Index == this.dataGridViewRazdelLesson.RowCount - 1){
                        return false;
                    }
                    else{
                        int RowIndex = Row.Index + 1;
                        int Count_Lec_Pratk_SamJob = 0;
                        for (int i = RowIndex; i < this.dataGridViewRazdelLesson.RowCount; i++ ) {
                            if (this.dataGridViewRazdelLesson.Rows[i].Cells["ColumnType"].Value.ToString().Trim() != "Раздел" &&
                                this.dataGridViewRazdelLesson.Rows[i].Cells["ColumnType"].Value.ToString().Trim() != "Тема") {
                                    Count_Lec_Pratk_SamJob++;
                            }
                            else {
                                if(Count_Lec_Pratk_SamJob != 0){
                                    break;
                                }
                                else {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
} 