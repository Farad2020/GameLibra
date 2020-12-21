using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameLibra.Models
{
    public class Games_and_Libraries
    {
        public int Id { get; set; }
        // Game ID(FK)
        public int GameId { get; set; }

        public Game Game { get; set; }

        // Library ID(FK)
        public int LibraryId { get; set; }

        public Library Library { get; set; }

        public Games_and_Libraries()
        {
        }
    }
}