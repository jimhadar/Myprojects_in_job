using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace UMK_RPD {
    internal partial class Form_for_UMK_and_RPD {
        /// <summary>
        /// проверка на то, что есть в программу внесены данные, которые можно внести в БД (прежде всего титульный лист)
        /// </summary>
        /// <returns>True, если все ок, False, если каких либо данных не хватает и сохранение в БД невозможно</returns>
        private bool NotIsEmptyData(){
            return (this.dataGridViewNagruzkaPrep.RowCount > 0) ? true : false; 
        }
        /// <summary>
        /// Загрузка информации из программы в базу данных
        /// </summary>
        private void LoadDataToDataBaseFromProgram() {
            GetValues();
            if (NotIsEmptyData()) {
                //this.uMK_and_RPDTableAdapter.Update(academia_for_UMK.UMK_and_RPD);
                MemoryStream MemStream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(MemStream, System.Text.Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                string Data = string.Empty;
                switch (this.Text) {
                    case "УМК":
                        writer.Flush();
                        Save_UMK_to_xml(ref writer);
                        writer.Flush();
                        using (StreamReader reader = new StreamReader(MemStream)) {
                            char[] c = new char[1];
                            MemStream.Seek(0, SeekOrigin.Begin);
                            Data = reader.ReadToEnd();
                        }
                        
                        CodSpeciality = (string)this.grupTableAdapter.GetCodSpeciality((short)this.Cod_Plan);
                        switch (this.modeProgram.openMode) {
                            case OpenMode.OpenUmk:
                                        this.uMK_and_RPDTableAdapter.Update(true,
                                                                            "УМК-" + this.FIO_prepod.Trim() + "-" + this.dataGridViewNagruzkaPrep.CurrentRow.Cells["nameSubColumn"].Value.ToString().Trim() + ".xml",
                                                                            (byte)this.CodFac,
                                                                            (byte)this.CodKaf,
                                                                            (int)this.Cod_prep,
                                                                            (short)this.CodSub,
                                                                            (short)this.numericUpDown.Value,
                                                                            Data.Substring(0, 19) + Data.Substring(36, Data.Length - 36),
                                                                            System.DateTime.Now.Date,
                                                                            (int)this.CodPrepWhoEdit,
                                                                            (int)this.Cod_Plan,
                                                                            this.CodSpeciality,
                                                                            (byte)this.Cod_Form_study,
                                                                            (byte)this.CodTypeEdu,
                                                                            this.modeProgram.IdRpd_or_UMK);
                                    break;
                            case OpenMode.NewUmk:
                                            this.uMK_and_RPDTableAdapter.Insert(true,
                                                                                "УМК-" + this.FIO_prepod.Trim() + "-" + this.dataGridViewNagruzkaPrep.CurrentRow.Cells["nameSubColumn"].Value.ToString().Trim() + ".xml",
                                                                                (byte)CodFac,
                                                                                (byte)CodKaf,
                                                                                (int)Cod_prep,
                                                                                (short)this.CodSub,
                                                                                (short)this.numericUpDown.Value,
                                                                                Data.Substring(0, 19) + Data.Substring(36, Data.Length - 36),  //сохраняем xml документ без указания кодировки)
                                                                                System.DateTime.Now.Date,
                                                                                (int)this.CodPrepWhoEdit,
                                                                                (int)this.Cod_Plan,
                                                                                (byte)this.Cod_Form_study,
                                                                                (byte)this.CodTypeEdu,
                                                                                this.CodSpeciality);
                                            modeProgram.IdRpd_or_UMK = Convert.ToInt32(this.uMK_and_RPDTableAdapter.GetMaxID());
                                    break;
                            }
                        break;
                    case "РПД":
                        writer.Flush();
                        Save_RPD_to_XML(ref writer);
                        writer.Flush();
                        using (StreamReader reader = new StreamReader(MemStream)) {
                            char[] c = new char[1];
                            MemStream.Seek(0, SeekOrigin.Begin);
                            Data = reader.ReadToEnd();
                        }
                        CodSpeciality = this.grupTableAdapter.GetCodSpeciality((short)Cod_Plan).ToString();
                        switch (this.modeProgram.openMode) {
                            case OpenMode.OpenRpd:
                                        this.uMK_and_RPDTableAdapter.Update(false,
                                                                            "РПД-" + this.FIO_prepod.Trim() + "-" + this.dataGridViewNagruzkaPrep.CurrentRow.Cells["nameSubColumn"].Value.ToString().Trim() + ".xml",
                                                                            (byte)this.CodFac,
                                                                            (byte)this.CodKaf,
                                                                            (int)this.Cod_prep,
                                                                            (short)this.CodSub,
                                                                            (short)this.numericUpDown.Value,
                                                                            Data.Substring(0, 19) + Data.Substring(36, Data.Length - 36),
                                                                            System.DateTime.Now.Date,
                                                                            (int)this.CodPrepWhoEdit,
                                                                            (int)this.Cod_Plan,
                                                                            this.CodSpeciality,
                                                                            (byte)this.Cod_Form_study,
                                                                            (byte)this.CodTypeEdu,
                                                                            this.modeProgram.IdRpd_or_UMK);
                                    break;
                            case OpenMode.NewRpd:
                                        this.uMK_and_RPDTableAdapter.Insert(false,
                                                                            "РПД-" + this.FIO_prepod.Trim() + "-" + this.dataGridViewNagruzkaPrep.CurrentRow.Cells["nameSubColumn"].Value.ToString().Trim() + ".xml",
                                                                            (byte)CodFac,
                                                                            (byte)CodKaf,
                                                                            (int)Cod_prep,
                                                                            (short)this.CodSub,
                                                                            (short)this.numericUpDown.Value,
                                                                            Data.Substring(0, 19) + Data.Substring(36, Data.Length - 36),  //сохраняем xml документ без указания кодировки)
                                                                            System.DateTime.Now.Date,
                                                                            (int)this.CodPrepWhoEdit,
                                                                            (int)this.Cod_Plan, 
                                                                            (byte)this.Cod_Form_study,
                                                                            (byte)this.CodTypeEdu,
                                                                            this.CodSpeciality);
                                        modeProgram.IdRpd_or_UMK = Convert.ToInt32(this.uMK_and_RPDTableAdapter.GetMaxID());
                                    break;
                        }
                        break;     
                }
                if(modeProgram.openMode == OpenMode.NewUmk || modeProgram.openMode == OpenMode.NewRpd){
                    modeProgram.openMode = (modeProgram.openMode == OpenMode.NewRpd) ? OpenMode.OpenRpd : OpenMode.OpenUmk;
                }
            }
            else {
                MessageBox.Show("Недостаточно информации для сохранения " +
                                this.Text + " в базе данных");
                return;
            }
        }                
        /// <summary>
        /// Загрузка информации из базы данных в программу
        /// </summary>
        private void LoadDataToProgramFromDataBase() {
            using (MemoryStream MemStream = new MemoryStream()) {
                XmlTextWriter xmlWriter = new XmlTextWriter(MemStream, System.Text.Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;                         
                StreamWriter writer = new StreamWriter(MemStream, System.Text.Encoding.UTF8);
                string Data = this.uMK_and_RPDTableAdapter.GetContents(modeProgram.IdRpd_or_UMK).ToString();
                writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Data);
                writer.Flush();
                StreamReader reader = new StreamReader(MemStream, System.Text.Encoding.UTF8);
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                XmlTextReader XmlReader = new XmlTextReader(reader);
                this.OpenXml = true;
                switch (modeProgram.openMode) {
                    case OpenMode.OpenRpd:
                        Load_RPD_To_Program_from_XML(ref XmlReader);
                        break;
                    case OpenMode.OpenUmk:
                        Load_UMK_To_Program_from_XML(ref XmlReader);
                        break;
                }
                this.label_for_shifr.Text = this.GetShifrDiscip();

                this.label_for_PrepWhoEdit_inBase.Text = this.prepodTableAdapter.Get_FIO((int)this.CodPrepWhoEdit).ToString().Trim();
                if(dataGridViewRazdelLesson.RowCount > 0){
                    dataGridViewRazdelLesson.CurrentCell = this.dataGridViewRazdelLesson.Rows[0].Cells["ColumnTheme"];
                }
            }              
        }
    }
}