using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Text;

namespace CalendarWinForm
{
    public partial class DataView : Form
    {
        // instance variable. 
        private SQLiteConnection connect;
        private CalendarMain cmain;

        // Constructor. 
        public DataView(SQLiteConnection connect, CalendarMain cmain) {
            InitializeComponent();

            this.connect = connect;
            this.cmain = cmain;
            refreshData();
        }


        /*** Event. ***/
        private void button_refresh_Click(object sender, EventArgs e){ refreshData(); }
        private void button_add_Click(object sender, EventArgs e) { buttonClickEnableChanged(); groupBox_mode.Text = "Add mode"; }
        private void button_modify_Click(object sender, EventArgs e) { buttonClickEnableChanged(); groupBox_mode.Text = "Modify mode"; }
        private void button_delete_Click(object sender, EventArgs e) { deleteMessage(); }
        private void DataView_Load(object sender, EventArgs e) { refreshData(); }

        private void CheckBox_isMulti_CheckedChanged(object sender, EventArgs e) {
            if (this.checkBox_isMulti.Checked == true)  this.dateTimePicker_end.Enabled = true;
            else this.dateTimePicker_end.Enabled = false;
            
        }

        private void listView_allDatalist_SelectedIndexChanged(object sender, EventArgs e) { /*button_modify.Enabled = true; */ button_delete.Enabled = true; }
        private void button_done_Click(object sender, EventArgs e)
        {
            int length;

            length = Encoding.Default.GetBytes(textBox_text.Text).Length;

            if (length <= 20 && length > 0) {
                if (label_date.Text == "Add mode") addMode();
                else if (label_date.Text == "Modify mode") modifyMode();
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

        }

        // select "Modift mode"     
        public void modifyMode(){

        }


        public void refreshData() {
            listView_allDatalist.Items.Clear();
            groupBox_mode.Text = "Unselected";

            connect.Open();
            SQLiteCommand command = new SQLiteCommand(QueryList.allDataSQL(), connect);
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
            connect.Close();

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
        }

        // Edit disable method. 
        private void buttonClickDisableChanged() {
            this.checkBox_isMulti.Enabled = false;      this.checkBox_isMulti.Checked = false;
            this.numericUpDown_hour.Enabled = false;    this.numericUpDown_hour.Value = 0;
            this.numericUpDown_minute.Enabled = false;  this.numericUpDown_minute.Value = 0;
            this.textBox_text.Enabled = false;          this.textBox_text.Text = "";
            this.checkBox_alarm.Enabled = false;        this.checkBox_alarm.Checked = false;
            this.button_done.Enabled = false;
            this.dateTimePicker_start.Enabled = false;
            this.dateTimePicker_start.Value = DateTime.Now;
            this.dateTimePicker_end.Value = DateTime.Now.AddDays(2);
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

                        connect.Open();
                        SQLiteCommand command = new SQLiteCommand(QueryList.deleteDateSQL(date[0], date[1], date[2], alarm), connect);
                        command.ExecuteNonQuery();
                        connect.Close();
                    }
                }

                refreshData();
                cmain.changeCalendar();
                cmain.calendarListRefresh();
                cmain.refreshAlarm();
            }
        }

    }
}
