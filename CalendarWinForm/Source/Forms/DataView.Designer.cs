namespace CalendarWinForm
{
    partial class DataView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "yyyy-MM-dd",
            "hh:mm",
            "Hello world!",
            "O or X"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataView));
            this.button_modify = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.listView_allDatalist = new System.Windows.Forms.ListView();
            this.col_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_text = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col_active = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.label_date = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.label_time = new System.Windows.Forms.Label();
            this.numericUpDown_hour = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_minute = new System.Windows.Forms.NumericUpDown();
            this.label_hour = new System.Windows.Forms.Label();
            this.label_minute = new System.Windows.Forms.Label();
            this.label_next = new System.Windows.Forms.Label();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.checkBox_isMulti = new System.Windows.Forms.CheckBox();
            this.label_text = new System.Windows.Forms.Label();
            this.textBox_text = new System.Windows.Forms.TextBox();
            this.checkBox_alarm = new System.Windows.Forms.CheckBox();
            this.button_done = new System.Windows.Forms.Button();
            this.groupBox_mode = new System.Windows.Forms.GroupBox();
            this.label_targetDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minute)).BeginInit();
            this.groupBox_mode.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_modify
            // 
            this.button_modify.Enabled = false;
            this.button_modify.Location = new System.Drawing.Point(392, 365);
            this.button_modify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_modify.Name = "button_modify";
            this.button_modify.Size = new System.Drawing.Size(86, 29);
            this.button_modify.TabIndex = 0;
            this.button_modify.Text = "modify";
            this.button_modify.UseVisualStyleBackColor = true;
            this.button_modify.Click += new System.EventHandler(this.Button_modify_Click);
            // 
            // button_delete
            // 
            this.button_delete.Enabled = false;
            this.button_delete.Location = new System.Drawing.Point(485, 365);
            this.button_delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(86, 29);
            this.button_delete.TabIndex = 1;
            this.button_delete.Text = "delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.Button_delete_Click);
            // 
            // listView_allDatalist
            // 
            this.listView_allDatalist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_date,
            this.col_time,
            this.col_text,
            this.col_active});
            this.listView_allDatalist.HideSelection = false;
            this.listView_allDatalist.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView_allDatalist.Location = new System.Drawing.Point(14, 15);
            this.listView_allDatalist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView_allDatalist.Name = "listView_allDatalist";
            this.listView_allDatalist.Size = new System.Drawing.Size(569, 331);
            this.listView_allDatalist.TabIndex = 2;
            this.listView_allDatalist.UseCompatibleStateImageBehavior = false;
            this.listView_allDatalist.View = System.Windows.Forms.View.Details;
            this.listView_allDatalist.SelectedIndexChanged += new System.EventHandler(this.ListView_allDatalist_SelectedIndexChanged);
            // 
            // col_date
            // 
            this.col_date.Text = "Date";
            this.col_date.Width = 96;
            // 
            // col_time
            // 
            this.col_time.Text = "Time";
            this.col_time.Width = 78;
            // 
            // col_text
            // 
            this.col_text.Text = "Text";
            this.col_text.Width = 225;
            // 
            // col_active
            // 
            this.col_active.Text = "Active";
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(13, 365);
            this.button_refresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(86, 29);
            this.button_refresh.TabIndex = 3;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.Button_refresh_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(300, 365);
            this.button_add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(86, 29);
            this.button_add.TabIndex = 4;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.Button_add_Click);
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(10, 62);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(37, 15);
            this.label_date.TabIndex = 5;
            this.label_date.Text = "Date";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Enabled = false;
            this.dateTimePicker_start.Location = new System.Drawing.Point(12, 81);
            this.dateTimePicker_start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(202, 25);
            this.dateTimePicker_start.TabIndex = 6;
            this.dateTimePicker_start.ValueChanged += new System.EventHandler(this.DateTimePicker_start_ValueChanged);
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(10, 190);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(37, 15);
            this.label_time.TabIndex = 7;
            this.label_time.Text = "Time";
            // 
            // numericUpDown_hour
            // 
            this.numericUpDown_hour.Enabled = false;
            this.numericUpDown_hour.Location = new System.Drawing.Point(12, 209);
            this.numericUpDown_hour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_hour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDown_hour.Name = "numericUpDown_hour";
            this.numericUpDown_hour.Size = new System.Drawing.Size(57, 25);
            this.numericUpDown_hour.TabIndex = 8;
            // 
            // numericUpDown_minute
            // 
            this.numericUpDown_minute.Enabled = false;
            this.numericUpDown_minute.Location = new System.Drawing.Point(129, 209);
            this.numericUpDown_minute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_minute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_minute.Name = "numericUpDown_minute";
            this.numericUpDown_minute.Size = new System.Drawing.Size(57, 25);
            this.numericUpDown_minute.TabIndex = 9;
            // 
            // label_hour
            // 
            this.label_hour.AutoSize = true;
            this.label_hour.Location = new System.Drawing.Point(73, 216);
            this.label_hour.Name = "label_hour";
            this.label_hour.Size = new System.Drawing.Size(38, 15);
            this.label_hour.TabIndex = 10;
            this.label_hour.Text = "Hour";
            // 
            // label_minute
            // 
            this.label_minute.AutoSize = true;
            this.label_minute.Location = new System.Drawing.Point(189, 216);
            this.label_minute.Name = "label_minute";
            this.label_minute.Size = new System.Drawing.Size(50, 15);
            this.label_minute.TabIndex = 11;
            this.label_minute.Text = "Minute";
            // 
            // label_next
            // 
            this.label_next.AutoSize = true;
            this.label_next.Location = new System.Drawing.Point(221, 88);
            this.label_next.Name = "label_next";
            this.label_next.Size = new System.Drawing.Size(18, 15);
            this.label_next.TabIndex = 12;
            this.label_next.Text = "~";
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Enabled = false;
            this.dateTimePicker_end.Location = new System.Drawing.Point(12, 115);
            this.dateTimePicker_end.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(202, 25);
            this.dateTimePicker_end.TabIndex = 13;
            this.dateTimePicker_end.ValueChanged += new System.EventHandler(this.DateTimePicker_end_ValueChanged);
            // 
            // checkBox_isMulti
            // 
            this.checkBox_isMulti.AutoSize = true;
            this.checkBox_isMulti.Enabled = false;
            this.checkBox_isMulti.Location = new System.Drawing.Point(12, 148);
            this.checkBox_isMulti.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_isMulti.Name = "checkBox_isMulti";
            this.checkBox_isMulti.Size = new System.Drawing.Size(144, 19);
            this.checkBox_isMulti.TabIndex = 14;
            this.checkBox_isMulti.Text = "Multi calendar set";
            this.checkBox_isMulti.UseVisualStyleBackColor = true;
            this.checkBox_isMulti.CheckedChanged += new System.EventHandler(this.CheckBox_isMulti_CheckedChanged);
            // 
            // label_text
            // 
            this.label_text.AutoSize = true;
            this.label_text.Location = new System.Drawing.Point(9, 252);
            this.label_text.Name = "label_text";
            this.label_text.Size = new System.Drawing.Size(36, 15);
            this.label_text.TabIndex = 15;
            this.label_text.Text = "Text";
            // 
            // textBox_text
            // 
            this.textBox_text.Enabled = false;
            this.textBox_text.Location = new System.Drawing.Point(12, 271);
            this.textBox_text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_text.Name = "textBox_text";
            this.textBox_text.Size = new System.Drawing.Size(225, 25);
            this.textBox_text.TabIndex = 16;
            // 
            // checkBox_alarm
            // 
            this.checkBox_alarm.AutoSize = true;
            this.checkBox_alarm.Enabled = false;
            this.checkBox_alarm.Location = new System.Drawing.Point(147, 304);
            this.checkBox_alarm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_alarm.Name = "checkBox_alarm";
            this.checkBox_alarm.Size = new System.Drawing.Size(90, 19);
            this.checkBox_alarm.TabIndex = 17;
            this.checkBox_alarm.Text = "Alarm ON";
            this.checkBox_alarm.UseVisualStyleBackColor = true;
            // 
            // button_done
            // 
            this.button_done.Enabled = false;
            this.button_done.Location = new System.Drawing.Point(589, 365);
            this.button_done.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_done.Name = "button_done";
            this.button_done.Size = new System.Drawing.Size(251, 29);
            this.button_done.TabIndex = 18;
            this.button_done.Text = "Done";
            this.button_done.UseVisualStyleBackColor = true;
            this.button_done.Click += new System.EventHandler(this.Button_done_Click);
            // 
            // groupBox_mode
            // 
            this.groupBox_mode.Controls.Add(this.label_targetDate);
            this.groupBox_mode.Controls.Add(this.checkBox_alarm);
            this.groupBox_mode.Controls.Add(this.checkBox_isMulti);
            this.groupBox_mode.Controls.Add(this.dateTimePicker_end);
            this.groupBox_mode.Controls.Add(this.label_text);
            this.groupBox_mode.Controls.Add(this.label_next);
            this.groupBox_mode.Controls.Add(this.textBox_text);
            this.groupBox_mode.Controls.Add(this.dateTimePicker_start);
            this.groupBox_mode.Controls.Add(this.numericUpDown_hour);
            this.groupBox_mode.Controls.Add(this.label_date);
            this.groupBox_mode.Controls.Add(this.label_minute);
            this.groupBox_mode.Controls.Add(this.label_time);
            this.groupBox_mode.Controls.Add(this.label_hour);
            this.groupBox_mode.Controls.Add(this.numericUpDown_minute);
            this.groupBox_mode.Location = new System.Drawing.Point(590, 15);
            this.groupBox_mode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_mode.Name = "groupBox_mode";
            this.groupBox_mode.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_mode.Size = new System.Drawing.Size(251, 331);
            this.groupBox_mode.TabIndex = 19;
            this.groupBox_mode.TabStop = false;
            // 
            // label_targetDate
            // 
            this.label_targetDate.AutoSize = true;
            this.label_targetDate.Location = new System.Drawing.Point(9, 31);
            this.label_targetDate.Name = "label_targetDate";
            this.label_targetDate.Size = new System.Drawing.Size(15, 15);
            this.label_targetDate.TabIndex = 18;
            this.label_targetDate.Text = "-";
            // 
            // DataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 407);
            this.Controls.Add(this.button_done);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.listView_allDatalist);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_modify);
            this.Controls.Add(this.groupBox_mode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataView";
            this.Text = "DataView";
            this.Load += new System.EventHandler(this.DataView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minute)).EndInit();
            this.groupBox_mode.ResumeLayout(false);
            this.groupBox_mode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_modify;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.ListView listView_allDatalist;
        private System.Windows.Forms.ColumnHeader col_date;
        private System.Windows.Forms.ColumnHeader col_time;
        private System.Windows.Forms.ColumnHeader col_text;
        private System.Windows.Forms.ColumnHeader col_active;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.NumericUpDown numericUpDown_hour;
        private System.Windows.Forms.NumericUpDown numericUpDown_minute;
        private System.Windows.Forms.Label label_hour;
        private System.Windows.Forms.Label label_minute;
        private System.Windows.Forms.Label label_next;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.CheckBox checkBox_isMulti;
        private System.Windows.Forms.Label label_text;
        private System.Windows.Forms.TextBox textBox_text;
        private System.Windows.Forms.CheckBox checkBox_alarm;
        private System.Windows.Forms.Button button_done;
        private System.Windows.Forms.GroupBox groupBox_mode;
        private System.Windows.Forms.Label label_targetDate;
    }
}