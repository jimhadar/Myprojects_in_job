using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UMK_RPD {
    
    public partial class HeadForm : Form {        
        public HeadForm() {
            InitializeComponent();
            UMK_RPD.Properties.Settings.Default.Setting_for_SaveRPD = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
            UMK_RPD.Properties.Settings.Default.Setting_for_SaveUMK = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments).ToString();
            UMK_RPD.Properties.Settings.Default.Save();
        }
        private void HeadForm_Load(object sender, EventArgs e) {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.NewRpd_btn, "Создать новую РПД");
            toolTip.SetToolTip(this.NewUmk_btn, "Создать новый УМК");
            toolTip.SetToolTip(this.Find_btn, "Найти РПД / УМК");
            toolTip.SetToolTip(this.Settings_btn, "Выбрать место для сохранения готовой РПД / УМК");
        }
        private void уМКToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (!this.FindFirstChildForm("УМК")) {
                ModeProgram modeProgram = new ModeProgram(OpenMode.NewUmk, 0);
                Form_for_UMK_and_RPD Umk = new Form_for_UMK_and_RPD(modeProgram);
                Umk.MdiParent = this;
                Umk.Text = "УМК";
                Umk.Show();
            }
        }
        /// <summary>
        /// находит первое вхождение формы типа  Form_for_UMK_and_RPD и именем   NameTitleForm
        /// в список дочерних форм данной формы,
        /// если форма найдена, то возвращает true, иначе - false
        /// </summary>
        /// <param name="NameTitleForm"> == РПД||УМК</param>
        /// <returns></returns>
        private bool FindFirstChildForm(string NameTitleForm) {
            foreach(Form form in this.MdiChildren){
                if(form is Form_for_UMK_and_RPD && form.Text == NameTitleForm){
                    return true;
                }
            }
            return false;
        }
        private void рПДToolStripMenuItem1_Click(object sender, EventArgs e) {
            if(!this.FindFirstChildForm("РПД")){
                ModeProgram modeProgram = new ModeProgram(OpenMode.NewRpd, 0);
                Form_for_UMK_and_RPD Rpd = new Form_for_UMK_and_RPD(modeProgram);
                Rpd.MdiParent = this;
                Rpd.Text = "РПД";
                Rpd.Show();
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e) {
            SettingsForm Setting = new SettingsForm();
            Setting.ShowDialog(this);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void поискРПДУМКToolStripMenuItem_Click(object sender, EventArgs e) {
            ExportForm exportForm = new ExportForm();
            exportForm.MdiParent = this;
            exportForm.Show();
        }

        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void стопкойToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void рядомToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void NewRpd_btn_Click(object sender, EventArgs e) {
            рПДToolStripMenuItem1_Click(sender, e); 
        }

        private void NewUmk_btn_Click(object sender, EventArgs e) {
            this.уМКToolStripMenuItem1_Click(sender, e);
        }

        private void Find_btn_Click(object sender, EventArgs e) {
            this.поискРПДУМКToolStripMenuItem_Click(sender, e);             
        }

        private void Settings_btn_Click(object sender, EventArgs e) {
            this.настройкиToolStripMenuItem_Click(sender, e);    
        }

        private void Close_btn_Click(object sender, EventArgs e) {
            Close();
        }

        private void показыватьИнструментальнуПанельToolStripMenuItem_Click(object sender, EventArgs e) {
            panel1.Visible = !panel1.Visible;
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e) {
            Form_for_aboutProgram AboutProgram = new Form_for_aboutProgram();
            AboutProgram.ShowDialog();
        }            
    }
}
