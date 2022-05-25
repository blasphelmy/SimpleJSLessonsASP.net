using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJSLessons.Models
{
    [Table("dataDataTable")]
    public partial class DataDataTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("imageData")]
        public string ImageData { get; set; }
        [Required]
        [Column("dataHash")]
        [StringLength(24)]
        public string DataHash { get; set; }
        [Column("uploadedBy")]
        [StringLength(30)]
        public string UploadedBy { get; set; }
        [Column("title")]
        [StringLength(128)]
        public string Title { get; set; }

        public virtual DataTable DataHashNavigation { get; set; }
    }
}
