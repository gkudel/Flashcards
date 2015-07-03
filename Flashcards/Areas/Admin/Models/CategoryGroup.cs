using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flashcards.Areas.Admin.Models
{
    public class CategoryGroup
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1)]
        [Remote("ValidateCategoryGroup", "Validator", ErrorMessage = "The field Code must be unique", AdditionalFields = "Id")]
        public string Description { get; set; } 

        public virtual ICollection<Category> Categories { get; set; }

    }
}