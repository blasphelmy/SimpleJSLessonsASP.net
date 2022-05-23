using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJSLessons.Models
{
    [Table("userSavedLessons")]
    public partial class UserSavedLessons
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("accountHash")]
        [StringLength(64)]
        public string AccountHash { get; set; }
        [Required]
        [Column("lessonHash")]
        [StringLength(24)]
        public string LessonHash { get; set; }
        [Column("lessonTitle")]
        [StringLength(128)]
        public string LessonTitle { get; set; }

        public virtual ApiUser AccountHashNavigation { get; set; }
    }
}
