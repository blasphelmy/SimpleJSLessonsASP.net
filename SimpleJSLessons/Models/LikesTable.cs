using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJSLessons.Models
{
    public partial class LikesTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("dataHash")]
        [StringLength(24)]
        public string DataHash { get; set; }
        [Required]
        [Column("username")]
        [StringLength(30)]
        public string Username { get; set; }

        public virtual ApiUser UsernameNavigation { get; set; }
    }
}
