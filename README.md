# _|RecipeBox|_
<div align="center">
    <!-- Project Shields -->
    <div align="center">
        <a href="https://github.com/MarcusKyung/RecipeBox2.Solution/graphs/contributors">
            <img src="https://img.shields.io/github/contributors/MarcusKyung/RecipeBox2.Solution.svg?style=plastic">
        </a>
        ¨
        <a href="https://github.com/MarcusKyung/RecipeBox2.Solution/stargazers">
            <img src="https://img.shields.io/github/stars/MarcusKyung/RecipeBox2.Solution.svg?color=yellow&style=plastic">
        </a>
        ¨
        <a href="https://github.com/MarcusKyung/RecipeBox2.Solution/issues">
            <img src="https://img.shields.io/github/issues/MarcusKyung/RecipeBox2.Solution?style=plastic">
        </a>
        ¨
        <a href="https://github.com/MarcusKyung/RecipeBox2.Solution/blob/main/LICENSE.txt">
            <img src="https://img.shields.io/github/license/MarcusKyung/RecipeBox2.Solution?color=orange&style=plastic">
        </a>
        ¨
        <a href="https://linkedin.com/in/MarcusKyung">
            <img src="https://img.shields.io/badge/-LinkedIn-black.svg?style=plastic&logo=linkedin&colorB=2867B2">
        </a>
    </div>
</div>

#### By _**Marcus Kyung**_

#### _This full CRUD EF Core based C# web application is allows a user to create recipes and associate them with ingredients and tags._

## Contents
* [Technologies Used](#technologies-used)
* [Description](#description)
* [Setup & installation](#setupinstallation-requirements)
* [Known-bugs](#known-bugs)
* [License](#license)

## Technologies Used

* _C#/.NET Version v6.0.402_
* _EF Core v6.0.0_
* _ASP.NET MVC Framework_
* _SQL/MySQLWorkbench_
* _Microsoft Identity_


## Description

This full CRUD C# web application allows a user to create recipes and associate them with ingredients and tags. Data is stored in a mySQL database and is accessed via Entity Framework Core. The application is built using the ASP.NET MVC framework and utilizes the Razor view engine. The application also utilizes Microsoft Identity for user authentication.

## Setup/Installation Requirements

1. Clone this repo from GH to your local machine.
2. In root directory of the file called RecipeBox2.Solution, add a file titled ```appsettings.json```.
3. Within `appsettings.json`, put in the following code, replacing the `databasename`, `uid`, and `pwd` values with your own username and password for MySQL.
```json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[INSERT-DATABASENAME-HERE];uid=[INSERT-UID-HERE];pwd=[INSERT-PWD-HERE];"
  }
}
```
4. Using your device's terminal navigate to the production directory, "/RecipeBox", and run the command: ```dotnet ef database update```. Doing so will load the database information required based on configurations in the included migrations file.
5. Within the production directory "/RecipeBox", run `dotnet run` in the command line to start the project.
6. Open the project in your browser by navigating to _https://localhost:5001_. 
7. Alternatively, the project can be run in development mode with `dotnet watch run`. Doing so will allow the project to be viewed at _http://localhost:5001_.

## Known Bugs

* _No known bugs as of 6/2/23._

## License

_For questions, comments, or concerns please reach out at Kyungmj@gmail.com_

MIT License

Copyright (c) [2023] [Marcus Kyung]