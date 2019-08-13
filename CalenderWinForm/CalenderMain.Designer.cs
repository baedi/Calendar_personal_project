namespace CalenderWinForm
{
    partial class Form_Calender_main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_MonthList = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_Year = new System.Windows.Forms.NumericUpDown();
            this.label_Year = new System.Windows.Forms.Label();
            this.label_Month = new System.Windows.Forms.Label();
            this.label_Time = new System.Windows.Forms.Label();
            this.numericUpDown_Month = new System.Windows.Forms.NumericUpDown();
            this.panel_MonthList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Month)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_MonthList
            // 
            this.panel_MonthList.ColumnCount = 7;
            this.panel_MonthList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.panel_MonthList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.panel_MonthList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.panel_MonthList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.panel_MonthList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.panel_MonthList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.panel_MonthList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.panel_MonthList.Controls.Add(this.label1, 0, 0);
            this.panel_MonthList.Controls.Add(this.label2, 1, 0);
            this.panel_MonthList.Controls.Add(this.label3, 2, 0);
            this.panel_MonthList.Controls.Add(this.label4, 3, 0);
            this.panel_MonthList.Controls.Add(this.label5, 4, 0);
            this.panel_MonthList.Controls.Add(this.label6, 5, 0);
            this.panel_MonthList.Controls.Add(this.label7, 6, 0);
            this.panel_MonthList.Location = new System.Drawing.Point(12, 66);
            this.panel_MonthList.Name = "panel_MonthList";
            this.panel_MonthList.RowCount = 7;
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.760998F));
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.87317F));
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.87317F));
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.87317F));
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.87317F));
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.87317F));
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.87317F));
            this.panel_MonthList.Size = new System.Drawing.Size(802, 529);
            this.panel_MonthList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "SUN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(117, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "MON";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(231, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "TUE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(345, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "WED";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(459, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "THU";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(573, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "FRI";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(687, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "SAT";
            // 
            // numericUpDown_Year
            // 
            this.numericUpDown_Year.Location = new System.Drawing.Point(12, 11);
            this.numericUpDown_Year.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numericUpDown_Year.Name = "numericUpDown_Year";
            this.numericUpDown_Year.Size = new System.Drawing.Size(57, 21);
            this.numericUpDown_Year.TabIndex = 2;
            this.numericUpDown_Year.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.numericUpDown_Year.ValueChanged += new System.EventHandler(this.numericUpDown_Year_ValueChanged);
            // 
            // label_Year
            // 
            this.label_Year.AutoSize = true;
            this.label_Year.Location = new System.Drawing.Point(72, 17);
            this.label_Year.Name = "label_Year";
            this.label_Year.Size = new System.Drawing.Size(17, 12);
            this.label_Year.TabIndex = 3;
            this.label_Year.Text = "년";
            // 
            // label_Month
            // 
            this.label_Month.AutoSize = true;
            this.label_Month.Location = new System.Drawing.Point(145, 17);
            this.label_Month.Name = "label_Month";
            this.label_Month.Size = new System.Drawing.Size(17, 12);
            this.label_Month.TabIndex = 5;
            this.label_Month.Text = "월";
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Font = new System.Drawing.Font("굴림", 12F);
            this.label_Time.Location = new System.Drawing.Point(627, 9);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(188, 16);
            this.label_Time.TabIndex = 6;
            this.label_Time.Text = "0000-00-00 오전 00:00:00";
            // 
            // numericUpDown_Month
            // 
            this.numericUpDown_Month.Location = new System.Drawing.Point(99, 10);
            this.numericUpDown_Month.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown_Month.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Month.Name = "numericUpDown_Month";
            this.numericUpDown_Month.Size = new System.Drawing.Size(44, 21);
            this.numericUpDown_Month.TabIndex = 7;
            this.numericUpDown_Month.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Month.ValueChanged += new System.EventHandler(this.numericUpDown_Month_ValueChanged);
            // 
            // Form_Calender_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(827, 607);
            this.Controls.Add(this.numericUpDown_Month);
            this.Controls.Add(this.label_Time);
            this.Controls.Add(this.label_Month);
            this.Controls.Add(this.label_Year);
            this.Controls.Add(this.numericUpDown_Year);
            this.Controls.Add(this.panel_MonthList);
            this.Name = "Form_Calender_main";
            this.Text = "Calender";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Calender_main_FormClosed);
            this.panel_MonthList.ResumeLayout(false);
            this.panel_MonthList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Month)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panel_MonthList;
        private System.Windows.Forms.NumericUpDown numericUpDown_Year;
        private System.Windows.Forms.Label label_Year;
        private System.Windows.Forms.Label label_Month;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.NumericUpDown numericUpDown_Month;
    }
}

