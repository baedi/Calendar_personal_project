using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace CalendarWinForm
{
    public partial class CalendarMain : Form
    {

        // variable.                                            
        private readonly SQLiteConnection[] connect;
        private SQLiteCommand command;
        private DataAddForm addForm;
        private TodayDataAddForm addForm_today;
        private DataView dataview;

        private int gbox_index;
        private bool alarm_onCheck;
        private bool real_exit;

        //private readonly AppManager appManager;
        private readonly ThreadManager tManager;
        private readonly ListBox[] gbox;
        private decimal[] selectCalendarDay;

        private readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\baedi_calendar";
        private readonly string[] dbFileName = { @"\calendar.db", @"\todayAlarm.db" };


        // main method.                                         
        public CalendarMain() {
            InitializeComponent();

            alarm_onCheck = true;
            gbox = new ListBox[42];


            // Database setting. 
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            connect = new SQLiteConnection[2] { null, null };

            for (int count = 0; count < 2; count++) {
                connect[count] = new SQLiteConnection("Data Source=" + path + dbFileName[count] + ";Version=3;");

                if(!File.Exists(path + dbFileName[count])) {
                    command = new SQLiteCommand(new ListSqlQuery().sqlCreateTable(count == 0 ? ListSqlQuery.CALENDAR_MODE : ListSqlQuery.ALARM_MODE), connect[count]);
                    SQLiteConnection.CreateFile(path + dbFileName[count]);
                    MessageBox.Show("Create DB : " + dbFileName[count]);
                    connect[count].Open();
                    command.ExecuteNonQuery();
                    connect[count].Close();
                }
            }

            tManager = new ThreadManager(label_Time, connect);    // Thread setting.  


            // Panel setting.                                   
            for (int count = 0; count < gbox.Length; count++) {
                gbox[count] = new ListBox();
                gbox[count].SelectionMode = SelectionMode.None;
                gbox[count].MouseDown += new MouseEventHandler(CalendarMouseDown);
                gbox[count].MouseDoubleClick += new MouseEventHandler(CalendarMouseDoubleClick);
            }
            // Current date setting. 
            DateTime curTime = new DateTime(DateTime.Now.Ticks);
            string[] ymd = curTime.ToString("yyyy-MM-dd").Split('-');
            selectCalendarDay = new decimal[] { decimal.Parse(ymd[0]), decimal.Parse(ymd[1]), decimal.Parse(ymd[2]) };

            for (int row = 1, count = 0; row <= 6; row++)
                for (int col = 0; col < 7; col++) { panel_MonthList.Controls.Add(gbox[count], col, row); count++; }

            label_DateTemp.Text = selectCalendarDay[0].ToString() + "." + selectCalendarDay[1].ToString() + "." + selectCalendarDay[2].ToString();
            label_YearMonth.Text = selectCalendarDay[0].ToString() + "." + selectCalendarDay[1].ToString("00");
            ChangeCalendar();
            TodayAlarmListRefresh();
        }



        // calendar diary set Method.                           
        private void SettingCalendar(){

            int maxDays = int.Parse(DateTime.DaysInMonth((int)selectCalendarDay[0], (int)selectCalendarDay[1]).ToString());
            int blankCount, tempCt;
            DateTime dOfMonth = new DateTime();

            dOfMonth = dOfMonth.AddYears((int)selectCalendarDay[0] - 1).AddMonths((int)selectCalendarDay[1] - 1);

            switch (dOfMonth.DayOfWeek.ToString())
            {
                case "Sunday": blankCount = 7; break;
                case "Monday": blankCount = 1; break;
                case "Tuesday": blankCount = 2; break;
                case "Wednesday": blankCount = 3; break;
                case "Thursday": blankCount = 4; break;
                case "Friday": blankCount = 5; break;
                default: blankCount = 6; break;
            }

            tempCt = blankCount - 1;
            connect[0].Open();

            for (int row = 1, boxCount = 0, dayCount = 1; row <= 6; row = row + 1)
                for (int col = 0; col < 7; col = col + 1)
                {

                    if (blankCount > 0 || dayCount > maxDays) {
                        gbox[boxCount].BackColor = System.Drawing.SystemColors.InactiveCaptionText;
                        gbox[boxCount].Enabled = false;
                        blankCount = blankCount - 1;
                    }

                    else {
                        // Calender Panel color setting.
                        if (DateTime.Now.ToString("yyyy-MM") == (selectCalendarDay[0].ToString() + "-" + selectCalendarDay[1].ToString("00")) && dayCount == int.Parse(DateTime.Now.ToString("dd")))
                            gbox[dayCount + tempCt].BackColor = System.Drawing.Color.FromArgb(192, 255, 255);

                        else if (dOfMonth.DayOfWeek.ToString() == "Sunday")
                            gbox[boxCount].BackColor = System.Drawing.Color.FromArgb(255, 192, 192);

                        else if (dOfMonth.DayOfWeek.ToString() == "Saturday")
                            gbox[boxCount].BackColor = System.Drawing.Color.FromArgb(192, 192, 255);

                        else gbox[boxCount].BackColor = System.Drawing.SystemColors.Window;

                        //gbox[boxCount].MouseDown += new MouseEventHandler(CalendarMouseDown);


                        // database setting. 
                        string[] dateStr = dOfMonth.ToString("yyyy-MM-dd").Split('-');
                        DataManage dManage = new DataManage(decimal.Parse(dateStr[0]), decimal.Parse(dateStr[1]), decimal.Parse(dateStr[2]));

                        command = new SQLiteCommand(new ListSqlQuery().sqlListboxRefresh(dManage.YearMonthDay), connect[0]);
                        SQLiteDataReader reader = command.ExecuteReader();
                        gbox[boxCount].Items.Insert(0, dayCount);

                        int moreCount = 0;
                        for (int count = 1; reader.Read(); count = count + 1) {
                            if (count >= 4) moreCount = moreCount + 1;
                            else gbox[boxCount].Items.Insert(count, reader["text"].ToString());
                        }

                        if (moreCount > 0) gbox[boxCount].Items.Insert(4, "(...more " + moreCount + ")");

                        reader.Close();

                        gbox[boxCount].Enabled = true;
                        dayCount = dayCount + 1;
                        dOfMonth = dOfMonth.AddDays(1);
                    }

                    boxCount = boxCount + 1;

                }

            connect[0].Close();

            gbox_index = (int)selectCalendarDay[2] + tempCt;
            gbox[gbox_index].BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            if (dataview != null && !dataview.IsDisposed) dataview.RefreshData();
        }


        public void ChangeCalendar()
        {
            for (int count = 0; count < gbox.Length; count++) gbox[count].Items.Clear();
            SettingCalendar();
            button_modifySch.Enabled = false;
            button_deleteSch.Enabled = false;
        }


        // database current day calendar import.                
        public void CalendarListRefresh()
        {
            connect[0].Open();
            listView_Schedule.Items.Clear();
            decimal[] selectCalendarDay2 = { selectCalendarDay[0], selectCalendarDay[1], selectCalendarDay[2] };

            command = new SQLiteCommand(new ListSqlQuery().sqlListViewRefresh(ListSqlQuery.CALENDAR_MODE, selectCalendarDay2), connect[0]);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                bool active = (bool)reader["active"];

                listView_Schedule.Items.Add(new ListViewItem(new string[] {
                    ((int)reader["sethour"]).ToString("00") + " : " +  ((int)reader["setminute"]).ToString("00"),
                    reader["text"].ToString(),
                    active ? "Y" : "N"
                }));
            }

            reader.Close();
            connect[0].Close();

            button_modifySch.Enabled = false;
            button_deleteSch.Enabled = false;

            if(dataview != null && !dataview.IsDisposed) dataview.RefreshData();
        }

        // database(today) current day calendar import.
        public void TodayAlarmListRefresh()
        {
            connect[1].Open();
            listView_todayList.Items.Clear();

            command = new SQLiteCommand(new ListSqlQuery().sqlListViewRefresh(ListSqlQuery.ALARM_MODE, null), connect[1]);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                listView_todayList.Items.Add(new ListViewItem(new string[] {
                    ((int)reader["sethour"]).ToString("00") + " : " + ((int)reader["setminute"]).ToString("00"),
                    reader["text"].ToString()
                }));
            }

            reader.Close();
            connect[1].Close();

            button_today_modify.Enabled = false;
            button_today_delete.Enabled = false;
        }


        // delete select database.                              
        private void DeleteDBdata_(int index, bool isCalendarMode) {
            ListView listview               = isCalendarMode == true ? listView_Schedule : listView_todayList;
            SQLiteConnection tempConnect    = isCalendarMode == true ? connect[0] : connect[1];
            decimal[] tempDateYMD           = isCalendarMode == true ? selectCalendarDay : null;
            int mode                        = isCalendarMode == true ? ListSqlQuery.CALENDAR_MODE : ListSqlQuery.ALARM_MODE;
            string[] splitstr               = listview.Items[index].Text.Split(':');

            DataManage dManage = new DataManage(decimal.Parse(splitstr[0]), decimal.Parse(splitstr[1]));

            tempConnect.Open();
            SQLiteCommand command = new SQLiteCommand(new ListSqlQuery().sqlDeleteData(mode, tempDateYMD, dManage.HourMinute), tempConnect);
            command.ExecuteNonQuery();
            tempConnect.Close();
        }


        // calendar widget Event.                               
        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            int cval = (int)selectCalendarDay[2];
            int temp = (int)selectCalendarDay[2];
            selectCalendarDay[2] = int.Parse(e.End.ToString("dd"));

            if (int.Parse(e.Start.Year.ToString()) == selectCalendarDay[0] &&
                int.Parse(e.Start.Month.ToString()) == selectCalendarDay[1])
            {
                cval = (int)selectCalendarDay[2] - cval;
                if (cval == 0) return;

                int[] sat_index = { 6, 13, 20, 27, 34, 41 };
                int[] sun_index = { 7, 14, 21, 28, 35, 42 };
                bool correct_sat_sun_index = false;

                // (blue) 192 192 255 
                foreach (int index in sat_index)
                    if (gbox_index == index)
                    {
                        gbox[gbox_index].BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
                        correct_sat_sun_index = true;
                        break;
                    };

                // (red) 255 192 192 
                if (!correct_sat_sun_index)
                    foreach (int index in sun_index)
                        if (gbox_index == index)
                        {
                            gbox[gbox_index].BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
                            correct_sat_sun_index = true;
                            break;
                        };

                // (white) window. 
                if (!correct_sat_sun_index)
                    gbox[gbox_index].BackColor = System.Drawing.SystemColors.Window;


                // current date color ... skycolor (192 255 255)
                if (DateTime.Now.ToString("yyyy-MM-dd") == (selectCalendarDay[0].ToString() + "-" + selectCalendarDay[1].ToString("00") + "-" + temp.ToString("00")))
                    gbox[gbox_index].BackColor = System.Drawing.Color.FromArgb(192, 255, 255);


                // selected 
                gbox_index = gbox_index + cval;
                gbox[gbox_index].BackColor = System.Drawing.Color.FromArgb(255, 255, 192);

                button_modifySch.Enabled = false;
                button_deleteSch.Enabled = false;
            }


            else {
                selectCalendarDay[0] = int.Parse(e.End.ToString("yyyy"));
                selectCalendarDay[1] = int.Parse(e.End.ToString("MM"));
                ChangeCalendar();
            }

            label_DateTemp.Text = e.End.ToString("yyyy") + "." + int.Parse(e.End.ToString("MM")).ToString() + "." + int.Parse(e.End.ToString("dd")).ToString();
            label_YearMonth.Text = e.End.ToString("yyyy") + "." + (int.Parse(e.End.ToString("MM")).ToString("00"));
            //calendar_index = -1;        // index reset. 
        }


        // Calendar click event.                                
        private void CalendarMouseDown(object sender, MouseEventArgs e) {
            //int gBoxIndex = ((ListBox)sender).TabIndex;
            monthCalendar1.SetDate(new DateTime((int)selectCalendarDay[0], (int)selectCalendarDay[1], int.Parse(((ListBox)sender).Items[0].ToString())));
        }


        // double click event. (open DataAddForm)               
        private void CalendarMouseDoubleClick(object sender, MouseEventArgs e) { AddFormDisposedCheckEvent(button_addSch, null); }


        // datetime label text changed Event.                   
        private void Label_DateTemp_TextChanged(object sender, EventArgs e) { CalendarListRefresh(); }


        // schedule click Event.                                
        private void ListView_Schedule_Click(object sender, EventArgs e)
        {
            //foreach (int getIndex in listView_Schedule.SelectedIndices) calendar_index = getIndex;
            button_modifySch.Enabled = true;
            button_deleteSch.Enabled = true;
        }

        private void ListView_Schedule_DoubleClick(object sender, EventArgs e)
        {
            foreach (int getIndex in listView_Schedule.SelectedIndices)
                MessageBox.Show(getIndex.ToString());
        }


        // today schedule click Event.
        private void ListView_todayList_Click(object sender, EventArgs e)
        {
            button_today_modify.Enabled = true;
            button_today_delete.Enabled = true;
        }


        // ADD, MODIFY, DELETE click check Event.           
        private void AddFormDisposedCheckEvent(object sender, EventArgs e) {
            if (sender.Equals(button_addSch) || sender.Equals(button_modifySch) || sender.Equals(button_deleteSch)) {
                if (addForm != null && addForm.IsDisposed) addForm = null;
                if (addForm != null) return;

                if (sender.Equals(button_addSch)) AddButtonClickProcess(true);
                else if (sender.Equals(button_modifySch)) ModifyButtonClickProcess(true);
                else if (sender.Equals(button_deleteSch)) DeleteButtonClickProcess(true);
            }

            else if(sender.Equals(button_today_add) || sender.Equals(button_today_modify) || sender.Equals(button_today_delete)) {
                if (addForm_today != null && addForm_today.IsDisposed) addForm_today = null;
                if (addForm_today != null) return;

                if (sender.Equals(button_today_add)) AddButtonClickProcess(false);
                else if (sender.Equals(button_today_modify)) ModifyButtonClickProcess(false);
                else if (sender.Equals(button_today_delete)) DeleteButtonClickProcess(false);
            }
        }


        private void AddButtonClickProcess(bool isCalendar) {
            if (isCalendar) {
                addForm = new DataAddForm(label_DateTemp, this, connect[0], false);
                addForm.Show();
            }

            else {
                addForm_today = new TodayDataAddForm(this, connect[1], true);
                addForm_today.Show();
            }
        }


        private void ModifyButtonClickProcess(bool isCalendar) {

            if (isCalendar){
                bool actCheck = listView_Schedule.SelectedItems[0].SubItems[2].Text == "Y" ? true : false;
                string text = listView_Schedule.SelectedItems[0].SubItems[1].Text.ToString();
                string[] datalist = listView_Schedule.SelectedItems[0].SubItems[0].Text.Split(':');
                addForm = new DataAddForm(label_DateTemp, this, connect[0], true);
                addForm.SetSelectData(datalist, text, actCheck);
                addForm.Show();
            }

            else {
                addForm_today = new TodayDataAddForm(this, connect[1], false);
                addForm_today.Text = "TodayDataAddForm(Modify)";
                addForm_today.PastDataSet(listView_todayList.SelectedItems[0].Text.ToString().Split(':'), listView_todayList.SelectedItems[0].SubItems[1].Text);
                addForm_today.Show();
            }
        }


        private void DeleteButtonClickProcess(bool isCalendar) {
            if (isCalendar) {
                if (MessageBox.Show($"Are you sure you want to delete the data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int count = listView_Schedule.Items.Count - 1; count >= 0; count = count - 1)
                        if (listView_Schedule.Items[count].Selected == true) DeleteDBdata_(count, true);

                    DataManage dManage = new DataManage(selectCalendarDay[0], selectCalendarDay[1], selectCalendarDay[2]);
                    ChangeCalendar();
                    CalendarListRefresh();
                    RefreshAlarm();
                }
            }

            else {
                if (MessageBox.Show($"Are you sure you want to delete the data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int count = listView_todayList.Items.Count - 1; count >= 0; count = count - 1)
                        if (listView_todayList.Items[count].Selected == true) DeleteDBdata_(count, false);

                    TodayAlarmListRefresh();
                    RefreshAlarm();
                }
            }
        }


        // "Alarm ON button click Event.                        
        private void Button_alarmon_Click(object sender, EventArgs e) { new AlarmStatusChange(this, alarmONToolStripMenuItem, button_alarmon, tManager, alarm_onCheck ? AlarmStatusChange.BC_FALSE : AlarmStatusChange.BC_TRUE); }


        // program close Event.                                 
        private void Form_Calendar_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (real_exit) {
                try
                {
                    tManager.SetThreadEnable(false);
                    if (tManager.GetThreadManager().ThreadState != System.Threading.ThreadState.Stopped) tManager.GetThreadManager().Join();
                }
                catch (NullReferenceException) { }
            }

            else { e.Cancel = true; Visible = false; }
        }

        // get, set Method. 
        public void RefreshAlarm() { tManager.NextAlarmReadyRefresh(); }
        public void SetAlarmOnCheck(bool temp) { alarm_onCheck = temp; }

        // data view mode. 
        private void Button_dataview_Click(object sender, EventArgs e) {
            if (dataview != null && dataview.IsDisposed) dataview = null;
            if (dataview != null) return; 
                dataview = new DataView(this, connect[0]);
                dataview.Show();
        }

        // trayicon Event. 
        private void Trayicon_MouseDoubleClick(object sender, MouseEventArgs e) { Visible = true; }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) { real_exit = true; Close(); }
        private void DataViewToolStripMenuItem_Click(object sender, EventArgs e) { Button_dataview_Click(null, null); }
        private void AlarmONToolStripMenuItem_Click(object sender, EventArgs e) { new AlarmStatusChange(this, alarmONToolStripMenuItem, button_alarmon, tManager, AlarmStatusChange.STRIP_CLICK); }
    }
}