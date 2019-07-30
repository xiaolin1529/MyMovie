namespace MyMovie.Areas.T1News.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [Key]
        public int NewID { get; set; }

        public int? ClassesID { get; set; }

        [Column(TypeName = "ntext")]
        public string Title { get; set; }

        [StringLength(20)]
        public string Author { get; set; }

        [StringLength(50)]
        public string Original { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
