# Calendar_personal_project 
 - Using C# WinForm to Implement a Calendar Program
---------------------------------------

## Programming logs
 
 #### 1 (19-08-13)
 - 캘린더 기본 틀 구현 (Implementing the Calendar framework)
 - 현재시간 기능 구현 (Implement current time display)

 #### 2 (19-08-14)
 - 미니 캘린더 추가 및 연동 작업 (Add and link mini calendars)
 - 일정 리스트 및 버튼 추가 (Add calendar lists and buttons)
 - 토, 일, 현재 날짜, 선택 날짜용 컬러 추가 (Add color for Saturday, day, current date and selection date)
 - 배경 추가 (Add background)

 #### 3 (19-08-16)
 - 메인 캘린더 선택 기능 추가 (Added main calendar selection)
 - 일정 추가 Form 디자인 완료 (Completed "Add Schedule" form design)

 #### 4 (19-08-17 ~ 19-08-18)
 - 일정 추가 기능 구현 (Implement "Add Schedule" functionality)
 - 일정 타이머 중복 방지 (Prevent scheduling overlap.)
 - 날짜를 선택할 때 데이터베이스에 저장된 데이터 가져오기 기능 추가 (Adding data import features stored in the database when you select a date)

 #### 5 (19-08-19)
 - 데이터 선택 후 수정 시 원본 데이터 가져옴 (Import source data on modification after data selection)
 - 목록에서 알람 활성화 여부 추가 (Add alarm activation status from list)

 #### 6 (19-08-20)
 - 수정 기능 구현 완료 (Complete implement modify function.)

 #### 7 (19-08-21 ~ 19-08-22)
 - 기존 년도, 월 조절 NumericUpDown 제거 (Removed "NumericUpDown" year, month regulator.)
 - 알람 기능 구현 완료 (Completed implementation of alarm function)
 - 사운드 추가 완료 (Completed add alarm sound)

 #### 8 (19-08-23)
 - DB 불러오기 최적화 (DB Load Optimization)

 #### 9 (19-08-24)
 - 다중 알람 설정 폼 구현 완료 (Complete implementation of multi-alarm setup form)
 - 데이터 추가, 변경 관련 몇 가지 오류 수정 (Fix errors related to adding and changing data)

 #### 10 (19-08-25)
 - 알람 사운드 켜기,끄기 기능 추가 (Add alarm sound on and off functions)
 - 알람을 "닫기"로 닫을 시 알람 오류 현상 수정 (Fixed alarm error when closing the alarm with "Close")

 #### 11 (19-08-26)
 - 일정 다중 추가, 수정 기능 구현 완료 (Complete implementation to add or modify schedules at once)

 #### 12 (19-08-27)
 - 다중 삭제 기능 추가 (Add multiple deletions)
 - 쿼리문 관련 코드 정리 (Clean up the code :: all sql query -> QueryList class)

 #### 13 (19-08-29)
 - 트레이 아이콘 추가 (Add tray icon)
  - 앞으로 트레이 아이콘에서 마우스 우클릭 후 Exit를 클릭하면 완전히 끌 수 있다. (Forward, click on the tray icon and click Exit to turn it off completely.)
  - 닫기를 누르면 창이 닫히지만 프로그램은 계속 동작함. (When you click Close, the window closes, but the program continues to work.)

 #### 14 (19-08-31)
 - 모든 알람 리스트 뷰 추가 (삭제, 갱신 구현) (Add all alarm list views (Includes deletion and modification.))

 #### 15 (19-09-21)
 - DataView 일부 기능 구현 (Implementing some features of DataView)
 
 #### 16 (19-09-22)
 - 트레이 아이콘 탭 기능 추가 (알람 켜기 설정, DataView 표시) ( Add Features to Tray Icon Tab ( Alarm On/Off and DataView ) )
 - DataView 일부 기능 구현 2 (Implementing some features of DataView (part 2))

 #### 17 (19-09-23)
 - DataView 알람 추가 기능 구현 완료(단일 알람) (Add an Alarm Add-In in DataView (Single Alarm))

 #### 18 (19-09-24)
 - DataView 알람 추가 기능 구현 완료(다중 알람) (Add an Alarm Add-In in DataView (Multi Alarm))
 - 일정 더블 클릭 기능 추가 (Add Date Double-click Feature)

 #### 19 (19-09-25)
 - 일정 더블 클릭 시 선택 가능한 일정에서만 기능이 동작하도록 수정 (Double-click Schedule to modify the function to only operate on a selectable schedule)
 - DataView 수정 버튼 기능 구현 (미완성) (Implementing the DataView Modify button function (incomplete))

 #### 20 (19-09-27)
 - 일일 알람 기능 구현 (미완성) (Implementing daily alarm functions (incomplete))

 #### 21 (19-09-29)
 - 일일 알람 기능 구현 완료 (Complete implementing daily alarm functions)

 #### 22 (19-09-30)
 - DataView 화면에서 알람 수정 기능 구현 (단일 알람) (Implementing an alarm modification function on the DataView screen (single alarm))

 #### 23 (19-10-01)
 - 프로그램 중복 실행 방지 기능 구현 (Modifying it to run in a single process manner)
 - 알람 ON/OFF 관련 버그 수정. (Fixed the bug related to alarm on/off.)

 #### 24 (19-10-02)
 - DataView 화면에서 알람 수정 기능 구현 (다중 알람) (Implementing an alarm modification function on the DataView screen (multi alarm))

 #### 25 (19-10-03)
 - 소스 파일 구성 정리 (Clean up C# class and form source files)
 - 싱글턴 패턴 적용 테스트 (Singleton pattern implementation test)

 #### 26 (19-10-04)
 - 코드 정리 작업 (Code cleanup )

 #### 27 (19-10-09)
 - 코드 정리 작업 : AlarmStatusChange class (Code cleanup : AlarmStatusChange)
  + 기존 CalendarMain에 있었던 알람 온오프 관련 메서드들을 AlarmStatusChange 객체에서 처리하도록 구현

 #### 28 (19-10-10)
 - 코드 정리 작업 (CalendarMain) (Code cleanup : CalendarMain)
 
 #### 29 (19-10-11)
 - DataView 객체 생성 방식 변경 (Change how DataView objects are created)
 - AppManager에서 불필요한 코드 제거 (Remove unnecessary code from AppManager)

 #### 30 (19-10-13)
 - 일일 알람 "수정 버튼" 기능 틀 구현 (Implementing the daily alarm "modify button" function frame)

 #### 31 (19-10-14)
 - 일일 알람 "수정 버튼" 기능 구현 완료 (Completed implementation of daily alarm "modify button" function)

 #### 32 (19-10-15 ~ 19-10-23)
 - SQL 전용 클래스 변경 작업 (정적 -> 동적 방식으로) (SQL-only class change operation (static -> dynamic))
 + (19-10-19) 일정 중복 관련 오류 해결 (An error that occurs when a schedule is duplicated has been corrected.)
 + (19-10-19) DataView의 QueryList를 ListSqlQuery로 대체 완료 (Replacing DataView's QueryList with ListSqlQuery)
 + (19-10-20) 일일 알람 수정 중 중복된 알람 입력 시 오류가 발생되는 현상 확인됨. (Error detected when registering duplicate alarms in daily alarm modification.)
 + (19-10-21) 일일 알람 오류 수정 (Modify daily alarm errors)
 + (19-10-22) "알람 편집기"가 이중으로 열리지 않도록 수정. (Modified to prevent the "Alarm Editor" from double opening)

 #### 33 (19-10-24)
 - DataView 코드 정리 작업 (DataView Code Cleanup Operation)

 #### 34 (19-10-25)
 - 코드 정리 작업 (Code cleanup)
 - 모든 쿼리를 통일화된 ListSqlQuery로 대체 완료 (Completed integrating all query commands into "ListSqlQuery")

 #### 35 (19-10-26 ~ 19-10-27)
 - 코드 정리 작업 (Code cleanup)
 + (19-10-27) 인터페이스 추가 (new Interface : IDataControl)

 #### 36 (19-11-02 ~ 19-11-05)
 - 코드 정리 작업 (Code cleanup)
 - (19-11-04) DataAddForm 객체 생성 방식 수정
 - (19-11-05) 데이터 삭제 메소드 통합 (Integration of data erasure method.)

---------------------------------------

## Helpful data (도움이 된 자료들)

 - https://docs.microsoft.com/ko-kr/dotnet/api/system.datetime.tostring?view=netframework-4.8#System_DateTime_ToString_System_String_
 - https://docs.microsoft.com/ko-kr/dotnet/framework/winforms/controls/how-to-anchor-and-dock-child-controls-in-a-tablelayoutpanel-control
 - https://mirwebma.tistory.com/140
 - https://github.com/baedi/Calender_personal_project
 - (SQLite) http://www.gisdeveloper.co.kr/?p=2290
 - (SQLite) http://www.csharpstudy.com/Practical/Prac-sqlite.aspx
 - (SQLite) https://swconsulting.tistory.com/83
 - (SQLite) https://www.codeproject.com/Articles/22165/Using-SQLite-in-your-C-Application
 - (BadImageFormatException 해결) https://bigenergy.tistory.com/673
 - (string byte 크기 구하기) https://happytomorrow.net/201
 - (SQLite db 파일 읽기) https://happyryu.tistory.com/76
 - (MessageBox YESNO) https://onlyican.tistory.com/152
 - (DB Update) https://spaghetti-code.tistory.com/9
 - (폼 닫기 취소) https://guyaga.tistory.com/56
 - (폼 최소,최대,닫기 없애기) https://terrorjang.tistory.com/40
 - (폼 더블버퍼링) https://cowvoice.tistory.com/8
 - (폼 중앙 띄우기) https://mainia.tistory.com/352
 - (dll exe에 포함시키기 관련 Nuget) https://onlycroco.tistory.com/14
 - (배포 관련 1) https://hunit.tistory.com/330
 - (배포 관련 2) https://blog.naver.com/goldrushing/130166294554
 - (저장된 리소스 가져오기) https://liesm.tistory.com/entry/C-Exe-%ED%8C%8C%EC%9D%BC%EC%97%90-DllOcx-%ED%8C%8C%EC%9D%BC-%ED%8F%AC%ED%95%A8%ED%95%98%EC%97%AC-%EC%BB%B4%ED%8C%8C%EC%9D%BC%ED%95%98%EA%B8%B0
 - (ico 삽입) https://yongtech.tistory.com/55
 - (사운드 재생 관련) https://blog.powerumc.kr/35
 - (사운드 재생 관련 리소스) http://blog.naver.com/PostView.nhn?blogId=hamstery&logNo=110089837046
 - (리소스 이미지 로드) https://akinokaze.tistory.com/201
 - (png -> ico) https://www.hipdf.com/kr/png-to-ico
 - (두 DateTime '일'수 차이 구하기) https://nicebury.tistory.com/60
 - (ListView 항목 복수 선택) https://wwwi.tistory.com/324
 - (트레이 아이콘) https://www.youtube.com/watch?v=TgDKcdC7X3E
 - (단일 프로세스 실행) http://egloos.zum.com/metashower/v/9468289
---------------------------------------

## Etc.

 - Background : https://pixabay.com/ko/photos/%EB%B2%BD%EC%A7%80-%EA%B3%B5%EA%B0%84-%EB%B0%94%ED%83%95-%ED%99%94%EB%A9%B4-%EC%9A%B0%EC%A3%BC-3584226/
 - Database : SQLite
 - Database Path : C:\Users\(YourUserName)\Documents\baedi_calendar
 - SQLite version : sqlite-netFx451-setup-bundle-x64-2013-1.0.111.0
 - Alarm Sound source : https://freesound.org/people/LittleT1D/sounds/323019/
