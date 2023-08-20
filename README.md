# Hướng dẫn chạy code

### Bước 1: Mở Oracle và chạy file PROJECT_PH1.sql và ABTM_PROJECT
### Bước 2: Giải nén file PH1.zip và copy thư mục Phanhe1 vào thư mục chứa file ATBM.sln
### Bước 3: Mở file ATBM.sln trong Visual Studio
### Bước 4: Cài đặt các package sau nếu chưa có:
- System.ValueTuple.4.5.0
- System.Threading.Tasks.Extensions.4.5.4
- System.Text.Json.6.0.0
- System.Text.Endcodings.Web.6.0.0
- System.Runtime.CompilerServices.Unsafe.6.0.0
- System.Numerics.Vectors.4.5.0
- System.Memory.4.5.4
- System.Buffers.4.5.1
- Oracle.ManagedDataAccess.21.9.0
- Microsoft.Bcl.AsyncInterfaces.6.0.0
- Guna.UI2.WinForms.2.0.4.4
### Bước 5: Chạy file GunaPatcher.exe (để setup package Guna.UI2.WinForms.2.0.4.4)
### Bước 6: Tại dòng 42 trong Phanhe1/Connectionfunction.cs:
```
String connectionString = @"Data Source=localhost:1521/XE;User ID=username; Password=password;DBA Privilege=SYSDBA;";
```
- Thay đổi username và password thành username và password của sysdba trên Oracle 
### Bước 7: Compile code
