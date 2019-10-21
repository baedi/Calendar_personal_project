using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarWinForm {
    class ListSqlQuery {

        public const int CALENDAR_MODE = 1;
        public const int ALARM_MODE = 2;

        // CREATE TABLE             
        public string sqlCreateTable(int mode){
            if (mode == CALENDAR_MODE) return "CREATE TABLE calendarlist (year INT, month INT, day INT, sethour INT, setminute INT, text VARCHAR(21), active BOOLEAN);";
            else if (mode == ALARM_MODE) return "CREATE TABLE t_alarmlist (sethour INT, setminute INT, text VARCHAR(21), active BOOLEAN, dot_week VARCHAR(4));";
            return null;
        }

        // INSERT SQL               
        public string sqlInsertValues(int mode, decimal[] setDate, decimal[] setTime, string text, bool alarmEnable) {
            if (mode == CALENDAR_MODE) return $"INSERT INTO calendarlist VALUES ({setDate[0]}, {setDate[1]}, {setDate[2]}, {setTime[0]}, {setTime[1]}, \"{text}\", {alarmEnable})";
            else if (mode == ALARM_MODE) return $"INSERT INTO t_alarmlist VALUES ({setTime[0]}, {setTime[1]}, \"{text}\", true, \" \");";
            return null;
        }

        // CALENDERLIST ALL DATA    
        public string sqlAllCalendarData() {
            return "SELECT * FROM calendarlist ORDER BY year, month, day, sethour, setminute ASC";
        }

        // LISTVIEW REFRESH         
        public string sqlListViewRefresh(int mode, decimal[] dateYMD){
            if (mode == CALENDAR_MODE) return $"SELECT sethour, setminute, text, active FROM calendarlist WHERE year = {dateYMD[0]} AND month = {dateYMD[1]} AND day = {dateYMD[2]} ORDER BY sethour, setminute ASC;";
            else if (mode == ALARM_MODE) return "SELECT sethour, setminute, text FROM t_alarmlist ORDER BY sethour, setminute ASC;";
            return null;
        }

        // LISTBOX REFRESH          
        public string sqlListboxRefresh(decimal[] dateYMD) {
            return $"SELECT text FROM calendarlist WHERE year = {dateYMD[0]} AND month = {dateYMD[1]} AND day = {dateYMD[2]} ORDER BY sethour, setminute ASC";
        }

        // UPDATE SQL               
        public string sqlUpdateData(int mode, decimal[] pastDate, decimal[] pastTime, decimal[] setTime, string text, bool alarmEnable) {
            if (mode == CALENDAR_MODE) return $"UPDATE calendarlist SET (sethour, setminute, text, active) = ({setTime[0]}, {setTime[1]}, '{text}', {alarmEnable}) " +
                                              $"WHERE year = {pastDate[0]} AND month = {pastDate[1]} AND day = {pastDate[2]} AND sethour = {pastTime[0]} AND setminute = {pastTime[1]};";

            else if (mode == ALARM_MODE) return $"UPDATE t_alarmlist SET (sethour, setminute, text) = ({setTime[0]}, {setTime[1]}, '{text}') " +
                                                $"WHERE sethour = {pastTime[0]} AND setminute = {pastTime[1]};";

            return null;
        }

        // OVERLAP CHECK            
        public string sqlOverlapCheck(int mode, decimal[] dateYMD, decimal[] time) {
            if (mode == CALENDAR_MODE) return $"SELECT * FROM calendarlist WHERE year = {dateYMD[0]} AND month = {dateYMD[1]} AND day = {dateYMD[2]} AND sethour = {time[0]} AND setminute = {time[1]};";
            else if (mode == ALARM_MODE) return $"SELECT * FROM t_alarmlist WHERE sethour = {time[0]} AND setminute = {time[1]};";
            return null;
        }

        // DELEDE DATA              
        public string sqlDeleteData(int mode, decimal[] dateYMD, decimal[] time) {
            if (mode == CALENDAR_MODE) return $"DELETE FROM calendarlist WHERE year = {dateYMD[0]} AND month = {dateYMD[1]} AND day = {dateYMD[2]} AND sethour = {time[0]} AND setminute = {time[1]};";
            else if (mode == ALARM_MODE) return $"DELETE FROM t_alarmlist WHERE sethour = {time[0]} AND setminute = {time[1]};";
            return null;
        }

        // NEXT ALARM               
        public string sqlNextAlarmCheck(decimal[] dateYMD) {
            return $"SELECT * FROM calendarlist WHERE year >= {dateYMD[0]} AND month >= {dateYMD[1]} AND day >= {dateYMD[2]} ORDER BY year, month, day, sethour, setminute ASC;";
        }
    }
}
