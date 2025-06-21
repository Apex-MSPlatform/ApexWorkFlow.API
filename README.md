# ApexWorkflow Service

## Overview

ApexWorkflow is a microservice within the Apex HR system designed to manage business workflow processes including multi-step approvals and dynamic routing. It enables administrators to define reusable workflow templates and supports complex approval policies that can be customized per user or role.

## Features

- Define and version workflow templates
- Support for multi-step approvals with conditional logic
- Manage workflow instances linked to business requests
- Track individual approval steps and approvers
- Audit trail of all approval actions
- Policy overrides for custom routing rules
- Integration with Apex Security service for user/role validation
- Built with Clean Architecture for maintainability and scalability

## Architecture

- **Domain Layer**: Entities and repository abstractions
- **Application Layer**: Business logic and use cases
- **Infrastructure Layer**: EF Core persistence and repository implementations
- **API Layer**: REST endpoints for workflow operations

## Prerequisites

- .NET 7 or later
- SQL Server (or compatible database)
- Access to Apex Security Service

## Getting Started

1. Clone the repository
2. Configure database connection in `appsettings.json`
3. Setup Apex Security Service base URL in `appsettings.json`
4. Run EF Core migrations:
   ```bash
   dotnet ef migrations add InitialCreate --startup-project ./ApexWorkFlow.API --project ./Infrastructure --output-dir Persistence/Migrations
   dotnet ef database update
   ```
