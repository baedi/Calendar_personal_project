# Calendar_personal_project 

Using C# WinForm to Implement a Calendar Program
---------------------------------------

## Calendar program
 
 - 캘린더 기본 틀 구현 (Implementing the Calendar framework)
 - 현재시간 기능 구현 (Implement current time display)

 - 미니 캘린더 추가 및 연동 작업 (Add and link mini calendars)
 - 일정 리스트 및 버튼 추가 (Add calendar lists and buttons)
 - 토, 일, 현재 날짜, 선택 날짜용 컬러 추가 (Add color for Saturday, day, current date and selection date)
 - 배경 추가 (Add background)

 - 메인 캘린더 선택 기능 추가 (Added main calendar selection)
 - 일정 추가 Form 디자인 완료 (Completed "Add Schedule" form design)

 - 일정 추가 기능 구현 (Implement "Add Schedule" functionality)
 - 일정 타이머 중복 방지 (Prevent scheduling overlap.)
 - 날짜를 선택할 때 데이터베이스에 저장된 데이터 가져오기 기능 추가 (Adding data import features stored in the database when you select a date)

 - 데이터 선택 후 수정 시 원본 데이터 가져옴 (Import source data on modification after data selection)
 - 목록에서 알람 활성화 여부 추가 (Add alarm activation status from list)

 - 수정 기능 구현 완료 (Complete implement modify function.)


### 남은 구현 목록들
 - 알람 기능 (사운드 포함)
 - 최적화

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
 
---------------------------------------

## Etc.

 - Background : https://pixabay.com/ko/photos/%EB%B2%BD%EC%A7%80-%EA%B3%B5%EA%B0%84-%EB%B0%94%ED%83%95-%ED%99%94%EB%A9%B4-%EC%9A%B0%EC%A3%BC-3584226/
 - Database : SQLite
 - Database Path : C:\Users\(YourUserName)\Documents\baedi_calendar
 - SQLite version : sqlite-netFx451-setup-bundle-x64-2013-1.0.111.0
