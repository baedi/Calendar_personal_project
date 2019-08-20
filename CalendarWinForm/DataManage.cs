using System;
using System.Collections;

namespace CalenderWinForm {
    class DataManage : ArrayList {
        private int year;
        private int month;
        private int day;
        private int sethour;
        private int setminute;
        private string text;
        private bool active;

        // Constructor.
        public DataManage() { }
        public DataManage(int y, int m, int d, int sh, int sm, string t, bool a) {
            this.year = y;          this.month = m;
            this.day = d;           this.sethour = sh;
            this.setminute = sm;    this.text = t;
            this.active = a;
        }

        // property. 
        public int Year { get { return year; } set { year = value; } }
        public int Month { get { return month; } set { month = value; } }
        public int Day { get { return day; } set { day = value; } }
        public int Sethour { get { return sethour; } set { sethour = value; } }
        public int Setminute { get { return setminute; } set { setminute = value; } }

        public string Text { get { return text; } set { text = value; } }
        public bool Active { get { return active; } set { active = value; } }

    }
}
