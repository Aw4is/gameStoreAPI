//First file that will run - creates insance of web application
//Hosts application - represent/introduce HTTP server of your app
//So it can listen/respond to HTTP requests, provides login/configuration services for more functionality

//Can add more configurations using this builder object
using System.Net;
using gameStore.Dtos;

var builder = WebApplication.CreateBuilder(args);


//Builds instance of web server
var app = builder.Build();







//Actualy runs the app in a server
app.Run();
