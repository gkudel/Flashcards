using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flashcards.Areas.Admin.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30,  MinimumLength=1)]        
        [Remote("ValidateCategory", "Validator", ErrorMessage = "The field Code must be unique", AdditionalFields = "Id")]
        public string Description { get; set; }

        public virtual ICollection<CategoryGroup> Groups { get; set; }
    }
}