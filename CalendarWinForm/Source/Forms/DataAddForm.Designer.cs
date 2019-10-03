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
            this.numericUpDown_setMinute = new System.Windows.Forms.NumericUpDown();
            this.label_AlarmTime = new System.Windows.Forms.Label();
            this.label_setHour = new System.Windows.Forms.Label();
            this.label_setMinute = new System.Windows.Forms.Label();
            this.label_calText = new System.Windows.Forms.Label();
            this.textBox_calendarText = new System.Windows.Forms.TextBox();
            this.checkBox_checkAlarm = new System.Windows.Forms.CheckBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.checkBox_multiMode = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.label_enddate = new System.Windows.Forms.Label();
            this.groupBox_range = new System.Windows.Forms.GroupBox();
            this.groupBox_curdatecheck = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setMinute)).BeginInit();
            this.groupBox_range.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDown_setHour
            // 
            this.numericUpDown_setHour.Location = new System.Drawing.Point(64, 20);
            this.numericUpDown_setHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDown_setHour.Name = "numericUpDown_setHour";
            this.numericUpDown_setHour.Size = new System.Drawing.Size(48, 21);
            this.numericUpDown_setHour.TabIndex = 0;
            // 
            // numericUpDown_setMinute
            // 
            this.numericUpDown_setMinute.Location = new System.Drawing.Point(149, 20);
            this.numericUpDown_setMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_setMinute.Name = "numericUpDown_setMinute";
            this.numericUpDown_setMinute.Size = new System.Drawing.Size(48, 21);
            this.numericUpDown_setMinute.TabIndex = 1;
            // 
            // label_AlarmTime
            // 
            this.label_AlarmTime.AutoSize = true;
            this.label_AlarmTime.Location = new System.Drawing.Point(15, 22);
            this.label_AlarmTime.Name = "label_AlarmTime";
            this.label_AlarmTime.Size = new System.Drawing.Size(38, 12);
            this.label_AlarmTime.TabIndex = 2;
            this.label_AlarmTime.Text = "Alarm";
            // 
            // label_setHour
            // 
            this.label_setHour.AutoSize = true;
            this.label_setHour.Location = new System.Drawing.Point(118, 25);
            this.label_setHour.Name = "label_setHour";
            this.label_setHour.Size = new System.Drawing.Size(13, 12);
            this.label_setHour.TabIndex = 3;
            this.label_setHour.Text = "H";
            // 
            // label_setMinute
            // 
            this.label_setMinute.AutoSize = true;
            this.label_setMinute.Location = new System.Drawing.Point(203, 25);
            this.label_setMinute.Name = "label_setMinute";
            this.label_setMinute.Size = new System.Drawing.Size(16, 12);
            this.label_setMinute.TabIndex = 4;
            this.label_setMinute.Text = "M";
            // 
            // label_calText
            // 
            this.label_calText.AutoSize = true;
            this.label_calText.Location = new System.Drawing.Point(15, 53);
            this.label_calText.Name = "label_calText";
            this.label_calText.Size = new System.Drawing.Size(30, 12);
            this.label_calText.TabIndex = 5;
            this.label_calText.Text = "Text";
            // 
            // textBox_calendarText
            // 
            this.textBox_calendarText.Location = new System.Drawing.Point(64, 50);
            this.textBox_calendarText.Name = "textBox_calendarText";
            this.textBox_calendarText.Size = new System.Drawing.Size(155, 21);
            this.textBox_calendarText.TabIndex = 6;
            // 
            // checkBox_checkAlarm
            // 
            this.checkBox_checkAlarm.AutoSize = true;
            this.checkBox_checkAlarm.Checked = true;
            this.checkBox_checkAlarm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_checkAlarm.Location = new System.Drawing.Point(132, 77);
            this.checkBox_checkAlarm.Name = "checkBox_checkAlarm";
            this.checkBox_checkAlarm.Size = new System.Drawing.Size(94, 16);
            this.checkBox_checkAlarm.TabIndex = 7;
            this.checkBox_checkAlarm.Text = "Alarm active";
            this.checkBox_checkAlarm.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(225, 17);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(68, 76);
            this.button_ok.TabIndex = 8;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // checkBox_multiMode
            // 
            this.checkBox_multiMode.AutoSize = true;
            this.checkBox_multiMode.Location = new System.Drawing.Point(17, 77);
            this.checkBox_multiMode.Name = "checkBox_multiMode";
            this.checkBox_multiMode.Size = new System.Drawing.Size(109, 16);
            this.checkBox_multiMode.TabIndex = 9;
            this.checkBox_multiMode.Text = "Multi set active";
            this.checkBox_multiMode.UseVisualStyleBackColor = true;
            this.checkBox_multiMode.CheckedChanged += new System.EventHandler(this.checkBox_multiMode_CheckedChanged);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Enabled = false;
            this.dateTimePicker_end.Location = new System.Drawing.Point(63, 14);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(226, 21);
            this.dateTimePicker_end.TabIndex = 11;
            // 
            // label_enddate
            // 
            this.label_enddate.AutoSize = true;
            this.label_enddate.Location = new System.Drawing.Point(10, 20);
            this.label_enddate.Name = "label_enddate";
            this.label_enddate.Size = new System.Drawing.Size(47, 12);
            this.label_enddate.TabIndex = 13;
            this.label_enddate.Text = "Start  ~";
            // 
            // groupBox_range
            // 
            this.groupBox_range.Controls.Add(this.label_enddate);
            this.groupBox_range.Controls.Add(this.dateTimePicker_end);
            this.groupBox_range.Location = new System.Drawing.Point(5, 115);
            this.groupBox_range.Name = "groupBox_range";
            this.groupBox_range.Size = new System.Drawing.Size(295, 43);
            this.groupBox_range.TabIndex = 14;
            this.groupBox_range.TabStop = false;
            this.groupBox_range.Text = "Range";
            // 
            // groupBox_curdatecheck
            // 
            this.groupBox_curdatecheck.Location = new System.Drawing.Point(5, 3);
            this.groupBox_curdatecheck.Name = "groupBox_curdatecheck";
            this.groupBox_curdatecheck.Size = new System.Drawing.Size(295, 106);
            this.groupBox_curdatecheck.TabIndex = 15;
            this.groupBox_curdatecheck.TabStop = false;
            this.groupBox_curdatecheck.Text = "2019.01.01";
            // 
            // DataAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(305, 163);
            this.Controls.Add(this.checkBox_multiMode);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.checkBox_checkAlarm);
            this.Controls.Add(this.textBox_calendarText);
            this.Controls.Add(this.label_calText);
            this.Controls.Add(this.label_setMinute);
            this.Controls.Add(this.label_setHour);
            this.Controls.Add(this.label_AlarmTime);
            this.Controls.Add(this.numericUpDown_setMinute);
            this.Controls.Add(this.numericUpDown_setHour);
            this.Controls.Add(this.groupBox_range);
            this.Controls.Add(this.groupBox_curdatecheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataAddForm";
            this.Text = "DataAddModify";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setMinute)).EndInit();
            this.groupBox_range.ResumeLayout(false);
            this.groupBox_range.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_setHour;
        private System.Windows.Forms.NumericUpDown numericUpDown_setMinute;
        private System.Windows.Forms.Label label_AlarmTime;
        private System.Windows.Forms.Label label_setHour;
        private System.Windows.Forms.Label label_setMinute;
        private System.Windows.Forms.Label label_calText;
        private System.Windows.Forms.TextBox textBox_calendarText;
        private System.Windows.Forms.CheckBox checkBox_checkAlarm;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.CheckBox checkBox_multiMode;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.Label label_enddate;
        private System.Windows.Forms.GroupBox groupBox_range;
        private System.Windows.Forms.GroupBox groupBox_curdatecheck;
    }
}