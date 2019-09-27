using System;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace CalendarWinForm {
    public partial class TodayDataAddForm : Form {

        // Instance var.    
        private SQLiteConnection dbConnect;
        private CalendarMain calendar;

        // Constructor. 
        public TodayDataAddForm(CalendarMain calendar)  {
            InitializeComponent();

            this.calendar = calendar;

        }


        // EVENT.       
        private void Button_today_OK_Click(object sender, EventArgs e) {
            int length;
            string sql;

            length = Encoding.Default.GetBytes(textBox_today_text.Text).Length;

            if(!(length <= 20 && length > 0)) {
                MessageBox.Show("Invalid input.\nPlease select the correct date.");
                return;
            }

            try {

                sql = QueryList.overlapCheckSQL_Today(nUD_t_hour.Value, nUD_t_minute.Value);
                if (!overlapCheck(sql)) { MessageBox.Show("Duplicate alarm time."); return; }

                // insert
                sql = QueryList.insertSQL_today(nUD_t_hour.Value, nUD_t_minute.Value, textBox_today_text.Text);
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
