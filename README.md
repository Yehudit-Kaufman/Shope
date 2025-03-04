# Project WEB API .NET 8

## Introduction
Welcome to the WEB API project built with .NET 8. The project focuses on REST architecture principles while maintaining clean code and high standards.

## Project Structure
The project is divided into several layers, each performing a unique role:
- **Controller**: Responsible for client-server communication and handling error statuses.
- **Service**: Responsible for validation and business logic.
- **Repository**: Responsible for database access.

### Dependency Injection (DI)
The layers communicate with each other using Dependency Injection (DI). Using DI allows for easier maintenance of the code and enables convenient unit testing (Unit Tests). The advantage is that the logic is written once and can be injected wherever needed in the project. The logic is written in the `program.cs` file - the dependency manager.

## DTO
The project uses DTOs defined as records because there is no need to modify the objects. The advantages of using DTOs include:
1. Returning or receiving part of the object instead of the whole for security purposes, etc.
2. Removing circular dependencies between objects that depend on each other.
3. Validation checks.

### Why Layers?
- **Separation of concerns**: Each layer has a distinct responsibility.
- **Scalability**: The architecture supports adding new features without affecting existing code.
- **Testability**: Layers make it easier to write unit and integration tests.

## Data Conversion
Data conversion between layers is done using AutoMapper, a tool that allows automatic conversion between objects. We used the async/await mechanism with scalability in mind.

### Key Features
- **AutoMapper**: Used for mapping between DTOs and domain entities.
- **Dependency Injection (DI)**: Services and repositories are injected using .NET’s built-in DI to ensure loose coupling.
- **Asynchronous Processing**: Implemented using async/await for scalability and performance.
- **SQL Database with Code First Approach**: The database is managed using Entity Framework Core with migrations.
- **Configuration Management**: App settings are managed through config files.
- **Global Error Handling (Middleware)**: Errors are logged and fatal errors are sent via email.
- **Request Logging**: Every request is logged for analytics and rating purposes.
- **Caching of API requests**.

## Database
The project uses a SQL DB with a Db First approach. The config file is used to manage project settings, allowing the definition of environment variables and database connection strings - stored separately from the source code. The config file allows defining applications and other settings that can be updated or changed easily without modifying the main code base.

## Error Handling
All errors are handled by Error Middleware. Errors are logged to a Logger, and fatal errors are sent by email to the support team.



## Request Analysis
All requests in the system are saved in a rating table in the database for rating and request analysis purposes.

## Clean Code
We place a strong emphasis on writing clean, readable, and maintainable code.

## Conclusion
Thank you for choosing to use our project. We hope the project will meet your expectations and provide a high-quality, professional solution.