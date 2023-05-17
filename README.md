# Player selection

This is the base code to work in this challenge, please don´t change the folder structure of WebApi and WebApiTest projects and don´t move the provided files to a different place as this will result in a test failure.

## Build the solution
This solution requires .NET 6 installed.

To build the solution run from the project folder
```shell
dotnet build
```

## Run solution locally
To run the solution locally just run this command from the project folder (WebApi folder)

```shell
dotnet run
```

## Run tests
To run the tests just run this command 

```shell
dotnet test
```

## Migration
Note that dotnet-ef tools is required to run the migration, run the following to install the tool
```shell
dotnet tool install --global dotnet-ef
``` 

### Add migration 
To add the migration, run this command from the project folder (WebApi folder)
```shell
dotnet ef migrations add InitialCreate
```
where InitialCreate is the  name of the migration

### Update database
```shell
dotnet ef database update
```

