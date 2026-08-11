# Chubb Insurance Claims Management API

A simple and scalable **Chubb Insurance Claims Management Backend API** built using **ASP.NET Core .NET 8**, Entity Framework Core, JWT Authentication, Clean Architecture, Service Layer, Repository Pattern, and Unit of Work.

The system supports both **claimants/customers** and **claims staff**.

Customers can report incidents, submit claims, track claim progress, and provide additional information when requested.

Claims staff can review claims, assign claims, request additional information, approve or reject claims, and complete settlements.

---

## 1. Tech Stack

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

---

# 4. API Endpoints

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
```

### Update Incident

```http
PUT /api/incidents/{id}
```

---

# 8. Claim APIs

### Create Claim

```http
POST /api/claims
```

### Get My Claims

```http
GET /api/claims/my
```

### Get Claim

```http
GET /api/claims/{id}
```

### Update Claim

```http
PUT /api/claims/{id}
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
```

---

### Request Additional Information

Role:

```text
ClaimOfficer
```

```http
PUT /api/claims/{id}/request-information
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
```

Role:

```text
Customer
```

---

## Officer Dashboard

```http
GET /api/dashboard/officer
```

Role:

```text
ClaimOfficer
```

---

## Supervisor Dashboard

```http
GET /api/dashboard/supervisor
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
### Dependency Injection
### Repository Pattern
### Unit of Work
### Clean Architecture
### DTOs
### Role-Based Authorization

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

