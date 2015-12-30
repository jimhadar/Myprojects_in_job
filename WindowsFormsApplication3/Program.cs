using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UMK_RPD
{
    internal enum OpenMode { NewRpd, NewUmk, OpenRpd, OpenUmk }
    internal struct ModeProgram {
        OpenMode _openMode;
        int _IdRpd_or_UMK;
        public OpenMode openMode {
            get { return _openMode; }
            set { _openMode = value; }
        }
        public int IdRpd_or_UMK {
            get { return _IdRpd_or_UMK; }
            set { _IdRpd_or_UMK = value; }
        }
        public ModeProgram(OpenMode _openMode, int _IdRpd_or_UMK) {
            this._IdRpd_or_UMK = _IdRpd_or_UMK;
            this._openMode = _openMode;
        }
    }
    static class Program
    {        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HeadForm());
        }
    }
}