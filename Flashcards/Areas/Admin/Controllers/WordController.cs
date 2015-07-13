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
    public class WordController : Controller
    {
        private AdminContext db = new AdminContext();

        // GET: /Admin/Word/
        public async Task<ActionResult> Index()
        {
            return View(await db.Words.ToListAsync());
        }

        // GET: /Admin/Word/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = await db.Words.FindAsync(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // GET: /Admin/Word/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Word/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Level")] Word word)
        {
            if (ModelState.IsValid)
            {
                db.Words.Add(word);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(word);
        }

        // GET: /Admin/Word/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = await db.Words.FindAsync(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // POST: /Admin/Word/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Level")] Word word)
        {
            if (ModelState.IsValid)
            {
                db.Entry(word).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(word);
        }

        // GET: /Admin/Word/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = await db.Words.FindAsync(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            return View(word);
        }

        // POST: /Admin/Word/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Word word = await db.Words.FindAsync(id);
            db.Words.Remove(word);
            await db.SaveChangesAsync();
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
