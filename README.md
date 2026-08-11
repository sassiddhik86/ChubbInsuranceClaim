# CHubb Insurance Claims Management API

A simple and scalable **Insurance Claims Management Backend API** built using **ASP.NET Core .NET 8**, Entity Framework Core, JWT Authentication, Clean Architecture, Service Layer, Repository Pattern, and Unit of Work.

The system supports both **claimants/customers** and **claims staff**.

Customers can report incidents, submit claims, track claim progress, and provide additional information when requested.

Claims staff can review claims, assign claims, request additional information, approve or reject claims, and complete settlements.

---

## 1. Technology Stack

**Backend**

* C#
* ASP.NET Core Web API (.NET 8)
* Entity Framework Core
* SQLite (In-Memory Database)

**Security**

* JWT Bearer Authentication
* Role based Authorization
* BCrypt password hashing

**Testing & Tools**

* Swagger (with JWT Bearer support)
* .NET CLI
* In-memory database (unit tests)

**Architecture**

* Clean Architecture
* SOLID Principles
* Repository Pattern
* Unit of Work Pattern
* Business Service Layer Pattern
* Dependency Injection
* Global Exception Middleware

---
---

# 2. Main Features

## Authentication

* User registration
* User login
* JWT authentication
* Custom User entity
* Custom Role entity
* Password hashing
* Role-based authorization

Supported roles:

```text
Customer
ClaimOfficer
Supervisor
Admin
```

---

## Incident Management

Customers can:

* Report an incident
* View an incident
* Update an incident

Example incident:

```text
Vehicle accident
Location: Kuala Lumpur
Incident Date: 2026-08-01
Police Report: POL-2026-001
```

---

## Claim Management

Customers can:

* Create claims
* View their claims
* View claim details
* Update claims
* Track claim status

---

## Claim Processing

Claims staff can:

* Assign claims
* Start claim review
* Request additional information
* Review submitted information
* Approve claims
* Reject claims
* Complete settlements

---

# 3. Project Structure

```text
InsuranceClaims
│
├── InsuranceClaims.sln
│
├── InsuranceClaims.Domain
│   │
│   ├── Entities
│   │   ├── User.cs
│   │   ├── Role.cs
│   │   ├── Claim.cs
│   │   ├── Incident.cs
│   │   ├── ClaimAssignment.cs
│   │   └── ClaimStatusHistory.cs
│   │
│   └── Enums
│       ├── ClaimStatus.cs
│       ├── IncidentType.cs
│       └── ...
│
│
├── InsuranceClaims.Application
│   │
│   ├── DTOs
│   │   ├── Auth
│   │   ├── Claim
│   │   ├── Incident
│   │   └── Dashboard
│   │
│   ├── Interfaces
│   │   └── Services
│   │
│   ├── Services
│   │   ├── AuthService.cs
│   │   ├── ClaimService.cs
│   │   ├── ClaimWorkflowService.cs
│   │   ├── IncidentService.cs
│   │   └── DashboardService.cs
│   │
│   └── DependencyInjection.cs
│
│
├── InsuranceClaims.Infrastructure
│   │
│   ├── Data
│   │   ├── ApplicationDbContext.cs
│   │   └── Configurations
│   │
│   ├── Repositories
│   │
│   ├── UnitOfWork
│   │
│   ├── Authentication
│   │
│   └── DependencyInjection.cs
│
│
└── InsuranceClaims.API
    │
    ├── Controllers
    │   ├── AuthController.cs
    │   ├── IncidentsController.cs
    │   ├── ClaimsController.cs
    │   └── DashboardController.cs
    │
    ├── Middlewares
    │   └── GlobalExceptionMiddleware.cs
    │
    ├── Extensions
    │   └── SwaggerExtension.cs
    │
    ├── Program.cs
    └── appsettings.json
```

# 5. Claim Workflow

The main claim lifecycle is:

```text
Submitted
    │
    ▼
Assigned
    │
    ▼
UnderReview
    │
    ├───────────────┐
    │               │
    ▼               ▼
Approved      NeedMoreInformation
    │               │
    │               ▼
    │        InformationReceived
    │               │
    └───────► UnderReview
                    │
                    ▼
                Approved
                    │
                    ▼
                Settled
```

A claim can also be rejected:

```text
UnderReview
     │
     ▼
Rejected
```

---

# 6. API Endpoints

## Authentication

### Register

```http
POST /api/auth/register
```

Example:

```json
{
  "fullName": "John Customer",
  "employeeNumber": "CUS001",
  "email": "customer@test.com",
  "password": "Password@123"
}
```

---

### Login

```http
POST /api/auth/login
```

Example:

```json
{
  "email": "customer@test.com",
  "password": "Password@123"
}
```

The response contains the JWT token.

---

# 7. Incident APIs

### Create Incident

```http
POST /api/incidents
Authorization: Bearer <token>
```

### Get Incident

```http
GET /api/incidents/{id}
Authorization: Bearer <token>
```

### Update Incident

```http
PUT /api/incidents/{id}
Authorization: Bearer <token>
```

---

# 8. Claim APIs

### Create Claim

```http
POST /api/claims
Authorization: Bearer <token>
```

### Get My Claims

```http
GET /api/claims/my
Authorization: Bearer <token>
```

### Get Claim

```http
GET /api/claims/{id}
Authorization: Bearer <token>
```

### Update Claim

```http
PUT /api/claims/{id}
Authorization: Bearer <token>
```

---

# 9. Claim Workflow APIs

### Assign Claim

Roles:

```text
Supervisor
Admin
```

```http
PUT /api/claims/{id}/assign
Authorization: Bearer <token>
```

Example:

```json
{
  "officerId": 2
}
```

---

### Start Review

Role:

```text
ClaimOfficer
```

```http
PUT /api/claims/{id}/review
Authorization: Bearer <token>
```

---

### Request Additional Information

Role:

```text
ClaimOfficer
```

```http
PUT /api/claims/{id}/request-information
Authorization: Bearer <token>
```

Example:

```json
{
  "information": "Please provide the vehicle repair quotation."
}
```

---

### Submit Additional Information

Role:

```text
Customer
```

```http
PUT /api/claims/{id}/submit-information
Authorization: Bearer <token>
```

Example:

```json
{
  "information": "Vehicle repair quotation submitted."
}
```

---

### Approve Claim

Role:

```text
ClaimOfficer
```

```http
PUT /api/claims/{id}/approve
Authorization: Bearer <token>
```

Example:

```json
{
  "remarks": "Claim approved after assessment."
}
```

---

### Reject Claim

Role:

```text
ClaimOfficer
```

```http
PUT /api/claims/{id}/reject
Authorization: Bearer <token>
```

Example:

```json
{
  "remarks": "Claim rejected based on policy assessment."
}
```

---

### Settle Claim

Role:

```text
Supervisor
```

```http
PUT /api/claims/{id}/settle
Authorization: Bearer <token>
```

Example:

```json
{
  "remarks": "Settlement completed."
}
```

---

# 10. Dashboard APIs

## Customer Dashboard

```http
GET /api/dashboard/customer
Authorization: Bearer <token>
```

Role:

```text
Customer
```

---

## Officer Dashboard

```http
GET /api/dashboard/officer
Authorization: Bearer <token>
```

Role:

```text
ClaimOfficer
```

---

## Supervisor Dashboard

```http
GET /api/dashboard/supervisor
Authorization: Bearer <token>
```

Role:

```text
Supervisor
```

---

# 11. Authentication

The API uses JWT Bearer Authentication.

Example HTTP header:

```http
Authorization: Bearer eyJhbGciOiJIUzI1NiIs...
```

JWT contains information such as:

```text
User ID
Email
Name
Role
```

The role is used by ASP.NET Core authorization:

```csharp
[Authorize(Roles = "Customer")]
```

or:

```csharp
[Authorize(Roles = "ClaimOfficer")]
```

or:

```csharp
[Authorize(Roles = "Supervisor")]
```

---

# 12. No ASP.NET Identity

This application intentionally does not use:

```text
ApplicationUser
ApplicationRole
UserManager
RoleManager
SignInManager
```

Instead, the application has its own business entities:

```text
User
Role
```

Relationship:

```text
User
  │
  └── RoleId
       │
       ▼
      Role
```

This makes the authentication model easier to customize according to the insurance business requirements.

---

# 13. Repository Pattern

Repositories provide database access.

Example:

```text
IClaimRepository
      │
      ▼
ClaimRepository
      │
      ▼
Entity Framework Core
```

Business services do not directly access `DbContext`.

Example:

```csharp
var claim =
    await _unitOfWork.Claims.GetByIdAsync(claimId);
```

---

# 14. Unit of Work

The Unit of Work coordinates repositories.

```text
IUnitOfWork
│
├── Users
├── Roles
├── Claims
├── Incidents
├── ClaimAssignments
└── ClaimStatusHistories
```

Changes are committed through:

```csharp
await _unitOfWork.SaveChangesAsync();
```

---

# 15. Business Service Layer

Controllers do not contain business logic.

The flow is:

```text
HTTP Request
     │
     ▼
Controller
     │
     ▼
Service
     │
     ▼
Unit Of Work
     │
     ▼
Repository
     │
     ▼
EF Core
     │
     ▼
Database
```

Example:

```text
ClaimsController
       │
       ▼
ClaimService
       │
       ▼
IUnitOfWork
       │
       ▼
ClaimRepository
       │
       ▼
ApplicationDbContext
```

---

# 16. CQRS

CQRS is intentionally **not used**.

The application uses a straightforward:

```text
Controller
    ↓
Service
    ↓
Repository
    ↓
EF Core
```

architecture.

This keeps the project simple and easy to maintain.

---

# 17. Global Exception Handling

All unhandled exceptions are handled by:

```text
GlobalExceptionMiddleware.cs
```

Example response:

```json
{
  "success": false,
  "statusCode": 404,
  "message": "Claim not found.",
  "timestamp": "2026-08-11T10:00:00Z"
}
```

This avoids putting repetitive `try/catch` blocks in every controller.

---

# 18. Swagger

Swagger is enabled for API testing.

After running the application, open:

```text
/swagger
```

Use the following sequence:

```text
1. Register Customer
       ↓
2. Login
       ↓
3. Copy JWT
       ↓
4. Click Authorize
       ↓
5. Enter Bearer <JWT>
       ↓
6. Create Incident
       ↓
7. Create Claim
       ↓
8. View My Claims
       ↓
9. Login as Supervisor
       ↓
10. Assign Claim
       ↓
11. Login as ClaimOfficer
       ↓
12. Start Review
       ↓
13. Request Information
       ↓
14. Login as Customer
       ↓
15. Submit Information
       ↓
16. Login as ClaimOfficer
       ↓
17. Approve / Reject
       ↓
18. Login as Supervisor
       ↓
19. Settle Claim
       ↓
20. Check Dashboard
```

---

# 19. Local Setup

## Prerequisites

Install:

* .NET 8 SDK
* Visual Studio 2022 or VS Code
* SQL Server or SQLite
* Swagger-compatible browser

Check .NET:

```bash
dotnet --version
```

Expected:

```text
8.x.x
```

---

# 20. Configure Database

Update:

```text
InsuranceClaims.API/appsettings.json
```

Example SQL Server configuration:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=InsuranceClaimsDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

If using SQL Server authentication:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=InsuranceClaimsDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
  }
}
```

---

# 21. Configure JWT

In `appsettings.json`:

```json
{
  "Jwt": {
    "Key": "YOUR_SUPER_SECRET_KEY_AT_LEAST_32_CHARACTERS",
    "Issuer": "InsuranceClaimsAPI",
    "Audience": "InsuranceClaimsClient",
    "ExpiryInMinutes": 120
  }
}
```

For production, do not commit real JWT secrets to source control.

Use environment variables or a secret store.

---

# 22. Install Packages

From the solution directory:

```bash
dotnet restore
```

Build:

```bash
dotnet build
```

---

# 23. Entity Framework Core Migration

From Package Manager Console:

```powershell
Add-Migration InitialCreate
```

Then:

```powershell
Update-Database
```

Or using the .NET CLI:

```bash
dotnet ef migrations add InitialCreate
```

Then:

```bash
dotnet ef database update
```

If the migration already exists, do not create another migration with the same name.

---

# 24. Run the Application

From the API project:

```bash
dotnet run
```

Or:

```bash
dotnet run --project InsuranceClaims.API
```

The console will show something similar to:

```text
Now listening on:
https://localhost:7xxx
```

Open:

```text
https://localhost:7xxx/swagger
```

---

# 25. Build the Complete Solution

From the solution root:

```bash
dotnet build
```

Run:

```bash
dotnet run --project InsuranceClaims.API
```

---

# 26. Recommended Test Data

Create these users:

```text
Customer

Email:
customer@test.com

Password:
Password@123
```

```text
Claim Officer

Email:
officer@test.com

Password:
Password@123
```

```text
Supervisor

Email:
supervisor@test.com

Password:
Password@123
```

The current registration logic assigns the default Customer role. Therefore, ClaimOfficer and Supervisor accounts should be created through seed data or assigned their roles directly in the database.

---

# 27. Example End-to-End Scenario

### Step 1 — Customer Login

```text
customer@test.com
```

### Step 2 — Report Incident

```text
Vehicle accident
```

### Step 3 — Submit Claim

```text
Claim Amount = RM 5,000
```

### Step 4 — Claim Submitted

```text
Submitted
```

### Step 5 — Supervisor Assigns Officer

```text
Assigned
```

### Step 6 — Officer Starts Review

```text
UnderReview
```

### Step 7 — Officer Requests Information

```text
NeedMoreInformation
```

### Step 8 — Customer Provides Information

```text
InformationReceived
```

### Step 9 — Officer Approves

```text
Approved
```

### Step 10 — Supervisor Settles

```text
Settled
```

---

# 28. Design Principles

The project follows:

### Single Responsibility

Each service has a focused responsibility.

### Dependency Injection

Dependencies are injected through constructors.

### Repository Pattern

Database access is isolated from business logic.

### Unit of Work

Coordinates multiple repository operations.

### Clean Architecture

Business logic is separated from infrastructure and presentation.

### DTOs

API contracts are separated from database entities.

### Role-Based Authorization

Access is controlled using JWT roles.

---

# 29. Simplified Request Flow

```text
                         CLIENT
                           │
                           ▼
                    ASP.NET WEB API
                           │
                           ▼
                     JWT Middleware
                           │
                           ▼
                       Controller
                           │
                           ▼
                    Business Service
                           │
                           ▼
                       UnitOfWork
                           │
                           ▼
                       Repository
                           │
                           ▼
                    Entity Framework
                           │
                           ▼
                        Database
```

---

# 30. Future Enhancements

The current implementation intentionally keeps the project small.

Possible future additions:

* Document management
* File uploads
* Email notifications
* SMS notifications
* Payment processing
* Advanced audit logging
* Claim timeline API
* Pagination
* Filtering and sorting
* API versioning
* Rate limiting
* Redis caching
* Background jobs
* Azure Service Bus
* Azure Key Vault
* Application Insights
* Refresh tokens
* Automated unit/integration testing
* React frontend

These can be added without changing the fundamental architecture.

---

# 31. Summary

This project provides a simple, maintainable insurance claims backend using:

```text
.NET 8
ASP.NET Core Web API
        +
Clean Architecture
        +
Custom User / Role
        +
JWT Authentication
        +
Business Service Layer
        +
Repository Pattern
        +
Unit Of Work
        +
Entity Framework Core
        +
Swagger
        +
Global Exception Handling
```

The application intentionally avoids:

```text
ASP.NET Identity
CQRS
MediatR
Refresh Tokens
```

The result is a **small, easy-to-understand backend** that can be extended into a larger insurance claims platform as business requirements grow.
