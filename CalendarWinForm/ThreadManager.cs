using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace CalenderWinForm
{
    class ThreadManager
    {
        private Thread manage;
        // private DateTime current;
        private Label timeLabel;
        private bool threadEnable;

        private SQLiteConnection dbconnect;
        private string sql;


        // Constructor. 
        public ThreadManager(Label label) {
            timeLabel = label;
            manage = new Thread(new ThreadStart(WorkingThread));
            threadEnable = true;
            manage.Start();
        }


        // Thread Tasks. 
        public void WorkingThread() {
            while (threadEnable){
                timeLabel.Text = DateTime.Now.ToString();

                try {


                }catch(Exception exc) { }
            }
        }


        // get, set Method. 
        public Thread getThreadManager() { return manage; }
        public void setThreadEnable(bool tf) { threadEnable = tf; }
    }
}
