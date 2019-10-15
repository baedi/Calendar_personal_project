using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarWinForm.Source.Class {
    class ListSqlQuery {

        public const int CALENDAR_MODE = 1;
        public const int ALARM_MODE = 2;

        // CREATE TABLE             
        public string sqlCreateTable(int mode){
            if (mode == CALENDAR_MODE) return "CREATE TABLE calendarlist (year INT, month INT, day INT, sethour INT, setminute INT, text VARCHAR(21), active BOOLEAN);";
            else if (mode == ALARM_MODE) return "CREATE TABLE t_alarmlist (sethour INT, setminute INT, text VARCHAR(21), active BOOLEAN, dot_week VARCHAR(4));";
            else return null;
        }

        // INSERT SQL               
        public string sqlInsertValues(int mode, decimal[] date, decimal[] setTime, string text, bool alarmEnable) {
            if (mode == CALENDAR_MODE) return $"INSERT INTO calendarlist VALUES ({date[0]}, {date[1]}, {date[2]}, {setTime[0]}, {setTime[1]}, \"{text}\", {alarmEnable}";
            else if (mode == ALARM_MODE) return $"INSERT INTO t_alarmlist VALUES ({setTime[0]}, {setTime[1]}, \"{text}\", true, \" \");";
            else return null;
        }

        // CALENDERLIST ALL DATA    
        public string sqlAllCalendarData() {
            return "SELECT * FROM calendarlist ORDER BY year, month, day, sethour, setminute ASC";
        }

        // LISTVIEW REFRESH         
        public string sqlListViewRefresh(int mode, decimal[] setDate){
            if (mode == CALENDAR_MODE) return $"SELECT sethour, setminute, text, active FROM calendarlist WHERE year = {setDate[0]} AND month = {setDate[1]} AND day = {setDate[2]} ORDER BY sethour, setminute ASC;";
            else if (mode == ALARM_MODE) return "SELECT sethour, setminute, text FROM t_alarmlist ORDER BY sethour, setminute ASC;";
            else return null;
        }

        // LISTBOX REFRESH          
        public string sqlListboxRefresh(decimal[] date) {
            return $"SELECT text FROM calendarlist WHERE year = {date[0]} AND month = {date[1]} AND day = {date[3]} ORDER BY sethour, setminute ASC";
        }
    }
}
