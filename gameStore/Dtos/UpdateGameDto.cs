//This is for updating/put requests

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameStore.Dtos
{
    public record class UpdateGameDto(
        string Name,
        string Genre,
        decimal Price,
        DateOnly ReleaseDate
    );
}