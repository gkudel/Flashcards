using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flashcards.Areas.Admin.Models
{
    public class Language
    {
        public int Id { get; set; }

        [Required]
        [StringLength(3, MinimumLength=1)]
        [Remote("ValidateLanguageCode", "Validator", ErrorMessage = "The field Code must be unique", AdditionalFields = "Id")]
        public string Code { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        public string Description { get; set; } 
    }
}