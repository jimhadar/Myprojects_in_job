namespace UMK_RPD {
    partial class Form_for_FindLiter {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.docIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grifColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mestoIzdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameIzdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataIzdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countBookColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codTypeBookColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.libBookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.academia_for_UMK = new UMK_RPD.Academia_for_UMK();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Ok_button = new System.Windows.Forms.Button();
            this.label_for_dataizd = new System.Windows.Forms.Label();
            this.label_for_name = new System.Windows.Forms.Label();
            this.label_for_key_word = new System.Windows.Forms.Label();
            this.label_for_author = new System.Windows.Forms.Label();
            this.textBoxDataIzd = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.textBoxKeyWord = new System.Windows.Forms.TextBox();
            this.lib_BookTableAdapter = new UMK_RPD.Academia_for_UMKTableAdapters.Lib_BookTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libBookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academia_for_UMK)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewResult, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(634, 443);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.AutoGenerateColumns = false;
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docIDColumn,
            this.docColumn,
            this.nameColumn,
            this.authorColumn,
            this.grifColumn,
            this.mestoIzdColumn,
            this.nameIzdColumn,
            this.dataIzdColumn,
            this.countBookColumn,
            this.tagsColumn,
            this.codTypeBookColumn,
            this.barCodeColumn});
            this.dataGridViewResult.DataSource = this.libBookBindingSource;
            this.dataGridViewResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewResult.Location = new System.Drawing.Point(3, 203);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.ReadOnly = true;
            this.dataGridViewResult.Size = new System.Drawing.Size(628, 237);
            this.dataGridViewResult.TabIndex = 0;
            this.dataGridViewResult.DoubleClick += new System.EventHandler(this.dataGridViewResult_DoubleClick);
            // 
            // docIDColumn
            // 
            this.docIDColumn.DataPropertyName = "DocID";
            this.docIDColumn.HeaderText = "DocID";
            this.docIDColumn.Name = "docIDColumn";
            this.docIDColumn.Visible = false;
            // 
            // docColumn
            // 
            this.docColumn.DataPropertyName = "Doc";
            this.docColumn.HeaderText = "Doc";
            this.docColumn.Name = "docColumn";
            this.docColumn.Visible = false;
            // 
            // nameColumn
            // 
            this.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameColumn.DataPropertyName = "name";
            this.nameColumn.HeaderText = "Название";
            this.nameColumn.Name = "nameColumn";
            // 
            // authorColumn
            // 
            this.authorColumn.DataPropertyName = "author";
            this.authorColumn.HeaderText = "Автор";
            this.authorColumn.Name = "authorColumn";
            this.authorColumn.Width = 150;
            // 
            // grifColumn
            // 
            this.grifColumn.DataPropertyName = "grif";
            this.grifColumn.HeaderText = "grif";
            this.grifColumn.Name = "grifColumn";
            this.grifColumn.Visible = false;
            // 
            // mestoIzdColumn
            // 
            this.mestoIzdColumn.DataPropertyName = "mestoIzd";
            this.mestoIzdColumn.HeaderText = "Место издания";
            this.mestoIzdColumn.Name = "mestoIzdColumn";
            // 
            // nameIzdColumn
            // 
            this.nameIzdColumn.DataPropertyName = "nameIzd";
            this.nameIzdColumn.HeaderText = "Издательство";
            this.nameIzdColumn.Name = "nameIzdColumn";
            this.nameIzdColumn.Width = 110;
            // 
            // dataIzdColumn
            // 
            this.dataIzdColumn.DataPropertyName = "dataIzd";
            this.dataIzdColumn.HeaderText = "Год";
            this.dataIzdColumn.Name = "dataIzdColumn";
            this.dataIzdColumn.Width = 50;
            // 
            // countBookColumn
            // 
            this.countBookColumn.DataPropertyName = "CountBook";
            this.countBookColumn.HeaderText = "CountBook";
            this.countBookColumn.Name = "countBookColumn";
            this.countBookColumn.Visible = false;
            // 
            // tagsColumn
            // 
            this.tagsColumn.DataPropertyName = "tags";
            this.tagsColumn.HeaderText = "tags";
            this.tagsColumn.Name = "tagsColumn";
            this.tagsColumn.Visible = false;
            // 
            // codTypeBookColumn
            // 
            this.codTypeBookColumn.DataPropertyName = "CodTypeBook";
            this.codTypeBookColumn.HeaderText = "CodTypeBook";
            this.codTypeBookColumn.Name = "codTypeBookColumn";
            this.codTypeBookColumn.Visible = false;
            // 
            // barCodeColumn
            // 
            this.barCodeColumn.DataPropertyName = "BarCode";
            this.barCodeColumn.HeaderText = "BarCode";
            this.barCodeColumn.Name = "barCodeColumn";
            this.barCodeColumn.Visible = false;
            // 
            // libBookBindingSource
            // 
            this.libBookBindingSource.DataMember = "Lib_Book";
            this.libBookBindingSource.DataSource = this.academia_for_UMK;
            // 
            // academia_for_UMK
            // 
            this.academia_for_UMK.DataSetName = "Academia_for_UMK";
            this.academia_for_UMK.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Ok_button);
            this.groupBox1.Controls.Add(this.label_for_dataizd);
            this.groupBox1.Controls.Add(this.label_for_name);
            this.groupBox1.Controls.Add(this.label_for_key_word);
            this.groupBox1.Controls.Add(this.label_for_author);
            this.groupBox1.Controls.Add(this.textBoxDataIzd);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.textBoxAuthor);
            this.groupBox1.Controls.Add(this.textBoxKeyWord);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 194);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск по";
            // 
            // Ok_button
            // 
            this.Ok_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Ok_button.Location = new System.Drawing.Point(9, 150);
            this.Ok_button.Name = "Ok_button";
            this.Ok_button.Size = new System.Drawing.Size(135, 38);
            this.Ok_button.TabIndex = 9;
            this.Ok_button.Text = "Начать поиск";
            this.Ok_button.UseVisualStyleBackColor = false;
            this.Ok_button.Click += new System.EventHandler(this.Ok_button_Click);
            // 
            // label_for_dataizd
            // 
            this.label_for_dataizd.AutoSize = true;
            this.label_for_dataizd.Location = new System.Drawing.Point(9, 113);
            this.label_for_dataizd.Name = "label_for_dataizd";
            this.label_for_dataizd.Size = new System.Drawing.Size(92, 16);
            this.label_for_dataizd.TabIndex = 8;
            this.label_for_dataizd.Text = "Год издания:";
            // 
            // label_for_name
            // 
            this.label_for_name.AutoSize = true;
            this.label_for_name.Location = new System.Drawing.Point(9, 85);
            this.label_for_name.Name = "label_for_name";
            this.label_for_name.Size = new System.Drawing.Size(77, 16);
            this.label_for_name.TabIndex = 7;
            this.label_for_name.Text = "Название:";
            // 
            // label_for_key_word
            // 
            this.label_for_key_word.AutoSize = true;
            this.label_for_key_word.Location = new System.Drawing.Point(9, 29);
            this.label_for_key_word.Name = "label_for_key_word";
            this.label_for_key_word.Size = new System.Drawing.Size(117, 16);
            this.label_for_key_word.TabIndex = 6;
            this.label_for_key_word.Text = "Ключевые слова";
            // 
            // label_for_author
            // 
            this.label_for_author.AutoSize = true;
            this.label_for_author.Location = new System.Drawing.Point(9, 57);
            this.label_for_author.Name = "label_for_author";
            this.label_for_author.Size = new System.Drawing.Size(51, 16);
            this.label_for_author.TabIndex = 5;
            this.label_for_author.Text = "Автор:";
            // 
            // textBoxDataIzd
            // 
            this.textBoxDataIzd.Location = new System.Drawing.Point(176, 110);
            this.textBoxDataIzd.Name = "textBoxDataIzd";
            this.textBoxDataIzd.Size = new System.Drawing.Size(197, 22);
            this.textBoxDataIzd.TabIndex = 4;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(176, 82);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(197, 22);
            this.textBoxName.TabIndex = 3;
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(176, 54);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(197, 22);
            this.textBoxAuthor.TabIndex = 2;
            // 
            // textBoxKeyWord
            // 
            this.textBoxKeyWord.Location = new System.Drawing.Point(176, 26);
            this.textBoxKeyWord.Name = "textBoxKeyWord";
            this.textBoxKeyWord.Size = new System.Drawing.Size(197, 22);
            this.textBoxKeyWord.TabIndex = 1;
            // 
            // lib_BookTableAdapter
            // 
            this.lib_BookTableAdapter.ClearBeforeFill = true;
            // 
            // Form_for_FindLiter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 443);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_for_FindLiter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск литературы";
            this.Load += new System.EventHandler(this.Form_for_FindLiter_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libBookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academia_for_UMK)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDataIzd;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.TextBox textBoxKeyWord;
        private System.Windows.Forms.Label label_for_dataizd;
        private System.Windows.Forms.Label label_for_name;
        private System.Windows.Forms.Label label_for_key_word;
        private System.Windows.Forms.Label label_for_author;
        private System.Windows.Forms.Button Ok_button;
        private Academia_for_UMK academia_for_UMK;
        private System.Windows.Forms.BindingSource libBookBindingSource;
        private Academia_for_UMKTableAdapters.Lib_BookTableAdapter lib_BookTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grifColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mestoIzdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameIzdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataIzdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countBookColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codTypeBookColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeColumn;
    }
}