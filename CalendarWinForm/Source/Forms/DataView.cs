using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Text;

namespace CalendarWinForm
{
    public partial class DataView : Form
    {
        // instance variable. 
        private CalendarMain tempMain;
        private SQLiteConnection tempConnect;

        // update sql only. 
        private DateTime past_day;
        private decimal past_h;
        private decimal past_m;


        // Constructor. 
        public DataView() {
            InitializeComponent();

            this.tempConnect = AppManager.GetInstance().Connect_calendar;
            this.tempMain = AppManager.GetInstance().S_Main;
            //this.Visible = false;
            refreshData();
        }


        /*** Event. ***/
        private void button_refresh_Click(object sender, EventArgs e){ refreshData(); }
        private void button_add_Click(object sender, EventArgs e) { buttonClickEnableChanged(); groupBox_mode.Text = "Add mode"; }
        private void button_modify_Click(object sender, EventArgs e) { buttonClickEnableChanged(); dataSettings(); groupBox_mode.Text = "Modify mode"; }
        private void button_delete_Click(object sender, EventArgs e) { deleteMessage(); }
        private void DataView_Load(object sender, EventArgs e) { refreshData(); }

        private void CheckBox_isMulti_CheckedChanged(object sender, EventArgs e) {
            if (this.checkBox_isMulti.Checked == true)  this.dateTimePicker_end.Enabled = true;
            else this.dateTimePicker_end.Enabled = false;
            
        }

        private void listView_allDatalist_SelectedIndexChanged(object sender, EventArgs e) {
            button_modify.Enabled = true;
            button_delete.Enabled = true;
        }

        private void button_done_Click(object sender, EventArgs e)
        {
            int length;

            length = Encoding.Default.GetBytes(textBox_text.Text).Length;

            if (length <= 20 && length > 0) {
                if (groupBox_mode.Text.Equals("Add mode")) addMode();
                else if (groupBox_mode.Text.Equals("Modify mode")) modifyMode();
            }

            else { MessageBox.Show("Invalid input.\nPlease select the correct date."); return; }
        }

        private void DateTimePicker_start_ValueChanged(object sender, EventArgs e) {
            this.dateTimePicker_end.Value = this.dateTimePicker_start.Value.AddDays(2);
        }

        private void DateTimePicker_end_ValueChanged(object sender, EventArgs e) {
            if(this.dateTimePicker_start.Value >= this.dateTimePicker_end.Value) {
                this.dateTimePicker_end.Value = this.dateTimePicker_start.Value.AddDays(2);
            }
        }


        /*** Method List. ***/

        // select "Add mode"        
        public void addMode(){

            string sql;
            string[] date;
            SQLiteCommand command;

            date = new string[3];
            date = (this.dateTimePicker_start.Value.ToString("yyyy-M-d")).Split('-');
            decimal[] dateYMD = { decimal.Parse(date[0]), decimal.Parse(date[1]), decimal.Parse(date[2]) };
            decimal[] dateHM = { numericUpDown_hour.Value, numericUpDown_minute.Value };

            // duplicate check.     
            sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, dateYMD, dateHM);
            tempConnect.Open();
            command = new SQLiteCommand(sql, tempConnect);
            SQLiteDataReader reader = command.ExecuteReader();

            if (reader.Read()) {
                MessageBox.Show("Duplicate alarm time.");
                reader.Close(); tempConnect.Close(); return;
            }

            reader.Close();
            tempConnect.Close();


            /* normal mode */
            if (this.checkBox_isMulti.Checked == false) {

                // input data.          
                sql = new ListSqlQuery().sqlInsertValues(ListSqlQuery.CALENDAR_MODE, dateYMD, dateHM, textBox_text.Text, checkBox_alarm.Checked);
                tempConnect.Open();
                command = new SQLiteCommand(sql, tempConnect);
                command.ExecuteNonQuery();
                tempConnect.Close();

            }


            /* multi mode */
            else {
                DateTime temp_nextday = new DateTime(dateTimePicker_start.Value.Ticks);
                TimeSpan temp = DateTime.Parse(dateTimePicker_end.Value.ToString("yyyy-M-d")) - DateTime.Parse(dateTimePicker_start.Value.ToString("yyyy-M-d"));
                int dayTemp = temp.Days;
                bool oncemessage = true;

                // input data (multi).          
                for (int count = 0; count <= dayTemp; count++, temp_nextday = temp_nextday.AddDays(1)) {
                    date = new string[3];
                    date = temp_nextday.ToString("yyyy-M-d").Split('-');

                    dateYMD[0] = decimal.Parse(date[0]);
                    dateYMD[1] = decimal.Parse(date[1]);
                    dateYMD[2] = decimal.Parse(date[2]);

                    sql = new ListSqlQuery().sqlOverlapCheck(ListSqlQuery.CALENDAR_MODE, dateYMD, dateHM);

                    tempConnect.Open();
                    command = new SQLiteCommand(sql, tempConnect);
                    reader = command.ExecuteReader();


                    // data is already exist.      
                    if (reader.Read()) {
                        reader.Close(); tempConnect.Close();
                        if (oncemessage) { MessageBox.Show("Existing data was maintained due to overlapping schedules."); oncemessage = false; }
                    }

                    // data is not already exist.  
                    else {
                        reader.Close(); tempConnect.Close();
                        sql = new ListSqlQuery().sqlInsertValues(ListSqlQuery.CALENDAR_MODE, dateYMD, dateHM, textBox_text.Text, checkBox_alarm.Checked);
                        tempConnect.Open(); command = new SQLiteCommand(sql, tempConnect);
                        command.ExecuteNonQuery();
                        tempConnect.Close();
                    }

                }

            }

            // refresh data 
            refreshData();
            tempMain.changeCalendar();
            tempMain.calendarListRefresh();
            tempMain.refreshAlarm();

        }

        // data settings.
        public void dataSettings(){
            for (int count = 0; count < listView_allDatalist.Items.Count; count++)
                if (listView_allDatalist.Items[count].Selected){

                    string[] sp = new string[2];
                    sp = listView_allDatalist.Items[count].SubItems[1].Text.Split(':');

                    label_targetDate.Text = listView_allDatalist.Items[count].Text;

                    past_day = dateTimePicker_start.Value = DateTime.Parse(label_targetDate.Text);
                    past_h = numericUpDown_hour.Value = decimal.Parse(sp[0]);
                    past_m = numericUpDown_minute.Value = decimal.Parse(sp[1]);
                    textBox_text.Text = listView_allDatalist.Items[count].SubItems[2].Text;
                    checkBox_alarm.Checked = ((listView_allDatalist.Items[count].SubItems[3].Text) == "O" ? true : false);
                    break;
                }
        }

        // select "Modift mode"     
        public void modifyMode(){

            string sql;
            string[] date;

            date = new string[3];
            date = past_day.ToString("yyyy-M-d").Split('-');
            sql = QueryList.overlapMultiCheckSQL(date, past_h, past_m);
            tempConnect.Open();
            SQLiteCommand command = new SQLiteCommand(sql, tempConnect);
            SQLiteDataReader reader = command.ExecuteReader();

            if (!reader.Read()){
                MessageBox.Show("Can't find past data.");
                reader.Close(); tempConnect.Close();
                return;
            }
            reader.Close();     tempConnect.Close();

            // single alarm mode. 
            if(checkBox_isMulti.Checked == false) {
                sql = QueryList.updateSQL(date, numericUpDown_hour.Value, numericUpDown_minute.Value, textBox_text.Text, checkBox_alarm.Checked, (int)past_h, (int)past_m);
                tempConnect.Open();
                command = new SQLiteCommand(sql, tempConnect);
                command.ExecuteNonQuery();
                tempConnect.Close();
                
            }

            // multi alarm mode. 
            else {
                DateTime temp_checkDay = new DateTime(dateTimePicker_start.Value.Ticks);
                int dayCount = (DateTime.Parse(dateTimePicker_end.Value.ToString("yyyy-M-d")) - DateTime.Parse(dateTimePicker_start.Value.ToString("yyyy-M-d"))).Days;

                for(int count = 0; count <= dayCount; count++, temp_checkDay = temp_checkDay.AddDays(1)) {
                    date = new string[3];
                    date = temp_checkDay.ToString("yyyy-M-d").Split('-');
                    sql = QueryList.updateMultiSQL2(date, numericUpDown_hour.Value, numericUpDown_minute.Value, textBox_text.Text, checkBox_alarm.Checked,past_h,past_m);

                    tempConnect.Open();
                    command = new SQLiteCommand(sql, tempConnect);
                    command.ExecuteNonQuery();
                    tempConnect.Close();
                }
            }

            // refresh data 
            refreshData();
            tempMain.changeCalendar();
            tempMain.calendarListRefresh();
            tempMain.refreshAlarm();
        }


        public void refreshData() {
            listView_allDatalist.Items.Clear();
            groupBox_mode.Text = "Unselected";

            tempConnect.Open();
            SQLiteCommand command = new SQLiteCommand(QueryList.allDataSQL(), tempConnect);
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

            reader.Close();
            tempConnect.Close();

            button_modify.Enabled = false;
            button_delete.Enabled = false;
            buttonClickDisableChanged();
        }


        // Edit enable method. 
        private void buttonClickEnableChanged() {
            this.checkBox_isMulti.Enabled = true;
            this.numericUpDown_hour.Enabled = true;
            this.numericUpDown_minute.Enabled = true;
            this.textBox_text.Enabled = true;
            this.checkBox_alarm.Enabled = true;
            this.button_done.Enabled = true;
            this.dateTimePicker_start.Enabled = true;
            this.label_targetDate.Text = "-";
        }

        // Edit disable method. 
        private void buttonClickDisableChanged() {
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


        private void deleteMessage() {
            if (MessageBox.Show($"Are you sure you want to delete the data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                for(int count = listView_allDatalist.Items.Count - 1; count >= 0; count = count - 1) {
                    if (listView_allDatalist.Items[count].Selected == true) {
                        string[] date_temp = listView_allDatalist.Items[count].Text.ToString().Split('-');
                        string[] alarm_temp = listView_allDatalist.Items[count].SubItems[1].Text.ToString().Split(':');

                        int[] date = new int[3];    date[0] = int.Parse(date_temp[0]);
                                                    date[1] = int.Parse(date_temp[1]);
                                                    date[2] = int.Parse(date_temp[2]);

                        int[] alarm = new int[2];   alarm[0] = int.Parse(alarm_temp[0]);
                                                    alarm[1] = int.Parse(alarm_temp[1]);

                        tempConnect.Open();
                        SQLiteCommand command = new SQLiteCommand(QueryList.deleteDateSQL(date[0], date[1], date[2], alarm), tempConnect);
                        command.ExecuteNonQuery();
                        tempConnect.Close();
                    }
                }

                refreshData();
                tempMain.changeCalendar();
                tempMain.calendarListRefresh();
                tempMain.refreshAlarm();
            }
        }

        private void DataView_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            this.Visible = false;
        }
    }
}
