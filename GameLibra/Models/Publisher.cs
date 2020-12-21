using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameLibra.Models
{
    public class Publisher
    {
        // Publisher ID
        [Key]
        public int Id { get; set; }

        // Publisher name
        [Required(ErrorMessage = "Publisher name is required")]
        [RegularExpression(@"^[A-Z].*",
         ErrorMessage = "Only can starting from Uppercase Characters is allowed.")]
        [MaxLength(255, ErrorMessage = "Maximum 255 characters allowed")]
        [Display(Name = "Publisher Name")]
        public string Name { get; set; }

        public Publisher()
        {

        }
    }
}