using System.Data.SQLite;

namespace CalendarWinForm {
    class AppManager {
        private static AppManager appManager;
        private static CalendarMain s_main;
        private static SQLiteConnection s_connect;

        // Constructor. 
        public static AppManager GetInstance() {
            if (appManager == null)
                appManager = new AppManager();

            return appManager;
        }

        public CalendarMain S_Main {
            get { return s_main; }
            set { s_main = value; }
        }

        public SQLiteConnection S_Connect {
            get { return s_connect; }
            set { s_connect = value; }
        }
    }
}
