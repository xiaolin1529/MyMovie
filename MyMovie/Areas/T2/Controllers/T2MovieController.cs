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
    public class T2MovieController : Controller
    {
        private NewsModel db = new NewsModel();

        // GET: T2/T2Movie
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
                return PartialView(db.T2Movie.ToList());
            return View(db.T2Movie.ToList());
        }

        // GET: T2/T2Movie/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T2Movie t2Movie = db.T2Movie.Find(id);
            if (t2Movie == null)
            {
                return HttpNotFound();
            }
            return View(t2Movie);
        }

        // GET: T2/T2Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T2/T2Movie/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,MovieName,MovieImage,Other")] T2Movie t2Movie)
        {
            if (ModelState.IsValid)
            {
                db.T2Movie.Add(t2Movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t2Movie);
        }

        // GET: T2/T2Movie/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T2Movie t2Movie = db.T2Movie.Find(id);
            if (t2Movie == null)
            {
                return HttpNotFound();
            }
            return View(t2Movie);
        }

        // POST: T2/T2Movie/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,MovieName,MovieImage,Other")] T2Movie t2Movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t2Movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t2Movie);
        }

        // GET: T2/T2Movie/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T2Movie t2Movie = db.T2Movie.Find(id);
            if (t2Movie == null)
            {
                return HttpNotFound();
            }
            return View(t2Movie);
        }

        // POST: T2/T2Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            T2Movie t2Movie = db.T2Movie.Find(id);
            db.T2Movie.Remove(t2Movie);
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
