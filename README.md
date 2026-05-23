# Project & Task Management API

Backend API built using ASP.NET Core Web API following Clean Architecture principles.

## Features

- JWT Authentication
- Projects Management
- Tasks Management
- CQRS with MediatR
- FluentValidation
- Entity Framework Core

---

## Technologies Used

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- MediatR
- FluentValidation

---

## Architecture

The project follows Clean Architecture:

- Domain Layer
- Application Layer
- Infrastructure Layer
- API Layer

---

## Setup Instructions

1. Clone repository
2. Update connection string in appsettings.json
3. Open Package Manager Console
4. Run:

```powershell
Update-Database
```

5. Run the project

---

## Authentication

Use:
- /api/Auth/register
- /api/Auth/login

Copy JWT token and use it as Bearer Token.

---

## API Testing

Swagger and Postman Collection are included.