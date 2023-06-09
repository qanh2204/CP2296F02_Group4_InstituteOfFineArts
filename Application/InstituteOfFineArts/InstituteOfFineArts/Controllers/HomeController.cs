using InstituteOfFineArts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace InstituteOfFineArts.Controllers
{
    public class HomeController : Controller
    {
        private InstituteOfFineArtsDBEntities db = new InstituteOfFineArtsDBEntities();
        // GET: Compe
        public async Task<ActionResult> Index()
        {
            var competitions = db.Competitions.Include(c => c.Reward);
            return View(await competitions.ToListAsync());
        }
        // GET: Compe/Details/5
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}