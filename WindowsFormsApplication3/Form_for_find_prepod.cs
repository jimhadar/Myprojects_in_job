using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UMK_RPD {
    public partial class Form_for_find : Form {
        int CODPE;
        int Cod_sub;
        int Cod_Plan;
        public Form_for_find() {
            InitializeComponent();
        }

        private void Form_for_find_prepod_Load(object sender, EventArgs e) {
            this.Find_dataGridView.AllowUserToAddRows = false;
            switch (this.Text) {
                case "Поиск дисциплины":
                        this.Find_dataGridView.DataSource = this.subsBindingSource;
                        this.OK_button.Text = "Выбрать дисциплину";
                        this.pr_label.Text = "Введите название дисциплины";
                        this.Find_dataGridView.Columns[0].Name = "CodSubColumn";
                        this.Find_dataGridView.Columns[1].Name = "nameSubColumn";
                        this.Find_dataGridView.Columns["nameSubColumn"].HeaderText = "Дисциплина";
                        this.Find_dataGridView.Columns["CodSubColumn"].HeaderText = "Код дисциплины";

                        this.Find_dataGridView.Columns["CodSubColumn"].Visible = false;
                        this.Find_dataGridView.Columns["nameSubColumn"].Visible = true;

                        this.Find_dataGridView.Columns["CodSubColumn"].DataPropertyName = "CodSub";
                        this.Find_dataGridView.Columns["nameSubColumn"].DataPropertyName = "NameSub";

                        this.Find_dataGridView.Columns["nameSubColumn"].Width = 300;

                        this.subs1TableAdapter.Fill(academia_for_UMK.Subs1, Cod_Plan);
                    break;
                case "Поиск преподавателя":
                        this.prepodTableAdapter.Fill(academia_for_UMK.Prepod, "");
                    break;
            }
            this.find_pr_textBox.Focus();
        }
        /// <summary>
        /// обработка введенного ФИО преподавателя и вывод в comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void find_pr_textBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (!(Char.IsWhiteSpace(e.KeyChar)) && !(Char.IsLetterOrDigit(e.KeyChar)) && !char.IsControl(e.KeyChar)) {
                e.KeyChar = '\0';
            }
            string temp = this.find_pr_textBox.Text;
            if (e.KeyChar == '\b') {
                if (this.find_pr_textBox.Text.Length == 1) {
                    temp = String.Empty;
                }
                if (this.find_pr_textBox.Text != String.Empty) {
                    temp = temp.Substring(0, find_pr_textBox.Text.Length - 1);
                }                 
            }
            else 
            if(e.KeyChar != '\0'){
                temp += e.KeyChar;
            }
            switch (this.Text) {
                case "Поиск преподавателя":
                    if (this.prepodTableAdapter.Fill(academia_for_UMK.Prepod, temp) != 0) {
                        cod_prep = Convert.ToInt32(this.Find_dataGridView.CurrentRow.Cells["cODPEColumn"].Value.ToString());
                    }
                    else { cod_prep = -1; }
                    break;
                case "Поиск дисциплины":
                    if (this.subs1TableAdapter.Fill_NameSub(academia_for_UMK.Subs1, Cod_Plan, temp) != 0) {
                        Cod_sub = Convert.ToInt32(this.Find_dataGridView.CurrentRow.Cells["CodSubColumn"].Value.ToString());
                    }
                    else { Cod_sub = -10; }
                    break;
            }
        }
        /// <summary>
        /// Возвращает код преподавателя
        /// </summary>
        public int cod_prep {
            set {
                this.CODPE = value;
            }
            get{
                return CODPE;
            }
        }
        /// <summary>
        /// Возвращает код предмета
        /// </summary>
        public int CodSub {
            get {
                return Cod_sub;
            }
        }
        /// <summary>
        /// Позволяет задать код плана
        /// </summary>
        public int CodPlan {
            set {
                this.Cod_Plan = value;
            }
        }
        private void OK_button_Click(object sender, EventArgs e) {          
            switch (this.Text) {
                case "Поиск преподавателя":
                    if ((this.find_pr_textBox.Text == String.Empty || cod_prep == -1) && Find_dataGridView.RowCount == 0) {
                        var msg = MessageBox.Show(this, "Преподавателя не найдено! Хотите продолжить поиск?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (msg == DialogResult.Yes) {
                            cod_prep = -1;
                            return;
                        }
                    }
                    this.Close();
                    break;
                case "Поиск дисциплины":
                    if ((this.find_pr_textBox.Text == String.Empty || Cod_sub == -10) && Find_dataGridView.RowCount == 0) {
                        var msg = MessageBox.Show(this, "Предметов не найдено! Хотите продолжить поиск?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (msg == DialogResult.Yes) {
                            Cod_sub = -10;
                            return;
                        }
                    }
                    this.Close(); 
                    break;
            }
        }

        private void Find_dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e) {
            switch (this.Text) {
                case "Поиск преподавателя":
                    if (Find_dataGridView.RowCount > 0) {
                        cod_prep = Convert.ToInt32(this.Find_dataGridView.CurrentRow.Cells["cODPEColumn"].Value.ToString());
                    }
                    else { cod_prep = -1; }    
                    break;
                case "Поиск дисциплины":
                    if (Find_dataGridView.RowCount > 0) {
                        Cod_sub = Convert.ToInt32(this.Find_dataGridView.CurrentRow.Cells["CodSubColumn"].Value.ToString());
                    }
                    else{ Cod_Plan = -10; }
                    break;
            }
        }
    }
}
