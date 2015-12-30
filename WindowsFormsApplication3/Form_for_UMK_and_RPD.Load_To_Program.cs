using System;
//в этом файле описание основных методов для считывания данных из XMl-файла в программу
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Xml.Xsl;
using System.Windows.Forms;
using System.Drawing;

namespace UMK_RPD {
    internal partial class Form_for_UMK_and_RPD {

        #region вспомогательные методы для заполнения всех полей программы из файла *.xml
        /// <summary>
        /// Очистка содержимого всех элементов управления, содержащих какой-либо текст
        /// </summary>
        private void Clear_all_control() {
            //this.Competetion_dataGridView.Rows.Clear();
            this.Ur_compit_TabCotrol.TabPages.Clear();
            this.dataGridViewRazdelLesson.Rows.Clear();
            this.dataGridView_for_Liter.Rows.Clear();
            this.dataGridView_Vopros_k_ekz.Rows.Clear();
            this.dataGridView_for_CurrentControl.Rows.Clear();
            this.richTextBox1.Clear();
            this.richTextBox2.Clear();
            this.richTextBox3.Clear();
            this.richTextBox4.Clear();
            this.richTextBox5.Clear();
            //this.richTextBox6.Clear();
            this.richTextBox7.Clear();
            this.richTextBox8.Clear();
            this.richTextBox9.Clear();
            this.richTextBoxTreb31.Clear();
            this.richTextBoxTreb32.Clear();
            this.richTextBoxTreb33.Clear();
            this.richTextBox10.Clear();
            this.richTextBox11.Clear();
            this.richTextBox12.Clear();
            this.richTextBox13.Clear();
            this.richTextBox14.Clear();
            this.richTextBox_for_pravila_proved_attest.Clear();
        }
        /// <summary>
        /// Заполнение TabPage_for_Title и основных переменных программы
        /// </summary>
        /// <param name="XmlReader"></param>
        private void zap_TabPage_Title(ref XmlTextReader XmlReader) {
            if (XmlReader.GetAttribute("CodPlan") == null) {
                Cod_Plan = Convert.ToInt16(this.grupTableAdapter.Get_CodPlan(Convert.ToInt16(XmlReader.GetAttribute("CodGroup"))));
            }
            else{
                Cod_Plan = Convert.ToInt16(XmlReader.GetAttribute("CodPlan"));
            }
            CodSub = Convert.ToInt16(XmlReader.GetAttribute("CodSub"));
            Cod_prep = Convert.ToInt32(XmlReader.GetAttribute("Cod_prep"));
            CodPrepWhoEdit = Convert.ToInt32(XmlReader.GetAttribute("CodPrepWhoEdit"));
            CodKaf = Convert.ToByte(XmlReader.GetAttribute("CodKafPrep").ToString());
            CodFac = Convert.ToByte(XmlReader.GetAttribute("CodFac"));
            Cod_Form_study = (byte?)this.grupTableAdapter.GetCodFormStudy((int)this.Cod_Plan);
            CodTypeEdu = (byte)this.grupTableAdapter.GetCodTypeEdu((int)this.Cod_Plan);
            CodSpeciality = this.grupTableAdapter.GetCodSpeciality((int)this.Cod_Plan).ToString();             
            this.comboBoxFacPrep.SelectedValue = CodFac;
            this.comboBoxKaf.SelectedValue = Convert.ToByte(XmlReader.GetAttribute("CodKafPrep").ToString()); 
            this.comboBox_FormStudy.SelectedValue = Cod_Form_study;
            this.comboBox_TypeEdu.SelectedValue = this.CodTypeEdu;
            this.comboBox_speciality.SelectedValue = this.CodSpeciality;
            this.OpenXml = true;
            this.comboBox_plan.SelectedValue = this.Cod_Plan;
            this.numericUpDown.Value = Convert.ToInt32(XmlReader.GetAttribute("Year"));
            //this.textBoxPrepod.Text = (string)this.prepodTableAdapter.Get_FIO((int)Cod_prep);
            //Загрузим из плана, в каком семестре и курсе изучается предмет
            HourLab = 0;
            HourLec = 0;
            HourSam = 0;
            label_for_UchYear.Text = @"/ " + (this.numericUpDown.Value + 1).ToString();
            this.studyExamsTableAdapter.Fill(academia_for_UMK.StudyExams, (int)Cod_Plan, (short)CodSub);                  
            this.studyTermTableAdapter.Fill(academia_for_UMK.StudyTerm, (int)Cod_Plan, (short)CodSub);
            OpenXml = true;
            this.dataGridViewNagruzkaPrep.CellEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNagruzkaPrep_CellEnter);
               // this.nagruzkaOnPrepTableAdapter.Fill(academia_for_UMK.NagruzkaOnPrep, (int)Cod_prep, Convert.ToInt16(this.numericUpDown.Value));
            this.dataGridViewNagruzkaPrep.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNagruzkaPrep_CellEnter);            
            foreach(DataGridViewRow Row in this.dataGridViewNagruzkaPrep.Rows){
                if (Row.Cells["codSubColumn1"].Value.ToString() == CodSub.ToString() &&  
                    Row.Cells["codPlanColumn1"].Value.ToString() == Cod_Plan.ToString() &&
                    (Row.Cells["codPrepOnPlanColumn"].Value.ToString() == Cod_prep.ToString() || Cod_prep == 0)) {
                        OpenXml = true;    
                        this.dataGridViewNagruzkaPrep.CurrentCell = Row.Cells["nameSubColumn"];                            
                        break;
                }
            }
            FindFirst_Umk_Rpd_on_data();
        }
        /// <summary>
        /// считывание из XmlReader узлов и заполнение richTextBox до тех пор, пока XmlReader.Name != XmlReader_Name
        /// </summary>
        /// <param name="richTextBox">Заполняемый richTextBox</param>
        /// <param name="XmlReader_Name">До тега с каким именем считывать информацию</param>
        /// <param name="XmlReader">Откуда считывем</param>
        private void zap_richTextBox_with_abzac(ref System.Windows.Forms.RichTextBox richTextBox, ref XmlTextReader XmlReader) {
            if (XmlReader.IsStartElement() && !XmlReader.IsEmptyElement) {
                richTextBox.Text = String.Empty;
                while (XmlReader.Read() && XmlReader.HasAttributes) {
                    richTextBox.Text += XmlReader.GetAttribute("Value") + '\n';
                }
                if (richTextBox.Text != String.Empty) {
                    richTextBox.Text = richTextBox.Text.Substring(0, richTextBox.Text.Length - 1);
                }
            }
        }
        /// <summary>
        /// Заполнение целей изучения дисциплины, компетенций
        /// </summary>
        /// <param name="XmlReader"></param>     ]
        /// <param name="end_teg">атрибут, до котрого необходимо считывать информацию</param>
        private void zap_TabPage_for_zapiska_and_compet(ref XmlTextReader XmlReader, string end_teg) {
            XmlReader.Read();
            while (XmlReader.Name != end_teg) {
                switch (XmlReader.Name) {
                    case "GoalsDisciplin":
                        zap_richTextBox_with_abzac(ref richTextBox1, ref XmlReader);
                        break;
                    case "PlaceOOP":
                        XmlReader.Read();
                        zap_richTextBox_with_abzac(ref richTextBox2, ref XmlReader);
                        richTextBox2.Text = String.Empty;
                        while (XmlReader.Read() && XmlReader.HasAttributes) {
                            richTextBox2.Text += XmlReader.GetAttribute("Value") + '\n';
                        }
                        if (richTextBox2.Text != String.Empty) {
                            richTextBox2.Text = richTextBox2.Text.Substring(0, richTextBox2.Text.Length - 1);
                        }
                        break;
                    case "Competetion": 
                            //CodSpeciality = this.grupTableAdapter.GetCodSpeciality((short)Cod_Plan).ToString();
                            this.competetionTableAdapter.Fill(academia_for_UMK.Competetion, CodSpeciality, (short)CodSub, (int)Cod_Plan);
                            int NumCompet = 0;
                            //Присваиваем каждой компетенции в CompetetiondataGridView столбцу KeyCompet значение из *.Xml файла
                            OpenXml = true;
                            while (XmlReader.Read() && XmlReader.Name != "Competetion" && XmlReader.Name == "Row") {
                                this.Competetion_dataGridView.Rows[NumCompet++].Cells["Key_compet"].Value = XmlReader.GetAttribute("KeyCompet").ToString().ToLower() == "true" ? true : false;
                            }
                            this.Competetion_dataGridView.EndEdit();
                        break;
                    case "Key_compet":
                        int i = 0; //Переменная, в которой хранится номер текущей вкладки Ur_compit_TabCotrol для заполнения
                        while (XmlReader.Read() && XmlReader.HasAttributes) {
                            switch (XmlReader.Name) {
                                case "Competetion":
                                    //Название ключевой компетенции
                                    Ur_compit_TabCotrol.TabPages.Add(XmlReader.GetAttribute("Name"));
                                    table_for_key_compet[i] = new DataGridView();
                                    table_for_key_compet[i].Location = new Point();
                                    table_for_key_compet[i].Dock = DockStyle.Fill;
                                    Ur_compit_TabCotrol.TabPages[i].Controls.Add(table_for_key_compet[i]);
                                    table_for_key_compet[i].Columns.Add("Uroven", "Уровень");
                                    table_for_key_compet[i].Columns["Uroven"].ReadOnly = true;
                                    table_for_key_compet[i].Columns["Uroven"].Width = 160;
                                    table_for_key_compet[i].Columns.Add("Opisanie", "Описание уровня");
                                    table_for_key_compet[i].Columns["Opisanie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                                    table_for_key_compet[i].AllowUserToAddRows = false;
                                    while (XmlReader.Read() && XmlReader.Name != "Competetion") {
                                        table_for_key_compet[i].Rows.Add();
                                        table_for_key_compet[i].Rows[this.table_for_key_compet[i].RowCount - 1].Cells["Uroven"].Value = XmlReader.GetAttribute("ur_osv");
                                        table_for_key_compet[i].Rows[this.table_for_key_compet[i].RowCount - 1].Cells["Opisanie"].Value = XmlReader.GetAttribute("priznak_osv");
                                    }
                                    i++;
                                    break;
                            }
                        }
                        if (XmlReader.Name == "Student_must_znat") { continue; }
                        break;
                    case "Student_must_znat":
                        zap_richTextBox_with_abzac(ref this.richTextBoxTreb31, ref XmlReader);
                        break;
                    case "Student_must_umet":
                        zap_richTextBox_with_abzac(ref this.richTextBoxTreb32, ref XmlReader);
                        break;
                    case "Student_must_vladet":
                        zap_richTextBox_with_abzac(ref this.richTextBoxTreb33, ref XmlReader);
                        break;
                }
                XmlReader.Read();
            }
            this.sform_spisok_key_compet();
        }
        /// <summary>
        /// считывание из XmlREader узлов, содержащих информацию, необходимую для заполнения dataGridViewRazdelLesson
        /// </summary>
        /// <param name="XmlReader">из этого потока считываем</param>
        /// <param name="end_teg">тег, до которого необходимо считывать</param>
        private void zap_TabPage_for_DataGridViewRazdelLesson(ref XmlTextReader XmlReader, string end_teg) {
            this.dataGridViewRazdelLesson.CellEndEdit -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRazdelLesson_CellEndEdit);
            while (XmlReader.Name != end_teg) {
                switch (XmlReader.Name) {
                    case "Razdel":
                        if (XmlReader.HasAttributes) {
                            this.разделToolStripMenuItem_Click(this, new EventArgs());
                            this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["Semestr"].Value = XmlReader.GetAttribute("Semestr");
                            this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["ColumnTheme"].Value = XmlReader.GetAttribute("About_razdel");
                            if (this.Text == "РПД") {
                                /*if ((XmlReader.GetAttribute("IdFormCurControl").ToString() != String.Empty)) {
                                    this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["FormCurControlColumn"].Value = Convert.ToInt16((XmlReader.GetAttribute("IdFormCurControl").ToString()));
                                }
                                else {
                                    this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["FormCurControlColumn"].Value = null;
                                } */
                                this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["FormCurControlColumn"].Value = XmlReader.GetAttribute("FormCurControl");
                            }
                        }
                        break;
                    case "Theme":
                        if (XmlReader.HasAttributes) {
                            this.темаToolStripMenuItem_Click(this, new EventArgs());
                            this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["Semestr"].Value = XmlReader.GetAttribute("Semestr");
                            this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["ColumnTheme"].Value = XmlReader.GetAttribute("About_theme");
                            if (this.Text == "РПД") {
                                /*if ((XmlReader.GetAttribute("IdFormCurControl").ToString() != String.Empty)) {
                                    this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["FormCurControlColumn"].Value = Convert.ToInt16((XmlReader.GetAttribute("IdFormCurControl").ToString()));
                                }
                                else{
                                    this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["FormCurControlColumn"].Value = null;
                                } */
                                this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["FormCurControlColumn"].Value = XmlReader.GetAttribute("FormCurControl");
                            }                                                                                                                                                                             
                        }
                        break;
                    case "Lec":
                            this.лекциюToolStripMenuItem_Click(this, new EventArgs());
                            this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["ColumnTheme"].Value = XmlReader.GetAttribute("About_Lec");
                            this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["ColumnVolume"].Value = XmlReader.GetAttribute("Hours");
                        break;
                    case "Praktika":
                            this.семинарскоеЗанятиеToolStripMenuItem_Click(this, new EventArgs());
                            this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["ColumnTheme"].Value = XmlReader.GetAttribute("About_praktik");
                            this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["ColumnVolume"].Value = XmlReader.GetAttribute("Hours");
                        break;
                    case "SamJob":
                            this.самостРаботаToolStripMenuItem_Click(this, new EventArgs());
                            this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["ColumnTheme"].Value = XmlReader.GetAttribute("About_samJob");
                            this.dataGridViewRazdelLesson.Rows[this.dataGridViewRazdelLesson.RowCount - 1].Cells["ColumnVolume"].Value = XmlReader.GetAttribute("Hours");
                        break;
                    //только для РПД
                    case "Type_and_Form_promej_control":
                            zap_richTextBox_with_abzac(ref this.richTextBox4, ref XmlReader);
                        return;
                }                        
                XmlReader.Read();
            }
            this.dataGridViewRazdelLesson.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRazdelLesson_CellEndEdit);   
        }
        private void zap_RecomandLiterature(ref XmlTextReader XmlReader) {
            if (XmlReader.IsStartElement() && !XmlReader.IsEmptyElement) {
                string type_liter = String.Empty;
                this.dataGridView_for_Liter.AllowUserToAddRows = false;
                while (XmlReader.Read() && XmlReader.HasAttributes) {
                    this.dataGridView_for_Liter.Rows.Add();
                    switch (XmlReader.Name) {
                        case "Main_Liter":
                            type_liter = "Основная";
                            this.dataGridView_for_Liter.Rows[this.dataGridView_for_Liter.RowCount - 1].Cells[1].Value = XmlReader.GetAttribute("Author");
                            break;
                        case "Dop_Liter":
                            type_liter = "Дополнительная";
                            this.dataGridView_for_Liter.Rows[this.dataGridView_for_Liter.RowCount - 1].Cells[1].Value = XmlReader.GetAttribute("Author");
                            break;
                        case "Elektr_Resourse":
                            type_liter = "Электронный ресурс";
                            this.dataGridView_for_Liter.Rows[this.dataGridView_for_Liter.RowCount - 1].Cells[1].Value = XmlReader.GetAttribute("Author");
                            break;
                    }
                    this.dataGridView_for_Liter.Rows[this.dataGridView_for_Liter.RowCount - 1].Cells[0].Value = type_liter;
                }
                this.dataGridView_for_Liter.AllowUserToAddRows = true;
            }
        }
        /// <summary>
        /// считывание из XmlReader узлов, содержащих информацию о текущем контроле успеваемости для заполнения 
        /// datagridviewCurrentControl
        /// </summary>
        /// <param name="XmlReader"></param>
        private void zap_datagridviewCurrentControl(ref XmlTextReader XmlReader) {
            if (XmlReader.IsStartElement() && !XmlReader.IsEmptyElement) {
                this.dataGridView_for_CurrentControl.AllowUserToAddRows = false;
                this.dataGridView_for_CurrentControl.Rows.Clear();
                while (XmlReader.Read() && XmlReader.HasAttributes) {
                    this.dataGridView_for_CurrentControl.Rows.Add();
                    int CurRow = this.dataGridView_for_CurrentControl.RowCount - 1;
                    this.dataGridView_for_CurrentControl.Rows[CurRow].Cells["ControlColumn"].Value = XmlReader.GetAttribute("Name_meropriyatie");
                    this.dataGridView_for_CurrentControl.Rows[CurRow].Cells["Kol_vo_ball"].Value = XmlReader.GetAttribute("Ball");
                    this.dataGridView_for_CurrentControl.Rows[CurRow].Cells["Razdel_theme_column"].Value = XmlReader.GetAttribute("Num_theme");
                }
                this.dataGridView_for_CurrentControl.AllowUserToAddRows = true;
            }
        }
        #endregion

        #region основные методы для заполнения всех программы из файла *.xml
        /// <summary>
        /// считывание данных из *.XML (УМК) в программу
        /// </summary>
        /// <param name="path"></param>
        private void Load_UMK_To_Program_from_XML(ref XmlTextReader XmlReader){
            Clear_all_control();
            if (table_for_key_compet == null) {
                table_for_key_compet = new DataGridView[20];
            }                                       
            XmlReader.Read();
            //находим тег, обеспечивающий идентификацию Xml-файла
            //Если XmlReader.Name == "umk" тогда продолжаем иначе выдаем 
            //предупреждение и выходим из метода без заполнения данных в программе
            XmlReader.Read();
            if (XmlReader.Name.ToLower() != "umk") {
                MessageBox.Show(this, "Для открытия выбран не корректный файл (в файле содержится информация не для УМК)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            while (!XmlReader.EOF) {
                if (XmlReader.NodeType == XmlNodeType.Element) {
                    switch (XmlReader.Name) {
                        case "Title_inf_for_program":
                                zap_TabPage_Title(ref XmlReader);    
                            break;
                        case "UMK_razdel_1":
                                zap_TabPage_for_zapiska_and_compet(ref XmlReader, XmlReader.Name);    
                            break;
                        case "Soderjanie_razd_discip":
                                zap_TabPage_for_DataGridViewRazdelLesson(ref XmlReader, "Razdel_2");
                                podshet_hours_in_RazdelLesson();
                            break;
                        case "Recommand_literature":
                                zap_RecomandLiterature(ref XmlReader);
                            break;
                        case "CurrentControl":
                                while (XmlReader.Read()) {
                                    switch (XmlReader.Name) {
                                        case "CurControl":
                                                /*if (XmlReader.IsStartElement() && !XmlReader.IsEmptyElement) {
                                                    this.dataGridView_for_CurrentControl.AllowUserToAddRows = false;
                                                    this.dataGridView_for_CurrentControl.Rows.Clear();
                                                    while (XmlReader.Read() && XmlReader.HasAttributes) {
                                                        this.dataGridView_for_CurrentControl.Rows.Add();
                                                        int CurRow = this.dataGridView_for_CurrentControl.RowCount - 1;
                                                        this.dataGridView_for_CurrentControl.Rows[CurRow].Cells["ControlColumn"].Value = XmlReader.GetAttribute("Name_meropriyatie");
                                                        this.dataGridView_for_CurrentControl.Rows[CurRow].Cells["Kol_vo_ball"].Value = XmlReader.GetAttribute("Ball");
                                                        this.dataGridView_for_CurrentControl.Rows[CurRow].Cells["Razdel_theme_column"].Value = XmlReader.GetAttribute("Num_theme");
                                                    }
                                                    this.dataGridView_for_CurrentControl.AllowUserToAddRows = true;
                                                }*/
                                                zap_datagridviewCurrentControl(ref XmlReader);
                                            break;
                                        case "Form_and_rules_attestat":
                                                zap_richTextBox_with_abzac(ref richTextBox_for_pravila_proved_attest,  ref XmlReader);
                                            break;
                                        case "Voprosy_k_ekz":
                                                if (XmlReader.IsStartElement() && !XmlReader.IsEmptyElement) {
                                                    this.dataGridView_Vopros_k_ekz.AllowUserToAddRows = false;
                                                    while (XmlReader.Read() && XmlReader.HasAttributes) {
                                                        this.dataGridView_Vopros_k_ekz.Rows.Add();
                                                        this.dataGridView_Vopros_k_ekz.Rows[this.dataGridView_Vopros_k_ekz.RowCount - 1].Cells[0].Value = XmlReader.GetAttribute("Value");
                                                    }
                                                    this.dataGridView_Vopros_k_ekz.AllowUserToAddRows = true;
                                                }
                                            break;
                                        case "Example_ekz_Unit":
                                                zap_richTextBox_with_abzac(ref richTextBox3, ref XmlReader);
                                            break;
                                    }
                                    if (XmlReader.Name == "CurrentControl") {
                                        break;
                                    }                                        
                                }
                            break;
                    }    
                }
                XmlReader.Read();
            }
            XmlReader.Close();
        }
        /// <summary>
        /// считывание данных из *.XML (РПД) в программу
        /// </summary>
        /// <param name="path"></param>
        private void Load_RPD_To_Program_from_XML(ref XmlTextReader XmlReader) {
            Clear_all_control();
            if (table_for_key_compet == null) {
                table_for_key_compet = new DataGridView[20];
            }
            XmlReader.Read();
            //находим тег, обеспечивающий идентификацию Xml-файла
            //Если XmlReader.Name == "umk" тогда продолжаем иначе выдаем 
            //предупреждение и выходим из метода без заполнения данных в программе
            XmlReader.Read();
            if (XmlReader.Name.ToLower() != "rpd") {
                MessageBox.Show(this, "Для открытия выбран не корректный файл (в файле содержится информация не для РПД)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            while (!XmlReader.EOF) {
                if (XmlReader.NodeType == XmlNodeType.Element) {
                    switch (XmlReader.Name) {
                        case "Title_inf_for_program":
                                zap_TabPage_Title(ref XmlReader);
                            break;
                        case "RPD_1_2_3":
                                zap_TabPage_for_zapiska_and_compet(ref XmlReader, "RPD_1_2_3");                        
                            break;
                        case "RPD_4_5":
                                while (XmlReader.Read() && XmlReader.Name != "RPD_4_5") {
                                    switch (XmlReader.Name) {
                                        case "Soderjanie_razd_discip":                                                
                                                zap_TabPage_for_DataGridViewRazdelLesson(ref XmlReader, "Type_and_Form_promej_control");
                                                podshet_hours_in_RazdelLesson();
                                                if (XmlReader.IsStartElement() && !XmlReader.IsEmptyElement) {
                                                    //Сразу считываем информацию для поля "Вид и форма промежуточной аттестации"
                                                    while (XmlReader.Read() && XmlReader.Name != "Type_and_Form_promej_control") {
                                                        this.richTextBox4.Text += XmlReader.GetAttribute("Value") + '\n';
                                                    }
                                                }
                                                if (this.richTextBox4.Text != string.Empty) {
                                                    richTextBox4.Text = richTextBox4.Text.Substring(0, richTextBox4.Text.Length - 1);
                                                }
                                            break;
                                        case "Obraz_technology":
                                                richTextBox5.Text = String.Empty;
                                                while (XmlReader.Read() && XmlReader.Name != "Part_zanyatii") {
                                                    richTextBox5.Text += XmlReader.GetAttribute("Value") + '\n';
                                                }
                                                if (richTextBox5.Text != String.Empty) {
                                                    richTextBox5.Text = richTextBox5.Text.Substring(0, richTextBox5.Text.Length - 1);
                                                }
                                                //Считывание поля для заполнения "доля занятий с использованием активных и интерактивных методов"
                                                textBox_for_Dolya_interaktiv_method.Text = XmlReader.GetAttribute("Value");
                                            break;
                                    }
                                    XmlReader.Read();
                                }
                            break;
                        case "RPD_6":
                                XmlReader.Read();
                                while (XmlReader.Name != "RPD_6") {
                                    switch (XmlReader.Name) {
                                        case "CurrentControl":
                                                //zap_richTextBox_with_abzac(ref this.richTextBox6, ref XmlReader);
                                                zap_datagridviewCurrentControl(ref XmlReader);
                                            break;
                                        case "Example_Zad_CurControl":
                                                zap_richTextBox_with_abzac(ref this.richTextBox9, ref XmlReader);
                                            break;
                                        case "Theme_Referats":
                                                zap_richTextBox_with_abzac(ref this.richTextBox8, ref XmlReader);
                                            break;
                                        case "Theme_KursJob":
                                                zap_richTextBox_with_abzac(ref this.richTextBox7, ref XmlReader);
                                            break;
                                        case "MethodUkaz_SamJob":
                                                zap_richTextBox_with_abzac(ref this.richTextBox14, ref XmlReader);
                                            break;
                                        case "Promej_Control":
                                                XmlReader.Read();
                                                while (XmlReader.Name != "Promej_Control") {
                                                    switch(XmlReader.Name){
                                                        case "About_promej_Control":
                                                                zap_richTextBox_with_abzac(ref this.richTextBox12, ref XmlReader);
                                                            break;
                                                        case "Example_Zad":
                                                                zap_richTextBox_with_abzac(ref this.richTextBox11, ref XmlReader);
                                                            break;
                                                        case "Vopros_k_Ekz":
                                                                zap_richTextBox_with_abzac(ref this.richTextBox10, ref XmlReader);
                                                            break;
                                                    }                              
                                                    XmlReader.Read();                                                    
                                                }                                                                                
                                            break;
                                    }                                                      
                                    XmlReader.Read();                        
                                }
                            break;
                        case "Recommand_literature":
                                zap_RecomandLiterature(ref XmlReader);
                            break;
                        case "Technical_Obespech":
                                zap_richTextBox_with_abzac(ref this.richTextBox13, ref XmlReader);
                            break;
                    }
                }
                XmlReader.Read();
            }
            XmlReader.Close();
        }
        #endregion
    }
} 