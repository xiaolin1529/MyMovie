using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMovie.Areas.Message.Models;
using MyMovie.Areas.T1News.Models;

namespace MyMovie.Areas.Message.Controllers
{
    public class MessageController : Controller
    {
        private NewsModel db = new NewsModel();

        // GET: Message/Message
        [AllowAnonymous]
        public ActionResult Index()
        {
            return PartialView();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(string frontViewData)
        {
            W_message New_message = new W_message();
            New_message.Content = frontViewData;
            New_message.CreateTime = DateTime.Now;
            if (New_message.Content != "")
            {
                db.W_message.Add(New_message);
                db.SaveChanges();
            }
            return PartialView();
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
