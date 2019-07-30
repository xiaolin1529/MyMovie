namespace MyMovie.Areas.Message.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class W_message
    {
        public int Id { get; set; }

        public string User { get; set; }

        public string Content { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(50)]
        public string TimeAgo { get; set; }
    }
}
