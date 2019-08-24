using System;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace CalendarWinForm
{
    public partial class DataAddForm : Form
    {
        // Instance variable.       
        private SQLiteConnection dbConnect;
        private Label date;
        private Form_Calendar_main calendar;
        private bool modifyMode;
        private string[] dateStr;

        private int original_hour;
        private int original_minute;
        private string original_text;

        private ListBox selectBox;

        // Constructor.             
        public DataAddForm(Label date, Form_Calendar_main calendar, bool mode) {
            InitializeComponent();
            this.date = date;
            this.calendar = calendar;
            modifyMode = mode;

            if (mode) this.Text = "Modify schedule";
            else this.Text = "Add schedule";

            dateStrSetting();

            //DateTime startDateTemp = new DateTime();
            DateTime endDateTemp = new DateTime();

            //startDateTemp = startDateTemp.AddYears(int.Parse(dateStr[0]) - 1).AddMonths(int.Parse(dateStr[1]) - 1).AddDays(int.Parse(dateStr[2]) - 1);
            endDateTemp = endDateTemp.AddYears(int.Parse(dateStr[0]) - 1).AddMonths(int.Parse(dateStr[1]) - 1).AddDays(int.Parse(dateStr[2]) + 50);

            dateTimePicker_end.Value = endDateTemp;
            groupBox_curdatecheck.Text = dateStr[0] + "." + dateStr[1] + "." + dateStr[2];

            //TimeSpan temp = DateTime.Parse(endDateTemp.ToString("yyyy-MM-dd")) - DateTime.Parse(startDateTemp.ToString("yyyy-MM-dd"));
            //int day_temp = temp.Days;
        }

        // Setting Method            
        public void gboxSetting(ListBox selectBox) { this.selectBox = selectBox; }
        public void dateStrSetting() { dateStr = new string[3]; dateStr = date.Text.Split('.'); }


        // button Event.            
        private void button_ok_Click(object sender, EventArgs e) {

            int length;
            string sql;

            length = Encoding.Default.GetBytes(textBox_calendarText.Text).Length;


            if (length <= 20 && length > 0) {
                try {

                    sql = $"select sethour, setminute from calendarlist where year = {dateStr[0]} AND month = {dateStr[1]} AND day = {dateStr[2]};";

                    // add schedule mode.
                    if (!modifyMode) {

                        // overlap alarm check. 
                        if (!overlapCheck(sql, false)) return;

                        // insert data.
                        sql = $"insert into calendarlist values " +
                              $"({dateStr[0]}, {dateStr[1]}, {dateStr[2]}, " +
                              $"{numericUpDown_setHour.Value}, {numericUpDown_setMinute.Value}, \"{textBox_calendarText.Text}\", {checkBox_checkAlarm.Checked})";

                        queryActive(sql);
                    }


                    // modify schedule mode. (normal)
                    else {

                        // overlap alarm check. 
                        if (!overlapCheck(sql, true)) return;

                        // update data. 
                        sql = "update calendarlist set (sethour, setminute, text, active) = " + 
                            $"({numericUpDown_setHour.Value},{numericUpDown_setMinute.Value},'{textBox_calendarText.Text}',{checkBox_checkAlarm.Checked}) " +
                            $"where year = {dateStr[0]} AND month = {dateStr[1]} AND day = {dateStr[2]} AND sethour = {original_hour} AND setminute = {original_minute}";
                        
                        queryActive(sql);
                    }
                }
                catch (Exception exc) {
                    MessageBox.Show("Error : " + exc.Message);
                    if (dbConnect.State.ToString() == "Open")
                        dbConnect.Close();
                }
            }

            else if (length <= 0) { MessageBox.Show("You didn't enter anything!");}
            else { MessageBox.Show("Character size must be no larger than 20."); }
        }


        // multi range check Event. 
        private void checkBox_multiMode_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_multiMode.Checked == false) dateTimePicker_end.Enabled = false;
            else if(checkBox_multiMode.Checked == true) dateTimePicker_end.Enabled = true;
        }



        // overlap alarm check Method. 
        private bool overlapCheck(string sql, bool modifyMode) {
            SQLiteCommand command;

            dbConnect.Open();
            command = new SQLiteCommand(sql, dbConnect);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (int.Parse(reader["sethour"].ToString()) == numericUpDown_setHour.Value &&
                     int.Parse(reader["setminute"].ToString()) == numericUpDown_setMinute.Value) {

                    if (numericUpDown_setHour.Value == original_hour && numericUpDown_setMinute.Value == original_minute && modifyMode)
                        continue;

                    MessageBox.Show("Duplicate alarm time.");
                    reader.Close();
                    dbConnect.Close();
                    return false;
                }
            }

            dbConnect.Close();
            return true;
        }


        // insert, modify data Method. 
        private void queryActive(string sql) {
            SQLiteCommand command;

            dbConnect.Open();
            command = new SQLiteCommand(sql, dbConnect);
            command.ExecuteNonQuery();
            dbConnect.Close();


            // select calendar year, month change check 
            int y_temp = int.Parse(dateStr[0]);
            int m_temp = int.Parse(dateStr[1]);
            dateStrSetting();

            if (y_temp == int.Parse(dateStr[0]) && m_temp == int.Parse(dateStr[1])){
                calendar.selectBoxDataRefresh(selectBox, dateStr);
                calendar.calendarListRefresh();
            }

            else calendar.changeCalendar();

            calendar.refreshAlarm();
            Close();
        }


        // get, set Method. 
        public void setDbConnect(SQLiteConnection conn) { dbConnect = conn; }
        public void setSelectData(string[] temp, string text, bool act) {
            original_hour = int.Parse(temp[0]);
            original_minute = int.Parse(temp[1]);
            original_text = text;

            numericUpDown_setHour.Value = original_hour;
            numericUpDown_setMinute.Value = original_minute;
            textBox_calendarText.Text = original_text;
            checkBox_checkAlarm.Checked = act;
        }


    }
}
