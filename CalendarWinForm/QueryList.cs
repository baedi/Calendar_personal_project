namespace CalendarWinForm
{
    static class QueryList {

        // create table. 
        public static string createTableSQL() { return "create table calendarlist (year INT, month INT, day INT, sethour INT, setminute INT, text VARCHAR(21), active BOOLEAN)";}


        // insert sql. 
        public static string insertSQL(string[] dateStr, decimal setH, decimal setM, string text, bool alaEnable) {
            return $"insert into calendarlist values ({dateStr[0]}, {dateStr[1]}, {dateStr[2]}, {setH}, {setM}, \"{text}\", {alaEnable})";
        }


        // listview refresh sql. 
        public static string listviewRefreshSQL(int setY, int setM, int setD) {
            return $"select sethour, setminute, text, active from calendarlist where year = {setY} AND month = {setM} AND day = {setD} order by sethour, setminute ASC;";
        }


        // listBox refresh sql. 
        public static string listBoxRefreshSQL(string[] dateStr) {
            return $"select text from calendarlist where year = {dateStr[0]} AND month = {dateStr[1]} AND day = {dateStr[2]} " +
                    "order by sethour, setminute ASC";
        }


        // update sql.
        public static string updateSQL(string[] dateStr, decimal setH, decimal setM, string text, bool alaEnable, int origH, int origM)
        {
            return $"update calendarlist set (sethour, setminute, text, active) = ({setH},{setM},'{text}',{alaEnable}) " +
                   $"where year = {dateStr[0]} AND month = {dateStr[1]} AND day = {dateStr[2]} AND sethour = {origH} AND setminute = {origM}";
        }


        // update sql (multimode). 
        public static string updateMultiSQL(string[] dateStr, decimal setH, decimal setM, string text, bool alaEnable) {
            return  $"update calendarlist set (text, active) = ('{text}', {alaEnable}) " +
                    $"where year = {int.Parse(dateStr[0])} AND month = {int.Parse(dateStr[1])} AND day = {int.Parse(dateStr[2])} " +
                    $"AND sethour = {setH} AND setminute = {setM}";
        }


        // overlap check sql. 
        public static string overlapCheckSQL(string[] dateStr) {
            return $"select sethour, setminute from calendarlist where year = {dateStr[0]} AND month = {dateStr[1]} AND day = {dateStr[2]};";
        }


        // overlap check sql (multimode). 
        public static string overlapMultiCheckSQL(string[] curDateStr, decimal setH, decimal setM) {
            return "select text, active from calendarlist " +
                    $"where year = {int.Parse(curDateStr[0])} AND month = {int.Parse(curDateStr[1])} AND day = {int.Parse(curDateStr[2])} " +
                    $"AND sethour = {setH} AND setminute = {setM}";
        }


        // delete date sql. 
        public static string deleteDateSQL(int setY, int setM, int setD, int[] datetemp) {
            return $"delete from calendarlist where year = {setY} AND month = {setM} AND day = {setD} AND sethour = {datetemp[0]} AND setminute = {datetemp[1]}";
        }


        // next alarm import. 
        public static string nextAlarmImport(string nowY, string nowM, string nowD) {
            return $"select * from calendarlist where year >= {int.Parse(nowY)} AND month >= {int.Parse(nowM)} AND day >= {int.Parse(nowD)} " +
                    "order by year, month, day, sethour, setminute ASC";
        }
    }
}
