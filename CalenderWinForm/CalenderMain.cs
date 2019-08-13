using System;
using System.Windows.Forms;

namespace CalenderWinForm
{
    public partial class Form_Calender_main : Form {

        // variable. 
        private ThreadManager tManager;
        private ListBox[] gbox;
        private int selectYear;
        private int selectMonth;


        // main method. 
        public Form_Calender_main() {
            InitializeComponent();
            gbox = new ListBox[42];
            tManager = new ThreadManager(label_Time);

            // Panel setting. 
            for(int count = 0; count < gbox.Length; count++) gbox[count] = new ListBox();


            // Current date setting. 
            numericUpDown_Year.Value = selectYear = int.Parse(DateTime.Now.ToString("yyyy"));
            numericUpDown_Month.Value = selectMonth = int.Parse(DateTime.Now.ToString("MM"));

            for (int row = 1, count = 0; row <= 6; row++)
                for (int col = 0; col < 7; col++) { panel_MonthList.Controls.Add(gbox[count], col, row); count++; }
        }



        // calender diary set Method. 
        private void settingCalender(int year, int month) {

            int maxDays = int.Parse(DateTime.DaysInMonth(year, month).ToString());
            int blankCount;
            DateTime dOfMonth = new DateTime();
            dOfMonth = dOfMonth.AddYears(year - 1).AddMonths(month - 1).AddDays(0);

            switch (dOfMonth.DayOfWeek.ToString()){
                case "Sunday":      blankCount = 7; break;
                case "Monday":      blankCount = 1; break;
                case "Tuesday":     blankCount = 2; break;
                case "Wednesday":   blankCount = 3; break;
                case "Thursday":    blankCount = 4; break;
                case "Friday":      blankCount = 5; break;
                default:            blankCount = 6; break;
            }
            
            for (int row = 1, boxCount = 0, dayCount = 1; row <= 6; row = row + 1 )
                for(int col = 0; col < 7; col = col + 1){

                    if (blankCount > 0 || dayCount > maxDays) {
                        gbox[boxCount].BackColor = System.Drawing.SystemColors.Control;
                        gbox[boxCount].Enabled = false;
                        blankCount = blankCount - 1;
                    }

                    else {
                        gbox[boxCount].BackColor = System.Drawing.SystemColors.Window;
                        gbox[boxCount].Items.Insert(0, dayCount);
                        dayCount = dayCount + 1;
                        gbox[boxCount].Enabled = true;
                    }
                    
                    boxCount = boxCount + 1;
                }
        }


        // ***** Event Method.  ***** 
        private void numericUpDown_Year_ValueChanged(object sender, EventArgs e) { changeCalender(); }
        private void numericUpDown_Month_ValueChanged(object sender, EventArgs e) { changeCalender(); }

        private void changeCalender()
        {
            for (int count = 0; count < gbox.Length; count++) gbox[count].Items.Clear();

            selectYear = int.Parse(numericUpDown_Year.Value.ToString());
            selectMonth = int.Parse(numericUpDown_Month.Value.ToString());
            settingCalender(selectYear, selectMonth);
        }


        // program close. 
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
