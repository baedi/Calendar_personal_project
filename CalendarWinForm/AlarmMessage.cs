using System.Windows.Forms;
using System;

namespace CalendarWinForm
{
    public partial class AlarmMessage : Form
    {
        public AlarmMessage()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.TopMost = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //this.TopLevel = true;
        }

        private void button_OK_Click(object sender, System.EventArgs e) { Visible = false; }
        private void AlarmMessage_FormClosing(object sender, FormClosingEventArgs e) { e.Cancel = true; Visible = false; }
        public void setAlarmText(string date, string text) {
            label_date.Text = date;
            label_textscreen.Text = text;
        }
        public void doubleBuffer(){ Invalidate(); }

    }
}
