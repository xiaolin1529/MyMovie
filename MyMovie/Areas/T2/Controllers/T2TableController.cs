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
    public class T2TableController : Controller
    {
        public string cinema1;
        private NewsModel db = new NewsModel();


        public ActionResult Index(string id)
        {
            T2Cinema cinema = db.T2Cinema.Find(id);
            cinema1 = cinema.CinemaName;
            ViewBag.result = cinema1;
            return View(db.T2Table.ToList());
        }
        // GET: T2/T2Table
       

        // GET: T2/T2Table/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T2Table t2Table = db.T2Table.Find(id);
            if (t2Table == null)
            {
                return HttpNotFound();
            }
            return View(t2Table);
        }

        // GET: T2/T2Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T2/T2Table/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTime,EndTime,RoomType,Price,Other")] T2Table t2Table)
        {
            if (ModelState.IsValid)
            {
                db.T2Table.Add(t2Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t2Table);
        }

        // GET: T2/T2Table/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T2Table t2Table = db.T2Table.Find(id);
            if (t2Table == null)
            {
                return HttpNotFound();
            }
            return View(t2Table);
        }

        // POST: T2/T2Table/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,EndTime,RoomType,Price,Other")] T2Table t2Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t2Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t2Table);
        }

        // GET: T2/T2Table/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T2Table t2Table = db.T2Table.Find(id);
            if (t2Table == null)
            {
                return HttpNotFound();
            }
            return View(t2Table);
        }

        // POST: T2/T2Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            T2Table t2Table = db.T2Table.Find(id);
            db.T2Table.Remove(t2Table);
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
