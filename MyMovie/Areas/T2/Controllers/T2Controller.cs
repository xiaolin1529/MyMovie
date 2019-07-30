using MyMovie.Areas.T1News.Models;
using MyMovie.Areas.T2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMovie.Areas.T2.Controllers
{
    public class T2Controller : Controller
    {
        private NewsModel db = new NewsModel();
        public ActionResult Index2(string id)

        {
            T2Table table = db.T2Table.Find(id);
            string table1 = table.StartTime;
            string table2 = table.EndTime;
            string table3 = table.RoomType;
            // string table4 = table.Price.ToString();
            string s = "购票信息：";
            s += string.Format("开始时间：{0},\n结束时间：{1},\n 放映厅：{2}",
                table1, table2, table3);
            ViewBag.Result = s;

            return PartialView();
        }
        public ActionResult Index3()
        {

            return View();
        }

    }
}