# ASP.NET Core practice project - to-do list

A project I have created while studying ASP.NET MVC, Entity Framework and the .NET Core ecosystem in general.

I know that making to-do lists as portfolio projects is a meme, don't take this app as a serious project - it was made just for educational purposes.
I didn't use much scaffolding so that I could focus on understanding what happens in the app.

It's not really meant to be a production-ready project - hence the hard-coded connection string, no containerization etc.

## Running

### Visual Studio

- open this project's solution
- wait until dependencies have been restored
- update the connection string in `AspNetPracticeTodo/appsettings.json` (if needed)
- open the NuGet console and type in `update-database` in order to make DB migrations
- run this app (`Ctrl+F5` in order to run without attaching the debugger)
