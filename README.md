# Calendar_personal_project 
 - Using C# WinForm to Implement a Calendar Program
---------------------------------------

## Programming logs
 
 #### 1 (19-08-13)
 - Ķ���� �⺻ Ʋ ���� (Implementing the Calendar framework)
 - ����ð� ��� ���� (Implement current time display)

 #### 2 (19-08-14)
 - �̴� Ķ���� �߰� �� ���� �۾� (Add and link mini calendars)
 - ���� ����Ʈ �� ��ư �߰� (Add calendar lists and buttons)
 - ��, ��, ���� ��¥, ���� ��¥�� �÷� �߰� (Add color for Saturday, day, current date and selection date)
 - ��� �߰� (Add background)

 #### 3 (19-08-16)
 - ���� Ķ���� ���� ��� �߰� (Added main calendar selection)
 - ���� �߰� Form ������ �Ϸ� (Completed "Add Schedule" form design)

 #### 4 (19-08-17 ~ 19-08-18)
 - ���� �߰� ��� ���� (Implement "Add Schedule" functionality)
 - ���� Ÿ�̸� �ߺ� ���� (Prevent scheduling overlap.)
 - ��¥�� ������ �� �����ͺ��̽��� ����� ������ �������� ��� �߰� (Adding data import features stored in the database when you select a date)

 #### 5 (19-08-19)
 - ������ ���� �� ���� �� ���� ������ ������ (Import source data on modification after data selection)
 - ��Ͽ��� �˶� Ȱ��ȭ ���� �߰� (Add alarm activation status from list)

 #### 6 (19-08-20)
 - ���� ��� ���� �Ϸ� (Complete implement modify function.)

 #### 7 (19-08-21 ~ 19-08-22)
 - ���� �⵵, �� ���� NumericUpDown ���� (Removed "NumericUpDown" year, month regulator.)
 - �˶� ��� ���� �Ϸ� (Completed implementation of alarm function)
 - ���� �߰� �Ϸ� (Completed add alarm sound)

 #### 8 (19-08-23)
 - DB �ҷ����� ����ȭ (DB Load Optimization)

 #### 9 (19-08-24)
 - ���� �˶� ���� �� ���� �Ϸ� (Complete implementation of multi-alarm setup form)
 - ������ �߰�, ���� ���� �� ���� ���� ���� (Fix errors related to adding and changing data)

 #### 10 (19-08-25)
 - �˶� ���� �ѱ�,���� ��� �߰� (Add alarm sound on and off functions)
 - �˶��� "�ݱ�"�� ���� �� �˶� ���� ���� ���� (Fixed alarm error when closing the alarm with "Close")

 #### 11 (19-08-26)
 - ���� ���� �߰�, ���� ��� ���� �Ϸ� (Complete implementation to add or modify schedules at once)

 #### 12 (19-08-27)
 - ���� ���� ��� �߰� (Add multiple deletions)
 - ������ ���� �ڵ� ���� (Clean up the code :: all sql query -> QueryList class)

 #### 13 (19-08-29)
 - Ʈ���� ������ �߰� (Add tray icon)
  - ������ Ʈ���� �����ܿ��� ���콺 ��Ŭ�� �� Exit�� Ŭ���ϸ� ������ �� �� �ִ�. (Forward, click on the tray icon and click Exit to turn it off completely.)
  - �ݱ⸦ ������ â�� �������� ���α׷��� ��� ������. (When you click Close, the window closes, but the program continues to work.)

 #### 14 (19-08-31)
 - ��� �˶� ����Ʈ �� �߰� (����, ���� ����) (Add all alarm list views (Includes deletion and modification.))

 #### 15 (19-09-21)
 - DataView �Ϻ� ��� ���� (Implementing some features of DataView)
 
 #### 16 (19-09-22)
 - Ʈ���� ������ �� ��� �߰� (�˶� �ѱ� ����, DataView ǥ��) ( Add Features to Tray Icon Tab ( Alarm On/Off and DataView ) )
 - DataView �Ϻ� ��� ���� 2 (Implementing some features of DataView (part 2))

 #### 17 (19-09-23)
 - DataView �˶� �߰� ��� ���� �Ϸ�(���� �˶�) (Add an Alarm Add-In in DataView (Single Alarm))

 #### 18 (19-09-24)
 - DataView �˶� �߰� ��� ���� �Ϸ�(���� �˶�) (Add an Alarm Add-In in DataView (Multi Alarm))
 - ���� ���� Ŭ�� ��� �߰� (Add Date Double-click Feature)

 #### 19 (19-09-25)
 - ���� ���� Ŭ�� �� ���� ������ ���������� ����� �����ϵ��� ���� (Double-click Schedule to modify the function to only operate on a selectable schedule)
 - DataView ���� ��ư ��� ���� (�̿ϼ�) (Implementing the DataView Modify button function (incomplete))

 #### 20 (19-09-27)
 - ���� �˶� ��� ���� (�̿ϼ�) (Implementing daily alarm functions (incomplete))

 #### 21 (19-09-29)
 - ���� �˶� ��� ���� �Ϸ� (Complete implementing daily alarm functions)

 #### 22 (19-09-30)
 - DataView ȭ�鿡�� �˶� ���� ��� ���� (���� �˶�) (Implementing an alarm modification function on the DataView screen (single alarm))

 #### 23 (19-10-01)
 - ���α׷� �ߺ� ���� ���� ��� ���� (Modifying it to run in a single process manner)
 - �˶� ON/OFF ���� ���� ����. (Fixed the bug related to alarm on/off.)

 #### 24 (19-10-02)
 - DataView ȭ�鿡�� �˶� ���� ��� ���� (���� �˶�) (Implementing an alarm modification function on the DataView screen (multi alarm))

 #### 25 (19-10-03)
 - �ҽ� ���� ���� ���� (Clean up C# class and form source files)
 - �̱��� ���� ���� �׽�Ʈ (Singleton pattern implementation test)

 #### 26 (19-10-04)
 - �ڵ� ���� �۾� (Code cleanup )

 #### 27 (19-10-09)
 - �ڵ� ���� �۾� : AlarmStatusChange class (Code cleanup : AlarmStatusChange)
  + ���� CalendarMain�� �־��� �˶� �¿��� ���� �޼������ AlarmStatusChange ��ü���� ó���ϵ��� ����

 #### 28 (19-10-10)
 - �ڵ� ���� �۾� (CalendarMain) (Code cleanup : CalendarMain)
 
 #### 29 (19-10-11)
 - DataView ��ü ���� ��� ���� (Change how DataView objects are created)
 - AppManager���� ���ʿ��� �ڵ� ���� (Remove unnecessary code from AppManager)

 #### 30 (19-10-13)
 - ���� �˶� "���� ��ư" ��� Ʋ ���� (Implementing the daily alarm "modify button" function frame)

 #### 31 (19-10-14)
 - ���� �˶� "���� ��ư" ��� ���� �Ϸ� (Completed implementation of daily alarm "modify button" function)

 #### 32 (19-10-15 ~ 19-10-23)
 - SQL ���� Ŭ���� ���� �۾� (���� -> ���� �������) (SQL-only class change operation (static -> dynamic))
 + (19-10-19) ���� �ߺ� ���� ���� �ذ� (An error that occurs when a schedule is duplicated has been corrected.)
 + (19-10-19) DataView�� QueryList�� ListSqlQuery�� ��ü �Ϸ� (Replacing DataView's QueryList with ListSqlQuery)
 + (19-10-20) ���� �˶� ���� �� �ߺ��� �˶� �Է� �� ������ �߻��Ǵ� ���� Ȯ�ε�. (Error detected when registering duplicate alarms in daily alarm modification.)
 + (19-10-21) ���� �˶� ���� ���� (Modify daily alarm errors)
 + (19-10-22) "�˶� ������"�� �������� ������ �ʵ��� ����. (Modified to prevent the "Alarm Editor" from double opening)

 #### 33 (19-10-24)
 - DataView �ڵ� ���� �۾� (DataView Code Cleanup Operation)

 #### 34 (19-10-25)
 - �ڵ� ���� �۾� (Code cleanup)
 - ��� ������ ����ȭ�� ListSqlQuery�� ��ü �Ϸ� (Completed integrating all query commands into "ListSqlQuery")

 #### 35 (19-10-26 ~ 19-10-27)
 - �ڵ� ���� �۾� (Code cleanup)
 + (19-10-27) �������̽� �߰� (new Interface : IDataControl)

 #### 36 (19-11-02 ~ 19-11-05)
 - �ڵ� ���� �۾� (Code cleanup)
 - (19-11-04) DataAddForm ��ü ���� ��� ����
 - (19-11-05) ������ ���� �޼ҵ� ���� (Integration of data erasure method.)

---------------------------------------

## Helpful data (������ �� �ڷ��)

 - https://docs.microsoft.com/ko-kr/dotnet/api/system.datetime.tostring?view=netframework-4.8#System_DateTime_ToString_System_String_
 - https://docs.microsoft.com/ko-kr/dotnet/framework/winforms/controls/how-to-anchor-and-dock-child-controls-in-a-tablelayoutpanel-control
 - https://mirwebma.tistory.com/140
 - https://github.com/baedi/Calender_personal_project
 - (SQLite) http://www.gisdeveloper.co.kr/?p=2290
 - (SQLite) http://www.csharpstudy.com/Practical/Prac-sqlite.aspx
 - (SQLite) https://swconsulting.tistory.com/83
 - (SQLite) https://www.codeproject.com/Articles/22165/Using-SQLite-in-your-C-Application
 - (BadImageFormatException �ذ�) https://bigenergy.tistory.com/673
 - (string byte ũ�� ���ϱ�) https://happytomorrow.net/201
 - (SQLite db ���� �б�) https://happyryu.tistory.com/76
 - (MessageBox YESNO) https://onlyican.tistory.com/152
 - (DB Update) https://spaghetti-code.tistory.com/9
 - (�� �ݱ� ���) https://guyaga.tistory.com/56
 - (�� �ּ�,�ִ�,�ݱ� ���ֱ�) https://terrorjang.tistory.com/40
 - (�� ������۸�) https://cowvoice.tistory.com/8
 - (�� �߾� ����) https://mainia.tistory.com/352
 - (dll exe�� ���Խ�Ű�� ���� Nuget) https://onlycroco.tistory.com/14
 - (���� ���� 1) https://hunit.tistory.com/330
 - (���� ���� 2) https://blog.naver.com/goldrushing/130166294554
 - (����� ���ҽ� ��������) https://liesm.tistory.com/entry/C-Exe-%ED%8C%8C%EC%9D%BC%EC%97%90-DllOcx-%ED%8C%8C%EC%9D%BC-%ED%8F%AC%ED%95%A8%ED%95%98%EC%97%AC-%EC%BB%B4%ED%8C%8C%EC%9D%BC%ED%95%98%EA%B8%B0
 - (ico ����) https://yongtech.tistory.com/55
 - (���� ��� ����) https://blog.powerumc.kr/35
 - (���� ��� ���� ���ҽ�) http://blog.naver.com/PostView.nhn?blogId=hamstery&logNo=110089837046
 - (���ҽ� �̹��� �ε�) https://akinokaze.tistory.com/201
 - (png -> ico) https://www.hipdf.com/kr/png-to-ico
 - (�� DateTime '��'�� ���� ���ϱ�) https://nicebury.tistory.com/60
 - (ListView �׸� ���� ����) https://wwwi.tistory.com/324
 - (Ʈ���� ������) https://www.youtube.com/watch?v=TgDKcdC7X3E
 - (���� ���μ��� ����) http://egloos.zum.com/metashower/v/9468289
---------------------------------------

## Etc.

 - Background : https://pixabay.com/ko/photos/%EB%B2%BD%EC%A7%80-%EA%B3%B5%EA%B0%84-%EB%B0%94%ED%83%95-%ED%99%94%EB%A9%B4-%EC%9A%B0%EC%A3%BC-3584226/
 - Database : SQLite
 - Database Path : C:\Users\(YourUserName)\Documents\baedi_calendar
 - SQLite version : sqlite-netFx451-setup-bundle-x64-2013-1.0.111.0
 - Alarm Sound source : https://freesound.org/people/LittleT1D/sounds/323019/
