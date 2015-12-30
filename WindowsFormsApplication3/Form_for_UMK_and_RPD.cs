using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Linq;

using CustomTexBoxColumn_for_CurContol;

using DocumentFormat.OpenXml.Packaging;

using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Math;
using System.Runtime.Serialization.Formatters.Binary;

namespace UMK_RPD {
    internal partial class Form_for_UMK_and_RPD : Form {
        /// <summary>
        /// перечисление для указания того, какой документ необходимо сохранить в формате *.docx: УМК, РПД, Аннотацию к РПД
        /// </summary>
        enum HowDoc_Save {
            SaveToXml = 0,
            SaveUmk = 1,
            SaveRPD = 2,
            SaveAnnotationToRPD = 3,
        }

        #region Основные используемые в программе переменные
        /// <summary>
        /// определяет каким образом открыта РПД/УМК: для редактирования существующей в БД записи или создания новой УМК/РПД
        /// </summary>
        ModeProgram modeProgram;
        /// <summary>
        /// Хранит временно данные из Competetion_DataGridView.Columns["Key_compet"]
        /// для дальнейшего обновления значений компетенций в этом столбце (ключевая / не ключевая)
        /// </summary>
        DataGridViewCheckBoxCell[] checkboxcell;
        /// <summary>
        /// если = false => данные в программе вбиваются "С чистого листа"
        /// если = true => то данные в программе вбиваются из файла *.Xml
        /// </summary>
        bool OpenXml = false;          
        /// <summary>
        /// Содержит полное описание всех ключевых компетенций
        /// </summary>
        DataGridView[] table_for_key_compet;                   
        /// <summary>
        /// Тип обучения: для стандартов (ФГОС 3, ФГОС 3+ и т.п.)
        /// </summary>
        byte CodTypeEdu;
        /// <summary>
        /// Код преподавателя по нагрузке
        /// </summary>
        int? Cod_prep { get; set; }
        /// <summary>
        /// код преподавателя, который создал РПД/УМК
        /// </summary>
        int? CodPrepWhoEdit;
        /// <summary>
        /// Код факультета
        /// </summary>
        byte? CodFac = null;
        /// <summary>
        /// Форма обучения
        /// </summary>
        byte? Cod_Form_study = null;
        /// <summary>
        /// Код кафедры дисцплины
        /// </summary>
        byte? CodKaf = null;
        
        /// <summary>
        /// Код группы
        /// </summary>
        short? Cod_group = null;
        /// <summary>
        /// Код предмета
        /// </summary>
        short? CodSub = null;
        /// <summary>
        /// Код учебного плана
        /// </summary>
        int? Cod_Plan = null;
        string save_path = "";
        /// <summary>
        /// Количество часов семинарских занятий
        /// </summary> 
        int HourLec = 0;
        /// <summary>
        /// Количество часов лабораторных работ
        /// </summary>
        int HourLab = 0;
        /// <summary>
        /// Количество часов для самостоятельных работ
        /// </summary>
        int HourSam = 0;

        DataTable Table_for_List_of_Theme;
        #endregion

        public Form_for_UMK_and_RPD(ModeProgram _modeProgram) {
            this.modeProgram = _modeProgram;
            InitializeComponent();
        }
        #region    События формы
        private void Form_for_UMK_Load(object sender, EventArgs e) {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "academia_for_UMK.TypeEdu". При необходимости она может быть перемещена или удалена.
            this.typeEduTableAdapter.Fill(this.academia_for_UMK.TypeEdu);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "academia_for_UMK.OcenSredstv". При необходимости она может быть перемещена или удалена.
            this.ocenSredstvTableAdapter.Fill(this.academia_for_UMK.OcenSredstv);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "academia_for_UMK.Faculty". При необходимости она может быть перемещена или удалена.
            this.facultyTableAdapter.Fill(this.academia_for_UMK.Faculty);
            this.formStudyTableAdapter.Fill(this.academia_for_UMK.FormStudy);
            this.comboBox_FormStudy.SelectedValue = 0;
            this.comboBox_TypeEdu.SelectedValue = 10;           
            //Вносим первонач. текст в RichTextBox для целей освоения дисциплины
            this.richTextBox1.Text = "Указываются цели освоения дисциплины, соотнесенные с общими целями ООП ВПО";
            this.richTextBox2.Text = "(Указывается цикл (раздел) ООП, к которому относится данная дисциплина. Дается описание логической и содержательно-методической взаимосвязи с другими частями ООП (дисциплинами, модулями, практиками)." +
                                     "Указываются требования к «входным» знаниям, умениям и готовностям обучающегося, " +
                                     "необходимым при освоении данной дисциплины и приобретенным в результате освоения предшествующих дисциплин (модулей)." +
                                     "Указываются те теоретические дисциплины и практики, для которых освоение данной дисциплины (модуля) необходимо как предшествующее).";
            this.comboBoxFacPrep.SelectedIndex = 0;
            this.kafsTableAdapter.Fill(academia_for_UMK.Kafs, (byte)this.comboBoxFacPrep.SelectedValue);
            this.richTextBox_for_pravila_proved_attest.Text = "(Указывается форма и правила проведения зачета или экзамена).";
            ToolTip_for_all_components();
            if (modeProgram.openMode == OpenMode.NewRpd || modeProgram.openMode == OpenMode.OpenRpd) {
                this.Text = "РПД";
            }
            else {
                this.Text = "УМК";
            }
            //Делаем невидимыми вкладки, в зависимости от того, что выбрано: УМК или РПД
            switch (this.Text) {
                case "УМК":
                    Page_for_RPD4_4_5.Parent = null;
                    Page_for_RPD6_2__6_4.Parent = null;
                    Page_for_RPD6_6__8.Parent = null;
                    break;
                case "РПД":
                    tabPage_for_CurControl.Parent = null;
                    tabPage_for_Example_EkzUnit.Parent = null;
                    this.dataGridViewRazdelLesson.Columns["FormCurControlColumn"].Visible = true;
                    this.аннотациюКРПДToolStripMenuItem.Visible = true;
                    break;
            }
            numericUpDown.Value = System.DateTime.Now.Year;
            label_for_UchYear.Text = @"/ " + (numericUpDown.Value + 1).ToString();
            if (modeProgram.openMode == OpenMode.OpenRpd || modeProgram.openMode == OpenMode.OpenUmk) {
                LoadDataToProgramFromDataBase();
            }
            dataGridView_for_Liter[2, 0].Value = global::UMK_RPD.Properties.Resources.find1;
            //если dataGridView_for_CurrentControl.RowCount == 1, то изменяем первую ячейку на тип CustomTextBoxCell_for_CurControl   
            this.Initial_Table_for_List_of_Theme();
            if(dataGridView_for_CurrentControl.Rows[0].Cells[0].Value == null){
                this.dataGridView_for_CurrentControl.AllowUserToAddRows = false;
                this.dataGridView_for_CurrentControl.Rows.Clear();
                this.dataGridView_for_CurrentControl.Rows.Add();
                this.dataGridView_for_CurrentControl.Rows[0].Cells[0] = Initial_CustomTextBoxCell_for_CurControl();
                this.dataGridView_for_CurrentControl.Rows[0].Cells[2] = Initial_CustomTextBoxCell_for_listTheme_DatagridViewCurControl();
                this.dataGridView_for_CurrentControl.AllowUserToAddRows = true;
            }
            if(this.Text == "РПД"){
                this.dataGridView_for_CurrentControl.Parent = this.panel_for_CurControl_for_RPD;
                this.dataGridView_for_CurrentControl.Dock = DockStyle.Bottom;
                this.dataGridView_for_CurrentControl.Height = this.panel_for_CurControl_for_RPD.Height - this.label_for_CurControl__for_RPD.Height - 5;
                this.panel_for_CurControl_for_RPD.Resize += (Sender, eventArgs) => {
                    this.dataGridView_for_CurrentControl.Height = this.dataGridView_for_CurrentControl.Height = this.panel_for_CurControl_for_RPD.Height - this.label_for_CurControl__for_RPD.Height - 5;                                             
                };
            }
            //открытьИзФайлаToolStripMenuItem.Visible = (modeProgram.openMode == OpenMode.NewRpd || modeProgram.openMode == OpenMode.NewUmk) ? true : false;
            //Открываем форму для поиска преподавателя, который редактирует/создает РПД/УМК
            Form_for_find find_pr = new Form_for_find();
            find_pr.ShowDialog(this);
            this.CodPrepWhoEdit = find_pr.cod_prep;
        }

        private void Form_for_UMK_and_RPD_FormClosing(object sender, FormClosingEventArgs e) {
            var message = MessageBox.Show("Сохранить " + this.Text + " в базе данных?", String.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (message == System.Windows.Forms.DialogResult.Yes) {
                if (!this.NotIsEmptyData()) {
                    message = MessageBox.Show("Недостаточно данных для сохранения " + this.Text + " в базе данных. Все равно выйти?", String.Empty, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (message == System.Windows.Forms.DialogResult.Cancel) {
                        e.Cancel = true;
                    }
                    return;
                }
                //this.dataGridView_for_CurrentControl.Rows.Clear();
                LoadDataToDataBaseFromProgram();
            }
            //this.dataGridView_for_CurrentControl.Rows.Clear();
            this.dataGridViewRazdelLesson.Rows.Clear();
        }
        #endregion

        #region Обработка действий с MenuStrip

        private void вxmlToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveToXml_or_DOCX(HowDoc_Save.SaveToXml);                                                   
        }

        private void вdocxToolStripMenuItem_Click(object sender, EventArgs e) {
            if (CorrectFilling_SoderjRazdDiscipGridView()) {
                SaveToXml_or_DOCX((this.Text == "РПД" ? HowDoc_Save.SaveRPD : HowDoc_Save.SaveUmk));
            }
            else {
                if(MessageBox.Show("Проверьте правильность заполнения таблицы с содержанием разделов дисциплины!" + 
                    "Одна или несколько тем не содержат лекций, практических занятий и самостоятельных работ." + 
                    "Информация из данной таблицы в файле формата *.docx может отображаться некорректно! Продолжить сохранение документа?",
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes){

                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e) {
            this.OpenXml = true;
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (this.Text == "УМК") { openFileDialog.InitialDirectory = UMK_RPD.Properties.Settings.Default.Setting_for_SaveUMK; }
            else { openFileDialog.InitialDirectory = UMK_RPD.Properties.Settings.Default.Setting_for_SaveRPD; }
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                if ((myStream = openFileDialog.OpenFile()) != null) {
                    string path = openFileDialog.FileName;
                    XmlTextReader XmlReader = new XmlTextReader(path);
                    XmlReader.WhitespaceHandling = WhitespaceHandling.None;
                    switch (this.Text) {
                        case "УМК":
                            this.Load_UMK_To_Program_from_XML(ref XmlReader);
                            break;
                        case "РПД":
                            this.Load_RPD_To_Program_from_XML(ref XmlReader);
                            break;
                    }
                    FindFirst_Umk_Rpd_on_data();
                }
            }
        }   

        private void экспортВБДToolStripMenuItem_Click(object sender, EventArgs e) {
            LoadDataToDataBaseFromProgram();
        }  
        private void добавитьНовуюРПДУМКToolStripMenuItem_Click(object sender, EventArgs e) {
            modeProgram.openMode = (this.Text == "РПД") ? OpenMode.NewRpd : OpenMode.NewUmk;
            LoadDataToDataBaseFromProgram();
        }

        #endregion

        #region обработка действий с Main_tabControl

        private void Main_tabControl_Selecting(object sender, TabControlCancelEventArgs e) {
            switch (Main_tabControl.SelectedIndex) {
                case 2:
                    this.Competetion_dataGridView.Columns["IdCompet"].Visible = false;
                    checkboxcell = new DataGridViewCheckBoxCell[this.Competetion_dataGridView.RowCount];
                    for (int i = 0; i < this.Competetion_dataGridView.RowCount; i++) {
                        checkboxcell[i] = new DataGridViewCheckBoxCell(false);
                        if (Competetion_dataGridView.Rows[i].Cells["Key_compet"].Value != null &&
                            Competetion_dataGridView.Rows[i].Cells["Key_compet"].Value.ToString().ToLower() == "true") {
                            checkboxcell[i].Value = true;
                        }
                        else {
                            checkboxcell[i].Value = false;
                        }
                    }
                    break;
                case 3:
                    HourLab = 0;
                    HourLec = 0;
                    HourSam = 0;
                    if (Cod_Plan != null && this.dataGridViewNagruzkaPrep.RowCount > 0) {
                        foreach (DataGridViewRow Row in this.dataGridView_for_StudyTerm.Rows) {
                            HourLec += Convert.ToInt32(Row.Cells["LecColumn"].Value);
                            HourSam += Convert.ToInt32(Row.Cells["SamColumn"].Value);
                            HourLab += Convert.ToInt32(Row.Cells["SemColumn"].Value);
                        }
                    }
                    if (this.dataGridViewRazdelLesson.RowCount > 0) {
                        this.Label_for_hours.Text = "Оставшийся объем часов: " + "Лекции: " + (HourLec - SumLec()).ToString() + "; Семинары: " + (HourLab - SumPraktik()).ToString() + "; Самостоятельные: " + (HourSam - SumSamost_job()).ToString();
                    }
                    break;
                case 4:
                    if (dataGridView_for_CurrentControl.RowCount == 1) {
                        DataGridViewComboBoxCell combobox = new DataGridViewComboBoxCell();
                        foreach (DataGridViewRow Row in this.dataGridViewRazdelLesson.Rows) {
                            if (Row.Cells["ColumnType"].Value.ToString() == "Тема" && Row.Cells["ColumnTheme"].Value != null) {
                                combobox.Items.Add(Row.Cells["ColumnTheme"].Value.ToString());
                            }
                        }
                        this.dataGridView_for_CurrentControl.Rows[0].Cells[2] = combobox;
                    }
                    break;
            }
            //MessageBox.Show("Значение ячейки:" + (this.Competetion_dataGridView.Rows[1].Cells["Key_compet"].Value != null ? this.Competetion_dataGridView.Rows[1].Cells["Key_compet"].Value.ToString() : "NULL".ToString()));
        }

        private void Main_tabControl_Click(object sender, EventArgs e) {
            switch (Main_tabControl.SelectedIndex) {
                case 2:
                    for (int i = 0; i < checkboxcell.Length; i++) {
                        this.Competetion_dataGridView.Rows[i].Cells["Key_compet"].Value = checkboxcell[i].Value;
                    }
                    break;
            }
        }

        #endregion                  
        
        #region Обработка действий с DataGridViewCompetetion

        /// <summary>
        /// Добавление компетенции в DataGridViewCompetetion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void добавитьКомпетенциюToolStripMenuItem_Click(object sender, EventArgs e) {
            //this.Competetion_dataGridView.Rows.Add(1);
        }

        private void сформироватьУровневоеОписаниеДляКлючевыхToolStripMenuItem_Click(object sender, EventArgs e) {
            this.sform_spisok_key_compet();
        }
        /// <summary>
        /// Удаление компетенции из DataGridViewRazdelLesson
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void удалитьКомпетенциюToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.Competetion_dataGridView.RowCount > 0) {
                this.Competetion_dataGridView.Rows.Remove(this.Competetion_dataGridView.Rows[this.Competetion_dataGridView.CurrentRow.Index]);
            }
        }
        private void Add_compet_btn_Click(object sender, EventArgs e) {
            this.добавитьКомпетенциюToolStripMenuItem_Click(sender, e);
        }

        private void Del_compet_btn_Click(object sender, EventArgs e) {
            this.удалитьКомпетенциюToolStripMenuItem_Click(sender, e);
        }

        private void Sform_keyCompet_btn_Click(object sender, EventArgs e) {
            this.sform_spisok_key_compet();
        }

    #endregion
                
        #region обработка действий с DataGridViewRazdelLesson
        /// <summary>
        /// Добавление раздела в DataGridViewRazdelLesson
        /// </summary>
        private void разделToolStripMenuItem_Click(object sender, EventArgs e) {
            this.dataGridViewRazdelLesson.EndEdit();
            int CurIndex = 0;
            //если в таблице количество строк !=0
            if (dataGridViewRazdelLesson.RowCount != 0) {
                //Добавление раздела после текущей строки
                CurIndex = dataGridViewRazdelLesson.CurrentRow.Index;
                if (dataGridViewRazdelLesson.Rows.Count - 1 != CurIndex) {
                    for (int i = CurIndex + 1; i < dataGridViewRazdelLesson.RowCount; i++) {
                        if (dataGridViewRazdelLesson.Rows[i].Cells["ColumnType"].Value.ToString() == "Раздел") {
                            CurIndex = i;
                            break;
                        }
                        else {
                            CurIndex = dataGridViewRazdelLesson.RowCount;
                        }
                    }
                }
                else {
                    CurIndex += 1;
                }
            }

            dataGridViewRazdelLesson.Rows.Insert(CurIndex, 1);
            DataGridViewCell combobox = new DataGridViewComboBoxCell();
            foreach (DataGridViewRow Row in this.dataGridView_for_StudyTerm.Rows) {
                ((DataGridViewComboBoxCell)combobox).Items.Add(Row.Cells["CourseColumn"].Value.ToString().Trim() + '.' + Row.Cells["NumTermColumn"].Value.ToString().Trim());
            }
            if (dataGridView_for_StudyTerm.RowCount > 0) {
                combobox.Value = this.dataGridView_for_StudyTerm.Rows[0].Cells["CourseColumn"].Value.ToString().Trim() + '.' + this.dataGridView_for_StudyTerm.Rows[0].Cells["NumTermColumn"].Value.ToString().Trim();
            }
            dataGridViewRazdelLesson.Rows[CurIndex].Cells["Semestr"] = combobox;
            //Для столбца "Форма текущего контроля"
            if (this.Text == "РПД") {
                combobox = new CustomTextBoxCell_for_CurControl();
                dataGridViewRazdelLesson.Rows[CurIndex].Cells["FormCurControlColumn"] = combobox;
                ((CustomTextBoxCell_for_CurControl)combobox).DataSource = ocenSredstvBindingSource;
                ((CustomTextBoxCell_for_CurControl)combobox).ValueMember = academia_for_UMK.OcenSredstv.IdSredstvColumn.ToString();
                ((CustomTextBoxCell_for_CurControl)combobox).DisplayMember = academia_for_UMK.OcenSredstv.NameSredstv_with_abbrColumn.ToString();
            }

            dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnType"].ReadOnly = true;
            dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnType"].Value = "Раздел";
            dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnVolume"].ReadOnly = true;
            dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnVolume"].Value = "0";
            this.dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnType"].Style.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnTheme"].Style.Alignment = DataGridViewContentAlignment.TopLeft;
            this.dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnType"].Style.Font = new System.Drawing.Font(this.dataGridViewRazdelLesson.Font, FontStyle.Bold);
            this.dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnTheme"].Style.Font = new System.Drawing.Font(this.dataGridViewRazdelLesson.Font, FontStyle.Bold);
            this.dataGridViewRazdelLesson.CurrentCell = this.dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnTheme"];
        }
        /// <summary>
        /// Удаление раздела/темы из DatagridRazdelLesson
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e) {
            this.dataGridViewRazdelLesson.EndEdit();
            if (dataGridViewRazdelLesson.Rows.Count != 0) {
                int Curindex = dataGridViewRazdelLesson.CurrentRow.Index;
                if (dataGridViewRazdelLesson.Rows[Curindex].Cells["ColumnType"].Value.ToString() != "Раздел" &&
                    dataGridViewRazdelLesson.Rows[Curindex].Cells["ColumnType"].Value.ToString() != "Тема") {
                    dataGridViewRazdelLesson.Rows.RemoveAt(Curindex);
                }
                else {                                  
                    //если удаляемая строка - последняя в гриде
                    //или если раздел пуст (то есть в след. строке грида содержится след. разде, то удаляем)
                    if (Curindex + 1 == dataGridViewRazdelLesson.Rows.Count) { 
                        dataGridViewRazdelLesson.Rows.RemoveAt(Curindex);
                        Initial_Table_for_List_of_Theme();
                    }
                    else if (dataGridViewRazdelLesson.Rows[Curindex].Cells["ColumnType"].Value.ToString() == "Раздел" &&
                             dataGridViewRazdelLesson.Rows[Curindex + 1].Cells["ColumnType"].Value.ToString() == "Раздел") {
                        dataGridViewRazdelLesson.Rows.RemoveAt(Curindex);
                    }
                    else if (dataGridViewRazdelLesson.Rows[Curindex].Cells["ColumnType"].Value.ToString() == "Тема" &&
                             (dataGridViewRazdelLesson.Rows[Curindex + 1].Cells["ColumnType"].Value.ToString() == "Раздел" ||
                             dataGridViewRazdelLesson.Rows[Curindex + 1].Cells["ColumnType"].Value.ToString() == "Тема")) {
                        dataGridViewRazdelLesson.Rows.RemoveAt(Curindex);
                    }
                    else {
                        string message = (dataGridViewRazdelLesson.Rows[Curindex].Cells["ColumnType"].Value.ToString() == "Раздел") ? 
                            "Раздел не является пустым!" : "Тема не является пустой!";
                        const string caption = "Ошибка";
                        var result = MessageBox.Show(message, caption,
                                                     MessageBoxButtons.OK,
                                                     MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// Добавление занятия в DataGridViewRazdelLesson
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void темаToolStripMenuItem_Click(object sender, EventArgs e) {
            this.dataGridViewRazdelLesson.EndEdit();
            if (dataGridViewRazdelLesson.Rows.Count != 0) {
                int CurIndex = dataGridViewRazdelLesson.CurrentRow.Index;
                if (this.dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnType"].Value.ToString() != "Раздел") {
                    while (CurIndex != dataGridViewRazdelLesson.RowCount &&
                          (dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnType"].Value.ToString() != "Раздел")) {
                        CurIndex++;
                    }
                }
                else { CurIndex++; }
                dataGridViewRazdelLesson.Rows.Insert(CurIndex, 1);
                dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnModule"] = new DataGridViewLinkCell();
                //Для столбца "Форма текущего контроля"
                CustomTextBoxCell_for_CurControl combobox = new CustomTextBoxCell_for_CurControl();
                combobox.DataSource = ocenSredstvBindingSource;
                combobox.ValueMember = academia_for_UMK.OcenSredstv.IdSredstvColumn.ToString();
                combobox.DisplayMember = academia_for_UMK.OcenSredstv.NameSredstv_with_abbrColumn.ToString();
                dataGridViewRazdelLesson.Rows[CurIndex].Cells["FormCurControlColumn"] = combobox;

                dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnType"].ReadOnly = true;
                dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnType"].Value = "Тема";
                dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnVolume"].Value = "0";
                dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnModule"].Value = "|-|";
                this.dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnType"].Style.Alignment = DataGridViewContentAlignment.TopRight;
                this.dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnTheme"].Style.Alignment = DataGridViewContentAlignment.TopLeft;
                this.dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnVolume"].ReadOnly = true;
                this.dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnType"].Style.Font = new System.Drawing.Font(this.dataGridViewRazdelLesson.Font, FontStyle.Bold);
                
                this.dataGridViewRazdelLesson.CurrentCell = this.dataGridViewRazdelLesson.Rows[CurIndex].Cells["ColumnTheme"];                
            }
            else {
                const string message =
               "Перед добавлением тем занятий необходимо выбрать или создать раздел! Для этого добавьте новый раздел.";
                const string caption = "Ошибка";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Добавление лекции к текущей теме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void лекциюToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Add_Lec_or_Prakt_or_SamJob("Лекция");
        }
        /// <summary>
        /// Добавление семинара к текущей теме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void семинарскоеЗанятиеToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Add_Lec_or_Prakt_or_SamJob("Семинар");
        }
        /// <summary>
        /// Добавление самостоятельной работы к текущей теме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void самостРаботаToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Add_Lec_or_Prakt_or_SamJob("Сам. работа");
        }
        /// <summary>
        /// Скрыть/показать содержимое DataGridViewRazdelLesson
        /// Если this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["ColumnModule"] = "|-|", то скрывается содержимое разделов,
        /// если this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["ColumnModule"] = "|+|", то содержимое разделов становится видимым
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewRazdelLesson_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex != -1 && this.dataGridViewRazdelLesson[e.ColumnIndex, e.RowIndex] == this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["ColumnModule"]) {
                int CurrentRow = e.RowIndex + 1;
                switch (this.dataGridViewRazdelLesson[e.ColumnIndex, e.RowIndex].Value.ToString()) {
                    case "|-|":
                        while (CurrentRow != this.dataGridViewRazdelLesson.RowCount && this.dataGridViewRazdelLesson.Rows[CurrentRow].Cells["ColumnType"].Value.ToString() != "Тема" &&
                                this.dataGridViewRazdelLesson.Rows[CurrentRow].Cells["ColumnType"].Value.ToString() != "Раздел") {
                            this.dataGridViewRazdelLesson.Rows[CurrentRow].Visible = false;
                            CurrentRow++;
                        }
                        this.dataGridViewRazdelLesson[e.ColumnIndex, e.RowIndex].Value = "|+|";
                        break;
                    case "|+|":
                        while (CurrentRow != this.dataGridViewRazdelLesson.RowCount && this.dataGridViewRazdelLesson.Rows[CurrentRow].Cells["ColumnType"].Value.ToString() != "Тема" &&
                                this.dataGridViewRazdelLesson.Rows[CurrentRow].Cells["ColumnType"].Value.ToString() != "Раздел") {
                            this.dataGridViewRazdelLesson.Rows[CurrentRow].Visible = true;
                            CurrentRow++;
                        }
                        this.dataGridViewRazdelLesson[e.ColumnIndex, e.RowIndex].Value = "|-|";
                        break;
                }
            }
        }
        private void dataGridViewRazdelLesson_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            double Sum_Lec = this.SumLec(),
                   Sum_Praktik = this.SumPraktik(),
                   Sum_Samost_Job = this.SumSamost_job();
            //Подсчет суммы часов лекций/практик/самост. работ и, если есть расхождения (количество часов превышено), то выдается предупреждение
            if (this.dataGridViewRazdelLesson[e.ColumnIndex, e.RowIndex] == this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["ColumnVolume"] && Validate_VolumnColumn(e.RowIndex)) {
                switch (this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["ColumnType"].Value.ToString().Trim()) {
                    case "Лекция":
                        if (Sum_Lec > (double)HourLec) {
                            MessageBox.Show("Объем часов, предназначенных для лекционных занятий - " + Sum_Lec.ToString() + " уже соотвествует объему, содержащемуся в учебном плане! Введите другой объем часов!",
                                            "Ошибка",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["ColumnVolume"].Value = (double)HourLec - Sum_Lec + Convert.ToDouble(this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["ColumnVolume"].Value);
                        }
                        break;
                    case "Семинар":
                        if (Sum_Praktik > (double)HourLab) {
                            MessageBox.Show("Объем часов, предназначенных для практических занятий - " + Sum_Praktik.ToString() + " уже соотвествует объему, содержащемуся в учебном плане! Введите другой объем часов!",
                                            "Ошибка",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["ColumnVolume"].Value = (double)HourLab - Sum_Praktik + Convert.ToDouble(this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["ColumnVolume"].Value);
                        }
                        break;
                    case "Сам. работа":
                        if (Sum_Samost_Job > (double)HourSam) {
                            MessageBox.Show("Объем часов, предназначенных для самоятоятельной работы - " + Sum_Samost_Job.ToString() + " уже соотвествует объему, содержащемуся в учебном плане! Введите другой объем часов!",
                                            "Ошибка",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["ColumnVolume"].Value = (double)HourSam - Sum_Samost_Job + Convert.ToDouble(this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["ColumnVolume"].Value);           
                        }
                        break;
                }
                this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                this.dataGridViewRazdelLesson.CurrentCell = this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
            podshet_hours_in_RazdelLesson();
            Label_for_hours.Text = "Оставшийся объем часов: " + "Лекции: " + (HourLec - this.SumLec()).ToString() + "; Семинары: " + (HourLab - this.SumPraktik()).ToString() + "; Самостоятельные: " + (HourSam - this.SumSamost_job()).ToString();
            //Замена всех значений поля "Семестра" при изменении семестра в разделе
            if (this.dataGridViewRazdelLesson[e.ColumnIndex, e.RowIndex] == this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["Semestr"]) {
                int CurrentRow = e.RowIndex + 1;
                while (CurrentRow != this.dataGridViewRazdelLesson.RowCount && dataGridViewRazdelLesson.Rows[CurrentRow].Cells["ColumnType"].Value.ToString() != "Раздел") {
                    dataGridViewRazdelLesson.Rows[CurrentRow].Cells["Semestr"].Value = this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["Semestr"].Value;
                    CurrentRow++;
                }
            }
            if (this.dataGridViewRazdelLesson[e.ColumnIndex, e.RowIndex] == this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["FormCurControlColumn"]) {
                this.dataGridViewRazdelLesson.Rows[e.RowIndex].MinimumHeight = 22;
                this.dataGridViewRazdelLesson.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            if(this.dataGridViewRazdelLesson[e.ColumnIndex, e.RowIndex] == this.dataGridViewRazdelLesson.Rows[e.RowIndex].Cells["ColumnTheme"] && this.dataGridViewRazdelLesson["ColumnType", e.RowIndex].Value.ToString() == "Тема"){
                Initial_Table_for_List_of_Theme();
            }
        }

        private void Add_razdel_btn_Click(object sender, EventArgs e) {
            this.разделToolStripMenuItem_Click(sender, e);
        }

        private void Add_theme_btn_Click(object sender, EventArgs e) {
            this.темаToolStripMenuItem_Click(sender, e);
        }

        private void Add_lec_btn_Click(object sender, EventArgs e) {
            this.Add_Lec_or_Prakt_or_SamJob("Лекция");
        }

        private void Add_prakt_btn_Click(object sender, EventArgs e) {
            this.Add_Lec_or_Prakt_or_SamJob("Семинар");
        }

        private void Add_sam_Job_btn_Click(object sender, EventArgs e) {
            this.Add_Lec_or_Prakt_or_SamJob("Сам. работа");
        }

        private void Del_btn_Click(object sender, EventArgs e) {
            this.удалитьToolStripMenuItem_Click(sender, e);
        }

    #endregion

        #region Обработка действий с dataGridView_for_Liter

        private void dataGridView_for_Liter_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            if (e.ColumnIndex == 0) {
                this.dataGridView_for_Liter[e.ColumnIndex, e.RowIndex].Value = "Основная";
            }
        }

        private void dataGridView_for_Liter_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            if (e.RowIndex > 0 && this.dataGridView_for_Liter[0, e.RowIndex - 1].Value == null) {
                ((DataGridViewComboBoxCell)this.dataGridView_for_Liter[0, e.RowIndex - 1]).Value = null;//"Основная";
            }
            this.dataGridView_for_Liter[0, e.RowIndex].Value = "Основная";
            this.dataGridView_for_Liter[2, e.RowIndex].Value = global::UMK_RPD.Properties.Resources.find1;
        }
        private void dataGridView_for_Liter_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex == 2) {
                if(this.dataGridView_for_Liter.CurrentRow.Index == this.dataGridView_for_Liter.RowCount - 1){
                    this.dataGridView_for_Liter.Rows.Add();                      
                }                
                Form_for_FindLiter FindLiter = new Form_for_FindLiter(this);
                FindLiter.ShowDialog(this);
            }
        }
        #endregion

        #region для компонентов титульной вкладки и dataGridView_for_CurrentControl
        private void comboBoxKaf_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.comboBoxKaf.SelectedValue != null) {
                this.CodKaf = Convert.ToByte(this.comboBoxKaf.SelectedValue.ToString());
                this.comboBox_plan_SelectedIndexChanged(sender, e);
            }
        }
        /// <summary>
        /// Выбор кафедры в зависимости от факультета
        /// </summary>
        private void comboBoxFacPrep_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.comboBoxFacPrep.SelectedValue != null) {
                this.kafsTableAdapter.Fill(academia_for_UMK.Kafs, Convert.ToByte(this.comboBoxFacPrep.SelectedValue));
                this.comboBoxKaf_SelectedIndexChanged(sender, e);
                CodFac = Convert.ToByte(this.comboBoxFacPrep.SelectedValue.ToString());
            }
        }

        private void textBoxPrepod_Click(object sender, EventArgs e) {
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e) {
            this.label_for_UchYear.Text = "/ " + (this.numericUpDown.Value + 1).ToString();
            if (this.comboBox_plan.Items.Count > 0) {
                this.nagruzkaOnPrepTableAdapter.Fill(academia_for_UMK.NagruzkaOnPrep, (int?)this.comboBox_plan.SelectedValue, (byte?)this.comboBoxKaf.SelectedValue, (short?)this.numericUpDown.Value, null);
            }
            else if (comboBox_plan.Items.Count == 0) {
                this.nagruzkaOnPrepTableAdapter.Fill(academia_for_UMK.NagruzkaOnPrep, 0, 0, 0, 0);
            }
            FindFirst_Umk_Rpd_on_data();
        }

        

        private void dataGridViewNagruzkaPrep_CellEnter(object sender, DataGridViewCellEventArgs e) {
            if (!OpenXml) {
                HourLab = 0;
                HourLec = 0;
                HourSam = 0;
                this.Cod_Plan = (int?)this.comboBox_plan.SelectedValue;
                this.CodSub = (System.Int16?)this.dataGridViewNagruzkaPrep.CurrentRow.Cells["codSubColumn1"].Value;
                this.Cod_prep = (int?)this.dataGridViewNagruzkaPrep.CurrentRow.Cells["codPrepOnPlanColumn"].Value;
                this.FIO_prepod = this.prepodTableAdapter.Get_FIO((this.Cod_prep != 0) ? (int)this.Cod_prep : (int)this.CodPrepWhoEdit).ToString();
                if (this.Cod_Plan != null) {
                    this.studyExamsTableAdapter.Fill(academia_for_UMK.StudyExams, (int)Cod_Plan, (short)CodSub);
                    this.studyTermTableAdapter.Fill(academia_for_UMK.StudyTerm, (int)Cod_Plan, (short)CodSub);
                    foreach (DataGridViewRow Row in this.dataGridView_for_StudyTerm.Rows) {
                        HourLec += Convert.ToInt32(Row.Cells["LecColumn"].Value);
                        HourSam += Convert.ToInt32(Row.Cells["SamColumn"].Value);
                        HourLab += Convert.ToInt32(Row.Cells["SemColumn"].Value);
                    }
                    CodSpeciality = this.comboBox_speciality.SelectedValue.ToString();
                    this.competetionTableAdapter.Fill(academia_for_UMK.Competetion, CodSpeciality, (short)CodSub, (int)Cod_Plan);
                    this.label_for_shifr.Text = this.GetShifrDiscip();
                    if (this.dataGridViewNagruzkaPrep.Rows[e.RowIndex].DefaultCellStyle.BackColor == System.Drawing.Color.LimeGreen) {
                        modeProgram.openMode = (modeProgram.openMode == OpenMode.NewRpd || modeProgram.openMode == OpenMode.OpenRpd) ? OpenMode.OpenRpd : OpenMode.OpenUmk;
                        modeProgram.IdRpd_or_UMK = Convert.ToInt32(this.uMK_and_RPDTableAdapter.GetID(this.CodSub, (this.Text == "РПД") ? false : true, (short)this.numericUpDown.Value, this.Cod_Plan, this.CodKaf));
                        int CodPEWhoEdit = Convert.ToInt32(this.uMK_and_RPDTableAdapter.GetCodPrepWhoEdit(modeProgram.IdRpd_or_UMK).ToString().Trim());
                        this.label_for_PrepWhoEdit_inBase.Text = this.prepodTableAdapter.Get_FIO(CodPEWhoEdit).ToString().Trim();
                    }
                    else {
                        modeProgram.openMode = (modeProgram.openMode == OpenMode.OpenRpd || modeProgram.openMode == OpenMode.NewRpd) ? OpenMode.NewRpd : OpenMode.NewUmk;
                        this.label_for_PrepWhoEdit_inBase.Text = String.Empty;
                    }                    
                }
            }
            else {
                OpenXml = false;
            } 
            if(this.dataGridViewNagruzkaPrep.RowCount > 0 &&
                this.dataGridViewNagruzkaPrep.CurrentRow.DefaultCellStyle.BackColor != System.Drawing.Color.LimeGreen) {
                this.label_for_PrepWhoEdit_inBase.Text = String.Empty;
            }
        }

        private void Next_button_Click(object sender, EventArgs e) {
            if (Main_tabControl.SelectedIndex < Main_tabControl.TabCount - 1) {
                Main_tabControl.SelectedIndex++;
                this.Main_tabControl_Click(sender, e);
            }
        }

        private void Pred_btn_Click(object sender, EventArgs e) {
            if (Main_tabControl.SelectedIndex > 0) {
                Main_tabControl.SelectedIndex--;
                this.Main_tabControl_Click(sender, e);
            }
        }
        /// <summary>
        /// инициализация ячейки с типом  CustomTextBoxCell_for_CurControl
        /// </summary>
        /// <param name="cell">ячейка, тип которой необходимо изменить</param>
        private CustomTextBoxCell_for_CurControl Initial_CustomTextBoxCell_for_CurControl() {
            CustomTexBoxColumn_for_CurContol.CustomTextBoxCell_for_CurControl combobox = new CustomTextBoxCell_for_CurControl();
            combobox.DataSource = ocenSredstvBindingSource;
            combobox.DisplayMember = academia_for_UMK.OcenSredstv.NameSredstv_with_abbrColumn.ToString(); ;
            combobox.ValueMember = academia_for_UMK.OcenSredstv.IdSredstvColumn.ToString();
            return combobox;
        }
        /// <summary>
        /// Инициализация/заполнение таблицы, содержащей список тем
        /// </summary>
        private void Initial_Table_for_List_of_Theme() {
            if (this.Table_for_List_of_Theme == null) {
                this.Table_for_List_of_Theme = new System.Data.DataTable();
                this.Table_for_List_of_Theme.Columns.AddRange(new System.Data.DataColumn[] { new System.Data.DataColumn("NumberTheme", typeof(string)), 
                                                                                             new System.Data.DataColumn("NameTheme", typeof(string)) });
            }
            else { 
            this.Table_for_List_of_Theme.Rows.Clear();                  
                int NumRazdel = 0, NumTheme = 0;
                foreach (DataGridViewRow Row in this.dataGridViewRazdelLesson.Rows) {
                    if (Row.Cells["ColumnType"].Value.ToString() == "Раздел") {
                        NumRazdel++;
                        NumTheme = 0;
                    }
                    else if (Row.Cells["ColumnType"].Value.ToString() == "Тема") {
                        NumTheme++;
                        this.Table_for_List_of_Theme.Rows.Add("Тема " + NumRazdel.ToString() + "." + NumTheme.ToString() + ".", (Row.Cells["ColumnTheme"].Value != null ? Row.Cells["ColumnTheme"].Value.ToString().Trim() : String.Empty));
                    }
                }
            }
        }

        private CustomTextBoxCell_for_CurControl Initial_CustomTextBoxCell_for_listTheme_DatagridViewCurControl() {
            CustomTextBoxCell_for_CurControl combobox = new CustomTextBoxCell_for_CurControl();
            combobox.DataSource = this.Table_for_List_of_Theme;
            combobox.ValueMember = this.Table_for_List_of_Theme.Columns["NumberTheme"].ToString();
            combobox.DisplayMember = this.Table_for_List_of_Theme.Columns["NameTheme"].ToString();
            return combobox;
        }

        private void dataGridView_for_CurrentControl_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            if(this.Table_for_List_of_Theme == null){
                this.Table_for_List_of_Theme = new System.Data.DataTable();
                this.Table_for_List_of_Theme.Columns.AddRange(new System.Data.DataColumn[] { new System.Data.DataColumn("NumberTheme", typeof(string)), 
                                                                                             new System.Data.DataColumn("NameTheme", typeof(string)) });
            }
            this.dataGridView_for_CurrentControl[0, e.RowIndex] = Initial_CustomTextBoxCell_for_CurControl();
            this.dataGridView_for_CurrentControl[2, e.RowIndex] = Initial_CustomTextBoxCell_for_listTheme_DatagridViewCurControl();
        }
        #endregion

        private void dataGridView_for_CurrentControl_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            this.dataGridView_for_CurrentControl.Rows[e.RowIndex].MinimumHeight = 22;
            this.dataGridView_for_CurrentControl.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void аннотациюКРПДToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveToXml_or_DOCX(HowDoc_Save.SaveAnnotationToRPD);
        }

        private void dataGridViewRazdelLesson_DataError(object sender, DataGridViewDataErrorEventArgs e) {
            int a = e.ColumnIndex;
        }

        private void comboBox_TypeEdu_SelectedIndexChanged(object sender, EventArgs e) {
            this.specialityTableAdapter.Fill(academia_for_UMK.Speciality, Convert.ToByte(this.comboBox_TypeEdu.SelectedValue));
            this.comboBox_speciality_SelectedIndexChanged(sender, e);
        }

        private void comboBox_speciality_SelectedIndexChanged(object sender, EventArgs e) {         
            if (this.comboBox_speciality.SelectedValue != null) {
                try {
                    this.studyPlansTableAdapter.Fill(academia_for_UMK.StudyPlans, (byte?)this.comboBox_FormStudy.SelectedValue, (byte?)this.comboBox_TypeEdu.SelectedValue, (string)this.comboBox_speciality.SelectedValue);
                }
                catch {
                    this.studyPlansTableAdapter.Fill(academia_for_UMK.StudyPlans, (byte?)this.comboBox_FormStudy.SelectedValue, (byte?)this.comboBox_TypeEdu.SelectedValue, (string)this.comboBox_speciality.SelectedValue);
                }                
                if (this.comboBox_plan.Items.Count > 0) {
                    comboBox_plan_SelectedIndexChanged(sender, e);
                }
                else {
                    this.nagruzkaOnPrepTableAdapter.Fill(academia_for_UMK.NagruzkaOnPrep, 0, 0, 0, 0);
                }

            }
            else {
                return;
            }
        }

        private void comboBox_FormStudy_SelectedIndexChanged(object sender, EventArgs e) {
            this.comboBox_speciality_SelectedIndexChanged(sender, e);
        }

        private void comboBox_plan_SelectedIndexChanged(object sender, EventArgs e) {
            if(this.comboBox_plan.Items.Count > 0){
                if (this.comboBox_plan.SelectedValue != null) {
                    this.nagruzkaOnPrepTableAdapter.Fill(academia_for_UMK.NagruzkaOnPrep, (int?)this.comboBox_plan.SelectedValue, (byte?)this.comboBoxKaf.SelectedValue, (short?)this.numericUpDown.Value, null);
                    FindFirst_Umk_Rpd_on_data();
                }
            }
            else if(comboBox_plan.Items.Count == 0){
                this.nagruzkaOnPrepTableAdapter.Fill(academia_for_UMK.NagruzkaOnPrep, 0, 0, 0, 0);
            }
        }
    }
}