using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using OdrorirBoard.Models;
using OdrorirBoard.Models.Modals;
using OdrorirBoard.Areas.BackEnd.Models;
using OdrorirBoard.Helpers;


namespace OdrorirBoard.Areas.BackEnd.Controllers
{
    public class TeamsController : Controller
    {

        private ApplicationUserManager _userManager;
        private readonly SiteDataContext _context = new SiteDataContext();

        //-----------------------------------------
        //  TEAMADMIN BACKEND         //
        //-----------------------------------------

        public ActionResult Index()
        {
            return View(_context.Teams.ToList());
        }

        // GET: Notifications/Edit/5
        public ActionResult Change(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            TeamViewModel.Team team = _context.Teams.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change([Bind(Include = "Id,CreatedOn, Name, TeamState,Projects")] TeamViewModel.Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(team).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        // GET: Notifications/Create
        public ActionResult New()
        {
            return PartialView("New");
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> New([Bind(Include = "Id,CreatedOn, Name, TeamState,Projects")] TeamViewModel.Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Add(team);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            return PartialView("New",team);
        }

        // GET: Notifications/Delete/5
        [HttpGet]
        public async Task<ActionResult> Remove (Guid? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamViewModel.Team team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return PartialView("Remove",team);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TeamDeleteConfirmed(Guid id)
        {
            TeamViewModel.Team team = await _context.Teams.FindAsync(id);

              _context.Teams.Remove(team);
              await _context.SaveChangesAsync();
              return Json(new { success = true });
        }
        [HttpGet]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //TeamViewModel.Team team = await _context.Teams.FindAsync(id);
            var teamDetails = (_context.Teams.Where(team => team.Id == id).Take(1).ToList());

            if (teamDetails == null)
            {
                return HttpNotFound();
            }

            return PartialView("Details", teamDetails);
        }


        //-----------------------------------------
        //  TEAMADMIN BACKEND         //
        //-----------------------------------------

    }
}