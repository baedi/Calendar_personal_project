using System.Data.SQLite;

namespace CalendarWinForm {
    class AppManager {
        private static AppManager appManager;

        // Constructor. 
        public static AppManager GetInstance() {
            if (appManager == null) appManager = new AppManager();
            return appManager;
        }

        public CalendarMain S_Main { get; set; }
        public SQLiteConnection Connect_calendar { get; set; }
        public SQLiteConnection Connect_today { get; set; }
        public SQLiteCommand Command_today { get; set; }
        public SQLiteCommand Command_calendar { get; set; }
    }
}
