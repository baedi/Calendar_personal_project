namespace CalendarWinForm
{
    partial class TodayDataAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TodayDataAddForm));
            this.nUD_t_hour = new System.Windows.Forms.NumericUpDown();
            this.nUD_t_minute = new System.Windows.Forms.NumericUpDown();
            this.label_today_hour = new System.Windows.Forms.Label();
            this.label_today_minute = new System.Windows.Forms.Label();
            this.label_today_alarm = new System.Windows.Forms.Label();
            this.textBox_today_text = new System.Windows.Forms.TextBox();
            this.label_today_text = new System.Windows.Forms.Label();
            this.button_today_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_t_hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_t_minute)).BeginInit();
            this.SuspendLayout();
            // 
            // nUD_t_hour
            // 
            this.nUD_t_hour.Location = new System.Drawing.Point(61, 12);
            this.nUD_t_hour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nUD_t_hour.Name = "nUD_t_hour";
            this.nUD_t_hour.Size = new System.Drawing.Size(55, 25);
            this.nUD_t_hour.TabIndex = 0;
            // 
            // nUD_t_minute
            // 
            this.nUD_t_minute.Location = new System.Drawing.Point(167, 12);
            this.nUD_t_minute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nUD_t_minute.Name = "nUD_t_minute";
            this.nUD_t_minute.Size = new System.Drawing.Size(55, 25);
            this.nUD_t_minute.TabIndex = 1;
            // 
            // label_today_hour
            // 
            this.label_today_hour.AutoSize = true;
            this.label_today_hour.Location = new System.Drawing.Point(120, 18);
            this.label_today_hour.Name = "label_today_hour";
            this.label_today_hour.Size = new System.Drawing.Size(17, 15);
            this.label_today_hour.TabIndex = 2;
            this.label_today_hour.Text = "H";
            // 
            // label_today_minute
            // 
            this.label_today_minute.AutoSize = true;
            this.label_today_minute.Location = new System.Drawing.Point(226, 20);
            this.label_today_minute.Name = "label_today_minute";
            this.label_today_minute.Size = new System.Drawing.Size(19, 15);
            this.label_today_minute.TabIndex = 3;
            this.label_today_minute.Text = "M";
            // 
            // label_today_alarm
            // 
            this.label_today_alarm.AutoSize = true;
            this.label_today_alarm.Location = new System.Drawing.Point(12, 20);
            this.label_today_alarm.Name = "label_today_alarm";
            this.label_today_alarm.Size = new System.Drawing.Size(42, 15);
            this.label_today_alarm.TabIndex = 4;
            this.label_today_alarm.Text = "Alarm";
            // 
            // textBox_today_text
            // 
            this.textBox_today_text.Location = new System.Drawing.Point(61, 48);
            this.textBox_today_text.Name = "textBox_today_text";
            this.textBox_today_text.Size = new System.Drawing.Size(184, 25);
            this.textBox_today_text.TabIndex = 5;
            // 
            // label_today_text
            // 
            this.label_today_text.AutoSize = true;
            this.label_today_text.Location = new System.Drawing.Point(12, 58);
            this.label_today_text.Name = "label_today_text";
            this.label_today_text.Size = new System.Drawing.Size(36, 15);
            this.label_today_text.TabIndex = 6;
            this.label_today_text.Text = "Text";
            // 
            // button_today_OK
            // 
            this.button_today_OK.Location = new System.Drawing.Point(264, 12);
            this.button_today_OK.Name = "button_today_OK";
            this.button_today_OK.Size = new System.Drawing.Size(84, 61);
            this.button_today_OK.TabIndex = 7;
            this.button_today_OK.Text = "OK";
            this.button_today_OK.UseVisualStyleBackColor = true;
            this.button_today_OK.Click += new System.EventHandler(this.Button_today_OK_Click);
            // 
            // TodayDataAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(366, 87);
            this.Controls.Add(this.button_today_OK);
            this.Controls.Add(this.label_today_text);
            this.Controls.Add(this.textBox_today_text);
            this.Controls.Add(this.label_today_alarm);
            this.Controls.Add(this.label_today_minute);
            this.Controls.Add(this.label_today_hour);
            this.Controls.Add(this.nUD_t_minute);
            this.Controls.Add(this.nUD_t_hour);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TodayDataAddForm";
            this.Text = "TodayDataAddForm";
            ((System.ComponentModel.ISupportInitialize)(this.nUD_t_hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_t_minute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nUD_t_hour;
        private System.Windows.Forms.NumericUpDown nUD_t_minute;
        private System.Windows.Forms.Label label_today_hour;
        private System.Windows.Forms.Label label_today_minute;
        private System.Windows.Forms.Label label_today_alarm;
        private System.Windows.Forms.TextBox textBox_today_text;
        private System.Windows.Forms.Label label_today_text;
        private System.Windows.Forms.Button button_today_OK;
    }
}