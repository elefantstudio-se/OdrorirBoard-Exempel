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
using OdrorirBoard.Areas.BackEnd.Models;
using OdrorirBoard.Helpers;
using System.Collections;

namespace OdrorirBoard.Areas.BackEnd.Controllers
{
    public class ProjectsController : Controller
    {

        private ApplicationUserManager _userManager;
        private readonly SiteDataContext _context = new SiteDataContext();

        //-----------------------------------------
        //  ProjectAdmin BACKEND         //
        //-----------------------------------------

        public ActionResult Index()
        {
            return View(_context.Projects.ToList());
        }

        // GET: Notifications/Edit/5
        public ActionResult Change(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsViewModel.Project project = _context.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change([Bind(Include = "Id,CreatedOn,Name, Description, projectMembers,ProjectOwner,AddedToProject, ProjectState,Users,Teams,ProjectTasks")]ProjectsViewModel.Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(project).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Notifications/Create
        public ActionResult New()
        {
            return View();
        }

        // POST: Notifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New([Bind(Include = "Id,CreatedOn,Name, Description, projectMembers,ProjectOwner,AddedToProject, ProjectState,Users,Teams,ProjectTasks")] ProjectsViewModel.Project project)
        {
            
            
            if (ModelState.IsValid)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(project);
        }


        // GET: Notifications/Delete/5
        public ActionResult Remove(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectsViewModel.Project project = _context.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectsDeleteConfirmed(Guid id)
        {
            ProjectsViewModel.Project project = _context.Projects.Find(id);
            
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //-----------------------------------------
        //  ProjectAdmin BACKEND         //
        //-----------------------------------------
    }
}