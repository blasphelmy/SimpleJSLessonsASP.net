using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJSLessons.Models
{
    public partial class CommentsTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("datahash")]
        [StringLength(24)]
        public string Datahash { get; set; }
        [Required]
        [Column("commentAuthorUsername")]
        [StringLength(30)]
        public string CommentAuthorUsername { get; set; }
        [Required]
        [Column("comment")]
        [StringLength(255)]
        public string Comment { get; set; }
        [Column("date", TypeName = "datetime")]
        public DateTime Date { get; set; }
    }
}
