using System;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace CalenderWinForm
{
    public partial class DataAddForm : Form
    {
        // Instance variable.       
        private SQLiteConnection dbConnect;
        private Label date;
        private Form_Calendar_main calendar;
        private bool modifyMode;

        private int original_hour;
        private int original_minute;
        private string original_text;

        // Constructor.             
        public DataAddForm(Label date, Form_Calendar_main calendar, bool mode) {
            InitializeComponent();
            this.date = date;
            this.calendar = calendar;
            modifyMode = mode;

            if (mode) this.Text = "Modify schedule";
            else this.Text = "Add schedule";
        }


        // button Event.            
        private void button_ok_Click(object sender, EventArgs e) {

            int length;
            string sql;

            length = Encoding.Default.GetBytes(textBox_calendarText.Text).Length;


            if (length <= 20 && length > 0) {

                // add schedule mode. 
                if (!modifyMode) {

                    string[] dateStr = new string[3];
                    dateStr = date.Text.Split('.');

                    try {
                        // overlap alarm check. 
                        sql = $"select sethour, setminute from calendarlist where year = {dateStr[0]} AND month = {dateStr[1]} AND day = {dateStr[2]};";
                        if (!overlapCheck(sql)) return;

                        // insert data. 
                        sql = $"insert into calendarlist values ({dateStr[0]}, {dateStr[1]}, {dateStr[2]}, {numericUpDown_setHour.Value}, {numericUpDown_setMinute.Value}, \"{textBox_calendarText.Text}\", {checkBox_checkAlarm.Checked})";
                        inputData(sql);
                    }

                    catch (Exception exc) {
                        MessageBox.Show("Error : " + exc.Message);
                        if (dbConnect.State.ToString() == "Open")
                            dbConnect.Close();
                    }
                }

                // modify schedule mode. 
                else {

                }
            }

            else if (length <= 0) { MessageBox.Show("You didn't enter anything!");}
            else { MessageBox.Show("Character size must be no larger than 20."); }
        }


        // overlap alarm check Method. 
        private bool overlapCheck(string sql) {
            SQLiteCommand command;

            dbConnect.Open();
            command = new SQLiteCommand(sql, dbConnect);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (int.Parse(reader["sethour"].ToString()) == numericUpDown_setHour.Value &&
                     int.Parse(reader["setminute"].ToString()) == numericUpDown_setMinute.Value)
                {
                    MessageBox.Show("Duplicate alarm time.");
                    reader.Close();
                    dbConnect.Close();
                    return false;
                }
            }

            dbConnect.Close();
            return true;
        }


        // insert data Method. 
        private void inputData(string sql) {
            SQLiteCommand command;

            dbConnect.Open();
            command = new SQLiteCommand(sql, dbConnect);
            command.ExecuteNonQuery();
            dbConnect.Close();
            calendar.changeCalendar();
            calendar.calendarListRefresh();
            Close();
        }


        // get, set Method. 
        public void setDbConnect(SQLiteConnection conn) { dbConnect = conn; }
        public void setSelectData(string[] temp, string text, bool act) {
            original_hour = int.Parse(temp[0]);
            original_minute = int.Parse(temp[1]);
            original_text = text;

            //MessageBox.Show(original_hour.ToString() + " " + original_minute.ToString() + " " + original_text.ToString());
            numericUpDown_setHour.Value = original_hour;
            numericUpDown_setMinute.Value = original_minute;
            textBox_calendarText.Text = original_text;
            checkBox_checkAlarm.Checked = act;
        }
    }
}
