namespace MyMovie.Areas.T2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T2Movie
    {
        [Key]
        [StringLength(3)]
        public string MovieId { get; set; }

        [StringLength(50)]
        public string MovieName { get; set; }

        [StringLength(50)]
        public string MovieImage { get; set; }

        [StringLength(50)]
        public string Other { get; set; }
    }
}
