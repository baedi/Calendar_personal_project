using System;
using System.Threading;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CalendarWinForm
{
    class ThreadManager
    {
        private Thread manage;
        private Label timeLabel;
        private bool threadEnable;

        private SQLiteConnection dbconnect;
        private SQLiteConnection dbconnect2;
        private SQLiteCommand dbcommand;
        private SQLiteDataReader reader;
        private string sql;

        private DateTime alarm;
        private string alarm_text;
        private AlarmMessage alarm_form;
        private bool isAlarmExist;


        // Constructor. 
        public ThreadManager(Label label, SQLiteConnection conn, SQLiteConnection conn2) {
            timeLabel = label;
            manage = new Thread(new ThreadStart(WorkingThread));
            alarm_form = new AlarmMessage();

            threadEnable = true;
            dbconnect = conn;
            dbconnect2 = conn2;
            nextAlarmReadyRefresh();
            manage.Start();


            alarm_form.Show();
            alarm_form.Visible = false;
        }


        // time refresh. 
        public void nextAlarmReadyRefresh() {
            try {
                isAlarmExist = false;

                sql = QueryList.nextAlarmImport(DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("dd"));

                dbconnect.Open();
                dbcommand = new SQLiteCommand(sql, dbconnect);
                reader = dbcommand.ExecuteReader();

                while (reader.Read()) {
                    alarm = new DateTime();

                    if ((bool)reader["active"] == true) {

                        alarm = alarm.AddYears((int)reader["year"] - 1).
                                      AddMonths((int)reader["month"] - 1).
                                      AddDays((int)reader["day"] - 1).
                                      AddHours((int)reader["sethour"]).
                                      AddMinutes((int)reader["setminute"]);
                        
                        if (alarm < DateTime.Now) continue;
                        isAlarmExist = true;
                        alarm_text = reader["text"].ToString();
                        break;
                    }
                }

                if (!isAlarmExist) {
                    alarm = new DateTime();
                    alarm = alarm.AddYears(9997);
                    alarm_text = "alarm disable.";
                }

                reader.Close();
                dbconnect.Close();

                // todayAlarmChecked();
            } catch(Exception exc) { MessageBox.Show(exc.Message); }
        }

        // today alarm check. 
        public void todayAlarmChecked() {
            DateTime current = DateTime.Now;
            DateTime temp_normal = new DateTime();
            DateTime temp_nextday = new DateTime();
            string temp_str_normal;
            string temp_str_nextday;
            bool tdalarmReady = false;

            try {
                sql = QueryList.listviewTodayRefreshSQL();
                dbconnect2.Open();
                dbcommand = new SQLiteCommand(sql, dbconnect2);
                reader = dbcommand.ExecuteReader();

                while (reader.Read()){
                    if (alarm.Hour > (int)reader["sethour"] ||
                        (alarm.Hour == (int)reader["sethour"] && alarm.Minute > (int)reader["setminute"])) {

                        temp_normal = new DateTime();
                        temp_normal = temp_normal.AddYears(current.Year - 1).
                                        AddMonths(current.Month - 1).
                                        AddDays(current.Day - 1).
                                        AddHours((int)reader["sethour"]).
                                        AddMinutes((int)reader["setminute"]);

                        temp_str_normal = reader["text"].ToString();
                        tdalarmReady = true;
                    }
                    else break;
                }

                if (tdalarmReady) {
                    if(current < temp_normal && temp_normal > alarm) {



                    }
                }

                reader.Close();
                reader = dbcommand.ExecuteReader();
                if (reader.Read()) {
                    temp_nextday = temp_nextday.AddYears(current.Year - 1).
                                    AddMonths(current.Month - 1).
                                    AddDays(current.Day).
                                    AddHours((int)reader["sethour"]).
                                    AddMinutes((int)reader["setminute"]);

                    temp_str_nextday = reader["text"].ToString();
                }

                reader.Close();
                dbconnect2.Close();




                MessageBox.Show(alarm.Year + " " + alarm.Month + " " + alarm.Day + " " + alarm.Hour + " " + alarm.Minute);
            } catch(Exception exc) { MessageBox.Show(exc.Message); }
        }


        // Thread Tasks. 
        public void WorkingThread() {
            while (threadEnable){
                timeLabel.Text = DateTime.Now.ToString();

                if (alarm < DateTime.Now) {
                    alarm_form.setAlarmText(alarm.ToString(), alarm_text);
                    alarm_form.Visible = true;
                    alarm_form.doubleBuffer();
                    alarm_form.soundPlay();
                    nextAlarmReadyRefresh();
                }

                Thread.Sleep(100);
            }
        }


        public void alarmOnOff_check(bool temp){ alarm_form.setSoundOnOff(temp); }

        // get, set Method. 
        public Thread getThreadManager() { return manage; }
        public void setThreadEnable(bool tf) { threadEnable = tf; }
    }
}
