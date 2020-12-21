using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameLibra.Models
{
    public class Games_and_Trailers
    {
        public int Id { get; set; }
        // Game ID(FK)
        public int GameId { get; set; }

        public Game Game { get; set; }

        // Game Trailer youtube link
        public string Link { get; set; }

        public Games_and_Trailers()
        {
        }
    }
}