namespace MyMovie.Areas.T1Upload.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T1resource
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [Column(TypeName = "ntext")]
        public string path { get; set; }

        [StringLength(50)]
        public string other { get; set; }
    }
}
