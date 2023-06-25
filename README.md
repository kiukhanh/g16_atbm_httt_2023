# Hướng dẫn chạy code

### Bước 1: Mở Oracle và chạy file PROJECT_PH1.sql và ABTM_PROJECT
### Bước 2: Mở file ATBM.sln trong Visual Studio
### Bước 3: Tại dòng 42 trong Phanhe1/Connectionfunction.cs:
```
String connectionString = @"Data Source=localhost:1521/XE;User ID=username; Password=password;DBA Privilege=SYSDBA;";
```
- Thay đổi username và password thành username và password của sysdba trên Oracle 
### Bước 4: Compile code
