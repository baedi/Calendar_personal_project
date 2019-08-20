using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Collections;

namespace CalenderWinForm
{
    public partial class Form_Calendar_main : Form {

        // variable. 
        private ThreadManager tManager;
        private ListBox[] gbox;
        private int selectYear;
        private int selectMonth;
        private int selectDay;
        private DataAddForm addForm;
        /* private ArrayList dManager; */

        private SQLiteConnection dbConnect;
        private SQLiteCommand dbCommand;

        private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\baedi_calendar";
        private string dbFileName = @"\calender.db";
        private string table = "create table calendarlist (year INT, month INT, day INT, sethour INT, setminute INT, text VARCHAR(21), active BOOLEAN)";

        private bool yearUpDownClick;
        private bool calendarYearClick;
        private int calendar_index;



        // main method. 
        public Form_Calendar_main() {
            InitializeComponent();
            gbox = new ListBox[42];
            tManager = new ThreadManager(label_Time);
            addForm = new DataAddForm(label_DateTemp, this, false);
            /* dManager = new DataManage(); */

            // Database setting. 
            dbConnect = new SQLiteConnection("Data Source=" + path + dbFileName + ";Version=3;");
            dbCommand = new SQLiteCommand(table, dbConnect);
            addForm.setDbConnect(dbConnect);

            if (!File.Exists(path + dbFileName)) {
                Directory.CreateDirectory(path);
                SQLiteConnection.CreateFile(path + dbFileName);
                MessageBox.Show("new calendar db created...");
                dbConnect.Open();
                dbCommand.ExecuteNonQuery();
                dbConnect.Close();
            }

            /*
             try { databaseImport(); } 
            catch(Exception exc) { MessageBox.Show(exc.Message); Close(); }
            */

            // Panel setting. 
            for(int count = 0; count < gbox.Length; count++) gbox[count] = new ListBox();

            // Current date setting. 
            selectDay = int.Parse(DateTime.Now.ToString("dd"));
            numericUpDown_Year.Value = selectYear = int.Parse(DateTime.Now.ToString("yyyy"));
            numericUpDown_Month.Value = selectMonth = int.Parse(DateTime.Now.ToString("MM"));

            for (int row = 1, count = 0; row <= 6; row++)
                for (int col = 0; col < 7; col++) { panel_MonthList.Controls.Add(gbox[count], col, row); count++; }

            label_DateTemp.Text = selectYear.ToString() + "." + selectMonth.ToString() + "." + selectDay.ToString();
        }



        // calendar diary set Method. 
        private void settingCalendar() {
            int maxDays = int.Parse(DateTime.DaysInMonth(selectYear, selectMonth).ToString());
            int blankCount, tempCt;
            DateTime dOfMonth = new DateTime();

            dOfMonth = dOfMonth.AddYears(selectYear - 1).AddMonths(selectMonth - 1);

            switch (dOfMonth.DayOfWeek.ToString()){
                case "Sunday":      blankCount = 7; break;
                case "Monday":      blankCount = 1; break;
                case "Tuesday":     blankCount = 2; break;
                case "Wednesday":   blankCount = 3; break;
                case "Thursday":    blankCount = 4; break;
                case "Friday":      blankCount = 5; break;
                default:            blankCount = 6; break;
            }

            tempCt = blankCount - 1;
            dbConnect.Open();

            for (int row = 1, boxCount = 0, dayCount = 1; row <= 6; row = row + 1)
                for (int col = 0; col < 7; col = col + 1) {

                    if (blankCount > 0 || dayCount > maxDays) {
                        gbox[boxCount].BackColor = System.Drawing.SystemColors.InactiveCaptionText;
                        gbox[boxCount].TabStop = false;
                        blankCount = blankCount - 1;
                    }

                    else {
                        string[] dateStr = new string[3];
                        string sql;


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

                        sql = $"select text from calendarlist where year = {dateStr[0]} AND month = {dateStr[1]} AND day = {dateStr[2]} order by sethour, setminute ASC";
                        dbCommand = new SQLiteCommand(sql, dbConnect);
                        SQLiteDataReader reader = dbCommand.ExecuteReader();
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

            dbConnect.Close();
            gbox[selectDay + tempCt].BackColor = System.Drawing.Color.FromArgb(255, 255, 192);

        }


        public void changeCalendar() {
            for (int count = 0; count < gbox.Length; count++) gbox[count].Items.Clear();

            selectYear = int.Parse(numericUpDown_Year.Value.ToString());
            selectMonth = int.Parse(numericUpDown_Month.Value.ToString());
            settingCalendar();

            button_modifySch.Enabled = false;
            button_deleteSch.Enabled = false;
        }


        // database current day calendar import. 
        public void calendarListRefresh() {
            string sql = $"select sethour, setminute, text, active from calendarlist where year = {selectYear} AND month = {selectMonth} AND day = {selectDay} order by sethour, setminute ASC;";
            dbConnect.Open();

            dbCommand = new SQLiteCommand(sql, dbConnect);
            SQLiteDataReader reader = dbCommand.ExecuteReader();

            listView_Schedule.Items.Clear();


            while (reader.Read()){
                bool active = (bool)reader["active"];

                listView_Schedule.Items.Add(new ListViewItem(new string[] {
                    ((int)reader["sethour"]).ToString("00") + " : " +  ((int)reader["setminute"]).ToString("00"),
                    reader["text"].ToString(),
                    active ? "Y" : "N"
                }));
            }

            reader.Close();
            dbConnect.Close();
        }


        // database import Method. 
        /*
        public void databaseImport() {
            try {
                string sql = $"select * from calendarlist order by year, month, day, sethour, setminute ASC";
                dbConnect.Open();
                dbCommand = new SQLiteCommand(sql, dbConnect);
                SQLiteDataReader reader = dbCommand.ExecuteReader();
                dManager = new DataManage();

                while (reader.Read())
                {
                    dManager.Add(new DataManage(
                        (int)reader["year"],
                        (int)reader["month"],
                        (int)reader["day"],
                        (int)reader["sethour"],
                        (int)reader["setminute"],
                        reader["text"].ToString(),
                        (bool)reader["active"]));
                }
                reader.Close();
                dbConnect.Close();
                
                for(int count = 0; count < dManager.Count; count++) {
                    DataManage temp = (DataManage)dManager[count];
                    MessageBox.Show(temp.Year.ToString() + "\n" + 
                                    temp.Month.ToString() + "\n" + 
                                    temp.Day.ToString() + "\n" + 
                                    temp.Sethour.ToString() + "\n" +
                                    temp.Setminute.ToString() + "\n" +
                                    temp.Text.ToString() + "\n" +
                                    temp.Active.ToString() + "\n");
                }
                

            }catch(Exception exc) { MessageBox.Show("Error : " + exc.Message); }
        }
*/

        // delete select database. 
        private void deleteDBdata() {
            string[] splitstr = new string[2];
            int[] datetemp = new int[2];
            splitstr = listView_Schedule.SelectedItems[0].Text.Split(':');
            datetemp[0] = int.Parse(splitstr[0]);
            datetemp[1] = int.Parse(splitstr[1]);

            // MessageBox.Show(listView_Schedule.SelectedItems[0].SubItems[1].ToString());

            string sql = $"delete from calendarlist where year = {selectYear} AND month = {selectMonth} AND day = {selectDay} AND sethour = {datetemp[0]} AND setminute = {datetemp[1]}";
            dbConnect.Open();

            dbCommand = new SQLiteCommand(sql, dbConnect);
            dbCommand.ExecuteNonQuery();
            dbConnect.Close();

            changeCalendar();
            calendarListRefresh();
        }


        // Year setting (numericUpDown)     
        private void numericUpDown_Year_ValueChanged(object sender, EventArgs e) {
            // MessageBox.Show("numericUpDown_Year active");
            changeCalendar();
            DateTime temp = new DateTime();
            monthCalendar1.SetDate(temp.AddYears(selectYear - 1).AddMonths(selectMonth - 1).AddDays(selectDay - 1));
        }


        // Month setting (numericUpDown)    
        private void numericUpDown_Month_ValueChanged(object sender, EventArgs e) {
            changeCalendar();
            DateTime temp = new DateTime();
            monthCalendar1.SetDate(temp.AddYears(selectYear - 1).AddMonths(selectMonth - 1).AddDays(selectDay - 1));
        }


        // calendar widget Event.           
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e) {
            // MessageBox.Show("monthCalendar1 active");
            selectDay = int.Parse(e.End.ToString("dd"));
            numericUpDown_Year.Value = selectYear = int.Parse(e.End.ToString("yyyy"));
            numericUpDown_Month.Value = selectMonth = int.Parse(e.End.ToString("MM"));

            changeCalendar();
            calendar_index = -1;
            label_DateTemp.Text = e.End.ToString("yyyy") + "." + int.Parse(e.End.ToString("MM")).ToString() + "." + int.Parse(e.End.ToString("dd")).ToString();
        }


        // click location check Event. (main calender click)    
        private void panel_MonthList_MouseDown(object sender, MouseEventArgs e) {
            for(int count = 0; count < gbox.Length; count++) {
                if (gbox[count].Location.X <= e.X &&
                    gbox[count].Location.Y <= e.Y &&
                    gbox[count].Location.X + gbox[count].Size.Width > e.X &&
                    gbox[count].Location.Y + gbox[count].Size.Height > e.Y &&
                    gbox[count].TabStop == true) {

                    DateTime temp = new DateTime();
                    monthCalendar1.SetDate(temp.AddYears(selectYear - 1).AddMonths(selectMonth - 1).AddDays(int.Parse(gbox[count].Items[0].ToString()) - 1));
                    break;
                }
            }
        }
        

        // datetime label text changed Event. 
        private void label_DateTemp_TextChanged(object sender, EventArgs e) { calendarListRefresh(); }


        // schedule click Event.
        private void listView_Schedule_Click(object sender, EventArgs e) {
            foreach (int getIndex in listView_Schedule.SelectedIndices)
                calendar_index = getIndex;

            button_modifySch.Enabled = true;
            button_deleteSch.Enabled = true;
        }

        private void listView_Schedule_DoubleClick(object sender, EventArgs e){
            foreach (int getIndex in listView_Schedule.SelectedIndices)
                MessageBox.Show(getIndex.ToString());
        }


        // "ADD" button click Event.        
        private void button_addSch_Click(object sender, EventArgs e) {

            addForm = new DataAddForm(label_DateTemp, this, false);
            addForm.setDbConnect(dbConnect);
            addForm.Show();
            
        }


        // "Modify" button click Event. 
        private void button_modifySch_Click(object sender, EventArgs e) {
            string[] datalist = new string[2];
            string text = listView_Schedule.SelectedItems[0].SubItems[1].Text.ToString();
            bool actCheck = listView_Schedule.SelectedItems[0].SubItems[2].Text == "Y" ? true : false;

            datalist = listView_Schedule.SelectedItems[0].SubItems[0].Text.Split(':');


            addForm = new DataAddForm(label_DateTemp, this, true);
            addForm.setDbConnect(dbConnect);
            addForm.setSelectData(datalist, text, actCheck);
            addForm.Show();
        }
        
        
        // "Delete" button click Event. 
        private void button_deleteSch_Click(object sender, EventArgs e) {
            if(MessageBox.Show($"Are you sure you want to delete the data?", "", MessageBoxButtons.YesNo) == DialogResult.Yes){
                deleteDBdata();
            }
        }


        // program close Event.             
        private void Form_Calender_main_FormClosed(object sender, FormClosedEventArgs e) {
            try {
                
                tManager.setThreadEnable(false);
                if (tManager.getThreadManager().ThreadState != System.Threading.ThreadState.Stopped)
                    tManager.getThreadManager().Join();
                    
            }
            catch (NullReferenceException exc) { }
        }
    }
}



// Background Image : 
// https://pixabay.com/ko/photos/%EB%B2%BD%EC%A7%80-%EA%B3%B5%EA%B0%84-%EB%B0%94%ED%83%95-%ED%99%94%EB%A9%B4-%EC%9A%B0%EC%A3%BC-3584226/
