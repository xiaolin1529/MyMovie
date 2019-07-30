using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMovie.Areas.T1News.Models;
using MyMovie.Areas.T2.Models;

namespace MyMovie.Areas.T2.Controllers
{
    public class T2CinemaController : Controller
    {
        private NewsModel db = new NewsModel();
        public string movie1;
      
        public ActionResult Index(string id)
        {
            T2Movie movie = db.T2Movie.Find(id);
            movie1 = movie.MovieName;
            ViewBag.result = movie1;
            return View(db.T2Cinema.ToList());
        }


        // GET: T2/T2Cinema/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T2Cinema t2Cinema = db.T2Cinema.Find(id);
            if (t2Cinema == null)
            {
                return HttpNotFound();
            }
            return View(t2Cinema);
        }

        // GET: T2/T2Cinema/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T2/T2Cinema/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CinemaId,CinemaName,Adderss,MiniPrice,Other")] T2Cinema t2Cinema)
        {
            if (ModelState.IsValid)
            {
                db.T2Cinema.Add(t2Cinema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t2Cinema);
        }

        // GET: T2/T2Cinema/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T2Cinema t2Cinema = db.T2Cinema.Find(id);
            if (t2Cinema == null)
            {
                return HttpNotFound();
            }
            return View(t2Cinema);
        }

        // POST: T2/T2Cinema/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CinemaId,CinemaName,Adderss,MiniPrice,Other")] T2Cinema t2Cinema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t2Cinema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t2Cinema);
        }

        // GET: T2/T2Cinema/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T2Cinema t2Cinema = db.T2Cinema.Find(id);
            if (t2Cinema == null)
            {
                return HttpNotFound();
            }
            return View(t2Cinema);
        }

        // POST: T2/T2Cinema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            T2Cinema t2Cinema = db.T2Cinema.Find(id);
            db.T2Cinema.Remove(t2Cinema);
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
