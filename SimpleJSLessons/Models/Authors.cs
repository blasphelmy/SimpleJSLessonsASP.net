using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJSLessons.Models
{
    public partial class Authors
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("dataHash")]
        [StringLength(24)]
        public string DataHash { get; set; }
        [Required]
        [Column("username")]
        [StringLength(20)]
        public string Username { get; set; }
        [Column("dateAuthored", TypeName = "datetime")]
        public DateTime DateAuthored { get; set; }

        public virtual DataTable DataHashNavigation { get; set; }
    }
}
