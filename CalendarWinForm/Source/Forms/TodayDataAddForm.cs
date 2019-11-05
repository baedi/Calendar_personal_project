using System;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CalendarWinForm {
    public partial class TodayDataAddForm : Form {

        // Instance var.    
        private readonly CalendarMain calendar;
        private SQLiteConnection tempConnect;
        private SQLiteCommand command;

        private readonly bool isAddMode;
        private decimal[] originalHM;


        // Constructor. 
        public TodayDataAddForm(CalendarMain calendar, SQLiteConnection conn, bool mode)  {
            InitializeComponent();
            this.calendar = calendar;
            tempConnect = conn;
            isAddMode = mode;
        }


        // Method       
        public void PastDataSet(string[] timeTemp, string textTemp) {
            originalHM = new decimal[2] { decimal.Parse(timeTemp[0]), decimal.Parse(timeTemp[1]) };

            nUD_t_hour.Value = originalHM[0];
            nUD_t_minute.Value = originalHM[1];
            textBox_today_text.Text = textTemp;
        }

        private bool OverlapCheck(string sql) {
            bool return_bool = true;

            tempConnect.Open();
            command = new SQLiteCommand(sql, tempConnect);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read()) return_bool = false;

            reader.Close();
            tempConnect.Close();
            return return_bool;
        }

        private void QueryActive(string sql) {

            tempConnect.Open();
            command = new SQLiteCommand(sql, tempConnect);
            command.ExecuteNonQuery();
            tempConnect.Close();

            calendar.TodayAlarmListRefresh();
            calendar.RefreshAlarm();
            Close();
        }


        // EVENT.       
        private void Button_today_OK_Click(object sender, EventArgs e) {

            decimal[] time = { nUD_t_hour.Value, nUD_t_minute.Value };
            int length = Encoding.Default.GetBytes(textBox_today_text.Text).Length;

            if (length <= 20 && length > 0) {
                try {
                    string sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.ALARM_MODE, null, time);
                    if (!OverlapCheck(sql)) { MessageBox.Show("Duplicate alarm time."); return; }

                    // add mode
                    if (isAddMode)  sql = new ListSqlQuery().sqlInsertValues(ListSqlQuery.ALARM_MODE, null, time, textBox_today_text.Text, true);
                    else            sql = new ListSqlQuery().sqlUpdateData(ListSqlQuery.ALARM_MODE, null, originalHM, time, textBox_today_text.Text, true);

                    QueryActive(sql);
                }

                catch (Exception exc) {
                    MessageBox.Show("Error : " + exc.Message);
                    if (tempConnect.State.ToString() == "Open") tempConnect.Close();
                }
            }

            else MessageBox.Show("Invalid input.\nPlease select the correct date.");
        }
    }
}
