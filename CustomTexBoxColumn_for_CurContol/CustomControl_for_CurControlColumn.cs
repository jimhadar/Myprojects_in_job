using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CustomTexBoxColumn_for_CurContol
{
    public partial class CustomTexBoxEditingControl_for_CurControl : UserControl, IDataGridViewEditingControl
    {
        private bool valueChanged = false;
        DataGridView dataGridView;
        int rowIndex;
        public override string Text {
            get {
                return this.textBox.Text;
            }
            set {
                this.textBox.Text = value;
            }
        }
        
        #region Свойства для доступа к comboBox_FormCurControl
        /// <summary>
        /// DataSource для comboBox_FormCurControl
        /// </summary>
        public object DataSource {
            get {
                return this.comboBox_FormCurControl.DataSource;
            }
            set {
                if(value != null){
                    this.comboBox_FormCurControl.DataSource = value;
                }
            }
        }
        /// <summary>
        /// ValueMember для comboBox_FormCurControl
        /// </summary>
        public string ValueMember {
            get {
                return this.comboBox_FormCurControl.ValueMember;
            }
            set {
                if(value != null){
                    this.comboBox_FormCurControl.ValueMember = value;
                }
            }
        }
        /// <summary>
        /// DisplayMember  для comboBox_FormCurControl
        /// </summary>
        public string DisplayMember {
            get {
                return this.comboBox_FormCurControl.DisplayMember;
            }
            set {
                if(value != null && value != string.Empty){
                    this.comboBox_FormCurControl.DisplayMember = value;
                }
            }
        }
        #endregion

        public CustomTexBoxEditingControl_for_CurControl()            
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            this.textBox.Width = this.comboBox_FormCurControl.Width;
            this.comboBox_FormCurControl.SelectedIndex = -1;
        }

        #region Реализация интерфейса IDataGridViewEditingControl
        /// <summary>
        /// Получает форматированное значение ячейки, которая изменяется редактором.
        /// </summary>
        public object EditingControlFormattedValue {
            get{
                return this.textBox.Text;
            }
            set{
                this.Text = value.ToString();
            }
        }
        /// <summary>
        /// Извлекает форматированное значение ячейки.
        /// </summary>
        /// <param name="context">Побитовое сочетание значений DataGridViewDataErrorContexts, которое задает контекст, в котором необходимы данные.</param>
        /// <returns>Объект Object, представляющий форматированную версию содержимого ячейки.</returns>
        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) {
            return EditingControlFormattedValue;
        }
        /// <summary>
        /// Изменяет пользовательский интерфейс элемента управления в соответствии с заданным стилем ячейки.
        /// </summary>
        /// <param name="dataGridViewCellStyle">Стиль DataGridViewCellStyle, используемый в качестве модели для пользовательского интерфейса.</param>    
        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle) {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }
        /// <summary>
        /// Получает или задает индекс родительской строки принимающей ячейки.
        /// </summary>
        public int EditingControlRowIndex {
            get {
                return rowIndex;
            }
            set {
                rowIndex = value;
            }
        }
        /// <summary>
        /// Определяет, является ли заданная клавиша обычной клавишей ввода, 
        /// которая должна обрабатываться элементом управления "Поле ввода", или специальной клавишей, 
        /// которая должна обрабатываться объектом DataGridView.
        /// </summary>
        /// <param name="key">Объект Keys, представляющий нажатую клавишу.</param>
        /// <param name="dataGridViewWantsInputKey">Значение true, если объект DataGridView должен обрабатывать объект Keys в параметре keyData, и значение false в противном случае.</param>
        /// <returns>Значение true, если заданная клавиша является обычной клавишей ввода, 
        /// которая должна обрабатываться элементом управления "Поле ввода", 
        /// и значение false в противном случае.</returns>
        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey) {                
            return true;
        }
        /// <summary>
        /// Подготавливает выбранную ячейку к редактированию.
        /// </summary>
        /// <param name="selectAll">Значение true, чтобы выбрать все содержимое ячейки, 
        /// и значение false в противном случае.</param>
        public void PrepareEditingControlForEdit(bool selectAll) {
            this.comboBox_FormCurControl.Focus();
        }
        /// <summary>
        /// Получает или задает значение, указывающее, нужно ли перемещать содержимое ячейки в случае изменения ее значения.
        /// Значение true, если необходимо перемещать содержимое, в противном случае — значение false.
        /// </summary>
        public bool RepositionEditingControlOnValueChange {
            get {
                return false;
            }
        }
        /// <summary>
        /// Возвращает или задает DataGridView, содержащий ячейку.
        /// Объект DataGridView, содержащий редактируемую ячейку DataGridViewCell, 
        /// или значение null, если отсутствует связанный объект DataGridView.
        /// </summary>
        public DataGridView EditingControlDataGridView {
            get {
                return dataGridView;
            }
            set {
                dataGridView = value;
            }
        }
        /// <summary>
        /// Получает или задает значение, указывающее, отличается ли значение элемента управления редактирования от значения принимающей ячейки.
        /// Возвращает Значение true, если значение элемента управления отличается от значения ячейки, и значение false в противном случае.
        /// </summary>
        public bool EditingControlValueChanged {
            get {
                return valueChanged;
            }
            set {
                valueChanged = value;
            }
        }
        /// <summary>
        /// Получает курсор, используемый, когда указатель мыши находится над элементом DataGridView.EditingPanel, 
        /// но вне элемента управления редактирования.
        /// Значение свойства:
        /// Объект Cursor, который представляет указатель мыши, используемый для панели редактирования. 
        /// </summary>
        public Cursor EditingPanelCursor {
            get {
                return base.Cursor;
            }
        }  
        #endregion

        private void button_add_FormCurControl_Click(object sender, EventArgs e) {
            if(this.comboBox_FormCurControl.SelectedValue != null && comboBox_FormCurControl.SelectedIndex != -1){
                string temp = string.Empty;
                //если источником данных для combobox является таблица со списком оценочных средств
                if(this.comboBox_FormCurControl.ValueMember == "IdSredstv"){
                    temp = this.comboBox_FormCurControl.Text.Substring(0, this.comboBox_FormCurControl.Text.IndexOf(' '));
                }
                //если источником данных для combobox является таблица со списком тем дисциплины
                else if (this.comboBox_FormCurControl.ValueMember == "NumberTheme") {
                    temp = (this.comboBox_FormCurControl.SelectedValue != null) ? this.comboBox_FormCurControl.SelectedValue.ToString() : String.Empty;
                }
                if(this.textBox.Text != string.Empty){
                    this.textBox.Text += ", " + temp;
                }
                else {
                    this.textBox.Text = temp;
                }                   
                this.comboBox_FormCurControl.SelectedIndex = -1;
            }
        }

        protected override void OnLeave(EventArgs e) {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnLeave(e);
        }

        private void CustomTexBoxEditingControl_for_CurControl_Resize(object sender, EventArgs e) {
            this.textBox.Width = this.Width - 20;
            this.comboBox_FormCurControl.Width = this.Width - 20;
            this.button_add_FormCurControl.Left = this.textBox.Left;
        }
    }

    public class CustomTexBoxColumn_for_CurContol : DataGridViewColumn  {
        /// <summary>
        /// DataSource для comboBox_FormCurControl в CustomTexBoxEditingControl_for_CurControl
        /// </summary>
        public object DataSource {
            get {
                return   ((CustomTextBoxCell_for_CurControl)this.CellTemplate).DataSource;
            }
            set {
                ((CustomTextBoxCell_for_CurControl)this.CellTemplate).DataSource = value;
            }
        }
        /// <summary>
        /// ValueMember для comboBox_FormCurControl в CustomTexBoxEditingControl_for_CurControl 
        /// </summary>
        public string ValueMember {
            get {
                return ((CustomTextBoxCell_for_CurControl)this.DataGridView.CurrentCell != null ? ((CustomTextBoxCell_for_CurControl)this.DataGridView.CurrentCell).ValueMember : string.Empty);
            }
            set {
                if ((CustomTextBoxCell_for_CurControl)this.DataGridView.CurrentCell != null) {
                    ((CustomTextBoxCell_for_CurControl)this.DataGridView.CurrentCell).ValueMember = value;
                }
            }
        }
        /// <summary>
        /// DisplayMember  для comboBox_FormCurControl в CustomTexBoxEditingControl_for_CurControl
        /// </summary>
        public string DisplayMember {
            get {
                return ((CustomTextBoxCell_for_CurControl)this.DataGridView.CurrentCell != null ? ((CustomTextBoxCell_for_CurControl)this.DataGridView.CurrentCell).DisplayMember : string.Empty);
            }
            set {
                if((CustomTextBoxCell_for_CurControl)this.DataGridView.CurrentCell != null){
                    ((CustomTextBoxCell_for_CurControl)this.DataGridView.CurrentCell).DisplayMember = value;
                }                
            }
        }
        public CustomTexBoxColumn_for_CurContol()
            : base(new CustomTextBoxCell_for_CurControl()) {
            
        }
        public override DataGridViewCell CellTemplate {
            get {
                return base.CellTemplate;
            }
            set {
                base.CellTemplate = value;
            }
        }
    }

    public class CustomTextBoxCell_for_CurControl : DataGridViewTextBoxCell{
        /// <summary>
        /// DataSource для comboBox_FormCurControl в CustomTexBoxEditingControl_for_CurControl
        /// </summary>
        public object DataSource;
        /// <summary>
        /// ValueMember для comboBox_FormCurControl в CustomTexBoxEditingControl_for_CurControl 
        /// </summary>
        public string ValueMember;
        /// <summary>
        /// DisplayMember  для comboBox_FormCurControl в CustomTexBoxEditingControl_for_CurControl
        /// </summary>
        public string DisplayMember;
        public CustomTextBoxCell_for_CurControl()
        :base(){
            this.Style.Format = "s";                    
        }
        public override void InitializeEditingControl(  int rowIndex, 
                                                        object initialFormattedValue, 
                                                        DataGridViewCellStyle dataGridViewCellStyle) 
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            CustomTexBoxEditingControl_for_CurControl cell = this.DataGridView.EditingControl as CustomTexBoxEditingControl_for_CurControl;
            cell.Text = (this.Value != null) ? this.Value.ToString() : string.Empty;
            cell.DataSource = this.DataSource;
            cell.ValueMember = this.ValueMember;
            cell.DisplayMember = this.DisplayMember;
            /*if(this.Value == null){
                this.cell.Text = string.Empty;
            }
            else {
                this.cell.Text = this.Value.ToString();
            }*/
            this.DataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DataGridView.CurrentRow.MinimumHeight = 80;
        }
        public override Type EditType {
            get {
                return typeof(CustomTexBoxEditingControl_for_CurControl);
            }
        }
        public override Type ValueType {
            get {
                return typeof(string);
            }
        }   
        public override object DefaultNewRowValue {
            get {
                return String.Empty; ;
            }
        } 
        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context) {
            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
        public override Type FormattedValueType {
            get {
                return typeof(string);
            }
        }       }    
}    