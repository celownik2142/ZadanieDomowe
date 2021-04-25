using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZadanieRekrutacyjne.Models;

namespace ZadanieRekrutacyjne.Controllers
{
    public class UserPermissionsController : Controller
    {
        private ZadanieRekrutacyjneEntities db = new ZadanieRekrutacyjneEntities();

        // GET: UserPermissions
        public ActionResult Index()
        {
            var userPermission = db.UserPermission.Include(u => u.Permissions).Include(u => u.Users);
            return View(userPermission.ToList());
        }

        // GET: UserPermissions/Create
        public ActionResult Create()
        {
            ViewBag.PermissionID = new SelectList(db.Permissions, "PermissionID", "PermissionCode");
            ViewBag.UserID = new SelectList(db.Users, "UserId", "Login");
            return View();
        }

        // POST: UserPermissions/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserPermissionID,UserID,PermissionID")] UserPermission userPermission)
        {
            if (ModelState.IsValid)
            {
                db.UserPermission.Add(userPermission);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PermissionID = new SelectList(db.Permissions, "PermissionID", "PermissionCode", userPermission.PermissionID);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "Login", userPermission.UserID);
            return View(userPermission);
        }

        // GET: UserPermissions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPermission userPermission = db.UserPermission.Find(id);
            if (userPermission == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermissionID = new SelectList(db.Permissions, "PermissionID", "PermissionCode", userPermission.PermissionID);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "Login", userPermission.UserID);
            return View(userPermission);
        }

        // POST: UserPermissions/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserPermissionID,UserID,PermissionID")] UserPermission userPermission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userPermission).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PermissionID = new SelectList(db.Permissions, "PermissionID", "PermissionCode", userPermission.PermissionID);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "Login", userPermission.UserID);
            return View(userPermission);
        }

        // GET: UserPermissions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPermission userPermission = db.UserPermission.Find(id);
            if (userPermission == null)
            {
                return HttpNotFound();
            }
            return View(userPermission);
        }

        // POST: UserPermissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserPermission userPermission = db.UserPermission.Find(id);
            db.UserPermission.Remove(userPermission);
            db.SaveChanges();
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
