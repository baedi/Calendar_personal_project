namespace CalendarWinForm
{
    partial class AlarmMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlarmMessage));
            this.label_date = new System.Windows.Forms.Label();
            this.groupBox_text = new System.Windows.Forms.GroupBox();
            this.label_textscreen = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.groupBox_text.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Font = new System.Drawing.Font("굴림", 12F);
            this.label_date.Location = new System.Drawing.Point(47, 11);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(253, 20);
            this.label_date.TabIndex = 0;
            this.label_date.Text = "0000-00-00 오전 00:00:00";
            // 
            // groupBox_text
            // 
            this.groupBox_text.Controls.Add(this.label_textscreen);
            this.groupBox_text.Location = new System.Drawing.Point(14, 42);
            this.groupBox_text.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_text.Name = "groupBox_text";
            this.groupBox_text.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox_text.Size = new System.Drawing.Size(278, 64);
            this.groupBox_text.TabIndex = 1;
            this.groupBox_text.TabStop = false;
            this.groupBox_text.Text = "Text";
            // 
            // label_textscreen
            // 
            this.label_textscreen.AutoSize = true;
            this.label_textscreen.Font = new System.Drawing.Font("굴림", 18F);
            this.label_textscreen.Location = new System.Drawing.Point(7, 21);
            this.label_textscreen.Name = "label_textscreen";
            this.label_textscreen.Size = new System.Drawing.Size(293, 30);
            this.label_textscreen.TabIndex = 0;
            this.label_textscreen.Text = "텍스트 샘플입니다...";
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(202, 114);
            this.button_OK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(86, 29);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // AlarmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 154);
            this.ControlBox = false;
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.groupBox_text);
            this.Controls.Add(this.label_date);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlarmMessage";
            this.Text = "Alarm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlarmMessage_FormClosing_1);
            this.groupBox_text.ResumeLayout(false);
            this.groupBox_text.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.GroupBox groupBox_text;
        private System.Windows.Forms.Label label_textscreen;
        private System.Windows.Forms.Button button_OK;
    }
}