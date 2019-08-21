using System;
using System.Threading;
using System.Threading.Tasks;
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
        private SQLiteCommand dbcommand;
        private SQLiteDataReader reader;
        private string sql;

        private DateTime alarm;
        private string alarm_text;
        private AlarmMessage alarm_form;


        // Constructor. 
        public ThreadManager(Label label, SQLiteConnection conn) {
            timeLabel = label;
            manage = new Thread(new ThreadStart(WorkingThread));
            alarm_form = new AlarmMessage();

            threadEnable = true;
            dbconnect = conn;
            nextAlarmReadyRefresh();
            manage.Start();


            alarm_form.Show();
            alarm_form.Visible = false;
        }


        // time refresh. 
        public void nextAlarmReadyRefresh() {
            try {
                sql = $"select * from calendarlist where year >= {int.Parse(DateTime.Now.ToString("yyyy"))} AND " +
                      $"month >= {int.Parse(DateTime.Now.ToString("MM"))} AND " +
                      $"day >= {int.Parse(DateTime.Now.ToString("dd"))} " +
                      "order by year, month, day, sethour, setminute ASC";

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
                        alarm_text = reader["text"].ToString();
                        break;

                    }
                }

                reader.Close();
                dbconnect.Close();
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
                    alarm = new DateTime();
                }
         
                if (alarm == new DateTime()) { nextAlarmReadyRefresh(); }

            }
        }


        // get, set Method. 
        public Thread getThreadManager() { return manage; }
        public void setThreadEnable(bool tf) { threadEnable = tf; }

    }
}
