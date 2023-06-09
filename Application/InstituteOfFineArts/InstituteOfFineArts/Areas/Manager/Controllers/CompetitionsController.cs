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

namespace InstituteOfFineArts.Areas.Manager.Controllers
{
    public class CompetitionsController : Controller
    {
        private InstituteOfFineArtsDBEntities db = new InstituteOfFineArtsDBEntities();

        // GET: Manager/Competitions
        public async Task<ActionResult> Index()
        {
            var competitions = db.Competitions.Include(c => c.Reward);
            return View(await competitions.ToListAsync());
        }

        // GET: Manager/Competitions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = await db.Competitions.FindAsync(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // GET: Manager/Competitions/Create
        public ActionResult Create()
        {
            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "Name");
            return View();
        }

        // POST: Manager/Competitions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CompetitionId,Name,Detail,StartDate,EndDate,Status,RewardId")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Competitions.Add(competition);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "Name", competition.RewardId);
            return View(competition);
        }

        // GET: Manager/Competitions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = await db.Competitions.FindAsync(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "Name", competition.RewardId);
            return View(competition);
        }

        // POST: Manager/Competitions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CompetitionId,Name,Detail,StartDate,EndDate,Status,RewardId")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competition).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "Name", competition.RewardId);
            return View(competition);
        }

        // GET: Manager/Competitions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = await db.Competitions.FindAsync(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        // POST: Manager/Competitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Competition competition = await db.Competitions.FindAsync(id);
            db.Competitions.Remove(competition);
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
