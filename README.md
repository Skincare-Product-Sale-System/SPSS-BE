<div align="center">

# 🧴 SPSS Backend

### Skincare Product Shopping System - Enterprise Backend API

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-12-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2019-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/sql-server)
[![SignalR](https://img.shields.io/badge/SignalR-Real--time-00D4AA?style=for-the-badge&logo=microsoft&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet/signalr)
[![Swagger](https://img.shields.io/badge/Swagger-API%20Docs-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)](https://swagger.io/)
[![Azure](https://img.shields.io/badge/Azure-Deployed-0078D4?style=for-the-badge&logo=microsoft-azure&logoColor=white)](https://azure.microsoft.com/)

*A comprehensive ASP.NET Core backend API for managing skincare e-commerce operations, featuring AI-powered skin analysis, real-time chat support, personalized product recommendations, and secure payment integration.*

[Swagger Docs](#-api-documentation) • [Report Bug](#-contributing) • [Request Feature](#-contributing)

</div>

---

## 📋 Table of Contents

- [About The Project](#-about-the-project)
- [Key Features](#-key-features)
- [Tech Stack](#️-tech-stack)
- [System Architecture](#-system-architecture)
- [Getting Started](#-getting-started)
- [API Documentation](#-api-documentation)
- [Database Schema](#-database-schema)
- [Contributing](#-contributing)
- [License](#-license)

---

## 🎯 About The Project

**SPSS Backend** is a robust, enterprise-grade RESTful Web API built with ASP.NET Core 8.0, implementing Clean Architecture principles to provide comprehensive backend services for the Skincare Product Shopping System (SPSS). The platform delivers a personalized skincare shopping experience with AI-powered skin analysis, intelligent product recommendations, and seamless e-commerce capabilities.

### 🎓 Project Details
- **Development Period:** 4 months (9/2024 - 12/2024)
- **Team Size:** 5 Developers
- **Architecture:** Clean Architecture (Onion Architecture)
- **Development Approach:** API-First Design
- **Lines of Code:** ~20,000+ (Backend only)

### 💡 Problem Statement

Traditional skincare e-commerce platforms face significant challenges:
- Customers struggle to find products suitable for their skin type
- Lack of personalized recommendations leads to poor purchase decisions
- No scientific skin analysis tools available for online shopping
- Manual customer support is expensive and not available 24/7
- Complex product variations and inventory management
- Payment processing complexity in Vietnam market

### ✅ Our Solution

SPSS Backend provides a centralized, scalable API platform that:
- Implements AI-powered skin analysis using Face++ and TensorFlow
- Delivers personalized product recommendations based on skin type
- Provides real-time chat support via SignalR WebSockets
- Integrates Vietnamese payment gateways (VNPAY, VietQR, SePay)
- Offers comprehensive product management with variations
- Supports quiz-based skin type assessment

---

## ⭐ Key Features

### 🔐 Authentication & Authorization
- **JWT-based authentication** - Secure token generation with access/refresh token mechanism
- **Role-based access control** - Admin, Staff, Customer roles with granular permissions
- **Account security** - Automatic lockout after failed login attempts
- **Token refresh mechanism** - 15-minute access tokens, 7-day refresh tokens
- **Password policies** - Strong password validation and BCrypt hashing
- **Firebase Integration** - Image storage and management

### 🛒 E-Commerce Core
- **Product catalog** - Complete CRUD operations with categories and brands
- **Product variations** - Size, volume, and other configurable options
- **Inventory management** - Stock tracking across product items
- **Shopping cart** - Real-time cart management with SignalR
- **Order processing** - Full order lifecycle management
- **Voucher system** - Discount codes and promotional campaigns
- **Review system** - Customer reviews with images and ratings

### 🔬 AI-Powered Skin Analysis
- **Face++ Integration** - Advanced facial recognition and skin attribute detection
- **TensorFlow/ONNX Models** - EfficientNet-based skin condition analysis
- **Skin issue detection** - Acne, wrinkles, dark circles, skin tone analysis
- **Personalized recommendations** - Product suggestions based on analysis results
- **Analysis history** - Track skin improvement over time
- **Credit-based system** - Transaction-based skin analysis pricing

### 📝 Quiz & Skin Type Assessment
- **Quiz engine** - Configurable quiz sets with multiple questions
- **Scoring algorithm** - Intelligent skin type determination
- **Personalized results** - Customized skincare routine recommendations
- **Product matching** - Products linked to specific skin types
- **Skin type profiles** - Oily, Dry, Combination, Sensitive, Normal

### 💬 Real-time Chat Support
- **SignalR WebSocket** - Bi-directional real-time communication
- **Live chat** - Customer-to-staff messaging system
- **Support queue** - Automatic routing to available staff
- **Chat history** - Persistent conversation storage
- **Multi-session support** - Handle multiple chat sessions simultaneously

### 💳 Payment Integration
- **VNPAY** - Vietnam's leading payment gateway integration
- **VietQR** - QR code-based bank transfer support
- **SePay Webhook** - Real-time payment notification handling
- **Transaction management** - Complete payment audit trail
- **Wallet system** - User balance for skin analysis credits
- **Refund processing** - Order cancellation and refund handling

### 📊 Dashboard & Analytics
- **Admin dashboard** - Sales overview, user statistics, order metrics
- **Financial dashboard** - Revenue tracking, payment analytics
- **Product analytics** - Best sellers, inventory alerts
- **Customer insights** - User behavior and purchase patterns

### 📰 Content Management
- **Blog system** - Educational skincare content with sections
- **Rich text support** - HTML content with images
- **Category organization** - Skincare tips, tutorials, news
- **SEO optimization** - Meta tags and descriptions

### 🏠 Address & Location
- **Multiple addresses** - Users can save multiple shipping addresses
- **Country management** - International shipping support
- **Address validation** - Structured address format

---

## 🛠️ Tech Stack

### Backend Framework
| Technology | Version | Purpose |
|------------|---------|---------|
| .NET | 8.0 LTS | Core framework |
| ASP.NET Core | 8.0 | Web API framework |
| C# | 12 | Programming language |
| Entity Framework Core | 8.0 | ORM and data access |

### Database & Persistence
| Technology | Purpose |
|------------|---------|
| Microsoft SQL Server 2019+ | Primary relational database |
| Azure SQL Database | Production cloud database |
| EF Core Migrations | Database schema versioning |
| LINQ | Type-safe query composition |

### Security & Authentication
| Technology | Purpose |
|------------|---------|
| JWT (JSON Web Tokens) | Stateless authentication |
| BCrypt.Net | Password hashing algorithm |
| Authorization Policies | Role-based access control |
| CORS | Cross-origin security |

### Real-time Communication
| Technology | Purpose |
|------------|---------|
| SignalR | WebSocket-based real-time updates |
| Azure SignalR Service | Scalable SignalR hosting |
| Chat Hub | Customer support messaging |
| Transaction Hub | Real-time payment notifications |

### AI & Machine Learning
| Technology | Purpose |
|------------|---------|
| Face++ API | Facial recognition and skin analysis |
| TensorFlow/ONNX | Deep learning skin analysis models |
| EfficientNet | Pre-trained image classification |

### Payment Gateways
| Technology | Purpose |
|------------|---------|
| VNPAY | Credit/debit card payments |
| VietQR | QR code bank transfers |
| SePay | Payment webhook processing |

### Architecture & Patterns
| Pattern | Implementation |
|---------|----------------|
| Clean Architecture | Onion Architecture with clear separation |
| Repository Pattern | Data access abstraction layer |
| Unit of Work | Transaction management and atomicity |
| Dependency Injection | Built-in ASP.NET Core DI container |
| Service Layer | Business logic encapsulation |

### Cloud & DevOps
| Technology | Purpose |
|------------|---------|
| Azure App Service | Production hosting |
| Azure SQL | Managed database service |
| Azure Pipelines | CI/CD automation |
| GitHub Actions | Automated deployments |

### Validation & Mapping
| Technology | Purpose |
|------------|---------|
| AutoMapper | Object-to-object mapping (DTOs ↔ Entities) |
| Data Annotations | Model validation attributes |
| Fluent Validation | Complex validation rules |

### External Services
| Service | Purpose |
|---------|---------|
| Firebase Storage | Image and file storage |
| Face++ API | AI skin analysis |
| Cloudinary (optional) | CDN for media files |

### Logging & Monitoring
| Technology | Purpose |
|------------|---------|
| Serilog | Structured logging framework |
| Application Insights | Azure monitoring |
| Console + File sinks | Log output destinations |

---

## 🏗️ System Architecture

```
┌─────────────────────────────────────────────────────────────────────────────┐
│                              CLIENT APPLICATIONS                             │
├──────────────────┬──────────────────┬──────────────────┬───────────────────┤
│   Web Customer   │   Web Staff      │   Web Admin      │   Mobile Apps     │
│   (Next.js)      │   (Next.js)      │   (Next.js)      │   (Future)        │
└────────┬─────────┴────────┬─────────┴────────┬─────────┴─────────┬─────────┘
         │                  │                  │                   │
         └──────────────────┴────────┬─────────┴───────────────────┘
                                     │
                           ┌─────────▼─────────┐
                           │   API Gateway     │
                           │  (ASP.NET Core)   │
                           │  Middleware Stack │
                           └─────────┬─────────┘
                                     │
         ┌───────────────────────────┼───────────────────────────┐
         │                           │                           │
┌────────▼────────┐        ┌─────────▼─────────┐       ┌────────▼────────┐
│  REST API       │        │  SignalR Hubs     │       │ Authentication  │
│  Controllers    │        │  (WebSocket)      │       │  Middleware     │
│  • Auth         │        │  • ChatHub        │       │  • JWT Tokens   │
│  • Products     │        │  • TransactionHub │       │  • RBAC         │
│  • Orders       │        │  • Real-time      │       │  • Security     │
│  • Payments     │        │    Updates        │       │    Headers      │
│  • Analysis     │        └─────────┬─────────┘       └────────┬────────┘
└────────┬────────┘                  │                          │
         │                           │                          │
         └───────────────────────────┼──────────────────────────┘
                                     │
                           ┌─────────▼─────────┐
                           │  Service Layer    │
                           │ (Business Logic)  │
                           │  • Validation     │
                           │  • AI Analysis    │
                           │  • Payments       │
                           └─────────┬─────────┘
                                     │
         ┌───────────────────────────┼───────────────────────────┐
         │                           │                           │
┌────────▼────────┐        ┌─────────▼─────────┐       ┌────────▼────────┐
│  Repository     │        │  External APIs    │       │   AI Services   │
│  Layer          │        │  Integration      │       │   Integration   │
│  • UnitOfWork   │        │  • VNPAY          │       │  • Face++       │
│  • Repositories │        │  • VietQR         │       │  • TensorFlow   │
└────────┬────────┘        │  • SePay          │       │  • EfficientNet │
         │                 └───────────────────┘       └─────────────────┘
         │                           
         ▼                           
┌─────────────────────────────────────────────────────────────────────────┐
│                         Data Access Layer                                │
│  ┌───────────────────────────────────────────────────────────────────┐ │
│  │  Entity Framework Core 8.0                                        │ │
│  │  • SPSSContext                                                    │ │
│  │  • Migrations                                                     │ │
│  │  • Change Tracking                                                │ │
│  └───────────────────────┬───────────────────────────────────────────┘ │
└────────────────────────────┼─────────────────────────────────────────────┘
                             │
         ┌───────────────────┴───────────────────┐
         │                                       │
         ▼                                       ▼
┌─────────────────────────┐         ┌─────────────────────────┐
│  Azure SQL Database     │         │  Firebase Storage       │
│  (Production)           │         │  (Images & Files)       │
└─────────────────────────┘         └─────────────────────────┘
```

### Architecture Layers

```
┌─────────────────────────────────────────────────────────────────┐
│              📱 Presentation Layer (API)                         │
│  • Controllers (39 API Endpoints)                               │
│  • SignalR Hubs (ChatHub, TransactionHub)                       │
│  • Middleware (Auth, Error Handling, CORS, Security)            │
│  • DTOs (Data Transfer Objects)                                 │
└──────────────────────┬──────────────────────────────────────────┘
                       │
┌──────────────────────▼──────────────────────────────────────────┐
│              🎯 Application Layer (Services)                     │
│  • 40+ Business Services                                        │
│  • AI Integration (Face++, TensorFlow)                          │
│  • Payment Processing (VNPAY, VietQR)                           │
│  • AutoMapper Profiles                                          │
└──────────────────────┬──────────────────────────────────────────┘
                       │
┌──────────────────────▼──────────────────────────────────────────┐
│              💼 Domain Layer (BusinessObjects)                   │
│  • 40+ Entities (Domain Models)                                 │
│  • Repository Interfaces                                        │
│  • Business Rules & Validation                                  │
│  • Data Transfer Objects                                        │
└──────────────────────┬──────────────────────────────────────────┘
                       │
┌──────────────────────▼──────────────────────────────────────────┐
│              🗄️ Infrastructure Layer (Repositories)              │
│  • Repository Implementations                                   │
│  • SPSSContext (EF Core)                                        │
│  • External Service Integration                                 │
│  • Unit of Work Pattern                                         │
└─────────────────────────────────────────────────────────────────┘
```

---

## 🚀 Getting Started

### Prerequisites

```bash
# Required
- .NET SDK 8.0 or later
- Microsoft SQL Server 2019+ (or SQL Server Express)
- Visual Studio 2022 / Visual Studio Code / JetBrains Rider

# Optional
- SQL Server Management Studio (SSMS)
- Postman or similar API testing tool
- Azure CLI (for deployment)
```

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/SPSS.git
   cd SPSS/SPSS-BE
   ```

2. **Configure Database Connection**
   
   Create `appsettings.Local.json` (not committed to Git):
   ```json
   {
     "ConnectionStrings": {
       "SPSS": "Server=localhost,1433;Database=spss;User ID=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True"
     }
   }
   ```

3. **Configure JWT Settings**
   ```json
   {
     "Jwt": {
       "Key": "your-secret-key-min-64-characters-for-security",
       "Issuer": "http://localhost:5041",
       "Audience": "http://localhost:3000",
       "AccessTokenExpirationMinutes": 15,
       "RefreshTokenExpirationDays": 7
     }
   }
   ```

4. **Configure AI Services (Face++)**
   ```json
   {
     "FacePlusPlus": {
       "ApiKey": "your-facepp-api-key",
       "ApiSecret": "your-facepp-api-secret",
       "DetectUrl": "https://api-us.faceplusplus.com/facepp/v3/detect",
       "AnalyzeUrl": "https://api-us.faceplusplus.com/facepp/v3/face/analyze"
     }
   }
   ```

5. **Configure Payment Gateways**
   ```json
   {
     "Banking": {
       "BankName": "YOUR_BANK",
       "BankId": "BANK_ID",
       "AccountNumber": "ACCOUNT_NUMBER",
       "AccountName": "ACCOUNT_NAME"
     },
     "VietQR": {
       "ClientId": "your-vietqr-client-id",
       "ApiKey": "your-vietqr-api-key"
     }
   }
   ```

6. **Using User Secrets (Recommended)**
   ```bash
   cd API
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:SPSS" "Server=localhost;Database=spss;..."
   dotnet user-secrets set "Jwt:Key" "your-secret-key"
   dotnet user-secrets set "FacePlusPlus:ApiKey" "your-api-key"
   dotnet user-secrets set "FacePlusPlus:ApiSecret" "your-api-secret"
   ```

7. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

8. **Apply Database Migrations**
   ```bash
   # From the solution directory
   dotnet ef database update --project BusinessObjects --startup-project API
   
   # Or run the included SQL script
   # Execute spss_script.sql in SSMS
   ```

9. **Run the Application**
   ```bash
   cd API
   dotnet run
   ```

10. **Access Swagger UI**
    
    Navigate to: `http://localhost:5041/swagger`

### 🔒 Security Notes

**IMPORTANT**: 
- ❌ **NEVER** commit files containing sensitive information
- ✅ Use `appsettings.Local.json` or User Secrets for development
- ✅ Use Azure App Configuration or Environment Variables for production
- ✅ Files in `.gitignore` will not be committed:
  - `appsettings.Local.json`
  - `appsettings.Production.json`
  - `**/handmade-product-*.json`
  - Other credential files

---

## 📚 API Documentation

### Base URL
- **Development:** `http://localhost:5041/api`
- **Production:** `https://spssapi-hxfzbchrcafgd2hg.southeastasia-01.azurewebsites.net/api`

### Authentication

All protected endpoints require a JWT Bearer token:
```http
Authorization: Bearer <your_jwt_token>
```

### API Modules

#### Authentication (`/api/authentication`)
| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| POST | `/authentication/register` | Register new customer account | ❌ |
| POST | `/authentication/login` | Login and receive JWT token | ❌ |
| POST | `/authentication/refresh-token` | Refresh expired token | ✅ |
| POST | `/authentication/logout` | Logout and invalidate token | ✅ |
| POST | `/authentication/change-password` | Change account password | ✅ |

#### Users & Accounts (`/api/users`, `/api/account`)
| Method | Endpoint | Description | Roles |
|--------|----------|-------------|-------|
| GET | `/users` | List all users (paginated) | Admin |
| GET | `/users/{id}` | Get user by ID | Admin, Staff |
| PUT | `/users/{id}` | Update user | Admin |
| DELETE | `/users/{id}` | Delete user | Admin |
| GET | `/account/profile` | Get current user profile | All |
| PUT | `/account/profile` | Update own profile | All |

#### Products (`/api/products`)
| Method | Endpoint | Description | Roles |
|--------|----------|-------------|-------|
| GET | `/products` | List all products (paginated, filtered) | All |
| GET | `/products/{id}` | Get product details | All |
| POST | `/products` | Create new product | Admin, Staff |
| PUT | `/products/{id}` | Update product | Admin, Staff |
| DELETE | `/products/{id}` | Delete product | Admin |
| GET | `/products/category/{categoryId}` | Products by category | All |
| GET | `/products/brand/{brandId}` | Products by brand | All |

#### Product Items & Variations (`/api/productitems`, `/api/variations`)
| Method | Endpoint | Description | Roles |
|--------|----------|-------------|-------|
| GET | `/productitems` | List product items | All |
| POST | `/productitems` | Create product item | Admin, Staff |
| PUT | `/productitems/{id}` | Update product item | Admin, Staff |
| GET | `/variations` | List variations | All |
| POST | `/variations` | Create variation | Admin |
| GET | `/variationoptions` | List variation options | All |

#### Shopping Cart (`/api/cartitems`)
| Method | Endpoint | Description | Roles |
|--------|----------|-------------|-------|
| GET | `/cartitems` | Get user's cart | Customer |
| POST | `/cartitems` | Add item to cart | Customer |
| PUT | `/cartitems/{id}` | Update cart item quantity | Customer |
| DELETE | `/cartitems/{id}` | Remove item from cart | Customer |
| DELETE | `/cartitems/clear` | Clear entire cart | Customer |

#### Orders (`/api/orders`)
| Method | Endpoint | Description | Roles |
|--------|----------|-------------|-------|
| GET | `/orders` | List all orders | Admin, Staff |
| GET | `/orders/{id}` | Get order details | All (filtered) |
| POST | `/orders` | Create new order | Customer |
| PUT | `/orders/{id}/status` | Update order status | Admin, Staff |
| POST | `/orders/{id}/cancel` | Cancel order | Customer, Admin |
| GET | `/orders/my-orders` | Get customer's orders | Customer |

#### Payments (`/api/vnpay`, `/api/vietqr`, `/api/sepay`)
| Method | Endpoint | Description | Roles |
|--------|----------|-------------|-------|
| POST | `/vnpay/create-payment` | Create VNPAY payment URL | Customer |
| GET | `/vnpay/vnpay-payment` | VNPAY callback handler | System |
| POST | `/vietqr/generate` | Generate VietQR code | Customer |
| POST | `/sepay/webhook` | SePay payment webhook | System |

#### Skin Analysis (`/api/skinanalysis`)
| Method | Endpoint | Description | Roles |
|--------|----------|-------------|-------|
| POST | `/skinanalysis/analyze` | Perform AI skin analysis | Customer |
| GET | `/skinanalysis/history` | Get analysis history | Customer |
| GET | `/skinanalysis/{id}` | Get analysis result | Customer |
| GET | `/skinanalysis/recommendations` | Get product recommendations | Customer |

#### Quiz System (`/api/quizsets`, `/api/quizquestions`, `/api/quizresults`)
| Method | Endpoint | Description | Roles |
|--------|----------|-------------|-------|
| GET | `/quizsets` | List all quiz sets | All |
| GET | `/quizsets/{id}` | Get quiz with questions | All |
| POST | `/quizsets` | Create quiz set | Admin |
| POST | `/quizresults` | Submit quiz answers | Customer |
| GET | `/quizresults/my-results` | Get customer's quiz results | Customer |

#### Chat Support (`/api/chathistory`)
| Method | Endpoint | Description | Roles |
|--------|----------|-------------|-------|
| GET | `/chathistory` | Get chat history | Staff, Admin |
| GET | `/chathistory/{userId}` | Get user's chat history | Staff, Customer |
| POST | `/chathistory` | Save chat message | All |

#### Blog & Content (`/api/blogs`)
| Method | Endpoint | Description | Roles |
|--------|----------|-------------|-------|
| GET | `/blogs` | List all blog posts | All |
| GET | `/blogs/{id}` | Get blog post details | All |
| POST | `/blogs` | Create blog post | Admin, Staff |
| PUT | `/blogs/{id}` | Update blog post | Admin, Staff |
| DELETE | `/blogs/{id}` | Delete blog post | Admin |

#### Dashboard & Analytics (`/api/dashboard`)
| Method | Endpoint | Description | Roles |
|--------|----------|-------------|-------|
| GET | `/dashboard/admin` | Admin dashboard statistics | Admin |
| GET | `/dashboard/financial` | Financial metrics | Admin |
| GET | `/dashboard/staff` | Staff dashboard | Staff |

### SignalR Hubs

#### Chat Hub (`/chathub`)
```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://your-api-url/chathub", {
        accessTokenFactory: () => yourJWTToken
    })
    .build();

// Register as support staff
connection.invoke("RegisterAsSupport");

// Register as user
connection.invoke("RegisterUser", userId);

// Send message
connection.invoke("SendMessage", userId, message, userType);

// Receive messages
connection.on("ReceiveMessage", (message, userType) => {
    console.log("Message received:", message);
});
```

#### Transaction Hub (`/transactionhub`)
```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://your-api-url/transactionhub")
    .build();

// Listen for payment updates
connection.on("PaymentCompleted", (transactionId, status) => {
    console.log("Payment updated:", transactionId, status);
});
```

### Interactive API Documentation

Access the full Swagger/OpenAPI documentation at:
- **Development:** `http://localhost:5041/swagger`
- **Production:** `https://spssapi-hxfzbchrcafgd2hg.southeastasia-01.azurewebsites.net/swagger`

---

## 🗄️ Database Schema

### Core Tables

```
┌──────────────┐     ┌──────────────┐     ┌──────────────┐
│    Users     │────▶│    Roles     │     │   Brands     │
└──────────────┘     └──────────────┘     └──────────────┘
       │                                          │
       ▼                                          ▼
┌──────────────┐     ┌──────────────┐     ┌──────────────┐
│  Addresses   │     │  Products    │◀────│  Categories  │
└──────────────┘     └──────────────┘     └──────────────┘
       │                    │
       │                    ▼
       │            ┌──────────────┐     ┌──────────────┐
       │            │ ProductItems │────▶│  Variations  │
       │            └──────────────┘     └──────────────┘
       │                    │
       ▼                    ▼
┌──────────────┐     ┌──────────────┐     ┌──────────────┐
│   Orders     │────▶│OrderDetails  │     │   Reviews    │
└──────────────┘     └──────────────┘     └──────────────┘
       │
       ▼
┌──────────────┐     ┌──────────────┐     ┌──────────────┐
│ Transactions │     │ SkinAnalysis │     │  QuizResults │
└──────────────┘     └──────────────┘     └──────────────┘
```

### Key Entities (40+ Tables)

#### Users & Authentication
- **Users** - User accounts with profile information
- **Roles** - Role definitions (Admin, Staff, Customer)
- **Addresses** - User shipping addresses
- **RefreshTokens** - JWT refresh token storage

#### Products & Catalog
- **Products** - Main product information
- **ProductItems** - Specific product variants (size, volume)
- **ProductCategories** - Category hierarchy
- **Brands** - Product brands
- **ProductImages** - Product gallery
- **Variations** - Variation types (Size, Volume)
- **VariationOptions** - Variation values (50ml, 100ml)
- **ProductConfigurations** - Product-variation mapping

#### E-Commerce
- **CartItems** - Shopping cart items
- **Orders** - Customer orders
- **OrderDetails** - Order line items
- **Vouchers** - Discount codes
- **PaymentMethods** - Available payment options
- **Transactions** - Payment transactions
- **StatusChanges** - Order status history
- **CancelReasons** - Order cancellation reasons

#### Skin Analysis & Quiz
- **SkinAnalysisResults** - AI analysis results
- **SkinAnalysisIssues** - Detected skin issues
- **SkinAnalysisRecommendations** - Product recommendations
- **SkinTypes** - Skin type definitions
- **ProductForSkinTypes** - Product-skin type mapping
- **QuizSets** - Quiz configurations
- **QuizQuestions** - Quiz questions
- **QuizOptions** - Answer options
- **QuizResults** - Customer quiz results

#### Content & Support
- **Blogs** - Blog posts
- **BlogSections** - Blog content sections
- **Reviews** - Product reviews
- **ReviewImages** - Review attachments
- **Replies** - Review replies
- **ChatHistories** - Support chat messages

### Database Migrations

```bash
# Create new migration
dotnet ef migrations add MigrationName --project BusinessObjects --startup-project API

# Update database
dotnet ef database update --project BusinessObjects --startup-project API

# Rollback migration
dotnet ef database update PreviousMigrationName --project BusinessObjects --startup-project API

# Generate SQL script
dotnet ef migrations script --project BusinessObjects --startup-project API --output migration.sql
```

---

## 📦 Deploy to Azure

### GitHub Actions CI/CD

The project includes Azure Pipelines configuration for automated deployment:

1. **Create Azure Resources**
   - Azure SQL Database
   - Azure App Service (Linux, .NET 8)
   - Azure SignalR Service

2. **Configure GitHub Secrets**
   ```
   AZURE_WEBAPP_PUBLISH_PROFILE - Download from App Service
   ```

3. **Push to Deploy**
   ```bash
   git push origin main
   # Automatic deployment triggered
   ```

See detailed guide in `.github/DEPLOYMENT_GUIDE.md`

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

### How to Contribute

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Code Standards
- Follow [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Write XML documentation for public APIs
- Include unit tests for new features
- Ensure all tests pass before submitting PR
- Use meaningful commit messages

---

## 📄 License

This project is developed for educational and portfolio purposes.

---

## 📊 Project Statistics

- **Development Time:** 4 months (9/2024 - 12/2024)
- **Team Size:** 5 developers
- **Lines of Code:** ~20,000+
- **API Endpoints:** 39 Controllers, 100+ endpoints
- **Database Tables:** 40+ normalized tables
- **Services:** 40+ business logic services
- **SignalR Hubs:** 2 real-time communication hubs
- **External Integrations:** Face++, VNPAY, VietQR, Firebase

---

<div align="center">

### ⭐ If you find this project helpful, please consider giving it a star!

**Built with ❤️ by SPSS Team**

[Back to Top](#-spss-backend)

</div>
- Production: https://spssapi-hxfzbchrcafgd2hg.southeastasia-01.azurewebsites.net/swagger
