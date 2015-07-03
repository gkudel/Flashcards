﻿using Flashcards.Areas.Admin.Browser;
using Flashcards.Areas.Admin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flashcards.Areas.Admin.Controllers
{
    public class BrowserController : Controller
    {
        // GET: /Admin/CategoryGroup/
        public JsonResult ReadBrowser(string id)
        {
            return Json(BrowserProvider.GetBrowser(id), JsonRequestBehavior.AllowGet);
        }
	}
}