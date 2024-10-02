
//DbContext is a framework used for ORM that connects to a database
//It is used to interact with the database and manage the entity objects
//Provides functionality for querying, saving, and updating data. 
    //Queries - A query is a specific request for data from a database. 
    //It specifies what data is needed and under what conditions. 
    //Queries can be simple (retrieving all records from a table) 
    //or complex (retrieving filtered, sorted, and joined data from multiple tables).


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace gameStore.Data
{
    public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
    {
        //Each DbSet property in a DbContext corresponds to a table in the database with Game being the entity type
            //Adding something to DBset results in a new row being foromed
            //Entites are instances (objects) of classes that belong in a database

        //set<Game> is the same as saying {set;}
        public DbSet<Game> Games => Set<Game>();

        public DbSet<Genre> Genres => Set<Genre>();

    }
}