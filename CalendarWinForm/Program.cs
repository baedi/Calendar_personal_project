using System;
//using System.IO;
using System.Windows.Forms;

namespace CalendarWinForm {
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try {
                /*
                // ass_SQLite_DLL
                string strJsonPath = Application.ExecutablePath.Replace("/", "\\");
                int intPos = strJsonPath.LastIndexOf("\\");
                if (intPos >= 1) strJsonPath = strJsonPath.Substring(0, intPos).Trim('\\');
                strJsonPath += "\\System.Data.SQLite.dll";

                FileInfo fileInfo = new FileInfo(strJsonPath);
                if(fileInfo.Exists == false) {
                    byte[] aryData = CalendarWinForm.Properties.Resources.ass_SQLite_dll;
                    FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.CreateNew);
                    fileStream.Write(aryData, 0, aryData.Length);
                    fileStream.Close();
                }
                */

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form_Calendar_main());
            } catch(Exception exc) { MessageBox.Show(exc.Message); }
        }

    }


}
