using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace CalendarWinForm
{
    public partial class CalendarMain : Form
    {

        // variable.                                            
        private AppManager appManager;

        private ThreadManager tManager;
        private ListBox[] gbox;
        private DataAddForm addForm;
        private TodayDataAddForm addForm_today;
        private DataView dataview;

        private int selectYear;
        private int selectMonth;
        private int selectDay;
        private int gbox_index;
        private bool alarm_onCheck;
        private bool real_exit;
        private bool isSelectedDate;

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
            addForm_today = new TodayDataAddForm(this);

            // singleton Instance. 
            appManager = AppManager.GetInstance();
            appManager.S_Main = this;

            // Database setting. 
            appManager.Connect_calendar = new SQLiteConnection("Data Source=" + path + dbFileName + ";Version=3;");
            appManager.Connect_today = new SQLiteConnection("Data Source=" + path + dbFileName2 + ";Version=3;");
            addForm.setDbConnect(appManager.Connect_calendar);
            addForm_today.setDbConnect(appManager.Connect_today);

            if (!File.Exists(path + dbFileName))
            {
                appManager.Command_calendar = new SQLiteCommand(QueryList.createTableSQL(), appManager.Connect_calendar);
                Directory.CreateDirectory(path);
                SQLiteConnection.CreateFile(path + dbFileName);
                MessageBox.Show("Created new calendar db.");
                appManager.Connect_calendar.Open();
                appManager.Command_calendar.ExecuteNonQuery();
                appManager.Connect_calendar.Close();
            }

            if (!File.Exists(path + dbFileName2))
            {
                appManager.Command_today = new SQLiteCommand(QueryList.createTableSQL_today(), appManager.Connect_today);
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                SQLiteConnection.CreateFile(path + dbFileName2);
                MessageBox.Show("Created new today alarm db.");
                appManager.Connect_today.Open();
                appManager.Command_today.ExecuteNonQuery();
                appManager.Connect_today.Close();
            }



            tManager = new ThreadManager(label_Time/*, appManager.Connect_calendar, appManager.Connect_today*/);    // Thread setting.  
            dataview = new DataView(appManager.Connect_calendar, this);                           // DataView setting.


            // Panel setting.                                   
            for (int count = 0; count < gbox.Length; count++) gbox[count] = new ListBox();

            // Current date setting. 
            selectDay = int.Parse(DateTime.Now.ToString("dd"));
            selectYear = int.Parse(DateTime.Now.ToString("yyyy"));
            selectMonth = int.Parse(DateTime.Now.ToString("MM"));

            for (int row = 1, count = 0; row <= 6; row++)
                for (int col = 0; col < 7; col++) { panel_MonthList.Controls.Add(gbox[count], col, row); count++; }

            label_DateTemp.Text = selectYear.ToString() + "." + selectMonth.ToString() + "." + selectDay.ToString();
            label_YearMonth.Text = selectYear.ToString() + "." + selectMonth.ToString("00");
            changeCalendar();
            todayAlarmListRefresh();
        }



        // calendar diary set Method.                           
        private void settingCalendar()
        {
            int maxDays = int.Parse(DateTime.DaysInMonth(selectYear, selectMonth).ToString());
            int blankCount, tempCt;
            DateTime dOfMonth = new DateTime();

            dOfMonth = dOfMonth.AddYears(selectYear - 1).AddMonths(selectMonth - 1);

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

                    if (blankCount > 0 || dayCount > maxDays)
                    {
                        gbox[boxCount].BackColor = System.Drawing.SystemColors.InactiveCaptionText;
                        gbox[boxCount].TabStop = false;
                        blankCount = blankCount - 1;
                    }

                    else
                    {
                        string[] dateStr = new string[3];

                        // Calender Panel color setting.
                        if (DateTime.Now.ToString("yyyy-MM") == (selectYear.ToString() + "-" + selectMonth.ToString("00")) && dayCount == int.Parse(DateTime.Now.ToString("dd")))
                            gbox[dayCount + tempCt].BackColor = System.Drawing.Color.FromArgb(192, 255, 255);

                        else if (dOfMonth.DayOfWeek.ToString() == "Sunday")
                            gbox[boxCount].BackColor = System.Drawing.Color.FromArgb(255, 192, 192);

                        else if (dOfMonth.DayOfWeek.ToString() == "Saturday")
                            gbox[boxCount].BackColor = System.Drawing.Color.FromArgb(192, 192, 255);

                        else gbox[boxCount].BackColor = System.Drawing.SystemColors.Window;


                        // database setting. 
                        dateStr = dOfMonth.ToString("yyyy-MM-dd").Split('-');
                        dateStr[1] = int.Parse(dateStr[1]).ToString();
                        dateStr[2] = int.Parse(dateStr[2]).ToString();

                        appManager.Command_calendar = new SQLiteCommand(QueryList.listBoxRefreshSQL(dateStr), appManager.Connect_calendar);
                        SQLiteDataReader reader = appManager.Command_calendar.ExecuteReader();
                        gbox[boxCount].Items.Insert(0, dayCount);

                        int moreCount = 0;
                        for (int count = 1; reader.Read(); count = count + 1)
                        {
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

            gbox_index = selectDay + tempCt;
            gbox[gbox_index].BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            //MessageBox.Show("Refresh Database");
            dataview.refreshData();
        }


        public void changeCalendar()
        {
            for (int count = 0; count < gbox.Length; count++) gbox[count].Items.Clear();
            settingCalendar();
            button_modifySch.Enabled = false;
            button_deleteSch.Enabled = false;
        }


        // database current day calendar import.                
        public void calendarListRefresh()
        {
            appManager.Connect_calendar.Open();
            listView_Schedule.Items.Clear();

            appManager.Command_calendar = new SQLiteCommand(QueryList.listviewRefreshSQL(selectYear, selectMonth, selectDay), appManager.Connect_calendar);
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

            dataview.refreshData();
        }

        // database(today) current day calendar import.
        public void todayAlarmListRefresh()
        {
            appManager.Connect_today.Open();
            listView_todayList.Items.Clear();

            appManager.Command_today = new SQLiteCommand(QueryList.listviewTodayRefreshSQL(), appManager.Connect_today);
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
        public void selectBoxDataRefresh(ListBox selectBox, string[] dateStr)
        {
            int dayItem = (int)selectBox.Items[0];
            selectBox.Items.Clear();
            selectBox.Items.Insert(0, dayItem);

            appManager.Connect_calendar.Open();
            SQLiteCommand command = new SQLiteCommand(QueryList.listBoxRefreshSQL(dateStr), appManager.Connect_calendar);
            SQLiteDataReader reader = command.ExecuteReader();

            int moreCount = 0;
            for (int count = 1; reader.Read(); count = count + 1)
            {
                if (count >= 4) moreCount = moreCount + 1;
                else selectBox.Items.Insert(count, reader["text"].ToString());
            }

            if (moreCount > 0) selectBox.Items.Insert(4, "(...more " + moreCount + ")");
            reader.Close();
            appManager.Connect_calendar.Close();
        }


        // delete select database.                              
        private void deleteDBdata(int index)
        {
            string[] splitstr = new string[2];
            int[] datetemp = new int[2];
            splitstr = listView_Schedule.Items[index].Text.Split(':');
            datetemp[0] = int.Parse(splitstr[0]);
            datetemp[1] = int.Parse(splitstr[1]);

            // MessageBox.Show(listView_Schedule.SelectedItems[0].SubItems[1].ToString());
            appManager.Connect_calendar.Open();

            appManager.Command_calendar = new SQLiteCommand(QueryList.deleteDateSQL(selectYear, selectMonth, selectDay, datetemp), appManager.Connect_calendar);
            appManager.Command_calendar.ExecuteNonQuery();
            appManager.Connect_calendar.Close();
        }

        private void deleteDBdata_today(int index)
        {
            string[] splitstr = new string[2];
            int[] datetemp = new int[2];
            splitstr = listView_todayList.Items[index].Text.Split(':');
            datetemp[0] = int.Parse(splitstr[0]);
            datetemp[1] = int.Parse(splitstr[1]);

            appManager.Connect_today.Open();
            appManager.Command_today = new SQLiteCommand(QueryList.deleteDateSQL_today(datetemp), appManager.Connect_today);
            appManager.Command_today.ExecuteNonQuery();
            appManager.Connect_today.Close();
        }





        // calendar widget Event.                               
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            int cval = selectDay;
            int temp = selectDay;
            selectDay = int.Parse(e.End.ToString("dd"));

            if (int.Parse(e.Start.Year.ToString()) == selectYear &&
                int.Parse(e.Start.Month.ToString()) == selectMonth)
            {
                cval = selectDay - cval;
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
                if (DateTime.Now.ToString("yyyy-MM-dd") == (selectYear.ToString() + "-" + selectMonth.ToString("00") + "-" + temp.ToString("00")))
                    gbox[gbox_index].BackColor = System.Drawing.Color.FromArgb(192, 255, 255);


                // selected 
                gbox_index = gbox_index + cval;
                gbox[gbox_index].BackColor = System.Drawing.Color.FromArgb(255, 255, 192);

                button_modifySch.Enabled = false;
                button_deleteSch.Enabled = false;
            }


            else
            {
                selectYear = int.Parse(e.End.ToString("yyyy"));
                selectMonth = int.Parse(e.End.ToString("MM"));
                changeCalendar();
            }

            label_DateTemp.Text = e.End.ToString("yyyy") + "." + int.Parse(e.End.ToString("MM")).ToString() + "." + int.Parse(e.End.ToString("dd")).ToString();
            label_YearMonth.Text = e.End.ToString("yyyy") + "." + (int.Parse(e.End.ToString("MM")).ToString("00"));
            //calendar_index = -1;        // index reset. 
        }


        // click location check Event. (main calender click)    
        private void panel_MonthList_MouseDown(object sender, MouseEventArgs e)
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
                    monthCalendar1.SetDate(temp.AddYears(selectYear - 1).AddMonths(selectMonth - 1).AddDays(int.Parse(gbox[count].Items[0].ToString()) - 1));
                    isSelectedDate = true;
                    return;
                }
            }

            isSelectedDate = false;
        }

        // double click event. (open DataAddForm)               
        private void Panel_MonthList_DoubleClick(object sender, EventArgs e)
        {
            if (isSelectedDate) this.button_addSch_Click(null, null);

        }


        // datetime label text changed Event.                   
        private void label_DateTemp_TextChanged(object sender, EventArgs e) { calendarListRefresh(); }


        // schedule click Event.                                
        private void listView_Schedule_Click(object sender, EventArgs e)
        {
            //foreach (int getIndex in listView_Schedule.SelectedIndices) calendar_index = getIndex;
            button_modifySch.Enabled = true;
            button_deleteSch.Enabled = true;
        }

        private void listView_Schedule_DoubleClick(object sender, EventArgs e)
        {
            foreach (int getIndex in listView_Schedule.SelectedIndices)
                MessageBox.Show(getIndex.ToString());
        }


        // today schedule click Event.
        private void ListView_todayList_Click(object sender, EventArgs e)
        {
            button_today_delete.Enabled = true;
        }



        // "ADD" button click Event.                            
        private void button_addSch_Click(object sender, EventArgs e)
        {
            addForm = new DataAddForm(label_DateTemp, this, false);
            addForm.gboxSetting(gbox[gbox_index]);
            addForm.setDbConnect(appManager.Connect_calendar);
            addForm.Show();
        }

        // "ADD" button click Event. (Today)                    
        private void Button_today_add_Click(object sender, EventArgs e)
        {
            addForm_today = new TodayDataAddForm(this);
            addForm_today.setDbConnect(appManager.Connect_today);
            addForm_today.Show();
        }


        // "Modify" button click Event.                         
        private void button_modifySch_Click(object sender, EventArgs e)
        {
            string[] datalist = new string[2];
            string text = listView_Schedule.SelectedItems[0].SubItems[1].Text.ToString();
            bool actCheck = listView_Schedule.SelectedItems[0].SubItems[2].Text == "Y" ? true : false;

            datalist = listView_Schedule.SelectedItems[0].SubItems[0].Text.Split(':');

            addForm = new DataAddForm(label_DateTemp, this, true);
            addForm.gboxSetting(gbox[gbox_index]);
            addForm.setDbConnect(appManager.Connect_calendar);
            addForm.setSelectData(datalist, text, actCheck);
            addForm.Show();
        }

        // "MODIFY" button click Event. (Today)                 
        private void Button_today_modify_Click(object sender, EventArgs e)
        {

            /* coming soon */

        }


        // "Delete" button click Event.                         
        private void button_deleteSch_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete the data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int count = listView_Schedule.Items.Count - 1; count >= 0; count = count - 1)
                    if (listView_Schedule.Items[count].Selected == true) deleteDBdata(count);

                string[] tempStr = new string[3];
                tempStr[0] = selectYear.ToString();
                tempStr[1] = selectMonth.ToString();
                tempStr[2] = selectDay.ToString();
                selectBoxDataRefresh(gbox[gbox_index], tempStr);
                calendarListRefresh();

                refreshAlarm();
            }
        }

        // "DELETE" button click Event. (Today)                 
        private void Button_today_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete the data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int count = listView_todayList.Items.Count - 1; count >= 0; count = count - 1)
                    if (listView_todayList.Items[count].Selected == true) deleteDBdata_today(count);

                todayAlarmListRefresh();
                refreshAlarm();
            }

        }


        // "Alarm ON button click Event.                        
        private void button_alarmon_Click(object sender, EventArgs e) { AlarmStatusChange.alarmStatusChange(alarmONToolStripMenuItem, button_alarmon, tManager, alarm_onCheck ? AlarmStatusChange.BC_FALSE : AlarmStatusChange.BC_TRUE); }


        // program close Event.                                 
        private void Form_Calendar_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (real_exit)
            {
                try
                {
                    tManager.setThreadEnable(false);
                    if (tManager.getThreadManager().ThreadState != System.Threading.ThreadState.Stopped) tManager.getThreadManager().Join();
                }
                catch (NullReferenceException exc) { }
            }

            else
            {
                e.Cancel = true;
                Visible = false;
            }
        }

        // data view mode. 
        private void button_dataview_Click(object sender, EventArgs e)
        {
            try { dataview.Show(); }
            catch (ObjectDisposedException exc) { dataview = new DataView(appManager.Connect_calendar, this); dataview.Show(); }
        }

        // get, set Method. 
        public void refreshAlarm() { tManager.nextAlarmReadyRefresh(); }
        public void setAlarmOnCheck(bool temp) { alarm_onCheck = temp; }


        // trayicon Event. 
        private void trayicon_MouseDoubleClick(object sender, MouseEventArgs e) { Visible = true; }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) { real_exit = true; Close(); }
        private void DataViewToolStripMenuItem_Click(object sender, EventArgs e) { button_dataview_Click(null, null); }
        private void AlarmONToolStripMenuItem_Click(object sender, EventArgs e) { AlarmStatusChange.alarmStatusChange(alarmONToolStripMenuItem, button_alarmon, tManager, AlarmStatusChange.STRIP_CLICK); }

    }
}