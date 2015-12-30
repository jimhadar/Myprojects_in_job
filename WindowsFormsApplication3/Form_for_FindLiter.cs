using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UMK_RPD {
    internal partial class Form_for_FindLiter : Form {
        /// <summary>
        /// Параметр для поиска по ключевому слову
        /// </summary>
        string KeyWord = string.Empty; 
        /// <summary>
        /// Параметр для поиска по автору
        /// </summary>
        string Author = string.Empty;
        /// <summary>
        /// параметр для поиска по названию книги
        /// </summary>
        string Name = string.Empty;
        /// <summary>
        /// параметр для поиска по году издания книги
        /// </summary>
        string DataIzd = string.Empty;
        /// <summary>
        /// Для того, чтобы передать результат поиска литературы в основную форму
        /// </summary>
        Form_for_UMK_and_RPD ParentForm;
        DataTable ResultTable;
        public Form_for_FindLiter() {
            InitializeComponent(); 
        }
        public Form_for_FindLiter(Form_for_UMK_and_RPD ParentForm) {
            this.ParentForm = ParentForm;
            InitializeComponent();
        }
        private void Fill_all_Values(object sender, EventArgs e) {
            KeyWord = (this.textBoxKeyWord.Text.Trim() == String.Empty) ? string.Empty : this.textBoxKeyWord.Text.Trim();
            Author = (this.textBoxAuthor.Text.Trim() == String.Empty) ? string.Empty : this.textBoxAuthor.Text.Trim();
            Name = (this.textBoxName.Text.Trim() == String.Empty) ? string.Empty : this.textBoxName.Text.Trim();
            DataIzd = (this.textBoxDataIzd.Text.Trim() == String.Empty) ? string.Empty : this.textBoxDataIzd.Text.Trim();
            ResultTable = this.lib_BookTableAdapter.GetData_with_param(Name, Author, DataIzd, KeyWord);
            this.dataGridViewResult.DataSource = ResultTable;
        }
        private void Ok_button_Click(object sender, EventArgs e) {
            Fill_all_Values(sender, e);                                  
        }

        private void Form_for_FindLiter_Load(object sender, EventArgs e) {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "academia_for_UMK.Lib_Book". При необходимости она может быть перемещена или удалена.
            //this.lib_BookTableAdapter.Fill(this.academia_for_UMK.Lib_Book); 
        }

        private void dataGridViewResult_DoubleClick(object sender, EventArgs e) {
            this.ParentForm.dataGridView_for_Liter.CurrentRow.Cells["Author"].Value =  dataGridViewResult.CurrentRow.Cells["authorColumn"].Value.ToString().Trim() + " " +
                                                                                                                                      dataGridViewResult.CurrentRow.Cells["nameColumn"].Value.ToString().Trim() + ". - " +
                                                                                                                                      dataGridViewResult.CurrentRow.Cells["mestoIzdColumn"].Value.ToString().Trim() + ": " +
                                                                                                                                      dataGridViewResult.CurrentRow.Cells["nameIzdColumn"].Value.ToString().Trim() + ", " +
                                                                                                                                      dataGridViewResult.CurrentRow.Cells["dataIzdColumn"].Value.ToString().Trim() + '.';
            this.Close();
        }                 
    }
}
