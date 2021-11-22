# IdentityAndAccess
Web API Project using .NET 6

## Technologies
- .NET 6
- Entity Framework 6
- Swagger
- SQL Server

## Commands

### Creating a new migration
- To add a migration, select the API project and execute `add-migration Migration_Name -Context ApplicationDbContext`

### Updating the database
- To run a migration, select the API project and execute `update-database -Context ApplicationDbContext`