//Represent Data Model of our Application
//We can not use Dtos as:
    //Represents contract between API and client
    //Should rarely change
    //Model regularly changes, we want flexibility to change tables and make a relationship structure

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameStore.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        //required so we do not create nullable names
        public required string Name { get; set; }


    }
}