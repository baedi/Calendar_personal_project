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

            dateSetting();

            startDateTemp = new DateTime();
            endDateTemp = new DateTime();

            startDateTemp = startDateTemp.AddYears((int)setDateYMD[0] - 1).AddMonths((int)setDateYMD[1] - 1).AddDays((int)setDateYMD[2] - 1);
            endDateTemp = endDateTemp.AddYears((int)setDateYMD[0] - 1).AddMonths((int)setDateYMD[1] - 1).AddDays((int)setDateYMD[2] + 2);

            dateTimePicker_end.Value = endDateTemp;
            groupBox_curdatecheck.Text = setDateYMD[0] + "." + setDateYMD[1] + "." + setDateYMD[2];

            //TimeSpan temp = DateTime.Parse(endDateTemp.ToString("yyyy-MM-dd")) - DateTime.Parse(startDateTemp.ToString("yyyy-MM-dd"));
            //int day_temp = temp.Days;
        }

        // Setting Method            
        public void gboxSetting(ListBox selectBox) { this.selectBox = selectBox; }

        public void dateSetting() {
            setDateYMD = new decimal[3];
            string[] tempString = new string[3]; tempString = date.Text.Split('.');

            for (int count = 0; count < tempString.Length; count++)
                setDateYMD[count] = decimal.Parse(tempString[count]);
        }


        // button Event.            
        private void Button_ok_Click(object sender, EventArgs e) {

            int length;
            string sql;
            decimal[] setDateHM = { numericUpDown_setHour.Value, numericUpDown_setMinute.Value };

            length = Encoding.Default.GetBytes(textBox_calendarText.Text).Length;


            if (length <= 20 && length > 0) {
                try {

                    sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, setDateYMD, setDateHM);

                    // add schedule mode.
                    if (!modifyMode) {

                        // overlap alarm check. 
                        if (!overlapCheck(sql, false)) return;

                        // insert data. (normal)        
                        if (!checkBox_multiMode.Checked) {
                            sql = new ListSqlQuery().sqlInsertValues(ListSqlQuery.CALENDAR_MODE, setDateYMD, setDateHM, textBox_calendarText.Text, checkBox_checkAlarm.Checked);
                            queryActive(sql);
                        }

                        // insert data. (multi)         
                        else {
                            DateTime temp_nextday = new DateTime(startDateTemp.Ticks);
                            TimeSpan temp = DateTime.Parse(dateTimePicker_end.Value.ToString("yyyy-MM-dd")) - DateTime.Parse(startDateTemp.ToString("yyyy-MM-dd"));
                            int dayTemp = temp.Days;
                            bool oncemessage = true;

                            if(dayTemp > 0) {
                                for(int count = 0; count <= dayTemp; count++, temp_nextday = temp_nextday.AddDays(1)) {

                                    // DB Check 
                                    string[] curDateStr = temp_nextday.ToString("yyyy-MM-dd").Split('-');
                                    decimal[] curDate = { decimal.Parse(curDateStr[0]), decimal.Parse(curDateStr[1]), decimal.Parse(curDateStr[2]) };
                                    sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, curDate, setDateHM);

                                    dbConnect.Open();
                                    SQLiteCommand command = new SQLiteCommand(sql, dbConnect);
                                    SQLiteDataReader reader = command.ExecuteReader();

                                    // data is already exist. 
                                    if (reader.Read()) {
                                        reader.Close();
                                        dbConnect.Close();
                                        if(oncemessage) MessageBox.Show("Existing data was maintained due to overlapping schedules.");
                                        oncemessage = false;
                                    }

                                    // data is not already exist. 
                                    else {
                                        
                                        reader.Close();
                                        dbConnect.Close();
                                        
                                        sql = new ListSqlQuery().sqlInsertValues(ListSqlQuery.CALENDAR_MODE, curDate, setDateHM, textBox_calendarText.Text, checkBox_checkAlarm.Checked);

                                        dbConnect.Open();
                                        command = new SQLiteCommand(sql, dbConnect);
                                        command.ExecuteNonQuery();
                                        dbConnect.Close();
                                    }
                                }
                                calendar.changeCalendar();
                                calendar.calendarListRefresh();
                                calendar.refreshAlarm();
                                Close();
                                return;
                            }

                            else { MessageBox.Show("Invalid input.\nPlease select the correct date."); return; }
                        }
                    }


                    // modify schedule mode. (normal)   
                    else {

                        // overlap alarm check. 
                        if (!overlapCheck(sql, true)) return;

                        // update data. (normal)        
                        if (!checkBox_multiMode.Checked) {
                            sql = new ListSqlQuery().sqlUpdateData(ListSqlQuery.CALENDAR_MODE, setDateYMD, originalHM, setDateHM, textBox_calendarText.Text, checkBox_checkAlarm.Checked);
                            queryActive(sql);
                        }

                        // update data. (multi)         
                        else {
                            DateTime temp_nextday = new DateTime(startDateTemp.Ticks);
                            TimeSpan temp = DateTime.Parse(dateTimePicker_end.Value.ToString("yyyy-MM-dd")) - DateTime.Parse(startDateTemp.ToString("yyyy-MM-dd"));
                            int dayTemp = temp.Days;

                            if(dayTemp > 0) {
                                for(int count = 0; count <= dayTemp; count++, temp_nextday = temp_nextday.AddDays(1)) {

                                    // DB Check
                                    string[] curDateStr = temp_nextday.ToString("yyyy-MM-dd").Split('-');
                                    decimal[] curDate = { decimal.Parse(curDateStr[0]), decimal.Parse(curDateStr[1]), decimal.Parse(curDateStr[2]) };

                                    sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, curDate, originalHM);

                                    dbConnect.Open();
                                    SQLiteCommand command = new SQLiteCommand(sql, dbConnect);
                                    SQLiteDataReader reader = command.ExecuteReader();

                                    // data is already exist. 
                                    if (reader.Read()) {
                                        reader.Close();
                                        dbConnect.Close();

                                        sql = new ListSqlQuery().sqlUpdateData(ListSqlQuery.CALENDAR_MODE, curDate, originalHM, setDateHM, textBox_calendarText.Text, checkBox_checkAlarm.Checked);

                                        dbConnect.Open();
                                        command = new SQLiteCommand(sql, dbConnect);
                                        command.ExecuteNonQuery();
                                        dbConnect.Close();
                                    }


                                    // data is not already exist. 
                                    else { reader.Close(); dbConnect.Close();}

                                }
                            }
                            calendar.changeCalendar();
                            calendar.calendarListRefresh();
                            calendar.refreshAlarm();
                            Close();
                            return;
                        }


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
        private void queryActive(string sql) {
            SQLiteCommand command;

            dbConnect.Open();
            command = new SQLiteCommand(sql, dbConnect);
            command.ExecuteNonQuery();
            dbConnect.Close();


            // select calendar year, month change check 
            decimal y_temp = setDateYMD[0];
            decimal m_temp = setDateYMD[1];
            dateSetting();

            if (y_temp == setDateYMD[0] && m_temp == setDateYMD[1]){
                calendar.selectBoxDataRefresh(selectBox, setDateYMD);
                calendar.calendarListRefresh();
            }

            else calendar.changeCalendar();

            calendar.refreshAlarm();
            Close();
        }


        // get, set Method. 
        public void setDbConnect(SQLiteConnection conn) { dbConnect = conn; }
        public void setSelectData(string[] temp, string text, bool act) {
            originalHM = new decimal[2];
            originalHM[0] = decimal.Parse(temp[0]);
            originalHM[1] = decimal.Parse(temp[1]);
            original_text = text;

            numericUpDown_setHour.Value = originalHM[0];
            numericUpDown_setMinute.Value = originalHM[1];
            textBox_calendarText.Text = original_text;
            checkBox_checkAlarm.Checked = act;
        }


    }
}
