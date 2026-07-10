# CSharp--CodingTracker
C#Academy Coding Tracker

## Project description
Coding Tracker is a console application that helps developers track and visualize the amount of time they spend coding. Whether you're a beginner or a seasoned developer, this tool lets you log your coding sessions and keep an overview of your progress over time. Users can add a new coding session, view all logged sessions, update an existing session, and delete a session.

## Technologies Used 
* Language: C# (.NET 10.0)
* Database: SQLite
* ORM: Dapper (2.1.79)
* Console UI: Spectre.Console(0.57.0) - for displaying data in formatted tables
* Configuration: Microsoft.Extensions.Configuration.Json — for reading settings from appsettings.json
* Database drive: Microsoft.Data.Sqlite

## Project structure
* `CodingSession.cs` > Model class representing a single coding session, with properties `Id`, `StartTime`, `EndTime` and `Duration`.
* `CodingSessionRepository.cs` > Handles all database access (Create, Read, Update and Delete) using Dapper. Responsible for initializing the database, and converting between C# types and SQLite-compatible types. 
* `UserInput.cs` > Responsible for prompting the user for input and reading it from the console. Delegates the actual validation logic to `Validation.cs`.
* `Validation.cs` > Contains the logic for validating whether a given string is a correctly formatted date/time, using `DateTime.TryParseExact`. 
* `CodingController.cs` > Orchestrates the application flow: shows the menu, processes the user's choice, and coordinates between `UserInput`, `CodingSessionRepository` and `PresentData`. 
* `PresentData.cs` > Responsible for displaying data to the user, using Spectre.Console to render sessions as a formatted table. 
* `Program.cs` > The entry point of the application. Initialized the database and starts the menu. 



