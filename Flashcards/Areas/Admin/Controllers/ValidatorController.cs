using Flashcards.Areas.Admin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Flashcards.Areas.Admin.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidatorController : Controller
    {
        private AdminContext db = new AdminContext();

        public ActionResult ValidateLanguageCode(string code, int? id)
        {
            if (id.HasValue)
            {
                return Json(db.Language.FirstOrDefault(l => l.Id != id && l.Code == code) == null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(db.Language.FirstOrDefault(l => l.Code == code) == null, JsonRequestBehavior.AllowGet);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}