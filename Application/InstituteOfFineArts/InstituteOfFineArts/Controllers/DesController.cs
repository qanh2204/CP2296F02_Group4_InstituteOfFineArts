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

namespace InstituteOfFineArts.Controllers
{
    public class DesController : Controller
    {
        private InstituteOfFineArtsDBEntities db = new InstituteOfFineArtsDBEntities();

        // GET: Des
        public async Task<ActionResult> Index()
        {
            var desigins = db.Desigins.Include(d => d.Competition).Include(d => d.Reward).Include(d => d.User).Where(d => d.Exhibition == 0);
            return View(await desigins.ToListAsync());
        }

        // GET: Des/Details/5
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


    }
}
