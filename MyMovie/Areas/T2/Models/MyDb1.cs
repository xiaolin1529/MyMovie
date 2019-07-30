namespace MyMovie.Areas.T2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDb1 : DbContext
    {
        public MyDb1()
            : base("name=MyDb1")
        {
        }

        public virtual DbSet<T2Cinema> T2Cinema { get; set; }
        public virtual DbSet<T2Movie> T2Movie { get; set; }
        public virtual DbSet<T2Table> T2Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
