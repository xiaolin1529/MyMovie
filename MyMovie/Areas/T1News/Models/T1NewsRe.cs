namespace MyMovie.Areas.T1News.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T1NewsRe
    {
        public int Id { get; set; }

        public int NewsID { get; set; }

        [StringLength(50)]
        public string ahthor { get; set; }

        [Column(TypeName = "ntext")]
        public string content { get; set; }
    }
}
