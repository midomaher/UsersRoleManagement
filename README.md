# Example Role-Based Authorization Using JWT Tokens in ASP .NET Core 8

This repository supports the below features:

• User Management:

         o Endpoints for CRUD operations on users.

         o Each user should have a username, email, password (hashed), and roles

• Role Management:

         o Endpoints for CRUD operations on roles
         
         o Each role should have a unique name and description.

• Authentication:
  
         o Endpoint for user login.
         o Implement JWT-based authentication.
         o Endpoint for refreshing JWT tokens.

• Multilingual Support:

         o Include the parameter X-Language in the header request ex. {"en-US", "ar-EG", "fr-FR"}

• Database Interaction:

         o Use SQLite, SQL Server or any preferred relational database for saving and retrieving data.

  o Use Entity Framework for managing users and roles
