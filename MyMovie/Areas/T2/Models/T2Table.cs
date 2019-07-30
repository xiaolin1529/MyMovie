namespace MyMovie.Areas.T2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T2Table
    {
        [StringLength(3)]
        public string Id { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        [StringLength(50)]
        public string RoomType { get; set; }

        public double Price { get; set; }

        [StringLength(50)]
        public string Other { get; set; }
    }
}
