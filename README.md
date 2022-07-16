# IdentityAndAccess
Web API Project using .NET 6

## Technologies
- .NET 6
- ASP.NET Core Identity
- Entity Framework 6
- Swagger
- SQL Server


## Authentication and Authorization

### Authentication
Authentication is the process of determining a user's identity. When the user is authenticated, it means that the application knows who the user is.
For example, if a user is not logged in the application, and tries to access something that it's only available when the user is authenticated, it will return a 401 (Unauthorized) error, which means that the application doesn't know who is trying to access the resource.

### Authorization
Authorization is the process of determining whether a user has access to a resource. Once the user is authenticated, the app will validate that the user has the permission to access the resource.
For example, if a user is authenticated in the application, but does not have permission to access some resource, when trying to access it, it will return a 403 (Forbidden) error, which means that the application knows who the user is, but the user does not have permission to access the resource.

## Roles and Claims
For Authorization, it's possible to use Roles, Claims, or use both together.

### Roles
Roles are about the roles that a user has.
For example, a user might have a role of "User", a role of "Manager", etc.

### Claims
Claims are more flexible than Roles, they are a name value pair.
Claims based authorization checks the value of a claim and allows access to a resource based upon that value. An identity can contain multiple claims with multiple values and can contain multiple claims of the same type.

## Commands

### Creating a new migration
- To add a migration, select the API/Infrastructure project and execute `add-migration Migration_Name -Context Context_Name`

### Updating the database
- To run a migration, select the API/Infrastructure project and execute `update-database -Context Context_Name`


## References
-   **ASP.NET Core security topics - Microsoft Documentation**  
    [https://docs.microsoft.com/en-us/aspnet/core/security/?view=aspnetcore-6.0](https://docs.microsoft.com/en-us/aspnet/core/security/?view=aspnetcore-6.0)


