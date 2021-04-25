using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZadanieRekrutacyjne.Models;
using System.Security.Cryptography;
using System.Text;

namespace ZadanieRekrutacyjne.Controllers
{
    public class UsersController : Controller
    {
        private ZadanieRekrutacyjneEntities db = new ZadanieRekrutacyjneEntities();


        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Login,Password,FirstName,LastName,PESEL,DateOfBirth,PlaceOfBirth,Position")] Users users, [Bind(Include = "UserPermissionID,UserID,PermissionID")] UserPermission userPermission )
        {
            if (ModelState.IsValid)
            {
                users.Password = HashPassword(users.Password); //haszowanie hasła przy pomocy sha 256
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Login,Password,FirstName,LastName,PESEL,DateOfBirth,PlaceOfBirth,Position")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users users = db.Users.Find(id);
            db.Users.Remove(users);
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

        [HttpPost]
        public JsonResult DoesLoginExist(string login)
        {
            bool LoginExist = !db.Users.Any(x => x.Login == login);
            return Json(LoginExist);
        }

        [HttpPost]
        public JsonResult DoesPeselExist(string pesel)
        {
            bool PeselExist = !db.Users.Any(x => x.PESEL == pesel);
            return Json(PeselExist);
        }

        static string HashPassword(string password)
        {  
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringbuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringbuilder.Append(bytes[i].ToString("x2"));
                }
                return stringbuilder.ToString();
            }
        }

    }
}
