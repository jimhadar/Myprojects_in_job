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
using Word = Microsoft.Office.Interop.Word;

namespace UMK_RPD
{

    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }
        private void btn_for_RPD_Click(object sender, EventArgs e) {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK){
                textBoxRPD.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.Setting_for_SaveRPD = folderBrowserDialog1.SelectedPath;
            }
        }
        private void Form3_Load(object sender, EventArgs e){            
            textBoxRPD.Text = Properties.Settings.Default.Setting_for_SaveRPD;
            textBoxUMK.Text = Properties.Settings.Default.Setting_for_SaveUMK;
        }

        private void btn_OK_Click(object sender, EventArgs e){            
            this.Close();
        }

        private void btn_for_UMK_Click(object sender, EventArgs e) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                textBoxUMK.Text = folderBrowserDialog.SelectedPath;
                Properties.Settings.Default.Setting_for_SaveUMK = folderBrowserDialog.SelectedPath;
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.Save();
        }
    }
}
