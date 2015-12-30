namespace UMK_RPD
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRPD = new System.Windows.Forms.TextBox();
            this.textBoxUMK = new System.Windows.Forms.TextBox();
            this.btn_for_RPD = new System.Windows.Forms.Button();
            this.btn_for_UMK = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Путь к шаблону РПД:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Путь к шаблону УМК:";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(461, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Выберите место, где необходимо сохранять готовый документ РПД:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(13, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(460, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Выберите место, где необходимо сохранять готовый документ УМК:";
            // 
            // textBoxRPD
            // 
            this.textBoxRPD.Location = new System.Drawing.Point(15, 29);
            this.textBoxRPD.Name = "textBoxRPD";
            this.textBoxRPD.Size = new System.Drawing.Size(470, 20);
            this.textBoxRPD.TabIndex = 2;
            // 
            // textBoxUMK
            // 
            this.textBoxUMK.Location = new System.Drawing.Point(16, 99);
            this.textBoxUMK.Name = "textBoxUMK";
            this.textBoxUMK.Size = new System.Drawing.Size(469, 20);
            this.textBoxUMK.TabIndex = 3;
            // 
            // btn_for_RPD
            // 
            this.btn_for_RPD.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btn_for_RPD.Location = new System.Drawing.Point(481, 29);
            this.btn_for_RPD.Name = "btn_for_RPD";
            this.btn_for_RPD.Size = new System.Drawing.Size(75, 23);
            this.btn_for_RPD.TabIndex = 4;
            this.btn_for_RPD.Text = "Изменить";
            this.btn_for_RPD.UseVisualStyleBackColor = true;
            this.btn_for_RPD.Click += new System.EventHandler(this.btn_for_RPD_Click);
            // 
            // btn_for_UMK
            // 
            this.btn_for_UMK.Location = new System.Drawing.Point(481, 99);
            this.btn_for_UMK.Name = "btn_for_UMK";
            this.btn_for_UMK.Size = new System.Drawing.Size(75, 23);
            this.btn_for_UMK.TabIndex = 5;
            this.btn_for_UMK.Text = "Изменить";
            this.btn_for_UMK.UseVisualStyleBackColor = true;
            this.btn_for_UMK.Click += new System.EventHandler(this.btn_for_UMK_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(502, 150);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(54, 24);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "Ok";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 202);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_for_UMK);
            this.Controls.Add(this.btn_for_RPD);
            this.Controls.Add(this.textBoxUMK);
            this.Controls.Add(this.textBoxRPD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxRPD;
        private System.Windows.Forms.TextBox textBoxUMK;
        private System.Windows.Forms.Button btn_for_RPD;
        private System.Windows.Forms.Button btn_for_UMK;
        private System.Windows.Forms.Button btn_OK;
    }
}