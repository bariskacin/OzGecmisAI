# OzGecmisAI

OzGecmisAI is a resume management API built with ASP.NET Core that allows users to create, manage, and store their resumes with detailed information including personal details, work experience, education, and skills.

## Features

- Create and manage multiple resumes
- Store detailed personal information
- Track work experience
- Manage education history
- List and categorize skills
- RESTful API endpoints
- Entity Framework Core with SQLite database

## Technologies

- ASP.NET Core
- Entity Framework Core
- SQLite
- C# 10.0

## API Endpoints

- `POST /api/resumes` - Create a new resume
- `GET /api/resumes/user/{userId}` - Get all resumes for a specific user
- `GET /api/resumes/{id}` - Get a specific resume by ID
- `PUT /api/resumes/{id}` - Update an existing resume
- `DELETE /api/resumes/{id}` - Delete a resume

## Getting Started

### Prerequisites

- .NET 10.0 SDK or later
- Visual Studio 2022 or Visual Studio Code

### Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/OzGecmisAI.git
```

2. Navigate to the project directory:
```bash
cd OzGecmisAI
```

3. Restore NuGet packages:
```bash
dotnet restore
```

4. Update the database:
```bash
dotnet ef database update
```

5. Run the application:
```bash
dotnet run
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.