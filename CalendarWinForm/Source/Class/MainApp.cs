using System;
using System.Windows.Forms;
using System.Threading;

namespace CalendarWinForm {
    static class Program {

        [STAThread] static void Main() {
            try {
                Mutex mutex = new Mutex(true, "bdi_calendar");
                TimeSpan wait = new TimeSpan(0, 0, 1);

                if (!mutex.WaitOne(wait)) {
                    MessageBox.Show("Calendar program is already running.");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new CalendarMain());
            } catch(Exception exc) { MessageBox.Show(exc.Message); }
        }

    }


}
