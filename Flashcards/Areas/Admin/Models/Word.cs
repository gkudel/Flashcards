using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flashcards.Areas.Admin.Models
{
    public enum Level { Simple, Intermediate, Advance }

    public class Word
    {
        public int Id { get; set; }
        public Level? Level { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Translation> Translations { get; set; }
    }
}