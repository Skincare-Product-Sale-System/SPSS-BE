# SPSS Backend API

## 🚀 Setup Development Environment

### Prerequisites
- .NET 8.0 SDK
- SQL Server (Docker hoặc Local)
- Visual Studio 2022 hoặc VS Code

### Configuration Setup

1. **Tạo file cấu hình local** (không commit lên Git):
   ```bash
   cp API/appsettings.json API/appsettings.Local.json
   ```

2. **Cấu hình `appsettings.Local.json`** với thông tin thực của bạn:
   ```json
   {
     "ConnectionStrings": {
       "SPSS": "Server=localhost,1433;Database=spss;User ID=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True"
     },
     "Jwt": {
       "Key": "your-secret-key-min-64-characters",
       "Issuer": "http://localhost:5041",
       "Audience": "http://localhost:3000"
     },
     "FacePlusPlus": {
       "ApiKey": "your-api-key",
       "ApiSecret": "your-api-secret"
     },
     "Banking": {
       "BankName": "YOUR_BANK",
       "BankId": "BANK_ID",
       "AccountNumber": "ACCOUNT_NUMBER",
       "AccountName": "ACCOUNT_NAME"
     },
     "VietQR": {
       "ClientId": "your-client-id",
       "ApiKey": "your-api-key"
     }
   }
   ```

3. **Hoặc dùng User Secrets** (Khuyến nghị):
   ```bash
   cd API
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:SPSS" "Server=localhost;Database=spss;..."
   dotnet user-secrets set "Jwt:Key" "your-secret-key"
   dotnet user-secrets set "FacePlusPlus:ApiKey" "your-api-key"
   dotnet user-secrets set "FacePlusPlus:ApiSecret" "your-api-secret"
   ```

### Run Project

```bash
cd API
dotnet restore
dotnet run
```

## 🔒 Security Notes

**QUAN TRỌNG**: 
- ❌ **KHÔNG BAO GIỜ** commit các file chứa thông tin nhạy cảm
- ✅ Sử dụng `appsettings.Local.json` hoặc User Secrets cho development
- ✅ Sử dụng Azure App Configuration hoặc Environment Variables cho production
- ✅ Files trong `.gitignore` sẽ không được commit:
  - `appsettings.Local.json`
  - `appsettings.Production.json`
  - `**/handmade-product-*.json`
  - Các file credentials khác

## 📦 Deploy to Azure

Xem hướng dẫn chi tiết trong [DEPLOYMENT.md](DEPLOYMENT.md)

Tóm tắt:
1. Tạo Azure SQL Database
2. Tạo Azure App Service
3. Cấu hình Environment Variables trên Azure Portal
4. Deploy qua GitHub Actions hoặc Azure DevOps

## 🛠️ Database Migration

```bash
# Update database
dotnet ef database update --project BusinessObjects

# Create new migration
dotnet ef migrations add MigrationName --project BusinessObjects
```

## 📝 API Documentation

Sau khi chạy project, truy cập Swagger UI tại:
- Development: http://localhost:5041/swagger
- Production: https://your-app.azurewebsites.net/swagger
