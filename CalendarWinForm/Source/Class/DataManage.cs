using System;
using System.Collections;

namespace CalendarWinForm {

    class DataManage : ArrayList {
        private decimal year;
        private decimal month;
        private decimal day;
        private decimal hour;
        private decimal minute;

        // Constructor.
        public DataManage(decimal year, decimal month, decimal day, decimal hour, decimal minute, string text, bool alarm) {
            this.year = year;       this.month = month;         this.day = day;
            this.hour = hour;       this.minute = minute;
            this.Text = text;       this.Active = alarm;
        }

        public DataManage(decimal year, decimal month, decimal day) {
            this.year = year;       this.month = month;         this.day = day;
        }

        public DataManage(decimal hour, decimal minute) {
            this.hour = hour;       this.minute = minute;
        }

        // property. 
        public decimal []YearMonthDay { get { return new decimal[] { year, month, day }; } set { year = value[0]; month = value[1]; day = value[2]; } }
        public decimal []HourMinute { get { return new decimal[] { hour, minute }; } set { hour = value[0]; minute = value[1]; } }
        public string Text { get; set; }
        public bool Active { get; set; }

    }
}
