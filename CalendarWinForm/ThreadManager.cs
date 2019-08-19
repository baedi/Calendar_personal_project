using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalenderWinForm
{
    class ThreadManager
    {
        private Thread manage;
        // private DateTime current;
        private Label timeLabel;
        private bool threadEnable;


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
            }
        }


        // get, set Method. 
        public Thread getThreadManager() { return manage; }
        public void setThreadEnable(bool tf) { threadEnable = tf; }
    }
}
