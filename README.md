# Calendar_personal_project 
 - Using C# WinForm to Implement a Calendar Program
---------------------------------------

## Calendar program
 
 #### 1
 - 캘린더 기본 틀 구현 (Implementing the Calendar framework)
 - 현재시간 기능 구현 (Implement current time display)

 #### 2
 - 미니 캘린더 추가 및 연동 작업 (Add and link mini calendars)
 - 일정 리스트 및 버튼 추가 (Add calendar lists and buttons)
 - 토, 일, 현재 날짜, 선택 날짜용 컬러 추가 (Add color for Saturday, day, current date and selection date)
 - 배경 추가 (Add background)

 #### 3
 - 메인 캘린더 선택 기능 추가 (Added main calendar selection)
 - 일정 추가 Form 디자인 완료 (Completed "Add Schedule" form design)

 #### 4
 - 일정 추가 기능 구현 (Implement "Add Schedule" functionality)
 - 일정 타이머 중복 방지 (Prevent scheduling overlap.)
 - 날짜를 선택할 때 데이터베이스에 저장된 데이터 가져오기 기능 추가 (Adding data import features stored in the database when you select a date)

 #### 5
 - 데이터 선택 후 수정 시 원본 데이터 가져옴 (Import source data on modification after data selection)
 - 목록에서 알람 활성화 여부 추가 (Add alarm activation status from list)

 #### 6
 - 수정 기능 구현 완료 (Complete implement modify function.)

 #### 7
 - 기존 년도, 월 조절 NumericUpDown 제거 (Removed "NumericUpDown" year, month regulator.)
 - 알람 기능 구현 완료 (Completed implementation of alarm function)
 - 사운드 추가 완료 (Completed add alarm sound)

 #### 8
 - DB 불러오기 최적화 (DB Load Optimization)

 #### 9
 - 다중 알람 설정 폼 구현 완료 (Complete implementation of multi-alarm setup form)
 - 데이터 추가, 변경 관련 몇 가지 오류 수정 (Fix errors related to adding and changing data)

 #### 10
 - 알람 사운드 켜기,끄기 기능 추가 (Add alarm sound on and off functions)
 - 알람을 "닫기"로 닫을 시 알람 오류 현상 수정 (Fixed alarm error when closing the alarm with "Close")

 #### 11 
 - 일정 다중 추가, 수정 기능 구현 완료 (Complete implementation to add or modify schedules at once)

 #### 12
 - 다중 삭제 기능 추가 (Add multiple deletions)
 - 쿼리문 관련 코드 정리 (Clean up the code :: all sql query -> QueryList class)

 #### 13
 - 트레이 아이콘 추가 (Add tray icon)
  - 앞으로 트레이 아이콘에서 마우스 우클릭 후 Exit를 클릭하면 완전히 끌 수 있다. (Forward, click on the tray icon and click Exit to turn it off completely.)
  - 닫기를 누르면 창이 닫히지만 프로그램은 계속 동작함. (When you click Close, the window closes, but the program continues to work.)

 #### 14
 - 모든 알람 리스트 뷰 추가 (삭제, 갱신 구현) (Add all alarm list views (Includes deletion and modification.))

 #### 15
 - DataView 일부 기능 구현 (Implementing some features of DataView)
 
 #### 16
 - 트레이 아이콘 탭 기능 추가 (알람 켜기 설정, DataView 표시) ( Add Features to Tray Icon Tab ( Alarm On/Off and DataView ) )
 - DataView 일부 기능 구현 2 (Implementing some features of DataView (part 2))

 #### 17
 - DataView 알람 추가 기능 구현 완료(단일 알람) (Add an Alarm Add-In in DataView (Single Alarm))

 #### 18
 - DataView 알람 추가 기능 구현 완료(다중 알람) (Add an Alarm Add-In in DataView (Multi Alarm))
 - 일정 더블 클릭 기능 추가 (Add Date Double-click Feature)

 #### 19 (19-09-25)
 - 일정 더블 클릭 시 선택 가능한 일정에서만 기능이 동작하도록 수정 (Double-click Schedule to modify the function to only operate on a selectable schedule)
 - DataView 수정 버튼 기능 구현 (미완성) (Implementing the DataView Modify button function (incomplete))

 #### 20 (19-09-27)
 - 일일 알람 기능 구현 (미완성) (Implementing daily alarm functions (incomplete))

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
---------------------------------------

## Etc.

 - Background : https://pixabay.com/ko/photos/%EB%B2%BD%EC%A7%80-%EA%B3%B5%EA%B0%84-%EB%B0%94%ED%83%95-%ED%99%94%EB%A9%B4-%EC%9A%B0%EC%A3%BC-3584226/
 - Database : SQLite
 - Database Path : C:\Users\(YourUserName)\Documents\baedi_calendar
 - SQLite version : sqlite-netFx451-setup-bundle-x64-2013-1.0.111.0
 - Alarm Sound source : https://freesound.org/people/LittleT1D/sounds/323019/
