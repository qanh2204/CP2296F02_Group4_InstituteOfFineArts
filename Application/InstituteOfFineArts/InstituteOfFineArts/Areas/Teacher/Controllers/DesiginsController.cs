using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InstituteOfFineArts.Models;

namespace InstituteOfFineArts.Areas.Teacher.Controllers
{
    public class DesiginsController : Controller
    {
        private InstituteOfFineArtsDBEntities db = new InstituteOfFineArtsDBEntities();

        // GET: Teacher/Desigins
        public async Task<ActionResult> Index()
        {
            var desigins = db.Desigins.Include(d => d.Competition).Include(d => d.Reward).Include(d => d.User);
            return View(await desigins.ToListAsync());
        }

        // GET: Teacher/Desigins/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desigin desigin = await db.Desigins.FindAsync(id);
            if (desigin == null)
            {
                return HttpNotFound();
            }
            return View(desigin);
        }

        // GET: Teacher/Desigins/Create
        public ActionResult Create()
        {
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "Name");
            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "Name");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FullName");
            return View();
        }

        // POST: Teacher/Desigins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DesiginId,Path,Name,Topic,Description,Date,Mark,Remark,Exhibition,Status,UserId,CompetitionId,RewardId,Price")] Desigin desigin)
        {
            if (ModelState.IsValid)
            {
                db.Desigins.Add(desigin);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "Name", desigin.CompetitionId);
            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "Name", desigin.RewardId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FullName", desigin.UserId);
            return View(desigin);
        }

        // GET: Teacher/Desigins/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desigin desigin = await db.Desigins.FindAsync(id);
            if (desigin == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "Name", desigin.CompetitionId);
            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "Name", desigin.RewardId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FullName", desigin.UserId);
            return View(desigin);
        }

        // POST: Teacher/Desigins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DesiginId,Path,Name,Topic,Description,Date,Mark,Remark,Exhibition,Status,UserId,CompetitionId,RewardId,Price")] Desigin desigin)
        {
           
            if (ModelState.IsValid)
            {                
                db.Entry(desigin).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "Name", desigin.CompetitionId);
            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "Name", desigin.RewardId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FullName", desigin.UserId);
            return View(desigin);
        }

        // GET: Teacher/Desigins/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Desigin desigin = await db.Desigins.FindAsync(id);
            if (desigin == null)
            {
                return HttpNotFound();
            }
            return View(desigin);
        }

        // POST: Teacher/Desigins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Desigin desigin = await db.Desigins.FindAsync(id);
            db.Desigins.Remove(desigin);
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
