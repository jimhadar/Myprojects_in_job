using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Deployment.Application;

namespace UMK_RPD {
    public partial class Form_for_aboutProgram : Form {
        public Form_for_aboutProgram() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Form_for_aboutProgram_Load(object sender, EventArgs e) {
            Assembly assem = Assembly.GetExecutingAssembly();
            AssemblyName assemName = assem.GetName();
            Version ver = assemName.Version; 
            this.label2.Text = ver.ToString();
        }
    }
}
