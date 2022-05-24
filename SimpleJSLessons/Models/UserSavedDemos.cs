using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJSLessons.Models
{
    public partial class UserSavedDemos
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("accountHash")]
        [StringLength(64)]
        public string AccountHash { get; set; }
        [Required]
        [Column("demoHash")]
        [StringLength(24)]
        public string DemoHash { get; set; }
        [Column("demoTitle")]
        [StringLength(128)]
        public string DemoTitle { get; set; }

        public virtual ApiUser AccountHashNavigation { get; set; }
        public virtual DataTable DemoHashNavigation { get; set; }
    }
}
