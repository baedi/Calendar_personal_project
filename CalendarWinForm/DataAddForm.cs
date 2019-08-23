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

            dateStr = new string[3];
            dateStr = date.Text.Split('.');
        }

        // gbox Setting. 
        public void gboxSetting(ListBox selectBox) { this.selectBox = selectBox; }


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


                    // modify schedule mode. 
                    else {

                        // overlap alarm check. 
                        if (!overlapCheck(sql, true)) return;

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

            calendar.selectBoxDataRefresh(selectBox, dateStr);
            calendar.calendarListRefresh();
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
