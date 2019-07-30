namespace MyMovie.Areas.T2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T2Cinema
    {
        [Key]
        [StringLength(3)]
        public string CinemaId { get; set; }

        [StringLength(50)]
        public string CinemaName { get; set; }

        [StringLength(50)]
        public string Adderss { get; set; }

        [StringLength(30)]
        public string MiniPrice { get; set; }

        [StringLength(50)]
        public string Other { get; set; }
    }
}
