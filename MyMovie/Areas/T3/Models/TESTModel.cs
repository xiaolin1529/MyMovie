namespace MyMovie.Areas.T3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TESTModel : DbContext
    {
        public TESTModel()
            : base("name=TESTModel")
        {
        }

        public virtual DbSet<MovieTables> MovieTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
