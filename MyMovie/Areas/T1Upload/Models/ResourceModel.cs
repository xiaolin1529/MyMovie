namespace MyMovie.Areas.T1Upload.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ResourceModel : DbContext
    {
        public ResourceModel()
            : base("name=ResourceModel")
        {
        }

        public virtual DbSet<T1resource> T1resource { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T1resource>()
                .Property(e => e.name)
                .IsFixedLength();
        }
    }
}
