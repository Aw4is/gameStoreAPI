//this is for initially making the games

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Records are immutable unlike classes so thats why we use it
//Good for DTos as they carry data from one place to another - no need for mutability 
//Reduce boilerplate code to make data implementation easier


namespace gameStore.Dtos
{
    public record class GameDto(
        int Id,
        string Name, 
        string Genre, 
        decimal Price,
        DateOnly ReleaseDate);
}