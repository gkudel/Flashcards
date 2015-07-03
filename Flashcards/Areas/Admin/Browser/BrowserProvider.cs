using Flashcards.Areas.Admin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flashcards.Areas.Admin.Browser
{
    public static class BrowserProvider
    {
        public static object GetBrowser(string name)
        {
            object ret = null;
            using(AdminContext db = new AdminContext())
            {                
                if (!string.IsNullOrEmpty(name))
                {
                    switch (name)
                    {
                        case "CategoryGroup":
                            ret = (from g in db.CategoryGroups
                                  select new { g.Id, g.Description }).ToList();
                            break;
                    }
                }
            }
            return ret;
        }
    }
}