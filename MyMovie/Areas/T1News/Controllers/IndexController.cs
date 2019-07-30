using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMovie.Areas.T1News.Models;
using MyMovie.Areas.T1News.Models.Local;
using MyMovie.Areas.T1News.CS;

namespace MyMovie.Areas.T1News.Controllers
{
    public class IndexController : Controller
    {
        private NewsModel db = new NewsModel();

        // GET: T1News/Index
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
                return PartialView(db.News.ToList());
            return View(db.News.ToList());
        }

        // GET: T1News/Index/Details/5
        public ActionResult Details(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailsAll data = SQLHelper.GetDetailsAll(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

       

        public ActionResult AddRe(int? id)
        {
            int nid = (int)id;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T1NewsRe data = new T1NewsRe()
            {
                NewsID = nid
            };
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        

        [HttpPost]
        public ActionResult AddRe1(FormCollection form)
        {
            string author = Request.Form["author"];
            string content = Request.Form["content"];
            int id = int.Parse(Request.Form["nid"]);
            T1NewsRe data = new T1NewsRe()
            {
                NewsID = id,
                ahthor = author,
                content = content
            };
            NewsModel db = new NewsModel();
            if (ModelState.IsValid)
            {
                db.T1NewsRe.Add(data);
                db.SaveChanges();
                return Redirect(Url.Action("Details", "Index",new { id = id}));
            }
            return View(data);
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
