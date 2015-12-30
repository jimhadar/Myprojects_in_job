namespace UMK_RPD {
    partial class Form_for_find {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.find_pr_textBox = new System.Windows.Forms.TextBox();
            this.pr_label = new System.Windows.Forms.Label();
            this.OK_button = new System.Windows.Forms.Button();
            this.Find_dataGridView = new System.Windows.Forms.DataGridView();
            this.fIOColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cODPEColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prepodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academia_for_UMK = new UMK_RPD.Academia_for_UMK();
            this.prepodTableAdapter = new UMK_RPD.Academia_for_UMKTableAdapters.PrepodTableAdapter();
            this.subsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subs1TableAdapter = new UMK_RPD.Academia_for_UMKTableAdapters.Subs1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Find_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prepodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academia_for_UMK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // find_pr_textBox
            // 
            this.find_pr_textBox.Location = new System.Drawing.Point(177, 9);
            this.find_pr_textBox.Name = "find_pr_textBox";
            this.find_pr_textBox.Size = new System.Drawing.Size(308, 20);
            this.find_pr_textBox.TabIndex = 0;
            this.find_pr_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.find_pr_textBox_KeyPress);
            // 
            // pr_label
            // 
            this.pr_label.AutoSize = true;
            this.pr_label.Location = new System.Drawing.Point(12, 12);
            this.pr_label.Name = "pr_label";
            this.pr_label.Size = new System.Drawing.Size(162, 13);
            this.pr_label.TabIndex = 2;
            this.pr_label.Text = "Введите ФИО преподавателя:";
            // 
            // OK_button
            // 
            this.OK_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OK_button.Location = new System.Drawing.Point(12, 200);
            this.OK_button.Name = "OK_button";
            this.OK_button.Size = new System.Drawing.Size(236, 36);
            this.OK_button.TabIndex = 2;
            this.OK_button.Text = "Выбрать преподавателя";
            this.OK_button.UseVisualStyleBackColor = false;
            this.OK_button.Click += new System.EventHandler(this.OK_button_Click);
            // 
            // Find_dataGridView
            // 
            this.Find_dataGridView.AutoGenerateColumns = false;
            this.Find_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Find_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fIOColumn,
            this.cODPEColumn});
            this.Find_dataGridView.DataSource = this.prepodBindingSource;
            this.Find_dataGridView.Location = new System.Drawing.Point(12, 35);
            this.Find_dataGridView.Name = "Find_dataGridView";
            this.Find_dataGridView.ReadOnly = true;
            this.Find_dataGridView.Size = new System.Drawing.Size(473, 150);
            this.Find_dataGridView.TabIndex = 1;
            this.Find_dataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Find_dataGridView_CellEnter);
            // 
            // fIOColumn
            // 
            this.fIOColumn.DataPropertyName = "FIO";
            this.fIOColumn.HeaderText = "ФИО";
            this.fIOColumn.Name = "fIOColumn";
            this.fIOColumn.ReadOnly = true;
            this.fIOColumn.Width = 250;
            // 
            // cODPEColumn
            // 
            this.cODPEColumn.DataPropertyName = "CODPE";
            this.cODPEColumn.HeaderText = "CODPE";
            this.cODPEColumn.Name = "cODPEColumn";
            this.cODPEColumn.ReadOnly = true;
            this.cODPEColumn.Visible = false;
            // 
            // prepodBindingSource
            // 
            this.prepodBindingSource.DataMember = "Prepod";
            this.prepodBindingSource.DataSource = this.academia_for_UMK;
            // 
            // academia_for_UMK
            // 
            this.academia_for_UMK.DataSetName = "Academia_for_UMK";
            this.academia_for_UMK.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // prepodTableAdapter
            // 
            this.prepodTableAdapter.ClearBeforeFill = true;
            // 
            // subsBindingSource
            // 
            this.subsBindingSource.DataMember = "Subs1";
            this.subsBindingSource.DataSource = this.academia_for_UMK;
            // 
            // subs1TableAdapter
            // 
            this.subs1TableAdapter.ClearBeforeFill = true;
            // 
            // Form_for_find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(495, 246);
            this.Controls.Add(this.OK_button);
            this.Controls.Add(this.pr_label);
            this.Controls.Add(this.find_pr_textBox);
            this.Controls.Add(this.Find_dataGridView);
            this.Name = "Form_for_find";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск преподавателя";
            this.Load += new System.EventHandler(this.Form_for_find_prepod_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Find_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prepodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academia_for_UMK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox find_pr_textBox;
        private System.Windows.Forms.Label pr_label;
        private System.Windows.Forms.Button OK_button;
        private System.Windows.Forms.DataGridView Find_dataGridView;
        private System.Windows.Forms.BindingSource prepodBindingSource;
        private Academia_for_UMK academia_for_UMK;
        private Academia_for_UMKTableAdapters.PrepodTableAdapter prepodTableAdapter;
        private System.Windows.Forms.BindingSource subsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fIOColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODPEColumn;
        private Academia_for_UMKTableAdapters.Subs1TableAdapter subs1TableAdapter;
    }
}