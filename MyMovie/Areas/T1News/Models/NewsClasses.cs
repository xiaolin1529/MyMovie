namespace MyMovie.Areas.T1News.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NewsClasses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClassesId { get; set; }

        [StringLength(20)]
        [Required]
        public string ClassesName { get; set; }
    }
}
