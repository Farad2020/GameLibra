using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameLibra.Models
{
    public class Games_and_Users
    {
        public int Id { get; set; }
        // Game ID(FK)
        public int GameId { get; set; }

        public Game Game { get; set; }
        // Genre ID(FK)
        public int GenreId { get; set; }

    }
}