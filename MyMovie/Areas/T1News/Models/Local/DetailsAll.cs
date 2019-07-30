using MyMovie.Areas.T1News.CS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMovie.Areas.T1News.Models.Local
{
  
    public class DetailsAll
    {
        public NewsDetails newsDetails { get; set; }
        public IEnumerable<DetailsOthers> SameClassNews { get; set; }

        public IEnumerable<T1NewsRe> NewsRe { get; set; }
        public DetailsAll(int? id)
        {
            this.newsDetails = SQLHelper.GetNewsDetails(id);
            this.SameClassNews = SQLHelper.GetDetailsOthers(id);
            this.NewsRe = SQLHelper.GetNewsRe(id);
        }
    }
}