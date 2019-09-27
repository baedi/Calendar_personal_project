# Calendar_personal_project 
 - Using C# WinForm to Implement a Calendar Program
---------------------------------------

## Calendar program
 
 #### 1
 - Ķ���� �⺻ Ʋ ���� (Implementing the Calendar framework)
 - ����ð� ��� ���� (Implement current time display)

 #### 2
 - �̴� Ķ���� �߰� �� ���� �۾� (Add and link mini calendars)
 - ���� ����Ʈ �� ��ư �߰� (Add calendar lists and buttons)
 - ��, ��, ���� ��¥, ���� ��¥�� �÷� �߰� (Add color for Saturday, day, current date and selection date)
 - ��� �߰� (Add background)

 #### 3
 - ���� Ķ���� ���� ��� �߰� (Added main calendar selection)
 - ���� �߰� Form ������ �Ϸ� (Completed "Add Schedule" form design)

 #### 4
 - ���� �߰� ��� ���� (Implement "Add Schedule" functionality)
 - ���� Ÿ�̸� �ߺ� ���� (Prevent scheduling overlap.)
 - ��¥�� ������ �� �����ͺ��̽��� ����� ������ �������� ��� �߰� (Adding data import features stored in the database when you select a date)

 #### 5
 - ������ ���� �� ���� �� ���� ������ ������ (Import source data on modification after data selection)
 - ��Ͽ��� �˶� Ȱ��ȭ ���� �߰� (Add alarm activation status from list)

 #### 6
 - ���� ��� ���� �Ϸ� (Complete implement modify function.)

 #### 7
 - ���� �⵵, �� ���� NumericUpDown ���� (Removed "NumericUpDown" year, month regulator.)
 - �˶� ��� ���� �Ϸ� (Completed implementation of alarm function)
 - ���� �߰� �Ϸ� (Completed add alarm sound)

 #### 8
 - DB �ҷ����� ����ȭ (DB Load Optimization)

 #### 9
 - ���� �˶� ���� �� ���� �Ϸ� (Complete implementation of multi-alarm setup form)
 - ������ �߰�, ���� ���� �� ���� ���� ���� (Fix errors related to adding and changing data)

 #### 10
 - �˶� ���� �ѱ�,���� ��� �߰� (Add alarm sound on and off functions)
 - �˶��� "�ݱ�"�� ���� �� �˶� ���� ���� ���� (Fixed alarm error when closing the alarm with "Close")

 #### 11 
 - ���� ���� �߰�, ���� ��� ���� �Ϸ� (Complete implementation to add or modify schedules at once)

 #### 12
 - ���� ���� ��� �߰� (Add multiple deletions)
 - ������ ���� �ڵ� ���� (Clean up the code :: all sql query -> QueryList class)

 #### 13
 - Ʈ���� ������ �߰� (Add tray icon)
  - ������ Ʈ���� �����ܿ��� ���콺 ��Ŭ�� �� Exit�� Ŭ���ϸ� ������ �� �� �ִ�. (Forward, click on the tray icon and click Exit to turn it off completely.)
  - �ݱ⸦ ������ â�� �������� ���α׷��� ��� ������. (When you click Close, the window closes, but the program continues to work.)

 #### 14
 - ��� �˶� ����Ʈ �� �߰� (����, ���� ����) (Add all alarm list views (Includes deletion and modification.))

 #### 15
 - DataView �Ϻ� ��� ���� (Implementing some features of DataView)
 
 #### 16
 - Ʈ���� ������ �� ��� �߰� (�˶� �ѱ� ����, DataView ǥ��) ( Add Features to Tray Icon Tab ( Alarm On/Off and DataView ) )
 - DataView �Ϻ� ��� ���� 2 (Implementing some features of DataView (part 2))

 #### 17
 - DataView �˶� �߰� ��� ���� �Ϸ�(���� �˶�) (Add an Alarm Add-In in DataView (Single Alarm))

 #### 18
 - DataView �˶� �߰� ��� ���� �Ϸ�(���� �˶�) (Add an Alarm Add-In in DataView (Multi Alarm))
 - ���� ���� Ŭ�� ��� �߰� (Add Date Double-click Feature)

 #### 19 (19-09-25)
 - ���� ���� Ŭ�� �� ���� ������ ���������� ����� �����ϵ��� ���� (Double-click Schedule to modify the function to only operate on a selectable schedule)
 - DataView ���� ��ư ��� ���� (�̿ϼ�) (Implementing the DataView Modify button function (incomplete))

 #### 20 (19-09-27)
 - ���� �˶� ��� ���� (�̿ϼ�) (Implementing daily alarm functions (incomplete))

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
---------------------------------------

## Etc.

 - Background : https://pixabay.com/ko/photos/%EB%B2%BD%EC%A7%80-%EA%B3%B5%EA%B0%84-%EB%B0%94%ED%83%95-%ED%99%94%EB%A9%B4-%EC%9A%B0%EC%A3%BC-3584226/
 - Database : SQLite
 - Database Path : C:\Users\(YourUserName)\Documents\baedi_calendar
 - SQLite version : sqlite-netFx451-setup-bundle-x64-2013-1.0.111.0
 - Alarm Sound source : https://freesound.org/people/LittleT1D/sounds/323019/
