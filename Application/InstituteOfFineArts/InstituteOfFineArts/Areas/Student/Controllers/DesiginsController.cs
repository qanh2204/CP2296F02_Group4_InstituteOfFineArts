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
using System.IO;

namespace InstituteOfFineArts.Areas.Student.Controllers
{
    public class DesiginsController : Controller
    {
        private InstituteOfFineArtsDBEntities db = new InstituteOfFineArtsDBEntities();

        // GET: Student/Desigins
        public async Task<ActionResult> Index()
        {
            if (Session["UserType"].Equals(3))
            {
                int UserIdSession = (int)Session["UserId"];
                var desigins = db.Desigins.Include(d => d.Competition).Include(d => d.Reward).Include(d => d.User).Where(d => d.UserId.Value.Equals(UserIdSession));
                return View(await desigins.ToListAsync());
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }

        // GET: Student/Desigins/Details/5
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

        // GET: Student/Desigins/Create
        //[ValidateInput(false)]
        public ActionResult Create()
        {
            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "Name");
            ViewBag.RewardId = new SelectList(db.Rewards, "RewardId", "Name");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FullName");
            return View();
        }

        // POST: Student/Desigins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]     
        //[ValidateInput(false)]
        public async Task<ActionResult> Create([Bind(Include = "DesiginId,Path,Name,Topic,Description,Date,Mark,Remark,Exhibition,Status,UserId,CompetitionId,RewardId,Price")] Desigin desigin, HttpPostedFileBase pathImg)
        {

            //upload file
            if (pathImg.ContentLength > 0)
            {
                // check extension
                string fileExtension = Path.GetExtension(pathImg.FileName); //.xxx
                if (fileExtension == ".png" || fileExtension == ".jpg")
                {
                    // uploading
                    string uploadFolder = Server.MapPath("/Uploads/");
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }                    
                    string newFileName = String.Format("{0}{1}{2}_{3}{4}_{5}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, pathImg.FileName);
                    string filePath = Path.Combine(uploadFolder, newFileName);
                    pathImg.SaveAs(filePath);
                    desigin.Path = "/Uploads/" + newFileName;
                    
                }
                else
                {
                    //.exe,.bat
                    // ko dc phep

                }
            }

            if (ModelState.IsValid)
            {
                desigin.Date = DateTime.Now;
                desigin.UserId = (int) Session["UserId"];
                db.Desigins.Add(desigin);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "Name", desigin.CompetitionId);
            
            return View(desigin);
        }
               
        // GET: Student/Desigins/Edit/5
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
            
            return View(desigin);
        }

        // POST: Student/Desigins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DesiginId,Path,Name,Topic,Description,Date,Mark,Remark,Exhibition,Status,UserId,CompetitionId,RewardId,Price")] Desigin desigin, HttpPostedFileBase pathImg)
        {
            try
            {
                //upload file
                if (pathImg.ContentLength > 0)
                {
                    // check extension
                    string fileExtension = Path.GetExtension(pathImg.FileName); //.xxx
                    if (fileExtension == ".png" || fileExtension == ".jpg")
                    {
                        // uploading
                        string uploadFolder = Server.MapPath("/Uploads/");
                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }
                        string newFileName = String.Format("{0}{1}{2}_{3}{4}_{5}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, pathImg.FileName);
                        string filePath = Path.Combine(uploadFolder, newFileName);
                        pathImg.SaveAs(filePath);
                        desigin.Path = "/Uploads/" + newFileName;

                    }
                    else
                    {
                        //.exe,.bat
                        // ko dc phep

                    }
                }

                if (ModelState.IsValid)
                {
                    desigin.Date = DateTime.Now;
                    desigin.UserId = (int)Session["UserId"];
                    db.Entry(desigin).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.CompetitionId = new SelectList(db.Competitions, "CompetitionId", "Name", desigin.CompetitionId);

                return View(desigin);
            }
            catch (Exception e)
            {
                return Redirect("Error");
            }
            
        }

        // GET: Student/Desigins/Delete/5
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

        // POST: Student/Desigins/Delete/5
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
