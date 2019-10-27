using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace CalendarWinForm
{
    public partial class CalendarMain : Form
    {

        // variable.                                            
        private DataAddForm addForm;
        private TodayDataAddForm addForm_today;
        private DataView dataview;

        private int gbox_index;
        private bool alarm_onCheck;
        private bool real_exit;
        private bool isSelectedDate;

        private readonly AppManager appManager;
        private readonly ThreadManager tManager;
        private readonly ListBox[] gbox;
        private readonly decimal[] selectCalendarDay;

        private readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\baedi_calendar";
        private readonly string dbFileName = @"\calendar.db";
        private readonly string dbFileName2 = @"\todayAlarm.db";


        // main method.                                         
        public CalendarMain()
        {
            InitializeComponent();

            alarm_onCheck = true;
            gbox = new ListBox[42];
            addForm = new DataAddForm(label_DateTemp, this, false);
            addForm_today = new TodayDataAddForm(this, false);

            // singleton Instance. 
            appManager = AppManager.GetInstance();
            appManager.S_Main = this;

            // Database setting. 
            appManager.Connect_calendar = new SQLiteConnection("Data Source=" + path + dbFileName + ";Version=3;");
            appManager.Connect_today = new SQLiteConnection("Data Source=" + path + dbFileName2 + ";Version=3;");
            addForm.SetDbConnect(appManager.Connect_calendar);      addForm.Close();
            addForm_today.setDbConnect(appManager.Connect_today);   addForm_today.Close();

            if (!File.Exists(path + dbFileName)) {
                appManager.Command_calendar = new SQLiteCommand(new ListSqlQuery().sqlCreateTable(ListSqlQuery.CALENDAR_MODE), appManager.Connect_calendar);
                Directory.CreateDirectory(path);
                SQLiteConnection.CreateFile(path + dbFileName);
                MessageBox.Show("Created new calendar db.");
                appManager.Connect_calendar.Open();
                appManager.Command_calendar.ExecuteNonQuery();
                appManager.Connect_calendar.Close();
            }

            if (!File.Exists(path + dbFileName2)) {
                appManager.Command_today = new SQLiteCommand(new ListSqlQuery().sqlCreateTable(ListSqlQuery.ALARM_MODE), appManager.Connect_today);
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                SQLiteConnection.CreateFile(path + dbFileName2);
                MessageBox.Show("Created new today alarm db.");
                appManager.Connect_today.Open();
                appManager.Command_today.ExecuteNonQuery();
                appManager.Connect_today.Close();
            }

            tManager = new ThreadManager(label_Time);    // Thread setting.  


            // Panel setting.                                   
            for (int count = 0; count < gbox.Length; count++) gbox[count] = new ListBox();

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
            appManager.Connect_calendar.Open();

            for (int row = 1, boxCount = 0, dayCount = 1; row <= 6; row = row + 1)
                for (int col = 0; col < 7; col = col + 1)
                {

                    if (blankCount > 0 || dayCount > maxDays) {
                        gbox[boxCount].BackColor = System.Drawing.SystemColors.InactiveCaptionText;
                        gbox[boxCount].TabStop = false;
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


                        // database setting. 
                        string[] dateStr = dOfMonth.ToString("yyyy-MM-dd").Split('-');
                        DataManage dManage = new DataManage(decimal.Parse(dateStr[0]), decimal.Parse(dateStr[1]), decimal.Parse(dateStr[2]));

                        appManager.Command_calendar = new SQLiteCommand(new ListSqlQuery().sqlListboxRefresh(dManage.YearMonthDay), appManager.Connect_calendar);
                        SQLiteDataReader reader = appManager.Command_calendar.ExecuteReader();
                        gbox[boxCount].Items.Insert(0, dayCount);

                        int moreCount = 0;
                        for (int count = 1; reader.Read(); count = count + 1) {
                            if (count >= 4) moreCount = moreCount + 1;
                            else gbox[boxCount].Items.Insert(count, reader["text"].ToString());
                        }

                        if (moreCount > 0) gbox[boxCount].Items.Insert(4, "(...more " + moreCount + ")");

                        reader.Close();

                        gbox[boxCount].TabStop = true;
                        dayCount = dayCount + 1;
                        dOfMonth = dOfMonth.AddDays(1);
                    }

                    gbox[boxCount].Enabled = false;
                    boxCount = boxCount + 1;

                }

            appManager.Connect_calendar.Close();

            gbox_index = (int)selectCalendarDay[2] + tempCt;
            gbox[gbox_index].BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            if (dataview != null) dataview.RefreshData();
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
            appManager.Connect_calendar.Open();
            listView_Schedule.Items.Clear();
            decimal[] selectCalendarDay2 = { selectCalendarDay[0], selectCalendarDay[1], selectCalendarDay[2] };

            appManager.Command_calendar = new SQLiteCommand(new ListSqlQuery().sqlListViewRefresh(ListSqlQuery.CALENDAR_MODE, selectCalendarDay2), appManager.Connect_calendar);
            SQLiteDataReader reader = appManager.Command_calendar.ExecuteReader();

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
            appManager.Connect_calendar.Close();

            button_modifySch.Enabled = false;
            button_deleteSch.Enabled = false;

            if(dataview != null)dataview.RefreshData();
        }

        // database(today) current day calendar import.
        public void TodayAlarmListRefresh()
        {
            appManager.Connect_today.Open();
            listView_todayList.Items.Clear();

            appManager.Command_today = new SQLiteCommand(new ListSqlQuery().sqlListViewRefresh(ListSqlQuery.ALARM_MODE, null), appManager.Connect_today);
            SQLiteDataReader reader = appManager.Command_today.ExecuteReader();

            while (reader.Read())
            {
                listView_todayList.Items.Add(new ListViewItem(new string[] {
                    ((int)reader["sethour"]).ToString("00") + " : " + ((int)reader["setminute"]).ToString("00"),
                    reader["text"].ToString()
                }));
            }

            reader.Close();
            appManager.Connect_today.Close();

            button_today_modify.Enabled = false;
            button_today_delete.Enabled = false;
        }


        // select box data refresh. 
        public void SelectBoxDataRefresh(ListBox selectBox, decimal[] dateYMD)
        {
            int dayItem = (int)selectBox.Items[0];
            selectBox.Items.Clear();
            selectBox.Items.Insert(0, dayItem);

            appManager.Connect_calendar.Open();
            SQLiteCommand command = new SQLiteCommand(new ListSqlQuery().sqlListboxRefresh(dateYMD), appManager.Connect_calendar);
            SQLiteDataReader reader = command.ExecuteReader();

            int moreCount = 0;
            for (int count = 1; reader.Read(); count = count + 1) {
                if (count >= 4) moreCount = moreCount + 1;
                else selectBox.Items.Insert(count, reader["text"].ToString());
            }

            if (moreCount > 0) selectBox.Items.Insert(4, "(...more " + moreCount + ")");
            reader.Close();
            appManager.Connect_calendar.Close();
        }


        // delete select database.                              
        private void DeleteDBdata(int index) {

            string[] splitstr = listView_Schedule.Items[index].Text.Split(':');
            DataManage dManage = new DataManage(decimal.Parse(splitstr[0]), decimal.Parse(splitstr[1]));

            appManager.Connect_calendar.Open();
            appManager.Command_calendar = new SQLiteCommand(new ListSqlQuery().sqlDeleteData(ListSqlQuery.CALENDAR_MODE, selectCalendarDay, dManage.HourMinute), appManager.Connect_calendar);
            appManager.Command_calendar.ExecuteNonQuery();
            appManager.Connect_calendar.Close();
        }

        private void DeleteDBdata_today(int index)
        {
            string[] splitstr = listView_todayList.Items[index].Text.Split(':');
            DataManage dManage = new DataManage(decimal.Parse(splitstr[0]), decimal.Parse(splitstr[1]));

            appManager.Connect_today.Open();
            appManager.Command_today = new SQLiteCommand(new ListSqlQuery().sqlDeleteData(ListSqlQuery.ALARM_MODE, null, dManage.HourMinute), appManager.Connect_today);
            appManager.Command_today.ExecuteNonQuery();
            appManager.Connect_today.Close();
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

                int[] sat_index = { 13, 20, 27, 34, 41 };
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


        // click location check Event. (main calender click)    
        private void Panel_MonthList_MouseDown(object sender, MouseEventArgs e)
        {
            for (int count = 0; count < gbox.Length; count++)
            {
                if (gbox[count].Location.X <= e.X &&
                    gbox[count].Location.Y <= e.Y &&
                    gbox[count].Location.X + gbox[count].Size.Width > e.X &&
                    gbox[count].Location.Y + gbox[count].Size.Height > e.Y &&
                    gbox[count].TabStop == true)
                {

                    DateTime temp = new DateTime();
                    monthCalendar1.SetDate(temp.AddYears((int)selectCalendarDay[0] - 1).AddMonths((int)selectCalendarDay[1] - 1).AddDays(int.Parse(gbox[count].Items[0].ToString()) - 1));
                    isSelectedDate = true;
                    return;
                }
            }

            isSelectedDate = false;
        }

        // double click event. (open DataAddForm)               
        private void Panel_MonthList_DoubleClick(object sender, EventArgs e){   if (isSelectedDate) this.Button_addSch_Click(null, null); }


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



        // "ADD" button click Event.                            
        private void Button_addSch_Click(object sender, EventArgs e)
        {
            if (addForm.IsDisposed) {
                addForm = new DataAddForm(label_DateTemp, this, false);
                addForm.GboxSetting(gbox[gbox_index]);
                addForm.SetDbConnect(appManager.Connect_calendar);
                addForm.Show();
            }
        }

        // "ADD" button click Event. (Today)                    
        private void Button_today_add_Click(object sender, EventArgs e)
        {
            if (addForm_today.IsDisposed){
                addForm_today = new TodayDataAddForm(this, true);
                addForm_today.setDbConnect(appManager.Connect_today);
                addForm_today.Show();
            }
        }


        // "Modify" button click Event.                         
        private void Button_modifySch_Click(object sender, EventArgs e)
        {
            string text = listView_Schedule.SelectedItems[0].SubItems[1].Text.ToString();
            bool actCheck = listView_Schedule.SelectedItems[0].SubItems[2].Text == "Y" ? true : false;
            string[] datalist = listView_Schedule.SelectedItems[0].SubItems[0].Text.Split(':');

            if (addForm.IsDisposed) {
                addForm = new DataAddForm(label_DateTemp, this, true);
                addForm.GboxSetting(gbox[gbox_index]);
                addForm.SetDbConnect(appManager.Connect_calendar);
                addForm.SetSelectData(datalist, text, actCheck);
                addForm.Show();
            }
        }

        // "MODIFY" button click Event. (Today)                 
        private void Button_today_modify_Click(object sender, EventArgs e) {
            if (addForm_today.IsDisposed) {
                addForm_today = new TodayDataAddForm(this, false);
                addForm_today.Text = "TodayDataAddForm(Modify)";
                addForm_today.pastDataSet(listView_todayList.SelectedItems[0].Text.ToString().Split(':'),
                                            listView_todayList.SelectedItems[0].SubItems[1].Text);
                addForm_today.setDbConnect(appManager.Connect_today);
                addForm_today.Show();
            }
        }


        // "Delete" button click Event.                         
        private void Button_deleteSch_Click(object sender, EventArgs e)
        {
            if (!addForm.IsDisposed) return;
            if (MessageBox.Show($"Are you sure you want to delete the data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int count = listView_Schedule.Items.Count - 1; count >= 0; count = count - 1)
                    if (listView_Schedule.Items[count].Selected == true) DeleteDBdata(count);

                DataManage dManage = new DataManage(selectCalendarDay[0], selectCalendarDay[1], selectCalendarDay[2]);
                SelectBoxDataRefresh(gbox[gbox_index], dManage.YearMonthDay);
                CalendarListRefresh();

                RefreshAlarm();
            }
        }

        // "DELETE" button click Event. (Today)                 
        private void Button_today_delete_Click(object sender, EventArgs e)
        {
            if (!addForm_today.IsDisposed) return;
            if (MessageBox.Show($"Are you sure you want to delete the data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int count = listView_todayList.Items.Count - 1; count >= 0; count = count - 1)
                    if (listView_todayList.Items[count].Selected == true) DeleteDBdata_today(count);

                TodayAlarmListRefresh();
                RefreshAlarm();
            }

        }


        // "Alarm ON button click Event.                        
        private void Button_alarmon_Click(object sender, EventArgs e) { AlarmStatusChange.alarmStatusChange(alarmONToolStripMenuItem, button_alarmon, tManager, alarm_onCheck ? AlarmStatusChange.BC_FALSE : AlarmStatusChange.BC_TRUE); }


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
        private void Button_dataview_Click(object sender, EventArgs e) { if(dataview == null) dataview = new DataView();    dataview.Show();}

        // trayicon Event. 
        private void Trayicon_MouseDoubleClick(object sender, MouseEventArgs e) { Visible = true; }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) { real_exit = true; Close(); }
        private void DataViewToolStripMenuItem_Click(object sender, EventArgs e) { Button_dataview_Click(null, null); }
        private void AlarmONToolStripMenuItem_Click(object sender, EventArgs e) { AlarmStatusChange.alarmStatusChange(alarmONToolStripMenuItem, button_alarmon, tManager, AlarmStatusChange.STRIP_CLICK); }

    }
}