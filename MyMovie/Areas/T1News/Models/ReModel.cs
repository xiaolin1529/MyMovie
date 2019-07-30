namespace MyMovie.Areas.T1News.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ReModel : DbContext
    {
        public ReModel()
            : base("name=ReModel")
        {
        }

        public virtual DbSet<T1NewsRe> T1NewsRe { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T1NewsRe>()
                .Property(e => e.ahthor)
                .IsFixedLength();
        }
    }
}
