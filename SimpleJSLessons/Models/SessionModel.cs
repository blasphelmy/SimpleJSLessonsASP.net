using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleJSLessons.Models
{
    public partial class SessionModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("sessionID")]
        [StringLength(64)]
        public string SessionId { get; set; }
        [Required]
        [Column("accountHash")]
        [StringLength(64)]
        public string AccountHash { get; set; }

        public virtual ApiUser AccountHashNavigation { get; set; }
    }
}
