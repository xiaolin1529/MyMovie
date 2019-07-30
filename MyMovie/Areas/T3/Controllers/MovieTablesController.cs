using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMovie.Areas.T1News.Models;
using MyMovie.Areas.T3.Models;

namespace MyMovie.Areas.T3.Controllers
{
    public class MovieTablesController : Controller
    {
        private NewsModel db = new NewsModel();

        // GET: T3/MovieTables
        public ActionResult Index(string search)
        {
            ViewBag.search = search;
            var t = db.MovieTables.ToList();
            if (string.IsNullOrEmpty(search) == false)
            {
                t = t.Where(s => s.Type.Contains(search) || s.Areas.Contains(search) || s.Years.Contains(search) || s.MovieName.Contains(search)).ToList();
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView(t);
            }
            return View(t);
        }
        public ActionResult Register()
        {
            return PartialView();
        }
        public ActionResult Add()
        {
            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView(db.MovieTables.ToList());
            //}
            return View(db.MovieTables.ToList());
        }
        // GET: T3/MovieTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieTables movieTables = db.MovieTables.Find(id);
            if (movieTables == null)
            {
                return HttpNotFound();
            }
            return View(movieTables);
        }

        // GET: T3/MovieTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T3/MovieTables/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieID,MovieImage,MovieName,MovieGrade,Type,Areas,Years,MvType1,Content,EditorName1,EdImage1,EditorName2,EdImage2,Actor1,AcImage1,Actor2,AcImage2,Actor3,AcImage3,AwardName1,AwTpye1,AwImage1,AwardName2,AwTpye2,AwImage2,Image1,Image2,Image3,Language,ShowTime,Length,Appraise,Profit")] MovieTables movieTables)
        {
            if (ModelState.IsValid)
            {
                db.MovieTables.Add(movieTables);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movieTables);
        }

        // GET: T3/MovieTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieTables movieTables = db.MovieTables.Find(id);
            if (movieTables == null)
            {
                return HttpNotFound();
            }
            return View(movieTables);
        }

        // POST: T3/MovieTables/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieID,MovieImage,MovieName,MovieGrade,Type,Areas,Years,MvType1,Content,EditorName1,EdImage1,EditorName2,EdImage2,Actor1,AcImage1,Actor2,AcImage2,Actor3,AcImage3,AwardName1,AwTpye1,AwImage1,AwardName2,AwTpye2,AwImage2,Image1,Image2,Image3,Language,ShowTime,Length,Appraise,Profit")] MovieTables movieTables)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieTables).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieTables);
        }

        // GET: T3/MovieTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieTables movieTables = db.MovieTables.Find(id);
            if (movieTables == null)
            {
                return HttpNotFound();
            }
            return View(movieTables);
        }

        // POST: T3/MovieTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieTables movieTables = db.MovieTables.Find(id);
            db.MovieTables.Remove(movieTables);
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
