using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace UMK_RPD
{
    public partial class ExportForm : Form {

        #region Необходимые переменные
        /// <summary>
        /// хранит текущие данные для заполнения datagridview
        /// </summary>
        DataTable RPD_and_UMK_Table;
        /// <summary>
        /// код преподавателя по нагрузке
        /// </summary>
        int? CodPrep = null;
        /// <summary>
        ///  код факультета для дисциплины
        /// </summary>     
        byte? CodFac = null;
        /// <summary>
        /// Код кафедры  для дисциплины
        /// </summary>
        byte? CodKaf = null;
        /// <summary>
        /// Код плана
        /// </summary>
        short? CodPlan = null;
        /// <summary>
        /// Учебный год
        /// </summary>
        short? Year = null;
        /// <summary>
        /// Код направелния подготовки
        /// </summary>
        string CodSpec = null;
        /// <summary>
        /// Тип обучения
        /// </summary>
        byte? CodTypeEdu = null;
        /// <summary>
        /// форма обучения
        /// </summary>
        byte? CodFormaOb = null;
        #endregion

        #region  вспомогательные методы
        private void LoadStudyPlansTableAdapter() {
            try {
                this.studyPlansTableAdapter.Fill(academia_for_UMK.StudyPlans, (this.CodFormaOb != null) ? (byte)this.CodFormaOb : (byte)0, (this.CodTypeEdu != null) ? (byte)this.CodTypeEdu : (byte)10, (this.CodSpec != null) ? this.CodSpec : null);
            }
            catch {
                this.studyPlansTableAdapter.Fill(academia_for_UMK.StudyPlans, (this.CodFormaOb != null) ? (byte)this.CodFormaOb : (byte)0, (this.CodTypeEdu != null) ? (byte)this.CodTypeEdu : (byte)10, (this.CodSpec != null) ? this.CodSpec : null);
            }
        }
        #endregion

        public ExportForm()
        {
            InitializeComponent();            
        } 
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "academia_for_UMK.TypeEdu". При необходимости она может быть перемещена или удалена.
            this.typeEduTableAdapter.Fill(this.academia_for_UMK.TypeEdu);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "academia_for_UMK.FormStudy". При необходимости она может быть перемещена или удалена.
            this.formStudyTableAdapter.Fill(this.academia_for_UMK.FormStudy);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "academia_for_UMK.Faculty". При необходимости она может быть перемещена или удалена.
            this.facultyTableAdapter.Fill(this.academia_for_UMK.Faculty);
            this.comboBox_for_typeEdu.SelectedValue = 10;
            this.CodTypeEdu = 10;
            this.CodFormaOb = 0;
            for (int i = System.DateTime.Now.Year - 4; i <= System.DateTime.Now.Year + 4; i++) {
                comboBox_for_year.Items.Add(i);
            }
            comboBox_for_year.SelectedIndex = 4;
            this.Top = 1;
            this.Left = 1;
        }
        private void GetValues() {
            if(!this.checkBox_for_prepod.Checked)
                CodPrep = null;

            if (this.checkBox_for_faculty.Checked) {
                CodFac = (byte?)this.comboBoxFaculty.SelectedValue;
            }
            else {
                CodFac = null;
            }

            if (this.checkBox_for_Kafs.Checked) {
                CodKaf = (byte?)this.comboBoxKaf.SelectedValue;
            }
            else {
                CodKaf = null;
            }

            if(this.checkBox_StudyPlan.Checked){
                CodPlan = (short?)this.comboBox_StudyPlan.SelectedValue;
            }
            else {
                CodPlan = null;
            }

            if (checkBox_for_year.Checked) {
                Year = Convert.ToInt16(this.comboBox_for_year.Items[comboBox_for_year.SelectedIndex].ToString());
            }
            else {
                Year = null;
            }

            if (this.checkBox_for_Spec.Checked) {
                CodSpec = (string)this.comboBox_for_spec.SelectedValue;
            }
            else {
                CodSpec = null;
            }

            CodTypeEdu = (byte?)this.comboBox_for_typeEdu.SelectedValue;

            CodFormaOb = (byte?)this.comboBox_formaob.SelectedValue;

            this.RPD_and_UMK_Table = this.uMK_and_RPD_with_opisanieTableAdapter.GetData(this.CodFac, this.CodKaf, this.CodPrep, this.Year, this.CodPlan, this.CodSpec, this.CodTypeEdu, this.CodFormaOb);

            this.dataGridView_for_UMK_and_RPD.DataSource = this.RPD_and_UMK_Table;
        }
        private void textBox_for_prepod_Click(object sender, EventArgs e) {
            Form_for_find find_pr = new Form_for_find();
            find_pr.ShowDialog(this);
            this.CodPrep = find_pr.cod_prep;
            if (CodPrep == -1) {
                this.textBox_prepod.Text = String.Empty;
            }
            else {
                this.textBox_prepod.Text = (string)this.prepodTableAdapter.Get_FIO((int)this.CodPrep);
            }    
        }

        private void checkBox_for_year_CheckedChanged(object sender, EventArgs e) {
            this.comboBox_for_year.Enabled = this.checkBox_for_year.Checked;
        }
             
        private void ok_button_Click(object sender, EventArgs e) {
            GetValues();
            
            if(this.dataGridView_for_UMK_and_RPD.RowCount == 0){
            //if(RPD_and_UMK_Table.Rows.Count == 0){
                MessageBox.Show("Нет ни одной РПД/УМК, удовлетворяющей выбранным критериям!",
                                "Ошибка поиска",
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e) {
            ModeProgram modeProgram = new ModeProgram(((bool)dataGridView_for_UMK_and_RPD.CurrentRow.Cells["uMKorRPDCheckBoxColumn"].Value ? OpenMode.OpenUmk : OpenMode.OpenRpd), (int)dataGridView_for_UMK_and_RPD.CurrentRow.Cells["idRPDorUMKColumn"].Value);
            Form_for_UMK_and_RPD form_for_RPD_or_UMK = new Form_for_UMK_and_RPD(modeProgram);
            form_for_RPD_or_UMK.MdiParent = this.ParentForm;
            form_for_RPD_or_UMK.Show();
        }

        private void comboBoxFaculty_SelectedIndexChanged(object sender, EventArgs e) {
            if(this.comboBoxFaculty.SelectedValue != null){
                this.CodFac = (byte)this.comboBoxFaculty.SelectedValue;
                this.kafsTableAdapter.Fill(academia_for_UMK.Kafs, (byte)this.CodFac);
            }
        }

        private void comboBox_formaob_SelectedIndexChanged(object sender, EventArgs e) {
            if(comboBox_formaob.SelectedValue != null){
                this.CodFormaOb = (byte)this.comboBox_formaob.SelectedValue;
                if (this.checkBox_StudyPlan.Checked) {
                    LoadStudyPlansTableAdapter();
                }
            }                 
        }

        private void comboBox_for_typeEdu_SelectedIndexChanged(object sender, EventArgs e) {
            if(this.comboBox_for_typeEdu.SelectedValue != null){
                this.CodTypeEdu = (byte)this.comboBox_for_typeEdu.SelectedValue;
                if (this.checkBox_for_Spec.Checked) {
                    this.specialityTableAdapter.Fill(academia_for_UMK.Speciality, (byte)CodTypeEdu);
                    this.CodSpec = (string)this.comboBox_for_spec.SelectedValue;
                    LoadStudyPlansTableAdapter();
                }
            }                
        }

        private void checkBox_for_prepod_CheckedChanged(object sender, EventArgs e) {
            this.textBox_prepod.Enabled = this.checkBox_for_prepod.Checked;
        }

        private void checkBox_for_faculty_CheckedChanged(object sender, EventArgs e) {
            this.comboBoxFaculty.Enabled = this.checkBox_for_faculty.Checked;
            if(this.checkBox_for_Kafs.Checked && !this.checkBox_for_faculty.Checked){
                this.checkBox_for_Kafs.Checked = false;
            }
            if(this.checkBox_for_faculty.Checked){
                this.facultyTableAdapter.Fill(academia_for_UMK.Faculty);
                if(this.comboBoxFaculty.SelectedValue != null){
                    this.CodFac = (byte)this.comboBoxFaculty.SelectedValue;
                }
                else {
                    this.CodFac = null;
                }
            }
        }

        private void checkBox_for_Kafs_CheckedChanged(object sender, EventArgs e) {
            this.comboBoxKaf.Enabled = this.checkBox_for_Kafs.Checked;
            if (!this.checkBox_for_faculty.Checked && this.checkBox_for_Kafs.Checked) {
                this.checkBox_for_faculty.Checked = true;
            }
            if (this.checkBox_for_Kafs.Checked) {
                this.kafsTableAdapter.Fill(academia_for_UMK.Kafs, (byte)this.CodFac);
            }
            else {
                this.CodKaf = null;
            }
        }

        private void checkBox_for_Spec_CheckedChanged(object sender, EventArgs e) {
            this.comboBox_for_spec.Enabled = this.checkBox_for_Spec.Checked;
            if (this.checkBox_for_Spec.Checked) {
                this.specialityTableAdapter.Fill(academia_for_UMK.Speciality, (this.CodTypeEdu != null) ? (byte)this.CodTypeEdu : (byte)10);
                this.CodSpec = (string)this.comboBox_for_spec.SelectedValue;
                if(checkBox_StudyPlan.Checked){
                    LoadStudyPlansTableAdapter();
                }
            }
            else {
                this.CodSpec = null;
            }
        }

        private void checkBox_StudyPlan_CheckedChanged(object sender, EventArgs e) {
            this.comboBox_StudyPlan.Enabled = this.checkBox_StudyPlan.Checked;
            if (this.checkBox_StudyPlan.Checked) {
                LoadStudyPlansTableAdapter();
            }
            else {
                this.CodPlan = null;
            }
        }

        private void comboBox_for_spec_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox_for_spec.SelectedValue != null) {
                this.CodSpec = this.comboBox_for_spec.SelectedValue.ToString();
            }
            if(this.checkBox_StudyPlan.Checked){
                LoadStudyPlansTableAdapter();
            }
        }    
    }      
}