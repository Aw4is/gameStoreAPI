using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.Dtos;


namespace gameStore.EndPoints
{   
    //Static class - can not create instances/objects from it
    public static class GamesEndPoints
    {
        const string endPoint = "GetGame";

        private static readonly List<GameDto> games = [new(1,"Final","RPG",50,new DateOnly(2010,9,8))];

        //this makes it an extended method
        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app){
                var group = app.MapGroup("games"); //all of our endpoints will start with games becomes new route so /

                //--Dealing with empty fields
                    //We first add required attribtues in the class (creategamedto) dealing with create requests
                    //then we add withParameterValidation() at the end using a nuget package to do it automatically:
                group.WithParameterValidation(); //if parameter missing will throw error stating what is missing - applies to all


                //---------------------------------------- Get Request ------------------------------------------------


                //GET /games when request sent
                group.MapGet("/", () => games);

                //Get .games/<ID>           {id} in this format as it is a variable so acts as a placeholder
                group.MapGet("/{id}", (int id) => 
                {
                    //? means it can hold a null value
                    GameDto? game = games.Find(game => game.Id == id);

                    //need results.ok so it returns a Iresult
                    //If game is not defined - throw 404 error else return it using Results.ok
                    return game is null? Results.NotFound() : Results.Ok(game);

                })
                .WithName(endPoint);

                //With name essentially acts as a variable holding "games/{id}" so when we say GetGame we refer to the route games/{id}


                //---------------------------------------- Post/Create Request ------------------------------------------------


                //POST (create) /games
                group.MapPost("/", (CreateGameDto newGame) => {
                    
                    

                   
                    //--Adding games
                    GameDto game = new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);

                    games.Add(game);

                    //checking if game addition suceeded - tells where client can find resource
                    return Results.CreatedAtRoute("GetGame", new {id = game.Id}, game);
                }).WithParameterValidation(); //automatically deals with wrong input fields, returns what field is missing & 404 error

                //---------------------------------------- Put/Update Request ------------------------------------------------

                //UPDATE PUT (replace/update resource) /games
                group.MapPut("/{id}" , (int id, UpdateGameDto updatedGame) =>{

                    var index = games.FindIndex(game => game.Id ==id);

                    if (index == -1){
                        return Results.NotFound(); //can either do this or create new resource depends on what we want
                    }

                    games[index] = new GameDto(
                        id,
                        updatedGame.Name,
                        updatedGame.Genre,
                        updatedGame.Price,
                        updatedGame.ReleaseDate
                    );

                    return Results.NoContent();
                });

                //---------------------------------------- Delete Request ------------------------------------------------


                //DELETE /games/{id}

                group.MapDelete("/{id}", (int id) => {
                    //If id doesnt exist it doesnt matter - if there delete else it will do nothing
                    games.RemoveAll(game => game.Id == id);

                    return Results.NoContent();
                });


        return group;
    }
            
    }
}