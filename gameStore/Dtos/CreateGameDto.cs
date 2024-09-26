//This is for creating

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//Difference to GameDTo is the id, we implement the id ourselves
//This is to create new games given by client so it is a POST operation
namespace gameStore.Dtos
{   
    //[] represents attributes think of them as libraries that work automatically in the background
    public record class CreateGameDto(
        [Required][StringLength(50)] string Name,
        [Required] [StringLength(20)]string Genre,
        [Range(1,100)] decimal Price,
        DateOnly ReleaseDate);
}