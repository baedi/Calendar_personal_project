namespace CalendarWinForm
{
    partial class DataAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataAddForm));
            this.numericUpDown_setHour = new System.Windows.Forms.NumericUpDown();
            this.label_AlarmTime = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.checkBox_multiMode = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.groupBox_range = new System.Windows.Forms.GroupBox();
            this.label_range = new System.Windows.Forms.Label();
            this.numericUpDown_setMinute = new System.Windows.Forms.NumericUpDown();
            this.label_setHour = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.label_calText = new System.Windows.Forms.Label();
            this.label_setMinute = new System.Windows.Forms.Label();
            this.textBox_calendarText = new System.Windows.Forms.TextBox();
            this.checkBox_checkAlarm = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setHour)).BeginInit();
            this.groupBox_range.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setMinute)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_setHour
            // 
            this.numericUpDown_setHour.Location = new System.Drawing.Point(59, 131);
            this.numericUpDown_setHour.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_setHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDown_setHour.Name = "numericUpDown_setHour";
            this.numericUpDown_setHour.Size = new System.Drawing.Size(55, 25);
            this.numericUpDown_setHour.TabIndex = 0;
            // 
            // label_AlarmTime
            // 
            this.label_AlarmTime.AutoSize = true;
            this.label_AlarmTime.Location = new System.Drawing.Point(11, 134);
            this.label_AlarmTime.Name = "label_AlarmTime";
            this.label_AlarmTime.Size = new System.Drawing.Size(37, 15);
            this.label_AlarmTime.TabIndex = 2;
            this.label_AlarmTime.Text = "Time";
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(6, 244);
            this.button_ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(289, 38);
            this.button_ok.TabIndex = 8;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.Button_ok_Click);
            // 
            // checkBox_multiMode
            // 
            this.checkBox_multiMode.AutoSize = true;
            this.checkBox_multiMode.Location = new System.Drawing.Point(13, 93);
            this.checkBox_multiMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_multiMode.Name = "checkBox_multiMode";
            this.checkBox_multiMode.Size = new System.Drawing.Size(163, 19);
            this.checkBox_multiMode.TabIndex = 9;
            this.checkBox_multiMode.Text = "Multi calendar active";
            this.checkBox_multiMode.UseVisualStyleBackColor = true;
            this.checkBox_multiMode.CheckedChanged += new System.EventHandler(this.CheckBox_multiMode_CheckedChanged);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Enabled = false;
            this.dateTimePicker_end.Location = new System.Drawing.Point(13, 60);
            this.dateTimePicker_end.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(249, 25);
            this.dateTimePicker_end.TabIndex = 11;
            // 
            // groupBox_range
            // 
            this.groupBox_range.Controls.Add(this.label_range);
            this.groupBox_range.Controls.Add(this.numericUpDown_setMinute);
            this.groupBox_range.Controls.Add(this.label_setHour);
            this.groupBox_range.Controls.Add(this.dateTimePicker_start);
            this.groupBox_range.Controls.Add(this.label_AlarmTime);
            this.groupBox_range.Controls.Add(this.checkBox_multiMode);
            this.groupBox_range.Controls.Add(this.label_calText);
            this.groupBox_range.Controls.Add(this.dateTimePicker_end);
            this.groupBox_range.Controls.Add(this.numericUpDown_setHour);
            this.groupBox_range.Controls.Add(this.label_setMinute);
            this.groupBox_range.Controls.Add(this.textBox_calendarText);
            this.groupBox_range.Controls.Add(this.checkBox_checkAlarm);
            this.groupBox_range.Location = new System.Drawing.Point(6, 13);
            this.groupBox_range.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_range.Name = "groupBox_range";
            this.groupBox_range.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_range.Size = new System.Drawing.Size(289, 223);
            this.groupBox_range.TabIndex = 14;
            this.groupBox_range.TabStop = false;
            this.groupBox_range.Text = "Date";
            // 
            // label_range
            // 
            this.label_range.AutoSize = true;
            this.label_range.Location = new System.Drawing.Point(268, 35);
            this.label_range.Name = "label_range";
            this.label_range.Size = new System.Drawing.Size(18, 15);
            this.label_range.TabIndex = 13;
            this.label_range.Text = "~";
            // 
            // numericUpDown_setMinute
            // 
            this.numericUpDown_setMinute.Location = new System.Drawing.Point(168, 131);
            this.numericUpDown_setMinute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_setMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_setMinute.Name = "numericUpDown_setMinute";
            this.numericUpDown_setMinute.Size = new System.Drawing.Size(55, 25);
            this.numericUpDown_setMinute.TabIndex = 1;
            // 
            // label_setHour
            // 
            this.label_setHour.AutoSize = true;
            this.label_setHour.Location = new System.Drawing.Point(116, 138);
            this.label_setHour.Name = "label_setHour";
            this.label_setHour.Size = new System.Drawing.Size(38, 15);
            this.label_setHour.TabIndex = 3;
            this.label_setHour.Text = "Hour";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Location = new System.Drawing.Point(13, 28);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(249, 25);
            this.dateTimePicker_start.TabIndex = 12;
            this.dateTimePicker_start.ValueChanged += new System.EventHandler(this.DateTimePicker_start_ValueChanged);
            // 
            // label_calText
            // 
            this.label_calText.AutoSize = true;
            this.label_calText.Location = new System.Drawing.Point(11, 164);
            this.label_calText.Name = "label_calText";
            this.label_calText.Size = new System.Drawing.Size(36, 15);
            this.label_calText.TabIndex = 5;
            this.label_calText.Text = "Text";
            // 
            // label_setMinute
            // 
            this.label_setMinute.AutoSize = true;
            this.label_setMinute.Location = new System.Drawing.Point(226, 138);
            this.label_setMinute.Name = "label_setMinute";
            this.label_setMinute.Size = new System.Drawing.Size(50, 15);
            this.label_setMinute.TabIndex = 4;
            this.label_setMinute.Text = "Minute";
            // 
            // textBox_calendarText
            // 
            this.textBox_calendarText.Location = new System.Drawing.Point(59, 161);
            this.textBox_calendarText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_calendarText.Name = "textBox_calendarText";
            this.textBox_calendarText.Size = new System.Drawing.Size(217, 25);
            this.textBox_calendarText.TabIndex = 6;
            // 
            // checkBox_checkAlarm
            // 
            this.checkBox_checkAlarm.AutoSize = true;
            this.checkBox_checkAlarm.Checked = true;
            this.checkBox_checkAlarm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_checkAlarm.Location = new System.Drawing.Point(186, 194);
            this.checkBox_checkAlarm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox_checkAlarm.Name = "checkBox_checkAlarm";
            this.checkBox_checkAlarm.Size = new System.Drawing.Size(90, 19);
            this.checkBox_checkAlarm.TabIndex = 7;
            this.checkBox_checkAlarm.Text = "Alarm ON";
            this.checkBox_checkAlarm.UseVisualStyleBackColor = true;
            // 
            // DataAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(301, 287);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.groupBox_range);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataAddForm";
            this.Text = "DataAddModify";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setHour)).EndInit();
            this.groupBox_range.ResumeLayout(false);
            this.groupBox_range.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setMinute)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_setHour;
        private System.Windows.Forms.Label label_AlarmTime;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.CheckBox checkBox_multiMode;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.GroupBox groupBox_range;
        private System.Windows.Forms.Label label_range;
        private System.Windows.Forms.NumericUpDown numericUpDown_setMinute;
        private System.Windows.Forms.Label label_setHour;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.Label label_calText;
        private System.Windows.Forms.Label label_setMinute;
        private System.Windows.Forms.TextBox textBox_calendarText;
        private System.Windows.Forms.CheckBox checkBox_checkAlarm;
    }
}