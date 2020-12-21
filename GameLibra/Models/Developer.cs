using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameLibra.Models
{
    public class Developer
    {
        // Dev ID
        [Key]
        public int Id { get; set; }
        // Dev name

        //[Required(ErrorMessage = "Developer name is required", AllowEmptyStrings = false)]
        [NotNullOrWhiteSpaceValidator]
        [Display(Name = "Developer Name")]
        [MaxLength(255, ErrorMessage = "Maximum 255 characters allowed")]
        public string Name { get; set; }

        public Developer()
        {
        }
    }
}