# DoggyRestApi

A Restful API project base on ASP.NET 6, implementing apis' self-discovery and HATEOAS.

## Table of Contents

- [Description](#description)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Description

DoggyRestApi is a Restful API project developed with ASP.NET 6. It showcases exceptional API self-discovery and HATEOAS capabilities. This project embraces SOLID and Clean Code principles, ensuring maintainability and extensibility of the codebase.  
Serving as a comprehensive backend system for a travel company, it offers seamless CRUD operations for travel routes, user authentication and authorization, shopping cart functionality, and order management. Leveraging technologies including EF Core, Dependency Injection, and JWT. It also includes unit tests for maximum reliability. The project is being continuously updated, please visit the GitHub repository: https://github.com/TuanyangQiu/DoggyRestApi


## Features
- CRUD for tourist routes
- User authentication and authorization
- Shopping cart management
- Orders management
- API self-discovery
- HATEOAS

## Getting Started

### Prerequisites

- Visual Studio 2022
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- SQL Server 2019

1. Clone code repository and open it in VS2022 
```
gh repo clone TuanyangQiu/DoggyRestApi
```  
2. Configure database in appsetting.json
```
  "DbContext": 
  {
    "ConnectionString": "server=YOUR_DB_IP;Database=DoggyRestApiDb;User Id=YOUR_DB_USER_NAME;Password=YOUR_DB_PASSWORD;"
  }
```
3. Configure JWT in appsetting.json
```
"Authentication": {
    "SecretKey": "YOUR_JWT_SECRET_KEY",
    "Issuer": "ISSUER_NAME",
    "Audience": "AUDIENCE_NAME"
  }
```
4. Update database by running the command in Package Manager Console in VS2022
```
Update-Database
```

### Installation

Updating...

## Usage

Updating...

## License

This project is licensed under the [MIT License](https://github.com/TuanyangQiu/DoggyRestApi/blob/bda482401f1134dcd8ef7c4f6e377825112a1d3d/LICENSE.txt).
