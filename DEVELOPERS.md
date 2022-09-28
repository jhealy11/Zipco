# User API Dev Guide
base url:
https://localhost:5001
Available Endpoints
api/User/Index
api/User/Get?id=x
api/User/CreateUser

api/Account/Index
api/Account/CreateAccount

sample api call:
https://localhost:5001/api/user/index

##To Build the database

Add-Migration InitialCreate -Project TestProject.Data
Update-Database


## Building
dotnet build;cd TestProject.WebAPI;dotnet run

## Testing
There are 3 Test Projects
	Unit Tests
		TestProject.Core.Tests
		TestProject.Service.Tests
	Integration Tests
		TestProject.Tests
			This solution has some tests that are purpousfully set to Skip, due to the fact the database may/may not have some data.
			Feel free to comment in/out the [Fact] Attribute where necessary.
	
rm -rd reports; dotnet build; dotnet test TestProject.Service.Tests --logger xunit --results-directory ./reports/ServiceTests
 dotnet build; dotnet test TestProject.Core.Tests --logger xunit --results-directory ./reports/CoreTests
 dotnet build; dotnet test TestProject.Tests --logger xunit --results-directory ./reports/TestProject

## Deploying
https://localhost:5001/api/user/index


 I did manage to create a docker file for the application. But I couldn't get it to communicate with the SQL Server instance running on the other docker image. 
I felt that the effort put into this, was slightly outside the scope of the exercise too. 
 When creating the docker file I did have to change the aspnet version from 3.0 to 3.1.

## docker run -p 5000:80 zipapi
## http://localhost:5000/api/user/index


## Additional Information
The database is not seeded, so some of the integartion tests to create users/accounts should be run first.
