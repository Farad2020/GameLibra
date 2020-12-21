using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace GameLibra.Models
{
    public class Library
    {
        // Library ID
        [Key]
        public int Id { get; set; }

        // Library name
        [Required(ErrorMessage = "Library Name is required")]
        [MaxLength(255, ErrorMessage = "Maximum 255 characters allowed")]
        [Display(Name = "Library Name")]
        public string Name { get; set; }

        // Library Desription
        //[Required(ErrorMessage = "Library Desription is required")]
        [MaxLength(3000, ErrorMessage = "Maximum 3000 characters allowed")]
        public string Desription { get; set; }


        // Library creation date
        [Display(Name = "Creation date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Creation_date { get; set; }


        // Library Owner ID(FK User)
        public string ApplicationUserId { get; set; }

        [Display(Name = "User")]
        public ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Games_and_Libraries> GameLibraries { get; set; }

        public Library()
        {
        }
    }
}