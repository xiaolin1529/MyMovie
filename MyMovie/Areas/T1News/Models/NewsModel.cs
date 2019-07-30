namespace MyMovie.Areas.T1News.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NewsModel : DbContext
    {
        public NewsModel()
            : base("name=NewsModelString")
        {
        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsClasses> NewsClasses { get; set; }

        public virtual DbSet<T1NewsRe> T1NewsRe { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<MyMovie.Areas.T2.Models.T2Movie> T2Movie { get; set; }

        public System.Data.Entity.DbSet<MyMovie.Areas.T2.Models.T2Table> T2Table { get; set; }

        public System.Data.Entity.DbSet<MyMovie.Areas.T2.Models.T2Cinema> T2Cinema { get; set; }

        public System.Data.Entity.DbSet<MyMovie.Areas.T3.Models.MovieTables> MovieTables { get; set; }

        public System.Data.Entity.DbSet<MyMovie.Areas.Message.Models.W_message> W_message { get; set; }

        public System.Data.Entity.DbSet<MyMovie.Areas.T1Upload.Models.T1resource> T1resource { get; set; }
    }
}
