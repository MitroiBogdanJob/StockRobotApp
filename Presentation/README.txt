
# Stock Robot Application

## Overview

  This is a C# .NET application designed to manage and display stock information.
  The application is structured following the Clean Architecture principles, separating responsibilities across different parts of the codebase. 
  The main idea is to decouple the business logic from the infrastructure and presentation layers.
  
### Project Structure

- Core: Contains the core entities and interfaces that define the contracts for the application's basic operations, such as `IStockRepository` and the `Stock` entity.
- Application: Includes interfaces and business logic required to implement use cases like `IGetStockDetailsUseCase`.
- Infrastructure: Implementation of the interfaces defined in Core, e.g., `StockRepository` implementing the `IStockRepository` interface.
- Presentation: Manages the interaction with the end-user, including configuration files and controllers to expose the application’s functionality, such as `StockController`.

## Prerequisites

- .NET 8 SDK**: Ensure you have .NET 8 SDK installed on your development machine.
-  The json file.

## Setup and Configuration

1. **Clone and Navigate to the Project**:
  You can clone the project using Visual Studio 2022 : 
   git clone <https://github.com/MitroiBogdanJob/StockRobotApp.git>

2. If there is any problem with any nuget package, run the command: dotnet restore

If you don't know how to run the command, these are the steps: 
Access the "View" menu: from the menu bar at the top of the Visual Studio window, click View.
Select "Terminal": in the View menu, look for and select the Terminal option. This will open a terminal built into Visual Studio.
Select PowerShell:in the open terminal, there is a drop-down menu on the right (by default it shows cmd or PowerShell).
Click that drop-down menu and select PowerShell if it's not already selected.

## Running the Application

- The application will be available by default at `http://localhost:5000`.

## Directory Structure

- `Application`: Contains use cases and logical interfaces.
- `Core`: Defines core entities and contracts.
- `Infrastructure`: Implements data abstractions.
- `Presentation`: Responsible for UI and API layers.

## Additional Information

- **Middleware**: The application uses `ExceptionHandlingMiddleware` for global error handling.

