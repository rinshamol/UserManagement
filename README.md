🧑‍💻 User Management API – ASP.NET Core Web API

A RESTful User Management API built using ASP.NET Core Web API.
This project demonstrates CRUD operations, validation, middleware usage, and API documentation using Swagger.

📌 Features

Create, Read, Update, and Delete users (CRUD)

Input validation using Data Annotations

Global exception handling middleware

Request logging middleware

Swagger UI for API documentation and testing

Clean, layered folder structure

In-memory database (Entity Framework Core)

🛠️ Tech Stack

ASP.NET Core Web API

Entity Framework Core (InMemory)

Swagger / Swashbuckle

C#

Git & GitHub

📂 Project Structure
UserManagementApi/
│
├── Controllers/
│   └── UsersController.cs
│
├── Models/
│   └── User.cs
│
├── Dtos/
│   ├── UserCreateDto.cs
│   ├── UserUpdateDto.cs
│   └── UserResponseDto.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Middlewares/
│   ├── RequestLoggingMiddleware.cs
│   └── ExceptionHandlingMiddleware.cs
│
├── Mapping/
│   └── UserMappingExtensions.cs
│
├── Program.cs
├── appsettings.json
└── UserManagementApi.sln

🚀 Getting Started
1️⃣ Clone the Repository
```git clone https://github.com/<your-username>/user-management-api-dotnet.git```
cd user-management-api-dotnet

2️⃣ Restore Dependencies
```dotnet restore```

3️⃣ Run the Application
```dotnet run```

📄 Swagger API Documentation

After running the application, open Swagger UI:

```https://localhost:<PORT>/swagger```


Example:

```https://localhost:7243/swagger```


Swagger allows you to test all API endpoints easily.

🔗 API Endpoints
Method	Endpoint	Description
GET	/api/users	Get all users
GET	/api/users/{id}	Get user by ID
POST	/api/users	Create new user
PUT	/api/users/{id}	Update existing user
DELETE	/api/users/{id}	Delete user
✅ Validation

Required fields are enforced

Email format validation

Age range validation

Duplicate email checks

Automatic 400 Bad Request responses for invalid data

🔐 Middleware Used

Request Logging Middleware

Logs HTTP method, path, status code, and execution time

Global Exception Handling Middleware

Handles unhandled exceptions

Returns consistent error responses

🤖 GitHub Copilot Usage

GitHub Copilot was used during development to:

Debug controller logic

Improve validation and error handling

Optimize middleware implementation

Speed up development

📦 Version Control

GitHub repository created and maintained

.gitignore configured to exclude bin/, obj/, and IDE files

Clean commit history

📝 Notes

This project uses In-Memory Database for simplicity

No external database setup is required

Suitable for learning, assignments, and demonstrations

👩‍💻 Author

Rinsha Mol K S
Software Developer
GitHub: https://github.com/
<your-username>

✅ License

This project is for educational purposes.
