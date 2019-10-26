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
        private readonly Label date;
        private readonly CalendarMain calendar;
        private readonly bool modifyMode;

        private decimal[] setDateYMD;       
        private decimal[] originalHM;
        private string original_text;

        private ListBox selectBox;
        private readonly DateTime startDateTemp;
        private readonly DateTime endDateTemp;

        // Constructor.             
        public DataAddForm(Label date, CalendarMain calendar, bool mode) {
            InitializeComponent();
            this.date = date;
            this.calendar = calendar;
            modifyMode = mode;

            if (mode) this.Text = "Modify schedule";
            else this.Text = "Add schedule";

            string[] tempString = date.Text.Split('.');
            setDateYMD = new decimal[3] { decimal.Parse(tempString[0]), decimal.Parse(tempString[1]), decimal.Parse(tempString[2]) };

            startDateTemp = new DateTime();
            endDateTemp = new DateTime();

            startDateTemp = startDateTemp.AddYears((int)setDateYMD[0] - 1).AddMonths((int)setDateYMD[1] - 1).AddDays((int)setDateYMD[2] - 1);
            endDateTemp = endDateTemp.AddYears((int)setDateYMD[0] - 1).AddMonths((int)setDateYMD[1] - 1).AddDays((int)setDateYMD[2] + 2);

            dateTimePicker_end.Value = endDateTemp;
            groupBox_curdatecheck.Text = setDateYMD[0] + "." + setDateYMD[1] + "." + setDateYMD[2];
        }

        // Setting Method            
        public void GboxSetting(ListBox selectBox) { this.selectBox = selectBox; }


        // button Event.            
        private void Button_ok_Click(object sender, EventArgs e) {

            int length;
            length = Encoding.Default.GetBytes(textBox_calendarText.Text).Length;


            if (length <= 20 && length > 0) {
                    if (!modifyMode) AddMode();
                    else ModifyMode();
            }
            
            else if (length <= 0) { MessageBox.Show("You didn't enter anything!");}
            else { MessageBox.Show("Character size must be no larger than 20."); }
        }


        public void AddMode() {
            decimal[] setDateHM = { numericUpDown_setHour.Value, numericUpDown_setMinute.Value };
            string sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, setDateYMD, setDateHM);

            // overlap alarm check. 
            if (!OverlapCheck(sql, false)) return;

            // insert data. (normal)        
            if (!checkBox_multiMode.Checked)
            {
                sql = new ListSqlQuery().sqlInsertValues(ListSqlQuery.CALENDAR_MODE, setDateYMD, setDateHM, textBox_calendarText.Text, checkBox_checkAlarm.Checked);
                QueryActive(sql);
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
                        sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, curDate, setDateHM);

                        dbConnect.Open();
                        SQLiteCommand command = new SQLiteCommand(sql, dbConnect);
                        SQLiteDataReader reader = command.ExecuteReader();

                        // data is already exist. 
                        if (reader.Read())
                        {
                            reader.Close();
                            dbConnect.Close();
                            if (oncemessage) MessageBox.Show("Existing data was maintained due to overlapping schedules.");
                            oncemessage = false;
                        }

                        // data is not already exist. 
                        else
                        {

                            reader.Close();
                            dbConnect.Close();

                            sql = new ListSqlQuery().sqlInsertValues(ListSqlQuery.CALENDAR_MODE, curDate, setDateHM, textBox_calendarText.Text, checkBox_checkAlarm.Checked);

                            dbConnect.Open();
                            command = new SQLiteCommand(sql, dbConnect);
                            command.ExecuteNonQuery();
                            dbConnect.Close();
                        }
                    }
                    calendar.ChangeCalendar();
                    calendar.CalendarListRefresh();
                    calendar.RefreshAlarm();
                    Close();
                    return;
                }

                else { MessageBox.Show("Invalid input.\nPlease select the correct date."); return; }
            }
        }


        public void ModifyMode() {
            decimal[] setDateHM = { numericUpDown_setHour.Value, numericUpDown_setMinute.Value };
            string sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, setDateYMD, setDateHM);

            // overlap alarm check. 
            if (!OverlapCheck(sql, true)) return;

            // update data. (normal)        
            if (!checkBox_multiMode.Checked)
            {
                sql = new ListSqlQuery().sqlUpdateData(ListSqlQuery.CALENDAR_MODE, setDateYMD, originalHM, setDateHM, textBox_calendarText.Text, checkBox_checkAlarm.Checked);
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

                        dbConnect.Open();
                        SQLiteCommand command = new SQLiteCommand(sql, dbConnect);
                        SQLiteDataReader reader = command.ExecuteReader();

                        // data is already exist. 
                        if (reader.Read())
                        {
                            reader.Close();
                            dbConnect.Close();

                            sql = new ListSqlQuery().sqlUpdateData(ListSqlQuery.CALENDAR_MODE, curDate, originalHM, setDateHM, textBox_calendarText.Text, checkBox_checkAlarm.Checked);

                            dbConnect.Open();
                            command = new SQLiteCommand(sql, dbConnect);
                            command.ExecuteNonQuery();
                            dbConnect.Close();
                        }


                        // data is not already exist. 
                        else { reader.Close(); dbConnect.Close(); }

                    }
                }
                calendar.ChangeCalendar();
                calendar.CalendarListRefresh();
                calendar.RefreshAlarm();
                Close();
                return;
            }


        }


        // multi range check Event. 
        private void CheckBox_multiMode_CheckedChanged(object sender, EventArgs e) {
            if (checkBox_multiMode.Checked == false) dateTimePicker_end.Enabled = false;
            else if(checkBox_multiMode.Checked == true) dateTimePicker_end.Enabled = true;
        }



        // overlap alarm check Method. 
        private bool OverlapCheck(string sql, bool modifyMode) {
            SQLiteCommand command;

            dbConnect.Open();
            command = new SQLiteCommand(sql, dbConnect);
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
                    dbConnect.Close();
                    return false;
                }
            }

            dbConnect.Close();
            return true;
        }


        // insert, modify data Method. 
        private void QueryActive(string sql) {
            SQLiteCommand command;

            dbConnect.Open();
            command = new SQLiteCommand(sql, dbConnect);
            command.ExecuteNonQuery();
            dbConnect.Close();


            // select calendar year, month change check 
            decimal y_temp = setDateYMD[0];
            decimal m_temp = setDateYMD[1];

            string[] tempString = date.Text.Split('.');
            setDateYMD = new decimal[3] { decimal.Parse(tempString[0]), decimal.Parse(tempString[1]), decimal.Parse(tempString[2]) };

            if (y_temp == setDateYMD[0] && m_temp == setDateYMD[1]){
                calendar.SelectBoxDataRefresh(selectBox, setDateYMD);
                calendar.CalendarListRefresh();
            }

            else calendar.ChangeCalendar();

            calendar.RefreshAlarm();
            Close();
        }


        // get, set Method. 
        public void setDbConnect(SQLiteConnection conn) { dbConnect = conn; }
        public void SetSelectData(string[] temp, string text, bool act) {
            originalHM = new decimal[2] { decimal.Parse(temp[0]), decimal.Parse(temp[1]) };
            original_text = text;

            numericUpDown_setHour.Value = originalHM[0];
            numericUpDown_setMinute.Value = originalHM[1];
            textBox_calendarText.Text = original_text;
            checkBox_checkAlarm.Checked = act;
        }


    }
}
