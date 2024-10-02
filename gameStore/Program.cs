//First file that will run - creates insance of web application
//Hosts application - represent/introduce HTTP server of your app
//So it can listen/respond to HTTP requests, provides login/configuration services for more functionality

//Can add more configurations using this builder object
using System.Net;
using gameStore.Data;
using gameStore.Dtos;

var builder = WebApplication.CreateBuilder(args);



//--connect to SQL lite
var connectionString = "Data Source=GameStore.db"; //Defines physical path to database file - not ideal but its sqlite
//This actually registers the service - Uses dependency injection
//Entity Framework will:
    //read connection string - create instance of gamestore context
    //Passes  DBcontext options which contain all data within the database
    //It will then connect to the database
    //Maps the entities to table
builder.Services.AddSqlite<GameStoreContext>(connectionString); //specify name of context then pass connection string


//Builds instance of web server
var app = builder.Build();







//Actualy runs the app in a server
app.Run();
