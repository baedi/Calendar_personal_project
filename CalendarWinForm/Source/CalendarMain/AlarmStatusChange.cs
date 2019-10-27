using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarWinForm {
    class AlarmStatusChange {

        public const int BC_FALSE = 0;
        public const int BC_TRUE = 1;
        public const int STRIP_CLICK = 3;

        public static void alarmStatusChange(ToolStripMenuItem alaItem, Button alaButton, ThreadManager tmanager, int mode) {

            if((alaItem.Checked == false && mode == STRIP_CLICK) || mode == BC_TRUE) {
                alaItem.Checked = true;
                alaItem.Text = "Alarm : ON";
                tmanager.AlarmOnOff_check(true);
                AppManager.GetInstance().S_Main.SetAlarmOnCheck(true);
                alaButton.Text = "ON";
            }

            else if((alaItem.Checked == true && mode == STRIP_CLICK) || mode == BC_FALSE) {
                alaItem.Checked = false;
                alaItem.Text = "Alarm : OFF";
                tmanager.AlarmOnOff_check(false);
                AppManager.GetInstance().S_Main.SetAlarmOnCheck(false);
                alaButton.Text = "OFF";
            }

        }

    }
}
