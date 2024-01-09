# Lazy Load - Issie with Entity Framework Core 8
This project is related to the [issue 32708  from Entity Framework Core](https://github.com/dotnet/efcore/issues/32708).

## Context
Here we have 2 projects: 
- .NET Framework 4.6.1 with EF6
- .NET 8 with EF Core
Both of them uses AutoMapper 9.0.0 to map entities from the database to View Models and both of them EF uses Proxies to Lazy Load the entities.

For some unknown reason, the latest version (.NET8 + EF Core) is taking *exponentially* more time to do this map. And it's important to note that is exponentially, it means that in this given project, the difference may be not much relevant, but in production databases, it leads to unpracticable performance issues.

## How To Run
- Clone the repository;
- Open the SQL Server Management Studio and run the *"backup_schema_and_data"* to get the data and the schema of the database;
- Run one project then another to spot the difference;
