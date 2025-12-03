========================
Migdal Garage App - הוראות הרצה
========================

האפליקציה מבוססת על ארכיטקטורת FullStack:
• צד שרת (MigdalApi) – פרויקט .NET Core בשיטת Code First
• צד לקוח (MigdalClient) – פרויקט Angular

------------------------
שלב 1 – הרצת השרת (Backend)
------------------------
1. לפתוח טרמינל בתיקייה:
   MigdalApi/

2. להריץ מיגרציה לצורך יצירת מסד הנתונים:
1.Add-Migration InitialCreate
2.Update-Database

3. להפעיל את השרת:
   dotnet run

------------------------
שלב 2 – הרצת הלקוח (Frontend)
------------------------
1. לפתוח טרמינל בתיקייה:
   MigdalClient/

2. להתקין חבילות:
   npm install

3. להריץ:
   ng serve --open

