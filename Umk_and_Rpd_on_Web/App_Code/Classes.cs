using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using Umk_and_Rpd_on_Web;
//using System.IO.Packaging;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;     

namespace Umk_and_Rpd_on_Web {
    /// <summary>
    /// для определения, куда сохранять файл сфомированную УМК / РПД: в БД или на ПК клиента в формате *.docx
    /// </summary>
    enum SaveToDoc_or_DataBase{
        SaveToDoc = 0,
        SaveToDB = 1
    };

    /// <summary>
    /// перечисление для указания того, какой документ необходимо сохранить в формате *.docx: УМК, РПД, Аннотацию к РПД
    /// </summary>
    enum HowDoc_Save {
        SaveToXml = 0,
        SaveUmk = 1,
        SaveRPD = 2,
        SaveAnnotationToRPD = 3,
        SaveToDataBase = 4
    }
    internal class Classes {
        #region метод для аутентификации преподавателя
        /// <summary>
        /// метод для аутентификации преподавателя (проверки подлинности)
        /// </summary>
        /// <param name="UserName">Логин</param>
        /// <param name="_pass">Пароль</param>
        /// <returns>true, если логин и пароль введны верно</returns>
        internal static bool Validate_password(String UserName, String _pass) {
            using (AcademiaDataSetTableAdapters.PeoplenPassTableAdapter PeoplenPassAdapter = new AcademiaDataSetTableAdapters.PeoplenPassTableAdapter()) {
                PeoplenPassAdapter.Fill(new AcademiaDataSet.PeoplenPassDataTable());
                object nik = PeoplenPassAdapter.GetNik(UserName);
                //если такого логина нет в БД
                if (nik == null) {
                    return false;
                }
                else {
                    object _salt = PeoplenPassAdapter.GetSalt(UserName);
                    //Если у пользователя нет пароля
                    if (_salt == null) {
                        return false;
                    }
                    // иначе проверяем соответствие пароля HASH-у из таблицы базы данных
                    else {
                        byte[] salt = Convert.FromBase64String(_salt.ToString().Trim());
                        Encoding utf8 = Encoding.UTF8;
                        byte[] hash;
                        // создаем рабочий массив достаточного размера, чтобы вместить
                        byte[] data = new byte[salt.Length
                                                + utf8.GetMaxByteCount(_pass.Length)];   // копируем синхропосылку в рабочий массив
                        Array.Copy(salt, 0, data, 0, salt.Length);

                        // копируем пароль в рабочий массив, преобразуя его в UTF-8
                        int byteCount = utf8.GetBytes(_pass, 0, _pass.Length,
                            data, salt.Length);
                        // хэшируем данные массива
                        using (System.Security.Cryptography.HashAlgorithm alg = new System.Security.Cryptography.SHA256Managed())
                            hash = alg.ComputeHash(data, 0, salt.Length + byteCount);
                        string hash_from_table = PeoplenPassAdapter.GetHash(UserName).ToString().Trim();
                        string result_hash = Convert.ToBase64String(hash);
                        if (result_hash == hash_from_table) {
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                }
            }
        }            
        #endregion
    }

    [Serializable()]
    internal partial class Data_for_program {
        #region Основные переменные, используемые в программе
        /// <summary>
        /// Id umk в базе данных
        /// </summary>
        internal int? Id_umk = null;
        /// <summary>
        /// Id rpd в базе данных
        /// </summary>
        internal int? Id_rpd = null;
        /// <summary>
        /// Тип обучения: для стандартов (ФГОС 3, ФГОС 3+ и т.п.)
        /// </summary>
        internal byte CodTypeEdu;
        /// <summary>
        /// Код преподавателя по нагрузке
        /// </summary>
        internal int? CodPrep = null;
        /// <summary>
        /// Код преподавателя, который сделал РПД/УМК
        /// </summary>
        internal int? CodPrepWhoEdit = null;
        /// <summary>
        /// Код факультета для преподавателя
        /// </summary>
        internal byte? CodFacPrep = null;
        /// <summary>
        /// Форма обучения
        /// </summary>
        internal byte? CodFormStudy = null;
        /// <summary>
        /// Код факультета для группы
        /// </summary>
        internal byte? CodFac;
        /// <summary>
        /// Код кафедры плана
        /// </summary>
        internal byte? CodKaf = null;
        /// <summary>
        /// Код группы
        /// </summary>
        internal short? CodGroup = null;
        /// <summary>
        /// Код предмета
        /// </summary>
        internal short? CodSub = null;
        /// <summary>
        /// Код учебного плана
        /// </summary>
        internal int? CodPlan = null;
        /// <summary>
        /// Количество часов семинарских занятий
        /// </summary> 
        internal int HourLec = 0;
        /// <summary>
        /// Количество часов лабораторных работ
        /// </summary>
        internal int HourLab = 0;
        /// <summary>
        /// Количество часов для самостоятельных работ
        /// </summary>
        internal int HourSam = 0;
        /// <summary>
        /// Кафедра для преподавателя
        /// </summary>
        internal byte? CodKafPrep = null;
        /// <summary>
        /// Учебный год
        /// </summary>
        internal int? UchYear = null;
        /// <summary>
        /// УМК или РПД
        /// если = true; то - УМК,
        /// если false, то РПД
        /// </summary>
        internal bool Umk_or_Rpd;
        /// <summary>
        /// Код специальности
        /// </summary>
        internal string CodSpeciality;
        /// <summary>
        /// для списка ключевых компетенций
        /// </summary>
        internal List<KeyCompetTable> table_for_key_compet = null;
        internal AcademiaDataSet.OcenSredstvDataTable OcenSredstvTable = null;
        #endregion

        #region Дополнительные переменные. необходимы только при заполнении файла *.xml
        /// <summary>
        /// ФИО преподавателя: если в плане CodPrep = 0, то FIO_prepod берется на основе CodPrepWhoEdit,
        /// иначе, если CodPrep != 0, то FIO_prepod берется на основе Cod_prep
        /// </summary>
        string FIO_prepod;
        /// <summary>
        /// название кафедры для преподавателя
        /// </summary>
        string NameKafPrep;
        /// <summary>
        /// название кафедры для плана
        /// </summary>
        string NameKafPlan;
        /// <summary>
        /// название дисциплины
        /// </summary>                                        
        string Name_discipline;
        /// <summary>
        /// шифр дисциплины
        /// </summary>
        string shifr_discipline;
        /// <summary>
        /// название специальности
        /// </summary>
        string Name_speciality;
        /// <summary>
        /// профиль подготовки
        /// </summary>
        string specialization;
        /// <summary>
        /// название формы обучения
        /// </summary>
        string NameFormStudy;
        /// <summary>
        /// Код преподавателя - зав. кафедрой
        /// </summary>
        int? CodZavKaf;
        /// <summary>
        /// Зав. кафедрой для кафедры, которая составляет УМК/РПД
        /// </summary>
        string ZavKaf;
        /// <summary>
        /// Код преподавателя - заместителя директора по учебной работе
        /// </summary>
        int CodZamDir;
        /// <summary>
        /// заместитель директора по учебной работе
        /// </summary>
        string ZamDir_po_uchJob;
        /// <summary>
        /// Составитель УМК/РПД
        /// </summary>
        string sostavitel;
        /// <summary>
        /// код декана факультета группы
        /// </summary>
        int? CodDekan;
        /// <summary>
        /// Декан факультета группы
        /// </summary>
        string Dekan;
        /// <summary>
        /// Количество зачетных единиц
        /// </summary>
        int ZET;
        /// <summary>
        /// цикл дисциплин в структуре ООП
        /// </summary>
        string NameGrSubject;
        /// <summary>
        /// код Заведующий кафедрой, которая стоит по плану
        /// </summary>
        int? CodZavKaf_for_Plan;
        /// <summary>
        /// зав. кафедрой, которая соит по плану
        /// </summary>
        string ZavKaf_For_Plan;
        /// <summary>
        /// Таблица со списком ключевых компетенций выбранной дисциплины
        /// </summary>
        AcademiaDataSet.CompetetionDataTable CompetetionTable;
        /// <summary>
        /// Строк, содержащая перечень курсов, на которы изучается дисциплина
        /// </summary>
        string Course_Obuch;
        /// <summary>
        /// строка, содержащая перечень семестров, в которых изучается дисциплина
        /// </summary>
        string Semestr_Obuch;
        /// <summary>
        /// строка, содержащая семестр, в котором предполагается курсовая работа
        /// </summary>
        string Semestr_Kurs_Job;
        /// <summary>
        /// Строка, содержащая семестр, в котором предполагается зачет
        /// </summary>
        string Semestr_Zachet;
        /// <summary>
        /// Строка, содержащая семестр, в котором предполагается экзамен
        /// </summary>
        string Semestr_Ekzamen;     
        /// <summary>
        /// Код специальности для файла *.docx, он отличается от четырехзначного CodSpeciality
        /// </summary>
        string CodSpecialty_for_XML;
        #endregion

        #region переменные для хранения информации о том, какими навыками должен обладать студент
        /// <summary>
        /// студент должен знать
        /// </summary>
        internal string Student_Doljen_Znat;
        /// <summary>
        /// студент должен уметь
        /// </summary>
        internal string Student_Doljen_Umet;
        /// <summary>
        /// студент должен владеть 
        /// </summary>
        internal string Student_doljen_Vladet;
        #endregion

        #region   для хранения пути к файлу *.docx, сохраненному на сервере
        /// <summary>
        /// где хранится файл и РПД
        /// если == String.Empty, тогда файл не создан
        /// </summary>
        string FilePathToRPD;
        /// <summary>
        /// где хранится файл с УМК
        /// если == String.Empty, то файл не создан
        /// </summary>
        string FilePathToUMK;          
        /// <summary>
        /// где хранится файл с аннотацией к РПД,
        /// если = String.Empty, то файл не создан
        /// </summary>
        string FilePathToAnnotationRPD;
        #endregion

        #region для хранения в памяти шаблона *.xml РПД/УМК
        /// <summary>
        /// данные из *.xml для РПД
        /// </summary>
        string Data_with_RPD;
        /// <summary>
        /// данные из *.xml для УМК
        /// </summary>
        string Data_with_UMK;
        #endregion
        /// <summary>
        /// место дисциплины в структуре ООП
        /// </summary>
        internal string PlaceOOP;
        /// <summary>
        /// цели изучения дисциплины
        /// </summary>  
        internal string GoalsDiscip;
        /// <summary>
        /// для хранения таблицы "Содержание разделов дисциплины"
        /// </summary>
        internal SoderjRazdDiscip_DataTable SoderjRazd_DataTable = null;
        /// <summary>
        /// для таблицы "Текущий контроль успеваемости"
        /// таблица != null только если выбрана для заполнения УМК
        /// </summary>
        internal CurrentControlTable CurControlTable = null;
        /// <summary>
        /// для таблицы "Рекомендуемая литература"
        /// </summary>
        internal LiteratureDataTable LiteratureTable = null;
        /// <summary>
        /// содержит прочие поля для заполнения УМК
        /// </summary>
        internal OthersFieldsForUMK othersFieldsForUMK = null;
        /// <summary>
        /// содержит прочие поля для заполнения РПД
        /// </summary>
        internal OthersFieldsForRPD othersFieldsForRPD = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodPrep">Код преподавателя</param>
        /// <param name="Umk_or_Rpd">УМК/РПД</param>
        /// <param name="CodFac">Код факультета для преподаваетля</param>
        /// <param name="CodKafPrep">Код кафедры для преподавателя</param>
        /// <param name="UchYear">Учебный год</param>
        internal Data_for_program(int CodPrep, bool Umk_or_Rpd, byte CodFac, byte CodKafPrep, int UchYear) {
            this.CodPrep = CodPrep;
            this.CodFacPrep = CodFac;
            this.Umk_or_Rpd = Umk_or_Rpd;
            this.CodKafPrep = CodKafPrep;
            this.UchYear = UchYear;
            table_for_key_compet = new List<KeyCompetTable>();
            SoderjRazd_DataTable = new SoderjRazdDiscip_DataTable();
            CurControlTable = new CurrentControlTable();
            string s = String.Empty;
            this.othersFieldsForUMK = new OthersFieldsForUMK(s, s, s);
            this.othersFieldsForRPD = new OthersFieldsForRPD(s, s, s, s, s, s, s, s, s, s, s);
            this.LiteratureTable = new LiteratureDataTable();
            this.PlaceOOP = string.Empty;
            this.GoalsDiscip = string.Empty;
            this.Student_Doljen_Umet = string.Empty;
            this.Student_doljen_Vladet = string.Empty;
            this.Student_Doljen_Znat = string.Empty;
        }
        /// <summary>
        /// Сохранение РПД / УМК в базу данных, в зависимости от параметра Save_RPD_or_UMK
        /// </summary>
        /// <param name="Save_RPD_or_UMK">если = true, то в БД сохраняется РПД,
        /// иначе если = false, то в БД сохранятеся УМК</param>
        /// <param name="SaveDoc_or_DB"></param>
        internal string SaveDataToDataBase_and_toDocx(bool Save_RPD_or_UMK, HowDoc_Save SaveDoc_or_DB, string PhisycalPathToApp, string AppPath) {
            this.Umk_or_Rpd = Save_RPD_or_UMK;
            //если нет еще данных в формате *.xml
            if (SaveDoc_or_DB == HowDoc_Save.SaveToDataBase) {
                //if(!Umk_or_Rpd && Data_with_RPD == null){
                MemoryStream memoryStream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(memoryStream, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                Save_RPD_to_XML(ref writer);
                writer.Flush();
                using (StreamReader reader = new StreamReader(memoryStream)) {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    this.Data_with_RPD = reader.ReadToEnd();
                }
                //}
                //else if(Umk_or_Rpd && Data_with_UMK == null){
                //MemoryStream 
                memoryStream = new MemoryStream();
                //XmlTextWriter 
                writer = new XmlTextWriter(memoryStream, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                Save_UMK_to_xml(ref writer);
                writer.Flush();
                using (StreamReader reader = new StreamReader(memoryStream)) {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    this.Data_with_UMK = reader.ReadToEnd();
                }
                //}
                using(AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter UMK_rpd_adapter = new AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter()){
                    //UMK_rpd_adapter.Fill(new AcademiaDataSet.UMK_and_RPDDataTable());
                    //Сохраняем РПД и УМК в базу данных
                    switch(this.Id_rpd){
                        //в базе данных еще нет такой РПД
                        //тогда вставляем новую РПД в базу данных
                        case null:
                            UMK_rpd_adapter.Insert(false,
                                                    "РПД-" + this.FIO_prepod.Trim() + "-" + this.Name_discipline.Trim() + "-" + CodSpeciality.ToString() + "-" + Name_speciality.ToString(),
                                                    (byte)this.CodFacPrep,
                                                    (byte)this.CodKafPrep,
                                                    (byte)this.CodPrep,
                                                    (short)this.CodSub,
                                                    (short)this.UchYear,
                                                    Data_with_RPD.Substring(0, 19) + Data_with_RPD.Substring(36, Data_with_RPD.Length - 36),
                                                    DateTime.Now,
                                                    this.CodPrepWhoEdit,
                                                    this.CodPlan,
                                                    this.CodFormStudy,
                                                    this.CodTypeEdu,
                                                    this.CodSpeciality, 
                                                    null);
                            this.Id_rpd = UMK_rpd_adapter.GetMaxID();
                            break;
                        //в базе данных уже есть такая РПД с Id = Id_rpd
                        //тогда обновляем данные в базе данных
                        default:
                            UMK_rpd_adapter.Update(false,
                                                    "РПД-" + this.FIO_prepod.Trim() + "-" + this.Name_discipline.Trim() + "-" + CodSpeciality.ToString() + "-" + Name_speciality.ToString(),
                                                    this.CodFacPrep,
                                                    this.CodKafPrep,
                                                    this.CodPrep,
                                                    this.CodSub,
                                                    (short)this.UchYear,
                                                    Data_with_RPD.Substring(0, 19) + Data_with_RPD.Substring(36, Data_with_RPD.Length - 36),
                                                    DateTime.Now,
                                                    this.CodPrepWhoEdit,
                                                    this.CodPlan,
                                                    this.CodSpeciality,
                                                    this.CodFormStudy,
                                                    this.CodTypeEdu, 
                                                    null,
                                                    (int)this.Id_rpd);
                            break;
                    }
                    switch(this.Id_umk){
                        //в базе данных еще нет такой УМК
                        //тогда вставляем новую РПД в базу данных
                        case null:
                            UMK_rpd_adapter.Insert(true,
                                                    "УМК-" + this.FIO_prepod.Trim() + "-" + this.Name_discipline.Trim() + "-" + CodSpeciality.ToString() + "-" + Name_speciality.ToString(),
                                                    (byte)this.CodFacPrep,
                                                    (byte)this.CodKafPrep,
                                                    (byte)this.CodPrep,
                                                    (short)this.CodSub,
                                                    (short)this.UchYear,
                                                    Data_with_UMK.Substring(0, 19) + Data_with_UMK.Substring(36, Data_with_UMK.Length - 36),
                                                    DateTime.Now,
                                                    this.CodPrepWhoEdit,
                                                    this.CodPlan,
                                                    this.CodFormStudy,
                                                    this.CodTypeEdu,
                                                    this.CodSpeciality,
                                                    null);
                            this.Id_umk = UMK_rpd_adapter.GetMaxID();
                            break;
                        //в базе данных уже есть такая УМК с Id = Id_umk
                        //тогда обновляем данные в базе данных
                        default:
                            UMK_rpd_adapter.Update(true,
                                                    "УМК-" + this.FIO_prepod.Trim() + "-" + this.Name_discipline.Trim() + "-" + CodSpeciality.ToString() + "-" + Name_speciality.ToString(),
                                                    this.CodFacPrep,
                                                    this.CodKafPrep,
                                                    this.CodPrep,
                                                    this.CodSub,
                                                    (short)this.UchYear,
                                                    Data_with_UMK.Substring(0, 19) + Data_with_UMK.Substring(36, Data_with_UMK.Length - 36),
                                                    DateTime.Now,
                                                    this.CodPrepWhoEdit,
                                                    this.CodPlan,
                                                    this.CodSpeciality,
                                                    this.CodFormStudy,
                                                    this.CodTypeEdu,
                                                    null,
                                                    (int)this.Id_umk);
                            break;
                    }
                }
                return string.Empty;
            }
            else {
                using (StringReader reader = new StringReader((SaveDoc_or_DB == HowDoc_Save.SaveRPD || SaveDoc_or_DB == HowDoc_Save.SaveAnnotationToRPD ? this.Data_with_RPD : this.Data_with_UMK))) {
                    return SaveToDocx(reader, SaveDoc_or_DB, PhisycalPathToApp, AppPath);
                }
            }
        }

        #region Вспомогательные методы для ввода в файл *.xml корректной информации
        /// <summary>
        /// Получение составителя УМК в формате: И.О. Фамилия
        /// </summary>
        /// <returns>И.О. Фамилия</returns>
        private string about_prepod(string FIOPrep) {
            //Получаем инициалы + фамилию препода
            string I_O_Fam = FIOPrep.Substring(0, FIOPrep.IndexOf(' '));
            FIOPrep = FIOPrep.Remove(0, FIOPrep.IndexOf(' ') + 1);
            string I = FIOPrep.Substring(0, 1);//инициалы: имя
            FIOPrep = FIOPrep.Remove(0, FIOPrep.IndexOf(" ") + 1);
            string O = FIOPrep.Substring(0, 1);//инициалы: отчество
            I_O_Fam = I + "." + O + ". " + I_O_Fam;
            return I_O_Fam;
        }
        /// <summary>
        /// возвращает название факультета в родительном падеже
        /// </summary>
        /// <param name="fac_name">навазние факультета</param>
        /// <returns></returns>
        private string Name_fac_in_rod_padej(byte Cod_fac) {
            string fac_name;
            using (AcademiaDataSetTableAdapters.FacultyTableAdapter FacultyAdapter = new AcademiaDataSetTableAdapters.FacultyTableAdapter()) {
                FacultyAdapter.Fill(new AcademiaDataSet.FacultyDataTable());
                fac_name = FacultyAdapter.GetNameFaculty(Cod_fac).ToString();
            }
            fac_name = fac_name.Substring(0, fac_name.IndexOf("факультет") - 1);
            return (fac_name.Substring(0, fac_name.Length - 2) + "ого").ToLower();
        }
        /// <summary>
        /// Получение (Фамилия И.О.) в формате (И.О. Фамилия) 
        /// </summary>
        /// <param name="FIO">Фамилия И.О.</param>
        /// <returns></returns>
        private string I_O_Fam_for_ZavKaf_and_Dekan(string FIO) {
            string temp = FIO.Substring(0, FIO.Length - 5);
            temp = FIO.Substring(FIO.IndexOf(' ') + 1, 4) + ' ' + temp;
            return temp;
        }
        /// <summary>
        /// ПОлная информация о преподе: степень + должность + И.О. Фамилия 
        /// </summary>
        /// <param name="CODPE">код преподаваетля</param>
        /// <param name="I_O_Fam">И.О. Фамилия преподавателя</param>
        /// <returns>строка формата: степень + должность + И.О. Фамилия </returns>
        private string full_inf_about_prepod(int CODPE, string I_O_Fam) {
            AcademiaDataSetTableAdapters.Doljnost_prepodTableAdapter DoljnostAdapter = new AcademiaDataSetTableAdapters.Doljnost_prepodTableAdapter();
            DoljnostAdapter.Fill(new AcademiaDataSet.Doljnost_prepodDataTable(), (int)this.CodPrep);

            AcademiaDataSetTableAdapters.PEOPLENTableAdapter PeolpeLenAdapter = new AcademiaDataSetTableAdapters.PEOPLENTableAdapter();
            PeolpeLenAdapter.Fill(new AcademiaDataSet.PEOPLENDataTable());

            AcademiaDataSetTableAdapters.DEGREETableAdapter DegreeAdapter = new AcademiaDataSetTableAdapters.DEGREETableAdapter();
            DegreeAdapter.Fill(new AcademiaDataSet.DEGREEDataTable());

            string Doljnost = DoljnostAdapter.GetDoljnost(CODPE);
            int? Cod_Degree = PeolpeLenAdapter.GetCodDegree(CODPE);
            if (Cod_Degree != null && Cod_Degree != 0) {
                string Stepen;
                Stepen = DegreeAdapter.GetNameDegree((int)Cod_Degree);
                if (Doljnost != null) {
                    return Stepen.Trim().ToLower() + ", " + Doljnost.Trim().ToLower() + ' ' + I_O_Fam;
                }
                else if (Stepen != null) {
                    return Stepen.Trim().ToLower() + ", " + I_O_Fam;
                }
                else {
                    return I_O_Fam;
                }
            }
            else {
                return Doljnost != null ? Doljnost.Trim().ToLower() + ' ' + I_O_Fam : I_O_Fam;
            }
        }
        /// <summary>
        /// Формирует запись с информацией о курсахобучения по выбранной дисциплине
        /// </summary>
        /// <returns>Запись с информацией о курсах, на которых изучалась дисциплина</returns>
        private string Get_Course_obuch(AcademiaDataSet.StudyTermDataTable StudyTermTable) {
            string temp = string.Empty;
            List<int> temp_mas = new List<int>();
            int i = 0;
            foreach (AcademiaDataSet.StudyTermRow Row in StudyTermTable.Rows) {
                int temp_int = Convert.ToInt32(Row["Course"].ToString());
                if (temp_mas.IndexOf(temp_int) < 0) {
                    temp_mas.Add(temp_int);
                }
            }
            foreach (int temp_int in temp_mas) {
                temp += temp_int.ToString() + ", ";
            }
            return temp.Substring(0, temp.Length - 2);
        }
        /// <summary>
        /// Возвращает семестр, в котором должна быть по дисциплине курсовая работа, если есть
        /// иначе возвращает "-"
        /// </summary>
        /// <returns></returns>
        private string Get_Sem_kurs_job(AcademiaDataSet.StudyExamsDataTable StudyExamsTable) {
            string temp = string.Empty;
            foreach (AcademiaDataSet.StudyExamsRow Row in StudyExamsTable.Rows) {
                if (Row["CodExType"].ToString().Trim() == "4") {
                    temp += Row["Course"].ToString().Trim() + "." + Row["NumTerm"].ToString().Trim() + ", ";
                }
            }
            if (temp != string.Empty) {
                return temp.Substring(0, temp.Length - 2);
            }
            else {
                return "-";
            }
        }
        /// <summary>
        /// Возвращает семестр, в котором по дисциплине должен быть зачет, если есть, иначе возвращает "-"
        /// </summary>
        /// <returns></returns>
        private string Get_Sem_zachet(AcademiaDataSet.StudyExamsDataTable StudyExamsTable) {
            string temp = string.Empty;
            foreach (AcademiaDataSet.StudyExamsRow Row in StudyExamsTable.Rows) {
                if (Row["CodExType"].ToString().Trim() == "2" || Row["CodExType"].ToString().Trim() == "6") {
                    temp += Row["Course"].ToString().Trim() + "." + Row["NumTerm"].ToString().Trim() + ", ";
                }
            }
            if (temp != string.Empty) {
                return temp.Substring(0, temp.Length - 2);
            }
            else {
                return "-";
            }
        }
        /// <summary>
        /// Возвращает семестр, в котором по дисциплине должен быть экзамен, если есть, иначе возвращает "-"
        /// </summary>
        /// <returns></returns>
        private string Get_Sem_Ekzamen(AcademiaDataSet.StudyExamsDataTable StudyExamsTable) {
            string temp = string.Empty;
            foreach (AcademiaDataSet.StudyExamsRow Row in StudyExamsTable.Rows) {
                if (Row["CodExType"].ToString().Trim() == "1") {
                    temp += Row["Course"].ToString().Trim() + "." + Row["NumTerm"].ToString().Trim() + ", ";
                }
            }
            if (temp != string.Empty) {
                return temp.Substring(0, temp.Length - 2);
            }
            else {
                return "-";
            }
        }
        /// <summary>
        /// Возвращает список семестров, в которых ведется дисциплина
        /// </summary>
        /// <returns></returns>
        private string Get_Sem(AcademiaDataSet.StudyTermDataTable StudyTermTable) {
            string temp = String.Empty;
            foreach (AcademiaDataSet.StudyTermRow Row in StudyTermTable.Rows) {
                temp += Row["Course"].ToString().Trim() + "." + Row["NumTerm"].ToString().Trim() + ", ";
            }
            return temp.Substring(0, temp.Length - 2);
        }
        /// <summary>
        /// Сумма часов лекций/практик/самостоятельной работы, в зависимости от параметра  Value_of_columnType 
        /// для раздела или темы, в зависимости от параметра Razdel_or_Theme
        /// </summary>
        /// <param name="CurrentRow">Строка, с которой начинается описание раздела (или темы)</param>
        /// <param name="Value_of_columnType">Равен "Лекция", "Семинар" или "Сам. работа"</param>
        /// <param name="Razdel_or_Theme">равен "Раздел" или "Тема"</param>
        /// <returns></returns>
        private double Sum_hour_for_razdel_or_theme(int CurrentRow, string Value_of_columnType, string Razdel_or_Theme) {
            double temp = 0;
            CurrentRow++;
            while (CurrentRow < this.SoderjRazd_DataTable.RowCount && this.SoderjRazd_DataTable[CurrentRow, "VidColumn"].ToString() != Razdel_or_Theme) {
                if (this.SoderjRazd_DataTable[CurrentRow, "VidColumn"].ToString() == Value_of_columnType) {
                    temp += Convert.ToDouble(this.SoderjRazd_DataTable[CurrentRow, "VolumeColumn"]);
                }
                CurrentRow++;
            }
            return temp;
        }
        private string GetShifrDiscip(AcademiaDataSetTableAdapters.SubjectGrsTableAdapter SubjectAdapter,
                                    AcademiaDataSetTableAdapters.StudyContentsTableAdapter StudyContentsAdapter,
                                    AcademiaDataSetTableAdapters.Studycomponents_plus_studycontentsTableAdapter Studycomponents_plus_studycontentsAdapter) {
            //шифр дисциплины
            if (StudyContentsAdapter.Get_CodGrSubject((int)this.CodPlan, (short)CodSub) != null) {
                byte cod_uch_circle = Convert.ToByte(StudyContentsAdapter.Get_CodGrSubject((int)CodPlan, (short)CodSub).ToString());//CodGrSubject
                NameGrSubject = SubjectAdapter.GetNameGRSub(cod_uch_circle).Trim().ToLower();
                string abbr_uch_circle = SubjectAdapter.Get_SubjectGRS(cod_uch_circle).ToString();//аббревиатура учебного цикла SubjectGRS
                int? CodComp = Convert.ToInt32(StudyContentsAdapter.Get_codComp((int)CodPlan, (short)CodSub).ToString());//номер по порядку в учебном цикле или плане AbrrComp
                int? Num_discip_in_plan = Convert.ToInt32(StudyContentsAdapter.Get_Num_In_Gr((int)CodPlan, (short)CodSub));
                object type_subject = Studycomponents_plus_studycontentsAdapter.Get_AbbrComp((int)CodComp);//тип предметам (например базовый) это CodComp
                return abbr_uch_circle + "." + (type_subject != null ? type_subject.ToString() : string.Empty) + "." + Num_discip_in_plan.ToString();
            }
            else {
                return String.Empty;
            }
        }
        /// <summary>
        /// Обновление значений всех основных переменных, необходимых для сохранения данных программы в формате *.XML
        /// </summary>
        internal void GetValues() {
            using (AcademiaDataSet academiaDataSet = new AcademiaDataSet()) {

                AcademiaDataSetTableAdapters.StudyPlansTableAdapter StudyPlansAdapter = new AcademiaDataSetTableAdapters.StudyPlansTableAdapter();
                StudyPlansAdapter.Fill_on_CodPlan(academiaDataSet.StudyPlans, (int)this.CodPlan);

                AcademiaDataSetTableAdapters.PEOPLENTableAdapter PeoplenLenAdapter = new AcademiaDataSetTableAdapters.PEOPLENTableAdapter();
                //PeoplenLenAdapter.Fill(academiaDataSet.PEOPLEN);

                AcademiaDataSetTableAdapters.SpecialityTableAdapter SpecialityAdapter = new AcademiaDataSetTableAdapters.SpecialityTableAdapter();
                //SpecialityAdapter.Fill(academiaDataSet.Speciality, (byte)this.CodTypeEdu);

                AcademiaDataSetTableAdapters.FacultyTableAdapter FacultyAdapter = new AcademiaDataSetTableAdapters.FacultyTableAdapter();
                //FacultyAdapter.Fill(academiaDataSet.Faculty);

                AcademiaDataSetTableAdapters.KafsTableAdapter KafsAdapter = new AcademiaDataSetTableAdapters.KafsTableAdapter();
                //KafsAdapter.Fill_without_param(academiaDataSet.Kafs);

                AcademiaDataSetTableAdapters.StudyTermTableAdapter StudyTermAdapter = new AcademiaDataSetTableAdapters.StudyTermTableAdapter();
                StudyTermAdapter.Fill(academiaDataSet.StudyTerm, (int)this.CodPlan, (short)this.CodSub);

                AcademiaDataSetTableAdapters.SubsTableAdapter SubsAdapter = new AcademiaDataSetTableAdapters.SubsTableAdapter();
                //SubsAdapter.Fill(academiaDataSet.Subs);

                AcademiaDataSetTableAdapters.SubjectGrsTableAdapter SubjectAdapter = new AcademiaDataSetTableAdapters.SubjectGrsTableAdapter();
                try {
                    SubjectAdapter.Fill(academiaDataSet.SubjectGrs);
                }
                catch {
                    SubjectAdapter.Fill(academiaDataSet.SubjectGrs);
                }

                AcademiaDataSetTableAdapters.StudyContentsTableAdapter StudyContentsAdapter = new AcademiaDataSetTableAdapters.StudyContentsTableAdapter();
                //StudyContentsAdapter.Fill(academiaDataSet.StudyContents);

                AcademiaDataSetTableAdapters.Studycomponents_plus_studycontentsTableAdapter Studycomponents_plus_studycontentsAdapter = new AcademiaDataSetTableAdapters.Studycomponents_plus_studycontentsTableAdapter();
                //Studycomponents_plus_studycontentsAdapter.Fill(academiaDataSet.Studycomponents_plus_studycontents);

                AcademiaDataSetTableAdapters.PrepodTableAdapter prepodAdapter = new AcademiaDataSetTableAdapters.PrepodTableAdapter();
                //prepodAdapter.Fill(academiaDataSet.Prepod);

                AcademiaDataSetTableAdapters.FormStudyTableAdapter FormStudyAdapter = new AcademiaDataSetTableAdapters.FormStudyTableAdapter();
                //FormStudyAdapter.Fill(academiaDataSet.FormStudy);

                AcademiaDataSetTableAdapters.CompetetionTableAdapter CompetetionAdapter = new AcademiaDataSetTableAdapters.CompetetionTableAdapter();
                //CompetetionAdapter.Fill(academiaDataSet.Competetion, this.CodSpeciality, (short)CodSub, (int)CodPlan);
                this.CompetetionTable = CompetetionAdapter.GetData(this.CodSpeciality, (short)CodSub, (int)CodPlan);

                AcademiaDataSetTableAdapters.StudyExamsTableAdapter StudyExamsAdapter = new AcademiaDataSetTableAdapters.StudyExamsTableAdapter();
                StudyExamsAdapter.Fill(academiaDataSet.StudyExams, (int)this.CodPlan, (short)this.CodSub);

                AcademiaDataSetTableAdapters.OcenSredstvTableAdapter OcenSredstvAdapter = new AcademiaDataSetTableAdapters.OcenSredstvTableAdapter();
                this.OcenSredstvTable = OcenSredstvAdapter.GetData();// new AcademiaDataSet.OcenSredstvDataTable();
                //OcenSredstvAdapter.Fill(this.OcenSredstvTable);

                AcademiaDataSetTableAdapters.ZavPodrazdnTableAdapter zavPodrazdn = new AcademiaDataSetTableAdapters.ZavPodrazdnTableAdapter();
                //this.CodFormStudy = Convert.ToByte(grupAdapter.GetCodFormStudy((short)this.CodGroup));

                ZamDir_po_uchJob = PeoplenLenAdapter.SelectZamDir_po_uch_job();
                NameKafPrep = KafsAdapter.GetNameKaf((byte)this.CodKafPrep);
                CodFac = Convert.ToByte(academiaDataSet.StudyPlans[0]["CodFaculty"]);
                this.CodKaf = Convert.ToByte(academiaDataSet.StudyPlans[0]["CodKaf"]);
                NameKafPlan = KafsAdapter.GetNameKaf((byte)this.CodKaf);
                Name_discipline = SubsAdapter.GetNameSub((short)this.CodSub).ToString();
                //Шифр дисциплины
                shifr_discipline = this.GetShifrDiscip(SubjectAdapter, StudyContentsAdapter, Studycomponents_plus_studycontentsAdapter);

                //CodSpeciality = SpecialityAdapter.GetCodSpecGroupOKSO((short)CodGroup).ToString();
                Name_speciality = SpecialityAdapter.GetNameSpecialityOKSO((int)this.CodPlan).ToString();
                //профиль подготовки
                specialization = SpecialityAdapter.GetNameSpecialization((int)this.CodPlan).ToString();
                this.FIO_prepod = prepodAdapter.GetFio((CodPrep != null && CodPrep != 0) ? (int)CodPrep : (int)this.CodPrepWhoEdit).ToString().Trim();
                sostavitel = about_prepod(this.FIO_prepod);
                //Заведующая кафедрой
                ZavKaf = KafsAdapter.GetZavKaf((byte)this.CodKafPrep).ToString();
                //Зав. кафедрой для плана
                ZavKaf_For_Plan = KafsAdapter.GetZavKaf((byte)this.CodKaf);
                this.CodZavKaf_for_Plan = Convert.ToInt32(zavPodrazdn.GetCodPE(NameKafPlan));

                Dekan = FacultyAdapter.GetDean((byte)CodFac).ToString();
                NameFormStudy = FormStudyAdapter.GetNameFormStudy((byte)this.CodFormStudy);
                CodZamDir = Convert.ToInt32(prepodAdapter.GetCodPrepPoFam(ZamDir_po_uchJob.Substring(0, ZamDir_po_uchJob.IndexOf(' '))));
                CodZavKaf = Convert.ToInt32(zavPodrazdn.GetCodPE(NameKafPrep));
                CodDekan = Convert.ToInt32(zavPodrazdn.GetCodPE(FacultyAdapter.GetNameFaculty((byte)CodFac)));
                HourLab = 0; HourLec = 0; HourSam = 0;
                foreach (DataRow Row in academiaDataSet.StudyTerm) {                                  
                    HourLec += Convert.ToInt32(Row["Lec"]);
                    HourSam += Convert.ToInt32(Row["Sam"]);
                    HourLab += Convert.ToInt32(Row["Sem"]);
                }
                ZET = 0;
                foreach (DataRow Row in academiaDataSet.StudyTerm.Rows) {
                    ZET = Convert.ToInt32(Row["ECTScredits"].ToString());
                }

                this.Course_Obuch = this.Get_Course_obuch(academiaDataSet.StudyTerm);

                this.Semestr_Kurs_Job = this.Get_Sem_kurs_job(academiaDataSet.StudyExams);

                this.Semestr_Obuch = this.Get_Sem(academiaDataSet.StudyTerm);

                this.Semestr_Zachet = this.Get_Sem_zachet(academiaDataSet.StudyExams);

                this.Semestr_Ekzamen = this.Get_Sem_Ekzamen(academiaDataSet.StudyExams);

                this.CodSpecialty_for_XML = (SpecialityAdapter.GetCodSpecGroupOKSO((int)this.CodPlan)) != null ? SpecialityAdapter.GetCodSpecGroupOKSO((int)this.CodPlan).ToString() : String.Empty;
            }

        }
        #endregion

        #region Вспомогательные методы для сохранения данных в *.xml
        /// <summary>
        /// Сохранение УМК в формате XML
        /// </summary>
        private void Save_UMK_to_xml(ref XmlTextWriter writer) {
            writer.WriteStartDocument();
            writer.WriteStartElement("umk");
            zap_XML_Title_List(ref writer);
            //Для раздела "Пояснительная записка"
            writer.WriteStartElement("UMK_razdel_1");
            writer.WriteStartElement("Data");
            zap_XML_GoalsDisc_PlaceOOP_Compet(ref writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            //Формирования раздела 2 "Структура дисциплины"
            writer.WriteStartElement("Razdel_2");
            //Для раздела 2.1. "Трудоемкость дисциплины и ее общая структура"
            writer.WriteStartElement("Struct_discip");
            //Здесь содержится информации о курсе обучения, 
            //семестрах, сумме часов лекций, практик и самостятельных работ
            writer.WriteStartElement("Main_inform");
            zap_XML_Struct_discip(ref writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("Soderjanie_razd_discip");
            writer.WriteAttributeString("FormaOb", this.NameFormStudy);
            zap_XML_soderj_discip(ref writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            //Формирование раздела 3.2. "Список используемой литературы"
            writer.WriteStartElement("Recommand_literature");
            zap_XML_Recommand_literature(ref writer);
            writer.WriteEndElement();
            //Формирование раздела 4. "Организация текущего контроля успеваемости и промежуточной аттестации по итогам освоения дисциплины "
            writer.WriteStartElement("CurrentControl");
            zap_XML_CurrentControl(ref writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            if (!(writer.BaseStream is MemoryStream)) {
                writer.Close();
            }
        }
        /// <summary>
        /// Сохранение РПД в формате XML
        /// </summary>
        /// <param name="writer"></param>
        private void Save_RPD_to_XML(ref XmlTextWriter writer) {
            writer.WriteStartDocument();
            writer.WriteStartElement("RPD");
            //Для титульного листа
            zap_XML_Title_List(ref writer);
            writer.WriteStartElement("RPD_1_2_3");
            writer.WriteStartElement("Data");
            zap_XML_GoalsDisc_PlaceOOP_Compet(ref writer);
            writer.WriteEndElement();
            //Для заполнения таблицы "Структура дисциплины" титульного листа
            writer.WriteStartElement("Struct_Discip");
            //Здесь содержится информации о курсе обучения, 
            //семестрах, сумме часов лекций, практик и самостятельных работ
            zap_XML_Struct_discip(ref writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("RPD_4_5");
            //Формирования разделов "4. Структура и содержание дисциплины"
            writer.WriteStartElement("Soderjanie_razd_discip");
            zap_XML_soderj_discip(ref writer);
            //Заполнение перечня оценочных средств для формы текущего контроля успеваемости
            writer.WriteStartElement("SpisokOcenSredstv");
            foreach (DataRow Row in this.OcenSredstvTable.Rows) {
                writer.WriteStartElement("OcenSredstv");
                writer.WriteAttributeString("AbbrSredstv", Row["AbbrSredstv"].ToString().Trim());
                writer.WriteAttributeString("NameSredstv", Row["NameSredstv"].ToString().Trim());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            //"4.4. Вид и форма промежуточной аттестации"
            writer.WriteStartElement("Type_and_Form_promej_control");
            this.Zap_XMl_with_abzac_from_List(this.othersFieldsForRPD.Type_and_FormCertification, ref writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            //"5. Используемые образовательные технологии"
            writer.WriteStartElement("Obraz_technology");
            this.Zap_XMl_with_abzac_from_List(this.othersFieldsForRPD.Used_Ecucate_Technology, ref writer);
            //"Доля занятий с использованием активных и интерактивных методов"
            writer.WriteStartElement("Part_zanyatii");
            writer.WriteAttributeString("Value", this.othersFieldsForRPD.PartInteractiveMethods.Trim());
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            //"Оценочные средства для текущего контроля успеваемости, 
            //промежуточной аттестации по итогам освоения дисциплины и 
            //учебно-методическое обеспечение самостоятельной работы студентов"
            writer.WriteStartElement("RPD_6");
            //"6.1. Текущий контроль"
            writer.WriteStartElement("CurrentControl");
            this.zap_XML_CurrentControl_From_CurControlTable(ref writer);
            writer.WriteEndElement();
            //"6.2. Образцы тестовых и контрольных заданий текущего контроля"
            writer.WriteStartElement("Example_Zad_CurControl");
            this.Zap_XMl_with_abzac_from_List(othersFieldsForRPD.Example_Test_CurControl, ref writer);
            writer.WriteEndElement();
            //"6.3. Примерная тематика рефератов, эссе, докладов "
            writer.WriteStartElement("Theme_Referats");
            this.Zap_XMl_with_abzac_from_List(othersFieldsForRPD.Themes_Of_Esse_Referats, ref writer);
            writer.WriteEndElement();
            //"6.4. Примерные темы курсовых работ, критерии оценивания"
            writer.WriteStartElement("Theme_KursJob");
            this.Zap_XMl_with_abzac_from_List(this.othersFieldsForRPD.Themes_Of_CourseJob, ref writer);
            writer.WriteEndElement();
            //"6.5. Методические указания по организации самостоятельной работы"
            writer.WriteStartElement("MethodUkaz_SamJob");
            Zap_XMl_with_abzac_from_List(this.othersFieldsForRPD.Organization_Of_IndependentWork, ref writer);
            writer.WriteEndElement();
            //"6.6. Промежуточный контроль"
            writer.WriteStartElement("Promej_Control");
            //первый раздел без названия
            writer.WriteStartElement("About_promej_Control");
            this.Zap_XMl_with_abzac_from_List(this.othersFieldsForRPD.InterMediate_Control, ref writer);
            writer.WriteEndElement();
            //образцы тестов, заданий
            writer.WriteStartElement("Example_Zad");
            this.Zap_XMl_with_abzac_from_List(this.othersFieldsForRPD.Example_Test, ref writer);
            writer.WriteEndElement();
            //перечень вопросов к экзамену (зачету)
            writer.WriteStartElement("Vopros_k_Ekz");
            this.Zap_XMl_with_abzac_from_List(this.othersFieldsForRPD.Question_For_Exam, ref writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            //"7. Учебно-методическое и информационное обеспечение дисциплины"
            writer.WriteStartElement("Recommand_literature");
            zap_XML_Recommand_literature(ref writer);
            writer.WriteEndElement();
            //"8. Материально-техническое обеспечение дисциплины"
            writer.WriteStartElement("Technical_Obespech");
            this.Zap_XMl_with_abzac_from_List(this.othersFieldsForRPD.Logistics_Discipline, ref writer);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            if (!(writer.BaseStream is MemoryStream)) {
                writer.Close();
            }
        }
        /// <summary>
        /// Формирование списка, в котором текст из richTextBox разбивается на абзацы,
        /// в каждый элемент списка представляет собой отдельный абзац, затем  занесение этого списка в XML-документ (writer)
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <returns></returns>
        private void zap_XMl_with_abzac_from_str(string data_from_textbox, ref XmlTextWriter writer) {
            List<string> format_result = new List<string>();
            string temp = data_from_textbox.Trim();
            int number_abzac;
            while ((number_abzac = temp.IndexOf('\n')) >= 0) {
                format_result.Add(temp.Substring(0, number_abzac));
                temp = temp.Remove(0, number_abzac + 1);
            }
            if (temp != String.Empty) {
                format_result.Add(temp.Substring(0, temp.Length));
            }
            if (format_result != null) {
                foreach (string s in format_result) {
                    writer.WriteStartElement("Abzac");
                    writer.WriteAttributeString("Value", s);
                    writer.WriteEndElement();
                }
            }
            else {
                writer.WriteStartElement("Abzac");
                writer.WriteAttributeString("Value", String.Empty);
                writer.WriteEndElement();
            }
        }
        /// <summary>
        /// занесение списка, содержащего абзацы из единого текста,
        /// в XML-документ (writer) 
        /// </summary>
        /// <param name="strings"></param>
        /// <param name="writer"></param>
        private void Zap_XMl_with_abzac_from_List(List<string> strings, ref XmlTextWriter writer) {
            foreach (string str in strings) {
                writer.WriteStartElement("Abzac");
                writer.WriteAttributeString("Value", str.Trim());
                writer.WriteEndElement();
            }
        }
        /// <summary>
        /// Заполнение в XML-документе раздела, содержащего информацию для титульного листа
        /// </summary>
        private void zap_XML_Title_List(ref XmlTextWriter writer) {
            //this.GetValues();
            //Информация для считывания информации из XML-файла и дальнейшего открытия этого файла в программе
            writer.WriteStartElement("Title_inf_for_program");
            //Код факультета преподавателя
            writer.WriteAttributeString("comboBoxFacPrep", this.CodFacPrep.ToString());
            //код кафедры преподавателя
            writer.WriteAttributeString("CodKafPrep", this.CodKafPrep.ToString());
            //
            writer.WriteAttributeString("CodFac", this.CodFac.ToString().Trim());
            //код преподавателя по нагрузке
            writer.WriteAttributeString("Cod_prep", this.CodPrep.ToString());
            //код преподавателя, который сделал РПД/УМК
            writer.WriteAttributeString("CodPrepWhoEdit", this.CodPrepWhoEdit.ToString());
            //код учебного плана
            writer.WriteAttributeString("CodPlan", this.CodPlan.ToString());
            //код предмета
            writer.WriteAttributeString("CodSub", CodSub.ToString());
            //Год учебного плана
            writer.WriteAttributeString("Year", this.UchYear.ToString());
            writer.WriteAttributeString("CodFormStudy", this.CodFormStudy.ToString().Trim());
            writer.WriteAttributeString("DateSave", DateTime.Now.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Title");
            writer.WriteAttributeString("ZamDir_po_uchJob", full_inf_about_prepod(CodZamDir, about_prepod(ZamDir_po_uchJob)));
            writer.WriteAttributeString("Kaf_for_prep", NameKafPrep.Trim());
            writer.WriteAttributeString("ZavKaf_forKaf_for_prep", full_inf_about_prepod((int)CodZavKaf, I_O_Fam_for_ZavKaf_and_Dekan(ZavKaf)));
            writer.WriteAttributeString("Name_discip", Name_discipline);
            writer.WriteAttributeString("Shift_discip", shifr_discipline);
            writer.WriteAttributeString("Cod_Speciality", this.CodSpecialty_for_XML);
            writer.WriteAttributeString("Name_speciality", Name_speciality);
            writer.WriteAttributeString("Specialization", specialization);
            //если РПД
            if (!this.Umk_or_Rpd) {
                writer.WriteAttributeString("FormaOb", this.NameFormStudy);
            }
            writer.WriteAttributeString("Year", System.DateTime.Now.Year.ToString());
            writer.WriteEndElement();
            //Для второй страницы
            writer.WriteStartElement("Two_str");
            writer.WriteAttributeString("Sostavitel", sostavitel);
            //ели заполняется УМК
            if (this.Umk_or_Rpd) {
                writer.WriteAttributeString("Full_inf_about_Sostavitel", full_inf_about_prepod((this.CodPrep != null && this.CodPrep != 0) ? (int)this.CodPrep : (int)this.CodPrepWhoEdit, sostavitel));
            }
            else {
                string temp = full_inf_about_prepod((this.CodPrep != null && this.CodPrep != 0) ? (int)this.CodPrep : (int)this.CodPrepWhoEdit, sostavitel);
                writer.WriteAttributeString("Full_inf_about_Sostavitel", temp.Substring(0, temp.Length - sostavitel.Length));
            }
            //название кафедры преподавателя
            writer.WriteAttributeString("Kaf_for_prep", NameKafPrep.Trim());
            //название факультета плана (группы)
            writer.WriteAttributeString("NameFac", this.Name_fac_in_rod_padej((byte)CodFac));
            //кафедра плана (группы)
            writer.WriteAttributeString("NameKaf", this.NameKafPlan.ToLower());
            //Зав. кафедрой для плана (группы)
            writer.WriteAttributeString("ZavKafForKafPlan", full_inf_about_prepod((int)this.CodZavKaf_for_Plan, I_O_Fam_for_ZavKaf_and_Dekan(ZavKaf_For_Plan)));
            writer.WriteAttributeString("Dean", full_inf_about_prepod((int)CodDekan, I_O_Fam_for_ZavKaf_and_Dekan(Dekan)));
            writer.WriteEndElement();
        }
        /// <summary>
        /// Заполнение в XML-документе разделов, содержащих информацию о целях изучения дисциплины, ее месте в структуре ООП
        /// и компетенции обучающегося
        /// </summary>
        /// <param name="writer"></param>
        private void zap_XML_GoalsDisc_PlaceOOP_Compet(ref XmlTextWriter writer) {
            //"Цели изучения дисциплины"
            writer.WriteStartElement("GoalsDisciplin");
            zap_XMl_with_abzac_from_str(this.GoalsDiscip, ref  writer);
            writer.WriteEndElement();
            //"Место дисциплины в структуре ООП бакалавриата"
            writer.WriteStartElement("PlaceOOP");
            //печатаем первое предложение раздела "Место дисциплины в структуре ООП"
            writer.WriteStartElement("AboutPlaceOOP");
            writer.WriteAttributeString("Value", "Дисциплина " + shifr_discipline.Trim() + " «" + Name_discipline + "» " + "входит в " + NameGrSubject + ".");
            writer.WriteEndElement();
            zap_XMl_with_abzac_from_str(this.PlaceOOP, ref writer);
            writer.WriteEndElement();
            writer.WriteStartElement("Competetion");
            //Вывод компетенций
            foreach (DataRow Row in this.CompetetionTable.Rows) {
                writer.WriteStartElement("Row");
                writer.WriteAttributeString("CodCompetencii", Row["AbbrComp"].ToString());
                writer.WriteAttributeString("Competencia", Row["AboutComp"].ToString());
                //для различения, является ли просматриваемая компетенция ключевой?
                bool KeyCompet = false;
                foreach (KeyCompetTable TableKeyCompet in this.table_for_key_compet) {
                    if (TableKeyCompet.TableName.ToString() == Row["AbbrComp"].ToString()) {
                        KeyCompet = true;
                        break;
                    }
                }
                writer.WriteAttributeString("KeyCompet", (KeyCompet) ? "True" : "False");
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            //создание списка всех ключевых компетенций
            string s = String.Empty;

            if (this.table_for_key_compet.Count > 0) {
                foreach (KeyCompetTable Table in this.table_for_key_compet) {
                    s += Table.TableName + ", ";
                }
                s = s.Substring(0, s.Length - 2);
            }
            //Вывод списком всех ключевых компетенций
            writer.WriteStartElement("All_key_compet");
            writer.WriteAttributeString("Value", s);
            writer.WriteEndElement();
            //Вывод ключевых компетенций с их описанием
            writer.WriteStartElement("Key_compet");
            foreach (KeyCompetTable Table in this.table_for_key_compet) {
                writer.WriteStartElement("Competetion");
                writer.WriteAttributeString("Name", Table.TableName);
                foreach (DataRow Row in Table) {
                    writer.WriteStartElement("Yr_compet");
                    //Уровень освоения
                    writer.WriteAttributeString("ur_osv", Row[0].ToString());
                    //признак освоения
                    writer.WriteAttributeString("priznak_osv", Row[1].ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            //"Студент должен знать"
            writer.WriteStartElement("Student_must_znat");
            zap_XMl_with_abzac_from_str(this.Student_Doljen_Znat, ref writer);
            writer.WriteEndElement();
            //"Студент должен уметь"
            writer.WriteStartElement("Student_must_umet");
            zap_XMl_with_abzac_from_str(this.Student_Doljen_Umet, ref writer);
            writer.WriteEndElement();
            //"Студент должен владеть"
            writer.WriteStartElement("Student_must_vladet");
            zap_XMl_with_abzac_from_str(this.Student_doljen_Vladet, ref writer);
            writer.WriteEndElement();
        }
        /// <summary>
        /// Общая структура дисциплины
        /// </summary>
        /// <param name="writer"></param>
        private void zap_XML_Struct_discip(ref XmlTextWriter writer) {
            //количество зачетных единиц
            writer.WriteAttributeString("ZET", ZET.ToString());
            //общее количество часов
            writer.WriteAttributeString("All_hours", (36 * ZET).ToString());
            //Форма обучения
            writer.WriteAttributeString("FormaOb", NameFormStudy.Substring(0, NameFormStudy.Length - 2) + "ое обучение");
            //Курс обучения
            writer.WriteAttributeString("Course", this.Course_Obuch);
            //Семесры, в которых должна преподаваться дисциплина
            writer.WriteAttributeString("Semestr", this.Semestr_Obuch);
            //Часы лекций
            writer.WriteAttributeString("HourLec", HourLec.ToString());
            //Часы практик (саминары + лабы)
            writer.WriteAttributeString("HourPraktik", (HourLab).ToString());
            //Часы самостоятельных работ
            writer.WriteAttributeString("HourSam", HourSam.ToString());
            //Семестр курсовой работы, если конечно есть)
            writer.WriteAttributeString("Kursov_job", this.Semestr_Kurs_Job);
            //Семестр зачета, если конечно есть)
            writer.WriteAttributeString("Zachet", this.Semestr_Zachet);
            //Семестр экзамена, если есть
            writer.WriteAttributeString("Ekzamen", this.Semestr_Ekzamen);
        }
        /// <summary>
        /// Заполнение в XML-документе раздела, описывающего содержание разделов дисциплины
        /// только для УМК
        /// </summary>
        private void zap_XML_soderj_discip(ref XmlTextWriter writer) {
            //временные переменные для хранения суммы часов лекций, практик и самостоятельных DataGridViewRazdelLesson
            double sum_hour_Lec, sum_hour_Sem, sum_hour_samjob;
            int number_razdel = 1;
            int number_theme = 1;
            int number_Lec = 1;
            int number_Praktik = 1;
            int number_SamJob = 1;
            string name_theme = string.Empty;
            for (int i = 0; i < this.SoderjRazd_DataTable.RowCount; i++) {
                if (this.SoderjRazd_DataTable[i, "VidColumn"].ToString() == "Раздел") {
                    writer.WriteStartElement("Razdel");
                    //Номер раздела
                    writer.WriteAttributeString("Id", number_razdel.ToString());
                    //Полное название раздела
                    writer.WriteAttributeString("Name", "Раздел " + number_razdel.ToString() + '.');
                    //Семестр, в котором изучается раздел
                    writer.WriteAttributeString("Semestr", (this.SoderjRazd_DataTable[i, "SemestrColumn"] != null) ? this.SoderjRazd_DataTable[i, "SemestrColumn"].ToString() : String.Empty);
                    //Описание раздела 
                    writer.WriteAttributeString("About_razdel", this.SoderjRazd_DataTable[i, "AboutColumn"].ToString());
                    //Объем часов для раздела (лекции)
                    writer.WriteAttributeString("SumLec", this.Sum_hour_for_razdel_or_theme(i, "Лекция", "Раздел").ToString());
                    //Объем часов для раздела (практические занятия)
                    writer.WriteAttributeString("SumPraktik", this.Sum_hour_for_razdel_or_theme(i, "Семинар", "Раздел").ToString());
                    //Объем часов для раздела (самостоятенльая работа)
                    writer.WriteAttributeString("SumSamJob", this.Sum_hour_for_razdel_or_theme(i, "Сам. работа", "Раздел").ToString());
                    //Если заполняется РПД
                    writer.WriteAttributeString("FormCurControl", (this.SoderjRazd_DataTable[i, "FormCurControlColumn"] != null) ? this.SoderjRazd_DataTable[i, "FormCurControlColumn"].ToString() : String.Empty);
                    int j = i + 1;
                    while (j < this.SoderjRazd_DataTable.RowCount && this.SoderjRazd_DataTable[j, "VidColumn"].ToString() != "Раздел") {
                        if (this.SoderjRazd_DataTable[j, "VidColumn"].ToString() == "Тема") {
                            writer.WriteStartElement("Theme");
                            name_theme = this.SoderjRazd_DataTable[j, "AboutColumn"].ToString();
                            //Номер темы
                            writer.WriteAttributeString("Id", number_razdel.ToString() + '.' + number_theme.ToString());
                            //Полное название темы  
                            writer.WriteAttributeString("Name", "Тема " + number_razdel.ToString() + '.' + number_theme.ToString() + '.');
                            //Семестр, в котором изучается тема
                            writer.WriteAttributeString("Semestr", (this.SoderjRazd_DataTable[j, "SemestrColumn"] != null) ? this.SoderjRazd_DataTable[j, "SemestrColumn"].ToString() : String.Empty);
                            //Описание темы (название темы)
                            writer.WriteAttributeString("About_theme", name_theme);
                            //Объем часов для темы (лекции)
                            sum_hour_Lec = this.Sum_hour_for_razdel_or_theme(j, "Лекция", "Тема");
                            writer.WriteAttributeString("SumLec", sum_hour_Lec != 0 ? sum_hour_Lec.ToString() : "-");
                            //Объем часов для темы (практические занятия)
                            sum_hour_Sem = this.Sum_hour_for_razdel_or_theme(j, "Семинар", "Тема");
                            writer.WriteAttributeString("SumPraktik", sum_hour_Sem != 0 ? sum_hour_Sem.ToString() : "-");
                            //Объем часов для темы (самостоятенльая работа)
                            sum_hour_samjob = this.Sum_hour_for_razdel_or_theme(j, "Сам. работа", "Тема");
                            writer.WriteAttributeString("SumSamJob", sum_hour_samjob != 0 ? sum_hour_samjob.ToString() : "-");
                            //Если заполняется РПД
                            writer.WriteAttributeString("FormCurControl", (this.SoderjRazd_DataTable[j, "FormCurControlColumn"] != null) ? this.SoderjRazd_DataTable[j, "FormCurControlColumn"].ToString() : String.Empty);
                            j++;
                            int k = j;
                            //Описание содержания лекционных занятий
                            writer.WriteStartElement("Lecsii");
                            while (k < this.SoderjRazd_DataTable.RowCount && this.SoderjRazd_DataTable[k, "VidColumn"].ToString() != "Тема") {
                                if (this.SoderjRazd_DataTable[k, "VidColumn"].ToString() == "Лекция") {
                                    writer.WriteStartElement("Lec");
                                    writer.WriteAttributeString("Name", "Лекция " + number_Lec.ToString() + '.');
                                    writer.WriteAttributeString("About_Lec", this.SoderjRazd_DataTable[k, "AboutColumn"].ToString());
                                    writer.WriteAttributeString("Hours", (this.SoderjRazd_DataTable[k, "VolumeColumn"] != null ? this.SoderjRazd_DataTable[k, "VolumeColumn"].ToString() : "0"));
                                    writer.WriteAttributeString("Name_Theme", name_theme);
                                    writer.WriteEndElement();
                                    number_Lec++;
                                }
                                k++;
                            }
                            writer.WriteEndElement();
                            k = j;
                            //Описание содержания Практических занятий
                            writer.WriteStartElement("Praktiki");
                            while (k < this.SoderjRazd_DataTable.RowCount && this.SoderjRazd_DataTable[k, "VidColumn"].ToString() != "Тема") {
                                if (this.SoderjRazd_DataTable[k, "VidColumn"].ToString() == "Семинар") {
                                    writer.WriteStartElement("Praktika");
                                    writer.WriteAttributeString("Name", "Занятие " + number_Praktik.ToString() + '.');
                                    writer.WriteAttributeString("About_praktik", (this.SoderjRazd_DataTable[k, "AboutColumn"] != null) ? this.SoderjRazd_DataTable[k, "AboutColumn"].ToString() : String.Empty);
                                    writer.WriteAttributeString("Hours", (this.SoderjRazd_DataTable[k, "VolumeColumn"] != null ? this.SoderjRazd_DataTable[k, "VolumeColumn"].ToString() : "0"));
                                    writer.WriteAttributeString("NumRazdel", "Раздел " + number_razdel.ToString());
                                    writer.WriteAttributeString("NumTheme", "Тема " + number_theme.ToString());
                                    writer.WriteEndElement();
                                    number_Praktik++;
                                }
                                k++;
                            }
                            writer.WriteEndElement();
                            k = j;
                            //Описание содержания самостоятеных работ
                            writer.WriteStartElement("Sam_Job");
                            while (k < this.SoderjRazd_DataTable.RowCount && this.SoderjRazd_DataTable[k, "VidColumn"].ToString() != "Тема") {
                                if (this.SoderjRazd_DataTable[k, "VidColumn"].ToString() == "Сам. работа") {
                                    writer.WriteStartElement("SamJob");
                                    writer.WriteAttributeString("Name", "Занятие " + number_SamJob.ToString() + '.');
                                    writer.WriteAttributeString("About_samJob", (this.SoderjRazd_DataTable[k, "AboutColumn"] != null) ? this.SoderjRazd_DataTable[k, "AboutColumn"].ToString() : String.Empty);
                                    writer.WriteAttributeString("Hours", (this.SoderjRazd_DataTable[k, "VolumeColumn"] != null ? this.SoderjRazd_DataTable[k, "VolumeColumn"].ToString() : "0"));
                                    writer.WriteAttributeString("Name_Theme", name_theme.Trim());
                                    writer.WriteEndElement();
                                    number_SamJob++;
                                }
                                k++;
                            }
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                            number_Lec = 1;
                            number_Praktik = 1;
                            number_SamJob = 1;
                            number_theme++;
                        }
                        j++;
                    }
                    writer.WriteEndElement();
                    number_razdel++;
                    number_theme = 1;
                }
            }
        }
        /// <summary>
        /// Заполнение в XML-документе раздела, содержащего список используемой литературы
        /// </summary>
        /// <param name="writer"></param>
        private void zap_XML_Recommand_literature(ref XmlTextWriter writer) {
            foreach (DataRow Row in this.LiteratureTable) {
                if (Row["AboutLiter"].ToString() != String.Empty) {
                    switch (Row["Type_liter"].ToString()) {
                        case "Основная":
                            writer.WriteStartElement("Main_Liter");
                            writer.WriteAttributeString("Author", Row["AboutLiter"].ToString().Trim());
                            writer.WriteEndElement();
                            break;
                        case "Дополнительная":
                            writer.WriteStartElement("Dop_Liter");
                            writer.WriteAttributeString("Author", Row["AboutLiter"].ToString().Trim());
                            writer.WriteEndElement();
                            break;
                        case "Электронный ресурс":
                            writer.WriteStartElement("Elektr_Resourse");
                            writer.WriteAttributeString("Author", Row["AboutLiter"].ToString().Trim());
                            writer.WriteEndElement();
                            break;
                    }
                }
            }
        }

        private void zap_XML_CurrentControl_From_CurControlTable(ref XmlTextWriter writer) {
            foreach (DataRow Row in this.CurControlTable) {
                if (Row["NumberBallColumn"] != String.Empty) {
                    writer.WriteStartElement("Row");
                    // ячейка "Контрольные мероприятия по дисциплине"
                    writer.WriteAttributeString("Name_meropriyatie", (Row["FormCurControlColumn"] != null ? Row["FormCurControlColumn"].ToString() : String.Empty));
                    //Количество баллов 
                    writer.WriteAttributeString("Ball", Row["NumberBallColumn"] != null ? Row["NumberBallColumn"].ToString() : String.Empty);
                    //Номера тем в формате: Тема + Номер раздела + "." + Номер темы + "."
                    writer.WriteAttributeString("Num_theme", Row["ThemeColumn"] != null ? Row["ThemeColumn"].ToString() : String.Empty);
                    writer.WriteEndElement();
                }
            }
        }
        /// <summary>
        /// Заполнение в XML-документе раздела, содержащего инфомрацию об организации текущего контроля
        /// </summary>
        /// <param name="writer"></param>
        private void zap_XML_CurrentControl(ref XmlTextWriter writer) {
            writer.WriteStartElement("CurControl");
            //Для пункта "4.1. Организация текущего контроля"
            zap_XML_CurrentControl_From_CurControlTable(ref writer);
            writer.WriteEndElement();
            //Форма и правила проведения зачета/экзамена
            writer.WriteStartElement("Form_and_rules_attestat");
            this.Zap_XMl_with_abzac_from_List(this.othersFieldsForUMK.Form_And_Rules_Certification, ref writer);
            writer.WriteEndElement();
            //Вопросы к экзамену/зачету
            writer.WriteStartElement("Voprosy_k_ekz");
            this.Zap_XMl_with_abzac_from_List(this.othersFieldsForUMK.Question_For_Exam, ref writer);
            writer.WriteEndElement();
            //Образцы экзаменационных тестов, заданий
            writer.WriteStartElement("Example_ekz_Unit");
            this.Zap_XMl_with_abzac_from_List(this.othersFieldsForUMK.Example_Exam_Tests, ref writer);
            writer.WriteEndElement();
        }
        #endregion

        #region методы для сохранения в базу данных или в формате *.docx на сервере
        private string SaveToDocx(StringReader Data, HowDoc_Save howDocSave, string PhisycalPathToApp, string AppPath) {
            PhisycalPathToApp += "Content\\AuthorizedUsers\\";
            //string PhisycalPath = System.Web.HttpRequest 
            string save_path =  PhisycalPathToApp +
                                "saving_docx_files\\" + 
                                (howDocSave == HowDoc_Save.SaveAnnotationToRPD ? "Аннотация к РПД" : (howDocSave == HowDoc_Save.SaveRPD ? "РПД" : "УМК")) + "_" +
                                this.shifr_discipline + "_" +
                                this.CodSpeciality + "_" +
                                this.Name_discipline + ".docx";
            AppPath += "\\Content\\AuthorizedUsers\\saving_docx_files\\" +
                                (howDocSave == HowDoc_Save.SaveAnnotationToRPD ? "Аннотация к РПД" : (howDocSave == HowDoc_Save.SaveRPD ? "РПД" : "УМК")) + "_" +
                                this.shifr_discipline + "_" +
                                this.CodSpeciality + "_" +
                                this.Name_discipline + ".docx";
            XmlTextReader xmlDataFile = new XmlTextReader(Data);
            //содержит шаблон для создаваемого документа в формате .docx
            string templateDocument = string.Empty;
            //новый выходной создаваемый файл
            string outputDocument = save_path;
            //вариант для отладки, когда шаблоны считываются не из ресурсов, а с диска
            /*//путь к файлу XSLT, содержащему стили преобразования
            string  xsltReader = string.Empty;
            switch(howDocSave){
                case HowDoc_Save.SaveRPD:
                    xsltReader = UMK_RPD.Properties.Settings.Default.Path_to_Files + "RPD.xslt";
                    templateDocument = UMK_RPD.Properties.Settings.Default.Path_to_Files + "RPD_template.docx";
                    break;
                case HowDoc_Save.SaveUmk:
                    xsltReader = UMK_RPD.Properties.Settings.Default.Path_to_Files + "UMK.xslt";
                    templateDocument = UMK_RPD.Properties.Settings.Default.Path_to_Files + "UMK_template.docx";
                    break;
                case HowDoc_Save.SaveAnnotationToRPD:
                    xsltReader = UMK_RPD.Properties.Settings.Default.Path_to_Files + "AnnotationToRPD_template.xslt";
                    templateDocument = UMK_RPD.Properties.Settings.Default.Path_to_Files + "AnnotationToRPD_template.docx";
                    break;
            } */

            //путь к файлу XSLT, содержащему стили преобразования
            string Data_xslt = string.Empty;
            switch (howDocSave) {
                case HowDoc_Save.SaveRPD:
                    Data_xslt = PhisycalPathToApp + "rpd_shablon\\RPD.xslt";
                    templateDocument = PhisycalPathToApp + "rpd_shablon\\RPD_template.docx";
                    this.FilePathToRPD = save_path;
                    break;
                case HowDoc_Save.SaveUmk:
                    Data_xslt = PhisycalPathToApp + "rpd_shablon\\UMK.xslt";
                    templateDocument = PhisycalPathToApp + "rpd_shablon\\UMK_template.docx";
                    this.FilePathToUMK = save_path;
                    break;
                case HowDoc_Save.SaveAnnotationToRPD:
                    Data_xslt = PhisycalPathToApp + "rpd_shablon\\AnnotationToRPD.xslt";
                    templateDocument = PhisycalPathToApp + "rpd_shablon\\AnnotationToRPD_template.docx";
                    this.FilePathToAnnotationRPD = save_path;
                    break;
            }
            XmlTextReader xsltReader = new XmlTextReader(Data_xslt);

            //Создать писатель для выходного XSL преобразования.
            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlWriter = XmlWriter.Create(stringWriter);
            //Создание объекта преобразования XSL.
            XslCompiledTransform transform = new XslCompiledTransform();
            //загружаем таблиц#у стилей  
            transform.Load(xsltReader);

            //Преобразование данных XML в Open XML 2.0 формата Wordprocessing.
            transform.Transform(xmlDataFile, xmlWriter);
            //Создать XML-документа новым содержанием.
            XmlDocument newWordContent = new XmlDocument();
            newWordContent.LoadXml(stringWriter.ToString());
            try {
                //if (outputDocument.IndexOf(".docx", 0, outputDocument.Length) <= 0) {
                //    outputDocument += ".docx";
                //}
                //Скопируйте исходный документ Word 2007 в выходной файл.
                System.IO.File.Copy(templateDocument, outputDocument, true);

                //Используйте Open XML SDK версии 2.0, чтобы открыть 
                //выходной документ в режиме редактирования.
                using (WordprocessingDocument output =
                  WordprocessingDocument.Open(outputDocument, true)) {
                    //использование элемента тело в новой 
                    //содержимому xmldocument создать новый открытый объект xml тела.
                    Body updatedbodycontent =
                      new Body(newWordContent.DocumentElement.InnerXml);
                    //заменить существующий теле документа с новым содержанием.
                    output.MainDocumentPart.Document.Body = updatedbodycontent;
                    //сохраните обновленный выходной документ.
                    output.MainDocumentPart.Document.Save();
                } 
                //Запуск документа MS Word
                //System.Diagnostics.Process.Start(outputDocument);
            }
            catch (Exception message) {
                //MessageBox.Show(message.Message);
            }
            finally {
                //для готового варианта (не отладка)
                //File.Delete(templateDocument);
            }
            return "/Content/AuthorizedUsers/saving_docx_files/" +
                                (howDocSave == HowDoc_Save.SaveAnnotationToRPD ? "Аннотация к РПД" : (howDocSave == HowDoc_Save.SaveRPD ? "РПД" : "УМК")) + "_" +
                                this.shifr_discipline + "_" +
                                this.CodSpeciality + "_" +
                                this.Name_discipline + ".docx";
            //return AppPath;
        }
        /// <summary>
        /// удаление файлов формата *.docx, созданных во время сеанса пользователя
        /// </summary>
        public void DeleteDocFiles() {
            if (File.Exists(this.FilePathToRPD)) {
                File.Delete(this.FilePathToRPD);
                this.FilePathToRPD = string.Empty;
            }
            if (File.Exists(this.FilePathToUMK)) {
                File.Delete(this.FilePathToUMK);
                this.FilePathToUMK = string.Empty;
            }
            if (File.Exists(this.FilePathToAnnotationRPD)) {
                File.Delete(this.FilePathToAnnotationRPD);
                this.FilePathToAnnotationRPD = string.Empty;
            }
        }
        #endregion
        internal void LoadDataToProgramFromDataBase(/*int? id_umk, int? id_rpd*/) {
            using (AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter umk_rpd_adapter = new AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter()) {
                umk_rpd_adapter.Fill(new AcademiaDataSet.UMK_and_RPDDataTable());
                if (Id_umk != null) {
                    string Data_umk = umk_rpd_adapter.GetContents((int)Id_umk);
                    using (MemoryStream MemStream_umk = new MemoryStream()) {
                        StreamWriter writer_umk = new StreamWriter(MemStream_umk, System.Text.Encoding.UTF8);
                        writer_umk.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Data_umk);
                        writer_umk.Flush();
                        StreamReader reader = new StreamReader(MemStream_umk, System.Text.Encoding.UTF8);
                        reader.BaseStream.Seek(0, SeekOrigin.Begin);
                        XmlTextReader XmlReader = new XmlTextReader(reader);
                        Load_UMK_To_Program_from_XML(ref XmlReader);
                    }
                }
                if (this.Id_rpd != null) {
                    string Data_rpd = umk_rpd_adapter.GetContents((int)Id_rpd);
                    using (MemoryStream MemStream_rpd = new MemoryStream()) {
                        StreamWriter writer_rpd = new StreamWriter(MemStream_rpd, System.Text.Encoding.UTF8);
                        writer_rpd.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Data_rpd);
                        writer_rpd.Flush();
                        StreamReader reader = new StreamReader(MemStream_rpd, System.Text.Encoding.UTF8);
                        reader.BaseStream.Seek(0, SeekOrigin.Begin);
                        XmlTextReader XmlReader = new XmlTextReader(reader);
                        Load_RPD_To_Program_from_XML(ref XmlReader);
                    }
                }
            }
        }

        private void Load_UMK_To_Program_from_XML(ref XmlTextReader XmlReader) {
            ClearAllFields();
            this.othersFieldsForUMK.UpdateFileds("", "", "");
            XmlReader.Read();
            while (!XmlReader.EOF) {
                if (XmlReader.NodeType == XmlNodeType.Element) {
                    switch (XmlReader.Name) {
                        case "Title_inf_for_program":

                            break;
                        case "UMK_razdel_1":
                            ZapFieldsFor_zapiska_and_Compet(ref XmlReader, XmlReader.Name);
                            break;
                        case "Soderjanie_razd_discip":
                            this.zap_SoderjRazd_DataTable_from_Xml(ref XmlReader, "Razdel_2");
                            this.podshet_hours_in_RazdelLesson();
                            break;
                        case "Recommand_literature":
                            this.zap_RecomandLiterature_from_Xml(ref XmlReader);
                            break;
                        case "CurrentControl":
                            while (XmlReader.Read()) {
                                switch (XmlReader.Name) {
                                    case "CurControl":
                                        this.zap_CurControlTable_from_Xml(ref XmlReader);
                                        break;
                                    case "Form_and_rules_attestat":
                                        this.othersFieldsForUMK.FormAndRulesCertification = this.zap_strFields_from_Xml(ref XmlReader);
                                        break;
                                    case "Voprosy_k_ekz":
                                        this.othersFieldsForUMK.QuestionForExam = zap_strFields_from_Xml(ref XmlReader);
                                        break;
                                    case "Example_ekz_Unit":
                                        this.othersFieldsForUMK.ExampleExamTests = zap_strFields_from_Xml(ref XmlReader);
                                        break;
                                }
                                if (XmlReader.Name == "CurrentControl") {
                                    break;
                                }
                            }
                            break;
                    }
                }
                XmlReader.Read();
            }
            XmlReader.Close();
        }

        private void Load_RPD_To_Program_from_XML(ref XmlTextReader XmlReader) {
            ClearAllFields();
            othersFieldsForRPD.UpdateFields("", "", "", "", "", "", "", "", "", "", "");
            XmlReader.Read();
            while (!XmlReader.EOF) {
                if (XmlReader.NodeType == XmlNodeType.Element) {
                    switch (XmlReader.Name) {
                        case "Title_inf_for_program":

                            break;
                        case "RPD_1_2_3":
                            ZapFieldsFor_zapiska_and_Compet(ref XmlReader, "RPD_1_2_3");
                            break;
                        case "RPD_4_5":
                            while (XmlReader.Read() && XmlReader.Name != "RPD_4_5") {
                                switch (XmlReader.Name) {
                                    case "Soderjanie_razd_discip":
                                        this.zap_SoderjRazd_DataTable_from_Xml(ref XmlReader, "Type_and_Form_promej_control");
                                        podshet_hours_in_RazdelLesson();
                                        if (XmlReader.Name == "Type_and_Form_promej_control") {
                                            this.othersFieldsForRPD.TypeAndFormCertification = zap_strFields_from_Xml(ref XmlReader);
                                        }
                                        break;
                                    case "Obraz_technology":
                                        //Считывание полей для заполнения "Используемые образовательные технологии"
                                        List<string> EducateTechnology = this.othersFieldsForRPD.Used_Ecucate_Technology;
                                        EducateTechnology.Clear();
                                        while (XmlReader.Read() && XmlReader.Name != "Part_zanyatii") {
                                            EducateTechnology.Add(XmlReader.GetAttribute("Value"));
                                        }
                                        if (EducateTechnology.Count == 0) {
                                            EducateTechnology.Add(string.Empty);
                                        }
                                        //Считывание поля для заполнения "доля занятий с использованием активных и интерактивных методов"
                                        this.othersFieldsForRPD.PartInteractiveMethods = XmlReader.GetAttribute("Value");
                                        break;
                                }
                                XmlReader.Read();
                            }
                            break;
                        case "RPD_6":
                            XmlReader.Read();
                            while (XmlReader.Name != "RPD_6") {
                                switch (XmlReader.Name) {
                                    case "CurrentControl":
                                        //для таблицы с текущим контролем успеваемости
                                        zap_CurControlTable_from_Xml(ref XmlReader);
                                        break;
                                    case "Example_Zad_CurControl":
                                        this.othersFieldsForRPD.ExampleTestCurControl = zap_strFields_from_Xml(ref XmlReader);
                                        break;
                                    case "Theme_Referats":
                                        this.othersFieldsForRPD.ThemesOfEsseReferats = zap_strFields_from_Xml(ref XmlReader);
                                        break;
                                    case "Theme_KursJob":
                                        this.othersFieldsForRPD.ThemesOfCourseJob = this.zap_strFields_from_Xml(ref XmlReader);
                                        break;
                                    case "MethodUkaz_SamJob":
                                        this.othersFieldsForRPD.OrganizationOfIndependentWork = this.zap_strFields_from_Xml(ref XmlReader);
                                        break;
                                    case "Promej_Control":
                                        XmlReader.Read();
                                        while (XmlReader.Name != "Promej_Control") {
                                            switch (XmlReader.Name) {
                                                case "About_promej_Control":
                                                    this.othersFieldsForRPD.InterMediateControl = zap_strFields_from_Xml(ref XmlReader);
                                                    break;
                                                case "Example_Zad":
                                                    this.othersFieldsForRPD.ExampleTest = zap_strFields_from_Xml(ref XmlReader);
                                                    break;
                                                case "Vopros_k_Ekz":
                                                    this.othersFieldsForRPD.QuestionForExam = this.zap_strFields_from_Xml(ref XmlReader);
                                                    break;
                                            }
                                            XmlReader.Read();
                                        }
                                        break;
                                }
                                XmlReader.Read();
                            }
                            break;
                        case "Recommand_literature":
                            //рекомендуемая литература
                            zap_RecomandLiterature_from_Xml(ref XmlReader);
                            break;
                        case "Technical_Obespech":
                            this.othersFieldsForRPD.LogisticsDiscipline = zap_strFields_from_Xml(ref XmlReader);
                            break;
                    }
                }
                XmlReader.Read();
            }
            XmlReader.Close();
        }

        #region Дополнительные методы
        /// <summary>
        /// очистка значений всех полей текущего экземпляра класса
        /// </summary>
        private void ClearAllFields() {
            this.Student_Doljen_Umet = string.Empty;
            this.Student_doljen_Vladet = string.Empty;
            this.Student_Doljen_Znat = string.Empty;
            this.PlaceOOP = string.Empty;
            this.GoalsDiscip = string.Empty;
            this.FilePathToRPD = string.Empty;
            this.FilePathToUMK = string.Empty;
            Data_with_RPD = string.Empty;
            Data_with_UMK = string.Empty;
            SoderjRazd_DataTable.Clear();
            LiteratureTable.Clear();
            this.table_for_key_compet.Clear();
        }

        private void ZapFieldsForTitle(ref XmlTextReader XmlReader) {
            HourLab = 0;
            HourLec = 0;
            HourSam = 0;

        }

        private void ZapFieldsFor_zapiska_and_Compet(ref XmlTextReader XmlReader, string end_teg) {
            XmlReader.Read();
            this.table_for_key_compet = new List<KeyCompetTable>();
            while (XmlReader.Name != end_teg) {
                switch (XmlReader.Name) {
                    case "GoalsDisciplin":
                        this.GoalsDiscip = zap_strFields_from_Xml(ref XmlReader);
                        break;
                    case "PlaceOOP":
                        XmlReader.Read();
                        string tmp = string.Empty;
                        while (XmlReader.Read() && XmlReader.HasAttributes) {
                            tmp += XmlReader.GetAttribute("Value") + '\n';
                        }
                        if(tmp != String.Empty){
                            tmp = tmp.Substring(0, tmp.Length - 1);
                        }
                        this.PlaceOOP = tmp;
                        break;
                    case "Competetion":

                        break;
                    case "Key_compet":
                        while (XmlReader.Read() && XmlReader.Name != "Key_compet") {
                            if (XmlReader.Name == "Competetion" && XmlReader.HasAttributes) {                                          
                                //Название ключевой компетенции
                                this.table_for_key_compet.Add(new KeyCompetTable(XmlReader.GetAttribute("Name")));
                                for (int i = 0; i < 3; i++) {
                                    XmlReader.Read();
                                    table_for_key_compet[table_for_key_compet.Count - 1].AddRow(XmlReader.GetAttribute("ur_osv"),
                                                                                                XmlReader.GetAttribute("priznak_osv"));
                                }
                            }
                            if (XmlReader.Name == "Student_must_znat") {
                                break;
                            }
                        }
                        if (XmlReader.Name == "Student_must_znat") { continue; }
                        break;
                    case "Student_must_znat":
                        this.Student_Doljen_Znat = zap_strFields_from_Xml(ref XmlReader);
                        break;
                    case "Student_must_umet":
                        this.Student_Doljen_Umet = zap_strFields_from_Xml(ref XmlReader);
                        break;
                    case "Student_must_vladet":
                        this.Student_doljen_Vladet = zap_strFields_from_Xml(ref XmlReader);
                        break;
                }
                XmlReader.Read();
            }
        }
        /// <summary>
        /// Заполнение строковых полей данными из *.xml файла, собирая воедино без абзацев
        /// </summary>
        /// <param name="List_abzac"></param>
        /// <param name="XmlReader"></param>
        private string zap_strFields_from_Xml(ref XmlTextReader XmlReader) {
            string str = string.Empty;
            if (XmlReader.IsStartElement() && !XmlReader.IsEmptyElement) {
                while (XmlReader.Read() && XmlReader.HasAttributes) {
                    str += XmlReader.GetAttribute("Value") + '\n';
                }
                if (str != String.Empty) {
                    str = str.Substring(0, str.Length - 1);
                }
            }
            return str;
        }

        private void zap_RecomandLiterature_from_Xml(ref XmlTextReader XmlReader) {
            if (XmlReader.IsStartElement() && !XmlReader.IsEmptyElement) {
                string type_liter = String.Empty;
                while (XmlReader.Read() && XmlReader.HasAttributes) {
                    switch (XmlReader.Name) {
                        case "Main_Liter":
                            type_liter = "Основная";
                            break;
                        case "Dop_Liter":
                            type_liter = "Дополнительная";
                            break;
                        case "Elektr_Resourse":
                            type_liter = "Электронный ресурс";
                            break;
                    }
                    this.LiteratureTable.AddRow(type_liter, XmlReader.GetAttribute("Author").ToString());
                }
            }
        }
        /// <summary>
        /// считывание из XmlReader узлов, содержащих инфомрацию о текущем контроле успеваемости 
        /// для заполнения таблицы CurControlTable
        /// </summary>
        /// <param name="XmlReader"></param>
        private void zap_CurControlTable_from_Xml(ref XmlTextReader XmlReader) {
            if (XmlReader.IsStartElement() && !XmlReader.IsEmptyElement) {
                this.CurControlTable.Clear();
                while (XmlReader.Read() && XmlReader.HasAttributes) {
                    this.CurControlTable.AddRow(XmlReader.GetAttribute("Name_meropriyatie").ToString(),
                                                XmlReader.GetAttribute("Ball").ToString(),
                                                XmlReader.GetAttribute("Num_theme").ToString());
                }
            }
        }

        private void zap_SoderjRazd_DataTable_from_Xml(ref XmlTextReader XmlReader, string end_teg) {
            while (XmlReader.Name != end_teg) {
                switch (XmlReader.Name) {
                    case "Razdel":
                        if (XmlReader.HasAttributes) {
                            this.SoderjRazd_DataTable.AddRow("Раздел",
                                                            (XmlReader.GetAttribute("Semestr") == null) ? String.Empty : XmlReader.GetAttribute("Semestr"),
                                                            (XmlReader.GetAttribute("About_razdel") == null) ? String.Empty : XmlReader.GetAttribute("About_razdel"),
                                                            0.0,
                                                            (XmlReader.GetAttribute("FormCurControl") == null) ? String.Empty : XmlReader.GetAttribute("FormCurControl"));
                        }
                        break;
                    case "Theme":
                        if (XmlReader.HasAttributes) {
                            this.SoderjRazd_DataTable.AddRow("Тема",
                                                            (XmlReader.GetAttribute("Semestr") == null) ? String.Empty : XmlReader.GetAttribute("Semestr"),
                                                            (XmlReader.GetAttribute("About_theme") == null) ? String.Empty : XmlReader.GetAttribute("About_theme"),
                                                            0.0,
                                                            (XmlReader.GetAttribute("FormCurControl") == null) ? String.Empty : XmlReader.GetAttribute("FormCurControl"));
                        }
                        break;
                    case "Lec":
                        this.SoderjRazd_DataTable.AddRow("Лекция",
                                                        SoderjRazd_DataTable[SoderjRazd_DataTable.RowCount - 1, "SemestrColumn"].ToString(),
                                                        (XmlReader.GetAttribute("About_Lec") == null) ? String.Empty : XmlReader.GetAttribute("About_Lec"),
                                                        Convert.ToDouble(XmlReader.GetAttribute("Hours")),
                                                        string.Empty);
                        break;
                    case "Praktika":
                        this.SoderjRazd_DataTable.AddRow("Семинар",
                                                        SoderjRazd_DataTable[SoderjRazd_DataTable.RowCount - 1, "SemestrColumn"].ToString(),
                                                        (XmlReader.GetAttribute("About_praktik") == null) ? String.Empty : XmlReader.GetAttribute("About_praktik"),
                                                        Convert.ToDouble(XmlReader.GetAttribute("Hours")),
                                                        string.Empty);
                        break;
                    case "SamJob":
                        this.SoderjRazd_DataTable.AddRow("Сам. работа",
                                                        SoderjRazd_DataTable[SoderjRazd_DataTable.RowCount - 1, "SemestrColumn"].ToString(),
                                                        (XmlReader.GetAttribute("About_samJob") == null) ? String.Empty : XmlReader.GetAttribute("About_samJob"),
                                                        Convert.ToDouble(XmlReader.GetAttribute("Hours")),
                                                        string.Empty);
                        break;
                }
                XmlReader.Read();
            }
        }
        /// <summary>
        /// Пересчет объема часов для тем и разделов в DataGridRazdelLesson
        /// </summary>
        internal void podshet_hours_in_RazdelLesson() {
            double temp = 0;
            for (int i = 0; i < this.SoderjRazd_DataTable.RowCount; i++) {
                int j;
                switch (this.SoderjRazd_DataTable[i, "VidColumn"].ToString().Trim()) {
                    case "Раздел":
                        j = i + 1;
                        while (j <= this.SoderjRazd_DataTable.RowCount - 1 && this.SoderjRazd_DataTable[j, "VidColumn"].ToString().Trim() != "Раздел") {
                            if (this.SoderjRazd_DataTable[j, "VidColumn"].ToString().Trim() == "Лекция" ||
                                this.SoderjRazd_DataTable[j, "VidColumn"].ToString().Trim() == "Семинар" ||
                                this.SoderjRazd_DataTable[j, "VidColumn"].ToString().Trim() == "Сам. работа") {
                                temp += Convert.ToDouble(this.SoderjRazd_DataTable[j, "VolumeColumn"]);
                            }
                            j++;
                        }
                        this.SoderjRazd_DataTable[i, "VolumeColumn"] = temp;
                        temp = 0;
                        break;
                    case "Тема":
                        j = i + 1;
                        while (j <= this.SoderjRazd_DataTable.RowCount - 1 && this.SoderjRazd_DataTable[j, "VidColumn"].ToString().Trim() != "Тема") {
                            if (this.SoderjRazd_DataTable[j, "VidColumn"].ToString().Trim() == "Лекция" ||
                                this.SoderjRazd_DataTable[j, "VidColumn"].ToString().Trim() == "Семинар" ||
                                this.SoderjRazd_DataTable[j, "VidColumn"].ToString().Trim() == "Сам. работа") {
                                temp += Convert.ToDouble(this.SoderjRazd_DataTable[j, "VolumeColumn"]);
                            }
                            j++;
                        }
                        this.SoderjRazd_DataTable[i, "VolumeColumn"] = temp;
                        temp = 0;
                        break;
                }
            }
        }
        #endregion
        
    }

    [Serializable()]
    public class SummaryTable {
        protected DataTable data;
        public SummaryTable() {
            data = new DataTable();
        }
        public Object this[int RowIndex, int ColumnIndex] {
            get {
                return this.data.Rows[RowIndex][ColumnIndex];
            }
            set {
                this.data.Rows[RowIndex][ColumnIndex] = value;
            }
        }

        public Object this[int RowIndex, string ColumnName] {
            get {
                return this.data.Rows[RowIndex][ColumnName];
            }
            set {
                this.data.Rows[RowIndex][ColumnName] = value;
            }
        }

        public int ColumnCount {
            get {
                return this.data.Columns.Count;
            }
        }

        public int RowCount {
            get {
                return this.data.Rows.Count;
            }
        }

        public void Clear() {
            this.data.Clear();
        }

        public IEnumerator<DataRow> GetEnumerator() {
            for (int index = 0; index < this.data.Rows.Count; index++) {
                yield return this.data.Rows[index];
            }
        }
    }

    /// <summary>
    /// класс для хранения таблицы текущего контроля успеваемости студентов
    /// </summary>
    [Serializable()]
    public class CurrentControlTable : SummaryTable {
        
        /// <summary>
        /// 
        /// </summary>
        public CurrentControlTable() 
            :base()
        {
            //data = new DataTable();
            DataColumn FormCurControlColumn = new DataColumn("FormCurControlColumn");
            FormCurControlColumn.DataType = System.Type.GetType("System.String");

            DataColumn NumberBallColumn = new DataColumn("NumberBallColumn");
            NumberBallColumn.DataType = System.Type.GetType("System.String");

            DataColumn NameTheme = new DataColumn("ThemeColumn");
            NameTheme.DataType = System.Type.GetType("System.String");
            this.data.Columns.AddRange(new DataColumn[] { FormCurControlColumn, NumberBallColumn, NameTheme });
        }
        /// <summary>
        /// Добавление сроки в таблицу
        /// </summary>
        /// <param name="FormCurControlColumn">Форма текущего контроля</param>
        /// <param name="Number_ball">Количество баллов</param>
        /// <param name="Name_Theme">Название темы</param>
        public void AddRow(string FormCurControlColumn, string Number_ball, string Name_Theme) {
            DataRow Row = this.data.NewRow();
            Row["FormCurControlColumn"] = FormCurControlColumn;
            Row["NumberBallColumn"] = Number_ball;
            Row["ThemeColumn"] = Name_Theme;
            this.data.Rows.Add(Row);
        }
        /// <summary>
        /// Удаление строки из таблицы
        /// </summary>
        /// <param name="CurrentRow">Номер удаляемой строки</param>
        public void RemoveRow(int CurrentRow) {
            if (CurrentRow >= 0 && CurrentRow < this.data.Rows.Count) {
                this.data.Rows.RemoveAt(CurrentRow);
            }
            else {
                throw new Exception("Задан неверный индекс строки для удаления");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CurrentRow">редактируемая строка</param>
        /// <param name="FormCurControlColumn">форма текущего контроля</param>
        /// <param name="Number_ball">количество баллов</param>
        /// <param name="Name_Theme">тема</param>
        public void EditRow(int CurrentRow, string FormCurControlColumn, string Number_ball, string Name_Theme) {
            if (CurrentRow >= 0 && CurrentRow < this.data.Rows.Count) {
                DataRow Row = this.data.Rows[CurrentRow];
                Row["FormCurControlColumn"] = FormCurControlColumn;
                Row["NumberBallColumn"] = Number_ball;
                Row["ThemeColumn"] = Name_Theme;
            }
            else {
                throw new Exception("Задан неверный индекс строки для редактирования");
            }
        }        
    }
    /// <summary>
    /// класс для таблицы, хранящей описание разделов/тем/лекций/сам. работ/семинарских занятий
    /// </summary>
    [Serializable()]
    public class SoderjRazdDiscip_DataTable :SummaryTable {
        //DataTable data;
        public SoderjRazdDiscip_DataTable() {
            data = new DataTable();
            DataColumn VidColumn,
                        SemestrColumn,
                        AboutColumn,
                        VolumeColumn,
                        FormCurControlColumn;
            VidColumn = new DataColumn("VidColumn");
            VidColumn.DataType = System.Type.GetType("System.String");

            SemestrColumn = new DataColumn("SemestrColumn");
            SemestrColumn.DataType = System.Type.GetType("System.String");

            AboutColumn = new DataColumn("AboutColumn");
            AboutColumn.DataType = System.Type.GetType("System.String");

            VolumeColumn = new DataColumn("VolumeColumn");
            VolumeColumn.DataType = System.Type.GetType("System.Double");

            FormCurControlColumn = new DataColumn("FormCurControlColumn");
            FormCurControlColumn.DataType = System.Type.GetType("System.String");

            this.data.Columns.AddRange(new DataColumn[] { VidColumn, SemestrColumn, AboutColumn, VolumeColumn, FormCurControlColumn });
        }
        /// <summary>
        /// добавляет строку в конец таблицы
        /// </summary>
        /// <param name="VidColumn">Раздел/Тема/Лекция/Семинар/Сам. работа</param>
        /// <param name="SemestrColumn">семестр</param>
        /// <param name="AboutColumn">содержание занятия</param>
        /// <param name="VolumeColumn">объем, часов</param>
        /// <param name="FormCurControlColumn">форма текущего контроля успеваемости</param>
        public void AddRow(string VidColumn, string SemestrColumn, string AboutColumn, double VolumeColumn, string FormCurControlColumn) {
            DataRow CurRow = this.data.NewRow();
            CurRow["VidColumn"] = VidColumn;
            CurRow["SemestrColumn"] = SemestrColumn;
            CurRow["AboutColumn"] = AboutColumn;
            CurRow["VolumeColumn"] = VolumeColumn;
            CurRow["FormCurControlColumn"] = FormCurControlColumn;
            this.data.Rows.Add(CurRow);
        }
        /// <summary>
        /// добавление нового занятия в таблицу
        /// </summary>
        /// <param name="index">номер добавляемой строки, если == -1, то строка добавляется в конец таблицы</param>
        /// <param name="VidColumn">Раздел/Тема/Лекция/Семинар/Сам. работа</param>
        /// <param name="SemestrColumn">семестр</param>
        /// <param name="AboutColumn">содержание занятия</param>
        /// <param name="VolumeColumn">объем, часов</param>
        /// <param name="FormCurControlColumn">форма текущего контроля успеваемости</param>
        public void InsertRow(int index, string VidColumn, string SemestrColumn, string AboutColumn, double VolumeColumn, string FormCurControlColumn) {
            if(index >= -1){
                DataRow CurRow = this.data.NewRow();
                data.Rows.InsertAt(CurRow, index);
                CurRow["VidColumn"] = VidColumn;
                CurRow["SemestrColumn"] = SemestrColumn;
                CurRow["AboutColumn"] = AboutColumn;
                CurRow["VolumeColumn"] = VolumeColumn;
                CurRow["FormCurControlColumn"] = FormCurControlColumn;
            }
            else {
                throw new Exception("Задана неверный позиция для вставки новой строки");
            }
        }
        public void EditRow(int index, string VidColumn, string SemestrColumn, string AboutColumn, double VolumeColumn, string FormCurControlColumn) {
            if (index >= 0 && index < this.data.Rows.Count) {
                DataRow CurRow = this.data.Rows[index];
                CurRow["VidColumn"] = VidColumn;
                CurRow["SemestrColumn"] = SemestrColumn;
                CurRow["AboutColumn"] = AboutColumn;
                CurRow["VolumeColumn"] = VolumeColumn;
                CurRow["FormCurControlColumn"] = FormCurControlColumn;
            }
            else {
                throw new Exception("Задан неверный индекс строки для редактирования");
            }
        }
        
    }
    [Serializable()]
    public class LiteratureDataTable :SummaryTable {
        //DataTable data;
        public LiteratureDataTable() {
            data = new DataTable();
            DataColumn Type_liter,
                        AboutLiter;
            Type_liter = new DataColumn("Type_liter");
            Type_liter.DataType = System.Type.GetType("System.String");

            AboutLiter = new DataColumn("AboutLiter");
            AboutLiter.DataType = System.Type.GetType("System.String");

            this.data.Columns.AddRange(new DataColumn[] { Type_liter, AboutLiter });
        }

        public void AddRow(string TypeLiter, string AboutLiter) {
            DataRow Row = this.data.NewRow();
            this.data.Rows.Add(Row);
            Row["Type_liter"] = TypeLiter;
            Row["AboutLiter"] = AboutLiter;
        }

        public void EditRow(int index, string TypeLiter, string AboutLiter) {
            if(index > 0 && index < this.data.Rows.Count){
                DataRow Row = this.data.Rows[index];
                Row["Type_liter"] = TypeLiter;
                Row["AboutLiter"] = AboutLiter;
            }
            else{
                throw new Exception("Задан неверный индекс строки для редактирования");
            }
        }

        public void RemoveRow(int index) {
            if (index > 0 && index < this.data.Rows.Count) {
                this.data.Rows.RemoveAt(index);
            }
            else {
                throw new Exception("Задан неверный индекс строки для удаления");
            }
        }
    }
    [Serializable()]
    public class SummaryOthersFields {
        public SummaryOthersFields() {

        }
        /// <summary>
        /// Преобразование строки str в массив строк, 
        /// каждая строка - отдельный абзац (то есть парсим на основе символа \n)
        /// </summary>
        /// <param name="str">входная строка</param>
        /// <returns>список строк-абзацев</returns>
        protected List<string> ConvertStrToListWithAbzac(string str) {
            List<string> format_result = new List<string>();
            if (str != null) {
                //позиция символа переноса строки
                int numberEnter;
                const char Enter = '\n';
                //пока есть символа переноса строки, то добавляем новые абзацы в список
                while ((numberEnter = str.IndexOf(Enter)) >= 0) {
                    if (str != string.Empty && numberEnter > 0) {
                        string tmp = str.Substring(0, numberEnter);
                        if (tmp[tmp.Length - 1] == '\n' || tmp[tmp.Length - 1] == '\r') {
                            format_result.Add(tmp.Substring(0, tmp.Length - 1));
                        }
                        else {
                            format_result.Add(tmp);
                        }
                        str = str.Remove(0, numberEnter + 1);
                    }
                    else if(numberEnter == 0){                                      
                        if(str[0] == '\n' || str[0] == '\r'){
                            format_result.Add(string.Empty);
                            str = str.Remove(0, 1);
                        }
                    }
                }
                //если строка пуста и список пуст, то с список добавляем только один абзац, содержащимй пустую строку
                if (format_result.Count == 0 && str.Length == 0) {
                    format_result.Add(String.Empty);
                }
                //иначе добавляем в качестве последнего абзаца оставшийся кусок строки
                else if((format_result.Count == 0 && str.Length != 0) || (format_result.Count != 0 && str.Length != 0)) {
                    format_result.Add(str.Trim());
                }
            }
            else {
                format_result.Add(String.Empty);
            }
            if (format_result.Count != 0 && format_result[format_result.Count - 1] == "\r\n") {
                format_result.RemoveAt(format_result.Count - 1);
            }
            return format_result;
        }
        /// <summary>
        /// Преобразуем обратно массив строк-абзацев в единую строку
        /// </summary>
        /// <param name="StrWithAbzac">массив строк-абзацев</param>
        /// <returns>единая строка</returns>
        protected string ConvertListWithAbzacToStr(List<string> StrWithAbzac) {
            StringBuilder strBuilder = new StringBuilder();
            foreach (string tmp in StrWithAbzac) {
                strBuilder.AppendLine(tmp);
            }
            string tmp_result = strBuilder.ToString();
            return tmp_result.Substring(0, tmp_result.Length - 2);
        }
    }

    /// <summary>
    /// хранит оставишеся 3 поля, которые предназначены только дла заполнения в УМК:
    /// 1. Форма и правила проведения промежуточной аттестации (зачет / экзамена)
    /// 2. Перечень вопросов к экзамену / зачету
    /// 3. Образцы экзаменационных тестов, заданий
    /// </summary>
    [Serializable()]
    public class OthersFieldsForUMK : SummaryOthersFields {
        #region используемые переменные
        /// <summary>
        /// форма и правила проведения промежуточной аттестации
        /// </summary>
        internal List<string> Form_And_Rules_Certification;
        /// <summary>
        /// перечень вопросов к экзамену/зачету
        /// </summary>
        internal List<string> Question_For_Exam;
        /// <summary>
        /// образцы экзаменационных тестов, заданий
        /// </summary>
        internal List<string> Example_Exam_Tests;
        #endregion
        
        #region свойства для доступа к описанным выше полям
        /// <summary>
        /// форма и правила проведения промежуточной аттестации
        /// </summary>
        public string FormAndRulesCertification {
            get {
                return this.ConvertListWithAbzacToStr(this.Form_And_Rules_Certification);
            }
            set {
                this.Form_And_Rules_Certification = this.ConvertStrToListWithAbzac(value);
            }
        }
        /// <summary>
        /// перечень вопросов к экзамену/зачету
        /// </summary>
        public string QuestionForExam {
            get {
                return this.ConvertListWithAbzacToStr(this.Question_For_Exam);
            }
            set {
                this.Question_For_Exam = this.ConvertStrToListWithAbzac(value);
            }
        }
        /// <summary>
        /// образцы экзаменационных тестов, заданий
        /// </summary>
        public string ExampleExamTests {
            get {
                return this.ConvertListWithAbzacToStr(this.Example_Exam_Tests);
            }
            set {
                this.Example_Exam_Tests = this.ConvertStrToListWithAbzac(value);
            }
        }
        #endregion
        /// <summary>
        /// инициализация объекта для дальшейшего заполнения его полей
        /// </summary>
        /// <param name="FormAndRulesCertification">форма и правила проведения промежуточной аттестации</param>
        /// <param name="QuestionForExam">перечень вопросов к экзамену/зачету</param>
        /// <param name="ExampleExamTests">образцы экзаменационных тестов, заданий</param>
        public OthersFieldsForUMK(  string FormAndRulesCertification, 
                                    string QuestionForExam, 
                                    string ExampleExamTests)
            :base()
        {
            this.FormAndRulesCertification = FormAndRulesCertification;
            this.QuestionForExam = QuestionForExam;
            this.ExampleExamTests = ExampleExamTests;
        }
        /// <summary>
        /// обновление данных
        /// </summary>
        /// <param name="FormAndRulesCertification">форма и правила проведения промежуточной аттестации</param>
        /// <param name="QuestionForExam">перечень вопросов к экзамену/зачету</param>
        /// <param name="ExampleExamTests">образцы экзаменационных тестов, заданий</param>
        public void UpdateFileds(   string FormAndRulesCertification,
                                    string QuestionForExam,
                                    string ExampleExamTests) {
            this.FormAndRulesCertification = FormAndRulesCertification;
            this.QuestionForExam = QuestionForExam;
            this.ExampleExamTests = ExampleExamTests;
        }      
    }
    /// <summary>
    /// хрнаит оставшиеся поля, котоыре предназначены только для заполнения РПД:
    /// 1. Вид и форма проведения промежуточной аттестации
    /// 2. Используемые образовательные технологии
    /// 3. Образцы тестов и контрольных занятий текущего контроля
    /// 4. примерная тематика эссе, рефератов, докладов
    /// 5. Примерные темы курсовых работ, критерии оценивания
    /// 6. Методические указания по организации самостоятельной работы
    /// 7. Промежуточный контроль
    /// 8. Образцы тестов, заданий
    /// 9. Перечень вопросов к экзамену (зачету)
    /// 10. Материально-техническое обеспечение дисциплины
    /// </summary>
    [Serializable()]
    public class OthersFieldsForRPD : SummaryOthersFields {
        #region Используемые переменные
        /// <summary>
        /// Вид и форма проведения промежуточной аттестации
        /// </summary>
        internal List<string> Type_and_FormCertification;
        /// <summary>
        /// Используемые образовательные технологии
        /// </summary>
        internal List<string> Used_Ecucate_Technology;
        /// <summary>
        /// Образцы тестов и контрольных занятий текущего контроля
        /// </summary>
        internal List<string> Example_Test_CurControl;
        /// <summary>
        /// примерная тематика эссе, рефератов, докладов
        /// </summary>
        internal List<string> Themes_Of_Esse_Referats;
        /// <summary>
        /// Примерные темы курсовых работ, критерии оценивания
        /// </summary>
        internal List<string> Themes_Of_CourseJob;
        /// <summary>
        /// Методические указания по организации самостоятельной работы
        /// </summary>
        internal List<string> Organization_Of_IndependentWork;
        /// <summary>
        /// Промежуточный контроль
        /// </summary>
        internal List<string> InterMediate_Control;
        /// <summary>
        /// Образцы тестов, заданий
        /// </summary>
        internal List<string> Example_Test;
        /// <summary>
        /// Перечень вопросов к экзамену (зачету)
        /// </summary>
        internal List<string> Question_For_Exam;
        /// <summary>
        /// Материально-техническое обеспечение дисциплины
        /// </summary>
        internal List<string> Logistics_Discipline;
        /// <summary>
        /// доля занятий с использованием актиных и интерактивнх образовательных технологий
        /// </summary>
        internal string PartInteractiveMethods;
        #endregion
        
        #region Свойства, используемые для доступа к полям объекта
        /// <summary>
        /// Вид и форма проведения промежуточной аттестации
        /// </summary>
        public string TypeAndFormCertification {
            get {
                return ConvertListWithAbzacToStr(this.Type_and_FormCertification);
            }
            set {
                this.Type_and_FormCertification = ConvertStrToListWithAbzac(value);
            }
        }
        /// <summary>
        /// Используемые образовательные технологии
        /// </summary>
        public string UsedEcucateTechnology {
            get {
                return this.ConvertListWithAbzacToStr(this.Used_Ecucate_Technology);
            }
            set {
                this.Used_Ecucate_Technology = ConvertStrToListWithAbzac(value);
            }
        }
        /// <summary>
        /// Образцы тестов и контрольных занятий текущего контроля
        /// </summary>
        public string ExampleTestCurControl {
            get {
                return this.ConvertListWithAbzacToStr(this.Example_Test_CurControl);
            }
            set {
                this.Example_Test_CurControl = ConvertStrToListWithAbzac(value);
            }
        }
        /// <summary>
        /// примерная тематика эссе, рефератов, докладов
        /// </summary>
        public string ThemesOfEsseReferats {
            get {
                return this.ConvertListWithAbzacToStr(this.Themes_Of_Esse_Referats);
            }
            set {
                this.Themes_Of_Esse_Referats = ConvertStrToListWithAbzac(value);
            }
        }
        /// <summary>
        /// Примерные темы курсовых работ, критерии оценивания
        /// </summary>
        public string ThemesOfCourseJob {
            get {
                return this.ConvertListWithAbzacToStr(this.Themes_Of_CourseJob);
            }                                                                   
            set {
                this.Themes_Of_CourseJob = ConvertStrToListWithAbzac(value);
            }
        }
        /// <summary>
        /// Методические указания по организации самостоятельной работы
        /// </summary>
        public string OrganizationOfIndependentWork {
            get {
                return this.ConvertListWithAbzacToStr(this.Organization_Of_IndependentWork);
            }
            set {
                this.Organization_Of_IndependentWork = this.ConvertStrToListWithAbzac(value);
            }
        }
        /// <summary>
        /// Промежуточный контроль
        /// </summary>
        public string InterMediateControl {
            get {
                return this.ConvertListWithAbzacToStr(this.InterMediate_Control);
            }
            set {
                this.InterMediate_Control = ConvertStrToListWithAbzac(value);
            }
        }
        /// <summary>
        /// Образцы тестов, заданий
        /// </summary>
        public string ExampleTest {
            get {
                return this.ConvertListWithAbzacToStr(this.Example_Test);
            }
            set {
                this.Example_Test = ConvertStrToListWithAbzac(value);
            }
        }
        /// <summary>
        /// Перечень вопросов к экзамену (зачету)
        /// </summary>
        public string QuestionForExam {
            get {
                return this.ConvertListWithAbzacToStr(this.Question_For_Exam);
            }
            set {
                this.Question_For_Exam = this.ConvertStrToListWithAbzac(value);
            }
        }
        /// <summary>
        /// Материально-техническое обеспечение дисциплины
        /// </summary>
        public string LogisticsDiscipline {
            get {
                return this.ConvertListWithAbzacToStr(this.Logistics_Discipline);
            }
            set {
                this.Logistics_Discipline = this.ConvertStrToListWithAbzac(value);
            }
        }
        #endregion
        /// <summary>
        /// инциализация
        /// </summary>
        /// <param name="TypeAndFormCertification">Вид и форма проведения промежуточной аттестации</param>
        /// <param name="UsedEcucateTechnology">Используемые образовательные технологии</param>
        /// <param name="ExampleTestCurControl">Образцы тестов и контрольных занятий текущего контроля</param>
        /// <param name="ThemesOfEsseReferats">примерная тематика эссе, рефератов, докладов</param>
        /// <param name="ThemesOfCourseJob">Примерные темы курсовых работ, критерии оценивания</param>
        /// <param name="OrganizationOfIndependentWork">Методические указания по организации самостоятельной работы</param>
        /// <param name="InterMediateControl">Промежуточный контроль</param>
        /// <param name="ExampleTest">Образцы тестов, заданий</param>
        /// <param name="QuestionForExam">Перечень вопросов к экзамену (зачету)</param>
        /// <param name="LogisticsDiscipline">Материально-техническое обеспечение дисциплины</param>
        public OthersFieldsForRPD(  string TypeAndFormCertification,
                                    string UsedEcucateTechnology,
                                    string ExampleTestCurControl,
                                    string ThemesOfEsseReferats,
                                    string ThemesOfCourseJob,
                                    string OrganizationOfIndependentWork,
                                    string InterMediateControl,
                                    string ExampleTest,
                                    string QuestionForExam,
                                    string LogisticsDiscipline,
                                    string PartInteractiveMethods)
            :base()
        {
                                        this.TypeAndFormCertification = TypeAndFormCertification;
            this.UsedEcucateTechnology = UsedEcucateTechnology;
            this.ExampleTestCurControl = ExampleTestCurControl;
            this.ThemesOfEsseReferats = ThemesOfEsseReferats;
            this.ThemesOfCourseJob = ThemesOfCourseJob;
            this.OrganizationOfIndependentWork = OrganizationOfIndependentWork;
            this.InterMediateControl = InterMediateControl;
            this.ExampleTest = ExampleTest;
            this.QuestionForExam = QuestionForExam;
            this.LogisticsDiscipline = LogisticsDiscipline;
            this.PartInteractiveMethods = PartInteractiveMethods;
        }

        /// <summary>
        /// обновление данных
        /// </summary>
        /// <param name="TypeAndFormCertification">Вид и форма проведения промежуточной аттестации</param>
        /// <param name="UsedEcucateTechnology">Используемые образовательные технологии</param>
        /// <param name="ExampleTestCurControl">Образцы тестов и контрольных занятий текущего контроля</param>
        /// <param name="ThemesOfEsseReferats">примерная тематика эссе, рефератов, докладов</param>
        /// <param name="ThemesOfCourseJob">Примерные темы курсовых работ, критерии оценивания</param>
        /// <param name="OrganizationOfIndependentWork">Методические указания по организации самостоятельной работы</param>
        /// <param name="InterMediateControl">Промежуточный контроль</param>
        /// <param name="ExampleTest">Образцы тестов, заданий</param>
        /// <param name="QuestionForExam">Перечень вопросов к экзамену (зачету)</param>
        /// <param name="LogisticsDiscipline">Материально-техническое обеспечение дисциплины</param>
        public void UpdateFields(string TypeAndFormCertification,
                                    string UsedEcucateTechnology,
                                    string ExampleTestCurControl,
                                    string ThemesOfEsseReferats,
                                    string ThemesOfCourseJob,
                                    string OrganizationOfIndependentWork,
                                    string InterMediateControl,
                                    string ExampleTest,
                                    string QuestionForExam,
                                    string LogisticsDiscipline,
                                    string PartInteractiveMethods) {
            this.TypeAndFormCertification = TypeAndFormCertification;
            this.UsedEcucateTechnology = UsedEcucateTechnology;
            this.ExampleTestCurControl = ExampleTestCurControl;
            this.ThemesOfEsseReferats = ThemesOfEsseReferats;
            this.ThemesOfCourseJob = ThemesOfCourseJob;
            this.OrganizationOfIndependentWork = OrganizationOfIndependentWork;
            this.InterMediateControl = InterMediateControl;
            this.ExampleTest = ExampleTest;
            this.QuestionForExam = QuestionForExam;
            this.LogisticsDiscipline = LogisticsDiscipline;
            this.PartInteractiveMethods = PartInteractiveMethods;
        }
    }
    /// <summary>
    /// для каждой таблицы с ключевыми компетенциями
    /// </summary>
    [Serializable()]
    public class KeyCompetTable : SummaryTable {
        public KeyCompetTable(string TableName) {
            this.data = new DataTable();
            this.data.TableName = TableName;
            DataColumn Ur_osv = new DataColumn("Уровень освоения"),
                        priznak_osv = new DataColumn("Признак освоения");
            Ur_osv.DataType = System.Type.GetType("System.String");
            priznak_osv.DataType = System.Type.GetType("System.String");
            this.data.Columns.AddRange(new DataColumn[] { Ur_osv, priznak_osv });
        }

        public void AddRow(string Ur_osv, string priznak_Osv) {
            this.data.Rows.Add(Ur_osv, priznak_Osv);
        }

        public void EditRow(int RowIndex, string Ur_osv, string priznak_Osv) {
            if(RowIndex > 0 && RowIndex < this.data.Rows.Count){
                this.data.Rows[RowIndex][0] = Ur_osv;
                this.data.Rows[RowIndex][1] = priznak_Osv;
            }
            else {
                throw new Exception("Задан неверный индекс строки для редактирования");
            }
        }

        public void RemoveRow(int RowIndex) {
            if(RowIndex > 0 && RowIndex < this.data.Rows.Count){
                this.data.Rows.RemoveAt(RowIndex);
            }
            else {
                throw new Exception("Задан неверный индекс строки для удаления");
            }
        }
        /// <summary>
        /// имя таблицы с ключевой компетенцией
        /// </summary>
        public string TableName {
            get {
                return this.data.TableName;
            }
        }
    }
}