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
            this.numericUpDown_setHour = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_setMinute = new System.Windows.Forms.NumericUpDown();
            this.label_AlarmTime = new System.Windows.Forms.Label();
            this.label_setHour = new System.Windows.Forms.Label();
            this.label_setMinute = new System.Windows.Forms.Label();
            this.label_calText = new System.Windows.Forms.Label();
            this.textBox_calendarText = new System.Windows.Forms.TextBox();
            this.checkBox_checkAlarm = new System.Windows.Forms.CheckBox();
            this.button_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setMinute)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_setHour
            // 
            this.numericUpDown_setHour.Location = new System.Drawing.Point(70, 12);
            this.numericUpDown_setHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numericUpDown_setHour.Name = "numericUpDown_setHour";
            this.numericUpDown_setHour.Size = new System.Drawing.Size(42, 21);
            this.numericUpDown_setHour.TabIndex = 0;
            // 
            // numericUpDown_setMinute
            // 
            this.numericUpDown_setMinute.Location = new System.Drawing.Point(143, 12);
            this.numericUpDown_setMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown_setMinute.Name = "numericUpDown_setMinute";
            this.numericUpDown_setMinute.Size = new System.Drawing.Size(42, 21);
            this.numericUpDown_setMinute.TabIndex = 1;
            // 
            // label_AlarmTime
            // 
            this.label_AlarmTime.AutoSize = true;
            this.label_AlarmTime.Location = new System.Drawing.Point(11, 14);
            this.label_AlarmTime.Name = "label_AlarmTime";
            this.label_AlarmTime.Size = new System.Drawing.Size(38, 12);
            this.label_AlarmTime.TabIndex = 2;
            this.label_AlarmTime.Text = "Alarm";
            // 
            // label_setHour
            // 
            this.label_setHour.AutoSize = true;
            this.label_setHour.Location = new System.Drawing.Point(114, 16);
            this.label_setHour.Name = "label_setHour";
            this.label_setHour.Size = new System.Drawing.Size(13, 12);
            this.label_setHour.TabIndex = 3;
            this.label_setHour.Text = "H";
            // 
            // label_setMinute
            // 
            this.label_setMinute.AutoSize = true;
            this.label_setMinute.Location = new System.Drawing.Point(188, 16);
            this.label_setMinute.Name = "label_setMinute";
            this.label_setMinute.Size = new System.Drawing.Size(16, 12);
            this.label_setMinute.TabIndex = 4;
            this.label_setMinute.Text = "M";
            // 
            // label_calText
            // 
            this.label_calText.AutoSize = true;
            this.label_calText.Location = new System.Drawing.Point(11, 45);
            this.label_calText.Name = "label_calText";
            this.label_calText.Size = new System.Drawing.Size(30, 12);
            this.label_calText.TabIndex = 5;
            this.label_calText.Text = "Text";
            // 
            // textBox_calendarText
            // 
            this.textBox_calendarText.Location = new System.Drawing.Point(70, 42);
            this.textBox_calendarText.Name = "textBox_calendarText";
            this.textBox_calendarText.Size = new System.Drawing.Size(134, 21);
            this.textBox_calendarText.TabIndex = 6;
            // 
            // checkBox_checkAlarm
            // 
            this.checkBox_checkAlarm.AutoSize = true;
            this.checkBox_checkAlarm.Checked = true;
            this.checkBox_checkAlarm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_checkAlarm.Location = new System.Drawing.Point(12, 77);
            this.checkBox_checkAlarm.Name = "checkBox_checkAlarm";
            this.checkBox_checkAlarm.Size = new System.Drawing.Size(94, 16);
            this.checkBox_checkAlarm.TabIndex = 7;
            this.checkBox_checkAlarm.Text = "Alarm active";
            this.checkBox_checkAlarm.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(129, 73);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 8;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // DataAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 105);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.checkBox_checkAlarm);
            this.Controls.Add(this.textBox_calendarText);
            this.Controls.Add(this.label_calText);
            this.Controls.Add(this.label_setMinute);
            this.Controls.Add(this.label_setHour);
            this.Controls.Add(this.label_AlarmTime);
            this.Controls.Add(this.numericUpDown_setMinute);
            this.Controls.Add(this.numericUpDown_setHour);
            this.Name = "DataAddForm";
            this.Text = "DataAddModify";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_setMinute)).EndInit();
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
    }
}