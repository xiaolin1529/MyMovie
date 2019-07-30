using MyMovie.Areas.T1News.CS;
using MyMovie.Areas.T1News.Models;
using MyMovie.Areas.T1News.Models.Local;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyMovie.Areas.T1News.Controllers
{
    public class ManagerController : Controller
    {
        // GET: T1News/Manager
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        public ActionResult Login()
        {
            string username = Request.Form["user"];
            string password = Request.Form["password"];
            if ("admin".Equals(username) && "123456".Equals(password))
            {
                
               var data  = SQLHelper.GetAllNews();
                return View("Manager",data.ToList());
            }

            else
                return View();

        }

        public ActionResult Manager()
        {
            return View("Manager", SQLHelper.GetAllNews().ToList());
        }


        // GET: T1News/Index/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T1News/Index/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "NewID,ClassesName,Title,Author,Original,Content")] NewsDetails newsDetails)
        {
            if (ModelState.IsValid)
            {
                SQLHelper.AddNews(newsDetails);
                return RedirectToAction("Manager");
            }

            return View(newsDetails);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var detail = SQLHelper.GetNewsDetails(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // GET: 
        public ActionResult Editor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var data = SQLHelper.GetNewsDetails(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }

        // POST: 
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Editor([Bind(Include = "NewID,ClassesName,Title,Author,Original,Content")] NewsDetails newsDetails)
        {

            if (ModelState.IsValid)
            {
                SQLHelper.SaveNewsDetails(newsDetails);
                return RedirectToAction("Manager");
            }
            return View(newsDetails);
        }



        // GET: T1News/Index/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var detail = SQLHelper.GetNewsDetails(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // POST: T1News/Index/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SQLHelper.RemoveNews(id);
            return RedirectToAction("Manager");
        }


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        SQLHelper.CloseDB();
        //    }
        //    base.Dispose(disposing);
        //}

    }


}