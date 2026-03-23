# TaskApi

A simple REST API for managing tasks (todo items) built with ASP.NET Core Minimal API.

## Overview

TaskApi is a lightweight web API that allows you to perform CRUD (Create, Read, Update, Delete) operations on tasks. It's built using .NET 8 and ASP.NET Core Minimal API, providing a clean and efficient way to manage your todo list.

## Features

- **GET /tasks**: Retrieve all tasks
- **POST /tasks**: Create a new task
- **PUT /tasks/{id}**: Update an existing task
- **DELETE /tasks/{id}**: Delete a task
- **GET /health**: Health check endpoint
- Swagger UI for API documentation and testing
- Docker support for containerization

## Project Structure

```
TaskApi/
├── src/
│   └── TaskApi/
│       ├── Program.cs                 # Main application entry point
│       ├── TaskApi.csproj            # Project file
│       ├── appsettings.json          # Application settings
│       ├── appsettings.Development.json # Development settings
│       ├── TaskApi.http              # HTTP requests for testing
│       └── Properties/
│           └── launchSettings.json    # Launch profiles
├── tests/
│   └── TaskApi.Tests/
│       ├── UnitTest1.cs              # Unit tests
│       └── TaskApi.Tests.csproj      # Test project file
├── Dockerfile                        # Docker configuration
├── TaskApi.sln                       # Solution file
└── README.md                         # This file
```

## Prerequisites

- .NET 8.0 SDK
- (Optional) Docker for containerization

## Getting Started

### Running Locally

1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd TaskApi
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the application:
   ```bash
   dotnet run --project src/TaskApi/TaskApi.csproj
   ```

4. Open your browser and navigate to `http://localhost:5125/swagger` to access the Swagger UI.

### Running with Docker

1. Build the Docker image:
   ```bash
   docker build -t taskapi .
   ```

2. Run the container:
   ```bash
   docker run -p 8080:8080 taskapi
   ```

3. Access the API at `http://localhost:8080/swagger`.

## API Endpoints

### Tasks

- **GET /tasks**
  - Returns a list of all tasks.

- **POST /tasks**
  - Creates a new task.
  - Body: `{ "title": "Task title", "isComplete": false }`

- **PUT /tasks/{id}**
  - Updates an existing task.
  - Body: `{ "title": "Updated title", "isComplete": true }`

- **DELETE /tasks/{id}**
  - Deletes a task by ID.

### Health Check

- **GET /health**
  - Returns "Healthy" for monitoring purposes.

## Task Model

```json
{
  "id": 1,
  "title": "Sample Task",
  "isComplete": false
}
```

## Testing

Run the tests using:

```bash
dotnet test
```

## Technologies Used

- ASP.NET Core Minimal API
- .NET 8.0
- Swagger/OpenAPI for API documentation
- xUnit for unit testing
- Docker for containerization

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if necessary
5. Submit a pull request

## License

This project is licensed under the MIT License.</content>
<parameter name="filePath">d:\dotnet-taskapi\README.md