﻿namespace CalendarWinForm
{
    partial class CalendarMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "00 : 00",
            "test",
            "O"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarMain));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "00 : 00",
            "test",
            "O"}, -1);
            this.panel_MonthList = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_Time = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label_DateTemp = new System.Windows.Forms.Label();
            this.listView_Schedule = new System.Windows.Forms.ListView();
            this.columnHeader_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_active = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_addSch = new System.Windows.Forms.Button();
            this.button_modifySch = new System.Windows.Forms.Button();
            this.button_deleteSch = new System.Windows.Forms.Button();
            this.label_YearMonth = new System.Windows.Forms.Label();
            this.button_alarmon = new System.Windows.Forms.Button();
            this.trayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alarmONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button_dataview = new System.Windows.Forms.Button();
            this.listView_todayList = new System.Windows.Forms.ListView();
            this.ch_today_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_today_data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_today_add = new System.Windows.Forms.Button();
            this.button_today_modify = new System.Windows.Forms.Button();
            this.button_today_delete = new System.Windows.Forms.Button();
            this.panel_MonthList.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_MonthList
            // 
            this.panel_MonthList.BackColor = System.Drawing.Color.Transparent;
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
            this.panel_MonthList.Location = new System.Drawing.Point(14, 75);
            this.panel_MonthList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel_MonthList.Name = "panel_MonthList";
            this.panel_MonthList.RowCount = 7;
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.675474F));
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.05409F));
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.05409F));
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.05409F));
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.05409F));
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.05409F));
            this.panel_MonthList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.05409F));
            this.panel_MonthList.Size = new System.Drawing.Size(918, 669);
            this.panel_MonthList.TabIndex = 1;
            this.panel_MonthList.DoubleClick += new System.EventHandler(this.Panel_MonthList_DoubleClick);
            this.panel_MonthList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MonthList_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "SUN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(134, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "MON";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(265, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "TUE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(396, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "WED";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label5.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(527, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "THU";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label6.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(658, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "FRI";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(789, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "SAT";
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.BackColor = System.Drawing.Color.Transparent;
            this.label_Time.Font = new System.Drawing.Font("굴림", 12F);
            this.label_Time.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_Time.Location = new System.Drawing.Point(717, 11);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(253, 20);
            this.label_Time.TabIndex = 6;
            this.label_Time.Text = "0000-00-00 오전 00:00:00";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.SystemColors.Window;
            this.monthCalendar1.Location = new System.Drawing.Point(963, 21);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 7;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label_DateTemp
            // 
            this.label_DateTemp.AutoSize = true;
            this.label_DateTemp.BackColor = System.Drawing.Color.Transparent;
            this.label_DateTemp.Font = new System.Drawing.Font("굴림", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_DateTemp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_DateTemp.Location = new System.Drawing.Point(964, 250);
            this.label_DateTemp.Name = "label_DateTemp";
            this.label_DateTemp.Size = new System.Drawing.Size(121, 20);
            this.label_DateTemp.TabIndex = 8;
            this.label_DateTemp.Text = "2019.01.01";
            this.label_DateTemp.TextChanged += new System.EventHandler(this.label_DateTemp_TextChanged);
            // 
            // listView_Schedule
            // 
            this.listView_Schedule.BackColor = System.Drawing.SystemColors.Window;
            this.listView_Schedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_time,
            this.columnHeader_data,
            this.columnHeader_active});
            this.listView_Schedule.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.listView_Schedule.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView_Schedule.Location = new System.Drawing.Point(964, 415);
            this.listView_Schedule.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView_Schedule.Name = "listView_Schedule";
            this.listView_Schedule.Size = new System.Drawing.Size(251, 290);
            this.listView_Schedule.TabIndex = 9;
            this.listView_Schedule.UseCompatibleStateImageBehavior = false;
            this.listView_Schedule.View = System.Windows.Forms.View.Details;
            this.listView_Schedule.Click += new System.EventHandler(this.listView_Schedule_Click);
            this.listView_Schedule.DoubleClick += new System.EventHandler(this.listView_Schedule_DoubleClick);
            // 
            // columnHeader_time
            // 
            this.columnHeader_time.Text = "Time";
            this.columnHeader_time.Width = 56;
            // 
            // columnHeader_data
            // 
            this.columnHeader_data.Text = "Data";
            this.columnHeader_data.Width = 110;
            // 
            // columnHeader_active
            // 
            this.columnHeader_active.Text = "Act";
            this.columnHeader_active.Width = 34;
            // 
            // button_addSch
            // 
            this.button_addSch.BackColor = System.Drawing.SystemColors.Control;
            this.button_addSch.Location = new System.Drawing.Point(963, 715);
            this.button_addSch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_addSch.Name = "button_addSch";
            this.button_addSch.Size = new System.Drawing.Size(82, 29);
            this.button_addSch.TabIndex = 10;
            this.button_addSch.Text = "Add";
            this.button_addSch.UseVisualStyleBackColor = false;
            this.button_addSch.Click += new System.EventHandler(this.button_addSch_Click);
            // 
            // button_modifySch
            // 
            this.button_modifySch.BackColor = System.Drawing.SystemColors.Control;
            this.button_modifySch.Location = new System.Drawing.Point(1048, 715);
            this.button_modifySch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_modifySch.Name = "button_modifySch";
            this.button_modifySch.Size = new System.Drawing.Size(82, 29);
            this.button_modifySch.TabIndex = 11;
            this.button_modifySch.Text = "Modify";
            this.button_modifySch.UseVisualStyleBackColor = false;
            this.button_modifySch.Click += new System.EventHandler(this.button_modifySch_Click);
            // 
            // button_deleteSch
            // 
            this.button_deleteSch.BackColor = System.Drawing.SystemColors.Control;
            this.button_deleteSch.Location = new System.Drawing.Point(1133, 715);
            this.button_deleteSch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_deleteSch.Name = "button_deleteSch";
            this.button_deleteSch.Size = new System.Drawing.Size(82, 29);
            this.button_deleteSch.TabIndex = 12;
            this.button_deleteSch.Text = "Delete";
            this.button_deleteSch.UseVisualStyleBackColor = false;
            this.button_deleteSch.Click += new System.EventHandler(this.button_deleteSch_Click);
            // 
            // label_YearMonth
            // 
            this.label_YearMonth.AutoSize = true;
            this.label_YearMonth.BackColor = System.Drawing.Color.Transparent;
            this.label_YearMonth.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_YearMonth.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_YearMonth.Location = new System.Drawing.Point(8, 11);
            this.label_YearMonth.Name = "label_YearMonth";
            this.label_YearMonth.Size = new System.Drawing.Size(205, 47);
            this.label_YearMonth.TabIndex = 13;
            this.label_YearMonth.Text = "0000.00";
            // 
            // button_alarmon
            // 
            this.button_alarmon.Location = new System.Drawing.Point(742, 35);
            this.button_alarmon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_alarmon.Name = "button_alarmon";
            this.button_alarmon.Size = new System.Drawing.Size(74, 29);
            this.button_alarmon.TabIndex = 14;
            this.button_alarmon.Text = "ON";
            this.button_alarmon.UseVisualStyleBackColor = true;
            this.button_alarmon.Click += new System.EventHandler(this.button_alarmon_Click);
            // 
            // trayicon
            // 
            this.trayicon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayicon.ContextMenuStrip = this.contextMenuStrip;
            this.trayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayicon.Icon")));
            this.trayicon.Text = "baedi_calendar";
            this.trayicon.Visible = true;
            this.trayicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayicon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alarmONToolStripMenuItem,
            this.dataViewToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.ShowCheckMargin = true;
            this.contextMenuStrip.Size = new System.Drawing.Size(177, 82);
            // 
            // alarmONToolStripMenuItem
            // 
            this.alarmONToolStripMenuItem.Checked = true;
            this.alarmONToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alarmONToolStripMenuItem.Name = "alarmONToolStripMenuItem";
            this.alarmONToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.alarmONToolStripMenuItem.Text = "Alarm : ON";
            this.alarmONToolStripMenuItem.Click += new System.EventHandler(this.AlarmONToolStripMenuItem_Click);
            // 
            // dataViewToolStripMenuItem
            // 
            this.dataViewToolStripMenuItem.Name = "dataViewToolStripMenuItem";
            this.dataViewToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.dataViewToolStripMenuItem.Text = "Data view";
            this.dataViewToolStripMenuItem.Click += new System.EventHandler(this.DataViewToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // button_dataview
            // 
            this.button_dataview.Location = new System.Drawing.Point(822, 35);
            this.button_dataview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_dataview.Name = "button_dataview";
            this.button_dataview.Size = new System.Drawing.Size(110, 29);
            this.button_dataview.TabIndex = 16;
            this.button_dataview.Text = "Data view";
            this.button_dataview.UseVisualStyleBackColor = true;
            this.button_dataview.Click += new System.EventHandler(this.button_dataview_Click);
            // 
            // listView_todayList
            // 
            this.listView_todayList.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.listView_todayList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_today_time,
            this.ch_today_data});
            this.listView_todayList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listView_todayList.Location = new System.Drawing.Point(964, 279);
            this.listView_todayList.Name = "listView_todayList";
            this.listView_todayList.Size = new System.Drawing.Size(251, 129);
            this.listView_todayList.TabIndex = 17;
            this.listView_todayList.UseCompatibleStateImageBehavior = false;
            this.listView_todayList.View = System.Windows.Forms.View.Details;
            this.listView_todayList.Click += new System.EventHandler(this.ListView_todayList_Click);
            // 
            // ch_today_time
            // 
            this.ch_today_time.Text = "Time";
            this.ch_today_time.Width = 55;
            // 
            // ch_today_data
            // 
            this.ch_today_data.Text = "Data";
            this.ch_today_data.Width = 145;
            // 
            // button_today_add
            // 
            this.button_today_add.Location = new System.Drawing.Point(1123, 247);
            this.button_today_add.Name = "button_today_add";
            this.button_today_add.Size = new System.Drawing.Size(30, 30);
            this.button_today_add.TabIndex = 18;
            this.button_today_add.Text = "+";
            this.button_today_add.UseVisualStyleBackColor = true;
            this.button_today_add.Click += new System.EventHandler(this.Button_today_add_Click);
            // 
            // button_today_modify
            // 
            this.button_today_modify.Location = new System.Drawing.Point(1154, 247);
            this.button_today_modify.Name = "button_today_modify";
            this.button_today_modify.Size = new System.Drawing.Size(30, 30);
            this.button_today_modify.TabIndex = 19;
            this.button_today_modify.Text = "R";
            this.button_today_modify.UseVisualStyleBackColor = true;
            this.button_today_modify.Click += new System.EventHandler(this.Button_today_modify_Click);
            // 
            // button_today_delete
            // 
            this.button_today_delete.Location = new System.Drawing.Point(1185, 247);
            this.button_today_delete.Name = "button_today_delete";
            this.button_today_delete.Size = new System.Drawing.Size(30, 30);
            this.button_today_delete.TabIndex = 20;
            this.button_today_delete.Text = "-";
            this.button_today_delete.UseVisualStyleBackColor = true;
            this.button_today_delete.Click += new System.EventHandler(this.Button_today_delete_Click);
            // 
            // CalendarMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CalendarWinForm.Properties.Resources.wallpaper_3584226_1280;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1235, 759);
            this.Controls.Add(this.button_today_delete);
            this.Controls.Add(this.button_today_modify);
            this.Controls.Add(this.button_today_add);
            this.Controls.Add(this.listView_todayList);
            this.Controls.Add(this.button_dataview);
            this.Controls.Add(this.button_alarmon);
            this.Controls.Add(this.label_YearMonth);
            this.Controls.Add(this.button_deleteSch);
            this.Controls.Add(this.button_modifySch);
            this.Controls.Add(this.button_addSch);
            this.Controls.Add(this.listView_Schedule);
            this.Controls.Add(this.label_DateTemp);
            this.Controls.Add(this.label_Time);
            this.Controls.Add(this.panel_MonthList);
            this.Controls.Add(this.monthCalendar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "CalendarMain";
            this.Text = "Calendar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Calendar_main_FormClosing);
            this.panel_MonthList.ResumeLayout(false);
            this.panel_MonthList.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panel_MonthList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label_DateTemp;
        private System.Windows.Forms.ListView listView_Schedule;
        private System.Windows.Forms.ColumnHeader columnHeader_time;
        private System.Windows.Forms.ColumnHeader columnHeader_data;
        private System.Windows.Forms.Button button_addSch;
        private System.Windows.Forms.Button button_modifySch;
        private System.Windows.Forms.Button button_deleteSch;
        private System.Windows.Forms.ColumnHeader columnHeader_active;
        private System.Windows.Forms.Label label_YearMonth;
        private System.Windows.Forms.Button button_alarmon;
        private System.Windows.Forms.NotifyIcon trayicon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button button_dataview;
        private System.Windows.Forms.ToolStripMenuItem dataViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alarmONToolStripMenuItem;
        private System.Windows.Forms.ListView listView_todayList;
        private System.Windows.Forms.ColumnHeader ch_today_time;
        private System.Windows.Forms.ColumnHeader ch_today_data;
        private System.Windows.Forms.Button button_today_add;
        private System.Windows.Forms.Button button_today_modify;
        private System.Windows.Forms.Button button_today_delete;
    }
}

