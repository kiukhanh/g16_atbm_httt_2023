# Hướng dẫn chạy code

### Bước 1: Mở Oracle và chạy file PROJECT_PH1.sql và ABTM_PROJECT
### Bước 2: Mở file ATBM.sln trong Visual Studio
### Bước 3: Tại dòng 42 trong Phanhe1/Connectionfunction.cs:
```
String connectionString = @"Data Source=localhost:1521/XEPDB1;User ID=username; Password=password;DBA Privilege=SYSDBA;";
```
- Thay đổi username và password thành username và password của sysdba trên Oracle

# - Thay đổi các Data Source=localhost:1521/XEPDB1 thành Data Source phù hợp
### Bước 4: Compile code
