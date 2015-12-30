namespace CustomTexBoxColumn_for_CurContol
{
    partial class CustomTexBoxEditingControl_for_CurControl
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.TextBox();
            this.comboBox_FormCurControl = new System.Windows.Forms.ComboBox();
            this.button_add_FormCurControl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(3, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(196, 20);
            this.textBox.TabIndex = 0;
            // 
            // comboBox_FormCurControl
            // 
            this.comboBox_FormCurControl.FormattingEnabled = true;
            this.comboBox_FormCurControl.Location = new System.Drawing.Point(3, 29);
            this.comboBox_FormCurControl.Name = "comboBox_FormCurControl";
            this.comboBox_FormCurControl.Size = new System.Drawing.Size(196, 21);
            this.comboBox_FormCurControl.TabIndex = 1;
            // 
            // button_add_FormCurControl
            // 
            this.button_add_FormCurControl.Location = new System.Drawing.Point(0, 55);
            this.button_add_FormCurControl.Name = "button_add_FormCurControl";
            this.button_add_FormCurControl.Size = new System.Drawing.Size(202, 23);
            this.button_add_FormCurControl.TabIndex = 2;
            this.button_add_FormCurControl.Text = "Добавить";
            this.button_add_FormCurControl.UseVisualStyleBackColor = true;
            this.button_add_FormCurControl.Click += new System.EventHandler(this.button_add_FormCurControl_Click);
            // 
            // CustomTexBoxEditingControl_for_CurControl
            // 
            this.AutoSize = true;
            this.Controls.Add(this.button_add_FormCurControl);
            this.Controls.Add(this.comboBox_FormCurControl);
            this.Controls.Add(this.textBox);
            this.Name = "CustomTexBoxEditingControl_for_CurControl";
            this.Size = new System.Drawing.Size(205, 82);
            this.Resize += new System.EventHandler(this.CustomTexBoxEditingControl_for_CurControl_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button button_add_FormCurControl;
        public System.Windows.Forms.ComboBox comboBox_FormCurControl;
    }
}
