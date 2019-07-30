using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMovie.Areas.T1News.Models;
using MyMovie.Areas.T1Upload.Models;

namespace MyMovie.Areas.T1Upload.Controllers
{
    public class T1resourceController : Controller
    {
        private NewsModel db = new NewsModel();

        // GET: T1Upload/T1resource
        public ActionResult Index()
        {
            if(Request.IsAjaxRequest())
            return PartialView(db.T1resource.ToList());
            return View(db.T1resource.ToList());
        }

        // GET: T1Upload/T1resource/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T1resource t1resource = db.T1resource.Find(id);
            if (t1resource == null)
            {
                return HttpNotFound();
            }
            return View(t1resource);
        }

        // GET: T1Upload/T1resource/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(FormCollection form)
        {
            if (Request.Files.Count == 0)
            {
                //Request.Files.Count 文件数为0上传不成功
                return View();
            }
            var file = Request.Files[0];
            if (file.ContentLength == 0)
            {
                //文件大小大（以字节为单位）为0时，做一些操作
                return View();
            }
            else
            {
                //文件大小不为0
                file = Request.Files[0];
                string name = Request.Form["name"];
                string other = Request.Form["other"];
                //保存成自己的文件全路径,newfile就是你上传后保存的文件,
                //服务器上的UpLoadFile文件夹必须有读写权限
                string target = Server.MapPath("/") + ("/ResourceFile/");//取得目标文件夹的路径
                string filename = file.FileName;//取得文件名字
                string path = target + filename;//获取存储的目标地址
                T1resource t1resource = new T1resource()
                {
                    name = name,
                    path = filename,
                    other = other
                };

                file.SaveAs(path);

                if (ModelState.IsValid)
                {
                    db.T1resource.Add(t1resource);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        // POST: T1Upload/T1resource/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        //// 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,name,path,other")] T1resource t1resource)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.T1resource.Add(t1resource);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(t1resource);
        //}

        // GET: T1Upload/T1resource/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T1resource t1resource = db.T1resource.Find(id);
            if (t1resource == null)
            {
                return HttpNotFound();
            }
            return View(t1resource);
        }

        // POST: T1Upload/T1resource/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,path,other")] T1resource t1resource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t1resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t1resource);
        }

        // GET: T1Upload/T1resource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T1resource t1resource = db.T1resource.Find(id);
            if (t1resource == null)
            {
                return HttpNotFound();
            }
            return View(t1resource);
        }

        // POST: T1Upload/T1resource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            T1resource t1resource = db.T1resource.Find(id);
            db.T1resource.Remove(t1resource);
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
