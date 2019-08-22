using System.Windows.Forms;
using System;
using System.Media;

namespace CalendarWinForm
{
    public partial class AlarmMessage : Form
    {
        private SoundPlayer sound;

        public AlarmMessage() {
            InitializeComponent();
            sound = new SoundPlayer(CalendarWinForm.Properties.Resources.alarm2);

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.TopMost = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //this.TopLevel = true;
            
            sound.LoadAsync();
        }

        private void button_OK_Click(object sender, System.EventArgs e) { formHide(); }
        private void AlarmMessage_FormClosing(object sender, FormClosingEventArgs e) { e.Cancel = true; formHide();}
        private void formHide() { sound.Stop(); Visible = false; }

        public void setAlarmText(string date, string text) {
            label_date.Text = date;
            label_textscreen.Text = text;
        }
        public void doubleBuffer(){ Invalidate(); }
        public void soundPlay() { sound.PlayLooping(); }
    }
}
