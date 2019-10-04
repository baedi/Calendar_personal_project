using System.Data.SQLite;

namespace CalendarWinForm {
    class AppManager {
        private static AppManager appManager;
        private static CalendarMain s_main;
        private static SQLiteConnection s_connect_calendar;
        private static SQLiteConnection s_connect_today;
        private static SQLiteCommand s_command_calendar;
        private static SQLiteCommand s_command_today;

        // Constructor. 
        public static AppManager GetInstance() {
            if (appManager == null)
                appManager = new AppManager();

            return appManager;
        }


        public CalendarMain S_Main                { get { return s_main; } set { s_main = value; } }
        public SQLiteConnection Connect_calendar  { get { return s_connect_calendar; } set { s_connect_calendar = value; } }
        public SQLiteConnection Connect_today     { get { return s_connect_today; } set { s_connect_today = value; } }
        public SQLiteCommand Command_today        { get { return s_command_today; } set { s_command_today = value; } }
        public SQLiteCommand Command_calendar     { get { return s_command_calendar; } set { s_command_calendar = value; } }
    }
}
