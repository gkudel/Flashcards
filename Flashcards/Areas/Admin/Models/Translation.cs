using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flashcards.Areas.Admin.Models
{
    public class Translation
    {
        public int Id { get; set; }

        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public int WordId { get; set; }
        public virtual Word Word { get; set; }
    }
}