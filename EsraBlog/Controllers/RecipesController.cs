using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EsraBlog.Models;

namespace EsraBlog.Controllers
{
    public class RecipesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recipes
        public async Task<ActionResult> Index()
        {
            return View(await db.AdminPosts.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminPost adminPost = await db.AdminPosts.FindAsync(id);
            if (adminPost == null)
            {
                return HttpNotFound();
            }
            return View(adminPost);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Content,Title,Date,Author")] AdminPost adminPost)
        {
            if (ModelState.IsValid)
            {
                db.AdminPosts.Add(adminPost);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(adminPost);
        }

        // GET: Recipes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminPost adminPost = await db.AdminPosts.FindAsync(id);
            if (adminPost == null)
            {
                return HttpNotFound();
            }
            return View(adminPost);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Content,Title,Date,Author")] AdminPost adminPost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminPost).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(adminPost);
        }

        // GET: Recipes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdminPost adminPost = await db.AdminPosts.FindAsync(id);
            if (adminPost == null)
            {
                return HttpNotFound();
            }
            return View(adminPost);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AdminPost adminPost = await db.AdminPosts.FindAsync(id);
            db.AdminPosts.Remove(adminPost);
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
