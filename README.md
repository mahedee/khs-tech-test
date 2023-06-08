## KHS Tech Test

### Tools and Technology

__Backend application__ 
* Clean Architecture
* CQRS Pattern
* C#
* MS SQL Server
* Entity Framework
* AutoMapper
* MediatR
* ASP.NET Core Web API
* .NET 6.0
* Visual Studio 2022

__Frontend Application__  
* React.js
* Bootstrap

__How to run application__

* Run back end application 
    * Go to backend\TechTest
    * Open TechTest.sln file using visual studio
    * Change connection string in TechTest.API -> appsettings.json
    * Go to Package Manager Console
        * Set TechTest.API project as startup project
        * Set TechTest.Infrastructure as Default Project in Package Manager Console
        * Run ```Update-Database -Verbose```

* Run Front end application
    * Go to frontend\ClientApp
    * Open terminal and run ```npm start ```
    * Client application will run http://localhost:3003
