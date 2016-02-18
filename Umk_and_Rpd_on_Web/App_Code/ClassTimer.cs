using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Data;
using System.IO;

namespace Umk_and_Rpd_on_Web.App_Code {
    public class TimerModule : IHttpModule {
        /// <summary>
        /// для удаления пустых записей из базы данных раз в сутки
        /// </summary>
        static Timer timerDelStrFromBase;
        /// <summary>
        /// для обновления/удаления записей из базы данных раз вчетверо суток
        /// </summary>
        static Timer timerUpdateStrInBase;
        long hour = 60;//3600000;
        static object synclock = new object();
        public void Init(HttpApplication app) {
            timerUpdateStrInBase = new Timer(new TimerCallback(DeleteEmptyStrFromBase), null, 0, hour * 2);
        }

        /// <summary>
        /// удаление пустых записей из базы данных в промежутке от 2 часов ночи до 6 утра
        /// </summary>
        /// <param name="obj"></param>
        private void DeleteEmptyStrFromBase(object obj) {
            lock (synclock) {
                DateTime dateNow = DateTime.Now;
                if (dateNow.Hour >= 3 && dateNow.Hour <= 7) {
                    using (AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter adapter = new AcademiaDataSetTableAdapters.UMK_and_RPDTableAdapter()) {
                        //удаляем пустые записи из базы данных
                        adapter.DeleteEmptyStr();
                        DataTable tmpTable = adapter.GetDataWithNameEmpty();
                        foreach (DataRow Row in tmpTable.Rows) {
                            //получаем дату последнего сохранения / изменения строки
                            DateTime dateSave = Convert.ToDateTime(Row["DateSave"]);
                            if (dateNow.Subtract(dateSave).Days >= 4) {
                                //если с момента изменения строки прошло более 5 дней, то удаляем строку
                                adapter.Delete((int?)Row["Id_RPD_or_UMK"]);
                            }
                        }
                    }
                }
            }
        }

        public void Dispose() { }
    }
}