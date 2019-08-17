using System;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace CalenderWinForm
{
    public partial class DataAddForm : Form
    {
        // Instance variable.       
        private SQLiteConnection dbConnect;
        private Label date;


        // Constructor.             
        public DataAddForm(Label date) {
            InitializeComponent();
            this.date = date;
        }


        // button Event.            
        private void button_ok_Click(object sender, EventArgs e) {
            try {
                int length = Encoding.Default.GetBytes(textBox_calendarText.Text).Length;

                if (length <= 20 && length > 0) {
                    string[] dateStr = new string[3];
                    string sql;
                    SQLiteCommand command;

                    dateStr = date.Text.Split('.');

                    // overlap alarm check. 
                    sql = $"select sethour, setminute from calendarlist where year = {dateStr[0]} AND month = {dateStr[1]} AND day = {dateStr[2]};";
                    dbConnect.Open();
                    command = new SQLiteCommand(sql, dbConnect);
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read()) {
                        if (int.Parse(reader["sethour"].ToString()) == numericUpDown_setHour.Value && 
                            int.Parse(reader["setminute"].ToString()) == numericUpDown_setMinute.Value) {
                            MessageBox.Show("Duplicate alarm time.");
                            reader.Close();
                            dbConnect.Close();
                            return;
                        }
                    }
                    dbConnect.Close();


                    // insert data. 
                    sql = $"insert into calendarlist values ({dateStr[0]}, {dateStr[1]}, {dateStr[2]}, {numericUpDown_setHour.Value}, {numericUpDown_setMinute.Value}, \"{textBox_calendarText.Text}\", {checkBox_checkAlarm.Checked})";
                    dbConnect.Open();
                    command = new SQLiteCommand(sql, dbConnect);
                    command.ExecuteNonQuery();
                    dbConnect.Close();

                    MessageBox.Show("Add Schedule Completed");
                    Close();
                }

                else if (length <= 0)
                    MessageBox.Show("You didn't enter anything!");

                else
                    MessageBox.Show("Character size must be no larger than 20.");
            }

            catch (Exception exc) {
                MessageBox.Show("Error : " + exc.Message);
                if (dbConnect.State.ToString() == "Open") dbConnect.Close();
            }
        }

        // get, set Method. 
        public void setDbConnect(SQLiteConnection conn) { dbConnect = conn; }
    }
}
