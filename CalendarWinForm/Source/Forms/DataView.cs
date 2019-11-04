using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Text;

namespace CalendarWinForm
{
    public partial class DataView : Form
    {
        // instance variable.       
        private readonly CalendarMain calendar;
        private  SQLiteConnection tempConnect;
        private readonly decimal[] originalHM;

        private DateTime past_day;
        private SQLiteCommand command;


        // Constructor. 
        public DataView(CalendarMain calendar, SQLiteConnection connect) {
            InitializeComponent();
            originalHM = new decimal[2];
            this.calendar = calendar;
            tempConnect = connect;
            RefreshData();
        }


        // Implinent Method.        
        public void AddMode(bool multiMod){

            string[] tempDate = (this.dateTimePicker_start.Value.ToString("yyyy-M-d")).Split('-');
            DataManage setData = new DataManage(decimal.Parse(tempDate[0]), decimal.Parse(tempDate[1]), decimal.Parse(tempDate[2]), 
                numericUpDown_hour.Value, numericUpDown_minute.Value, textBox_text.Text, checkBox_alarm.Checked);

            // duplicate check.     
            string sql_str = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, setData.YearMonthDay, setData.HourMinute);

            tempConnect.Open();
            command = new SQLiteCommand(sql_str, tempConnect);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read()) {
                MessageBox.Show("Duplicate alarm time.");
                reader.Close(); tempConnect.Close(); return;
            }

            reader.Close(); tempConnect.Close();


            /* normal mode */
            if (multiMod == false) {

                // input data.          
                sql_str = new ListSqlQuery().sqlInsertValues(ListSqlQuery.CALENDAR_MODE, setData.YearMonthDay, setData.HourMinute, setData.Text, setData.Active);
                QueryActive(sql_str);

            }


            /* multi mode */
            else {
                DateTime temp_nextday = new DateTime(dateTimePicker_start.Value.Ticks);
                TimeSpan temp = DateTime.Parse(dateTimePicker_end.Value.ToString("yyyy-M-d")) - DateTime.Parse(dateTimePicker_start.Value.ToString("yyyy-M-d"));
                int dayTemp = temp.Days;
                bool oncemessage = true;

                // input data (multi).          
                for (int count = 0; count <= dayTemp; count++, temp_nextday = temp_nextday.AddDays(1)) {
                    tempDate = temp_nextday.ToString("yyyy-M-d").Split('-');

                    setData.YearMonthDay = new decimal[] { decimal.Parse(tempDate[0]), decimal.Parse(tempDate[1]), decimal.Parse(tempDate[2]) };
                    sql_str = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, setData.YearMonthDay, setData.HourMinute);

                    tempConnect.Open();
                    command = new SQLiteCommand(sql_str, tempConnect);
                    reader = command.ExecuteReader();


                    // data is already exist.      
                    if (reader.Read()) {
                        reader.Close(); tempConnect.Close();
                        if (oncemessage) { MessageBox.Show("Existing data was maintained due to overlapping schedules."); oncemessage = false; }
                    }

                    // data is not already exist.  
                    else {
                        reader.Close(); tempConnect.Close();
                        sql_str = new ListSqlQuery().sqlInsertValues(ListSqlQuery.CALENDAR_MODE, setData.YearMonthDay, setData.HourMinute, textBox_text.Text, checkBox_alarm.Checked);
                        QueryActive(sql_str);
                    }

                }

            }

            // refresh data 
            RefreshData();
            RefreshCalendar();

        }

        public void ModifyMode(){

            string sql;
            string[] date = past_day.ToString("yyyy-M-d").Split('-');
            decimal[] pastDateYMD = { decimal.Parse(date[0]), decimal.Parse(date[1]), decimal.Parse(date[2]) };
            decimal[] setTimeHM = { numericUpDown_hour.Value, numericUpDown_minute.Value };

            sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, pastDateYMD, originalHM);

            tempConnect.Open();
            command = new SQLiteCommand(sql, tempConnect);
            SQLiteDataReader reader = command.ExecuteReader();

            bool isRead = reader.Read();
            reader.Close(); tempConnect.Close();

            if (!isRead) { MessageBox.Show("Can't Find past data."); return; }


            // single alarm mode. 
            if(checkBox_isMulti.Checked == false) {
                sql = new ListSqlQuery().sqlUpdateData(ListSqlQuery.CALENDAR_MODE, pastDateYMD, originalHM, setTimeHM, textBox_text.Text, checkBox_alarm.Checked);
                QueryActive(sql);

            }

            // multi alarm mode. 
            else {
                DateTime temp_checkDay = new DateTime(dateTimePicker_start.Value.Ticks);
                int dayCount = (DateTime.Parse(dateTimePicker_end.Value.ToString("yyyy-M-d")) - DateTime.Parse(dateTimePicker_start.Value.ToString("yyyy-M-d"))).Days;

                for(int count = 0; count <= dayCount; count++, temp_checkDay = temp_checkDay.AddDays(1)) {
                    date = temp_checkDay.ToString("yyyy-M-d").Split('-');
                    pastDateYMD[0] = decimal.Parse(date[0]);
                    pastDateYMD[1] = decimal.Parse(date[1]);
                    pastDateYMD[2] = decimal.Parse(date[2]);

                    sql = new ListSqlQuery().sqlUpdateData(ListSqlQuery.CALENDAR_MODE, pastDateYMD, originalHM, setTimeHM, textBox_text.Text, checkBox_alarm.Checked);

                    QueryActive(sql);
                }
            }

            // refresh data 
            RefreshData();
            RefreshCalendar();
        }

        private bool OverlapCheck(string sql, bool modifyMode)
        {

            return true;
        }

        private void QueryActive(string sql)
        {
            tempConnect.Open();
            command = new SQLiteCommand(sql, tempConnect);
            command.ExecuteNonQuery();
            tempConnect.Close();
        }

        public void DataSettings(){
            for (int count = 0; count < listView_allDatalist.Items.Count; count++)
                if (listView_allDatalist.Items[count].Selected){

                    string[] sp = listView_allDatalist.Items[count].SubItems[1].Text.Split(':');

                    label_targetDate.Text = listView_allDatalist.Items[count].Text;

                    past_day = dateTimePicker_start.Value = DateTime.Parse(label_targetDate.Text);
                    originalHM[0] = numericUpDown_hour.Value = decimal.Parse(sp[0]);
                    originalHM[1] = numericUpDown_minute.Value = decimal.Parse(sp[1]);
                    textBox_text.Text = listView_allDatalist.Items[count].SubItems[2].Text;
                    checkBox_alarm.Checked = ((listView_allDatalist.Items[count].SubItems[3].Text) == "O" ? true : false);
                    break;
                }
        }

        public void RefreshData() {
            listView_allDatalist.Items.Clear();
            groupBox_mode.Text = "Unselected";

            tempConnect.Open();
            command = new SQLiteCommand(new ListSqlQuery().sqlAllCalendarData(), tempConnect);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                bool active = (bool)reader["active"];
                string[] items = new string[] {
                reader["year"] + "-" + reader["month"] + "-" + reader["day"],
                reader["sethour"] + ":" + reader["setminute"],
                reader["text"].ToString(),
                active ? "O" : "X"
                };

                listView_allDatalist.Items.Add(new ListViewItem(items));
            }

            reader.Close(); tempConnect.Close();

            button_modify.Enabled = false;
            button_delete.Enabled = false;
            ButtonClickDisableChanged();
        }

        public void RefreshCalendar() {
            calendar.ChangeCalendar();
            calendar.CalendarListRefresh();
            calendar.RefreshAlarm();
        }


        // EVENT Method.            
        private void Button_refresh_Click(object sender, EventArgs e){ RefreshData(); }
        private void Button_add_Click(object sender, EventArgs e) { ButtonClickEnableChanged(); groupBox_mode.Text = "Add mode"; }
        private void Button_modify_Click(object sender, EventArgs e) { ButtonClickEnableChanged(); DataSettings(); groupBox_mode.Text = "Modify mode"; }
        private void Button_delete_Click(object sender, EventArgs e) { DeleteMessage(); }
        private void DataView_Load(object sender, EventArgs e) { RefreshData(); }

        private void CheckBox_isMulti_CheckedChanged(object sender, EventArgs e) {
            if (this.checkBox_isMulti.Checked == true)  this.dateTimePicker_end.Enabled = true;
            else this.dateTimePicker_end.Enabled = false;
            
        }

        private void ListView_allDatalist_SelectedIndexChanged(object sender, EventArgs e) {
            button_modify.Enabled = true;
            button_delete.Enabled = true;
        }

        private void Button_done_Click(object sender, EventArgs e)
        {
            int length;

            length = Encoding.Default.GetBytes(textBox_text.Text).Length;

            if (length <= 20 && length > 0) {
                if (groupBox_mode.Text.Equals("Add mode")) AddMode(this.checkBox_isMulti.Checked);
                else if (groupBox_mode.Text.Equals("Modify mode")) ModifyMode();
            }

            else { MessageBox.Show("Invalid input.\nPlease select the correct date."); }
        }

        private void DateTimePicker_start_ValueChanged(object sender, EventArgs e) {
            this.dateTimePicker_end.Value = this.dateTimePicker_start.Value.AddDays(2);
        }

        private void DateTimePicker_end_ValueChanged(object sender, EventArgs e) {
            if(this.dateTimePicker_start.Value >= this.dateTimePicker_end.Value) {
                this.dateTimePicker_end.Value = this.dateTimePicker_start.Value.AddDays(2);
            }
        }

        private void ButtonClickEnableChanged() {
            this.checkBox_isMulti.Enabled = true;
            this.numericUpDown_hour.Enabled = true;
            this.numericUpDown_minute.Enabled = true;
            this.textBox_text.Enabled = true;
            this.checkBox_alarm.Enabled = true;
            this.button_done.Enabled = true;
            this.dateTimePicker_start.Enabled = true;
            this.label_targetDate.Text = "-";
        }

        private void ButtonClickDisableChanged() {
            this.checkBox_isMulti.Enabled = false;      this.checkBox_isMulti.Checked = false;
            this.numericUpDown_hour.Enabled = false;    this.numericUpDown_hour.Value = 0;
            this.numericUpDown_minute.Enabled = false;  this.numericUpDown_minute.Value = 0;
            this.textBox_text.Enabled = false;          this.textBox_text.Text = "";
            this.checkBox_alarm.Enabled = false;        this.checkBox_alarm.Checked = true;
            this.button_done.Enabled = false;
            this.dateTimePicker_start.Enabled = false;
            this.dateTimePicker_start.Value = DateTime.Now;
            this.dateTimePicker_end.Value = DateTime.Now.AddDays(2);
            this.label_targetDate.Text = "-";
        }

        private void DeleteMessage() {
            if (MessageBox.Show($"Are you sure you want to delete the data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                for(int count = listView_allDatalist.Items.Count - 1; count >= 0; count = count - 1) {
                    if (listView_allDatalist.Items[count].Selected == true) {

                        string[] date_temp = listView_allDatalist.Items[count].Text.ToString().Split('-');
                        string[] alarm_temp = listView_allDatalist.Items[count].SubItems[1].Text.ToString().Split(':');
                        decimal[] date = { decimal.Parse(date_temp[0]), decimal.Parse(date_temp[1]), decimal.Parse(date_temp[2]) };
                        decimal[] alarm = { decimal.Parse(alarm_temp[0]), decimal.Parse(alarm_temp[1]) };

                        tempConnect.Open();
                        command = new SQLiteCommand(new ListSqlQuery().sqlDeleteData(ListSqlQuery.CALENDAR_MODE, date, alarm), tempConnect);
                        command.ExecuteNonQuery();
                        tempConnect.Close();
                    }
                }

                RefreshData();
                RefreshCalendar();
            }
        }

        private void DataView_FormClosing(object sender, FormClosingEventArgs e) { e.Cancel = true; this.Visible = false;   }

    }
}
