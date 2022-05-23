using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJSLessons.Models
{
    [Table("sessionID")]
    public partial class SessionId
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("sessionID")]
        [StringLength(64)]
        public string SessionIdHash { get; set; }
        [Required]
        [Column("accountHash")]
        [StringLength(64)]
        public string AccountHash { get; set; }

        public virtual ApiUser AccountHashNavigation { get; set; }
    }
}
