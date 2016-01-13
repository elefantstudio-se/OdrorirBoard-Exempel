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

namespace OdrorirBoard.Areas.BackEnd.Controllers
{
    public class NotifyController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly SiteDataContext _context = new SiteDataContext();
        //-----------------------------------------
        //  NOTIFICATION MANAGER BACKEND         //
        //-----------------------------------------

        public ActionResult Index()
        {
            return View(_context.Notifications.ToList());
        }

        public ActionResult ModNotifyDialog()
        {
            return PartialView("_NotifysDetails");
        }

        [HttpPost]
        public ActionResult ModNotifyDiaRedir()
        {
            return RedirectToAction("Index");
        }

        public ActionResult _NotifysDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var notification = _context.Notifications.Find(id);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return PartialView(notification);
        }


        // GET: Notifications/Edit/5
        public ActionResult Change(long? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var notification = _context.Notifications.Find(id.Value);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // POST: Notifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change([Bind(Include = "NotificationId,Title,NotificationType,Controller,Action,UserId,IsDismissed")] NotificationAlert.Notification notification)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(notification).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notification);
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
        public ActionResult New([Bind(Include = "NotificationId,Title,NotificationType,Controller,Action,UserId,IsDismissed")] NotificationAlert.Notification notification)
        {
            if (ModelState.IsValid)
            {
                _context.Notifications.Add(notification);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notification);
        }


        // GET: Notifications/Delete/5
        
        public ActionResult Remove(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationAlert.Notification notification = _context.Notifications.Find(id.Value);
            if (notification == null)
            {
                return HttpNotFound();
            }
            return View(notification);
        }

        // POST: Notifications/Delete/5
        
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            NotificationAlert.Notification notification = _context.Notifications.Find(id);
            _context.Notifications.Remove(notification);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //-----------------------------------------
        //  NOTIFICATION MANAGER BACKEND         //
        //-----------------------------------------
    }
}