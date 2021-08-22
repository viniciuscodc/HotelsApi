# HotelsApi

A .NET 5 web api. 

Features:
- Utilizing jwt token authentication
- Generic repository pattern
- Api paging
- Caching
- Generic error handling
- Entity framework with postgres
- Custom logging with serilog
- API documentation using SwaggerUI

# Database
The entity framework core was used to manage the database and is configured to use postgres. To adjust the database the connection string in InAndOut.csproj must be modified for the database used. Entity framework can be installed to generate tables automatically:

Visual studio:

```
Add-Migration "name"
```

```
Update-database
```

Cli:

```
dotnet tool install --global dotnet ef
```

```
dotnet ef migrations add "name"
```

```
dotnet ef database update
```


# Running
To run the application a .net runtime must be installed, it's available for all platforms. It can be run using visual studio or via CLI in the extracted folder:

```
dotnet run
```
