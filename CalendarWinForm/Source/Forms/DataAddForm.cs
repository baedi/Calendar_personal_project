using System;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace CalendarWinForm
{
    public partial class DataAddForm : Form
    {
        // Instance variable.       
        private readonly CalendarMain calendar;
        private readonly Label date;
        private SQLiteConnection tempConnect;
        private SQLiteCommand command;

        private readonly DateTime startDateTemp;
        private decimal[] dateYMD;
        private decimal[] originalYMD;
        private decimal[] originalHM;


        // Constructor.             
        public DataAddForm(Label date, CalendarMain calendar, SQLiteConnection connect, bool isModifyMode) {
            InitializeComponent();
            this.date = date;
            this.calendar = calendar;
            tempConnect = connect;

            if (!isModifyMode) this.Text = "Add schedule";
            else this.Text = "Modify schedule";

            string[] tempString = date.Text.Split('.');
            originalYMD = dateYMD = new decimal[3] { decimal.Parse(tempString[0]), decimal.Parse(tempString[1]), decimal.Parse(tempString[2]) };

            startDateTemp = new DateTime((int)dateYMD[0], (int)dateYMD[1], (int)dateYMD[2]);
            dateTimePicker_start.Value = new DateTime(startDateTemp.Ticks);
            dateTimePicker_end.Value = new DateTime(startDateTemp.Ticks).AddDays(2);
        }

        // Impliment Method.        
        public void AddMode() {

            decimal[] setDateHM = { numericUpDown_setHour.Value, numericUpDown_setMinute.Value };
            
            // overlap alarm check. 
            string sql_str = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, dateYMD, setDateHM);
            if (!OverlapCheck(sql_str, false)) return;

            // insert data. (normal)        
            if (!checkBox_multiMode.Checked)
            {
                sql_str = new ListSqlQuery().sqlInsertValues(ListSqlQuery.CALENDAR_MODE, dateYMD, setDateHM, textBox_calendarText.Text, checkBox_checkAlarm.Checked);
                QueryActive(sql_str);
            }

            // insert data. (multi)         
            else
            {
                DateTime temp_nextday = new DateTime(startDateTemp.Ticks);
                TimeSpan temp = DateTime.Parse(dateTimePicker_end.Value.ToString("yyyy-MM-dd")) - DateTime.Parse(startDateTemp.ToString("yyyy-MM-dd"));
                int dayTemp = temp.Days;
                bool oncemessage = true;

                if (dayTemp > 0)
                {
                    for (int count = 0; count <= dayTemp; count++, temp_nextday = temp_nextday.AddDays(1))
                    {

                        // DB Check 
                        string[] curDateStr = temp_nextday.ToString("yyyy-MM-dd").Split('-');
                        decimal[] curDate = { decimal.Parse(curDateStr[0]), decimal.Parse(curDateStr[1]), decimal.Parse(curDateStr[2]) };
                        sql_str = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, curDate, setDateHM);

                        tempConnect.Open();
                        command = new SQLiteCommand(sql_str, tempConnect);
                        SQLiteDataReader reader = command.ExecuteReader();

                        // data is already exist. 
                        if (reader.Read())
                        {
                            reader.Close();
                            tempConnect.Close();
                            if (oncemessage) MessageBox.Show("Existing data was maintained due to overlapping schedules.");
                            oncemessage = false;
                        }

                        // data is not already exist. 
                        else
                        {

                            reader.Close();
                            tempConnect.Close();

                            sql_str = new ListSqlQuery().sqlInsertValues(ListSqlQuery.CALENDAR_MODE, curDate, setDateHM, textBox_calendarText.Text, checkBox_checkAlarm.Checked);

                            tempConnect.Open();
                            command = new SQLiteCommand(sql_str, tempConnect);
                            command.ExecuteNonQuery();
                            tempConnect.Close();
                        }
                    }
                    calendar.ChangeCalendar();
                    calendar.CalendarListRefresh();
                    calendar.RefreshAlarm();
                    Close();
                }

                else { MessageBox.Show("Invalid input.\nPlease select the correct date."); return; }
            }
        }

        public void ModifyMode() {
            decimal[] DateHM = { numericUpDown_setHour.Value, numericUpDown_setMinute.Value };
            string sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, dateYMD, DateHM);

            // overlap alarm check. 
            if (!OverlapCheck(sql, true)) return;

            // update data. (normal)        
            if (!checkBox_multiMode.Checked)
            {
                sql = new ListSqlQuery().sqlUpdateData(ListSqlQuery.CALENDAR_MODE, originalYMD, originalHM, dateYMD, DateHM, textBox_calendarText.Text, checkBox_checkAlarm.Checked);
                QueryActive(sql);
            }

            // update data. (multi)         
            else
            {
                DateTime temp_nextday = new DateTime(startDateTemp.Ticks);
                TimeSpan temp = DateTime.Parse(dateTimePicker_end.Value.ToString("yyyy-MM-dd")) - DateTime.Parse(startDateTemp.ToString("yyyy-MM-dd"));
                int dayTemp = temp.Days;

                if (dayTemp > 0)
                {
                    for (int count = 0; count <= dayTemp; count++, temp_nextday = temp_nextday.AddDays(1))
                    {

                        // DB Check
                        string[] curDateStr = temp_nextday.ToString("yyyy-MM-dd").Split('-');
                        decimal[] curDate = { decimal.Parse(curDateStr[0]), decimal.Parse(curDateStr[1]), decimal.Parse(curDateStr[2]) };

                        sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, curDate, originalHM);

                        tempConnect.Open();
                        command = new SQLiteCommand(sql, tempConnect);
                        SQLiteDataReader reader = command.ExecuteReader();

                        // data is already exist. 
                        if (reader.Read())
                        {
                            reader.Close();
                            tempConnect.Close();

                            sql = new ListSqlQuery().sqlUpdateData(ListSqlQuery.CALENDAR_MODE, curDate, originalHM, curDate, DateHM, textBox_calendarText.Text, checkBox_checkAlarm.Checked);

                            tempConnect.Open();
                            command = new SQLiteCommand(sql, tempConnect);
                            command.ExecuteNonQuery();
                            tempConnect.Close();
                        }


                        // data is not already exist. 
                        else { reader.Close(); tempConnect.Close(); }

                    }
                }
                calendar.ChangeCalendar();
                calendar.CalendarListRefresh();
                calendar.RefreshAlarm();
                Close();
            }
        }

        private bool OverlapCheck(string sql, bool modifyMode) {

            tempConnect.Open();
            command = new SQLiteCommand(sql, tempConnect);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (int.Parse(reader["sethour"].ToString()) == numericUpDown_setHour.Value &&
                     int.Parse(reader["setminute"].ToString()) == numericUpDown_setMinute.Value) {

                    if(modifyMode)
                        if (numericUpDown_setHour.Value == originalHM[0] && numericUpDown_setMinute.Value == originalHM[1])
                            continue;

                    MessageBox.Show("Duplicate alarm time.");
                    reader.Close();
                    tempConnect.Close();
                    return false;
                }
            }

            tempConnect.Close();
            return true;
        }

        private void QueryActive(string sql) {

            tempConnect.Open();
            command = new SQLiteCommand(sql, tempConnect);
            command.ExecuteNonQuery();
            tempConnect.Close();


            // select calendar year, month change check 
            string[] selectCalDate = date.Text.Split('.');
            decimal[] selectCalDate2 = new decimal[3] { decimal.Parse(selectCalDate[0]), decimal.Parse(selectCalDate[1]), decimal.Parse(selectCalDate[2]) };

            if (selectCalDate2[0] == dateYMD[0] && selectCalDate2[1] == dateYMD[1]){
                calendar.ChangeCalendar();
                calendar.CalendarListRefresh();
            }

            calendar.RefreshAlarm();
            Close();
        }


        // EVENT Method.            
        private void Button_ok_Click(object sender, EventArgs e) {

            int length;
            length = Encoding.Default.GetBytes(textBox_calendarText.Text).Length;


            if (length <= 20 && length > 0) {
                    if (this.Text.Equals("Add schedule")) AddMode();
                    else if(this.Text.Equals("Modify schedule")) ModifyMode();
            }

            else { MessageBox.Show("Invalid input.\nPlease select the correct date."); }
        }

        private void CheckBox_multiMode_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_multiMode.Checked == false) dateTimePicker_end.Enabled = false;
            else if(checkBox_multiMode.Checked == true) dateTimePicker_end.Enabled = true;
        }


        // get, set Method. 
        public void SetDbConnect(SQLiteConnection conn) { tempConnect = conn; }
        public void SetSelectData(string[] temp, string text, bool act) {
            originalHM = new decimal[2] { decimal.Parse(temp[0]), decimal.Parse(temp[1]) };

            numericUpDown_setHour.Value = originalHM[0];
            numericUpDown_setMinute.Value = originalHM[1];
            textBox_calendarText.Text = text;
            checkBox_checkAlarm.Checked = act;
        }

        private void DateTimePicker_start_ValueChanged(object sender, EventArgs e) {
            string[] tempStr = dateTimePicker_start.Value.ToString("yyyy-MM-dd").Split('-');
            dateYMD = new decimal[3] { decimal.Parse(tempStr[0]), decimal.Parse(tempStr[1]), decimal.Parse(tempStr[2]) };
            dateTimePicker_end.Value = dateTimePicker_start.Value.AddDays(2);
        }

        private void DateTimePicker_end_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker_start.Value >= dateTimePicker_end.Value) {
                dateTimePicker_end.Value = dateTimePicker_start.Value.AddDays(2);
            }
        }
    }
}
