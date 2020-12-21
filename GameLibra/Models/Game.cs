using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GameLibra.Models
{
    public class Game
    {
        // Game ID
        [Key]
        public int Id { get; set; }

        // Game name
        [Required(ErrorMessage = "Game name is required")]
        [Display(Name = "Game Name")]
        [MaxLength(255, ErrorMessage = "Maximum 255 characters allowed")]
        public string Name { get; set; }

        // Game data
        [Required(ErrorMessage = "Release date is required")]
        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Release_date { get; set; }


        // Game Desription
        [Required(ErrorMessage = "Game desription is required")]
        [MaxLength(3000, ErrorMessage = "Maximum 3000 characters allowed")]
        public string Desription { get; set; }

        // Game Dev ID(FK Developer)
        public Developer Developer { get; set; }

        // Game Dev ID(FK Developer)
        [Display(Name = "Developer")]
        public int DeveloperId { get; set; }


        // Game Pub ID(FK Publisher)
        public Publisher Publisher { get; set; }

        // Game Pub ID(FK Publisher)
        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }

        public virtual ICollection<Games_and_Genres> GameGenres { get; set; }

        public virtual ICollection<Games_and_Images> GameImages { get; set; }

        public virtual ICollection<Games_and_Trailers> GameTrailers { get; set; }

        public virtual ICollection<Games_and_Libraries> GameLibraries { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public Game(int id, string name, DateTime release_date, string desription, Developer developer, int developerId, Publisher publisher, int publisherId)
        {
            Id = id;
            Name = name;
            Release_date = release_date;
            Desription = desription;
            Developer = developer;
            DeveloperId = developerId;
            Publisher = publisher;
            PublisherId = publisherId;
        }

        public Game()
        {
        }

        public bool getTrue() {
            return true;
        }

        //public virtual ICollection<Games_and_Owners> GameOwners { get; set; }


    }
}