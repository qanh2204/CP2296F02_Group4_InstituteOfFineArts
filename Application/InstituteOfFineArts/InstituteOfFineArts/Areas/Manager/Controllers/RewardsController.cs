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
    public class RewardsController : Controller
    {
        private InstituteOfFineArtsDBEntities db = new InstituteOfFineArtsDBEntities();

        // GET: Manager/Rewards
        public async Task<ActionResult> Index()
        {
            return View(await db.Rewards.ToListAsync());
        }

        // GET: Manager/Rewards/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reward reward = await db.Rewards.FindAsync(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            return View(reward);
        }

        // GET: Manager/Rewards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Rewards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RewardId,Name,Detail,Price")] Reward reward)
        {
            if (ModelState.IsValid)
            {
                db.Rewards.Add(reward);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(reward);
        }

        // GET: Manager/Rewards/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reward reward = await db.Rewards.FindAsync(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            return View(reward);
        }

        // POST: Manager/Rewards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RewardId,Name,Detail,Price")] Reward reward)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reward).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reward);
        }

        // GET: Manager/Rewards/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reward reward = await db.Rewards.FindAsync(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            return View(reward);
        }

        // POST: Manager/Rewards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reward reward = await db.Rewards.FindAsync(id);
            db.Rewards.Remove(reward);
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
