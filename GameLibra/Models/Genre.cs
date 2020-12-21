using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace GameLibra.Models
{
    public class Genre : IValidatableObject
    {
        // Genre ID
        [Key]
        public int Id { get; set; }

        // Genre name
        [Required(ErrorMessage = "Genre name is required")]
        [MaxLength(255, ErrorMessage = "Maximum 255 characters allowed")]
        [Display(Name = "Genre")]
        public string Name { get; set; }

        // Genre Desription
        [Required(ErrorMessage = "Genre Desription is required")]
        [MaxLength(3000, ErrorMessage = "Maximum 3000 characters allowed")]
        [Display(Name = "Genre Desription")]
        public string Description { get; set; }

        public virtual ICollection<Games_and_Genres> GameGenres { get; set; }


        public virtual ICollection<Game> Games { get; set; }
        public Genre()
        {
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name.Any(c => char.IsDigit(c))) {
                yield return new ValidationResult("Genre Name Cannot Contain numbers");
            }
        }
    }
}