using System;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CalendarWinForm {
    public partial class TodayDataAddForm : Form {

        // Instance var.    
        private SQLiteConnection dbConnect;
        private CalendarMain calendar;
        private bool isAddMode;
        private decimal[] pastHM;


        // Constructor. 
        public TodayDataAddForm(CalendarMain calendar, bool mode)  {
            InitializeComponent();

            this.calendar = calendar;
            isAddMode = mode;
        }

        public void pastDataSet(string[] timeTemp, string textTemp) {
            pastHM = new decimal[2];
            pastHM[0] = decimal.Parse(timeTemp[0]);
            pastHM[1] = decimal.Parse(timeTemp[1]);

            nUD_t_hour.Value = pastHM[0];
            nUD_t_minute.Value = pastHM[1];
            textBox_today_text.Text = textTemp;
        }


        // EVENT.       
        private void Button_today_OK_Click(object sender, EventArgs e) {
            int length;
            string sql;
            decimal[] time = { nUD_t_hour.Value, nUD_t_minute.Value };

            length = Encoding.Default.GetBytes(textBox_today_text.Text).Length;

            if(!(length <= 20 && length > 0)) {
                MessageBox.Show("Invalid input.\nPlease select the correct date.");
                return;
            }

            try {
                sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.ALARM_MODE, null, time);
                if (!overlapCheck(sql)) { MessageBox.Show("Duplicate alarm time."); return; }

                // add mode
                if (isAddMode)  sql = new ListSqlQuery().sqlInsertValues(ListSqlQuery.ALARM_MODE, null, time, textBox_today_text.Text, true);
                else            sql = new ListSqlQuery().sqlUpdateData(ListSqlQuery.ALARM_MODE, null, pastHM, time, textBox_today_text.Text, true);

                queryActive(sql);
            } catch(Exception exc) {
                MessageBox.Show("Error : " + exc.Message);
                if (dbConnect.State.ToString() == "Open") dbConnect.Close();
            }

        }


        // Method.      
        public void setDbConnect(SQLiteConnection conn) { dbConnect = conn; }

        private bool overlapCheck(string sql) {
            SQLiteCommand command;
            bool return_bool = true;

            dbConnect.Open();
            command = new SQLiteCommand(sql, dbConnect);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read()) return_bool = false;

            reader.Close();
            dbConnect.Close();
            return return_bool;
        }

        private void queryActive(string sql) {
            SQLiteCommand command;

            dbConnect.Open();
            command = new SQLiteCommand(sql, dbConnect);
            command.ExecuteNonQuery();
            dbConnect.Close();

            calendar.todayAlarmListRefresh();
            calendar.refreshAlarm();
            Close();
        }
    }
}
