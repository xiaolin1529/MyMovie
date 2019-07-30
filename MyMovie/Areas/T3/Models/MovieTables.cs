namespace MyMovie.Areas.T3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MovieTables
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieID { get; set; }

        [StringLength(150)]
        public string MovieImage { get; set; }

        [Required]
        [StringLength(30)]
        public string MovieName { get; set; }

        public double? MovieGrade { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        [StringLength(20)]
        public string Areas { get; set; }

        [StringLength(20)]
        public string Years { get; set; }

        [StringLength(20)]
        public string MvType1 { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        [StringLength(20)]
        public string EditorName1 { get; set; }

        [StringLength(20)]
        public string EdImage1 { get; set; }

        [StringLength(20)]
        public string EditorName2 { get; set; }

        [StringLength(20)]
        public string EdImage2 { get; set; }

        [StringLength(20)]
        public string Actor1 { get; set; }

        [StringLength(20)]
        public string AcImage1 { get; set; }

        [StringLength(20)]
        public string Actor2 { get; set; }

        [StringLength(20)]
        public string AcImage2 { get; set; }

        [StringLength(20)]
        public string Actor3 { get; set; }

        [StringLength(20)]
        public string AcImage3 { get; set; }

        [StringLength(20)]
        public string AwardName1 { get; set; }

        [StringLength(20)]
        public string AwTpye1 { get; set; }

        [StringLength(20)]
        public string AwImage1 { get; set; }

        [StringLength(20)]
        public string AwardName2 { get; set; }

        [StringLength(20)]
        public string AwTpye2 { get; set; }

        [StringLength(20)]
        public string AwImage2 { get; set; }

        [StringLength(20)]
        public string Image1 { get; set; }

        [StringLength(20)]
        public string Image2 { get; set; }

        [StringLength(20)]
        public string Image3 { get; set; }

        [StringLength(20)]
        public string Language { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ShowTime { get; set; }

        public int? Length { get; set; }

        public int? Appraise { get; set; }

        public int? Profit { get; set; }
    }
}
