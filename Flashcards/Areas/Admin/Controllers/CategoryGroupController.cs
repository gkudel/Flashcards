using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Flashcards.Areas.Admin.Models;
using Flashcards.Areas.Admin.DAL;

namespace Flashcards.Areas.Admin.Controllers
{
    public class CategoryGroupController : Controller
    {
        private AdminContext db = new AdminContext();

        // GET: /Admin/CategoryGroup/
        public async Task<ActionResult> Index()
        {
            return View(await db.CategoryGroups.ToListAsync());
        }

        // GET: /Admin/CategoryGroup/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryGroup categorygroup = await db.CategoryGroups.FindAsync(id);
            if (categorygroup == null)
            {
                return HttpNotFound();
            }
            return View(categorygroup);
        }

        // GET: /Admin/CategoryGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/CategoryGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Description")] CategoryGroup categorygroup)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.CategoryGroups.Add(categorygroup);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", " Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(categorygroup);
        }

        // GET: /Admin/CategoryGroup/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryGroup categorygroup = await db.CategoryGroups.FindAsync(id);
            if (categorygroup == null)
            {
                return HttpNotFound();
            }
            return View(categorygroup);
        }

        // POST: /Admin/CategoryGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPost(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var categoryGroupsToUpdate = db.CategoryGroups.Find(id);

            if (TryUpdateModel(categoryGroupsToUpdate, "",
                new string[] { "Description" }))
            {
                try
                {
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(categoryGroupsToUpdate);
        }

        // GET: /Admin/CategoryGroup/Delete/5
        public async Task<ActionResult> Delete(int? id, bool? saveChangesError)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            CategoryGroup categorygroup = await db.CategoryGroups.FindAsync(id);
            if (categorygroup == null)
            {
                return HttpNotFound();
            }
            return View(categorygroup);
        }

        // POST: /Admin/CategoryGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                CategoryGroup categorygroup = await db.CategoryGroups.FindAsync(id);
                db.CategoryGroups.Remove(categorygroup);
                await db.SaveChangesAsync();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
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
