using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameLibra.Models
{
    public class Games_and_Genres
    {
        public int Id { get; set; }
        // Game ID(FK)
        public int GameId { get; set; }

        public Game Game { get; set; }
        // Genre ID(FK)
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public Games_and_Genres()
        {
        }
    }
}