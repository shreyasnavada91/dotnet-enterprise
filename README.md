# .NET Enterprise SaaS - 2019-2023

## Overview
Enterprise-class SaaS application built with .NET Core and TypeScript.

## Technologies (2019-2023)
- **Backend**: .NET Core 3.1, C# 8, ASP.NET Core
- **Frontend**: React 17, TypeScript, Entity Framework Core
- **Database**: SQL Server, PostgreSQL
- **DevOps**: Docker, Kubernetes, Azure DevOps

## Architecture
```
[Client] <--API/REST--> [API Gateway] <--Service--> [Database]
                            |
                    [Service Bus]
```

## Key Features
1. Multi-tenant SaaS architecture
2. RESTful API design with dependency injection
3. Unit testing with xUnit
4. Docker containerization
5. CI/CD pipelines with Azure DevOps

## Bug Fixes Applied
1. **NullReferenceException** - Added null checking with Elvis operator
2. **Entity Framework Performance** - Fixed N+1 query issues
3. **CORS Configuration** - Fixed preflight request handling
4. **Memory Leaks** - Proper disposal of db contexts

## Build & Run (2023 Style)
```bash
# Backend
dotnet restore
dotnet run

# Frontend
npm install
npm start
```
