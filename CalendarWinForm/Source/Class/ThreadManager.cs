using System;
using System.Threading;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CalendarWinForm {
    class ThreadManager {
        private readonly AppManager appManager;
        private readonly Thread manage;
        private readonly Label timeLabel;
        private readonly AlarmMessage alarm_form;

        private DateTime alarm;
        private string alarm_text;
        private bool threadEnable;
        private bool isAlarmExist;


        // Constructor. 
        public ThreadManager(Label label) {

            appManager = AppManager.GetInstance();

            timeLabel = label;
            manage = new Thread(new ThreadStart(WorkingThread));
            alarm_form = new AlarmMessage();

            threadEnable = true;
            NextAlarmReadyRefresh();
            manage.Start();

            alarm_form.Show();
            alarm_form.Visible = false;
        }


        // time refresh. 
        public void NextAlarmReadyRefresh() {
            try {
                isAlarmExist = false;
                decimal[] dateYMD = { decimal.Parse(DateTime.Now.ToString("yyyy")), decimal.Parse(DateTime.Now.ToString("MM")), decimal.Parse(DateTime.Now.ToString("dd")) };

                string sql = new ListSqlQuery().sqlNextAlarmCheck(dateYMD);

                appManager.Connect_calendar.Open();
                appManager.Command_calendar = new SQLiteCommand(sql, appManager.Connect_calendar);
                SQLiteDataReader reader = appManager.Command_calendar.ExecuteReader();

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
                appManager.Connect_calendar.Close();

                TodayAlarmChecked();
            } catch(Exception exc) { MessageBox.Show(exc.Message); }
        }

        // today alarm check. 
        public void TodayAlarmChecked() {
            DateTime today = new DateTime();
            DateTime current = DateTime.Now;
            bool findToday = false;

            try {
                string sql = new ListSqlQuery().sqlListViewRefresh(ListSqlQuery.ALARM_MODE, null);
                appManager.Connect_today.Open();
                appManager.Command_calendar = new SQLiteCommand(sql, appManager.Connect_today);
                SQLiteDataReader reader = appManager.Command_calendar.ExecuteReader();

                // Today alarm confirm.     
                while (reader.Read()){
                    today = new DateTime();

                    today = today.AddYears(current.Year - 1).AddMonths(current.Month - 1).AddDays(current.Day - 1).
                        AddHours((int)reader["sethour"]).AddMinutes((int)reader["setminute"]);

                    if (today <= current) continue;
                    else if(today > current){
                        findToday = true;

                        if (today >= alarm) break;
                        else if (today < alarm) {
                            alarm = today;
                            alarm_text = reader["text"].ToString();
                            break;
                        }
                    }
                }

                reader.Close();

                // Next day confirm.        
                if (!findToday) {
                    reader = appManager.Command_calendar.ExecuteReader();

                    if (reader.Read())
                    {
                        today = new DateTime();

                        today = today.AddYears(current.Year - 1).AddMonths(current.Month - 1).AddDays(current.Day).
                            AddHours((int)reader["sethour"]).AddMinutes((int)reader["setminute"]);

                        if (today <= current) { }
                        else if (today > current) {
                            if (today >= alarm) { }
                            else if (today < alarm) {
                                alarm = today;
                                alarm_text = reader["text"].ToString();
                            }
                        }
                    }

                    reader.Close();
                }

                appManager.Connect_today.Close();

                MessageBox.Show("alarm : " + alarm.Year + "." + alarm.Month + "." + alarm.Day + " " + alarm.Hour + ":" + alarm.Minute);
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
                    NextAlarmReadyRefresh();
                }

                Thread.Sleep(100);
            }
        }


        public void AlarmOnOff_check(bool temp){ alarm_form.setSoundOnOff(temp); }

        // get, set Method. 
        public Thread GetThreadManager() { return manage; }
        public void SetThreadEnable(bool tf) { threadEnable = tf; }
    }
}
