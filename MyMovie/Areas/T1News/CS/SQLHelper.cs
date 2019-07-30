using MyMovie.Areas.T1News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMovie.Areas.T1News.Models.Local;
using System.Data.Entity;

namespace MyMovie.Areas.T1News.CS
{
    public class SQLHelper
    {
        private static NewsModel db = new NewsModel();

        public SQLHelper()
        {
            db = new NewsModel();
        }
        public static NewsDetails GetNewsDetails(int? id)
        {
            News news = db.News.Find(id);
            NewsClasses newsClasses = db.NewsClasses.Find(news.ClassesID);
            NewsDetails newsDetails = new NewsDetails
            {
                NewID = news.NewID,
                ClassesName = newsClasses.ClassesName,
                Title = news.Title,
                Author = news.Author,
                Original = news.Original,
                Content = news.Content
            };
            return newsDetails;
        }

        public static IEnumerable<T1NewsRe> GetNewsRe(int? id)
        {
            var sameIDRe = db.T1NewsRe.ToList();

            return sameIDRe;
        }

        public static DbSet<News> GetAllNews()
        {
            return db.News;
        }

        public static DetailsAll GetDetailsAll(int? id)
        {
            DetailsAll all = new DetailsAll(id);
            return all;
        }

        public static IEnumerable<DetailsOthers> GetDetailsOthers(int? id)
        {
            int? cid = db.News.Find(id).ClassesID;
            var sameClassList = from uu in db.News
                                join ud in db.NewsClasses on uu.ClassesID equals ud.ClassesId
                                where uu.ClassesID == cid && uu.NewID != id
                                select new DetailsOthers { NewID = uu.NewID, Title = uu.Title, ClassesName = ud.ClassesName };
            return sameClassList;
        }

       public static void SaveNewsDetails(NewsDetails newsDetails)
        {

            News news = db.News.Find(newsDetails.NewID);

           news.ClassesID = db.NewsClasses.FirstOrDefault(A => A.ClassesName.Equals("人文")).ClassesId;
            news.Title = newsDetails.Title;
            news.Author = newsDetails.Author;
            news.Original = news.Original;
            news.Content = newsDetails.Content;
            db.Entry(news).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static void AddNews(NewsDetails newsDetails)
        {
            News news = new News
            {
                Author = newsDetails.Author,
                ClassesID = db.NewsClasses.FirstOrDefault(A => A.ClassesName.Equals(newsDetails.ClassesName)).ClassesId,
                Original = newsDetails.Original,
                Title = newsDetails.Title,
                Content = newsDetails.Content
            };
            db.News.Add(news);
            db.SaveChanges();
        }

        public static void RemoveNews(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
        }

        public static void CloseDB()
        {
            db.Dispose();
        }
    }
}